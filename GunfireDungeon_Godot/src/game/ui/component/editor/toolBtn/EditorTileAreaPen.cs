
using Godot;
using UI.editor.MapEditor;

/// <summary>
/// 瓷砖区域画笔
/// </summary>
public class EditorTileAreaPen : EditorToolBase
{
    private bool _isPressed;
    private MouseButton _buttonIndex;

    private Vector2 _mousePosition;
    private Vector2I _mouseCellPosition;

    //绘制填充区域
    private bool _drawFullRect = false;
    private Vector2I _mouseStartCellPosition;

    public EditorTileAreaPen(EditorTileMap editorTileMap) : base(
        ResourcePath.resource_sprite_ui_commonIcon_AreaTool_png, "绘制区域瓷砖", true, editorTileMap, EditorToolEnum.TileAreaPen)
    {
    }
    
    public override void Process(float delta)
    {
        var mousePosition = EditorTileMap.GetLocalMousePosition();
        _mouseCellPosition = EditorTileMap.LocalToMap(mousePosition);
        _mousePosition = _mouseCellPosition * GameConfig.TileCellSize;
    }
    
    public override void OnMapInputEvent(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton)
        {
            _buttonIndex = mouseButton.ButtonIndex;
            if (mouseButton.ButtonIndex == MouseButton.Left || mouseButton.ButtonIndex == MouseButton.Right)
            {
                _isPressed = mouseButton.Pressed;
                if (_isPressed) //开始按下
                {
                    _mouseStartCellPosition = EditorTileMap.LocalToMap(EditorTileMap.GetLocalMousePosition());
                    _drawFullRect = true;
                }
                else if (!_isPressed && _drawFullRect) //松手提交
                {
                    _drawFullRect = false;
                    if (_buttonIndex == MouseButton.Left) //绘制
                    {
                        DoDrawCell();
                    }
                    else //擦除
                    {
                        DoEraseCell();
                    }
                }
            }
        }
    }

    private void DoDrawCell()
    {
        EditorTileMap.SetRectCell(_mouseStartCellPosition, _mouseCellPosition);
    }
    
    private void DoEraseCell()
    {
        EditorTileMap.EraseRectCell(_mouseStartCellPosition, _mouseCellPosition);
    }

    public override void OnMapDrawTool(CanvasItem brush)
    {
        if (_drawFullRect)
        {
            var canvasItem = brush;
            var size = EditorTileMap.TileSet.TileSize;
            var cellPos = _mouseStartCellPosition;
            var temp = size;
            if (_mouseStartCellPosition.X > _mouseCellPosition.X)
            {
                cellPos.X += 1;
                temp.X -= size.X;
            }

            if (_mouseStartCellPosition.Y > _mouseCellPosition.Y)
            {
                cellPos.Y += 1;
                temp.Y -= size.Y;
            }

            var p = cellPos * size;
            var s = _mousePosition.AsVector2I() - p + temp;

            if (s.X < 0)
            {
                p.X += s.X;
                s.X *= -1;
            }

            if (s.Y < 0)
            {
                p.Y += s.Y;
                s.Y *= -1;
            }

            //绘制边框
            canvasItem.DrawRect(new Rect2(p, s), Colors.White, false, 2f / EditorTileMap.Scale.X);

            if (EditorTileMap.CurrLayer.Layer != MapLayer.AutoFloorLayer &&
                (EditorTileMap.CurrBrushType == EditorTileMap.TileMapDrawMode.Free ||
                 EditorTileMap.CurrBrushType == EditorTileMap.TileMapDrawMode.Combination)) //自由绘制 或者 绘制组合
            {
                if (_isPressed && _buttonIndex == MouseButton.Left && EditorTileMap.BrushWidth > 0 && EditorTileMap.BrushHeight > 0) //左键绘制
                {
                    var w = s.X / GameConfig.TileCellSize;
                    var h = s.Y / GameConfig.TileCellSize;
                    for (var i = 0; i < w; i++)
                    {
                        for (var j = 0; j < h; j++)
                        {
                            var x = i % EditorTileMap.BrushWidth + EditorTileMap.BrushStartX;
                            var y = j % EditorTileMap.BrushHeight + EditorTileMap.BrushStartY;
                            if (EditorTileMap.CurrBrush.TryGetValue(new Vector2I(x, y), out var v))
                            {
                                var rect = new Rect2(p + (new Vector2I(i, j)) * GameConfig.TileCellSize,
                                    GameConfig.TileCellSize, GameConfig.TileCellSize);
                                var srcRect = new Rect2(v * GameConfig.TileCellSize, GameConfig.TileCellSize,
                                    GameConfig.TileCellSize);
                                canvasItem.DrawTextureRectRegion(EditorTileMap.CurrBrushTexture, rect, srcRect,
                                    new Color(1, 1, 1, 0.3f));
                            }
                        }
                    }
                }
            }
        }
    }
}