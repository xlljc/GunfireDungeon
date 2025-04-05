using DsUi;

namespace UI.editor.MapEditor;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class MapEditor : UiBase
{
    /// <summary>
    /// 节点路径: MapEditor.Bg
    /// </summary>
    public Bg L_Bg
    {
        get
        {
            if (_L_Bg == null) _L_Bg = new Bg((MapEditorPanel)this, GetNode<Godot.Panel>("Bg"));
            return _L_Bg;
        }
    }
    private Bg _L_Bg;


    public MapEditor() : base(nameof(MapEditor))
    {
    }

    public sealed override void OnInitNestedUi()
    {
        _ = L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_TileMap;
        _ = L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_MarkTemplate;
        _ = L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ObjectTemplate;
        _ = L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab1;
        _ = L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab2;
        _ = L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab3;

    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.Head.Back
    /// </summary>
    public class Back : UiNode<MapEditorPanel, Godot.Button, Back>
    {
        public Back(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Back Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.Head.Save
    /// </summary>
    public class Save : UiNode<MapEditorPanel, Godot.Button, Save>
    {
        public Save(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Save Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.Head.Title
    /// </summary>
    public class Title : UiNode<MapEditorPanel, Godot.Label, Title>
    {
        public Title(MapEditorPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Title Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.Head.Play
    /// </summary>
    public class Play : UiNode<MapEditorPanel, Godot.Button, Play>
    {
        public Play(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Play Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.Head.PlaySetting
    /// </summary>
    public class PlaySetting : UiNode<MapEditorPanel, Godot.Button, PlaySetting>
    {
        public PlaySetting(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override PlaySetting Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.Head
    /// </summary>
    public class Head : UiNode<MapEditorPanel, Godot.Panel, Head>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.Back
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
        /// 节点路径: MapEditor.Bg.VBoxContainer.Save
        /// </summary>
        public Save L_Save
        {
            get
            {
                if (_L_Save == null) _L_Save = new Save(UiPanel, Instance.GetNode<Godot.Button>("Save"));
                return _L_Save;
            }
        }
        private Save _L_Save;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.Title
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
        /// 节点路径: MapEditor.Bg.VBoxContainer.Play
        /// </summary>
        public Play L_Play
        {
            get
            {
                if (_L_Play == null) _L_Play = new Play(UiPanel, Instance.GetNode<Godot.Button>("Play"));
                return _L_Play;
            }
        }
        private Play _L_Play;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.PlaySetting
        /// </summary>
        public PlaySetting L_PlaySetting
        {
            get
            {
                if (_L_PlaySetting == null) _L_PlaySetting = new PlaySetting(UiPanel, Instance.GetNode<Godot.Button>("PlaySetting"));
                return _L_PlaySetting;
            }
        }
        private PlaySetting _L_PlaySetting;

        public Head(MapEditorPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override Head Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.HBoxContainer.Label
    /// </summary>
    public class Label : UiNode<MapEditorPanel, Godot.Label, Label>
    {
        public Label(MapEditorPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.HBoxContainer.CheckButton
    /// </summary>
    public class CheckButton : UiNode<MapEditorPanel, Godot.CheckButton, CheckButton>
    {
        public CheckButton(MapEditorPanel uiPanel, Godot.CheckButton node) : base(uiPanel, node) {  }
        public override CheckButton Clone() => new (UiPanel, (Godot.CheckButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer_1 : UiNode<MapEditorPanel, Godot.HBoxContainer, HBoxContainer_1>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.Label
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
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.CheckButton
        /// </summary>
        public CheckButton L_CheckButton
        {
            get
            {
                if (_L_CheckButton == null) _L_CheckButton = new CheckButton(UiPanel, Instance.GetNode<Godot.CheckButton>("CheckButton"));
                return _L_CheckButton;
            }
        }
        private CheckButton _L_CheckButton;

        public HBoxContainer_1(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer_1 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.ScrollContainer.LayerButton.SelectTexture
    /// </summary>
    public class SelectTexture : UiNode<MapEditorPanel, Godot.NinePatchRect, SelectTexture>
    {
        public SelectTexture(MapEditorPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override SelectTexture Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.ScrollContainer.LayerButton.VisibleButton
    /// </summary>
    public class VisibleButton : UiNode<MapEditorPanel, Godot.TextureButton, VisibleButton>
    {
        public VisibleButton(MapEditorPanel uiPanel, Godot.TextureButton node) : base(uiPanel, node) {  }
        public override VisibleButton Clone() => new (UiPanel, (Godot.TextureButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.ScrollContainer.LayerButton
    /// </summary>
    public class LayerButton : UiNode<MapEditorPanel, Godot.Button, LayerButton>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.ScrollContainer.SelectTexture
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

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.ScrollContainer.VisibleButton
        /// </summary>
        public VisibleButton L_VisibleButton
        {
            get
            {
                if (_L_VisibleButton == null) _L_VisibleButton = new VisibleButton(UiPanel, Instance.GetNode<Godot.TextureButton>("VisibleButton"));
                return _L_VisibleButton;
            }
        }
        private VisibleButton _L_VisibleButton;

        public LayerButton(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override LayerButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<MapEditorPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.LayerButton
        /// </summary>
        public LayerButton L_LayerButton
        {
            get
            {
                if (_L_LayerButton == null) _L_LayerButton = new LayerButton(UiPanel, Instance.GetNode<Godot.Button>("LayerButton"));
                return _L_LayerButton;
            }
        }
        private LayerButton _L_LayerButton;

        public ScrollContainer(MapEditorPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<MapEditorPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.HBoxContainer
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
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.ScrollContainer
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

        public VBoxContainer_1(MapEditorPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer
    /// </summary>
    public class MapEditorMapLayer : UiNode<MapEditorPanel, UI.editor.MapEditorMapLayer.MapEditorMapLayerPanel, MapEditorMapLayer>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.VBoxContainer
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

        public MapEditorMapLayer(MapEditorPanel uiPanel, UI.editor.MapEditorMapLayer.MapEditorMapLayerPanel node) : base(uiPanel, node) {  }
        public override MapEditorMapLayer Clone() => new (UiPanel, (UI.editor.MapEditorMapLayer.MapEditorMapLayerPanel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.HBoxContainer.SearchInput
    /// </summary>
    public class SearchInput : UiNode<MapEditorPanel, Godot.LineEdit, SearchInput>
    {
        public SearchInput(MapEditorPanel uiPanel, Godot.LineEdit node) : base(uiPanel, node) {  }
        public override SearchInput Clone() => new (UiPanel, (Godot.LineEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.HBoxContainer.SearchButton
    /// </summary>
    public class SearchButton : UiNode<MapEditorPanel, Godot.Button, SearchButton>
    {
        public SearchButton(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override SearchButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer_2 : UiNode<MapEditorPanel, Godot.HBoxContainer, HBoxContainer_2>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.SearchInput
        /// </summary>
        public SearchInput L_SearchInput
        {
            get
            {
                if (_L_SearchInput == null) _L_SearchInput = new SearchInput(UiPanel, Instance.GetNode<Godot.LineEdit>("SearchInput"));
                return _L_SearchInput;
            }
        }
        private SearchInput _L_SearchInput;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.SearchButton
        /// </summary>
        public SearchButton L_SearchButton
        {
            get
            {
                if (_L_SearchButton == null) _L_SearchButton = new SearchButton(UiPanel, Instance.GetNode<Godot.Button>("SearchButton"));
                return _L_SearchButton;
            }
        }
        private SearchButton _L_SearchButton;

        public HBoxContainer_2(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer_2 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.ScrollContainer.CellButton.PreviewImage
    /// </summary>
    public class PreviewImage : UiNode<MapEditorPanel, Godot.TextureRect, PreviewImage>
    {
        public PreviewImage(MapEditorPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override PreviewImage Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.ScrollContainer.CellButton.CellName
    /// </summary>
    public class CellName : UiNode<MapEditorPanel, Godot.Label, CellName>
    {
        public CellName(MapEditorPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override CellName Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.ScrollContainer.CellButton.SelectTexture
    /// </summary>
    public class SelectTexture_1 : UiNode<MapEditorPanel, Godot.NinePatchRect, SelectTexture_1>
    {
        public SelectTexture_1(MapEditorPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override SelectTexture_1 Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.ScrollContainer.CellButton
    /// </summary>
    public class CellButton : UiNode<MapEditorPanel, Godot.Button, CellButton>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.ScrollContainer.PreviewImage
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
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.ScrollContainer.CellName
        /// </summary>
        public CellName L_CellName
        {
            get
            {
                if (_L_CellName == null) _L_CellName = new CellName(UiPanel, Instance.GetNode<Godot.Label>("CellName"));
                return _L_CellName;
            }
        }
        private CellName _L_CellName;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.ScrollContainer.SelectTexture
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

        public CellButton(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CellButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.ScrollContainer
    /// </summary>
    public class ScrollContainer_1 : UiNode<MapEditorPanel, Godot.ScrollContainer, ScrollContainer_1>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer.CellButton
        /// </summary>
        public CellButton L_CellButton
        {
            get
            {
                if (_L_CellButton == null) _L_CellButton = new CellButton(UiPanel, Instance.GetNode<Godot.Button>("CellButton"));
                return _L_CellButton;
            }
        }
        private CellButton _L_CellButton;

        public ScrollContainer_1(MapEditorPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer_1 Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.VBoxContainer
    /// </summary>
    public class VBoxContainer_2 : UiNode<MapEditorPanel, Godot.VBoxContainer, VBoxContainer_2>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.HBoxContainer
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
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject.ScrollContainer
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

        public VBoxContainer_2(MapEditorPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_2 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject
    /// </summary>
    public class MapEditorConfigObject : UiNode<MapEditorPanel, UI.editor.MapEditorConfigObject.MapEditorConfigObjectPanel, MapEditorConfigObject>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.VBoxContainer
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

        public MapEditorConfigObject(MapEditorPanel uiPanel, UI.editor.MapEditorConfigObject.MapEditorConfigObjectPanel node) : base(uiPanel, node) {  }
        public override MapEditorConfigObject Clone() => new (UiPanel, (UI.editor.MapEditorConfigObject.MapEditorConfigObjectPanel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel
    /// </summary>
    public class LayerPanel : UiNode<MapEditorPanel, Godot.Panel, LayerPanel>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.MapEditorMapLayer
        /// </summary>
        public MapEditorMapLayer L_MapEditorMapLayer
        {
            get
            {
                if (_L_MapEditorMapLayer == null) _L_MapEditorMapLayer = new MapEditorMapLayer(UiPanel, Instance.GetNode<UI.editor.MapEditorMapLayer.MapEditorMapLayerPanel>("MapEditorMapLayer"));
                return _L_MapEditorMapLayer;
            }
        }
        private MapEditorMapLayer _L_MapEditorMapLayer;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.MapEditorConfigObject
        /// </summary>
        public MapEditorConfigObject L_MapEditorConfigObject
        {
            get
            {
                if (_L_MapEditorConfigObject == null) _L_MapEditorConfigObject = new MapEditorConfigObject(UiPanel, Instance.GetNode<UI.editor.MapEditorConfigObject.MapEditorConfigObjectPanel>("MapEditorConfigObject"));
                return _L_MapEditorConfigObject;
            }
        }
        private MapEditorConfigObject _L_MapEditorConfigObject;

        public LayerPanel(MapEditorPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override LayerPanel Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.TileMap.NavigationRegion
    /// </summary>
    public class NavigationRegion : UiNode<MapEditorPanel, Godot.NavigationRegion2D, NavigationRegion>
    {
        public NavigationRegion(MapEditorPanel uiPanel, Godot.NavigationRegion2D node) : base(uiPanel, node) {  }
        public override NavigationRegion Clone() => new (UiPanel, (Godot.NavigationRegion2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.TileMap.ErrorCell.ErrorCellAnimationPlayer
    /// </summary>
    public class ErrorCellAnimationPlayer : UiNode<MapEditorPanel, Godot.AnimationPlayer, ErrorCellAnimationPlayer>
    {
        public ErrorCellAnimationPlayer(MapEditorPanel uiPanel, Godot.AnimationPlayer node) : base(uiPanel, node) {  }
        public override ErrorCellAnimationPlayer Clone() => new (UiPanel, (Godot.AnimationPlayer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.TileMap.ErrorCell
    /// </summary>
    public class ErrorCell : UiNode<MapEditorPanel, Godot.Sprite2D, ErrorCell>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.TileMap.ErrorCellAnimationPlayer
        /// </summary>
        public ErrorCellAnimationPlayer L_ErrorCellAnimationPlayer
        {
            get
            {
                if (_L_ErrorCellAnimationPlayer == null) _L_ErrorCellAnimationPlayer = new ErrorCellAnimationPlayer(UiPanel, Instance.GetNode<Godot.AnimationPlayer>("ErrorCellAnimationPlayer"));
                return _L_ErrorCellAnimationPlayer;
            }
        }
        private ErrorCellAnimationPlayer _L_ErrorCellAnimationPlayer;

        public ErrorCell(MapEditorPanel uiPanel, Godot.Sprite2D node) : base(uiPanel, node) {  }
        public override ErrorCell Clone() => new (UiPanel, (Godot.Sprite2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.TileMap.Brush
    /// </summary>
    public class Brush : UiNode<MapEditorPanel, Godot.Node2D, Brush>
    {
        public Brush(MapEditorPanel uiPanel, Godot.Node2D node) : base(uiPanel, node) {  }
        public override Brush Clone() => new (UiPanel, (Godot.Node2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.TileMap
    /// </summary>
    public class TileMap : UiNode<MapEditorPanel, UI.editor.MapEditor.EditorTileMap, TileMap>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.NavigationRegion
        /// </summary>
        public NavigationRegion L_NavigationRegion
        {
            get
            {
                if (_L_NavigationRegion == null) _L_NavigationRegion = new NavigationRegion(UiPanel, Instance.GetNode<Godot.NavigationRegion2D>("NavigationRegion"));
                return _L_NavigationRegion;
            }
        }
        private NavigationRegion _L_NavigationRegion;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.ErrorCell
        /// </summary>
        public ErrorCell L_ErrorCell
        {
            get
            {
                if (_L_ErrorCell == null) _L_ErrorCell = new ErrorCell(UiPanel, Instance.GetNode<Godot.Sprite2D>("ErrorCell"));
                return _L_ErrorCell;
            }
        }
        private ErrorCell _L_ErrorCell;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.Brush
        /// </summary>
        public Brush L_Brush
        {
            get
            {
                if (_L_Brush == null) _L_Brush = new Brush(UiPanel, Instance.GetNode<Godot.Node2D>("Brush"));
                return _L_Brush;
            }
        }
        private Brush _L_Brush;

        public TileMap(MapEditorPanel uiPanel, UI.editor.MapEditor.EditorTileMap node) : base(uiPanel, node) {  }
        public override TileMap Clone() => new (UiPanel, (UI.editor.MapEditor.EditorTileMap)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.N_HoverRoot.N_HoverArea
    /// </summary>
    public class N_HoverArea : UiNode<MapEditorPanel, DoorHoverArea, N_HoverArea>
    {
        public N_HoverArea(MapEditorPanel uiPanel, DoorHoverArea node) : base(uiPanel, node) {  }
        public override N_HoverArea Clone() => new (UiPanel, (DoorHoverArea)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.N_HoverRoot
    /// </summary>
    public class N_HoverRoot : UiNode<MapEditorPanel, Godot.Control, N_HoverRoot>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.N_HoverArea
        /// </summary>
        public N_HoverArea L_N_HoverArea
        {
            get
            {
                if (_L_N_HoverArea == null) _L_N_HoverArea = new N_HoverArea(UiPanel, Instance.GetNode<DoorHoverArea>("N_HoverArea"));
                return _L_N_HoverArea;
            }
        }
        private N_HoverArea _L_N_HoverArea;

        public N_HoverRoot(MapEditorPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override N_HoverRoot Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.E_HoverRoot.E_HoverArea
    /// </summary>
    public class E_HoverArea : UiNode<MapEditorPanel, DoorHoverArea, E_HoverArea>
    {
        public E_HoverArea(MapEditorPanel uiPanel, DoorHoverArea node) : base(uiPanel, node) {  }
        public override E_HoverArea Clone() => new (UiPanel, (DoorHoverArea)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.E_HoverRoot
    /// </summary>
    public class E_HoverRoot : UiNode<MapEditorPanel, Godot.Control, E_HoverRoot>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.E_HoverArea
        /// </summary>
        public E_HoverArea L_E_HoverArea
        {
            get
            {
                if (_L_E_HoverArea == null) _L_E_HoverArea = new E_HoverArea(UiPanel, Instance.GetNode<DoorHoverArea>("E_HoverArea"));
                return _L_E_HoverArea;
            }
        }
        private E_HoverArea _L_E_HoverArea;

        public E_HoverRoot(MapEditorPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override E_HoverRoot Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.S_HoverRoot.S_HoverArea
    /// </summary>
    public class S_HoverArea : UiNode<MapEditorPanel, DoorHoverArea, S_HoverArea>
    {
        public S_HoverArea(MapEditorPanel uiPanel, DoorHoverArea node) : base(uiPanel, node) {  }
        public override S_HoverArea Clone() => new (UiPanel, (DoorHoverArea)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.S_HoverRoot
    /// </summary>
    public class S_HoverRoot : UiNode<MapEditorPanel, Godot.Control, S_HoverRoot>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.S_HoverArea
        /// </summary>
        public S_HoverArea L_S_HoverArea
        {
            get
            {
                if (_L_S_HoverArea == null) _L_S_HoverArea = new S_HoverArea(UiPanel, Instance.GetNode<DoorHoverArea>("S_HoverArea"));
                return _L_S_HoverArea;
            }
        }
        private S_HoverArea _L_S_HoverArea;

        public S_HoverRoot(MapEditorPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override S_HoverRoot Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.W_HoverRoot.W_HoverArea
    /// </summary>
    public class W_HoverArea : UiNode<MapEditorPanel, DoorHoverArea, W_HoverArea>
    {
        public W_HoverArea(MapEditorPanel uiPanel, DoorHoverArea node) : base(uiPanel, node) {  }
        public override W_HoverArea Clone() => new (UiPanel, (DoorHoverArea)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.W_HoverRoot
    /// </summary>
    public class W_HoverRoot : UiNode<MapEditorPanel, Godot.Control, W_HoverRoot>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.W_HoverArea
        /// </summary>
        public W_HoverArea L_W_HoverArea
        {
            get
            {
                if (_L_W_HoverArea == null) _L_W_HoverArea = new W_HoverArea(UiPanel, Instance.GetNode<DoorHoverArea>("W_HoverArea"));
                return _L_W_HoverArea;
            }
        }
        private W_HoverArea _L_W_HoverArea;

        public W_HoverRoot(MapEditorPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override W_HoverRoot Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.HoverPreviewRoot.HoverPreview
    /// </summary>
    public class HoverPreview : UiNode<MapEditorPanel, Godot.TextureRect, HoverPreview>
    {
        public HoverPreview(MapEditorPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override HoverPreview Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.HoverPreviewRoot
    /// </summary>
    public class HoverPreviewRoot : UiNode<MapEditorPanel, Godot.Control, HoverPreviewRoot>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.HoverPreview
        /// </summary>
        public HoverPreview L_HoverPreview
        {
            get
            {
                if (_L_HoverPreview == null) _L_HoverPreview = new HoverPreview(UiPanel, Instance.GetNode<Godot.TextureRect>("HoverPreview"));
                return _L_HoverPreview;
            }
        }
        private HoverPreview _L_HoverPreview;

        public HoverPreviewRoot(MapEditorPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override HoverPreviewRoot Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.DoorToolTemplate.DoorArea
    /// </summary>
    public class DoorArea : UiNode<MapEditorPanel, Godot.ColorRect, DoorArea>
    {
        public DoorArea(MapEditorPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override DoorArea Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.DoorToolTemplate.StartBtn
    /// </summary>
    public class StartBtn : UiNode<MapEditorPanel, UI.editor.MapEditorTools.DoorDragButton, StartBtn>
    {
        public StartBtn(MapEditorPanel uiPanel, UI.editor.MapEditorTools.DoorDragButton node) : base(uiPanel, node) {  }
        public override StartBtn Clone() => new (UiPanel, (UI.editor.MapEditorTools.DoorDragButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.DoorToolTemplate.EndBtn
    /// </summary>
    public class EndBtn : UiNode<MapEditorPanel, UI.editor.MapEditorTools.DoorDragButton, EndBtn>
    {
        public EndBtn(MapEditorPanel uiPanel, UI.editor.MapEditorTools.DoorDragButton node) : base(uiPanel, node) {  }
        public override EndBtn Clone() => new (UiPanel, (UI.editor.MapEditorTools.DoorDragButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.DoorToolTemplate
    /// </summary>
    public class DoorToolTemplate : UiNode<MapEditorPanel, UI.editor.MapEditorTools.DoorDragArea, DoorToolTemplate>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.DoorArea
        /// </summary>
        public DoorArea L_DoorArea
        {
            get
            {
                if (_L_DoorArea == null) _L_DoorArea = new DoorArea(UiPanel, Instance.GetNode<Godot.ColorRect>("DoorArea"));
                return _L_DoorArea;
            }
        }
        private DoorArea _L_DoorArea;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.StartBtn
        /// </summary>
        public StartBtn L_StartBtn
        {
            get
            {
                if (_L_StartBtn == null) _L_StartBtn = new StartBtn(UiPanel, Instance.GetNode<UI.editor.MapEditorTools.DoorDragButton>("StartBtn"));
                return _L_StartBtn;
            }
        }
        private StartBtn _L_StartBtn;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.EndBtn
        /// </summary>
        public EndBtn L_EndBtn
        {
            get
            {
                if (_L_EndBtn == null) _L_EndBtn = new EndBtn(UiPanel, Instance.GetNode<UI.editor.MapEditorTools.DoorDragButton>("EndBtn"));
                return _L_EndBtn;
            }
        }
        private EndBtn _L_EndBtn;

        public DoorToolTemplate(MapEditorPanel uiPanel, UI.editor.MapEditorTools.DoorDragArea node) : base(uiPanel, node) {  }
        public override DoorToolTemplate Clone() => new (UiPanel, (UI.editor.MapEditorTools.DoorDragArea)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.MarkTemplate
    /// </summary>
    public class MarkTemplate : UiNode<MapEditorPanel, UI.editor.MapEditorTools.MarkTool, MarkTemplate>
    {
        public MarkTemplate(MapEditorPanel uiPanel, UI.editor.MapEditorTools.MarkTool node) : base(uiPanel, node) {  }
        public override MarkTemplate Clone() => new (UiPanel, (UI.editor.MapEditorTools.MarkTool)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot
    /// </summary>
    public class ToolRoot : UiNode<MapEditorPanel, Godot.Control, ToolRoot>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.N_HoverRoot
        /// </summary>
        public N_HoverRoot L_N_HoverRoot
        {
            get
            {
                if (_L_N_HoverRoot == null) _L_N_HoverRoot = new N_HoverRoot(UiPanel, Instance.GetNode<Godot.Control>("N_HoverRoot"));
                return _L_N_HoverRoot;
            }
        }
        private N_HoverRoot _L_N_HoverRoot;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.E_HoverRoot
        /// </summary>
        public E_HoverRoot L_E_HoverRoot
        {
            get
            {
                if (_L_E_HoverRoot == null) _L_E_HoverRoot = new E_HoverRoot(UiPanel, Instance.GetNode<Godot.Control>("E_HoverRoot"));
                return _L_E_HoverRoot;
            }
        }
        private E_HoverRoot _L_E_HoverRoot;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.S_HoverRoot
        /// </summary>
        public S_HoverRoot L_S_HoverRoot
        {
            get
            {
                if (_L_S_HoverRoot == null) _L_S_HoverRoot = new S_HoverRoot(UiPanel, Instance.GetNode<Godot.Control>("S_HoverRoot"));
                return _L_S_HoverRoot;
            }
        }
        private S_HoverRoot _L_S_HoverRoot;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.W_HoverRoot
        /// </summary>
        public W_HoverRoot L_W_HoverRoot
        {
            get
            {
                if (_L_W_HoverRoot == null) _L_W_HoverRoot = new W_HoverRoot(UiPanel, Instance.GetNode<Godot.Control>("W_HoverRoot"));
                return _L_W_HoverRoot;
            }
        }
        private W_HoverRoot _L_W_HoverRoot;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.HoverPreviewRoot
        /// </summary>
        public HoverPreviewRoot L_HoverPreviewRoot
        {
            get
            {
                if (_L_HoverPreviewRoot == null) _L_HoverPreviewRoot = new HoverPreviewRoot(UiPanel, Instance.GetNode<Godot.Control>("HoverPreviewRoot"));
                return _L_HoverPreviewRoot;
            }
        }
        private HoverPreviewRoot _L_HoverPreviewRoot;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.DoorToolTemplate
        /// </summary>
        public DoorToolTemplate L_DoorToolTemplate
        {
            get
            {
                if (_L_DoorToolTemplate == null) _L_DoorToolTemplate = new DoorToolTemplate(UiPanel, Instance.GetNode<UI.editor.MapEditorTools.DoorDragArea>("DoorToolTemplate"));
                return _L_DoorToolTemplate;
            }
        }
        private DoorToolTemplate _L_DoorToolTemplate;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.MarkTemplate
        /// </summary>
        public MarkTemplate L_MarkTemplate
        {
            get
            {
                if (_L_MarkTemplate == null) _L_MarkTemplate = new MarkTemplate(UiPanel, Instance.GetNode<UI.editor.MapEditorTools.MarkTool>("MarkTemplate"));
                return _L_MarkTemplate;
            }
        }
        private MarkTemplate _L_MarkTemplate;

        public ToolRoot(MapEditorPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override ToolRoot Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ObjectTemplate.CollisionShape2D
    /// </summary>
    public class CollisionShape2D : UiNode<MapEditorPanel, Godot.CollisionShape2D, CollisionShape2D>
    {
        public CollisionShape2D(MapEditorPanel uiPanel, Godot.CollisionShape2D node) : base(uiPanel, node) {  }
        public override CollisionShape2D Clone() => new (UiPanel, (Godot.CollisionShape2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ObjectTemplate.Bar
    /// </summary>
    public class Bar : UiNode<MapEditorPanel, Godot.Node2D, Bar>
    {
        public Bar(MapEditorPanel uiPanel, Godot.Node2D node) : base(uiPanel, node) {  }
        public override Bar Clone() => new (UiPanel, (Godot.Node2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ObjectTemplate.RectBrush
    /// </summary>
    public class RectBrush : UiNode<MapEditorPanel, Godot.Node2D, RectBrush>
    {
        public RectBrush(MapEditorPanel uiPanel, Godot.Node2D node) : base(uiPanel, node) {  }
        public override RectBrush Clone() => new (UiPanel, (Godot.Node2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ObjectTemplate
    /// </summary>
    public class ObjectTemplate : UiNode<MapEditorPanel, UI.editor.MapEditorTools.CustomObject, ObjectTemplate>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.CollisionShape2D
        /// </summary>
        public CollisionShape2D L_CollisionShape2D
        {
            get
            {
                if (_L_CollisionShape2D == null) _L_CollisionShape2D = new CollisionShape2D(UiPanel, Instance.GetNode<Godot.CollisionShape2D>("CollisionShape2D"));
                return _L_CollisionShape2D;
            }
        }
        private CollisionShape2D _L_CollisionShape2D;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.Bar
        /// </summary>
        public Bar L_Bar
        {
            get
            {
                if (_L_Bar == null) _L_Bar = new Bar(UiPanel, Instance.GetNode<Godot.Node2D>("Bar"));
                return _L_Bar;
            }
        }
        private Bar _L_Bar;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.RectBrush
        /// </summary>
        public RectBrush L_RectBrush
        {
            get
            {
                if (_L_RectBrush == null) _L_RectBrush = new RectBrush(UiPanel, Instance.GetNode<Godot.Node2D>("RectBrush"));
                return _L_RectBrush;
            }
        }
        private RectBrush _L_RectBrush;

        public ObjectTemplate(MapEditorPanel uiPanel, UI.editor.MapEditorTools.CustomObject node) : base(uiPanel, node) {  }
        public override ObjectTemplate Clone() => new (UiPanel, (UI.editor.MapEditorTools.CustomObject)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.HBoxContainer.ToolButton.Select
    /// </summary>
    public class Select : UiNode<MapEditorPanel, Godot.NinePatchRect, Select>
    {
        public Select(MapEditorPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override Select Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.HBoxContainer.ToolButton
    /// </summary>
    public class ToolButton : UiNode<MapEditorPanel, Godot.TextureButton, ToolButton>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.HBoxContainer.Select
        /// </summary>
        public Select L_Select
        {
            get
            {
                if (_L_Select == null) _L_Select = new Select(UiPanel, Instance.GetNode<Godot.NinePatchRect>("Select"));
                return _L_Select;
            }
        }
        private Select _L_Select;

        public ToolButton(MapEditorPanel uiPanel, Godot.TextureButton node) : base(uiPanel, node) {  }
        public override ToolButton Clone() => new (UiPanel, (Godot.TextureButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.HBoxContainer
    /// </summary>
    public class HBoxContainer_3 : UiNode<MapEditorPanel, Godot.HBoxContainer, HBoxContainer_3>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolButton
        /// </summary>
        public ToolButton L_ToolButton
        {
            get
            {
                if (_L_ToolButton == null) _L_ToolButton = new ToolButton(UiPanel, Instance.GetNode<Godot.TextureButton>("ToolButton"));
                return _L_ToolButton;
            }
        }
        private ToolButton _L_ToolButton;

        public HBoxContainer_3(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer_3 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools
    /// </summary>
    public class MapEditorTools : UiNode<MapEditorPanel, UI.editor.MapEditorTools.MapEditorToolsPanel, MapEditorTools>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.ToolRoot
        /// </summary>
        public ToolRoot L_ToolRoot
        {
            get
            {
                if (_L_ToolRoot == null) _L_ToolRoot = new ToolRoot(UiPanel, Instance.GetNode<Godot.Control>("ToolRoot"));
                return _L_ToolRoot;
            }
        }
        private ToolRoot _L_ToolRoot;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.ObjectTemplate
        /// </summary>
        public ObjectTemplate L_ObjectTemplate
        {
            get
            {
                if (_L_ObjectTemplate == null) _L_ObjectTemplate = new ObjectTemplate(UiPanel, Instance.GetNode<UI.editor.MapEditorTools.CustomObject>("ObjectTemplate"));
                return _L_ObjectTemplate;
            }
        }
        private ObjectTemplate _L_ObjectTemplate;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.HBoxContainer
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

        public MapEditorTools(MapEditorPanel uiPanel, UI.editor.MapEditorTools.MapEditorToolsPanel node) : base(uiPanel, node) {  }
        public override MapEditorTools Clone() => new (UiPanel, (UI.editor.MapEditorTools.MapEditorToolsPanel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer
    /// </summary>
    public class CanvasLayer : UiNode<MapEditorPanel, Godot.CanvasLayer, CanvasLayer>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.MapEditorTools
        /// </summary>
        public MapEditorTools L_MapEditorTools
        {
            get
            {
                if (_L_MapEditorTools == null) _L_MapEditorTools = new MapEditorTools(UiPanel, Instance.GetNode<UI.editor.MapEditorTools.MapEditorToolsPanel>("MapEditorTools"));
                return _L_MapEditorTools;
            }
        }
        private MapEditorTools _L_MapEditorTools;

        public CanvasLayer(MapEditorPanel uiPanel, Godot.CanvasLayer node) : base(uiPanel, node) {  }
        public override CanvasLayer Clone() => new (UiPanel, (Godot.CanvasLayer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport
    /// </summary>
    public class SubViewport : UiNode<MapEditorPanel, Godot.SubViewport, SubViewport>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.TileMap
        /// </summary>
        public TileMap L_TileMap
        {
            get
            {
                if (_L_TileMap == null) _L_TileMap = new TileMap(UiPanel, Instance.GetNode<UI.editor.MapEditor.EditorTileMap>("TileMap"));
                return _L_TileMap;
            }
        }
        private TileMap _L_TileMap;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.CanvasLayer
        /// </summary>
        public CanvasLayer L_CanvasLayer
        {
            get
            {
                if (_L_CanvasLayer == null) _L_CanvasLayer = new CanvasLayer(UiPanel, Instance.GetNode<Godot.CanvasLayer>("CanvasLayer"));
                return _L_CanvasLayer;
            }
        }
        private CanvasLayer _L_CanvasLayer;

        public SubViewport(MapEditorPanel uiPanel, Godot.SubViewport node) : base(uiPanel, node) {  }
        public override SubViewport Clone() => new (UiPanel, (Godot.SubViewport)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView
    /// </summary>
    public class MapView : UiNode<MapEditorPanel, Godot.SubViewportContainer, MapView>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.SubViewport
        /// </summary>
        public SubViewport L_SubViewport
        {
            get
            {
                if (_L_SubViewport == null) _L_SubViewport = new SubViewport(UiPanel, Instance.GetNode<Godot.SubViewport>("SubViewport"));
                return _L_SubViewport;
            }
        }
        private SubViewport _L_SubViewport;

        public MapView(MapEditorPanel uiPanel, Godot.SubViewportContainer node) : base(uiPanel, node) {  }
        public override MapView Clone() => new (UiPanel, (Godot.SubViewportContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView2
    /// </summary>
    public class MapView2 : UiNode<MapEditorPanel, Godot.TextureRect, MapView2>
    {
        public MapView2(MapEditorPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override MapView2 Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<MapEditorPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MapView
        /// </summary>
        public MapView L_MapView
        {
            get
            {
                if (_L_MapView == null) _L_MapView = new MapView(UiPanel, Instance.GetNode<Godot.SubViewportContainer>("MapView"));
                return _L_MapView;
            }
        }
        private MapView _L_MapView;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MapView2
        /// </summary>
        public MapView2 L_MapView2
        {
            get
            {
                if (_L_MapView2 == null) _L_MapView2 = new MapView2(UiPanel, Instance.GetNode<Godot.TextureRect>("MapView2"));
                return _L_MapView2;
            }
        }
        private MapView2 _L_MapView2;

        public MarginContainer(MapEditorPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left
    /// </summary>
    public class Left : UiNode<MapEditorPanel, Godot.Panel, Left>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.MarginContainer
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

        public Left(MapEditorPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override Left Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<MapEditorPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.LayerPanel
        /// </summary>
        public LayerPanel L_LayerPanel
        {
            get
            {
                if (_L_LayerPanel == null) _L_LayerPanel = new LayerPanel(UiPanel, Instance.GetNode<Godot.Panel>("LayerPanel"));
                return _L_LayerPanel;
            }
        }
        private LayerPanel _L_LayerPanel;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Left
        /// </summary>
        public Left L_Left
        {
            get
            {
                if (_L_Left == null) _L_Left = new Left(UiPanel, Instance.GetNode<Godot.Panel>("Left"));
                return _L_Left;
            }
        }
        private Left _L_Left;

        public HBoxContainer(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.HBoxContainer.Label
    /// </summary>
    public class Label_1 : UiNode<MapEditorPanel, Godot.Label, Label_1>
    {
        public Label_1(MapEditorPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.HBoxContainer.SourceOption
    /// </summary>
    public class SourceOption : UiNode<MapEditorPanel, Godot.OptionButton, SourceOption>
    {
        public SourceOption(MapEditorPanel uiPanel, Godot.OptionButton node) : base(uiPanel, node) {  }
        public override SourceOption Clone() => new (UiPanel, (Godot.OptionButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer_4 : UiNode<MapEditorPanel, Godot.HBoxContainer, HBoxContainer_4>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Label
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
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.SourceOption
        /// </summary>
        public SourceOption L_SourceOption
        {
            get
            {
                if (_L_SourceOption == null) _L_SourceOption = new SourceOption(UiPanel, Instance.GetNode<Godot.OptionButton>("SourceOption"));
                return _L_SourceOption;
            }
        }
        private SourceOption _L_SourceOption;

        public HBoxContainer_4(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer_4 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.HBoxContainer2.Label
    /// </summary>
    public class Label_2 : UiNode<MapEditorPanel, Godot.Label, Label_2>
    {
        public Label_2(MapEditorPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_2 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.HBoxContainer2.HandleOption
    /// </summary>
    public class HandleOption : UiNode<MapEditorPanel, Godot.OptionButton, HandleOption>
    {
        public HandleOption(MapEditorPanel uiPanel, Godot.OptionButton node) : base(uiPanel, node) {  }
        public override HandleOption Clone() => new (UiPanel, (Godot.OptionButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.HBoxContainer2
    /// </summary>
    public class HBoxContainer2 : UiNode<MapEditorPanel, Godot.HBoxContainer, HBoxContainer2>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Label
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
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.HandleOption
        /// </summary>
        public HandleOption L_HandleOption
        {
            get
            {
                if (_L_HandleOption == null) _L_HandleOption = new HandleOption(UiPanel, Instance.GetNode<Godot.OptionButton>("HandleOption"));
                return _L_HandleOption;
            }
        }
        private HandleOption _L_HandleOption;

        public HBoxContainer2(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer2 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab1.TabRoot.TileSprite
    /// </summary>
    public class TileSprite : UiNode<MapEditorPanel, Godot.Sprite2D, TileSprite>
    {
        public TileSprite(MapEditorPanel uiPanel, Godot.Sprite2D node) : base(uiPanel, node) {  }
        public override TileSprite Clone() => new (UiPanel, (Godot.Sprite2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab1.TabRoot.Brush
    /// </summary>
    public class Brush_1 : UiNode<MapEditorPanel, Godot.Control, Brush_1>
    {
        public Brush_1(MapEditorPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Brush_1 Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab1.TabRoot
    /// </summary>
    public class TabRoot : UiNode<MapEditorPanel, Godot.Control, TabRoot>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab1.TileSprite
        /// </summary>
        public TileSprite L_TileSprite
        {
            get
            {
                if (_L_TileSprite == null) _L_TileSprite = new TileSprite(UiPanel, Instance.GetNode<Godot.Sprite2D>("TileSprite"));
                return _L_TileSprite;
            }
        }
        private TileSprite _L_TileSprite;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab1.Brush
        /// </summary>
        public Brush_1 L_Brush
        {
            get
            {
                if (_L_Brush == null) _L_Brush = new Brush_1(UiPanel, Instance.GetNode<Godot.Control>("Brush"));
                return _L_Brush;
            }
        }
        private Brush_1 _L_Brush;

        public TabRoot(MapEditorPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override TabRoot Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab1.Grid
    /// </summary>
    public class Grid : UiNode<MapEditorPanel, Godot.ColorRect, Grid>
    {
        public Grid(MapEditorPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override Grid Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab1.FocusBtn
    /// </summary>
    public class FocusBtn : UiNode<MapEditorPanel, Godot.TextureButton, FocusBtn>
    {
        public FocusBtn(MapEditorPanel uiPanel, Godot.TextureButton node) : base(uiPanel, node) {  }
        public override FocusBtn Clone() => new (UiPanel, (Godot.TextureButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab1
    /// </summary>
    public class Tab1 : UiNode<MapEditorPanel, UI.editor.MapEditorMapTile.FreeTileTab, Tab1>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.TabRoot
        /// </summary>
        public TabRoot L_TabRoot
        {
            get
            {
                if (_L_TabRoot == null) _L_TabRoot = new TabRoot(UiPanel, Instance.GetNode<Godot.Control>("TabRoot"));
                return _L_TabRoot;
            }
        }
        private TabRoot _L_TabRoot;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Grid
        /// </summary>
        public Grid L_Grid
        {
            get
            {
                if (_L_Grid == null) _L_Grid = new Grid(UiPanel, Instance.GetNode<Godot.ColorRect>("Grid"));
                return _L_Grid;
            }
        }
        private Grid _L_Grid;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.FocusBtn
        /// </summary>
        public FocusBtn L_FocusBtn
        {
            get
            {
                if (_L_FocusBtn == null) _L_FocusBtn = new FocusBtn(UiPanel, Instance.GetNode<Godot.TextureButton>("FocusBtn"));
                return _L_FocusBtn;
            }
        }
        private FocusBtn _L_FocusBtn;

        public Tab1(MapEditorPanel uiPanel, UI.editor.MapEditorMapTile.FreeTileTab node) : base(uiPanel, node) {  }
        public override Tab1 Clone() => new (UiPanel, (UI.editor.MapEditorMapTile.FreeTileTab)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer.TerrainItem.Select
    /// </summary>
    public class Select_1 : UiNode<MapEditorPanel, Godot.NinePatchRect, Select_1>
    {
        public Select_1(MapEditorPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override Select_1 Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer.TerrainItem.TerrainName
    /// </summary>
    public class TerrainName : UiNode<MapEditorPanel, Godot.Label, TerrainName>
    {
        public TerrainName(MapEditorPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override TerrainName Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer.TerrainItem.ErrorIcon
    /// </summary>
    public class ErrorIcon : UiNode<MapEditorPanel, Godot.TextureRect, ErrorIcon>
    {
        public ErrorIcon(MapEditorPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override ErrorIcon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer.TerrainItem.TerrainPreview
    /// </summary>
    public class TerrainPreview : UiNode<MapEditorPanel, Godot.TextureRect, TerrainPreview>
    {
        public TerrainPreview(MapEditorPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override TerrainPreview Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer.TerrainItem
    /// </summary>
    public class TerrainItem : UiNode<MapEditorPanel, Godot.Button, TerrainItem>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer.Select
        /// </summary>
        public Select_1 L_Select
        {
            get
            {
                if (_L_Select == null) _L_Select = new Select_1(UiPanel, Instance.GetNode<Godot.NinePatchRect>("Select"));
                return _L_Select;
            }
        }
        private Select_1 _L_Select;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer.TerrainName
        /// </summary>
        public TerrainName L_TerrainName
        {
            get
            {
                if (_L_TerrainName == null) _L_TerrainName = new TerrainName(UiPanel, Instance.GetNode<Godot.Label>("TerrainName"));
                return _L_TerrainName;
            }
        }
        private TerrainName _L_TerrainName;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer.ErrorIcon
        /// </summary>
        public ErrorIcon L_ErrorIcon
        {
            get
            {
                if (_L_ErrorIcon == null) _L_ErrorIcon = new ErrorIcon(UiPanel, Instance.GetNode<Godot.TextureRect>("ErrorIcon"));
                return _L_ErrorIcon;
            }
        }
        private ErrorIcon _L_ErrorIcon;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer.TerrainPreview
        /// </summary>
        public TerrainPreview L_TerrainPreview
        {
            get
            {
                if (_L_TerrainPreview == null) _L_TerrainPreview = new TerrainPreview(UiPanel, Instance.GetNode<Godot.TextureRect>("TerrainPreview"));
                return _L_TerrainPreview;
            }
        }
        private TerrainPreview _L_TerrainPreview;

        public TerrainItem(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override TerrainItem Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer
    /// </summary>
    public class ScrollContainer_2 : UiNode<MapEditorPanel, Godot.ScrollContainer, ScrollContainer_2>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.TerrainItem
        /// </summary>
        public TerrainItem L_TerrainItem
        {
            get
            {
                if (_L_TerrainItem == null) _L_TerrainItem = new TerrainItem(UiPanel, Instance.GetNode<Godot.Button>("TerrainItem"));
                return _L_TerrainItem;
            }
        }
        private TerrainItem _L_TerrainItem;

        public ScrollContainer_2(MapEditorPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer_2 Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2
    /// </summary>
    public class Tab2 : UiNode<MapEditorPanel, UI.editor.MapEditorMapTile.TerrainTileTab, Tab2>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.ScrollContainer
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

        public Tab2(MapEditorPanel uiPanel, UI.editor.MapEditorMapTile.TerrainTileTab node) : base(uiPanel, node) {  }
        public override Tab2 Clone() => new (UiPanel, (UI.editor.MapEditorMapTile.TerrainTileTab)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab3.ScrollContainer.CellButton.PreviewImage
    /// </summary>
    public class PreviewImage_1 : UiNode<MapEditorPanel, Godot.TextureRect, PreviewImage_1>
    {
        public PreviewImage_1(MapEditorPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override PreviewImage_1 Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab3.ScrollContainer.CellButton.CellName
    /// </summary>
    public class CellName_1 : UiNode<MapEditorPanel, Godot.Label, CellName_1>
    {
        public CellName_1(MapEditorPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override CellName_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab3.ScrollContainer.CellButton.SelectTexture
    /// </summary>
    public class SelectTexture_2 : UiNode<MapEditorPanel, Godot.NinePatchRect, SelectTexture_2>
    {
        public SelectTexture_2(MapEditorPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override SelectTexture_2 Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab3.ScrollContainer.CellButton
    /// </summary>
    public class CellButton_1 : UiNode<MapEditorPanel, Godot.Button, CellButton_1>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab3.ScrollContainer.PreviewImage
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

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab3.ScrollContainer.CellName
        /// </summary>
        public CellName_1 L_CellName
        {
            get
            {
                if (_L_CellName == null) _L_CellName = new CellName_1(UiPanel, Instance.GetNode<Godot.Label>("CellName"));
                return _L_CellName;
            }
        }
        private CellName_1 _L_CellName;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab3.ScrollContainer.SelectTexture
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

        public CellButton_1(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CellButton_1 Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab3.ScrollContainer
    /// </summary>
    public class ScrollContainer_3 : UiNode<MapEditorPanel, Godot.ScrollContainer, ScrollContainer_3>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab3.CellButton
        /// </summary>
        public CellButton_1 L_CellButton
        {
            get
            {
                if (_L_CellButton == null) _L_CellButton = new CellButton_1(UiPanel, Instance.GetNode<Godot.Button>("CellButton"));
                return _L_CellButton;
            }
        }
        private CellButton_1 _L_CellButton;

        public ScrollContainer_3(MapEditorPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer_3 Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab3
    /// </summary>
    public class Tab3 : UiNode<MapEditorPanel, UI.editor.MapEditorMapTile.CombinationTileTab, Tab3>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.ScrollContainer
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

        public Tab3(MapEditorPanel uiPanel, UI.editor.MapEditorMapTile.CombinationTileTab node) : base(uiPanel, node) {  }
        public override Tab3 Clone() => new (UiPanel, (UI.editor.MapEditorMapTile.CombinationTileTab)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer
    /// </summary>
    public class MarginContainer_2 : UiNode<MapEditorPanel, Godot.MarginContainer, MarginContainer_2>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.Tab1
        /// </summary>
        public Tab1 L_Tab1
        {
            get
            {
                if (_L_Tab1 == null) _L_Tab1 = new Tab1(UiPanel, Instance.GetNode<UI.editor.MapEditorMapTile.FreeTileTab>("Tab1"));
                return _L_Tab1;
            }
        }
        private Tab1 _L_Tab1;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.Tab2
        /// </summary>
        public Tab2 L_Tab2
        {
            get
            {
                if (_L_Tab2 == null) _L_Tab2 = new Tab2(UiPanel, Instance.GetNode<UI.editor.MapEditorMapTile.TerrainTileTab>("Tab2"));
                return _L_Tab2;
            }
        }
        private Tab2 _L_Tab2;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.Tab3
        /// </summary>
        public Tab3 L_Tab3
        {
            get
            {
                if (_L_Tab3 == null) _L_Tab3 = new Tab3(UiPanel, Instance.GetNode<UI.editor.MapEditorMapTile.CombinationTileTab>("Tab3"));
                return _L_Tab3;
            }
        }
        private Tab3 _L_Tab3;

        public MarginContainer_2(MapEditorPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer_2 Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel
    /// </summary>
    public class Panel : UiNode<MapEditorPanel, Godot.Panel, Panel>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.MarginContainer
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

        public Panel(MapEditorPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override Panel Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer
    /// </summary>
    public class VBoxContainer_3 : UiNode<MapEditorPanel, Godot.VBoxContainer, VBoxContainer_3>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.HBoxContainer
        /// </summary>
        public HBoxContainer_4 L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer_4(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer_4 _L_HBoxContainer;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.HBoxContainer2
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
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.Panel
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

        public VBoxContainer_3(MapEditorPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_3 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.MaskBg.Label
    /// </summary>
    public class Label_3 : UiNode<MapEditorPanel, Godot.Label, Label_3>
    {
        public Label_3(MapEditorPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_3 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.MaskBg
    /// </summary>
    public class MaskBg : UiNode<MapEditorPanel, Godot.ColorRect, MaskBg>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.Label
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

        public MaskBg(MapEditorPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override MaskBg Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile
    /// </summary>
    public class MapEditorMapTile : UiNode<MapEditorPanel, UI.editor.MapEditorMapTile.MapEditorMapTilePanel, MapEditorMapTile>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.VBoxContainer
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
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MaskBg
        /// </summary>
        public MaskBg L_MaskBg
        {
            get
            {
                if (_L_MaskBg == null) _L_MaskBg = new MaskBg(UiPanel, Instance.GetNode<Godot.ColorRect>("MaskBg"));
                return _L_MaskBg;
            }
        }
        private MaskBg _L_MaskBg;

        public MapEditorMapTile(MapEditorPanel uiPanel, UI.editor.MapEditorMapTile.MapEditorMapTilePanel node) : base(uiPanel, node) {  }
        public override MapEditorMapTile Clone() => new (UiPanel, (UI.editor.MapEditorMapTile.MapEditorMapTilePanel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile
    /// </summary>
    public class MapTile : UiNode<MapEditorPanel, Godot.MarginContainer, MapTile>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapEditorMapTile
        /// </summary>
        public MapEditorMapTile L_MapEditorMapTile
        {
            get
            {
                if (_L_MapEditorMapTile == null) _L_MapEditorMapTile = new MapEditorMapTile(UiPanel, Instance.GetNode<UI.editor.MapEditorMapTile.MapEditorMapTilePanel>("MapEditorMapTile"));
                return _L_MapEditorMapTile;
            }
        }
        private MapEditorMapTile _L_MapEditorMapTile;

        public MapTile(MapEditorPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MapTile Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.HBoxContainer.SearchInput
    /// </summary>
    public class SearchInput_1 : UiNode<MapEditorPanel, Godot.LineEdit, SearchInput_1>
    {
        public SearchInput_1(MapEditorPanel uiPanel, Godot.LineEdit node) : base(uiPanel, node) {  }
        public override SearchInput_1 Clone() => new (UiPanel, (Godot.LineEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.HBoxContainer.SearchButton
    /// </summary>
    public class SearchButton_1 : UiNode<MapEditorPanel, Godot.Button, SearchButton_1>
    {
        public SearchButton_1(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override SearchButton_1 Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer_5 : UiNode<MapEditorPanel, Godot.HBoxContainer, HBoxContainer_5>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.SearchInput
        /// </summary>
        public SearchInput_1 L_SearchInput
        {
            get
            {
                if (_L_SearchInput == null) _L_SearchInput = new SearchInput_1(UiPanel, Instance.GetNode<Godot.LineEdit>("SearchInput"));
                return _L_SearchInput;
            }
        }
        private SearchInput_1 _L_SearchInput;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.SearchButton
        /// </summary>
        public SearchButton_1 L_SearchButton
        {
            get
            {
                if (_L_SearchButton == null) _L_SearchButton = new SearchButton_1(UiPanel, Instance.GetNode<Godot.Button>("SearchButton"));
                return _L_SearchButton;
            }
        }
        private SearchButton_1 _L_SearchButton;

        public HBoxContainer_5(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer_5 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.HBoxContainer2.Label
    /// </summary>
    public class Label_4 : UiNode<MapEditorPanel, Godot.Label, Label_4>
    {
        public Label_4(MapEditorPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_4 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.HBoxContainer2.LayerOption
    /// </summary>
    public class LayerOption : UiNode<MapEditorPanel, Godot.OptionButton, LayerOption>
    {
        public LayerOption(MapEditorPanel uiPanel, Godot.OptionButton node) : base(uiPanel, node) {  }
        public override LayerOption Clone() => new (UiPanel, (Godot.OptionButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.HBoxContainer2
    /// </summary>
    public class HBoxContainer2_1 : UiNode<MapEditorPanel, Godot.HBoxContainer, HBoxContainer2_1>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.Label
        /// </summary>
        public Label_4 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_4(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_4 _L_Label;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.LayerOption
        /// </summary>
        public LayerOption L_LayerOption
        {
            get
            {
                if (_L_LayerOption == null) _L_LayerOption = new LayerOption(UiPanel, Instance.GetNode<Godot.OptionButton>("LayerOption"));
                return _L_LayerOption;
            }
        }
        private LayerOption _L_LayerOption;

        public HBoxContainer2_1(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer2_1 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.ItemRoot.Item.ItemButton.Icon
    /// </summary>
    public class Icon : UiNode<MapEditorPanel, Godot.TextureRect, Icon>
    {
        public Icon(MapEditorPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override Icon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.ItemRoot.Item.ItemButton.Select
    /// </summary>
    public class Select_2 : UiNode<MapEditorPanel, Godot.NinePatchRect, Select_2>
    {
        public Select_2(MapEditorPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override Select_2 Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.ItemRoot.Item.ItemButton
    /// </summary>
    public class ItemButton : UiNode<MapEditorPanel, Godot.Button, ItemButton>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.ItemRoot.Item.Icon
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
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.ItemRoot.Item.Select
        /// </summary>
        public Select_2 L_Select
        {
            get
            {
                if (_L_Select == null) _L_Select = new Select_2(UiPanel, Instance.GetNode<Godot.NinePatchRect>("Select"));
                return _L_Select;
            }
        }
        private Select_2 _L_Select;

        public ItemButton(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ItemButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.ItemRoot.Item
    /// </summary>
    public class Item : UiNode<MapEditorPanel, Godot.HBoxContainer, Item>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.ItemRoot.ItemButton
        /// </summary>
        public ItemButton L_ItemButton
        {
            get
            {
                if (_L_ItemButton == null) _L_ItemButton = new ItemButton(UiPanel, Instance.GetNode<Godot.Button>("ItemButton"));
                return _L_ItemButton;
            }
        }
        private ItemButton _L_ItemButton;

        public Item(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override Item Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.ItemRoot
    /// </summary>
    public class ItemRoot : UiNode<MapEditorPanel, Godot.ScrollContainer, ItemRoot>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.Item
        /// </summary>
        public Item L_Item
        {
            get
            {
                if (_L_Item == null) _L_Item = new Item(UiPanel, Instance.GetNode<Godot.HBoxContainer>("Item"));
                return _L_Item;
            }
        }
        private Item _L_Item;

        public ItemRoot(MapEditorPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ItemRoot Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer
    /// </summary>
    public class VBoxContainer_4 : UiNode<MapEditorPanel, Godot.VBoxContainer, VBoxContainer_4>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.HBoxContainer
        /// </summary>
        public HBoxContainer_5 L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer_5(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer_5 _L_HBoxContainer;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.HBoxContainer2
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

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.ItemRoot
        /// </summary>
        public ItemRoot L_ItemRoot
        {
            get
            {
                if (_L_ItemRoot == null) _L_ItemRoot = new ItemRoot(UiPanel, Instance.GetNode<Godot.ScrollContainer>("ItemRoot"));
                return _L_ItemRoot;
            }
        }
        private ItemRoot _L_ItemRoot;

        public VBoxContainer_4(MapEditorPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_4 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.DynamicDeleteButton
    /// </summary>
    public class DynamicDeleteButton : UiNode<MapEditorPanel, Godot.Button, DynamicDeleteButton>
    {
        public DynamicDeleteButton(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override DynamicDeleteButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject
    /// </summary>
    public class MapEditorObject : UiNode<MapEditorPanel, UI.editor.MapEditorObject.MapEditorObjectPanel, MapEditorObject>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.VBoxContainer
        /// </summary>
        public VBoxContainer_4 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_4(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_4 _L_VBoxContainer;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.DynamicDeleteButton
        /// </summary>
        public DynamicDeleteButton L_DynamicDeleteButton
        {
            get
            {
                if (_L_DynamicDeleteButton == null) _L_DynamicDeleteButton = new DynamicDeleteButton(UiPanel, Instance.GetNode<Godot.Button>("DynamicDeleteButton"));
                return _L_DynamicDeleteButton;
            }
        }
        private DynamicDeleteButton _L_DynamicDeleteButton;

        public MapEditorObject(MapEditorPanel uiPanel, UI.editor.MapEditorObject.MapEditorObjectPanel node) : base(uiPanel, node) {  }
        public override MapEditorObject Clone() => new (UiPanel, (UI.editor.MapEditorObject.MapEditorObjectPanel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject
    /// </summary>
    public class MapObject : UiNode<MapEditorPanel, Godot.MarginContainer, MapObject>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapEditorObject
        /// </summary>
        public MapEditorObject L_MapEditorObject
        {
            get
            {
                if (_L_MapEditorObject == null) _L_MapEditorObject = new MapEditorObject(UiPanel, Instance.GetNode<UI.editor.MapEditorObject.MapEditorObjectPanel>("MapEditorObject"));
                return _L_MapEditorObject;
            }
        }
        private MapEditorObject _L_MapEditorObject;

        public MapObject(MapEditorPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MapObject Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.MarkLabel
    /// </summary>
    public class MarkLabel : UiNode<MapEditorPanel, Godot.Label, MarkLabel>
    {
        public MarkLabel(MapEditorPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override MarkLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.HBoxContainer.PreinstallOption
    /// </summary>
    public class PreinstallOption : UiNode<MapEditorPanel, Godot.OptionButton, PreinstallOption>
    {
        public PreinstallOption(MapEditorPanel uiPanel, Godot.OptionButton node) : base(uiPanel, node) {  }
        public override PreinstallOption Clone() => new (UiPanel, (Godot.OptionButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.HBoxContainer.AddPreinstall
    /// </summary>
    public class AddPreinstall : UiNode<MapEditorPanel, Godot.Button, AddPreinstall>
    {
        public AddPreinstall(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override AddPreinstall Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.HBoxContainer.EditPreinstall
    /// </summary>
    public class EditPreinstall : UiNode<MapEditorPanel, Godot.Button, EditPreinstall>
    {
        public EditPreinstall(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override EditPreinstall Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.HBoxContainer.DeletePreinstall
    /// </summary>
    public class DeletePreinstall : UiNode<MapEditorPanel, Godot.Button, DeletePreinstall>
    {
        public DeletePreinstall(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override DeletePreinstall Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer_6 : UiNode<MapEditorPanel, Godot.HBoxContainer, HBoxContainer_6>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.PreinstallOption
        /// </summary>
        public PreinstallOption L_PreinstallOption
        {
            get
            {
                if (_L_PreinstallOption == null) _L_PreinstallOption = new PreinstallOption(UiPanel, Instance.GetNode<Godot.OptionButton>("PreinstallOption"));
                return _L_PreinstallOption;
            }
        }
        private PreinstallOption _L_PreinstallOption;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.AddPreinstall
        /// </summary>
        public AddPreinstall L_AddPreinstall
        {
            get
            {
                if (_L_AddPreinstall == null) _L_AddPreinstall = new AddPreinstall(UiPanel, Instance.GetNode<Godot.Button>("AddPreinstall"));
                return _L_AddPreinstall;
            }
        }
        private AddPreinstall _L_AddPreinstall;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.EditPreinstall
        /// </summary>
        public EditPreinstall L_EditPreinstall
        {
            get
            {
                if (_L_EditPreinstall == null) _L_EditPreinstall = new EditPreinstall(UiPanel, Instance.GetNode<Godot.Button>("EditPreinstall"));
                return _L_EditPreinstall;
            }
        }
        private EditPreinstall _L_EditPreinstall;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.DeletePreinstall
        /// </summary>
        public DeletePreinstall L_DeletePreinstall
        {
            get
            {
                if (_L_DeletePreinstall == null) _L_DeletePreinstall = new DeletePreinstall(UiPanel, Instance.GetNode<Godot.Button>("DeletePreinstall"));
                return _L_DeletePreinstall;
            }
        }
        private DeletePreinstall _L_DeletePreinstall;

        public HBoxContainer_6(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer_6 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.MarkLabel2
    /// </summary>
    public class MarkLabel2 : UiNode<MapEditorPanel, Godot.Label, MarkLabel2>
    {
        public MarkLabel2(MapEditorPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override MarkLabel2 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.DynamicTool.EditButton
    /// </summary>
    public class EditButton : UiNode<MapEditorPanel, Godot.Button, EditButton>
    {
        public EditButton(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override EditButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.DynamicTool.DeleteButton
    /// </summary>
    public class DeleteButton : UiNode<MapEditorPanel, Godot.Button, DeleteButton>
    {
        public DeleteButton(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override DeleteButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.DynamicTool
    /// </summary>
    public class DynamicTool : UiNode<MapEditorPanel, Godot.HBoxContainer, DynamicTool>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.EditButton
        /// </summary>
        public EditButton L_EditButton
        {
            get
            {
                if (_L_EditButton == null) _L_EditButton = new EditButton(UiPanel, Instance.GetNode<Godot.Button>("EditButton"));
                return _L_EditButton;
            }
        }
        private EditButton _L_EditButton;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.DeleteButton
        /// </summary>
        public DeleteButton L_DeleteButton
        {
            get
            {
                if (_L_DeleteButton == null) _L_DeleteButton = new DeleteButton(UiPanel, Instance.GetNode<Godot.Button>("DeleteButton"));
                return _L_DeleteButton;
            }
        }
        private DeleteButton _L_DeleteButton;

        public DynamicTool(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override DynamicTool Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.AutoFillTip.Label
    /// </summary>
    public class Label_5 : UiNode<MapEditorPanel, Godot.Label, Label_5>
    {
        public Label_5(MapEditorPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_5 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.AutoFillTip
    /// </summary>
    public class AutoFillTip : UiNode<MapEditorPanel, Godot.ColorRect, AutoFillTip>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.Label
        /// </summary>
        public Label_5 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_5(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_5 _L_Label;

        public AutoFillTip(MapEditorPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override AutoFillTip Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.AddWaveButton
    /// </summary>
    public class AddWaveButton : UiNode<MapEditorPanel, Godot.Button, AddWaveButton>
    {
        public AddWaveButton(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override AddWaveButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.WaveContainer.TextureButton
    /// </summary>
    public class TextureButton : UiNode<MapEditorPanel, Godot.TextureButton, TextureButton>
    {
        public TextureButton(MapEditorPanel uiPanel, Godot.TextureButton node) : base(uiPanel, node) {  }
        public override TextureButton Clone() => new (UiPanel, (Godot.TextureButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.WaveContainer.WaveButton.Select
    /// </summary>
    public class Select_3 : UiNode<MapEditorPanel, Godot.NinePatchRect, Select_3>
    {
        public Select_3(MapEditorPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override Select_3 Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.WaveContainer.WaveButton
    /// </summary>
    public class WaveButton : UiNode<MapEditorPanel, Godot.Button, WaveButton>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.WaveContainer.Select
        /// </summary>
        public Select_3 L_Select
        {
            get
            {
                if (_L_Select == null) _L_Select = new Select_3(UiPanel, Instance.GetNode<Godot.NinePatchRect>("Select"));
                return _L_Select;
            }
        }
        private Select_3 _L_Select;

        public WaveButton(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override WaveButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.WaveContainer.WaveVisibleButton
    /// </summary>
    public class WaveVisibleButton : UiNode<MapEditorPanel, Godot.Button, WaveVisibleButton>
    {
        public WaveVisibleButton(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override WaveVisibleButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.WaveContainer
    /// </summary>
    public class WaveContainer : UiNode<MapEditorPanel, Godot.HBoxContainer, WaveContainer>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.TextureButton
        /// </summary>
        public TextureButton L_TextureButton
        {
            get
            {
                if (_L_TextureButton == null) _L_TextureButton = new TextureButton(UiPanel, Instance.GetNode<Godot.TextureButton>("TextureButton"));
                return _L_TextureButton;
            }
        }
        private TextureButton _L_TextureButton;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.WaveButton
        /// </summary>
        public WaveButton L_WaveButton
        {
            get
            {
                if (_L_WaveButton == null) _L_WaveButton = new WaveButton(UiPanel, Instance.GetNode<Godot.Button>("WaveButton"));
                return _L_WaveButton;
            }
        }
        private WaveButton _L_WaveButton;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.WaveVisibleButton
        /// </summary>
        public WaveVisibleButton L_WaveVisibleButton
        {
            get
            {
                if (_L_WaveVisibleButton == null) _L_WaveVisibleButton = new WaveVisibleButton(UiPanel, Instance.GetNode<Godot.Button>("WaveVisibleButton"));
                return _L_WaveVisibleButton;
            }
        }
        private WaveVisibleButton _L_WaveVisibleButton;

        public WaveContainer(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override WaveContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarginContainer.AddMarkButton
    /// </summary>
    public class AddMarkButton : UiNode<MapEditorPanel, Godot.Button, AddMarkButton>
    {
        public AddMarkButton(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override AddMarkButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarginContainer
    /// </summary>
    public class MarginContainer_3 : UiNode<MapEditorPanel, Godot.MarginContainer, MarginContainer_3>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.AddMarkButton
        /// </summary>
        public AddMarkButton L_AddMarkButton
        {
            get
            {
                if (_L_AddMarkButton == null) _L_AddMarkButton = new AddMarkButton(UiPanel, Instance.GetNode<Godot.Button>("AddMarkButton"));
                return _L_AddMarkButton;
            }
        }
        private AddMarkButton _L_AddMarkButton;

        public MarginContainer_3(MapEditorPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer_3 Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarkContainer.MarkItem.MarkButton.MarkIcon
    /// </summary>
    public class MarkIcon : UiNode<MapEditorPanel, Godot.TextureRect, MarkIcon>
    {
        public MarkIcon(MapEditorPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override MarkIcon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarkContainer.MarkItem.MarkButton.Select
    /// </summary>
    public class Select_4 : UiNode<MapEditorPanel, Godot.NinePatchRect, Select_4>
    {
        public Select_4(MapEditorPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override Select_4 Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarkContainer.MarkItem.MarkButton
    /// </summary>
    public class MarkButton : UiNode<MapEditorPanel, Godot.Button, MarkButton>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarkContainer.MarkItem.MarkIcon
        /// </summary>
        public MarkIcon L_MarkIcon
        {
            get
            {
                if (_L_MarkIcon == null) _L_MarkIcon = new MarkIcon(UiPanel, Instance.GetNode<Godot.TextureRect>("MarkIcon"));
                return _L_MarkIcon;
            }
        }
        private MarkIcon _L_MarkIcon;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarkContainer.MarkItem.Select
        /// </summary>
        public Select_4 L_Select
        {
            get
            {
                if (_L_Select == null) _L_Select = new Select_4(UiPanel, Instance.GetNode<Godot.NinePatchRect>("Select"));
                return _L_Select;
            }
        }
        private Select_4 _L_Select;

        public MarkButton(MapEditorPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override MarkButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarkContainer.MarkItem
    /// </summary>
    public class MarkItem : UiNode<MapEditorPanel, Godot.HBoxContainer, MarkItem>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarkContainer.MarkButton
        /// </summary>
        public MarkButton L_MarkButton
        {
            get
            {
                if (_L_MarkButton == null) _L_MarkButton = new MarkButton(UiPanel, Instance.GetNode<Godot.Button>("MarkButton"));
                return _L_MarkButton;
            }
        }
        private MarkButton _L_MarkButton;

        public MarkItem(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override MarkItem Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarkContainer
    /// </summary>
    public class MarkContainer : UiNode<MapEditorPanel, Godot.MarginContainer, MarkContainer>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarkItem
        /// </summary>
        public MarkItem L_MarkItem
        {
            get
            {
                if (_L_MarkItem == null) _L_MarkItem = new MarkItem(UiPanel, Instance.GetNode<Godot.HBoxContainer>("MarkItem"));
                return _L_MarkItem;
            }
        }
        private MarkItem _L_MarkItem;

        public MarkContainer(MapEditorPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarkContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem
    /// </summary>
    public class WaveItem : UiNode<MapEditorPanel, Godot.VBoxContainer, WaveItem>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveContainer
        /// </summary>
        public WaveContainer L_WaveContainer
        {
            get
            {
                if (_L_WaveContainer == null) _L_WaveContainer = new WaveContainer(UiPanel, Instance.GetNode<Godot.HBoxContainer>("WaveContainer"));
                return _L_WaveContainer;
            }
        }
        private WaveContainer _L_WaveContainer;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.MarginContainer
        /// </summary>
        public MarginContainer_3 L_MarginContainer
        {
            get
            {
                if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer_3(UiPanel, Instance.GetNode<Godot.MarginContainer>("MarginContainer"));
                return _L_MarginContainer;
            }
        }
        private MarginContainer_3 _L_MarginContainer;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.MarkContainer
        /// </summary>
        public MarkContainer L_MarkContainer
        {
            get
            {
                if (_L_MarkContainer == null) _L_MarkContainer = new MarkContainer(UiPanel, Instance.GetNode<Godot.MarginContainer>("MarkContainer"));
                return _L_MarkContainer;
            }
        }
        private MarkContainer _L_MarkContainer;

        public WaveItem(MapEditorPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override WaveItem Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_6 : UiNode<MapEditorPanel, Godot.VBoxContainer, VBoxContainer_6>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.AutoFillTip
        /// </summary>
        public AutoFillTip L_AutoFillTip
        {
            get
            {
                if (_L_AutoFillTip == null) _L_AutoFillTip = new AutoFillTip(UiPanel, Instance.GetNode<Godot.ColorRect>("AutoFillTip"));
                return _L_AutoFillTip;
            }
        }
        private AutoFillTip _L_AutoFillTip;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.AddWaveButton
        /// </summary>
        public AddWaveButton L_AddWaveButton
        {
            get
            {
                if (_L_AddWaveButton == null) _L_AddWaveButton = new AddWaveButton(UiPanel, Instance.GetNode<Godot.Button>("AddWaveButton"));
                return _L_AddWaveButton;
            }
        }
        private AddWaveButton _L_AddWaveButton;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.WaveItem
        /// </summary>
        public WaveItem L_WaveItem
        {
            get
            {
                if (_L_WaveItem == null) _L_WaveItem = new WaveItem(UiPanel, Instance.GetNode<Godot.VBoxContainer>("WaveItem"));
                return _L_WaveItem;
            }
        }
        private WaveItem _L_WaveItem;

        public VBoxContainer_6(MapEditorPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_6 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer
    /// </summary>
    public class ScrollContainer_4 : UiNode<MapEditorPanel, Godot.ScrollContainer, ScrollContainer_4>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.VBoxContainer
        /// </summary>
        public VBoxContainer_6 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_6(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_6 _L_VBoxContainer;

        public ScrollContainer_4(MapEditorPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer_4 Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer
    /// </summary>
    public class VBoxContainer_5 : UiNode<MapEditorPanel, Godot.VBoxContainer, VBoxContainer_5>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.MarkLabel
        /// </summary>
        public MarkLabel L_MarkLabel
        {
            get
            {
                if (_L_MarkLabel == null) _L_MarkLabel = new MarkLabel(UiPanel, Instance.GetNode<Godot.Label>("MarkLabel"));
                return _L_MarkLabel;
            }
        }
        private MarkLabel _L_MarkLabel;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.HBoxContainer
        /// </summary>
        public HBoxContainer_6 L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer_6(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer_6 _L_HBoxContainer;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.MarkLabel2
        /// </summary>
        public MarkLabel2 L_MarkLabel2
        {
            get
            {
                if (_L_MarkLabel2 == null) _L_MarkLabel2 = new MarkLabel2(UiPanel, Instance.GetNode<Godot.Label>("MarkLabel2"));
                return _L_MarkLabel2;
            }
        }
        private MarkLabel2 _L_MarkLabel2;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.DynamicTool
        /// </summary>
        public DynamicTool L_DynamicTool
        {
            get
            {
                if (_L_DynamicTool == null) _L_DynamicTool = new DynamicTool(UiPanel, Instance.GetNode<Godot.HBoxContainer>("DynamicTool"));
                return _L_DynamicTool;
            }
        }
        private DynamicTool _L_DynamicTool;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.ScrollContainer
        /// </summary>
        public ScrollContainer_4 L_ScrollContainer
        {
            get
            {
                if (_L_ScrollContainer == null) _L_ScrollContainer = new ScrollContainer_4(UiPanel, Instance.GetNode<Godot.ScrollContainer>("ScrollContainer"));
                return _L_ScrollContainer;
            }
        }
        private ScrollContainer_4 _L_ScrollContainer;

        public VBoxContainer_5(MapEditorPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_5 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark
    /// </summary>
    public class MapEditorMapMark : UiNode<MapEditorPanel, UI.editor.MapEditorMapMark.MapEditorMapMarkPanel, MapEditorMapMark>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.VBoxContainer
        /// </summary>
        public VBoxContainer_5 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_5(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_5 _L_VBoxContainer;

        public MapEditorMapMark(MapEditorPanel uiPanel, UI.editor.MapEditorMapMark.MapEditorMapMarkPanel node) : base(uiPanel, node) {  }
        public override MapEditorMapMark Clone() => new (UiPanel, (UI.editor.MapEditorMapMark.MapEditorMapMarkPanel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark
    /// </summary>
    public class MapMark : UiNode<MapEditorPanel, Godot.MarginContainer, MapMark>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapEditorMapMark
        /// </summary>
        public MapEditorMapMark L_MapEditorMapMark
        {
            get
            {
                if (_L_MapEditorMapMark == null) _L_MapEditorMapMark = new MapEditorMapMark(UiPanel, Instance.GetNode<UI.editor.MapEditorMapMark.MapEditorMapMarkPanel>("MapEditorMapMark"));
                return _L_MapEditorMapMark;
            }
        }
        private MapEditorMapMark _L_MapEditorMapMark;

        public MapMark(MapEditorPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MapMark Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer
    /// </summary>
    public class TabContainer : UiNode<MapEditorPanel, Godot.TabContainer, TabContainer>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.MapTile
        /// </summary>
        public MapTile L_MapTile
        {
            get
            {
                if (_L_MapTile == null) _L_MapTile = new MapTile(UiPanel, Instance.GetNode<Godot.MarginContainer>("MapTile"));
                return _L_MapTile;
            }
        }
        private MapTile _L_MapTile;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.MapObject
        /// </summary>
        public MapObject L_MapObject
        {
            get
            {
                if (_L_MapObject == null) _L_MapObject = new MapObject(UiPanel, Instance.GetNode<Godot.MarginContainer>("MapObject"));
                return _L_MapObject;
            }
        }
        private MapObject _L_MapObject;

        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.MapMark
        /// </summary>
        public MapMark L_MapMark
        {
            get
            {
                if (_L_MapMark == null) _L_MapMark = new MapMark(UiPanel, Instance.GetNode<Godot.MarginContainer>("MapMark"));
                return _L_MapMark;
            }
        }
        private MapMark _L_MapMark;

        public TabContainer(MapEditorPanel uiPanel, Godot.TabContainer node) : base(uiPanel, node) {  }
        public override TabContainer Clone() => new (UiPanel, (Godot.TabContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer
    /// </summary>
    public class MarginContainer_1 : UiNode<MapEditorPanel, Godot.MarginContainer, MarginContainer_1>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.TabContainer
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

        public MarginContainer_1(MapEditorPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer_1 Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right
    /// </summary>
    public class Right : UiNode<MapEditorPanel, Godot.Panel, Right>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.MarginContainer
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

        public Right(MapEditorPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override Right Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2
    /// </summary>
    public class HSplitContainer2 : UiNode<MapEditorPanel, Godot.HSplitContainer, HSplitContainer2>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HBoxContainer
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
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.Right
        /// </summary>
        public Right L_Right
        {
            get
            {
                if (_L_Right == null) _L_Right = new Right(UiPanel, Instance.GetNode<Godot.Panel>("Right"));
                return _L_Right;
            }
        }
        private Right _L_Right;

        public HSplitContainer2(MapEditorPanel uiPanel, Godot.HSplitContainer node) : base(uiPanel, node) {  }
        public override HSplitContainer2 Clone() => new (UiPanel, (Godot.HSplitContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer.HSplitContainer
    /// </summary>
    public class HSplitContainer : UiNode<MapEditorPanel, Godot.HBoxContainer, HSplitContainer>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer2
        /// </summary>
        public HSplitContainer2 L_HSplitContainer2
        {
            get
            {
                if (_L_HSplitContainer2 == null) _L_HSplitContainer2 = new HSplitContainer2(UiPanel, Instance.GetNode<Godot.HSplitContainer>("HSplitContainer2"));
                return _L_HSplitContainer2;
            }
        }
        private HSplitContainer2 _L_HSplitContainer2;

        public HSplitContainer(MapEditorPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HSplitContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<MapEditorPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 节点路径: MapEditor.Bg.Head
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
        /// 节点路径: MapEditor.Bg.HSplitContainer
        /// </summary>
        public HSplitContainer L_HSplitContainer
        {
            get
            {
                if (_L_HSplitContainer == null) _L_HSplitContainer = new HSplitContainer(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HSplitContainer"));
                return _L_HSplitContainer;
            }
        }
        private HSplitContainer _L_HSplitContainer;

        public VBoxContainer(MapEditorPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditor.Bg
    /// </summary>
    public class Bg : UiNode<MapEditorPanel, Godot.Panel, Bg>
    {
        /// <summary>
        /// 节点路径: MapEditor.VBoxContainer
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

        public Bg(MapEditorPanel uiPanel, Godot.Panel node) : base(uiPanel, node) {  }
        public override Bg Clone() => new (UiPanel, (Godot.Panel)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.Head.Back
    /// </summary>
    public Back S_Back => L_Bg.L_VBoxContainer.L_Head.L_Back;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.Head.Save
    /// </summary>
    public Save S_Save => L_Bg.L_VBoxContainer.L_Head.L_Save;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.Head.Title
    /// </summary>
    public Title S_Title => L_Bg.L_VBoxContainer.L_Head.L_Title;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.Head.Play
    /// </summary>
    public Play S_Play => L_Bg.L_VBoxContainer.L_Head.L_Play;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.Head.PlaySetting
    /// </summary>
    public PlaySetting S_PlaySetting => L_Bg.L_VBoxContainer.L_Head.L_PlaySetting;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.Head
    /// </summary>
    public Head S_Head => L_Bg.L_VBoxContainer.L_Head;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.HBoxContainer.CheckButton
    /// </summary>
    public CheckButton S_CheckButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_LayerPanel.L_MapEditorMapLayer.L_VBoxContainer.L_HBoxContainer.L_CheckButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.ScrollContainer.LayerButton.VisibleButton
    /// </summary>
    public VisibleButton S_VisibleButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_LayerPanel.L_MapEditorMapLayer.L_VBoxContainer.L_ScrollContainer.L_LayerButton.L_VisibleButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer.VBoxContainer.ScrollContainer.LayerButton
    /// </summary>
    public LayerButton S_LayerButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_LayerPanel.L_MapEditorMapLayer.L_VBoxContainer.L_ScrollContainer.L_LayerButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorMapLayer
    /// </summary>
    public MapEditorMapLayer S_MapEditorMapLayer => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_LayerPanel.L_MapEditorMapLayer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel.MapEditorConfigObject
    /// </summary>
    public MapEditorConfigObject S_MapEditorConfigObject => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_LayerPanel.L_MapEditorConfigObject;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.LayerPanel
    /// </summary>
    public LayerPanel S_LayerPanel => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_LayerPanel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.TileMap.NavigationRegion
    /// </summary>
    public NavigationRegion S_NavigationRegion => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_TileMap.L_NavigationRegion;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.TileMap.ErrorCell.ErrorCellAnimationPlayer
    /// </summary>
    public ErrorCellAnimationPlayer S_ErrorCellAnimationPlayer => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_TileMap.L_ErrorCell.L_ErrorCellAnimationPlayer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.TileMap.ErrorCell
    /// </summary>
    public ErrorCell S_ErrorCell => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_TileMap.L_ErrorCell;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.TileMap
    /// </summary>
    public TileMap S_TileMap => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_TileMap;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.N_HoverRoot.N_HoverArea
    /// </summary>
    public N_HoverArea S_N_HoverArea => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_N_HoverRoot.L_N_HoverArea;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.N_HoverRoot
    /// </summary>
    public N_HoverRoot S_N_HoverRoot => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_N_HoverRoot;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.E_HoverRoot.E_HoverArea
    /// </summary>
    public E_HoverArea S_E_HoverArea => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_E_HoverRoot.L_E_HoverArea;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.E_HoverRoot
    /// </summary>
    public E_HoverRoot S_E_HoverRoot => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_E_HoverRoot;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.S_HoverRoot.S_HoverArea
    /// </summary>
    public S_HoverArea S_S_HoverArea => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_S_HoverRoot.L_S_HoverArea;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.S_HoverRoot
    /// </summary>
    public S_HoverRoot S_S_HoverRoot => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_S_HoverRoot;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.W_HoverRoot.W_HoverArea
    /// </summary>
    public W_HoverArea S_W_HoverArea => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_W_HoverRoot.L_W_HoverArea;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.W_HoverRoot
    /// </summary>
    public W_HoverRoot S_W_HoverRoot => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_W_HoverRoot;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.HoverPreviewRoot.HoverPreview
    /// </summary>
    public HoverPreview S_HoverPreview => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_HoverPreviewRoot.L_HoverPreview;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.HoverPreviewRoot
    /// </summary>
    public HoverPreviewRoot S_HoverPreviewRoot => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_HoverPreviewRoot;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.DoorToolTemplate.DoorArea
    /// </summary>
    public DoorArea S_DoorArea => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_DoorToolTemplate.L_DoorArea;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.DoorToolTemplate.StartBtn
    /// </summary>
    public StartBtn S_StartBtn => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_DoorToolTemplate.L_StartBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.DoorToolTemplate.EndBtn
    /// </summary>
    public EndBtn S_EndBtn => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_DoorToolTemplate.L_EndBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.DoorToolTemplate
    /// </summary>
    public DoorToolTemplate S_DoorToolTemplate => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_DoorToolTemplate;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot.MarkTemplate
    /// </summary>
    public MarkTemplate S_MarkTemplate => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot.L_MarkTemplate;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ToolRoot
    /// </summary>
    public ToolRoot S_ToolRoot => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ToolRoot;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ObjectTemplate.CollisionShape2D
    /// </summary>
    public CollisionShape2D S_CollisionShape2D => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ObjectTemplate.L_CollisionShape2D;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ObjectTemplate.Bar
    /// </summary>
    public Bar S_Bar => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ObjectTemplate.L_Bar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ObjectTemplate.RectBrush
    /// </summary>
    public RectBrush S_RectBrush => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ObjectTemplate.L_RectBrush;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.ObjectTemplate
    /// </summary>
    public ObjectTemplate S_ObjectTemplate => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_ObjectTemplate;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools.HBoxContainer.ToolButton
    /// </summary>
    public ToolButton S_ToolButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools.L_HBoxContainer.L_ToolButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer.MapEditorTools
    /// </summary>
    public MapEditorTools S_MapEditorTools => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer.L_MapEditorTools;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport.CanvasLayer
    /// </summary>
    public CanvasLayer S_CanvasLayer => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport.L_CanvasLayer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView.SubViewport
    /// </summary>
    public SubViewport S_SubViewport => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView.L_SubViewport;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView
    /// </summary>
    public MapView S_MapView => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left.MarginContainer.MapView2
    /// </summary>
    public MapView2 S_MapView2 => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left.L_MarginContainer.L_MapView2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.HBoxContainer.Left
    /// </summary>
    public Left S_Left => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_HBoxContainer.L_Left;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.HBoxContainer.SourceOption
    /// </summary>
    public SourceOption S_SourceOption => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_HBoxContainer.L_SourceOption;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.HBoxContainer2.HandleOption
    /// </summary>
    public HandleOption S_HandleOption => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_HBoxContainer2.L_HandleOption;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab1.TabRoot.TileSprite
    /// </summary>
    public TileSprite S_TileSprite => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab1.L_TabRoot.L_TileSprite;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab1.TabRoot
    /// </summary>
    public TabRoot S_TabRoot => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab1.L_TabRoot;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab1.Grid
    /// </summary>
    public Grid S_Grid => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab1.L_Grid;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab1.FocusBtn
    /// </summary>
    public FocusBtn S_FocusBtn => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab1.L_FocusBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab1
    /// </summary>
    public Tab1 S_Tab1 => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab1;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer.TerrainItem.TerrainName
    /// </summary>
    public TerrainName S_TerrainName => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab2.L_ScrollContainer.L_TerrainItem.L_TerrainName;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer.TerrainItem.ErrorIcon
    /// </summary>
    public ErrorIcon S_ErrorIcon => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab2.L_ScrollContainer.L_TerrainItem.L_ErrorIcon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer.TerrainItem.TerrainPreview
    /// </summary>
    public TerrainPreview S_TerrainPreview => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab2.L_ScrollContainer.L_TerrainItem.L_TerrainPreview;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2.ScrollContainer.TerrainItem
    /// </summary>
    public TerrainItem S_TerrainItem => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab2.L_ScrollContainer.L_TerrainItem;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab2
    /// </summary>
    public Tab2 S_Tab2 => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel.MarginContainer.Tab3
    /// </summary>
    public Tab3 S_Tab3 => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel.L_MarginContainer.L_Tab3;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.VBoxContainer.Panel
    /// </summary>
    public Panel S_Panel => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_VBoxContainer.L_Panel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile.MaskBg
    /// </summary>
    public MaskBg S_MaskBg => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile.L_MaskBg;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile.MapEditorMapTile
    /// </summary>
    public MapEditorMapTile S_MapEditorMapTile => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile.L_MapEditorMapTile;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapTile
    /// </summary>
    public MapTile S_MapTile => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapTile;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.HBoxContainer2.LayerOption
    /// </summary>
    public LayerOption S_LayerOption => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapObject.L_MapEditorObject.L_VBoxContainer.L_HBoxContainer2.L_LayerOption;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.ItemRoot.Item.ItemButton.Icon
    /// </summary>
    public Icon S_Icon => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapObject.L_MapEditorObject.L_VBoxContainer.L_ItemRoot.L_Item.L_ItemButton.L_Icon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.ItemRoot.Item.ItemButton
    /// </summary>
    public ItemButton S_ItemButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapObject.L_MapEditorObject.L_VBoxContainer.L_ItemRoot.L_Item.L_ItemButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.ItemRoot.Item
    /// </summary>
    public Item S_Item => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapObject.L_MapEditorObject.L_VBoxContainer.L_ItemRoot.L_Item;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.VBoxContainer.ItemRoot
    /// </summary>
    public ItemRoot S_ItemRoot => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapObject.L_MapEditorObject.L_VBoxContainer.L_ItemRoot;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject.DynamicDeleteButton
    /// </summary>
    public DynamicDeleteButton S_DynamicDeleteButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapObject.L_MapEditorObject.L_DynamicDeleteButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject.MapEditorObject
    /// </summary>
    public MapEditorObject S_MapEditorObject => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapObject.L_MapEditorObject;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapObject
    /// </summary>
    public MapObject S_MapObject => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapObject;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.MarkLabel
    /// </summary>
    public MarkLabel S_MarkLabel => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_MarkLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.HBoxContainer.PreinstallOption
    /// </summary>
    public PreinstallOption S_PreinstallOption => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_HBoxContainer.L_PreinstallOption;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.HBoxContainer.AddPreinstall
    /// </summary>
    public AddPreinstall S_AddPreinstall => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_HBoxContainer.L_AddPreinstall;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.HBoxContainer.EditPreinstall
    /// </summary>
    public EditPreinstall S_EditPreinstall => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_HBoxContainer.L_EditPreinstall;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.HBoxContainer.DeletePreinstall
    /// </summary>
    public DeletePreinstall S_DeletePreinstall => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_HBoxContainer.L_DeletePreinstall;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.MarkLabel2
    /// </summary>
    public MarkLabel2 S_MarkLabel2 => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_MarkLabel2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.DynamicTool.EditButton
    /// </summary>
    public EditButton S_EditButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_DynamicTool.L_EditButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.DynamicTool.DeleteButton
    /// </summary>
    public DeleteButton S_DeleteButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_DynamicTool.L_DeleteButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.DynamicTool
    /// </summary>
    public DynamicTool S_DynamicTool => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_DynamicTool;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.AutoFillTip
    /// </summary>
    public AutoFillTip S_AutoFillTip => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_AutoFillTip;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.AddWaveButton
    /// </summary>
    public AddWaveButton S_AddWaveButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_AddWaveButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.WaveContainer.TextureButton
    /// </summary>
    public TextureButton S_TextureButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_WaveItem.L_WaveContainer.L_TextureButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.WaveContainer.WaveButton
    /// </summary>
    public WaveButton S_WaveButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_WaveItem.L_WaveContainer.L_WaveButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.WaveContainer.WaveVisibleButton
    /// </summary>
    public WaveVisibleButton S_WaveVisibleButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_WaveItem.L_WaveContainer.L_WaveVisibleButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.WaveContainer
    /// </summary>
    public WaveContainer S_WaveContainer => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_WaveItem.L_WaveContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarginContainer.AddMarkButton
    /// </summary>
    public AddMarkButton S_AddMarkButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_WaveItem.L_MarginContainer.L_AddMarkButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarkContainer.MarkItem.MarkButton.MarkIcon
    /// </summary>
    public MarkIcon S_MarkIcon => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_WaveItem.L_MarkContainer.L_MarkItem.L_MarkButton.L_MarkIcon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarkContainer.MarkItem.MarkButton
    /// </summary>
    public MarkButton S_MarkButton => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_WaveItem.L_MarkContainer.L_MarkItem.L_MarkButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarkContainer.MarkItem
    /// </summary>
    public MarkItem S_MarkItem => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_WaveItem.L_MarkContainer.L_MarkItem;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem.MarkContainer
    /// </summary>
    public MarkContainer S_MarkContainer => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_WaveItem.L_MarkContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark.VBoxContainer.ScrollContainer.VBoxContainer.WaveItem
    /// </summary>
    public WaveItem S_WaveItem => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark.L_VBoxContainer.L_ScrollContainer.L_VBoxContainer.L_WaveItem;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark.MapEditorMapMark
    /// </summary>
    public MapEditorMapMark S_MapEditorMapMark => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark.L_MapEditorMapMark;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer.MapMark
    /// </summary>
    public MapMark S_MapMark => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer.L_MapMark;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right.MarginContainer.TabContainer
    /// </summary>
    public TabContainer S_TabContainer => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right.L_MarginContainer.L_TabContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2.Right
    /// </summary>
    public Right S_Right => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2.L_Right;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer.HSplitContainer2
    /// </summary>
    public HSplitContainer2 S_HSplitContainer2 => L_Bg.L_VBoxContainer.L_HSplitContainer.L_HSplitContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg.VBoxContainer.HSplitContainer
    /// </summary>
    public HSplitContainer S_HSplitContainer => L_Bg.L_VBoxContainer.L_HSplitContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditor.Bg
    /// </summary>
    public Bg S_Bg => L_Bg;

}
