using DsUi;

namespace UI.MapEditorConfigObject;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class MapEditorConfigObject : UiBase
{
    /// <summary>
    /// 节点路径: MapEditorConfigObject.VBoxContainer
    /// </summary>
    public VBoxContainer L_VBoxContainer
    {
        get
        {
            if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer((MapEditorConfigObjectPanel)this, GetNode<Godot.VBoxContainer>("VBoxContainer"));
            return _L_VBoxContainer;
        }
    }
    private VBoxContainer _L_VBoxContainer;


    public MapEditorConfigObject() : base(nameof(MapEditorConfigObject))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: MapEditorConfigObject.VBoxContainer.HBoxContainer.SearchInput
    /// </summary>
    public class SearchInput : UiNode<MapEditorConfigObjectPanel, Godot.LineEdit, SearchInput>
    {
        public SearchInput(MapEditorConfigObjectPanel uiPanel, Godot.LineEdit node) : base(uiPanel, node) {  }
        public override SearchInput Clone() => new (UiPanel, (Godot.LineEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorConfigObject.VBoxContainer.HBoxContainer.SearchButton
    /// </summary>
    public class SearchButton : UiNode<MapEditorConfigObjectPanel, Godot.Button, SearchButton>
    {
        public SearchButton(MapEditorConfigObjectPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override SearchButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorConfigObject.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<MapEditorConfigObjectPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 节点路径: MapEditorConfigObject.VBoxContainer.SearchInput
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
        /// 节点路径: MapEditorConfigObject.VBoxContainer.SearchButton
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

        public HBoxContainer(MapEditorConfigObjectPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorConfigObject.VBoxContainer.ScrollContainer.CellButton.PreviewImage
    /// </summary>
    public class PreviewImage : UiNode<MapEditorConfigObjectPanel, Godot.TextureRect, PreviewImage>
    {
        public PreviewImage(MapEditorConfigObjectPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override PreviewImage Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorConfigObject.VBoxContainer.ScrollContainer.CellButton.CellName
    /// </summary>
    public class CellName : UiNode<MapEditorConfigObjectPanel, Godot.Label, CellName>
    {
        public CellName(MapEditorConfigObjectPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override CellName Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorConfigObject.VBoxContainer.ScrollContainer.CellButton.SelectTexture
    /// </summary>
    public class SelectTexture : UiNode<MapEditorConfigObjectPanel, Godot.NinePatchRect, SelectTexture>
    {
        public SelectTexture(MapEditorConfigObjectPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override SelectTexture Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorConfigObject.VBoxContainer.ScrollContainer.CellButton
    /// </summary>
    public class CellButton : UiNode<MapEditorConfigObjectPanel, Godot.Button, CellButton>
    {
        /// <summary>
        /// 节点路径: MapEditorConfigObject.VBoxContainer.ScrollContainer.PreviewImage
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
        /// 节点路径: MapEditorConfigObject.VBoxContainer.ScrollContainer.CellName
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
        /// 节点路径: MapEditorConfigObject.VBoxContainer.ScrollContainer.SelectTexture
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

        public CellButton(MapEditorConfigObjectPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CellButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorConfigObject.VBoxContainer.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<MapEditorConfigObjectPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 节点路径: MapEditorConfigObject.VBoxContainer.CellButton
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

        public ScrollContainer(MapEditorConfigObjectPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorConfigObject.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<MapEditorConfigObjectPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 节点路径: MapEditorConfigObject.HBoxContainer
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
        /// 节点路径: MapEditorConfigObject.ScrollContainer
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

        public VBoxContainer(MapEditorConfigObjectPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorConfigObject.VBoxContainer.HBoxContainer.SearchInput
    /// </summary>
    public SearchInput S_SearchInput => L_VBoxContainer.L_HBoxContainer.L_SearchInput;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorConfigObject.VBoxContainer.HBoxContainer.SearchButton
    /// </summary>
    public SearchButton S_SearchButton => L_VBoxContainer.L_HBoxContainer.L_SearchButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorConfigObject.VBoxContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_VBoxContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorConfigObject.VBoxContainer.ScrollContainer.CellButton.PreviewImage
    /// </summary>
    public PreviewImage S_PreviewImage => L_VBoxContainer.L_ScrollContainer.L_CellButton.L_PreviewImage;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorConfigObject.VBoxContainer.ScrollContainer.CellButton.CellName
    /// </summary>
    public CellName S_CellName => L_VBoxContainer.L_ScrollContainer.L_CellButton.L_CellName;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorConfigObject.VBoxContainer.ScrollContainer.CellButton.SelectTexture
    /// </summary>
    public SelectTexture S_SelectTexture => L_VBoxContainer.L_ScrollContainer.L_CellButton.L_SelectTexture;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorConfigObject.VBoxContainer.ScrollContainer.CellButton
    /// </summary>
    public CellButton S_CellButton => L_VBoxContainer.L_ScrollContainer.L_CellButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorConfigObject.VBoxContainer.ScrollContainer
    /// </summary>
    public ScrollContainer S_ScrollContainer => L_VBoxContainer.L_ScrollContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorConfigObject.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_VBoxContainer;

}
