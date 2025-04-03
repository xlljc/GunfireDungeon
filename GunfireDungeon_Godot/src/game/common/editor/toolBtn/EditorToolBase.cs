
using Godot;
using UI.MapEditor;

/// <summary>
/// 地图编辑器工具栏图标逻辑基类
/// </summary>
public abstract class EditorToolBase
{
    /// <summary>
    /// 工具图标
    /// </summary>
    public string Icon { get; }
    
    /// <summary>
    /// 工具提示名称
    /// </summary>
    public string TipText { get; }
    
    /// <summary>
    /// 是否可以选中
    /// </summary>
    public bool CanSelect { get; }
    
    /// <summary>
    /// 绑定的 TileMap
    /// </summary>
    public EditorTileMap EditorTileMap { get; }
    
    /// <summary>
    /// 工具枚举类型
    /// </summary>
    public EditorToolEnum EditorToolType { get; }

    public EditorToolBase(string icon, string tipText, bool canSelect, EditorTileMap editorTileMap, EditorToolEnum editorToolType)
    {
        Icon = icon;
        CanSelect = canSelect;
        EditorTileMap = editorTileMap;
        EditorToolType = editorToolType;
        TipText = tipText;
    }

    /// <summary>
    /// 点击时回调
    /// </summary>
    public virtual void OnClick()
    {
    }

    /// <summary>
    /// 改变选中状态时回调
    /// </summary>
    public virtual void OnSetSelected(bool selected)
    {
    }

    /// <summary>
    /// 选中后每帧调用
    /// </summary>
    public virtual void Process(float delta)
    {
    }

    /// <summary>
    /// 选中后处理的 TileMap 输入事件, 仅在选中时才会调用
    /// </summary>
    public virtual void OnMapInputEvent(InputEvent @event)
    {
    }

    /// <summary>
    /// 绘制工具, 仅在选中时才会调用
    /// </summary>
    public virtual void OnMapDrawTool(CanvasItem brush)
    {
        
    }
}