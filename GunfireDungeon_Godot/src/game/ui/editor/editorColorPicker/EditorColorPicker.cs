using DsUi;

namespace UI.editor.EditorColorPicker;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class EditorColorPicker : UiBase
{
    /// <summary>
    /// 节点路径: EditorColorPicker.ColorPicker
    /// </summary>
    public ColorPicker L_ColorPicker
    {
        get
        {
            if (_L_ColorPicker == null) _L_ColorPicker = new ColorPicker((EditorColorPickerPanel)this, GetNode<Godot.ColorPicker>("ColorPicker"));
            return _L_ColorPicker;
        }
    }
    private ColorPicker _L_ColorPicker;


    public EditorColorPicker() : base(nameof(EditorColorPicker))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: EditorColorPicker.ColorPicker
    /// </summary>
    public class ColorPicker : UiNode<EditorColorPickerPanel, Godot.ColorPicker, ColorPicker>
    {
        public ColorPicker(EditorColorPickerPanel uiPanel, Godot.ColorPicker node) : base(uiPanel, node) {  }
        public override ColorPicker Clone() => new (UiPanel, (Godot.ColorPicker)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorColorPicker.ColorPicker
    /// </summary>
    public ColorPicker S_ColorPicker => L_ColorPicker;

}
