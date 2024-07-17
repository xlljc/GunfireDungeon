
using Godot;
using UI.MapEditor;

/// <summary>
/// 移动视角按钮
/// </summary>
public class EditorMove : EditorToolBase
{
    private bool _isPressed;
    
    public EditorMove(EditorTileMap editorTileMap) : base(
        ResourcePath.resource_sprite_ui_commonIcon_DragTool_png, "移动视角", true, editorTileMap, EditorToolEnum.Move)
    {
    }

    public override void OnMapInputEvent(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton)
        {
            if (mouseButton.ButtonIndex == MouseButton.Left || mouseButton.ButtonIndex == MouseButton.Right || mouseButton.ButtonIndex == MouseButton.Middle)
            {
                _isPressed = mouseButton.Pressed;
            }
        }
        else if (@event is InputEventMouseMotion motion)
        {
            if (_isPressed)
            {
                EditorTileMap.SetMapPosition(EditorTileMap.Position + motion.Relative);
            }
        }
    }
}