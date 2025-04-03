namespace UI.Setting;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Setting : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: Setting.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((SettingPanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: Setting.TextureRect
    /// </summary>
    public TextureRect L_TextureRect
    {
        get
        {
            if (_L_TextureRect == null) _L_TextureRect = new TextureRect((SettingPanel)this, GetNode<Godot.TextureRect>("TextureRect"));
            return _L_TextureRect;
        }
    }
    private TextureRect _L_TextureRect;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: Setting.ScrollContainer
    /// </summary>
    public ScrollContainer L_ScrollContainer
    {
        get
        {
            if (_L_ScrollContainer == null) _L_ScrollContainer = new ScrollContainer((SettingPanel)this, GetNode<Godot.ScrollContainer>("ScrollContainer"));
            return _L_ScrollContainer;
        }
    }
    private ScrollContainer _L_ScrollContainer;


    public Setting() : base(nameof(Setting))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: Setting.ColorRect
    /// </summary>
    public class ColorRect : UiNode<SettingPanel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(SettingPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.TextureRect"/>, 路径: Setting.TextureRect
    /// </summary>
    public class TextureRect : UiNode<SettingPanel, Godot.TextureRect, TextureRect>
    {
        public TextureRect(SettingPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override TextureRect Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Setting.ScrollContainer.SettingMenu.Title
    /// </summary>
    public class Title : UiNode<SettingPanel, Godot.Label, Title>
    {
        public Title(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Title Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Setting.ScrollContainer.SettingMenu.FullScreen.Name
    /// </summary>
    public class Name : UiNode<SettingPanel, Godot.Label, Name>
    {
        public Name(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Name Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.CheckBox"/>, 路径: Setting.ScrollContainer.SettingMenu.FullScreen.CheckBox
    /// </summary>
    public class CheckBox : UiNode<SettingPanel, Godot.CheckBox, CheckBox>
    {
        public CheckBox(SettingPanel uiPanel, Godot.CheckBox node) : base(uiPanel, node) {  }
        public override CheckBox Clone() => new (UiPanel, (Godot.CheckBox)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Setting.ScrollContainer.SettingMenu.FullScreen
    /// </summary>
    public class FullScreen : UiNode<SettingPanel, Godot.HBoxContainer, FullScreen>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Setting.ScrollContainer.SettingMenu.Name
        /// </summary>
        public Name L_Name
        {
            get
            {
                if (_L_Name == null) _L_Name = new Name(UiPanel, Instance.GetNode<Godot.Label>("Name"));
                return _L_Name;
            }
        }
        private Name _L_Name;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.CheckBox"/>, 节点路径: Setting.ScrollContainer.SettingMenu.CheckBox
        /// </summary>
        public CheckBox L_CheckBox
        {
            get
            {
                if (_L_CheckBox == null) _L_CheckBox = new CheckBox(UiPanel, Instance.GetNode<Godot.CheckBox>("CheckBox"));
                return _L_CheckBox;
            }
        }
        private CheckBox _L_CheckBox;

        public FullScreen(SettingPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override FullScreen Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Setting.ScrollContainer.SettingMenu.FullScreen2.Label
    /// </summary>
    public class Label : UiNode<SettingPanel, Godot.Label, Label>
    {
        public Label(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HSlider"/>, 路径: Setting.ScrollContainer.SettingMenu.FullScreen2.BGM
    /// </summary>
    public class BGM : UiNode<SettingPanel, Godot.HSlider, BGM>
    {
        public BGM(SettingPanel uiPanel, Godot.HSlider node) : base(uiPanel, node) {  }
        public override BGM Clone() => new (UiPanel, (Godot.HSlider)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Setting.ScrollContainer.SettingMenu.FullScreen2
    /// </summary>
    public class FullScreen2 : UiNode<SettingPanel, Godot.HBoxContainer, FullScreen2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Setting.ScrollContainer.SettingMenu.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Setting.ScrollContainer.SettingMenu.BGM
        /// </summary>
        public BGM L_BGM
        {
            get
            {
                if (_L_BGM == null) _L_BGM = new BGM(UiPanel, Instance.GetNode<Godot.HSlider>("BGM"));
                return _L_BGM;
            }
        }
        private BGM _L_BGM;

        public FullScreen2(SettingPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override FullScreen2 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Setting.ScrollContainer.SettingMenu.FullScreen3.Label
    /// </summary>
    public class Label_1 : UiNode<SettingPanel, Godot.Label, Label_1>
    {
        public Label_1(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HSlider"/>, 路径: Setting.ScrollContainer.SettingMenu.FullScreen3.SFX
    /// </summary>
    public class SFX : UiNode<SettingPanel, Godot.HSlider, SFX>
    {
        public SFX(SettingPanel uiPanel, Godot.HSlider node) : base(uiPanel, node) {  }
        public override SFX Clone() => new (UiPanel, (Godot.HSlider)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Setting.ScrollContainer.SettingMenu.FullScreen3
    /// </summary>
    public class FullScreen3 : UiNode<SettingPanel, Godot.HBoxContainer, FullScreen3>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Setting.ScrollContainer.SettingMenu.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Setting.ScrollContainer.SettingMenu.SFX
        /// </summary>
        public SFX L_SFX
        {
            get
            {
                if (_L_SFX == null) _L_SFX = new SFX(UiPanel, Instance.GetNode<Godot.HSlider>("SFX"));
                return _L_SFX;
            }
        }
        private SFX _L_SFX;

        public FullScreen3(SettingPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override FullScreen3 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: Setting.ScrollContainer.SettingMenu.Back
    /// </summary>
    public class Back : UiNode<SettingPanel, Godot.Button, Back>
    {
        public Back(SettingPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Back Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Setting.ScrollContainer.SettingMenu
    /// </summary>
    public class SettingMenu : UiNode<SettingPanel, Godot.VBoxContainer, SettingMenu>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Setting.ScrollContainer.Title
        /// </summary>
        public Title L_Title
        {
            get
            {
                if (_L_Title == null) _L_Title = new Title(UiPanel, Instance.GetNode<Godot.Label>("Title"));
                return _L_Title;
            }
        }
        private Title _L_Title;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Setting.ScrollContainer.FullScreen
        /// </summary>
        public FullScreen L_FullScreen
        {
            get
            {
                if (_L_FullScreen == null) _L_FullScreen = new FullScreen(UiPanel, Instance.GetNode<Godot.HBoxContainer>("FullScreen"));
                return _L_FullScreen;
            }
        }
        private FullScreen _L_FullScreen;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Setting.ScrollContainer.FullScreen2
        /// </summary>
        public FullScreen2 L_FullScreen2
        {
            get
            {
                if (_L_FullScreen2 == null) _L_FullScreen2 = new FullScreen2(UiPanel, Instance.GetNode<Godot.HBoxContainer>("FullScreen2"));
                return _L_FullScreen2;
            }
        }
        private FullScreen2 _L_FullScreen2;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Setting.ScrollContainer.FullScreen3
        /// </summary>
        public FullScreen3 L_FullScreen3
        {
            get
            {
                if (_L_FullScreen3 == null) _L_FullScreen3 = new FullScreen3(UiPanel, Instance.GetNode<Godot.HBoxContainer>("FullScreen3"));
                return _L_FullScreen3;
            }
        }
        private FullScreen3 _L_FullScreen3;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: Setting.ScrollContainer.Back
        /// </summary>
        public Back L_Back
        {
            get
            {
                if (_L_Back == null) _L_Back = new Back(UiPanel, Instance.GetNode<Godot.Button>("Back"));
                return _L_Back;
            }
        }
        private Back _L_Back;

        public SettingMenu(SettingPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override SettingMenu Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ScrollContainer"/>, 路径: Setting.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<SettingPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Setting.SettingMenu
        /// </summary>
        public SettingMenu L_SettingMenu
        {
            get
            {
                if (_L_SettingMenu == null) _L_SettingMenu = new SettingMenu(UiPanel, Instance.GetNode<Godot.VBoxContainer>("SettingMenu"));
                return _L_SettingMenu;
            }
        }
        private SettingMenu _L_SettingMenu;

        public ScrollContainer(SettingPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: Setting.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.TextureRect"/>, 节点路径: Setting.TextureRect
    /// </summary>
    public TextureRect S_TextureRect => L_TextureRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: Setting.ScrollContainer.SettingMenu.Title
    /// </summary>
    public Title S_Title => L_ScrollContainer.L_SettingMenu.L_Title;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: Setting.ScrollContainer.SettingMenu.FullScreen.Name
    /// </summary>
    public Name S_Name => L_ScrollContainer.L_SettingMenu.L_FullScreen.L_Name;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.CheckBox"/>, 节点路径: Setting.ScrollContainer.SettingMenu.FullScreen.CheckBox
    /// </summary>
    public CheckBox S_CheckBox => L_ScrollContainer.L_SettingMenu.L_FullScreen.L_CheckBox;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Setting.ScrollContainer.SettingMenu.FullScreen
    /// </summary>
    public FullScreen S_FullScreen => L_ScrollContainer.L_SettingMenu.L_FullScreen;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Setting.ScrollContainer.SettingMenu.FullScreen2.BGM
    /// </summary>
    public BGM S_BGM => L_ScrollContainer.L_SettingMenu.L_FullScreen2.L_BGM;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Setting.ScrollContainer.SettingMenu.FullScreen2
    /// </summary>
    public FullScreen2 S_FullScreen2 => L_ScrollContainer.L_SettingMenu.L_FullScreen2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Setting.ScrollContainer.SettingMenu.FullScreen3.SFX
    /// </summary>
    public SFX S_SFX => L_ScrollContainer.L_SettingMenu.L_FullScreen3.L_SFX;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Setting.ScrollContainer.SettingMenu.FullScreen3
    /// </summary>
    public FullScreen3 S_FullScreen3 => L_ScrollContainer.L_SettingMenu.L_FullScreen3;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: Setting.ScrollContainer.SettingMenu.Back
    /// </summary>
    public Back S_Back => L_ScrollContainer.L_SettingMenu.L_Back;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Setting.ScrollContainer.SettingMenu
    /// </summary>
    public SettingMenu S_SettingMenu => L_ScrollContainer.L_SettingMenu;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: Setting.ScrollContainer
    /// </summary>
    public ScrollContainer S_ScrollContainer => L_ScrollContainer;

}
