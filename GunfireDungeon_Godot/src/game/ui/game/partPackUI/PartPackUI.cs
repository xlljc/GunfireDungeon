using DsUi;

namespace UI.game.PartPackUI;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class PartPackUI : UiBase
{
    /// <summary>
    /// 节点路径: PartPackUI.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((PartPackUIPanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;

    /// <summary>
    /// 节点路径: PartPackUI.VBoxContainer
    /// </summary>
    public VBoxContainer L_VBoxContainer
    {
        get
        {
            if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer((PartPackUIPanel)this, GetNode<Godot.VBoxContainer>("VBoxContainer"));
            return _L_VBoxContainer;
        }
    }
    private VBoxContainer _L_VBoxContainer;


    public PartPackUI() : base(UiManager.UiName.Game_PartPackUI)
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: PartPackUI.ColorRect
    /// </summary>
    public class ColorRect : UiNode<PartPackUIPanel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(PartPackUIPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.PartBg.Border
    /// </summary>
    public class Border : UiNode<PartPackUIPanel, Godot.NinePatchRect, Border>
    {
        public Border(PartPackUIPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override Border Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.PartBg.PartPackItem.PartIcon
    /// </summary>
    public class PartIcon : UiNode<PartPackUIPanel, Godot.TextureRect, PartIcon>
    {
        public PartIcon(PartPackUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override PartIcon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.PartBg.PartPackItem
    /// </summary>
    public class PartPackItem : UiNode<PartPackUIPanel, Godot.NinePatchRect, PartPackItem>
    {
        /// <summary>
        /// 节点路径: PartPackUI.VBoxContainer.PartBg.PartIcon
        /// </summary>
        public PartIcon L_PartIcon
        {
            get
            {
                if (_L_PartIcon == null) _L_PartIcon = new PartIcon(UiPanel, Instance.GetNode<Godot.TextureRect>("PartIcon"));
                return _L_PartIcon;
            }
        }
        private PartIcon _L_PartIcon;

        public PartPackItem(PartPackUIPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override PartPackItem Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.PartBg
    /// </summary>
    public class PartBg : UiNode<PartPackUIPanel, Godot.MarginContainer, PartBg>
    {
        /// <summary>
        /// 节点路径: PartPackUI.VBoxContainer.Border
        /// </summary>
        public Border L_Border
        {
            get
            {
                if (_L_Border == null) _L_Border = new Border(UiPanel, Instance.GetNode<Godot.NinePatchRect>("Border"));
                return _L_Border;
            }
        }
        private Border _L_Border;

        /// <summary>
        /// 节点路径: PartPackUI.VBoxContainer.PartPackItem
        /// </summary>
        public PartPackItem L_PartPackItem
        {
            get
            {
                if (_L_PartPackItem == null) _L_PartPackItem = new PartPackItem(UiPanel, Instance.GetNode<Godot.NinePatchRect>("PartPackItem"));
                return _L_PartPackItem;
            }
        }
        private PartPackItem _L_PartPackItem;

        public PartBg(PartPackUIPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override PartBg Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.Control.WeaponIcon
    /// </summary>
    public class WeaponIcon : UiNode<PartPackUIPanel, Godot.TextureRect, WeaponIcon>
    {
        public WeaponIcon(PartPackUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override WeaponIcon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.Control
    /// </summary>
    public class Control : UiNode<PartPackUIPanel, Godot.Control, Control>
    {
        /// <summary>
        /// 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.WeaponIcon
        /// </summary>
        public WeaponIcon L_WeaponIcon
        {
            get
            {
                if (_L_WeaponIcon == null) _L_WeaponIcon = new WeaponIcon(UiPanel, Instance.GetNode<Godot.TextureRect>("WeaponIcon"));
                return _L_WeaponIcon;
            }
        }
        private WeaponIcon _L_WeaponIcon;

        public Control(PartPackUIPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Control Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.VBoxContainer.WeaponMana
    /// </summary>
    public class WeaponMana : UiNode<PartPackUIPanel, Godot.Label, WeaponMana>
    {
        public WeaponMana(PartPackUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override WeaponMana Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.VBoxContainer.WeaponBuffMana
    /// </summary>
    public class WeaponBuffMana : UiNode<PartPackUIPanel, Godot.Label, WeaponBuffMana>
    {
        public WeaponBuffMana(PartPackUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override WeaponBuffMana Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.VBoxContainer
    /// </summary>
    public class VBoxContainer_2 : UiNode<PartPackUIPanel, Godot.VBoxContainer, VBoxContainer_2>
    {
        /// <summary>
        /// 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.WeaponMana
        /// </summary>
        public WeaponMana L_WeaponMana
        {
            get
            {
                if (_L_WeaponMana == null) _L_WeaponMana = new WeaponMana(UiPanel, Instance.GetNode<Godot.Label>("WeaponMana"));
                return _L_WeaponMana;
            }
        }
        private WeaponMana _L_WeaponMana;

        /// <summary>
        /// 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.WeaponBuffMana
        /// </summary>
        public WeaponBuffMana L_WeaponBuffMana
        {
            get
            {
                if (_L_WeaponBuffMana == null) _L_WeaponBuffMana = new WeaponBuffMana(UiPanel, Instance.GetNode<Godot.Label>("WeaponBuffMana"));
                return _L_WeaponBuffMana;
            }
        }
        private WeaponBuffMana _L_WeaponBuffMana;

        public VBoxContainer_2(PartPackUIPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_2 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.PartListItem.SubLine
    /// </summary>
    public class SubLine : UiNode<PartPackUIPanel, Godot.ColorRect, SubLine>
    {
        public SubLine(PartPackUIPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override SubLine Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.PartListItem.ListName
    /// </summary>
    public class ListName : UiNode<PartPackUIPanel, Godot.Label, ListName>
    {
        public ListName(PartPackUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override ListName Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.PartListItem
    /// </summary>
    public class PartListItem : UiNode<PartPackUIPanel, Godot.Control, PartListItem>
    {
        /// <summary>
        /// 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.SubLine
        /// </summary>
        public SubLine L_SubLine
        {
            get
            {
                if (_L_SubLine == null) _L_SubLine = new SubLine(UiPanel, Instance.GetNode<Godot.ColorRect>("SubLine"));
                return _L_SubLine;
            }
        }
        private SubLine _L_SubLine;

        /// <summary>
        /// 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.ListName
        /// </summary>
        public ListName L_ListName
        {
            get
            {
                if (_L_ListName == null) _L_ListName = new ListName(UiPanel, Instance.GetNode<Godot.Label>("ListName"));
                return _L_ListName;
            }
        }
        private ListName _L_ListName;

        public PartListItem(PartPackUIPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override PartListItem Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem
    /// </summary>
    public class WeaponItem : UiNode<PartPackUIPanel, Godot.NinePatchRect, WeaponItem>
    {
        /// <summary>
        /// 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.Control
        /// </summary>
        public Control L_Control
        {
            get
            {
                if (_L_Control == null) _L_Control = new Control(UiPanel, Instance.GetNode<Godot.Control>("Control"));
                return _L_Control;
            }
        }
        private Control _L_Control;

        /// <summary>
        /// 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.VBoxContainer
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

        /// <summary>
        /// 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.PartListItem
        /// </summary>
        public PartListItem L_PartListItem
        {
            get
            {
                if (_L_PartListItem == null) _L_PartListItem = new PartListItem(UiPanel, Instance.GetNode<Godot.Control>("PartListItem"));
                return _L_PartListItem;
            }
        }
        private PartListItem _L_PartListItem;

        public WeaponItem(PartPackUIPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override WeaponItem Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<PartPackUIPanel, Godot.ScrollContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 节点路径: PartPackUI.VBoxContainer.WeaponBg.WeaponItem
        /// </summary>
        public WeaponItem L_WeaponItem
        {
            get
            {
                if (_L_WeaponItem == null) _L_WeaponItem = new WeaponItem(UiPanel, Instance.GetNode<Godot.NinePatchRect>("WeaponItem"));
                return _L_WeaponItem;
            }
        }
        private WeaponItem _L_WeaponItem;

        public VBoxContainer_1(PartPackUIPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer.WeaponBg
    /// </summary>
    public class WeaponBg : UiNode<PartPackUIPanel, Godot.MarginContainer, WeaponBg>
    {
        /// <summary>
        /// 节点路径: PartPackUI.VBoxContainer.VBoxContainer
        /// </summary>
        public VBoxContainer_1 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_1(UiPanel, Instance.GetNode<Godot.ScrollContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_1 _L_VBoxContainer;

        public WeaponBg(PartPackUIPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override WeaponBg Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: PartPackUI.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<PartPackUIPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 节点路径: PartPackUI.PartBg
        /// </summary>
        public PartBg L_PartBg
        {
            get
            {
                if (_L_PartBg == null) _L_PartBg = new PartBg(UiPanel, Instance.GetNode<Godot.MarginContainer>("PartBg"));
                return _L_PartBg;
            }
        }
        private PartBg _L_PartBg;

        /// <summary>
        /// 节点路径: PartPackUI.WeaponBg
        /// </summary>
        public WeaponBg L_WeaponBg
        {
            get
            {
                if (_L_WeaponBg == null) _L_WeaponBg = new WeaponBg(UiPanel, Instance.GetNode<Godot.MarginContainer>("WeaponBg"));
                return _L_WeaponBg;
            }
        }
        private WeaponBg _L_WeaponBg;

        public VBoxContainer(PartPackUIPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.VBoxContainer.PartBg.Border
    /// </summary>
    public Border S_Border => L_VBoxContainer.L_PartBg.L_Border;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.VBoxContainer.PartBg.PartPackItem.PartIcon
    /// </summary>
    public PartIcon S_PartIcon => L_VBoxContainer.L_PartBg.L_PartPackItem.L_PartIcon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.VBoxContainer.PartBg.PartPackItem
    /// </summary>
    public PartPackItem S_PartPackItem => L_VBoxContainer.L_PartBg.L_PartPackItem;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.VBoxContainer.PartBg
    /// </summary>
    public PartBg S_PartBg => L_VBoxContainer.L_PartBg;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.Control.WeaponIcon
    /// </summary>
    public WeaponIcon S_WeaponIcon => L_VBoxContainer.L_WeaponBg.L_VBoxContainer.L_WeaponItem.L_Control.L_WeaponIcon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.Control
    /// </summary>
    public Control S_Control => L_VBoxContainer.L_WeaponBg.L_VBoxContainer.L_WeaponItem.L_Control;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.VBoxContainer.WeaponMana
    /// </summary>
    public WeaponMana S_WeaponMana => L_VBoxContainer.L_WeaponBg.L_VBoxContainer.L_WeaponItem.L_VBoxContainer.L_WeaponMana;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.VBoxContainer.WeaponBuffMana
    /// </summary>
    public WeaponBuffMana S_WeaponBuffMana => L_VBoxContainer.L_WeaponBg.L_VBoxContainer.L_WeaponItem.L_VBoxContainer.L_WeaponBuffMana;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.PartListItem.SubLine
    /// </summary>
    public SubLine S_SubLine => L_VBoxContainer.L_WeaponBg.L_VBoxContainer.L_WeaponItem.L_PartListItem.L_SubLine;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.PartListItem.ListName
    /// </summary>
    public ListName S_ListName => L_VBoxContainer.L_WeaponBg.L_VBoxContainer.L_WeaponItem.L_PartListItem.L_ListName;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem.PartListItem
    /// </summary>
    public PartListItem S_PartListItem => L_VBoxContainer.L_WeaponBg.L_VBoxContainer.L_WeaponItem.L_PartListItem;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.VBoxContainer.WeaponBg.VBoxContainer.WeaponItem
    /// </summary>
    public WeaponItem S_WeaponItem => L_VBoxContainer.L_WeaponBg.L_VBoxContainer.L_WeaponItem;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: PartPackUI.VBoxContainer.WeaponBg
    /// </summary>
    public WeaponBg S_WeaponBg => L_VBoxContainer.L_WeaponBg;

}
