using DsUi;

namespace UI.game.Loading;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Loading : UiBase
{
    /// <summary>
    /// 节点路径: Loading.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((LoadingPanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;

    /// <summary>
    /// 节点路径: Loading.Label
    /// </summary>
    public Label L_Label
    {
        get
        {
            if (_L_Label == null) _L_Label = new Label((LoadingPanel)this, GetNode<Godot.Label>("Label"));
            return _L_Label;
        }
    }
    private Label _L_Label;


    public Loading() : base(UiManager.UiName.Game_Loading)
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: Loading.ColorRect
    /// </summary>
    public class ColorRect : UiNode<LoadingPanel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(LoadingPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Loading.Label
    /// </summary>
    public class Label : UiNode<LoadingPanel, Godot.Label, Label>
    {
        public Label(LoadingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Loading.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Loading.Label
    /// </summary>
    public Label S_Label => L_Label;

}
