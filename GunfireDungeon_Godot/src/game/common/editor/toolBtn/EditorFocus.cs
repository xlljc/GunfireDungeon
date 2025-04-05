
using UI.editor.MapEditor;

/// <summary>
/// 聚焦按钮
/// </summary>
public class EditorFocus : EditorToolBase
{
    public EditorFocus(EditorTileMap editorTileMap) : base(
        ResourcePath.resource_sprite_ui_commonIcon_CenterTool_png, "聚焦", false, editorTileMap, EditorToolEnum.Focus)
    {
    }

    public override void OnClick()
    {
        EditorTileMap.OnFocusClick();
    }
}