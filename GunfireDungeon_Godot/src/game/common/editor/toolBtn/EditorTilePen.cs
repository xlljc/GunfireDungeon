
using Godot;
using UI.MapEditor;

/// <summary>
/// 瓷砖画笔
/// </summary>
public class EditorTilePen : EditorToolBase
{
    private bool _isPressed;
    private MouseButton _buttonIndex;

    //单次绘制是否改变过tile数据
    private bool _changeFlag = false;

    private Vector2 _mousePosition;
    private Vector2I _mouseCellPosition;

    //上一帧鼠标所在的cell坐标
    private Vector2I _prevMouseCellPosition = new Vector2I(-99999, -99999);

    public EditorTilePen(EditorTileMap editorTileMap) : base(
        ResourcePath.resource_sprite_ui_commonIcon_PenTool_png, "绘制瓷砖", true, editorTileMap, EditorToolEnum.TilePen)
    {
    }

    public override void Process(float delta)
    {
        var mousePosition = EditorTileMap.GetLocalMousePosition();
        //绘制2x2地形
        if ((!_isPressed || _buttonIndex != MouseButton.Right) &&
            EditorTileMap.CurrBrushType == EditorTileMap.TileMapDrawMode.Terrain &&
            EditorTileMap.CurrTerrain != null &&
            EditorTileMap.CurrTerrain.TerrainInfo.TerrainType == 1)
        {
            mousePosition -= new Vector2(GameConfig.TileCellSize / 2f, GameConfig.TileCellSize / 2f);
        }

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
                if (!_isPressed)
                {
                    _changeFlag = false;
                }
                else if (_buttonIndex == MouseButton.Left) //绘制
                {
                    DoDrawCell();
                }
                else if (_buttonIndex == MouseButton.Right) //擦除
                {
                    DoEraseCell();
                }
            }
        }
        else if (@event is InputEventMouseMotion && _isPressed)
        {
            if (_buttonIndex == MouseButton.Left) //绘制
            {
                DoDrawCell();
            }
            else if (_buttonIndex == MouseButton.Right) //擦除
            {
                DoEraseCell();
            }
        }
    }

    private void DoDrawCell()
    {
        if (_prevMouseCellPosition != _mouseCellPosition || !_changeFlag) //鼠标位置变过
        {
            _changeFlag = true;
            _prevMouseCellPosition = _mouseCellPosition;
            //绘制图块
            EditorTileMap.SetSingleCell(_mouseCellPosition);
        }
    }

    private void DoEraseCell()
    {
        var position = EditorTileMap.GetLocalMousePosition();
        var mouseCellPosition = EditorTileMap.LocalToMap(position);
        if (_prevMouseCellPosition != mouseCellPosition || !_changeFlag) //鼠标位置变过
        {
            _changeFlag = true;
            _prevMouseCellPosition = mouseCellPosition;
            //绘制图块
            EditorTileMap.EraseSingleCell(mouseCellPosition);
        }
    }

    public override void OnMapDrawTool(CanvasItem brush)
    {
        var canvasItem = brush;
        if (EditorTileMap.CurrLayer.Layer == MapLayer.AutoFloorLayer) //选择自动地板层
        {
            DrawCellOutline(canvasItem);
        }
        else //自定义层
        {
            if (EditorTileMap.CurrBrushType == EditorTileMap.TileMapDrawMode.Free ||
                EditorTileMap.CurrBrushType == EditorTileMap.TileMapDrawMode.Combination) //自由绘制 或者 绘制组合
            {
                if (_isPressed && _buttonIndex == MouseButton.Right) //按下了左键擦除
                {
                    DrawCellOutline(canvasItem);
                }
                else //正常绘制
                {
                    foreach (var item in EditorTileMap.CurrBrush)
                    {
                        var rect = new Rect2(
                            _mousePosition + (item.Key + EditorTileMap.BrushOffset) * GameConfig.TileCellSize,
                            GameConfig.TileCellSize, GameConfig.TileCellSize);
                        var srcRect = new Rect2(item.Value * GameConfig.TileCellSize, GameConfig.TileCellSize,
                            GameConfig.TileCellSize);
                        canvasItem.DrawTextureRectRegion(EditorTileMap.CurrBrushTexture, rect, srcRect,
                            new Color(1, 1, 1, 0.3f));
                    }
                }
            }
            else if (EditorTileMap.CurrBrushType == EditorTileMap.TileMapDrawMode.Terrain) //绘制地形
            {
                if (EditorTileMap.CurrTerrain == null) //未选择地形
                {
                    DrawCellOutline(canvasItem);
                }
                else if (EditorTileMap.CurrTerrain.TerrainInfo.TerrainType == 0) //3x3
                {
                    DrawCellOutline(canvasItem);
                }
                else //2x2
                {
                    DrawCellOutline(canvasItem);
                    if (!_isPressed || _buttonIndex != MouseButton.Right) //没按下左键擦除
                    {
                        DrawCellOutline(canvasItem, new Vector2I(GameConfig.TileCellSize, 0));
                        DrawCellOutline(canvasItem, new Vector2I(0, GameConfig.TileCellSize));
                        DrawCellOutline(canvasItem,
                            new Vector2I(GameConfig.TileCellSize, GameConfig.TileCellSize));
                    }
                }
            }
        }
    }

    private void DrawCellOutline(CanvasItem canvasItem)
    {
        canvasItem.DrawRect(new Rect2(_mousePosition, EditorTileMap.TileSet.TileSize),
            Colors.White, false, 2f / EditorTileMap.Scale.X);
    }

    private void DrawCellOutline(CanvasItem canvasItem, Vector2I offset)
    {
        canvasItem.DrawRect(
            new Rect2(_mousePosition + offset, EditorTileMap.TileSet.TileSize),
            Colors.White, false, 2f / EditorTileMap.Scale.X);
    }
}