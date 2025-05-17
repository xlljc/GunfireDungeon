using Godot;
using System;

public partial class LiquidTest : Node2D
{
    [Export] public Sprite2D MaskSprite;

    private ImageTexture _texture;
    private bool _isDrawing = false;
    
    public override void _Ready()
    {
        //创建空的纹理
        var canvas = Image.CreateEmpty(1920 / 4, 1080 / 4, false, Image.Format.Rgba8);
        _texture = ImageTexture.CreateFromImage(canvas);

        MaskSprite.Texture = _texture;
    }

    public override void _Input(InputEvent @event)
    {
        // 处理鼠标按下/释放
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (mouseEvent.ButtonIndex == MouseButton.Left)
            {
                _isDrawing = mouseEvent.Pressed;
            }
        }
        // 处理鼠标移动（拖拽）
        else if (@event is InputEventMouseMotion motionEvent && _isDrawing)
        {
            Vector2 mouseGlobalPos = GetGlobalMousePosition() / 4;
            int baseX = (int)mouseGlobalPos.X;
            int baseY = (int)mouseGlobalPos.Y;
            var image = _texture.GetImage();
        
            // 绘制3x3像素方块
            for (int xOffset = -4; xOffset <= 4; xOffset++)
            {
                for (int yOffset = -4; yOffset <= 4; yOffset++)
                {
                    int pixelX = baseX + xOffset;
                    int pixelY = baseY + yOffset;

                    if (pixelX >= 0 && pixelX < _texture.GetWidth() &&
                        pixelY >= 0 && pixelY < _texture.GetHeight())
                    {
                        image.SetPixel(pixelX, pixelY, Colors.White);
                    }
                }
            }
        
            _texture.Update(image);
        }
    }

}
