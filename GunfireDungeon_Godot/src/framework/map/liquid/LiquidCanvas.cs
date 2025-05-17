
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
    private class LiquidLayer
    {
        public ExcelConfig.LiquidLayer Config;
        public CanvasGroup CanvasGroup;
        public ShaderMaterial Material;
    }
    
    public bool IsDestroyed { get; private set; }

    private readonly Dictionary<string, LiquidLayer> _canvasGroups = new Dictionary<string, LiquidLayer>();
    
    
    public override void _Ready()
    {
        foreach (var item in ExcelConfig.LiquidLayer_List)
        {
            var canvasGroup = new CanvasGroup();
            var layer = new LiquidLayer();
            layer.CanvasGroup = canvasGroup;
            layer.Config = item;
            layer.Material = (ShaderMaterial)ResourceManager.Load<ShaderMaterial>(ResourcePath.resource_material_Liquid_tres).Duplicate();
            canvasGroup.Material = layer.Material;
            
            layer.Material.SetShaderParameter("tex", ResourceManager.LoadTexture2D(item.Texture));
            layer.Material.SetShaderParameter("hframes", item.Hframes);
            
            _canvasGroups.Add(item.Id, layer);
            AddChild(canvasGroup);
        }
    }

    public void Destroy()
    {
        if (IsDestroyed)
        {
            return;
        }
        
        IsDestroyed = true;
        _canvasGroups.Clear();
        QueueFree();
    }

    public override void _Process(double delta)
    {
        var camera = GameCamera.Main;
        foreach (var item in _canvasGroups)
        {
            item.Value.Material.SetShaderParameter("scale", camera.Zoom.X);
            item.Value.Material.SetShaderParameter("offset", camera.Position + camera.Offset);
        }
    }

    /// <summary>
    /// 根据画笔数据在画布上绘制液体, 转换坐标请调用 ToLiquidCanvasPosition() 函数
    /// </summary>
    /// <param name="brush">画笔数据</param>
    /// <param name="position">绘制坐标, 相对于画布坐标</param>
    public LiquidPoint DrawBrush(ExcelConfig.LiquidBrush brush, Vector2I position)
    {
        return DrawBrush(brush, null, position, 0);
    }
    
    /// <summary>
    /// 根据画笔数据在画布上绘制液体, 转换坐标请调用 ToLiquidCanvasPosition() 函数
    /// </summary>
    /// <param name="brush">画笔数据</param>
    /// <param name="position">绘制坐标, 相对于画布坐标</param>
    /// <param name="rotation">旋转角度, 弧度制</param>
    public LiquidPoint DrawBrush(ExcelConfig.LiquidBrush brush, Vector2I position, float rotation)
    {
        return DrawBrush(brush, null, position, rotation);
    }

    /// <summary>
    /// 根据画笔数据在画布上绘制液体, 转换坐标请调用 ToLiquidCanvasPosition() 函数
    /// </summary>
    /// <param name="brush">画笔数据</param>
    /// <param name="prevPoint">上一帧坐标, 相对于画布坐标, 改参数用于两点距离较大时执行补间操作, 如果传 null, 则不会进行补间</param>
    /// <param name="position">绘制坐标, 相对于画布坐标</param>
    /// <param name="rotation">旋转角度, 弧度制</param>
    public LiquidPoint DrawBrush(ExcelConfig.LiquidBrush brush, LiquidPoint? prevPoint, Vector2I position, float rotation)
    {
        var prevPosition = prevPoint?.Position;

        
        
        var texture = ResourceManager.LoadTexture2D(brush.BrushTexture);
        var layer = _canvasGroups[brush.Layer.Id];
        
        var tw = texture.GetWidth();
        var th = texture.GetHeight();
        
        
        //存在上一次记录的点
        if (prevPosition != null)
        {
            var offset = new Vector2(position.X - prevPosition.Value.X, position.Y - prevPosition.Value.Y);
            var maxL = brush.Ffm * Mathf.Lerp(tw, th, Mathf.Abs(Mathf.Sin(offset.Angle() - rotation + Mathf.Pi * 0.5f)));
            maxL = Mathf.Max(1, maxL);
            var len = offset.Length();
            if (len > maxL)
            {
                //Debug.Log($"距离太大了, 启用补间: len: {len}, maxL: {maxL}");
                var count = Mathf.CeilToInt(len / maxL);
                var step = new Vector2(offset.X / count, offset.Y / count);
                var prevPos = prevPosition.Value;

                for (var i = 1; i <= count - 1; i++)
                {
                    var x = (int)(prevPos.X + step.X * i);
                    var y = (int)(prevPos.Y + step.Y * i);

                    CreateSprite(brush, texture, layer, x, y, rotation);
                }

                
                return CreateSprite(brush, texture, layer, position.X, position.Y, rotation);
            }
            if (Mathf.Abs(prevPoint.Rotation - rotation) <= Mathf.DegToRad(5)) //在补间范围内
            {
                prevPoint.Refresh();
                return prevPoint;
            }
        }

        return CreateSprite(brush, texture, layer, position.X, position.Y, rotation);
    }

    private LiquidPoint CreateSprite(ExcelConfig.LiquidBrush brush, Texture2D texture, LiquidLayer layer, float x, float y, float rotation)
    {
        var sprite = new LiquidPoint();
        sprite.Texture = texture;
        sprite.Rotation = rotation;
        sprite.Position  = new Vector2(x, y);
        layer.CanvasGroup.AddChild(sprite);
        sprite.Init(brush);
        return sprite;
    }

    /// <summary>
    /// 返回是否碰到任何有效像素点
    /// </summary>
    public bool Collision(int x, int y)
    {
        return false;
    }

    /// <summary>
    /// 返回碰撞到的有效像素点数据
    /// </summary>
    public LiquidPixel GetPixelData(int x, int y)
    {
        return null;
    }
}