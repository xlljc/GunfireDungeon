using DsUi;

namespace UI.game.RoomUI;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class RoomUI : UiBase
{
    /// <summary>
    /// 节点路径: RoomUI.InteractiveTipBar
    /// </summary>
    public InteractiveTipBar L_InteractiveTipBar
    {
        get
        {
            if (_L_InteractiveTipBar == null) _L_InteractiveTipBar = new InteractiveTipBar((RoomUIPanel)this, GetNode<UI.game.RoomUI.InteractiveTipBarHandler>("InteractiveTipBar"));
            return _L_InteractiveTipBar;
        }
    }
    private InteractiveTipBar _L_InteractiveTipBar;

    /// <summary>
    /// 节点路径: RoomUI.ReloadBar
    /// </summary>
    public ReloadBar L_ReloadBar
    {
        get
        {
            if (_L_ReloadBar == null) _L_ReloadBar = new ReloadBar((RoomUIPanel)this, GetNode<UI.game.RoomUI.ReloadBarHandler>("ReloadBar"));
            return _L_ReloadBar;
        }
    }
    private ReloadBar _L_ReloadBar;

    /// <summary>
    /// 节点路径: RoomUI.Control
    /// </summary>
    public Control L_Control
    {
        get
        {
            if (_L_Control == null) _L_Control = new Control((RoomUIPanel)this, GetNode<Godot.Control>("Control"));
            return _L_Control;
        }
    }
    private Control _L_Control;

    /// <summary>
    /// 节点路径: RoomUI.Mask
    /// </summary>
    public Mask L_Mask
    {
        get
        {
            if (_L_Mask == null) _L_Mask = new Mask((RoomUIPanel)this, GetNode<Godot.ColorRect>("Mask"));
            return _L_Mask;
        }
    }
    private Mask _L_Mask;


    public RoomUI() : base(UiManager.UiName.Game_RoomUI)
    {
    }

    public sealed override void OnInitNestedUi()
    {
        _ = L_InteractiveTipBar;
        _ = L_ReloadBar;
        _ = L_Control.L_LifeBar;
        _ = L_Control.L_ActivePropBar;
        _ = L_Control.L_WeaponBar;

    }

    /// <summary>
    /// 路径: RoomUI.InteractiveTipBar.Icon
    /// </summary>
    public class Icon : UiNode<RoomUIPanel, Godot.TextureRect, Icon>
    {
        public Icon(RoomUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override Icon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.InteractiveTipBar.InteractiveIcon
    /// </summary>
    public class InteractiveIcon : UiNode<RoomUIPanel, Godot.TextureRect, InteractiveIcon>
    {
        public InteractiveIcon(RoomUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override InteractiveIcon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.InteractiveTipBar.Line2D
    /// </summary>
    public class Line2D : UiNode<RoomUIPanel, Godot.Line2D, Line2D>
    {
        public Line2D(RoomUIPanel uiPanel, Godot.Line2D node) : base(uiPanel, node) {  }
        public override Line2D Clone() => new (UiPanel, (Godot.Line2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.InteractiveTipBar.NameLabel
    /// </summary>
    public class NameLabel : UiNode<RoomUIPanel, Godot.Label, NameLabel>
    {
        public NameLabel(RoomUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override NameLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.InteractiveTipBar
    /// </summary>
    public class InteractiveTipBar : UiNode<RoomUIPanel, UI.game.RoomUI.InteractiveTipBarHandler, InteractiveTipBar>
    {
        /// <summary>
        /// 节点路径: RoomUI.Icon
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
        /// 节点路径: RoomUI.InteractiveIcon
        /// </summary>
        public InteractiveIcon L_InteractiveIcon
        {
            get
            {
                if (_L_InteractiveIcon == null) _L_InteractiveIcon = new InteractiveIcon(UiPanel, Instance.GetNode<Godot.TextureRect>("InteractiveIcon"));
                return _L_InteractiveIcon;
            }
        }
        private InteractiveIcon _L_InteractiveIcon;

        /// <summary>
        /// 节点路径: RoomUI.Line2D
        /// </summary>
        public Line2D L_Line2D
        {
            get
            {
                if (_L_Line2D == null) _L_Line2D = new Line2D(UiPanel, Instance.GetNode<Godot.Line2D>("Line2D"));
                return _L_Line2D;
            }
        }
        private Line2D _L_Line2D;

        /// <summary>
        /// 节点路径: RoomUI.NameLabel
        /// </summary>
        public NameLabel L_NameLabel
        {
            get
            {
                if (_L_NameLabel == null) _L_NameLabel = new NameLabel(UiPanel, Instance.GetNode<Godot.Label>("NameLabel"));
                return _L_NameLabel;
            }
        }
        private NameLabel _L_NameLabel;

        public InteractiveTipBar(RoomUIPanel uiPanel, UI.game.RoomUI.InteractiveTipBarHandler node) : base(uiPanel, node) {  }
        public override InteractiveTipBar Clone() => new (UiPanel, (UI.game.RoomUI.InteractiveTipBarHandler)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.ReloadBar.Slot.Block
    /// </summary>
    public class Block : UiNode<RoomUIPanel, Godot.Sprite2D, Block>
    {
        public Block(RoomUIPanel uiPanel, Godot.Sprite2D node) : base(uiPanel, node) {  }
        public override Block Clone() => new (UiPanel, (Godot.Sprite2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.ReloadBar.Slot
    /// </summary>
    public class Slot : UiNode<RoomUIPanel, Godot.TextureRect, Slot>
    {
        /// <summary>
        /// 节点路径: RoomUI.ReloadBar.Block
        /// </summary>
        public Block L_Block
        {
            get
            {
                if (_L_Block == null) _L_Block = new Block(UiPanel, Instance.GetNode<Godot.Sprite2D>("Block"));
                return _L_Block;
            }
        }
        private Block _L_Block;

        public Slot(RoomUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override Slot Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.ReloadBar
    /// </summary>
    public class ReloadBar : UiNode<RoomUIPanel, UI.game.RoomUI.ReloadBarHandler, ReloadBar>
    {
        /// <summary>
        /// 节点路径: RoomUI.Slot
        /// </summary>
        public Slot L_Slot
        {
            get
            {
                if (_L_Slot == null) _L_Slot = new Slot(UiPanel, Instance.GetNode<Godot.TextureRect>("Slot"));
                return _L_Slot;
            }
        }
        private Slot _L_Slot;

        public ReloadBar(RoomUIPanel uiPanel, UI.game.RoomUI.ReloadBarHandler node) : base(uiPanel, node) {  }
        public override ReloadBar Clone() => new (UiPanel, (UI.game.RoomUI.ReloadBarHandler)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Life.VBoxContainer.ShieldContainer.TextureRect
    /// </summary>
    public class TextureRect : UiNode<RoomUIPanel, Godot.TextureRect, TextureRect>
    {
        public TextureRect(RoomUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override TextureRect Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Life.VBoxContainer.ShieldContainer.ShieldProgressBar.Number
    /// </summary>
    public class Number : UiNode<RoomUIPanel, Godot.Label, Number>
    {
        public Number(RoomUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Number Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Life.VBoxContainer.ShieldContainer.ShieldProgressBar
    /// </summary>
    public class ShieldProgressBar : UiNode<RoomUIPanel, CommProgressBar, ShieldProgressBar>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.LifeBar.Life.VBoxContainer.ShieldContainer.Number
        /// </summary>
        public Number L_Number
        {
            get
            {
                if (_L_Number == null) _L_Number = new Number(UiPanel, Instance.GetNode<Godot.Label>("Number"));
                return _L_Number;
            }
        }
        private Number _L_Number;

        public ShieldProgressBar(RoomUIPanel uiPanel, CommProgressBar node) : base(uiPanel, node) {  }
        public override ShieldProgressBar Clone() => new (UiPanel, (CommProgressBar)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Life.VBoxContainer.ShieldContainer
    /// </summary>
    public class ShieldContainer : UiNode<RoomUIPanel, Godot.HBoxContainer, ShieldContainer>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.LifeBar.Life.VBoxContainer.TextureRect
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

        /// <summary>
        /// 节点路径: RoomUI.Control.LifeBar.Life.VBoxContainer.ShieldProgressBar
        /// </summary>
        public ShieldProgressBar L_ShieldProgressBar
        {
            get
            {
                if (_L_ShieldProgressBar == null) _L_ShieldProgressBar = new ShieldProgressBar(UiPanel, Instance.GetNode<CommProgressBar>("ShieldProgressBar"));
                return _L_ShieldProgressBar;
            }
        }
        private ShieldProgressBar _L_ShieldProgressBar;

        public ShieldContainer(RoomUIPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override ShieldContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Life.VBoxContainer.LifeContainer.TextureRect
    /// </summary>
    public class TextureRect_1 : UiNode<RoomUIPanel, Godot.TextureRect, TextureRect_1>
    {
        public TextureRect_1(RoomUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override TextureRect_1 Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Life.VBoxContainer.LifeContainer.LifeProgressBar.Number
    /// </summary>
    public class Number_1 : UiNode<RoomUIPanel, Godot.Label, Number_1>
    {
        public Number_1(RoomUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Number_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Life.VBoxContainer.LifeContainer.LifeProgressBar
    /// </summary>
    public class LifeProgressBar : UiNode<RoomUIPanel, CommProgressBar, LifeProgressBar>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.LifeBar.Life.VBoxContainer.LifeContainer.Number
        /// </summary>
        public Number_1 L_Number
        {
            get
            {
                if (_L_Number == null) _L_Number = new Number_1(UiPanel, Instance.GetNode<Godot.Label>("Number"));
                return _L_Number;
            }
        }
        private Number_1 _L_Number;

        public LifeProgressBar(RoomUIPanel uiPanel, CommProgressBar node) : base(uiPanel, node) {  }
        public override LifeProgressBar Clone() => new (UiPanel, (CommProgressBar)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Life.VBoxContainer.LifeContainer
    /// </summary>
    public class LifeContainer : UiNode<RoomUIPanel, Godot.HBoxContainer, LifeContainer>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.LifeBar.Life.VBoxContainer.TextureRect
        /// </summary>
        public TextureRect_1 L_TextureRect
        {
            get
            {
                if (_L_TextureRect == null) _L_TextureRect = new TextureRect_1(UiPanel, Instance.GetNode<Godot.TextureRect>("TextureRect"));
                return _L_TextureRect;
            }
        }
        private TextureRect_1 _L_TextureRect;

        /// <summary>
        /// 节点路径: RoomUI.Control.LifeBar.Life.VBoxContainer.LifeProgressBar
        /// </summary>
        public LifeProgressBar L_LifeProgressBar
        {
            get
            {
                if (_L_LifeProgressBar == null) _L_LifeProgressBar = new LifeProgressBar(UiPanel, Instance.GetNode<CommProgressBar>("LifeProgressBar"));
                return _L_LifeProgressBar;
            }
        }
        private LifeProgressBar _L_LifeProgressBar;

        public LifeContainer(RoomUIPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override LifeContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Life.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<RoomUIPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.LifeBar.Life.ShieldContainer
        /// </summary>
        public ShieldContainer L_ShieldContainer
        {
            get
            {
                if (_L_ShieldContainer == null) _L_ShieldContainer = new ShieldContainer(UiPanel, Instance.GetNode<Godot.HBoxContainer>("ShieldContainer"));
                return _L_ShieldContainer;
            }
        }
        private ShieldContainer _L_ShieldContainer;

        /// <summary>
        /// 节点路径: RoomUI.Control.LifeBar.Life.LifeContainer
        /// </summary>
        public LifeContainer L_LifeContainer
        {
            get
            {
                if (_L_LifeContainer == null) _L_LifeContainer = new LifeContainer(UiPanel, Instance.GetNode<Godot.HBoxContainer>("LifeContainer"));
                return _L_LifeContainer;
            }
        }
        private LifeContainer _L_LifeContainer;

        public VBoxContainer(RoomUIPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Life
    /// </summary>
    public class Life : UiNode<RoomUIPanel, Godot.Control, Life>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.LifeBar.VBoxContainer
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

        public Life(RoomUIPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Life Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Gold.GoldIcon
    /// </summary>
    public class GoldIcon : UiNode<RoomUIPanel, Godot.TextureRect, GoldIcon>
    {
        public GoldIcon(RoomUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override GoldIcon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Gold.GoldText
    /// </summary>
    public class GoldText : UiNode<RoomUIPanel, Godot.Label, GoldText>
    {
        public GoldText(RoomUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override GoldText Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Gold
    /// </summary>
    public class Gold : UiNode<RoomUIPanel, Godot.Control, Gold>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.LifeBar.GoldIcon
        /// </summary>
        public GoldIcon L_GoldIcon
        {
            get
            {
                if (_L_GoldIcon == null) _L_GoldIcon = new GoldIcon(UiPanel, Instance.GetNode<Godot.TextureRect>("GoldIcon"));
                return _L_GoldIcon;
            }
        }
        private GoldIcon _L_GoldIcon;

        /// <summary>
        /// 节点路径: RoomUI.Control.LifeBar.GoldText
        /// </summary>
        public GoldText L_GoldText
        {
            get
            {
                if (_L_GoldText == null) _L_GoldText = new GoldText(UiPanel, Instance.GetNode<Godot.Label>("GoldText"));
                return _L_GoldText;
            }
        }
        private GoldText _L_GoldText;

        public Gold(RoomUIPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Gold Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar
    /// </summary>
    public class LifeBar : UiNode<RoomUIPanel, UI.game.RoomUI.LifeBarHandler, LifeBar>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.Life
        /// </summary>
        public Life L_Life
        {
            get
            {
                if (_L_Life == null) _L_Life = new Life(UiPanel, Instance.GetNode<Godot.Control>("Life"));
                return _L_Life;
            }
        }
        private Life _L_Life;

        /// <summary>
        /// 节点路径: RoomUI.Control.Gold
        /// </summary>
        public Gold L_Gold
        {
            get
            {
                if (_L_Gold == null) _L_Gold = new Gold(UiPanel, Instance.GetNode<Godot.Control>("Gold"));
                return _L_Gold;
            }
        }
        private Gold _L_Gold;

        public LifeBar(RoomUIPanel uiPanel, UI.game.RoomUI.LifeBarHandler node) : base(uiPanel, node) {  }
        public override LifeBar Clone() => new (UiPanel, (UI.game.RoomUI.LifeBarHandler)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.ActivePropBar.ActivePropBg
    /// </summary>
    public class ActivePropBg : UiNode<RoomUIPanel, Godot.NinePatchRect, ActivePropBg>
    {
        public ActivePropBg(RoomUIPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override ActivePropBg Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.ActivePropBar.ActivePropSprite
    /// </summary>
    public class ActivePropSprite : UiNode<RoomUIPanel, Godot.TextureRect, ActivePropSprite>
    {
        public ActivePropSprite(RoomUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override ActivePropSprite Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.ActivePropBar.CooldownProgress
    /// </summary>
    public class CooldownProgress : UiNode<RoomUIPanel, Godot.Sprite2D, CooldownProgress>
    {
        public CooldownProgress(RoomUIPanel uiPanel, Godot.Sprite2D node) : base(uiPanel, node) {  }
        public override CooldownProgress Clone() => new (UiPanel, (Godot.Sprite2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.ActivePropBar.ActivePropCount
    /// </summary>
    public class ActivePropCount : UiNode<RoomUIPanel, Godot.Label, ActivePropCount>
    {
        public ActivePropCount(RoomUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override ActivePropCount Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.ActivePropBar.ActivePropPanel
    /// </summary>
    public class ActivePropPanel : UiNode<RoomUIPanel, Godot.NinePatchRect, ActivePropPanel>
    {
        public ActivePropPanel(RoomUIPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override ActivePropPanel Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.ActivePropBar.ChargeProgressBar
    /// </summary>
    public class ChargeProgressBar : UiNode<RoomUIPanel, Godot.NinePatchRect, ChargeProgressBar>
    {
        public ChargeProgressBar(RoomUIPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override ChargeProgressBar Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.ActivePropBar.ChargeProgress
    /// </summary>
    public class ChargeProgress : UiNode<RoomUIPanel, Godot.Sprite2D, ChargeProgress>
    {
        public ChargeProgress(RoomUIPanel uiPanel, Godot.Sprite2D node) : base(uiPanel, node) {  }
        public override ChargeProgress Clone() => new (UiPanel, (Godot.Sprite2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.ActivePropBar
    /// </summary>
    public class ActivePropBar : UiNode<RoomUIPanel, UI.game.RoomUI.ActivePropBarHandler, ActivePropBar>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.ActivePropBg
        /// </summary>
        public ActivePropBg L_ActivePropBg
        {
            get
            {
                if (_L_ActivePropBg == null) _L_ActivePropBg = new ActivePropBg(UiPanel, Instance.GetNode<Godot.NinePatchRect>("ActivePropBg"));
                return _L_ActivePropBg;
            }
        }
        private ActivePropBg _L_ActivePropBg;

        /// <summary>
        /// 节点路径: RoomUI.Control.ActivePropSprite
        /// </summary>
        public ActivePropSprite L_ActivePropSprite
        {
            get
            {
                if (_L_ActivePropSprite == null) _L_ActivePropSprite = new ActivePropSprite(UiPanel, Instance.GetNode<Godot.TextureRect>("ActivePropSprite"));
                return _L_ActivePropSprite;
            }
        }
        private ActivePropSprite _L_ActivePropSprite;

        /// <summary>
        /// 节点路径: RoomUI.Control.CooldownProgress
        /// </summary>
        public CooldownProgress L_CooldownProgress
        {
            get
            {
                if (_L_CooldownProgress == null) _L_CooldownProgress = new CooldownProgress(UiPanel, Instance.GetNode<Godot.Sprite2D>("CooldownProgress"));
                return _L_CooldownProgress;
            }
        }
        private CooldownProgress _L_CooldownProgress;

        /// <summary>
        /// 节点路径: RoomUI.Control.ActivePropCount
        /// </summary>
        public ActivePropCount L_ActivePropCount
        {
            get
            {
                if (_L_ActivePropCount == null) _L_ActivePropCount = new ActivePropCount(UiPanel, Instance.GetNode<Godot.Label>("ActivePropCount"));
                return _L_ActivePropCount;
            }
        }
        private ActivePropCount _L_ActivePropCount;

        /// <summary>
        /// 节点路径: RoomUI.Control.ActivePropPanel
        /// </summary>
        public ActivePropPanel L_ActivePropPanel
        {
            get
            {
                if (_L_ActivePropPanel == null) _L_ActivePropPanel = new ActivePropPanel(UiPanel, Instance.GetNode<Godot.NinePatchRect>("ActivePropPanel"));
                return _L_ActivePropPanel;
            }
        }
        private ActivePropPanel _L_ActivePropPanel;

        /// <summary>
        /// 节点路径: RoomUI.Control.ChargeProgressBar
        /// </summary>
        public ChargeProgressBar L_ChargeProgressBar
        {
            get
            {
                if (_L_ChargeProgressBar == null) _L_ChargeProgressBar = new ChargeProgressBar(UiPanel, Instance.GetNode<Godot.NinePatchRect>("ChargeProgressBar"));
                return _L_ChargeProgressBar;
            }
        }
        private ChargeProgressBar _L_ChargeProgressBar;

        /// <summary>
        /// 节点路径: RoomUI.Control.ChargeProgress
        /// </summary>
        public ChargeProgress L_ChargeProgress
        {
            get
            {
                if (_L_ChargeProgress == null) _L_ChargeProgress = new ChargeProgress(UiPanel, Instance.GetNode<Godot.Sprite2D>("ChargeProgress"));
                return _L_ChargeProgress;
            }
        }
        private ChargeProgress _L_ChargeProgress;

        public ActivePropBar(RoomUIPanel uiPanel, UI.game.RoomUI.ActivePropBarHandler node) : base(uiPanel, node) {  }
        public override ActivePropBar Clone() => new (UiPanel, (UI.game.RoomUI.ActivePropBarHandler)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.WeaponBar.BufferManaProgress.Number
    /// </summary>
    public class Number_2 : UiNode<RoomUIPanel, Godot.Label, Number_2>
    {
        public Number_2(RoomUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Number_2 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.WeaponBar.BufferManaProgress
    /// </summary>
    public class BufferManaProgress : UiNode<RoomUIPanel, CommProgressBar, BufferManaProgress>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.WeaponBar.Number
        /// </summary>
        public Number_2 L_Number
        {
            get
            {
                if (_L_Number == null) _L_Number = new Number_2(UiPanel, Instance.GetNode<Godot.Label>("Number"));
                return _L_Number;
            }
        }
        private Number_2 _L_Number;

        public BufferManaProgress(RoomUIPanel uiPanel, CommProgressBar node) : base(uiPanel, node) {  }
        public override BufferManaProgress Clone() => new (UiPanel, (CommProgressBar)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.WeaponBar.WeaponPanel.WeaponSprite
    /// </summary>
    public class WeaponSprite : UiNode<RoomUIPanel, Godot.TextureRect, WeaponSprite>
    {
        public WeaponSprite(RoomUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override WeaponSprite Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.WeaponBar.WeaponPanel
    /// </summary>
    public class WeaponPanel : UiNode<RoomUIPanel, Godot.NinePatchRect, WeaponPanel>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.WeaponBar.WeaponSprite
        /// </summary>
        public WeaponSprite L_WeaponSprite
        {
            get
            {
                if (_L_WeaponSprite == null) _L_WeaponSprite = new WeaponSprite(UiPanel, Instance.GetNode<Godot.TextureRect>("WeaponSprite"));
                return _L_WeaponSprite;
            }
        }
        private WeaponSprite _L_WeaponSprite;

        public WeaponPanel(RoomUIPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override WeaponPanel Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.WeaponBar.ManaProgress.Number
    /// </summary>
    public class Number_3 : UiNode<RoomUIPanel, Godot.Label, Number_3>
    {
        public Number_3(RoomUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Number_3 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.WeaponBar.ManaProgress
    /// </summary>
    public class ManaProgress : UiNode<RoomUIPanel, CommProgressBar, ManaProgress>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.WeaponBar.Number
        /// </summary>
        public Number_3 L_Number
        {
            get
            {
                if (_L_Number == null) _L_Number = new Number_3(UiPanel, Instance.GetNode<Godot.Label>("Number"));
                return _L_Number;
            }
        }
        private Number_3 _L_Number;

        public ManaProgress(RoomUIPanel uiPanel, CommProgressBar node) : base(uiPanel, node) {  }
        public override ManaProgress Clone() => new (UiPanel, (CommProgressBar)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.WeaponBar.ManaIcon
    /// </summary>
    public class ManaIcon : UiNode<RoomUIPanel, Godot.TextureRect, ManaIcon>
    {
        public ManaIcon(RoomUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override ManaIcon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.WeaponBar.VBoxContainer.BulletItem
    /// </summary>
    public class BulletItem : UiNode<RoomUIPanel, Godot.TextureRect, BulletItem>
    {
        public BulletItem(RoomUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override BulletItem Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.WeaponBar.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<RoomUIPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.WeaponBar.BulletItem
        /// </summary>
        public BulletItem L_BulletItem
        {
            get
            {
                if (_L_BulletItem == null) _L_BulletItem = new BulletItem(UiPanel, Instance.GetNode<Godot.TextureRect>("BulletItem"));
                return _L_BulletItem;
            }
        }
        private BulletItem _L_BulletItem;

        public VBoxContainer_1(RoomUIPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.WeaponBar
    /// </summary>
    public class WeaponBar : UiNode<RoomUIPanel, UI.game.RoomUI.WeaponBarHandler, WeaponBar>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.BufferManaProgress
        /// </summary>
        public BufferManaProgress L_BufferManaProgress
        {
            get
            {
                if (_L_BufferManaProgress == null) _L_BufferManaProgress = new BufferManaProgress(UiPanel, Instance.GetNode<CommProgressBar>("BufferManaProgress"));
                return _L_BufferManaProgress;
            }
        }
        private BufferManaProgress _L_BufferManaProgress;

        /// <summary>
        /// 节点路径: RoomUI.Control.WeaponPanel
        /// </summary>
        public WeaponPanel L_WeaponPanel
        {
            get
            {
                if (_L_WeaponPanel == null) _L_WeaponPanel = new WeaponPanel(UiPanel, Instance.GetNode<Godot.NinePatchRect>("WeaponPanel"));
                return _L_WeaponPanel;
            }
        }
        private WeaponPanel _L_WeaponPanel;

        /// <summary>
        /// 节点路径: RoomUI.Control.ManaProgress
        /// </summary>
        public ManaProgress L_ManaProgress
        {
            get
            {
                if (_L_ManaProgress == null) _L_ManaProgress = new ManaProgress(UiPanel, Instance.GetNode<CommProgressBar>("ManaProgress"));
                return _L_ManaProgress;
            }
        }
        private ManaProgress _L_ManaProgress;

        /// <summary>
        /// 节点路径: RoomUI.Control.ManaIcon
        /// </summary>
        public ManaIcon L_ManaIcon
        {
            get
            {
                if (_L_ManaIcon == null) _L_ManaIcon = new ManaIcon(UiPanel, Instance.GetNode<Godot.TextureRect>("ManaIcon"));
                return _L_ManaIcon;
            }
        }
        private ManaIcon _L_ManaIcon;

        /// <summary>
        /// 节点路径: RoomUI.Control.VBoxContainer
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

        public WeaponBar(RoomUIPanel uiPanel, UI.game.RoomUI.WeaponBarHandler node) : base(uiPanel, node) {  }
        public override WeaponBar Clone() => new (UiPanel, (UI.game.RoomUI.WeaponBarHandler)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control
    /// </summary>
    public class Control : UiNode<RoomUIPanel, Godot.Control, Control>
    {
        /// <summary>
        /// 节点路径: RoomUI.LifeBar
        /// </summary>
        public LifeBar L_LifeBar
        {
            get
            {
                if (_L_LifeBar == null) _L_LifeBar = new LifeBar(UiPanel, Instance.GetNode<UI.game.RoomUI.LifeBarHandler>("LifeBar"));
                return _L_LifeBar;
            }
        }
        private LifeBar _L_LifeBar;

        /// <summary>
        /// 节点路径: RoomUI.ActivePropBar
        /// </summary>
        public ActivePropBar L_ActivePropBar
        {
            get
            {
                if (_L_ActivePropBar == null) _L_ActivePropBar = new ActivePropBar(UiPanel, Instance.GetNode<UI.game.RoomUI.ActivePropBarHandler>("ActivePropBar"));
                return _L_ActivePropBar;
            }
        }
        private ActivePropBar _L_ActivePropBar;

        /// <summary>
        /// 节点路径: RoomUI.WeaponBar
        /// </summary>
        public WeaponBar L_WeaponBar
        {
            get
            {
                if (_L_WeaponBar == null) _L_WeaponBar = new WeaponBar(UiPanel, Instance.GetNode<UI.game.RoomUI.WeaponBarHandler>("WeaponBar"));
                return _L_WeaponBar;
            }
        }
        private WeaponBar _L_WeaponBar;

        public Control(RoomUIPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Control Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Mask
    /// </summary>
    public class Mask : UiNode<RoomUIPanel, Godot.ColorRect, Mask>
    {
        public Mask(RoomUIPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override Mask Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.InteractiveTipBar.Icon
    /// </summary>
    public Icon S_Icon => L_InteractiveTipBar.L_Icon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.InteractiveTipBar.InteractiveIcon
    /// </summary>
    public InteractiveIcon S_InteractiveIcon => L_InteractiveTipBar.L_InteractiveIcon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.InteractiveTipBar.Line2D
    /// </summary>
    public Line2D S_Line2D => L_InteractiveTipBar.L_Line2D;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.InteractiveTipBar.NameLabel
    /// </summary>
    public NameLabel S_NameLabel => L_InteractiveTipBar.L_NameLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.InteractiveTipBar
    /// </summary>
    public InteractiveTipBar S_InteractiveTipBar => L_InteractiveTipBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.ReloadBar.Slot.Block
    /// </summary>
    public Block S_Block => L_ReloadBar.L_Slot.L_Block;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.ReloadBar.Slot
    /// </summary>
    public Slot S_Slot => L_ReloadBar.L_Slot;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.ReloadBar
    /// </summary>
    public ReloadBar S_ReloadBar => L_ReloadBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.LifeBar.Life.VBoxContainer.ShieldContainer.ShieldProgressBar
    /// </summary>
    public ShieldProgressBar S_ShieldProgressBar => L_Control.L_LifeBar.L_Life.L_VBoxContainer.L_ShieldContainer.L_ShieldProgressBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.LifeBar.Life.VBoxContainer.ShieldContainer
    /// </summary>
    public ShieldContainer S_ShieldContainer => L_Control.L_LifeBar.L_Life.L_VBoxContainer.L_ShieldContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.LifeBar.Life.VBoxContainer.LifeContainer.LifeProgressBar
    /// </summary>
    public LifeProgressBar S_LifeProgressBar => L_Control.L_LifeBar.L_Life.L_VBoxContainer.L_LifeContainer.L_LifeProgressBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.LifeBar.Life.VBoxContainer.LifeContainer
    /// </summary>
    public LifeContainer S_LifeContainer => L_Control.L_LifeBar.L_Life.L_VBoxContainer.L_LifeContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.LifeBar.Life
    /// </summary>
    public Life S_Life => L_Control.L_LifeBar.L_Life;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.LifeBar.Gold.GoldIcon
    /// </summary>
    public GoldIcon S_GoldIcon => L_Control.L_LifeBar.L_Gold.L_GoldIcon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.LifeBar.Gold.GoldText
    /// </summary>
    public GoldText S_GoldText => L_Control.L_LifeBar.L_Gold.L_GoldText;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.LifeBar.Gold
    /// </summary>
    public Gold S_Gold => L_Control.L_LifeBar.L_Gold;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.LifeBar
    /// </summary>
    public LifeBar S_LifeBar => L_Control.L_LifeBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.ActivePropBar.ActivePropBg
    /// </summary>
    public ActivePropBg S_ActivePropBg => L_Control.L_ActivePropBar.L_ActivePropBg;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.ActivePropBar.ActivePropSprite
    /// </summary>
    public ActivePropSprite S_ActivePropSprite => L_Control.L_ActivePropBar.L_ActivePropSprite;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.ActivePropBar.CooldownProgress
    /// </summary>
    public CooldownProgress S_CooldownProgress => L_Control.L_ActivePropBar.L_CooldownProgress;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.ActivePropBar.ActivePropCount
    /// </summary>
    public ActivePropCount S_ActivePropCount => L_Control.L_ActivePropBar.L_ActivePropCount;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.ActivePropBar.ActivePropPanel
    /// </summary>
    public ActivePropPanel S_ActivePropPanel => L_Control.L_ActivePropBar.L_ActivePropPanel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.ActivePropBar.ChargeProgressBar
    /// </summary>
    public ChargeProgressBar S_ChargeProgressBar => L_Control.L_ActivePropBar.L_ChargeProgressBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.ActivePropBar.ChargeProgress
    /// </summary>
    public ChargeProgress S_ChargeProgress => L_Control.L_ActivePropBar.L_ChargeProgress;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.ActivePropBar
    /// </summary>
    public ActivePropBar S_ActivePropBar => L_Control.L_ActivePropBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.WeaponBar.BufferManaProgress
    /// </summary>
    public BufferManaProgress S_BufferManaProgress => L_Control.L_WeaponBar.L_BufferManaProgress;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.WeaponBar.WeaponPanel.WeaponSprite
    /// </summary>
    public WeaponSprite S_WeaponSprite => L_Control.L_WeaponBar.L_WeaponPanel.L_WeaponSprite;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.WeaponBar.WeaponPanel
    /// </summary>
    public WeaponPanel S_WeaponPanel => L_Control.L_WeaponBar.L_WeaponPanel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.WeaponBar.ManaProgress
    /// </summary>
    public ManaProgress S_ManaProgress => L_Control.L_WeaponBar.L_ManaProgress;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.WeaponBar.ManaIcon
    /// </summary>
    public ManaIcon S_ManaIcon => L_Control.L_WeaponBar.L_ManaIcon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.WeaponBar.VBoxContainer.BulletItem
    /// </summary>
    public BulletItem S_BulletItem => L_Control.L_WeaponBar.L_VBoxContainer.L_BulletItem;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.WeaponBar
    /// </summary>
    public WeaponBar S_WeaponBar => L_Control.L_WeaponBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control
    /// </summary>
    public Control S_Control => L_Control;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Mask
    /// </summary>
    public Mask S_Mask => L_Mask;

}
