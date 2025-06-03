
using System;
using System.Collections.Generic;
using Config;
using DsUi;
using Godot;

/// <summary>
/// 液体画布
/// </summary>
public partial class LiquidCanvas : Node2D, IDestroy
{
    private class SummaryPixel
    {
        public LiquidPixel Pixel;
        public LiquidLayerSprite Layer;
    }
    
    /// <summary>
    /// 程序每帧最多等待执行时间, 超过这个时间的像素点将交到下一帧执行, 单位: 毫秒
    /// </summary>
    public static float MaxWaitTime { get; set; } = 4f;

    /// <summary>
    /// 画布缩放
    /// </summary>
    public static int CanvasScale { get; } = 4;

    /// <summary>
    /// 画布每秒更新频率
    /// </summary>
    public static int UpdateFps { get; set; } = 20;
    
    /// <summary>
    /// 画布宽度
    /// </summary>
    public int Width { get; }
    
    /// <summary>
    /// 画布高度
    /// </summary>
    public int Height { get; }
    
    public bool IsDestroyed { get; private set; }
    
    //记录是否有像素点发生变动
    private bool _changeFlag = false;
    //所属房间
    private RoomInfo _roomInfo;

    private Dictionary<string, LiquidLayerSprite> _liquidLayer = new Dictionary<string, LiquidLayerSprite>();
    //画布上的像素点，这里代表所有层级的像素点
    private SummaryPixel[,] _imageUsePixels;
    
    public LiquidCanvas(RoomInfo roomInfo)
    {
        Name = "LiquidCanvas" + roomInfo.Id;
        _roomInfo = roomInfo;
        var size = (roomInfo.Size + new Vector2I(2, 2)) * GameConfig.TileCellSize;
        Width = size.X;
        Height = size.Y;
        Position = roomInfo.GetWorldPosition() - GameConfig.TileCellSizeVector2I;
        _imageUsePixels = new SummaryPixel[Width, Height];
    }
    
    public void Destroy()
    {
        if (IsDestroyed)
        {
            return;
        }
        
        IsDestroyed = true;
        
        foreach (var sprite in _liquidLayer)
        {
            sprite.Value.Destroy();
        }
        
        QueueFree();
    }

    /// <summary>
    /// 将画布外的坐标转为画布内的坐标
    /// </summary>
    public Vector2I ToLiquidCanvasPosition(Vector2 position)
    {
        return ((position - Position) / CanvasScale).AsVector2I();
    }

    /// <summary>
    /// 根据画笔数据在画布上绘制液体, 转换坐标请调用 ToLiquidCanvasPosition() 函数
    /// </summary>
    /// <param name="brush">画笔数据</param>
    /// <param name="layer">绘制的层级</param>
    /// <param name="position">绘制坐标, 相对于画布坐标</param>
    public void DrawBrush(BrushImageData brush, ExcelConfig.LiquidLayer layer, Vector2I position)
    {
        DrawBrush(brush, layer, null, position, 0);
    }
    
    /// <summary>
    /// 根据画笔数据在画布上绘制液体, 转换坐标请调用 ToLiquidCanvasPosition() 函数
    /// </summary>
    /// <param name="brush">画笔数据</param>
    /// <param name="layer">绘制的层级</param>
    /// <param name="position">绘制坐标, 相对于画布坐标</param>
    /// <param name="rotation">旋转角度, 弧度制</param>
    public void DrawBrush(BrushImageData brush, ExcelConfig.LiquidLayer layer, Vector2I position, float rotation)
    {
        DrawBrush(brush, layer, null, position, rotation);
    }

    /// <summary>
    /// 根据画笔数据在画布上绘制液体, 转换坐标请调用 ToLiquidCanvasPosition() 函数
    /// </summary>
    /// <param name="brush">画笔数据</param>
    /// <param name="layer">绘制的层级</param>
    /// <param name="prevPosition">上一帧坐标, 相对于画布坐标, 改参数用于两点距离较大时执行补间操作, 如果传 null, 则不会进行补间</param>
    /// <param name="position">绘制坐标, 相对于画布坐标</param>
    /// <param name="rotation">旋转角度, 弧度制</param>
    public void DrawBrush(BrushImageData brush, ExcelConfig.LiquidLayer layer, Vector2I? prevPosition, Vector2I position, float rotation)
    {
        LiquidLayerSprite liquidLayer;
        if (!_liquidLayer.TryGetValue(layer.Id, out liquidLayer))
        {
            liquidLayer = new LiquidLayerSprite();
            liquidLayer.Init(_roomInfo, layer, this, ResourceManager.LoadTexture2D(layer.Texture), (int)layer.Hframes);
            AddChild(liquidLayer);
            _liquidLayer.Add(layer.Id, liquidLayer);
        }

        var result = liquidLayer.DrawBrush(brush, prevPosition, position, rotation);
        foreach (var item in result)
        {
            var temp = _imageUsePixels[item.X, item.Y];
            if (temp == null)
            {
                temp = new SummaryPixel();
                _imageUsePixels[item.X, item.Y] = temp;
            }

            if (temp.Layer == liquidLayer) continue;

            //有更新层，也就是从这一层画到另一层上
            temp.Layer = liquidLayer;
            if (temp.Pixel != null)
            {
                temp.Pixel.Color.A = 0;
            }

            temp.Pixel = item;
        }
    }

    /// <summary>
    /// 返回是否碰到任何有效像素点
    /// </summary>
    public bool Collision(int x, int y)
    {
        if (x >= 0 && x < _imageUsePixels.GetLength(0) && y >= 0 && y < _imageUsePixels.GetLength(1))
        {
            var result = _imageUsePixels[x, y];
            if (result != null && result.Pixel.IsRun)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 返回碰撞到的有效像素点数据
    /// </summary>
    public LiquidPixel GetPixelData(int x, int y)
    {
        if (x >= 0 && x < _imageUsePixels.GetLength(0) && y >= 0 && y < _imageUsePixels.GetLength(1))
        {
            var result = _imageUsePixels[x, y];
            if (result != null && result.Pixel.IsRun)
            {
                return result.Pixel;
            }
        }

        return null;
    }
    
}