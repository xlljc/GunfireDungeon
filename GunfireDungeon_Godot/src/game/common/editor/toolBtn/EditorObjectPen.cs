
using Godot;
using UI.editor.MapEditor;

public class EditorObjectPen : EditorToolBase
{
    private bool _isPressed;
    
    public EditorObjectPen(EditorTileMap editorTileMap) : base(
        ResourcePath.resource_sprite_ui_commonIcon_PenTool_png, "绘制物体", true, editorTileMap, EditorToolEnum.ObjectPen)
    {
    }
    
    public override void OnMapInputEvent(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton)
        {
            if (mouseButton.ButtonIndex == MouseButton.Left)
            {
                _isPressed = mouseButton.Pressed;
                if (_isPressed)
                {
                    DoPutObject();
                }
            }
        }
    }

    private void DoPutObject()
    {
        var config = EditorTileMap.MapEditorPanel.S_MapEditorConfigObject.Instance.GetSelectConfig();
        if (config != null)
        {
            var pos = EditorTileMap.GetLocalMousePosition().AsVector2I();
            EventManager.EmitEvent(EventEnum.OnPutObject, new RoomObjectInfo()
            {
                Id = config.Id,
                X = pos.X,
                Y = pos.Y
            });
            EventManager.EmitEvent(EventEnum.OnTileMapDirty);
        }
        else
        {
            EditorWindowManager.ShowTips("提示", "请先在左侧面板选择一个物体！");
        }
    }
    
}