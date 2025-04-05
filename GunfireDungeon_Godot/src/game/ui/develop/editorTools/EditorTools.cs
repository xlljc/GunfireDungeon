using DsUi;

namespace UI.develop.EditorTools;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class EditorTools : UiBase
{
    /// <summary>
    /// 节点路径: EditorTools.ScrollContainer
    /// </summary>
    public ScrollContainer L_ScrollContainer
    {
        get
        {
            if (_L_ScrollContainer == null) _L_ScrollContainer = new ScrollContainer((EditorToolsPanel)this, GetNode<Godot.ScrollContainer>("ScrollContainer"));
            return _L_ScrollContainer;
        }
    }
    private ScrollContainer _L_ScrollContainer;

    /// <summary>
    /// 节点路径: EditorTools.Confirm
    /// </summary>
    public Confirm L_Confirm
    {
        get
        {
            if (_L_Confirm == null) _L_Confirm = new Confirm((EditorToolsPanel)this, GetNode<Godot.ConfirmationDialog>("Confirm"));
            return _L_Confirm;
        }
    }
    private Confirm _L_Confirm;

    /// <summary>
    /// 节点路径: EditorTools.Tips
    /// </summary>
    public Tips L_Tips
    {
        get
        {
            if (_L_Tips == null) _L_Tips = new Tips((EditorToolsPanel)this, GetNode<Godot.AcceptDialog>("Tips"));
            return _L_Tips;
        }
    }
    private Tips _L_Tips;


    public EditorTools() : base(nameof(EditorTools))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer.Label
    /// </summary>
    public class Label : UiNode<EditorToolsPanel, Godot.Label, Label>
    {
        public Label(EditorToolsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer.Button
    /// </summary>
    public class Button : UiNode<EditorToolsPanel, Godot.Button, Button>
    {
        public Button(EditorToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Button Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<EditorToolsPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 节点路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.Label
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

        /// <summary>
        /// 节点路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.Button
        /// </summary>
        public Button L_Button
        {
            get
            {
                if (_L_Button == null) _L_Button = new Button(UiPanel, Instance.GetNode<Godot.Button>("Button"));
                return _L_Button;
            }
        }
        private Button _L_Button;

        public HBoxContainer(EditorToolsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer6.Label
    /// </summary>
    public class Label_1 : UiNode<EditorToolsPanel, Godot.Label, Label_1>
    {
        public Label_1(EditorToolsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer6.Button
    /// </summary>
    public class Button_1 : UiNode<EditorToolsPanel, Godot.Button, Button_1>
    {
        public Button_1(EditorToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Button_1 Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer6
    /// </summary>
    public class HBoxContainer6 : UiNode<EditorToolsPanel, Godot.HBoxContainer, HBoxContainer6>
    {
        /// <summary>
        /// 节点路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.Label
        /// </summary>
        public Label_1 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_1(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_1 _L_Label;

        /// <summary>
        /// 节点路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.Button
        /// </summary>
        public Button_1 L_Button
        {
            get
            {
                if (_L_Button == null) _L_Button = new Button_1(UiPanel, Instance.GetNode<Godot.Button>("Button"));
                return _L_Button;
            }
        }
        private Button_1 _L_Button;

        public HBoxContainer6(EditorToolsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer6 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer7.Label
    /// </summary>
    public class Label_2 : UiNode<EditorToolsPanel, Godot.Label, Label_2>
    {
        public Label_2(EditorToolsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_2 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer7.Button
    /// </summary>
    public class Button_2 : UiNode<EditorToolsPanel, Godot.Button, Button_2>
    {
        public Button_2(EditorToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Button_2 Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer7
    /// </summary>
    public class HBoxContainer7 : UiNode<EditorToolsPanel, Godot.HBoxContainer, HBoxContainer7>
    {
        /// <summary>
        /// 节点路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.Label
        /// </summary>
        public Label_2 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_2(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_2 _L_Label;

        /// <summary>
        /// 节点路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.Button
        /// </summary>
        public Button_2 L_Button
        {
            get
            {
                if (_L_Button == null) _L_Button = new Button_2(UiPanel, Instance.GetNode<Godot.Button>("Button"));
                return _L_Button;
            }
        }
        private Button_2 _L_Button;

        public HBoxContainer7(EditorToolsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer7 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer8.Label
    /// </summary>
    public class Label_3 : UiNode<EditorToolsPanel, Godot.Label, Label_3>
    {
        public Label_3(EditorToolsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_3 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer8.Button
    /// </summary>
    public class Button_3 : UiNode<EditorToolsPanel, Godot.Button, Button_3>
    {
        public Button_3(EditorToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Button_3 Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer8
    /// </summary>
    public class HBoxContainer8 : UiNode<EditorToolsPanel, Godot.HBoxContainer, HBoxContainer8>
    {
        /// <summary>
        /// 节点路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.Label
        /// </summary>
        public Label_3 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_3(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_3 _L_Label;

        /// <summary>
        /// 节点路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.Button
        /// </summary>
        public Button_3 L_Button
        {
            get
            {
                if (_L_Button == null) _L_Button = new Button_3(UiPanel, Instance.GetNode<Godot.Button>("Button"));
                return _L_Button;
            }
        }
        private Button_3 _L_Button;

        public HBoxContainer8(EditorToolsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer8 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<EditorToolsPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 节点路径: EditorTools.ScrollContainer.MarginContainer.HBoxContainer
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

        /// <summary>
        /// 节点路径: EditorTools.ScrollContainer.MarginContainer.HBoxContainer6
        /// </summary>
        public HBoxContainer6 L_HBoxContainer6
        {
            get
            {
                if (_L_HBoxContainer6 == null) _L_HBoxContainer6 = new HBoxContainer6(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer6"));
                return _L_HBoxContainer6;
            }
        }
        private HBoxContainer6 _L_HBoxContainer6;

        /// <summary>
        /// 节点路径: EditorTools.ScrollContainer.MarginContainer.HBoxContainer7
        /// </summary>
        public HBoxContainer7 L_HBoxContainer7
        {
            get
            {
                if (_L_HBoxContainer7 == null) _L_HBoxContainer7 = new HBoxContainer7(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer7"));
                return _L_HBoxContainer7;
            }
        }
        private HBoxContainer7 _L_HBoxContainer7;

        /// <summary>
        /// 节点路径: EditorTools.ScrollContainer.MarginContainer.HBoxContainer8
        /// </summary>
        public HBoxContainer8 L_HBoxContainer8
        {
            get
            {
                if (_L_HBoxContainer8 == null) _L_HBoxContainer8 = new HBoxContainer8(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer8"));
                return _L_HBoxContainer8;
            }
        }
        private HBoxContainer8 _L_HBoxContainer8;

        public VBoxContainer(EditorToolsPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<EditorToolsPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 节点路径: EditorTools.ScrollContainer.VBoxContainer
        /// </summary>
        public VBoxContainer L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer _L_VBoxContainer;

        public MarginContainer(EditorToolsPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<EditorToolsPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 节点路径: EditorTools.MarginContainer
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

        public ScrollContainer(EditorToolsPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.Confirm
    /// </summary>
    public class Confirm : UiNode<EditorToolsPanel, Godot.ConfirmationDialog, Confirm>
    {
        public Confirm(EditorToolsPanel uiPanel, Godot.ConfirmationDialog node) : base(uiPanel, node) {  }
        public override Confirm Clone() => new (UiPanel, (Godot.ConfirmationDialog)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorTools.Tips
    /// </summary>
    public class Tips : UiNode<EditorToolsPanel, Godot.AcceptDialog, Tips>
    {
        public Tips(EditorToolsPanel uiPanel, Godot.AcceptDialog node) : base(uiPanel, node) {  }
        public override Tips Clone() => new (UiPanel, (Godot.AcceptDialog)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_ScrollContainer.L_MarginContainer.L_VBoxContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer6
    /// </summary>
    public HBoxContainer6 S_HBoxContainer6 => L_ScrollContainer.L_MarginContainer.L_VBoxContainer.L_HBoxContainer6;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer7
    /// </summary>
    public HBoxContainer7 S_HBoxContainer7 => L_ScrollContainer.L_MarginContainer.L_VBoxContainer.L_HBoxContainer7;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer.HBoxContainer8
    /// </summary>
    public HBoxContainer8 S_HBoxContainer8 => L_ScrollContainer.L_MarginContainer.L_VBoxContainer.L_HBoxContainer8;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorTools.ScrollContainer.MarginContainer.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_ScrollContainer.L_MarginContainer.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorTools.ScrollContainer.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_ScrollContainer.L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorTools.ScrollContainer
    /// </summary>
    public ScrollContainer S_ScrollContainer => L_ScrollContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorTools.Confirm
    /// </summary>
    public Confirm S_Confirm => L_Confirm;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorTools.Tips
    /// </summary>
    public Tips S_Tips => L_Tips;

}
