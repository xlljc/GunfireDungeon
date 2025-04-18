using DsUi;

namespace UI.editor.MapEditorObject;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class MapEditorObject : UiBase
{
    /// <summary>
    /// 节点路径: MapEditorObject.VBoxContainer
    /// </summary>
    public VBoxContainer L_VBoxContainer
    {
        get
        {
            if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer((MapEditorObjectPanel)this, GetNode<Godot.VBoxContainer>("VBoxContainer"));
            return _L_VBoxContainer;
        }
    }
    private VBoxContainer _L_VBoxContainer;

    /// <summary>
    /// 节点路径: MapEditorObject.DynamicDeleteButton
    /// </summary>
    public DynamicDeleteButton L_DynamicDeleteButton
    {
        get
        {
            if (_L_DynamicDeleteButton == null) _L_DynamicDeleteButton = new DynamicDeleteButton((MapEditorObjectPanel)this, GetNode<Godot.Button>("DynamicDeleteButton"));
            return _L_DynamicDeleteButton;
        }
    }
    private DynamicDeleteButton _L_DynamicDeleteButton;


    public MapEditorObject() : base(UiManager.UiName.Editor_MapEditorObject)
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: MapEditorObject.VBoxContainer.HBoxContainer.SearchInput
    /// </summary>
    public class SearchInput : UiNode<MapEditorObjectPanel, Godot.LineEdit, SearchInput>
    {
        public SearchInput(MapEditorObjectPanel uiPanel, Godot.LineEdit node) : base(uiPanel, node) {  }
        public override SearchInput Clone() => new (UiPanel, (Godot.LineEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorObject.VBoxContainer.HBoxContainer.SearchButton
    /// </summary>
    public class SearchButton : UiNode<MapEditorObjectPanel, Godot.Button, SearchButton>
    {
        public SearchButton(MapEditorObjectPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override SearchButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorObject.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<MapEditorObjectPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 节点路径: MapEditorObject.VBoxContainer.SearchInput
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
        /// 节点路径: MapEditorObject.VBoxContainer.SearchButton
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

        public HBoxContainer(MapEditorObjectPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorObject.VBoxContainer.HBoxContainer2.Label
    /// </summary>
    public class Label : UiNode<MapEditorObjectPanel, Godot.Label, Label>
    {
        public Label(MapEditorObjectPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorObject.VBoxContainer.HBoxContainer2.LayerOption
    /// </summary>
    public class LayerOption : UiNode<MapEditorObjectPanel, Godot.OptionButton, LayerOption>
    {
        public LayerOption(MapEditorObjectPanel uiPanel, Godot.OptionButton node) : base(uiPanel, node) {  }
        public override LayerOption Clone() => new (UiPanel, (Godot.OptionButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorObject.VBoxContainer.HBoxContainer2
    /// </summary>
    public class HBoxContainer2 : UiNode<MapEditorObjectPanel, Godot.HBoxContainer, HBoxContainer2>
    {
        /// <summary>
        /// 节点路径: MapEditorObject.VBoxContainer.Label
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
        /// 节点路径: MapEditorObject.VBoxContainer.LayerOption
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

        public HBoxContainer2(MapEditorObjectPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer2 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorObject.VBoxContainer.ItemRoot.Item.ItemButton.Icon
    /// </summary>
    public class Icon : UiNode<MapEditorObjectPanel, Godot.TextureRect, Icon>
    {
        public Icon(MapEditorObjectPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override Icon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorObject.VBoxContainer.ItemRoot.Item.ItemButton.Select
    /// </summary>
    public class Select : UiNode<MapEditorObjectPanel, Godot.NinePatchRect, Select>
    {
        public Select(MapEditorObjectPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override Select Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorObject.VBoxContainer.ItemRoot.Item.ItemButton
    /// </summary>
    public class ItemButton : UiNode<MapEditorObjectPanel, Godot.Button, ItemButton>
    {
        /// <summary>
        /// 节点路径: MapEditorObject.VBoxContainer.ItemRoot.Item.Icon
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
        /// 节点路径: MapEditorObject.VBoxContainer.ItemRoot.Item.Select
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

        public ItemButton(MapEditorObjectPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ItemButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorObject.VBoxContainer.ItemRoot.Item
    /// </summary>
    public class Item : UiNode<MapEditorObjectPanel, Godot.HBoxContainer, Item>
    {
        /// <summary>
        /// 节点路径: MapEditorObject.VBoxContainer.ItemRoot.ItemButton
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

        public Item(MapEditorObjectPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override Item Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorObject.VBoxContainer.ItemRoot
    /// </summary>
    public class ItemRoot : UiNode<MapEditorObjectPanel, Godot.ScrollContainer, ItemRoot>
    {
        /// <summary>
        /// 节点路径: MapEditorObject.VBoxContainer.Item
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

        public ItemRoot(MapEditorObjectPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ItemRoot Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorObject.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<MapEditorObjectPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 节点路径: MapEditorObject.HBoxContainer
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
        /// 节点路径: MapEditorObject.HBoxContainer2
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
        /// 节点路径: MapEditorObject.ItemRoot
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

        public VBoxContainer(MapEditorObjectPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: MapEditorObject.DynamicDeleteButton
    /// </summary>
    public class DynamicDeleteButton : UiNode<MapEditorObjectPanel, Godot.Button, DynamicDeleteButton>
    {
        public DynamicDeleteButton(MapEditorObjectPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override DynamicDeleteButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorObject.VBoxContainer.HBoxContainer.SearchInput
    /// </summary>
    public SearchInput S_SearchInput => L_VBoxContainer.L_HBoxContainer.L_SearchInput;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorObject.VBoxContainer.HBoxContainer.SearchButton
    /// </summary>
    public SearchButton S_SearchButton => L_VBoxContainer.L_HBoxContainer.L_SearchButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorObject.VBoxContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_VBoxContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorObject.VBoxContainer.HBoxContainer2.Label
    /// </summary>
    public Label S_Label => L_VBoxContainer.L_HBoxContainer2.L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorObject.VBoxContainer.HBoxContainer2.LayerOption
    /// </summary>
    public LayerOption S_LayerOption => L_VBoxContainer.L_HBoxContainer2.L_LayerOption;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorObject.VBoxContainer.HBoxContainer2
    /// </summary>
    public HBoxContainer2 S_HBoxContainer2 => L_VBoxContainer.L_HBoxContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorObject.VBoxContainer.ItemRoot.Item.ItemButton.Icon
    /// </summary>
    public Icon S_Icon => L_VBoxContainer.L_ItemRoot.L_Item.L_ItemButton.L_Icon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorObject.VBoxContainer.ItemRoot.Item.ItemButton.Select
    /// </summary>
    public Select S_Select => L_VBoxContainer.L_ItemRoot.L_Item.L_ItemButton.L_Select;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorObject.VBoxContainer.ItemRoot.Item.ItemButton
    /// </summary>
    public ItemButton S_ItemButton => L_VBoxContainer.L_ItemRoot.L_Item.L_ItemButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorObject.VBoxContainer.ItemRoot.Item
    /// </summary>
    public Item S_Item => L_VBoxContainer.L_ItemRoot.L_Item;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorObject.VBoxContainer.ItemRoot
    /// </summary>
    public ItemRoot S_ItemRoot => L_VBoxContainer.L_ItemRoot;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorObject.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: MapEditorObject.DynamicDeleteButton
    /// </summary>
    public DynamicDeleteButton S_DynamicDeleteButton => L_DynamicDeleteButton;

}
