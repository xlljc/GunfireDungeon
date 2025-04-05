using DsUi;

namespace UI.editor.EditorManager;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class EditorManager : UiBase
{
    /// <summary>
    /// 节点路径: EditorManager.Bg
    /// </summary>
    public Bg L_Bg
    {
        get
        {
            if (_L_Bg == null) _L_Bg = new Bg((EditorManagerPanel)this, GetNode<Godot.Panel>("Bg"));
            return _L_Bg;
        }
    }
    private Bg _L_Bg;


    public EditorManager() : base(nameof(EditorManager))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.Head.Back
    /// </summary>
    public class Back : UiNode<EditorManagerPanel, Godot.Button, Back>
    {
        public Back(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Back Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.Head.Title
    /// </summary>
    public class Title : UiNode<EditorManagerPanel, Godot.Label, Title>
    {
        public Title(EditorManagerPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Title Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.Head
    /// </summary>
    public class Head : UiNode<EditorManagerPanel, Godot.Panel, Head>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.Back
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

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.Title
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

        public Head(EditorManagerPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override Head Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.HBoxContainer.GroupSearchInput
    /// </summary>
    public class GroupSearchInput : UiNode<EditorManagerPanel, Godot.LineEdit, GroupSearchInput>
    {
        public GroupSearchInput(EditorManagerPanel uiPanel, Godot.LineEdit node) : base(uiPanel, node) {  }
        public override GroupSearchInput Clone() => new (UiPanel, (Godot.LineEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.HBoxContainer.GroupSearchButton
    /// </summary>
    public class GroupSearchButton : UiNode<EditorManagerPanel, Godot.Button, GroupSearchButton>
    {
        public GroupSearchButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override GroupSearchButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer_1 : UiNode<EditorManagerPanel, Godot.HBoxContainer, HBoxContainer_1>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.GroupSearchInput
        /// </summary>
        public GroupSearchInput L_GroupSearchInput
        {
            get
            {
                if (_L_GroupSearchInput == null) _L_GroupSearchInput = new GroupSearchInput(UiPanel, Instance.GetNode<Godot.LineEdit>("GroupSearchInput"));
                return _L_GroupSearchInput;
            }
        }
        private GroupSearchInput _L_GroupSearchInput;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.GroupSearchButton
        /// </summary>
        public GroupSearchButton L_GroupSearchButton
        {
            get
            {
                if (_L_GroupSearchButton == null) _L_GroupSearchButton = new GroupSearchButton(UiPanel, Instance.GetNode<Godot.Button>("GroupSearchButton"));
                return _L_GroupSearchButton;
            }
        }
        private GroupSearchButton _L_GroupSearchButton;

        public HBoxContainer_1(EditorManagerPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer_1 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.HBoxContainer2.GroupAddButton
    /// </summary>
    public class GroupAddButton : UiNode<EditorManagerPanel, Godot.Button, GroupAddButton>
    {
        public GroupAddButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override GroupAddButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.HBoxContainer2.GroupEditButton
    /// </summary>
    public class GroupEditButton : UiNode<EditorManagerPanel, Godot.Button, GroupEditButton>
    {
        public GroupEditButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override GroupEditButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.HBoxContainer2.GroupDeleteButton
    /// </summary>
    public class GroupDeleteButton : UiNode<EditorManagerPanel, Godot.Button, GroupDeleteButton>
    {
        public GroupDeleteButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override GroupDeleteButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.HBoxContainer2
    /// </summary>
    public class HBoxContainer2 : UiNode<EditorManagerPanel, Godot.HBoxContainer, HBoxContainer2>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.GroupAddButton
        /// </summary>
        public GroupAddButton L_GroupAddButton
        {
            get
            {
                if (_L_GroupAddButton == null) _L_GroupAddButton = new GroupAddButton(UiPanel, Instance.GetNode<Godot.Button>("GroupAddButton"));
                return _L_GroupAddButton;
            }
        }
        private GroupAddButton _L_GroupAddButton;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.GroupEditButton
        /// </summary>
        public GroupEditButton L_GroupEditButton
        {
            get
            {
                if (_L_GroupEditButton == null) _L_GroupEditButton = new GroupEditButton(UiPanel, Instance.GetNode<Godot.Button>("GroupEditButton"));
                return _L_GroupEditButton;
            }
        }
        private GroupEditButton _L_GroupEditButton;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.GroupDeleteButton
        /// </summary>
        public GroupDeleteButton L_GroupDeleteButton
        {
            get
            {
                if (_L_GroupDeleteButton == null) _L_GroupDeleteButton = new GroupDeleteButton(UiPanel, Instance.GetNode<Godot.Button>("GroupDeleteButton"));
                return _L_GroupDeleteButton;
            }
        }
        private GroupDeleteButton _L_GroupDeleteButton;

        public HBoxContainer2(EditorManagerPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer2 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.ScrollContainer.GroupButton.SelectTexture
    /// </summary>
    public class SelectTexture : UiNode<EditorManagerPanel, Godot.NinePatchRect, SelectTexture>
    {
        public SelectTexture(EditorManagerPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override SelectTexture Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.ScrollContainer.GroupButton
    /// </summary>
    public class GroupButton : UiNode<EditorManagerPanel, Godot.Button, GroupButton>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.ScrollContainer.SelectTexture
        /// </summary>
        public SelectTexture L_SelectTexture
        {
            get
            {
                if (_L_SelectTexture == null) _L_SelectTexture = new SelectTexture(UiPanel, Instance.GetNode<Godot.NinePatchRect>("SelectTexture"));
                return _L_SelectTexture;
            }
        }
        private SelectTexture _L_SelectTexture;

        public GroupButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override GroupButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<EditorManagerPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.GroupButton
        /// </summary>
        public GroupButton L_GroupButton
        {
            get
            {
                if (_L_GroupButton == null) _L_GroupButton = new GroupButton(UiPanel, Instance.GetNode<Godot.Button>("GroupButton"));
                return _L_GroupButton;
            }
        }
        private GroupButton _L_GroupButton;

        public ScrollContainer(EditorManagerPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<EditorManagerPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.HBoxContainer
        /// </summary>
        public HBoxContainer_1 L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer_1(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer_1 _L_HBoxContainer;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.HBoxContainer2
        /// </summary>
        public HBoxContainer2 L_HBoxContainer2
        {
            get
            {
                if (_L_HBoxContainer2 == null) _L_HBoxContainer2 = new HBoxContainer2(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer2"));
                return _L_HBoxContainer2;
            }
        }
        private HBoxContainer2 _L_HBoxContainer2;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.ScrollContainer
        /// </summary>
        public ScrollContainer L_ScrollContainer
        {
            get
            {
                if (_L_ScrollContainer == null) _L_ScrollContainer = new ScrollContainer(UiPanel, Instance.GetNode<Godot.ScrollContainer>("ScrollContainer"));
                return _L_ScrollContainer;
            }
        }
        private ScrollContainer _L_ScrollContainer;

        public VBoxContainer_1(EditorManagerPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<EditorManagerPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.VBoxContainer
        /// </summary>
        public VBoxContainer_1 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_1(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_1 _L_VBoxContainer;

        public MarginContainer(EditorManagerPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel
    /// </summary>
    public class Panel : UiNode<EditorManagerPanel, Godot.Panel, Panel>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.MarginContainer
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

        public Panel(EditorManagerPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override Panel Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.HBoxContainer.RoomSearchInput
    /// </summary>
    public class RoomSearchInput : UiNode<EditorManagerPanel, Godot.LineEdit, RoomSearchInput>
    {
        public RoomSearchInput(EditorManagerPanel uiPanel, Godot.LineEdit node) : base(uiPanel, node) {  }
        public override RoomSearchInput Clone() => new (UiPanel, (Godot.LineEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.HBoxContainer.RoomTypeButton
    /// </summary>
    public class RoomTypeButton : UiNode<EditorManagerPanel, Godot.OptionButton, RoomTypeButton>
    {
        public RoomTypeButton(EditorManagerPanel uiPanel, Godot.OptionButton node) : base(uiPanel, node) {  }
        public override RoomTypeButton Clone() => new (UiPanel, (Godot.OptionButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.HBoxContainer.RoomSearchButton
    /// </summary>
    public class RoomSearchButton : UiNode<EditorManagerPanel, Godot.Button, RoomSearchButton>
    {
        public RoomSearchButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override RoomSearchButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.HBoxContainer.RoomAddButton
    /// </summary>
    public class RoomAddButton : UiNode<EditorManagerPanel, Godot.Button, RoomAddButton>
    {
        public RoomAddButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override RoomAddButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.HBoxContainer.RoomEditButton
    /// </summary>
    public class RoomEditButton : UiNode<EditorManagerPanel, Godot.Button, RoomEditButton>
    {
        public RoomEditButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override RoomEditButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.HBoxContainer.RoomDeleteButton
    /// </summary>
    public class RoomDeleteButton : UiNode<EditorManagerPanel, Godot.Button, RoomDeleteButton>
    {
        public RoomDeleteButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override RoomDeleteButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer_2 : UiNode<EditorManagerPanel, Godot.HBoxContainer, HBoxContainer_2>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.RoomSearchInput
        /// </summary>
        public RoomSearchInput L_RoomSearchInput
        {
            get
            {
                if (_L_RoomSearchInput == null) _L_RoomSearchInput = new RoomSearchInput(UiPanel, Instance.GetNode<Godot.LineEdit>("RoomSearchInput"));
                return _L_RoomSearchInput;
            }
        }
        private RoomSearchInput _L_RoomSearchInput;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.RoomTypeButton
        /// </summary>
        public RoomTypeButton L_RoomTypeButton
        {
            get
            {
                if (_L_RoomTypeButton == null) _L_RoomTypeButton = new RoomTypeButton(UiPanel, Instance.GetNode<Godot.OptionButton>("RoomTypeButton"));
                return _L_RoomTypeButton;
            }
        }
        private RoomTypeButton _L_RoomTypeButton;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.RoomSearchButton
        /// </summary>
        public RoomSearchButton L_RoomSearchButton
        {
            get
            {
                if (_L_RoomSearchButton == null) _L_RoomSearchButton = new RoomSearchButton(UiPanel, Instance.GetNode<Godot.Button>("RoomSearchButton"));
                return _L_RoomSearchButton;
            }
        }
        private RoomSearchButton _L_RoomSearchButton;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.RoomAddButton
        /// </summary>
        public RoomAddButton L_RoomAddButton
        {
            get
            {
                if (_L_RoomAddButton == null) _L_RoomAddButton = new RoomAddButton(UiPanel, Instance.GetNode<Godot.Button>("RoomAddButton"));
                return _L_RoomAddButton;
            }
        }
        private RoomAddButton _L_RoomAddButton;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.RoomEditButton
        /// </summary>
        public RoomEditButton L_RoomEditButton
        {
            get
            {
                if (_L_RoomEditButton == null) _L_RoomEditButton = new RoomEditButton(UiPanel, Instance.GetNode<Godot.Button>("RoomEditButton"));
                return _L_RoomEditButton;
            }
        }
        private RoomEditButton _L_RoomEditButton;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.RoomDeleteButton
        /// </summary>
        public RoomDeleteButton L_RoomDeleteButton
        {
            get
            {
                if (_L_RoomDeleteButton == null) _L_RoomDeleteButton = new RoomDeleteButton(UiPanel, Instance.GetNode<Godot.Button>("RoomDeleteButton"));
                return _L_RoomDeleteButton;
            }
        }
        private RoomDeleteButton _L_RoomDeleteButton;

        public HBoxContainer_2(EditorManagerPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer_2 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.RoomButton.PreviewImage
    /// </summary>
    public class PreviewImage : UiNode<EditorManagerPanel, Godot.TextureRect, PreviewImage>
    {
        public PreviewImage(EditorManagerPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override PreviewImage Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.RoomButton.RoomName
    /// </summary>
    public class RoomName : UiNode<EditorManagerPanel, Godot.Label, RoomName>
    {
        public RoomName(EditorManagerPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override RoomName Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.RoomButton.RoomType
    /// </summary>
    public class RoomType : UiNode<EditorManagerPanel, Godot.Label, RoomType>
    {
        public RoomType(EditorManagerPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override RoomType Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.RoomButton.SelectTexture
    /// </summary>
    public class SelectTexture_1 : UiNode<EditorManagerPanel, Godot.NinePatchRect, SelectTexture_1>
    {
        public SelectTexture_1(EditorManagerPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override SelectTexture_1 Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.RoomButton.ErrorTexture
    /// </summary>
    public class ErrorTexture : UiNode<EditorManagerPanel, Godot.TextureRect, ErrorTexture>
    {
        public ErrorTexture(EditorManagerPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override ErrorTexture Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.RoomButton
    /// </summary>
    public class RoomButton : UiNode<EditorManagerPanel, Godot.Button, RoomButton>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.PreviewImage
        /// </summary>
        public PreviewImage L_PreviewImage
        {
            get
            {
                if (_L_PreviewImage == null) _L_PreviewImage = new PreviewImage(UiPanel, Instance.GetNode<Godot.TextureRect>("PreviewImage"));
                return _L_PreviewImage;
            }
        }
        private PreviewImage _L_PreviewImage;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.RoomName
        /// </summary>
        public RoomName L_RoomName
        {
            get
            {
                if (_L_RoomName == null) _L_RoomName = new RoomName(UiPanel, Instance.GetNode<Godot.Label>("RoomName"));
                return _L_RoomName;
            }
        }
        private RoomName _L_RoomName;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.RoomType
        /// </summary>
        public RoomType L_RoomType
        {
            get
            {
                if (_L_RoomType == null) _L_RoomType = new RoomType(UiPanel, Instance.GetNode<Godot.Label>("RoomType"));
                return _L_RoomType;
            }
        }
        private RoomType _L_RoomType;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.SelectTexture
        /// </summary>
        public SelectTexture_1 L_SelectTexture
        {
            get
            {
                if (_L_SelectTexture == null) _L_SelectTexture = new SelectTexture_1(UiPanel, Instance.GetNode<Godot.NinePatchRect>("SelectTexture"));
                return _L_SelectTexture;
            }
        }
        private SelectTexture_1 _L_SelectTexture;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.ErrorTexture
        /// </summary>
        public ErrorTexture L_ErrorTexture
        {
            get
            {
                if (_L_ErrorTexture == null) _L_ErrorTexture = new ErrorTexture(UiPanel, Instance.GetNode<Godot.TextureRect>("ErrorTexture"));
                return _L_ErrorTexture;
            }
        }
        private ErrorTexture _L_ErrorTexture;

        public RoomButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override RoomButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer
    /// </summary>
    public class ScrollContainer_1 : UiNode<EditorManagerPanel, Godot.ScrollContainer, ScrollContainer_1>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.RoomButton
        /// </summary>
        public RoomButton L_RoomButton
        {
            get
            {
                if (_L_RoomButton == null) _L_RoomButton = new RoomButton(UiPanel, Instance.GetNode<Godot.Button>("RoomButton"));
                return _L_RoomButton;
            }
        }
        private RoomButton _L_RoomButton;

        public ScrollContainer_1(EditorManagerPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer_1 Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_2 : UiNode<EditorManagerPanel, Godot.VBoxContainer, VBoxContainer_2>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.HBoxContainer
        /// </summary>
        public HBoxContainer_2 L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer_2(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer_2 _L_HBoxContainer;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.ScrollContainer
        /// </summary>
        public ScrollContainer_1 L_ScrollContainer
        {
            get
            {
                if (_L_ScrollContainer == null) _L_ScrollContainer = new ScrollContainer_1(UiPanel, Instance.GetNode<Godot.ScrollContainer>("ScrollContainer"));
                return _L_ScrollContainer;
            }
        }
        private ScrollContainer_1 _L_ScrollContainer;

        public VBoxContainer_2(EditorManagerPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_2 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer
    /// </summary>
    public class MarginContainer_1 : UiNode<EditorManagerPanel, Godot.MarginContainer, MarginContainer_1>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.VBoxContainer
        /// </summary>
        public VBoxContainer_2 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_2(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_2 _L_VBoxContainer;

        public MarginContainer_1(EditorManagerPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer_1 Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2
    /// </summary>
    public class Panel2 : UiNode<EditorManagerPanel, Godot.Panel, Panel2>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.MarginContainer
        /// </summary>
        public MarginContainer_1 L_MarginContainer
        {
            get
            {
                if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer_1(UiPanel, Instance.GetNode<Godot.MarginContainer>("MarginContainer"));
                return _L_MarginContainer;
            }
        }
        private MarginContainer_1 _L_MarginContainer;

        public Panel2(EditorManagerPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override Panel2 Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<EditorManagerPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.Panel
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

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.Panel2
        /// </summary>
        public Panel2 L_Panel2
        {
            get
            {
                if (_L_Panel2 == null) _L_Panel2 = new Panel2(UiPanel, Instance.GetNode<Godot.Panel>("Panel2"));
                return _L_Panel2;
            }
        }
        private Panel2 _L_Panel2;

        public HBoxContainer(EditorManagerPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject
    /// </summary>
    public class MapEditorProject : UiNode<EditorManagerPanel, UI.editor.MapEditorProject.MapEditorProjectPanel, MapEditorProject>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.HBoxContainer
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

        public MapEditorProject(EditorManagerPanel uiPanel, UI.editor.MapEditorProject.MapEditorProjectPanel node) : base(uiPanel, node) {  }
        public override MapEditorProject Clone() => new (UiPanel, (UI.editor.MapEditorProject.MapEditorProjectPanel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.Map
    /// </summary>
    public class Map : UiNode<EditorManagerPanel, Godot.MarginContainer, Map>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.MapEditorProject
        /// </summary>
        public MapEditorProject L_MapEditorProject
        {
            get
            {
                if (_L_MapEditorProject == null) _L_MapEditorProject = new MapEditorProject(UiPanel, Instance.GetNode<UI.editor.MapEditorProject.MapEditorProjectPanel>("MapEditorProject"));
                return _L_MapEditorProject;
            }
        }
        private MapEditorProject _L_MapEditorProject;

        public Map(EditorManagerPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override Map Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.HBoxContainer.TileSearchInput
    /// </summary>
    public class TileSearchInput : UiNode<EditorManagerPanel, Godot.LineEdit, TileSearchInput>
    {
        public TileSearchInput(EditorManagerPanel uiPanel, Godot.LineEdit node) : base(uiPanel, node) {  }
        public override TileSearchInput Clone() => new (UiPanel, (Godot.LineEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.HBoxContainer.TileSearchButton
    /// </summary>
    public class TileSearchButton : UiNode<EditorManagerPanel, Godot.Button, TileSearchButton>
    {
        public TileSearchButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override TileSearchButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.HBoxContainer.TileAddButton
    /// </summary>
    public class TileAddButton : UiNode<EditorManagerPanel, Godot.Button, TileAddButton>
    {
        public TileAddButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override TileAddButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.HBoxContainer.TileEditButton
    /// </summary>
    public class TileEditButton : UiNode<EditorManagerPanel, Godot.Button, TileEditButton>
    {
        public TileEditButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override TileEditButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.HBoxContainer.TileDeleteButton
    /// </summary>
    public class TileDeleteButton : UiNode<EditorManagerPanel, Godot.Button, TileDeleteButton>
    {
        public TileDeleteButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override TileDeleteButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer_3 : UiNode<EditorManagerPanel, Godot.HBoxContainer, HBoxContainer_3>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.TileSearchInput
        /// </summary>
        public TileSearchInput L_TileSearchInput
        {
            get
            {
                if (_L_TileSearchInput == null) _L_TileSearchInput = new TileSearchInput(UiPanel, Instance.GetNode<Godot.LineEdit>("TileSearchInput"));
                return _L_TileSearchInput;
            }
        }
        private TileSearchInput _L_TileSearchInput;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.TileSearchButton
        /// </summary>
        public TileSearchButton L_TileSearchButton
        {
            get
            {
                if (_L_TileSearchButton == null) _L_TileSearchButton = new TileSearchButton(UiPanel, Instance.GetNode<Godot.Button>("TileSearchButton"));
                return _L_TileSearchButton;
            }
        }
        private TileSearchButton _L_TileSearchButton;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.TileAddButton
        /// </summary>
        public TileAddButton L_TileAddButton
        {
            get
            {
                if (_L_TileAddButton == null) _L_TileAddButton = new TileAddButton(UiPanel, Instance.GetNode<Godot.Button>("TileAddButton"));
                return _L_TileAddButton;
            }
        }
        private TileAddButton _L_TileAddButton;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.TileEditButton
        /// </summary>
        public TileEditButton L_TileEditButton
        {
            get
            {
                if (_L_TileEditButton == null) _L_TileEditButton = new TileEditButton(UiPanel, Instance.GetNode<Godot.Button>("TileEditButton"));
                return _L_TileEditButton;
            }
        }
        private TileEditButton _L_TileEditButton;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.TileDeleteButton
        /// </summary>
        public TileDeleteButton L_TileDeleteButton
        {
            get
            {
                if (_L_TileDeleteButton == null) _L_TileDeleteButton = new TileDeleteButton(UiPanel, Instance.GetNode<Godot.Button>("TileDeleteButton"));
                return _L_TileDeleteButton;
            }
        }
        private TileDeleteButton _L_TileDeleteButton;

        public HBoxContainer_3(EditorManagerPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer_3 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.ScrollContainer.TileButton.Icon
    /// </summary>
    public class Icon : UiNode<EditorManagerPanel, Godot.TextureRect, Icon>
    {
        public Icon(EditorManagerPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override Icon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.ScrollContainer.TileButton.TileName
    /// </summary>
    public class TileName : UiNode<EditorManagerPanel, Godot.Label, TileName>
    {
        public TileName(EditorManagerPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override TileName Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.ScrollContainer.TileButton.SelectTexture
    /// </summary>
    public class SelectTexture_2 : UiNode<EditorManagerPanel, Godot.NinePatchRect, SelectTexture_2>
    {
        public SelectTexture_2(EditorManagerPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override SelectTexture_2 Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.ScrollContainer.TileButton
    /// </summary>
    public class TileButton : UiNode<EditorManagerPanel, Godot.Button, TileButton>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.ScrollContainer.Icon
        /// </summary>
        public Icon L_Icon
        {
            get
            {
                if (_L_Icon == null) _L_Icon = new Icon(UiPanel, Instance.GetNode<Godot.TextureRect>("Icon"));
                return _L_Icon;
            }
        }
        private Icon _L_Icon;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.ScrollContainer.TileName
        /// </summary>
        public TileName L_TileName
        {
            get
            {
                if (_L_TileName == null) _L_TileName = new TileName(UiPanel, Instance.GetNode<Godot.Label>("TileName"));
                return _L_TileName;
            }
        }
        private TileName _L_TileName;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.ScrollContainer.SelectTexture
        /// </summary>
        public SelectTexture_2 L_SelectTexture
        {
            get
            {
                if (_L_SelectTexture == null) _L_SelectTexture = new SelectTexture_2(UiPanel, Instance.GetNode<Godot.NinePatchRect>("SelectTexture"));
                return _L_SelectTexture;
            }
        }
        private SelectTexture_2 _L_SelectTexture;

        public TileButton(EditorManagerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override TileButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.ScrollContainer
    /// </summary>
    public class ScrollContainer_2 : UiNode<EditorManagerPanel, Godot.ScrollContainer, ScrollContainer_2>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.TileButton
        /// </summary>
        public TileButton L_TileButton
        {
            get
            {
                if (_L_TileButton == null) _L_TileButton = new TileButton(UiPanel, Instance.GetNode<Godot.Button>("TileButton"));
                return _L_TileButton;
            }
        }
        private TileButton _L_TileButton;

        public ScrollContainer_2(EditorManagerPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer_2 Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer
    /// </summary>
    public class VBoxContainer_3 : UiNode<EditorManagerPanel, Godot.VBoxContainer, VBoxContainer_3>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.HBoxContainer
        /// </summary>
        public HBoxContainer_3 L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer_3(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer_3 _L_HBoxContainer;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.ScrollContainer
        /// </summary>
        public ScrollContainer_2 L_ScrollContainer
        {
            get
            {
                if (_L_ScrollContainer == null) _L_ScrollContainer = new ScrollContainer_2(UiPanel, Instance.GetNode<Godot.ScrollContainer>("ScrollContainer"));
                return _L_ScrollContainer;
            }
        }
        private ScrollContainer_2 _L_ScrollContainer;

        public VBoxContainer_3(EditorManagerPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_3 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.Panel.ScrollContainer.Preview.Name
    /// </summary>
    public class Name : UiNode<EditorManagerPanel, Godot.Label, Name>
    {
        public Name(EditorManagerPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Name Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.Panel.ScrollContainer.Preview.PreviewImage
    /// </summary>
    public class PreviewImage_1 : UiNode<EditorManagerPanel, Godot.TextureRect, PreviewImage_1>
    {
        public PreviewImage_1(EditorManagerPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override PreviewImage_1 Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.Panel.ScrollContainer.Preview
    /// </summary>
    public class Preview : UiNode<EditorManagerPanel, Godot.Panel, Preview>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.Panel.ScrollContainer.Name
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
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.Panel.ScrollContainer.PreviewImage
        /// </summary>
        public PreviewImage_1 L_PreviewImage
        {
            get
            {
                if (_L_PreviewImage == null) _L_PreviewImage = new PreviewImage_1(UiPanel, Instance.GetNode<Godot.TextureRect>("PreviewImage"));
                return _L_PreviewImage;
            }
        }
        private PreviewImage_1 _L_PreviewImage;

        public Preview(EditorManagerPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override Preview Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.Panel.ScrollContainer
    /// </summary>
    public class ScrollContainer_3 : UiNode<EditorManagerPanel, Godot.ScrollContainer, ScrollContainer_3>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.Panel.Preview
        /// </summary>
        public Preview L_Preview
        {
            get
            {
                if (_L_Preview == null) _L_Preview = new Preview(UiPanel, Instance.GetNode<Godot.Panel>("Preview"));
                return _L_Preview;
            }
        }
        private Preview _L_Preview;

        public ScrollContainer_3(EditorManagerPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer_3 Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.Panel
    /// </summary>
    public class Panel_2 : UiNode<EditorManagerPanel, Godot.Panel, Panel_2>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.ScrollContainer
        /// </summary>
        public ScrollContainer_3 L_ScrollContainer
        {
            get
            {
                if (_L_ScrollContainer == null) _L_ScrollContainer = new ScrollContainer_3(UiPanel, Instance.GetNode<Godot.ScrollContainer>("ScrollContainer"));
                return _L_ScrollContainer;
            }
        }
        private ScrollContainer_3 _L_ScrollContainer;

        public Panel_2(EditorManagerPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override Panel_2 Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2
    /// </summary>
    public class HBoxContainer2_1 : UiNode<EditorManagerPanel, Godot.HBoxContainer, HBoxContainer2_1>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.VBoxContainer
        /// </summary>
        public VBoxContainer_3 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_3(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_3 _L_VBoxContainer;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.Panel
        /// </summary>
        public Panel_2 L_Panel
        {
            get
            {
                if (_L_Panel == null) _L_Panel = new Panel_2(UiPanel, Instance.GetNode<Godot.Panel>("Panel"));
                return _L_Panel;
            }
        }
        private Panel_2 _L_Panel;

        public HBoxContainer2_1(EditorManagerPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer2_1 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer
    /// </summary>
    public class MarginContainer_2 : UiNode<EditorManagerPanel, Godot.MarginContainer, MarginContainer_2>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.HBoxContainer2
        /// </summary>
        public HBoxContainer2_1 L_HBoxContainer2
        {
            get
            {
                if (_L_HBoxContainer2 == null) _L_HBoxContainer2 = new HBoxContainer2_1(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer2"));
                return _L_HBoxContainer2;
            }
        }
        private HBoxContainer2_1 _L_HBoxContainer2;

        public MarginContainer_2(EditorManagerPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer_2 Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel
    /// </summary>
    public class Panel_1 : UiNode<EditorManagerPanel, Godot.Panel, Panel_1>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.MarginContainer
        /// </summary>
        public MarginContainer_2 L_MarginContainer
        {
            get
            {
                if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer_2(UiPanel, Instance.GetNode<Godot.MarginContainer>("MarginContainer"));
                return _L_MarginContainer;
            }
        }
        private MarginContainer_2 _L_MarginContainer;

        public Panel_1(EditorManagerPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override Panel_1 Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject
    /// </summary>
    public class TileSetEditorProject : UiNode<EditorManagerPanel, UI.editor.TileSetEditorProject.TileSetEditorProjectPanel, TileSetEditorProject>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.Panel
        /// </summary>
        public Panel_1 L_Panel
        {
            get
            {
                if (_L_Panel == null) _L_Panel = new Panel_1(UiPanel, Instance.GetNode<Godot.Panel>("Panel"));
                return _L_Panel;
            }
        }
        private Panel_1 _L_Panel;

        public TileSetEditorProject(EditorManagerPanel uiPanel, UI.editor.TileSetEditorProject.TileSetEditorProjectPanel node) : base(uiPanel, node) {  }
        public override TileSetEditorProject Clone() => new (UiPanel, (UI.editor.TileSetEditorProject.TileSetEditorProjectPanel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet
    /// </summary>
    public class TileSet : UiNode<EditorManagerPanel, Godot.MarginContainer, TileSet>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSetEditorProject
        /// </summary>
        public TileSetEditorProject L_TileSetEditorProject
        {
            get
            {
                if (_L_TileSetEditorProject == null) _L_TileSetEditorProject = new TileSetEditorProject(UiPanel, Instance.GetNode<UI.editor.TileSetEditorProject.TileSetEditorProjectPanel>("TileSetEditorProject"));
                return _L_TileSetEditorProject;
            }
        }
        private TileSetEditorProject _L_TileSetEditorProject;

        public TileSet(EditorManagerPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override TileSet Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer.TabContainer
    /// </summary>
    public class TabContainer : UiNode<EditorManagerPanel, Godot.TabContainer, TabContainer>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.Map
        /// </summary>
        public Map L_Map
        {
            get
            {
                if (_L_Map == null) _L_Map = new Map(UiPanel, Instance.GetNode<Godot.MarginContainer>("Map"));
                return _L_Map;
            }
        }
        private Map _L_Map;

        /// <summary>
        /// 节点路径: EditorManager.Bg.VBoxContainer.TileSet
        /// </summary>
        public TileSet L_TileSet
        {
            get
            {
                if (_L_TileSet == null) _L_TileSet = new TileSet(UiPanel, Instance.GetNode<Godot.MarginContainer>("TileSet"));
                return _L_TileSet;
            }
        }
        private TileSet _L_TileSet;

        public TabContainer(EditorManagerPanel uiPanel, Godot.TabContainer node) : base(uiPanel, node) {  }
        public override TabContainer Clone() => new (UiPanel, (Godot.TabContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<EditorManagerPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 节点路径: EditorManager.Bg.Head
        /// </summary>
        public Head L_Head
        {
            get
            {
                if (_L_Head == null) _L_Head = new Head(UiPanel, Instance.GetNode<Godot.Panel>("Head"));
                return _L_Head;
            }
        }
        private Head _L_Head;

        /// <summary>
        /// 节点路径: EditorManager.Bg.TabContainer
        /// </summary>
        public TabContainer L_TabContainer
        {
            get
            {
                if (_L_TabContainer == null) _L_TabContainer = new TabContainer(UiPanel, Instance.GetNode<Godot.TabContainer>("TabContainer"));
                return _L_TabContainer;
            }
        }
        private TabContainer _L_TabContainer;

        public VBoxContainer(EditorManagerPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: EditorManager.Bg
    /// </summary>
    public class Bg : UiNode<EditorManagerPanel, Godot.Panel, Bg>
    {
        /// <summary>
        /// 节点路径: EditorManager.VBoxContainer
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

        public Bg(EditorManagerPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override Bg Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.Head.Back
    /// </summary>
    public Back S_Back => L_Bg.L_VBoxContainer.L_Head.L_Back;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.Head.Title
    /// </summary>
    public Title S_Title => L_Bg.L_VBoxContainer.L_Head.L_Title;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.Head
    /// </summary>
    public Head S_Head => L_Bg.L_VBoxContainer.L_Head;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.HBoxContainer.GroupSearchInput
    /// </summary>
    public GroupSearchInput S_GroupSearchInput => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel.L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_GroupSearchInput;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.HBoxContainer.GroupSearchButton
    /// </summary>
    public GroupSearchButton S_GroupSearchButton => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel.L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_GroupSearchButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.HBoxContainer2.GroupAddButton
    /// </summary>
    public GroupAddButton S_GroupAddButton => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel.L_MarginContainer.L_VBoxContainer.L_HBoxContainer2.L_GroupAddButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.HBoxContainer2.GroupEditButton
    /// </summary>
    public GroupEditButton S_GroupEditButton => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel.L_MarginContainer.L_VBoxContainer.L_HBoxContainer2.L_GroupEditButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.HBoxContainer2.GroupDeleteButton
    /// </summary>
    public GroupDeleteButton S_GroupDeleteButton => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel.L_MarginContainer.L_VBoxContainer.L_HBoxContainer2.L_GroupDeleteButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel.MarginContainer.VBoxContainer.ScrollContainer.GroupButton
    /// </summary>
    public GroupButton S_GroupButton => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_GroupButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.HBoxContainer.RoomSearchInput
    /// </summary>
    public RoomSearchInput S_RoomSearchInput => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel2.L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_RoomSearchInput;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.HBoxContainer.RoomTypeButton
    /// </summary>
    public RoomTypeButton S_RoomTypeButton => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel2.L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_RoomTypeButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.HBoxContainer.RoomSearchButton
    /// </summary>
    public RoomSearchButton S_RoomSearchButton => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel2.L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_RoomSearchButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.HBoxContainer.RoomAddButton
    /// </summary>
    public RoomAddButton S_RoomAddButton => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel2.L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_RoomAddButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.HBoxContainer.RoomEditButton
    /// </summary>
    public RoomEditButton S_RoomEditButton => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel2.L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_RoomEditButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.HBoxContainer.RoomDeleteButton
    /// </summary>
    public RoomDeleteButton S_RoomDeleteButton => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel2.L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_RoomDeleteButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.RoomButton.RoomName
    /// </summary>
    public RoomName S_RoomName => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel2.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_RoomButton.L_RoomName;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.RoomButton.RoomType
    /// </summary>
    public RoomType S_RoomType => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel2.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_RoomButton.L_RoomType;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.RoomButton.ErrorTexture
    /// </summary>
    public ErrorTexture S_ErrorTexture => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel2.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_RoomButton.L_ErrorTexture;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2.MarginContainer.VBoxContainer.ScrollContainer.RoomButton
    /// </summary>
    public RoomButton S_RoomButton => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel2.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_RoomButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject.HBoxContainer.Panel2
    /// </summary>
    public Panel2 S_Panel2 => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject.L_HBoxContainer.L_Panel2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map.MapEditorProject
    /// </summary>
    public MapEditorProject S_MapEditorProject => L_Bg.L_VBoxContainer.L_TabContainer.L_Map.L_MapEditorProject;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.Map
    /// </summary>
    public Map S_Map => L_Bg.L_VBoxContainer.L_TabContainer.L_Map;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.HBoxContainer.TileSearchInput
    /// </summary>
    public TileSearchInput S_TileSearchInput => L_Bg.L_VBoxContainer.L_TabContainer.L_TileSet.L_TileSetEditorProject.L_Panel.L_MarginContainer.L_HBoxContainer2.L_VBoxContainer.L_HBoxContainer.L_TileSearchInput;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.HBoxContainer.TileSearchButton
    /// </summary>
    public TileSearchButton S_TileSearchButton => L_Bg.L_VBoxContainer.L_TabContainer.L_TileSet.L_TileSetEditorProject.L_Panel.L_MarginContainer.L_HBoxContainer2.L_VBoxContainer.L_HBoxContainer.L_TileSearchButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.HBoxContainer.TileAddButton
    /// </summary>
    public TileAddButton S_TileAddButton => L_Bg.L_VBoxContainer.L_TabContainer.L_TileSet.L_TileSetEditorProject.L_Panel.L_MarginContainer.L_HBoxContainer2.L_VBoxContainer.L_HBoxContainer.L_TileAddButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.HBoxContainer.TileEditButton
    /// </summary>
    public TileEditButton S_TileEditButton => L_Bg.L_VBoxContainer.L_TabContainer.L_TileSet.L_TileSetEditorProject.L_Panel.L_MarginContainer.L_HBoxContainer2.L_VBoxContainer.L_HBoxContainer.L_TileEditButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.HBoxContainer.TileDeleteButton
    /// </summary>
    public TileDeleteButton S_TileDeleteButton => L_Bg.L_VBoxContainer.L_TabContainer.L_TileSet.L_TileSetEditorProject.L_Panel.L_MarginContainer.L_HBoxContainer2.L_VBoxContainer.L_HBoxContainer.L_TileDeleteButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.ScrollContainer.TileButton.Icon
    /// </summary>
    public Icon S_Icon => L_Bg.L_VBoxContainer.L_TabContainer.L_TileSet.L_TileSetEditorProject.L_Panel.L_MarginContainer.L_HBoxContainer2.L_VBoxContainer.L_ScrollContainer.L_TileButton.L_Icon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.ScrollContainer.TileButton.TileName
    /// </summary>
    public TileName S_TileName => L_Bg.L_VBoxContainer.L_TabContainer.L_TileSet.L_TileSetEditorProject.L_Panel.L_MarginContainer.L_HBoxContainer2.L_VBoxContainer.L_ScrollContainer.L_TileButton.L_TileName;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.VBoxContainer.ScrollContainer.TileButton
    /// </summary>
    public TileButton S_TileButton => L_Bg.L_VBoxContainer.L_TabContainer.L_TileSet.L_TileSetEditorProject.L_Panel.L_MarginContainer.L_HBoxContainer2.L_VBoxContainer.L_ScrollContainer.L_TileButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.Panel.ScrollContainer.Preview.Name
    /// </summary>
    public Name S_Name => L_Bg.L_VBoxContainer.L_TabContainer.L_TileSet.L_TileSetEditorProject.L_Panel.L_MarginContainer.L_HBoxContainer2.L_Panel.L_ScrollContainer.L_Preview.L_Name;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject.Panel.MarginContainer.HBoxContainer2.Panel.ScrollContainer.Preview
    /// </summary>
    public Preview S_Preview => L_Bg.L_VBoxContainer.L_TabContainer.L_TileSet.L_TileSetEditorProject.L_Panel.L_MarginContainer.L_HBoxContainer2.L_Panel.L_ScrollContainer.L_Preview;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet.TileSetEditorProject
    /// </summary>
    public TileSetEditorProject S_TileSetEditorProject => L_Bg.L_VBoxContainer.L_TabContainer.L_TileSet.L_TileSetEditorProject;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer.TileSet
    /// </summary>
    public TileSet S_TileSet => L_Bg.L_VBoxContainer.L_TabContainer.L_TileSet;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg.VBoxContainer.TabContainer
    /// </summary>
    public TabContainer S_TabContainer => L_Bg.L_VBoxContainer.L_TabContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: EditorManager.Bg
    /// </summary>
    public Bg S_Bg => L_Bg;

}
