using DsUi;

namespace UI.editor.EditorWindow;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class EditorWindow : UiBase
{
    /// <summary>
    /// 节点路径: EditorWindow.Bg
    /// </summary>
    public Bg L_Bg
    {
        get
        {
            if (_L_Bg == null) _L_Bg = new Bg((EditorWindowPanel)this, GetNode<Godot.ColorRect>("Bg"));
            return _L_Bg;
        }
    }
    private Bg _L_Bg;

    /// <summary>
    /// 节点路径: EditorWindow.Window
    /// </summary>
    public Window L_Window
    {
        get
        {
            if (_L_Window == null) _L_Window = new Window((EditorWindowPanel)this, GetNode<Godot.Window>("Window"));
            return _L_Window;
        }
    }
    private Window _L_Window;


    public EditorWindow() : base(nameof(EditorWindow))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: EditorWindow.Bg
    /// </summary>
    public class Bg : UiNode<EditorWindowPanel, Godot.ColorRect, Bg>
    {
        public Bg(EditorWindowPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override Bg Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorWindow.Window.Panel.VBoxContainer.Body
    /// </summary>
    public class Body : UiNode<EditorWindowPanel, Godot.MarginContainer, Body>
    {
        public Body(EditorWindowPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override Body Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorWindow.Window.Panel.VBoxContainer.HBoxContainer.CustomButton.Button
    /// </summary>
    public class Button : UiNode<EditorWindowPanel, Godot.Button, Button>
    {
        public Button(EditorWindowPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Button Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorWindow.Window.Panel.VBoxContainer.HBoxContainer.CustomButton
    /// </summary>
    public class CustomButton : UiNode<EditorWindowPanel, Godot.CenterContainer, CustomButton>
    {
        /// <summary>
        /// 节点路径: EditorWindow.Window.Panel.VBoxContainer.HBoxContainer.Button
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

        public CustomButton(EditorWindowPanel uiPanel, Godot.CenterContainer node) : base(uiPanel, node) {  }
        public override CustomButton Clone() => new (UiPanel, (Godot.CenterContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorWindow.Window.Panel.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<EditorWindowPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 节点路径: EditorWindow.Window.Panel.VBoxContainer.CustomButton
        /// </summary>
        public CustomButton L_CustomButton
        {
            get
            {
                if (_L_CustomButton == null) _L_CustomButton = new CustomButton(UiPanel, Instance.GetNode<Godot.CenterContainer>("CustomButton"));
                return _L_CustomButton;
            }
        }
        private CustomButton _L_CustomButton;

        public HBoxContainer(EditorWindowPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorWindow.Window.Panel.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<EditorWindowPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 节点路径: EditorWindow.Window.Panel.Body
        /// </summary>
        public Body L_Body
        {
            get
            {
                if (_L_Body == null) _L_Body = new Body(UiPanel, Instance.GetNode<Godot.MarginContainer>("Body"));
                return _L_Body;
            }
        }
        private Body _L_Body;

        /// <summary>
        /// 节点路径: EditorWindow.Window.Panel.HBoxContainer
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

        public VBoxContainer(EditorWindowPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorWindow.Window.Panel
    /// </summary>
    public class Panel : UiNode<EditorWindowPanel, Godot.Panel, Panel>
    {
        /// <summary>
        /// 节点路径: EditorWindow.Window.VBoxContainer
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

        public Panel(EditorWindowPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override Panel Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorWindow.Window
    /// </summary>
    public class Window : UiNode<EditorWindowPanel, Godot.Window, Window>
    {
        /// <summary>
        /// 节点路径: EditorWindow.Panel
        /// </summary>
        public Panel L_Panel
        {
            get
            {
                if (_L_Panel == null) _L_Panel = new Panel(UiPanel, Instance.GetNode<Godot.Panel>("Panel"));
                return _L_Panel;
            }
        }
        private Panel _L_Panel;

        public Window(EditorWindowPanel uiPanel, Godot.Window node) : base(uiPanel, node) {  }
        public override Window Clone() => new (UiPanel, (Godot.Window)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorWindow.Bg
    /// </summary>
    public Bg S_Bg => L_Bg;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorWindow.Window.Panel.VBoxContainer.Body
    /// </summary>
    public Body S_Body => L_Window.L_Panel.L_VBoxContainer.L_Body;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorWindow.Window.Panel.VBoxContainer.HBoxContainer.CustomButton.Button
    /// </summary>
    public Button S_Button => L_Window.L_Panel.L_VBoxContainer.L_HBoxContainer.L_CustomButton.L_Button;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorWindow.Window.Panel.VBoxContainer.HBoxContainer.CustomButton
    /// </summary>
    public CustomButton S_CustomButton => L_Window.L_Panel.L_VBoxContainer.L_HBoxContainer.L_CustomButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorWindow.Window.Panel.VBoxContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_Window.L_Panel.L_VBoxContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorWindow.Window.Panel.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_Window.L_Panel.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorWindow.Window.Panel
    /// </summary>
    public Panel S_Panel => L_Window.L_Panel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorWindow.Window
    /// </summary>
    public Window S_Window => L_Window;

}
