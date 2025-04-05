using DsUi;

namespace UI.game.BottomTips;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class BottomTips : UiBase
{
    /// <summary>
    /// 节点路径: BottomTips.Panel
    /// </summary>
    public Panel L_Panel
    {
        get
        {
            if (_L_Panel == null) _L_Panel = new Panel((BottomTipsPanel)this, GetNode<Godot.PanelContainer>("Panel"));
            return _L_Panel;
        }
    }
    private Panel _L_Panel;


    public BottomTips() : base(nameof(BottomTips))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: BottomTips.Panel.MarginContainer.CenterContainer.HBoxContainer.AspectRatioContainer.TextureRect
    /// </summary>
    public class TextureRect : UiNode<BottomTipsPanel, Godot.TextureRect, TextureRect>
    {
        public TextureRect(BottomTipsPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override TextureRect Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: BottomTips.Panel.MarginContainer.CenterContainer.HBoxContainer.AspectRatioContainer
    /// </summary>
    public class AspectRatioContainer : UiNode<BottomTipsPanel, Godot.AspectRatioContainer, AspectRatioContainer>
    {
        /// <summary>
        /// 节点路径: BottomTips.Panel.MarginContainer.CenterContainer.HBoxContainer.TextureRect
        /// </summary>
        public TextureRect L_TextureRect
        {
            get
            {
                if (_L_TextureRect == null) _L_TextureRect = new TextureRect(UiPanel, Instance.GetNode<Godot.TextureRect>("TextureRect"));
                return _L_TextureRect;
            }
        }
        private TextureRect _L_TextureRect;

        public AspectRatioContainer(BottomTipsPanel uiPanel, Godot.AspectRatioContainer node) : base(uiPanel, node) {  }
        public override AspectRatioContainer Clone() => new (UiPanel, (Godot.AspectRatioContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: BottomTips.Panel.MarginContainer.CenterContainer.HBoxContainer.Label
    /// </summary>
    public class Label : UiNode<BottomTipsPanel, Godot.Label, Label>
    {
        public Label(BottomTipsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: BottomTips.Panel.MarginContainer.CenterContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<BottomTipsPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 节点路径: BottomTips.Panel.MarginContainer.CenterContainer.AspectRatioContainer
        /// </summary>
        public AspectRatioContainer L_AspectRatioContainer
        {
            get
            {
                if (_L_AspectRatioContainer == null) _L_AspectRatioContainer = new AspectRatioContainer(UiPanel, Instance.GetNode<Godot.AspectRatioContainer>("AspectRatioContainer"));
                return _L_AspectRatioContainer;
            }
        }
        private AspectRatioContainer _L_AspectRatioContainer;

        /// <summary>
        /// 节点路径: BottomTips.Panel.MarginContainer.CenterContainer.Label
        /// </summary>
        public Label L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label _L_Label;

        public HBoxContainer(BottomTipsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: BottomTips.Panel.MarginContainer.CenterContainer
    /// </summary>
    public class CenterContainer : UiNode<BottomTipsPanel, Godot.CenterContainer, CenterContainer>
    {
        /// <summary>
        /// 节点路径: BottomTips.Panel.MarginContainer.HBoxContainer
        /// </summary>
        public HBoxContainer L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer _L_HBoxContainer;

        public CenterContainer(BottomTipsPanel uiPanel, Godot.CenterContainer node) : base(uiPanel, node) {  }
        public override CenterContainer Clone() => new (UiPanel, (Godot.CenterContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: BottomTips.Panel.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<BottomTipsPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 节点路径: BottomTips.Panel.CenterContainer
        /// </summary>
        public CenterContainer L_CenterContainer
        {
            get
            {
                if (_L_CenterContainer == null) _L_CenterContainer = new CenterContainer(UiPanel, Instance.GetNode<Godot.CenterContainer>("CenterContainer"));
                return _L_CenterContainer;
            }
        }
        private CenterContainer _L_CenterContainer;

        public MarginContainer(BottomTipsPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: BottomTips.Panel
    /// </summary>
    public class Panel : UiNode<BottomTipsPanel, Godot.PanelContainer, Panel>
    {
        /// <summary>
        /// 节点路径: BottomTips.MarginContainer
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

        public Panel(BottomTipsPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override Panel Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: BottomTips.Panel.MarginContainer.CenterContainer.HBoxContainer.AspectRatioContainer.TextureRect
    /// </summary>
    public TextureRect S_TextureRect => L_Panel.L_MarginContainer.L_CenterContainer.L_HBoxContainer.L_AspectRatioContainer.L_TextureRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: BottomTips.Panel.MarginContainer.CenterContainer.HBoxContainer.AspectRatioContainer
    /// </summary>
    public AspectRatioContainer S_AspectRatioContainer => L_Panel.L_MarginContainer.L_CenterContainer.L_HBoxContainer.L_AspectRatioContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: BottomTips.Panel.MarginContainer.CenterContainer.HBoxContainer.Label
    /// </summary>
    public Label S_Label => L_Panel.L_MarginContainer.L_CenterContainer.L_HBoxContainer.L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: BottomTips.Panel.MarginContainer.CenterContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_Panel.L_MarginContainer.L_CenterContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: BottomTips.Panel.MarginContainer.CenterContainer
    /// </summary>
    public CenterContainer S_CenterContainer => L_Panel.L_MarginContainer.L_CenterContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: BottomTips.Panel.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_Panel.L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: BottomTips.Panel
    /// </summary>
    public Panel S_Panel => L_Panel;

}
