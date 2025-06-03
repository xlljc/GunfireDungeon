using System;
using System.Collections.Generic;
using Config;
using Godot;
using DsUi;

public partial class LiquidLayerSprite : Sprite2D, IDestroy
{
    private Image _maskImage;
    private ImageTexture _maskTexture;
    //画布上的像素点
    private LiquidPixel[,] _imagePixels;
    //需要执行更新的像素点
    private List<LiquidPixel> _updateImagePixels = new List<LiquidPixel>();
    //画布已经运行的时间
    private float _runTime = 0;
    private int _executeIndex = -1;
    //用于记录有变动的像素点
    private List<LiquidPixel> _tempList = new List<LiquidPixel>();
    //所属房间
    private RoomInfo _roomInfo;
    //记录是否有像素点发生变动
    private bool _changeFlag = false;
    
    private ExcelConfig.LiquidLayer _layerConfig;
    private ShaderMaterial _material;
    private double _processTimer;
    private LiquidCanvas _canvas;
    
    public bool IsDestroyed { get; private set;  }
    
    public void Init(RoomInfo roomInfo, ExcelConfig.LiquidLayer layer, LiquidCanvas canvas, Texture2D texture, int hFrames)
    {
        _roomInfo = roomInfo;
        _layerConfig = layer;
        _canvas = canvas;
        Name = "LiquidLayer" + layer.Id;
        
        Centered = false;

        var width = canvas.Width / 4;
        var height = canvas.Height / 4;
        _maskImage = Image.CreateEmpty(width, height, false, Image.Format.Rgba8);
        _maskTexture = ImageTexture.CreateFromImage(_maskImage);
        Texture = texture;

        RegionEnabled = true;
        RegionRect = new Rect2I(0, 0, canvas.Width, canvas.Height);
        Debug.Log("width: "  + canvas.Width + ", height: " + canvas.Height);
        
        _imagePixels = new LiquidPixel[width, height];
        
        _material = (ShaderMaterial)ResourceManager.Load<ShaderMaterial>(ResourcePath.resource_material_Liquid_tres).Duplicate();
        Material = _material;
        _material.SetShaderParameter("hframes", hFrames);
        _material.SetShaderParameter("origin_size", texture.GetSize());
        _material.SetShaderParameter("mask", _maskTexture);
        SetMaskAlpha(0.2f);
    }

    public void SetMaskFrame(int frame)
    {
        _material.SetShaderParameter("frame", frame);
    }

    public void SetMaskAlpha(float alpha)
    {
         _material.SetShaderParameter("alpha", alpha);
    }
    
    public void Destroy()
    {
        if (IsDestroyed)
        {
            return;
        }

        IsDestroyed = true;

        _maskTexture.Dispose();
        _maskImage.Dispose();
        
        QueueFree();
    }
    
    public override void _Process(double delta)
    {
        //这里待优化, 应该每次绘制都将像素点放入 _tempList 中, 然后帧结束再统一提交

        _processTimer += delta;
        if (_processTimer < 1d / LiquidCanvas.UpdateFps)
        {
            return;
        }

        var newDelta = _processTimer;
        _processTimer %= 1d / LiquidCanvas.UpdateFps;
        
        //更新消除逻辑
        if (_updateImagePixels.Count > 0)
        {
            var startIndex = _executeIndex;
            if (_executeIndex < 0 || _executeIndex >= _updateImagePixels.Count)
            {
                _executeIndex = _updateImagePixels.Count - 1;
            }

            var startTime = DateTime.UtcNow;
            var isOver = false;
            var index = 0;
            for (; _executeIndex >= 0; _executeIndex--)
            {
                index++;
                var imagePixel = _updateImagePixels[_executeIndex];
                if (UpdateImagePixel(imagePixel)) //移除
                {
                    _updateImagePixels.RemoveAt(_executeIndex);
                    if (_executeIndex < startIndex)
                    {
                        startIndex--;
                    }
                }

                if (index > 200)
                {
                    index = 0;
                    if ((DateTime.UtcNow - startTime).TotalMilliseconds > LiquidCanvas.MaxWaitTime) //超过最大执行时间
                    {
                        isOver = true;
                        break;
                    }
                }
            }

            if (!isOver && startIndex >= 0 && _executeIndex < 0)
            {
                _executeIndex = _updateImagePixels.Count - 1;
                for (; _executeIndex >= startIndex; _executeIndex--)
                {
                    index++;
                    var imagePixel = _updateImagePixels[_executeIndex];
                    if (UpdateImagePixel(imagePixel)) //移除
                    {
                        _updateImagePixels.RemoveAt(_executeIndex);
                    }
                    
                    if (index > 200)
                    {
                        index = 0;
                        if ((DateTime.UtcNow - startTime).TotalMilliseconds > LiquidCanvas.MaxWaitTime) //超过最大执行时间
                        {
                            break;
                        }
                    }
                }
            }
        }

        if (_changeFlag)
        {
            _maskTexture.Update(_maskImage);
            _changeFlag = false;
        }

        _runTime += (float)newDelta;
    }
    
    public List<LiquidPixel> DrawBrush(BrushImageData brush, Vector2I? prevPosition, Vector2I position, float rotation)
    {
        Debug.Log("DrawBrush: " + position);
        _tempList.Clear();
        var center = new Vector2I(brush.Width, brush.Height) / 2;
        var pos = position - center;
        var canvasWidth = _maskTexture.GetWidth();
        var canvasHeight = _maskTexture.GetHeight();
        //存在上一次记录的点
        if (prevPosition != null)
        {
            var offset = new Vector2(position.X - prevPosition.Value.X, position.Y - prevPosition.Value.Y);
            var maxL = brush.Brush.Ffm * Mathf.Lerp(
                brush.PixelHeight,
                brush.PixelWidth,
                Mathf.Abs(Mathf.Sin(offset.Angle() - rotation + Mathf.Pi * 0.5f))
            );
            maxL = Mathf.Max(1, maxL);
            var len = offset.Length();
            if (len > maxL) //距离太大了, 需要补间
            {
                //Debug.Log($"距离太大了, 启用补间: len: {len}, maxL: {maxL}");
                var count = Mathf.CeilToInt(len / maxL);
                var step = new Vector2(offset.X / count, offset.Y / count);
                var prevPos = prevPosition.Value - center;
                
                for (var i = 1; i <= count; i++)
                {
                    foreach (var brushPixel in brush.Pixels)
                    {
                        var brushPos = RotatePixels(brushPixel.X, brushPixel.Y, center.X, center.Y, rotation);
                        var x = (int)(prevPos.X + step.X * i + brushPos.X);
                        var y = (int)(prevPos.Y + step.Y * i + brushPos.Y);
                        if (x >= 0 && x < canvasWidth && y >= 0 && y < canvasHeight)
                        {
                            var temp = SetPixelData(x, y, brushPixel, _layerConfig);
                            if (!temp.TempFlag)
                            {
                                temp.TempFlag = true;
                                _tempList.Add(temp);
                            }
                        }
                    }
                }
                
                foreach (var brushPixel in brush.Pixels)
                {
                    var brushPos = RotatePixels(brushPixel.X, brushPixel.Y, center.X, center.Y, rotation);
                    var x = pos.X + brushPos.X;
                    var y = pos.Y + brushPos.Y;
                    if (x >= 0 && x < canvasWidth && y >= 0 && y < canvasHeight)
                    {
                        var temp = SetPixelData(x, y, brushPixel, _layerConfig);
                        if (!temp.TempFlag)
                        {
                            temp.TempFlag = true;
                            _tempList.Add(temp);
                        }
                    }
                }

                foreach (var imagePixel in _tempList)
                {
                    _changeFlag = true;
                    _maskImage.SetPixel(imagePixel.X, imagePixel.Y, imagePixel.Color);
                    Debug.Log("setPixel: " + imagePixel.X + ", " + imagePixel.Y);
                    imagePixel.TempFlag = false;
                }


                return _tempList;
            }
        }
        
        
        foreach (var brushPixel in brush.Pixels)
        {
            var brushPos = RotatePixels(brushPixel.X, brushPixel.Y, center.X, center.Y, rotation);
            var x = pos.X + brushPos.X;
            var y = pos.Y + brushPos.Y;
            if (x >= 0 && x < canvasWidth && y >= 0 && y < canvasHeight)
            {
                _changeFlag = true;
                var temp = SetPixelData(x, y, brushPixel, _layerConfig);
                _maskImage.SetPixel(x, y, temp.Color);
                Debug.Log("setPixel: " + x + ", " + y);
                _tempList.Add(temp);
            }
        }

        return _tempList;
    }
    
    /// <summary>
    /// 更新像素点数据逻辑, 返回是否擦除
    /// </summary>
    private bool UpdateImagePixel(LiquidPixel imagePixel)
    {
        if (imagePixel.Color.A > 0)
        {
            if (imagePixel.Timer > 0) //继续等待消散
            {
                imagePixel.Timer -= _runTime - imagePixel.TempTime;
                imagePixel.TempTime = _runTime;
            }
            else
            {
                var oldA = imagePixel.Color.A;
                imagePixel.Color.A -= imagePixel.Layer.WriteOffSpeed * (_runTime - imagePixel.TempTime);
                
                if (imagePixel.Color.A <= 0) //完全透明了
                {
                    _changeFlag = true;
                    _maskImage.SetPixel(imagePixel.X, imagePixel.Y, new Color(0, 0, 0, 0));
                    imagePixel.IsRun = false;
                    imagePixel.IsUpdate = false;
                    return true;
                }
                else if (!Utils.IsSameGradient(oldA, imagePixel.Color.A, GameConfig.LiquidGradient)) //同一渐变梯度下才会有颜色变化
                {
                    _changeFlag = true;
                    _maskImage.SetPixel(imagePixel.X, imagePixel.Y, imagePixel.Color);
                    imagePixel.TempTime = _runTime;
                }
            }
        }

        return false;
    }
    
    //记录像素点数据
    private LiquidPixel SetPixelData(int x, int y, BrushPixelData pixelData, ExcelConfig.LiquidLayer layer)
    {
        var temp = _imagePixels[x, y];
        if (temp == null)
        {
            temp = new LiquidPixel()
            {
                X = x,
                Y = y,
                Color = pixelData.Color,
                Brush = pixelData.Brush,
                Timer = layer.Duration,
                Layer = layer
            };
            _imagePixels[x, y] = temp;

            temp.IsRun = true;
            temp.IsUpdate = layer.Duration >= 0;
            if (temp.IsUpdate)
            {
                _updateImagePixels.Add(temp);
                Debug.Log("添加点: " + temp.X + ", " + temp.Y);
            }
            temp.TempTime = _runTime;
        }
        else
        {
            if (temp.Brush != pixelData.Brush)
            {
                temp.Color = pixelData.Color;
                temp.Brush = pixelData.Brush;
                temp.Layer = layer;
            }
            else
            {
                var tempColor = pixelData.Color;
                temp.Color = new Color(tempColor.R, tempColor.G, tempColor.B, Mathf.Max(temp.Color.A, tempColor.A));
            }
            
            temp.Timer = layer.Duration;
            
            var prevUpdate = temp.IsUpdate;
            temp.IsUpdate = layer.Duration >= 0;
            if (!prevUpdate && temp.IsUpdate)
            {
                _updateImagePixels.Add(temp);
                Debug.Log("添加点: " + temp.X + ", " + temp.Y);
            }
            else if (prevUpdate && !temp.IsUpdate)
            {
                _updateImagePixels.Remove(temp);
            }
            
            temp.IsRun = true;
            temp.TempTime = _runTime;
        }

        return temp;
    }
    
    /// <summary>
    /// 根据 rotation 旋转像素点坐标, 并返回旋转后的坐标, rotation 为弧度制角度, 旋转中心点为 centerX, centerY
    /// </summary>
    private Vector2I RotatePixels(int x, int y, int centerX, int centerY, float rotation)
    {
        if (rotation == 0)
        {
            return new Vector2I(x, y);
        }

        x -= centerX;
        y -= centerY;
        var sv = Mathf.Sin(rotation);
        var cv = Mathf.Cos(rotation);
        var newX = Mathf.RoundToInt(x * cv - y * sv);
        var newY = Mathf.RoundToInt(x * sv + y * cv);
        newX += centerX;
        newY += centerY;
        return new Vector2I(newX, newY);
    }
}