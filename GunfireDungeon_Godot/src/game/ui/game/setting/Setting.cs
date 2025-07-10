using DsUi;

namespace UI.game.Setting;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Setting : UiBase
{
    /// <summary>
    /// 节点路径: Setting.ColorRect
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
    /// 节点路径: Setting.ScrollContainer
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


    public Setting() : base(UiManager.UiName.Game_Setting)
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: Setting.ColorRect
    /// </summary>
    public class ColorRect : UiNode<SettingPanel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(SettingPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.Title
    /// </summary>
    public class Title : UiNode<SettingPanel, Godot.Label, Title>
    {
        public Title(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Title Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer.Name
    /// </summary>
    public class Name : UiNode<SettingPanel, Godot.Label, Name>
    {
        public Name(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Name Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer.FullScreen
    /// </summary>
    public class FullScreen : UiNode<SettingPanel, Godot.CheckBox, FullScreen>
    {
        public FullScreen(SettingPanel uiPanel, Godot.CheckBox node) : base(uiPanel, node) {  }
        public override FullScreen Clone() => new (UiPanel, (Godot.CheckBox)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer
    /// </summary>
    public class BoxContainer : UiNode<SettingPanel, Godot.HBoxContainer, BoxContainer>
    {
        /// <summary>
        /// 节点路径: Setting.ScrollContainer.SettingMenu.Name
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
        /// 节点路径: Setting.ScrollContainer.SettingMenu.FullScreen
        /// </summary>
        public FullScreen L_FullScreen
        {
            get
            {
                if (_L_FullScreen == null) _L_FullScreen = new FullScreen(UiPanel, Instance.GetNode<Godot.CheckBox>("FullScreen"));
                return _L_FullScreen;
            }
        }
        private FullScreen _L_FullScreen;

        public BoxContainer(SettingPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override BoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer6.Name
    /// </summary>
    public class Name_1 : UiNode<SettingPanel, Godot.Label, Name_1>
    {
        public Name_1(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Name_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer6.VerticalSync
    /// </summary>
    public class VerticalSync : UiNode<SettingPanel, Godot.CheckBox, VerticalSync>
    {
        public VerticalSync(SettingPanel uiPanel, Godot.CheckBox node) : base(uiPanel, node) {  }
        public override VerticalSync Clone() => new (UiPanel, (Godot.CheckBox)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer6
    /// </summary>
    public class BoxContainer6 : UiNode<SettingPanel, Godot.HBoxContainer, BoxContainer6>
    {
        /// <summary>
        /// 节点路径: Setting.ScrollContainer.SettingMenu.Name
        /// </summary>
        public Name_1 L_Name
        {
            get
            {
                if (_L_Name == null) _L_Name = new Name_1(UiPanel, Instance.GetNode<Godot.Label>("Name"));
                return _L_Name;
            }
        }
        private Name_1 _L_Name;

        /// <summary>
        /// 节点路径: Setting.ScrollContainer.SettingMenu.VerticalSync
        /// </summary>
        public VerticalSync L_VerticalSync
        {
            get
            {
                if (_L_VerticalSync == null) _L_VerticalSync = new VerticalSync(UiPanel, Instance.GetNode<Godot.CheckBox>("VerticalSync"));
                return _L_VerticalSync;
            }
        }
        private VerticalSync _L_VerticalSync;

        public BoxContainer6(SettingPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override BoxContainer6 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer2.Name
    /// </summary>
    public class Name_2 : UiNode<SettingPanel, Godot.Label, Name_2>
    {
        public Name_2(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Name_2 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer2.PerfectPixel
    /// </summary>
    public class PerfectPixel : UiNode<SettingPanel, Godot.CheckBox, PerfectPixel>
    {
        public PerfectPixel(SettingPanel uiPanel, Godot.CheckBox node) : base(uiPanel, node) {  }
        public override PerfectPixel Clone() => new (UiPanel, (Godot.CheckBox)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer2
    /// </summary>
    public class BoxContainer2 : UiNode<SettingPanel, Godot.HBoxContainer, BoxContainer2>
    {
        /// <summary>
        /// 节点路径: Setting.ScrollContainer.SettingMenu.Name
        /// </summary>
        public Name_2 L_Name
        {
            get
            {
                if (_L_Name == null) _L_Name = new Name_2(UiPanel, Instance.GetNode<Godot.Label>("Name"));
                return _L_Name;
            }
        }
        private Name_2 _L_Name;

        /// <summary>
        /// 节点路径: Setting.ScrollContainer.SettingMenu.PerfectPixel
        /// </summary>
        public PerfectPixel L_PerfectPixel
        {
            get
            {
                if (_L_PerfectPixel == null) _L_PerfectPixel = new PerfectPixel(UiPanel, Instance.GetNode<Godot.CheckBox>("PerfectPixel"));
                return _L_PerfectPixel;
            }
        }
        private PerfectPixel _L_PerfectPixel;

        public BoxContainer2(SettingPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override BoxContainer2 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer3.Label
    /// </summary>
    public class Label : UiNode<SettingPanel, Godot.Label, Label>
    {
        public Label(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer3.BGM
    /// </summary>
    public class BGM : UiNode<SettingPanel, Godot.HSlider, BGM>
    {
        public BGM(SettingPanel uiPanel, Godot.HSlider node) : base(uiPanel, node) {  }
        public override BGM Clone() => new (UiPanel, (Godot.HSlider)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer3
    /// </summary>
    public class BoxContainer3 : UiNode<SettingPanel, Godot.HBoxContainer, BoxContainer3>
    {
        /// <summary>
        /// 节点路径: Setting.ScrollContainer.SettingMenu.Label
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
        /// 节点路径: Setting.ScrollContainer.SettingMenu.BGM
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

        public BoxContainer3(SettingPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override BoxContainer3 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer4.Label
    /// </summary>
    public class Label_1 : UiNode<SettingPanel, Godot.Label, Label_1>
    {
        public Label_1(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer4.SFX
    /// </summary>
    public class SFX : UiNode<SettingPanel, Godot.HSlider, SFX>
    {
        public SFX(SettingPanel uiPanel, Godot.HSlider node) : base(uiPanel, node) {  }
        public override SFX Clone() => new (UiPanel, (Godot.HSlider)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer4
    /// </summary>
    public class BoxContainer4 : UiNode<SettingPanel, Godot.HBoxContainer, BoxContainer4>
    {
        /// <summary>
        /// 节点路径: Setting.ScrollContainer.SettingMenu.Label
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
        /// 节点路径: Setting.ScrollContainer.SettingMenu.SFX
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

        public BoxContainer4(SettingPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override BoxContainer4 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer5.Label
    /// </summary>
    public class Label_2 : UiNode<SettingPanel, Godot.Label, Label_2>
    {
        public Label_2(SettingPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_2 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer5.FollowsMouseAmount
    /// </summary>
    public class FollowsMouseAmount : UiNode<SettingPanel, Godot.HSlider, FollowsMouseAmount>
    {
        public FollowsMouseAmount(SettingPanel uiPanel, Godot.HSlider node) : base(uiPanel, node) {  }
        public override FollowsMouseAmount Clone() => new (UiPanel, (Godot.HSlider)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.BoxContainer5
    /// </summary>
    public class BoxContainer5 : UiNode<SettingPanel, Godot.HBoxContainer, BoxContainer5>
    {
        /// <summary>
        /// 节点路径: Setting.ScrollContainer.SettingMenu.Label
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
        /// 节点路径: Setting.ScrollContainer.SettingMenu.FollowsMouseAmount
        /// </summary>
        public FollowsMouseAmount L_FollowsMouseAmount
        {
            get
            {
                if (_L_FollowsMouseAmount == null) _L_FollowsMouseAmount = new FollowsMouseAmount(UiPanel, Instance.GetNode<Godot.HSlider>("FollowsMouseAmount"));
                return _L_FollowsMouseAmount;
            }
        }
        private FollowsMouseAmount _L_FollowsMouseAmount;

        public BoxContainer5(SettingPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override BoxContainer5 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu.Back
    /// </summary>
    public class Back : UiNode<SettingPanel, Godot.Button, Back>
    {
        public Back(SettingPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Back Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Setting.ScrollContainer.SettingMenu
    /// </summary>
    public class SettingMenu : UiNode<SettingPanel, Godot.VBoxContainer, SettingMenu>
    {
        /// <summary>
        /// 节点路径: Setting.ScrollContainer.Title
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
        /// 节点路径: Setting.ScrollContainer.BoxContainer
        /// </summary>
        public BoxContainer L_BoxContainer
        {
            get
            {
                if (_L_BoxContainer == null) _L_BoxContainer = new BoxContainer(UiPanel, Instance.GetNode<Godot.HBoxContainer>("BoxContainer"));
                return _L_BoxContainer;
            }
        }
        private BoxContainer _L_BoxContainer;

        /// <summary>
        /// 节点路径: Setting.ScrollContainer.BoxContainer6
        /// </summary>
        public BoxContainer6 L_BoxContainer6
        {
            get
            {
                if (_L_BoxContainer6 == null) _L_BoxContainer6 = new BoxContainer6(UiPanel, Instance.GetNode<Godot.HBoxContainer>("BoxContainer6"));
                return _L_BoxContainer6;
            }
        }
        private BoxContainer6 _L_BoxContainer6;

        /// <summary>
        /// 节点路径: Setting.ScrollContainer.BoxContainer2
        /// </summary>
        public BoxContainer2 L_BoxContainer2
        {
            get
            {
                if (_L_BoxContainer2 == null) _L_BoxContainer2 = new BoxContainer2(UiPanel, Instance.GetNode<Godot.HBoxContainer>("BoxContainer2"));
                return _L_BoxContainer2;
            }
        }
        private BoxContainer2 _L_BoxContainer2;

        /// <summary>
        /// 节点路径: Setting.ScrollContainer.BoxContainer3
        /// </summary>
        public BoxContainer3 L_BoxContainer3
        {
            get
            {
                if (_L_BoxContainer3 == null) _L_BoxContainer3 = new BoxContainer3(UiPanel, Instance.GetNode<Godot.HBoxContainer>("BoxContainer3"));
                return _L_BoxContainer3;
            }
        }
        private BoxContainer3 _L_BoxContainer3;

        /// <summary>
        /// 节点路径: Setting.ScrollContainer.BoxContainer4
        /// </summary>
        public BoxContainer4 L_BoxContainer4
        {
            get
            {
                if (_L_BoxContainer4 == null) _L_BoxContainer4 = new BoxContainer4(UiPanel, Instance.GetNode<Godot.HBoxContainer>("BoxContainer4"));
                return _L_BoxContainer4;
            }
        }
        private BoxContainer4 _L_BoxContainer4;

        /// <summary>
        /// 节点路径: Setting.ScrollContainer.BoxContainer5
        /// </summary>
        public BoxContainer5 L_BoxContainer5
        {
            get
            {
                if (_L_BoxContainer5 == null) _L_BoxContainer5 = new BoxContainer5(UiPanel, Instance.GetNode<Godot.HBoxContainer>("BoxContainer5"));
                return _L_BoxContainer5;
            }
        }
        private BoxContainer5 _L_BoxContainer5;

        /// <summary>
        /// 节点路径: Setting.ScrollContainer.Back
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
    /// 路径: Setting.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<SettingPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 节点路径: Setting.SettingMenu
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
    /// 场景中唯一名称的节点, 节点路径: Setting.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.Title
    /// </summary>
    public Title S_Title => L_ScrollContainer.L_SettingMenu.L_Title;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.BoxContainer.FullScreen
    /// </summary>
    public FullScreen S_FullScreen => L_ScrollContainer.L_SettingMenu.L_BoxContainer.L_FullScreen;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.BoxContainer
    /// </summary>
    public BoxContainer S_BoxContainer => L_ScrollContainer.L_SettingMenu.L_BoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.BoxContainer6.VerticalSync
    /// </summary>
    public VerticalSync S_VerticalSync => L_ScrollContainer.L_SettingMenu.L_BoxContainer6.L_VerticalSync;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.BoxContainer6
    /// </summary>
    public BoxContainer6 S_BoxContainer6 => L_ScrollContainer.L_SettingMenu.L_BoxContainer6;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.BoxContainer2.PerfectPixel
    /// </summary>
    public PerfectPixel S_PerfectPixel => L_ScrollContainer.L_SettingMenu.L_BoxContainer2.L_PerfectPixel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.BoxContainer2
    /// </summary>
    public BoxContainer2 S_BoxContainer2 => L_ScrollContainer.L_SettingMenu.L_BoxContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.BoxContainer3.BGM
    /// </summary>
    public BGM S_BGM => L_ScrollContainer.L_SettingMenu.L_BoxContainer3.L_BGM;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.BoxContainer3
    /// </summary>
    public BoxContainer3 S_BoxContainer3 => L_ScrollContainer.L_SettingMenu.L_BoxContainer3;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.BoxContainer4.SFX
    /// </summary>
    public SFX S_SFX => L_ScrollContainer.L_SettingMenu.L_BoxContainer4.L_SFX;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.BoxContainer4
    /// </summary>
    public BoxContainer4 S_BoxContainer4 => L_ScrollContainer.L_SettingMenu.L_BoxContainer4;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.BoxContainer5.FollowsMouseAmount
    /// </summary>
    public FollowsMouseAmount S_FollowsMouseAmount => L_ScrollContainer.L_SettingMenu.L_BoxContainer5.L_FollowsMouseAmount;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.BoxContainer5
    /// </summary>
    public BoxContainer5 S_BoxContainer5 => L_ScrollContainer.L_SettingMenu.L_BoxContainer5;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu.Back
    /// </summary>
    public Back S_Back => L_ScrollContainer.L_SettingMenu.L_Back;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer.SettingMenu
    /// </summary>
    public SettingMenu S_SettingMenu => L_ScrollContainer.L_SettingMenu;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Setting.ScrollContainer
    /// </summary>
    public ScrollContainer S_ScrollContainer => L_ScrollContainer;

}
