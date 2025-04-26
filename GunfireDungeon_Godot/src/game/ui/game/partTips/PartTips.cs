using DsUi;

namespace UI.game.PartTips;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class PartTips : UiBase
{
    /// <summary>
    /// 节点路径: PartTips.PanelRoot
    /// </summary>
    public PanelRoot L_PanelRoot
    {
        get
        {
            if (_L_PanelRoot == null) _L_PanelRoot = new PanelRoot((PartTipsPanel)this, GetNode<Godot.PanelContainer>("PanelRoot"));
            return _L_PanelRoot;
        }
    }
    private PanelRoot _L_PanelRoot;


    public PartTips() : base(UiManager.UiName.Game_PartTips)
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: PartTips.PanelRoot.MarginContainer.Text
    /// </summary>
    public class Text : UiNode<PartTipsPanel, Godot.RichTextLabel, Text>
    {
        public Text(PartTipsPanel uiPanel, Godot.RichTextLabel node) : base(uiPanel, node) {  }
        public override Text Clone() => new (UiPanel, (Godot.RichTextLabel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartTips.PanelRoot.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<PartTipsPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 节点路径: PartTips.PanelRoot.Text
        /// </summary>
        public Text L_Text
        {
            get
            {
                if (_L_Text == null) _L_Text = new Text(UiPanel, Instance.GetNode<Godot.RichTextLabel>("Text"));
                return _L_Text;
            }
        }
        private Text _L_Text;

        public MarginContainer(PartTipsPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartTips.PanelRoot
    /// </summary>
    public class PanelRoot : UiNode<PartTipsPanel, Godot.PanelContainer, PanelRoot>
    {
        /// <summary>
        /// 节点路径: PartTips.MarginContainer
        /// </summary>
        public MarginContainer L_MarginContainer
        {
            get
            {
                if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer(UiPanel, Instance.GetNode<Godot.MarginContainer>("MarginContainer"));
                return _L_MarginContainer;
            }
        }
        private MarginContainer _L_MarginContainer;

        public PanelRoot(PartTipsPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelRoot Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartTips.PanelRoot.MarginContainer.Text
    /// </summary>
    public Text S_Text => L_PanelRoot.L_MarginContainer.L_Text;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartTips.PanelRoot.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_PanelRoot.L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartTips.PanelRoot
    /// </summary>
    public PanelRoot S_PanelRoot => L_PanelRoot;

}
