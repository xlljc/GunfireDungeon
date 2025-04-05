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
            if (_L_InteractiveTipBar == null) _L_InteractiveTipBar = new InteractiveTipBar((RoomUIPanel)this, GetNode<Godot.Control>("InteractiveTipBar"));
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
            if (_L_ReloadBar == null) _L_ReloadBar = new ReloadBar((RoomUIPanel)this, GetNode<Godot.Control>("ReloadBar"));
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
    /// 节点路径: RoomUI.WeaponRoulette
    /// </summary>
    public WeaponRoulette L_WeaponRoulette
    {
        get
        {
            if (_L_WeaponRoulette == null) _L_WeaponRoulette = new WeaponRoulette((RoomUIPanel)this, GetNode<UI.game.WeaponRoulette.WeaponRoulettePanel>("WeaponRoulette"));
            return _L_WeaponRoulette;
        }
    }
    private WeaponRoulette _L_WeaponRoulette;

    /// <summary>
    /// 节点路径: RoomUI.RoomMap
    /// </summary>
    public RoomMap L_RoomMap
    {
        get
        {
            if (_L_RoomMap == null) _L_RoomMap = new RoomMap((RoomUIPanel)this, GetNode<UI.game.RoomMap.RoomMapPanel>("RoomMap"));
            return _L_RoomMap;
        }
    }
    private RoomMap _L_RoomMap;

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


    public RoomUI() : base(nameof(RoomUI))
    {
    }

    public sealed override void OnInitNestedUi()
    {
        _ = L_WeaponRoulette.L_Root.L_RouletteBg.L_WeaponSlotNode;

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
    public class InteractiveTipBar : UiNode<RoomUIPanel, Godot.Control, InteractiveTipBar>
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

        public InteractiveTipBar(RoomUIPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override InteractiveTipBar Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
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
    public class ReloadBar : UiNode<RoomUIPanel, Godot.Control, ReloadBar>
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

        public ReloadBar(RoomUIPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override ReloadBar Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Life.LifeIcon
    /// </summary>
    public class LifeIcon : UiNode<RoomUIPanel, Godot.TextureRect, LifeIcon>
    {
        public LifeIcon(RoomUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override LifeIcon Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.LifeBar.Life
    /// </summary>
    public class Life : UiNode<RoomUIPanel, Godot.Control, Life>
    {
        /// <summary>
        /// 节点路径: RoomUI.Control.LifeBar.LifeIcon
        /// </summary>
        public LifeIcon L_LifeIcon
        {
            get
            {
                if (_L_LifeIcon == null) _L_LifeIcon = new LifeIcon(UiPanel, Instance.GetNode<Godot.TextureRect>("LifeIcon"));
                return _L_LifeIcon;
            }
        }
        private LifeIcon _L_LifeIcon;

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
    public class LifeBar : UiNode<RoomUIPanel, Godot.VBoxContainer, LifeBar>
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

        public LifeBar(RoomUIPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override LifeBar Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
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
    public class ActivePropBar : UiNode<RoomUIPanel, Godot.Control, ActivePropBar>
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

        public ActivePropBar(RoomUIPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override ActivePropBar Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
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
    /// 路径: RoomUI.Control.WeaponBar.AmmoCount
    /// </summary>
    public class AmmoCount : UiNode<RoomUIPanel, Godot.Label, AmmoCount>
    {
        public AmmoCount(RoomUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override AmmoCount Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.Control.WeaponBar
    /// </summary>
    public class WeaponBar : UiNode<RoomUIPanel, Godot.Control, WeaponBar>
    {
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
        /// 节点路径: RoomUI.Control.AmmoCount
        /// </summary>
        public AmmoCount L_AmmoCount
        {
            get
            {
                if (_L_AmmoCount == null) _L_AmmoCount = new AmmoCount(UiPanel, Instance.GetNode<Godot.Label>("AmmoCount"));
                return _L_AmmoCount;
            }
        }
        private AmmoCount _L_AmmoCount;

        public WeaponBar(RoomUIPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override WeaponBar Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
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
                if (_L_LifeBar == null) _L_LifeBar = new LifeBar(UiPanel, Instance.GetNode<Godot.VBoxContainer>("LifeBar"));
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
                if (_L_ActivePropBar == null) _L_ActivePropBar = new ActivePropBar(UiPanel, Instance.GetNode<Godot.Control>("ActivePropBar"));
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
                if (_L_WeaponBar == null) _L_WeaponBar = new WeaponBar(UiPanel, Instance.GetNode<Godot.Control>("WeaponBar"));
                return _L_WeaponBar;
            }
        }
        private WeaponBar _L_WeaponBar;

        public Control(RoomUIPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Control Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Bg
    /// </summary>
    public class Bg : UiNode<RoomUIPanel, Godot.ColorRect, Bg>
    {
        public Bg(RoomUIPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override Bg Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotUi.WeaponUi.WeaponIcon
    /// </summary>
    public class WeaponIcon : UiNode<RoomUIPanel, Godot.Sprite2D, WeaponIcon>
    {
        public WeaponIcon(RoomUIPanel uiPanel, Godot.Sprite2D node) : base(uiPanel, node) {  }
        public override WeaponIcon Clone() => new (UiPanel, (Godot.Sprite2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotUi.WeaponUi.AmmoLabel
    /// </summary>
    public class AmmoLabel : UiNode<RoomUIPanel, Godot.Label, AmmoLabel>
    {
        public AmmoLabel(RoomUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override AmmoLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotUi.WeaponUi
    /// </summary>
    public class WeaponUi : UiNode<RoomUIPanel, Godot.Control, WeaponUi>
    {
        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotUi.WeaponIcon
        /// </summary>
        public WeaponIcon L_WeaponIcon
        {
            get
            {
                if (_L_WeaponIcon == null) _L_WeaponIcon = new WeaponIcon(UiPanel, Instance.GetNode<Godot.Sprite2D>("WeaponIcon"));
                return _L_WeaponIcon;
            }
        }
        private WeaponIcon _L_WeaponIcon;

        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotUi.AmmoLabel
        /// </summary>
        public AmmoLabel L_AmmoLabel
        {
            get
            {
                if (_L_AmmoLabel == null) _L_AmmoLabel = new AmmoLabel(UiPanel, Instance.GetNode<Godot.Label>("AmmoLabel"));
                return _L_AmmoLabel;
            }
        }
        private AmmoLabel _L_AmmoLabel;

        public WeaponUi(RoomUIPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override WeaponUi Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotUi.LockSprite
    /// </summary>
    public class LockSprite : UiNode<RoomUIPanel, Godot.Sprite2D, LockSprite>
    {
        public LockSprite(RoomUIPanel uiPanel, Godot.Sprite2D node) : base(uiPanel, node) {  }
        public override LockSprite Clone() => new (UiPanel, (Godot.Sprite2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotUi
    /// </summary>
    public class SlotUi : UiNode<RoomUIPanel, Godot.Control, SlotUi>
    {
        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.WeaponUi
        /// </summary>
        public WeaponUi L_WeaponUi
        {
            get
            {
                if (_L_WeaponUi == null) _L_WeaponUi = new WeaponUi(UiPanel, Instance.GetNode<Godot.Control>("WeaponUi"));
                return _L_WeaponUi;
            }
        }
        private WeaponUi _L_WeaponUi;

        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.LockSprite
        /// </summary>
        public LockSprite L_LockSprite
        {
            get
            {
                if (_L_LockSprite == null) _L_LockSprite = new LockSprite(UiPanel, Instance.GetNode<Godot.Sprite2D>("LockSprite"));
                return _L_LockSprite;
            }
        }
        private LockSprite _L_LockSprite;

        public SlotUi(RoomUIPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override SlotUi Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotAreaNode.CollisionPolygon2D
    /// </summary>
    public class CollisionPolygon2D : UiNode<RoomUIPanel, Godot.CollisionPolygon2D, CollisionPolygon2D>
    {
        public CollisionPolygon2D(RoomUIPanel uiPanel, Godot.CollisionPolygon2D node) : base(uiPanel, node) {  }
        public override CollisionPolygon2D Clone() => new (UiPanel, (Godot.CollisionPolygon2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotAreaNode
    /// </summary>
    public class SlotAreaNode : UiNode<RoomUIPanel, Godot.Area2D, SlotAreaNode>
    {
        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.CollisionPolygon2D
        /// </summary>
        public CollisionPolygon2D L_CollisionPolygon2D
        {
            get
            {
                if (_L_CollisionPolygon2D == null) _L_CollisionPolygon2D = new CollisionPolygon2D(UiPanel, Instance.GetNode<Godot.CollisionPolygon2D>("CollisionPolygon2D"));
                return _L_CollisionPolygon2D;
            }
        }
        private CollisionPolygon2D _L_CollisionPolygon2D;

        public SlotAreaNode(RoomUIPanel uiPanel, Godot.Area2D node) : base(uiPanel, node) {  }
        public override SlotAreaNode Clone() => new (UiPanel, (Godot.Area2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode
    /// </summary>
    public class WeaponSlotNode : UiNode<RoomUIPanel, UI.game.WeaponRoulette.WeaponSlot, WeaponSlotNode>
    {
        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.SlotUi
        /// </summary>
        public SlotUi L_SlotUi
        {
            get
            {
                if (_L_SlotUi == null) _L_SlotUi = new SlotUi(UiPanel, Instance.GetNode<Godot.Control>("SlotUi"));
                return _L_SlotUi;
            }
        }
        private SlotUi _L_SlotUi;

        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.SlotAreaNode
        /// </summary>
        public SlotAreaNode L_SlotAreaNode
        {
            get
            {
                if (_L_SlotAreaNode == null) _L_SlotAreaNode = new SlotAreaNode(UiPanel, Instance.GetNode<Godot.Area2D>("SlotAreaNode"));
                return _L_SlotAreaNode;
            }
        }
        private SlotAreaNode _L_SlotAreaNode;

        public WeaponSlotNode(RoomUIPanel uiPanel, UI.game.WeaponRoulette.WeaponSlot node) : base(uiPanel, node) {  }
        public override WeaponSlotNode Clone() => new (UiPanel, (UI.game.WeaponRoulette.WeaponSlot)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.RouletteBg
    /// </summary>
    public class RouletteBg : UiNode<RoomUIPanel, Godot.Sprite2D, RouletteBg>
    {
        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.Root.WeaponSlotNode
        /// </summary>
        public WeaponSlotNode L_WeaponSlotNode
        {
            get
            {
                if (_L_WeaponSlotNode == null) _L_WeaponSlotNode = new WeaponSlotNode(UiPanel, Instance.GetNode<UI.game.WeaponRoulette.WeaponSlot>("WeaponSlotNode"));
                return _L_WeaponSlotNode;
            }
        }
        private WeaponSlotNode _L_WeaponSlotNode;

        public RouletteBg(RoomUIPanel uiPanel, Godot.Sprite2D node) : base(uiPanel, node) {  }
        public override RouletteBg Clone() => new (UiPanel, (Godot.Sprite2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.UpBar.Label
    /// </summary>
    public class Label : UiNode<RoomUIPanel, Godot.Label, Label>
    {
        public Label(RoomUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.UpBar.Label2
    /// </summary>
    public class Label2 : UiNode<RoomUIPanel, Godot.Label, Label2>
    {
        public Label2(RoomUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label2 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.UpBar.PageLabel
    /// </summary>
    public class PageLabel : UiNode<RoomUIPanel, Godot.Label, PageLabel>
    {
        public PageLabel(RoomUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override PageLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.UpBar
    /// </summary>
    public class UpBar : UiNode<RoomUIPanel, Godot.ColorRect, UpBar>
    {
        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.Root.Label
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
        /// 节点路径: RoomUI.game.WeaponRoulette.Root.Label2
        /// </summary>
        public Label2 L_Label2
        {
            get
            {
                if (_L_Label2 == null) _L_Label2 = new Label2(UiPanel, Instance.GetNode<Godot.Label>("Label2"));
                return _L_Label2;
            }
        }
        private Label2 _L_Label2;

        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.Root.PageLabel
        /// </summary>
        public PageLabel L_PageLabel
        {
            get
            {
                if (_L_PageLabel == null) _L_PageLabel = new PageLabel(UiPanel, Instance.GetNode<Godot.Label>("PageLabel"));
                return _L_PageLabel;
            }
        }
        private PageLabel _L_PageLabel;

        public UpBar(RoomUIPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override UpBar Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.DownBar.Label
    /// </summary>
    public class Label_1 : UiNode<RoomUIPanel, Godot.Label, Label_1>
    {
        public Label_1(RoomUIPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root.DownBar
    /// </summary>
    public class DownBar : UiNode<RoomUIPanel, Godot.ColorRect, DownBar>
    {
        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.Root.Label
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

        public DownBar(RoomUIPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override DownBar Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.Root
    /// </summary>
    public class Root : UiNode<RoomUIPanel, Godot.Control, Root>
    {
        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.RouletteBg
        /// </summary>
        public RouletteBg L_RouletteBg
        {
            get
            {
                if (_L_RouletteBg == null) _L_RouletteBg = new RouletteBg(UiPanel, Instance.GetNode<Godot.Sprite2D>("RouletteBg"));
                return _L_RouletteBg;
            }
        }
        private RouletteBg _L_RouletteBg;

        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.UpBar
        /// </summary>
        public UpBar L_UpBar
        {
            get
            {
                if (_L_UpBar == null) _L_UpBar = new UpBar(UiPanel, Instance.GetNode<Godot.ColorRect>("UpBar"));
                return _L_UpBar;
            }
        }
        private UpBar _L_UpBar;

        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.DownBar
        /// </summary>
        public DownBar L_DownBar
        {
            get
            {
                if (_L_DownBar == null) _L_DownBar = new DownBar(UiPanel, Instance.GetNode<Godot.ColorRect>("DownBar"));
                return _L_DownBar;
            }
        }
        private DownBar _L_DownBar;

        public Root(RoomUIPanel uiPanel, Godot.Control node) : base(uiPanel, node) {  }
        public override Root Clone() => new (UiPanel, (Godot.Control)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.MouseArea.CollisionShape2D
    /// </summary>
    public class CollisionShape2D : UiNode<RoomUIPanel, Godot.CollisionShape2D, CollisionShape2D>
    {
        public CollisionShape2D(RoomUIPanel uiPanel, Godot.CollisionShape2D node) : base(uiPanel, node) {  }
        public override CollisionShape2D Clone() => new (UiPanel, (Godot.CollisionShape2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.WeaponRoulette.MouseArea
    /// </summary>
    public class MouseArea : UiNode<RoomUIPanel, Godot.Area2D, MouseArea>
    {
        /// <summary>
        /// 节点路径: RoomUI.game.WeaponRoulette.CollisionShape2D
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

        public MouseArea(RoomUIPanel uiPanel, Godot.Area2D node) : base(uiPanel, node) {  }
        public override MouseArea Clone() => new (UiPanel, (Godot.Area2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.WeaponRoulette
    /// </summary>
    public class WeaponRoulette : UiNode<RoomUIPanel, UI.game.WeaponRoulette.WeaponRoulettePanel, WeaponRoulette>
    {
        /// <summary>
        /// 节点路径: RoomUI.Bg
        /// </summary>
        public Bg L_Bg
        {
            get
            {
                if (_L_Bg == null) _L_Bg = new Bg(UiPanel, Instance.GetNode<Godot.ColorRect>("Bg"));
                return _L_Bg;
            }
        }
        private Bg _L_Bg;

        /// <summary>
        /// 节点路径: RoomUI.Root
        /// </summary>
        public Root L_Root
        {
            get
            {
                if (_L_Root == null) _L_Root = new Root(UiPanel, Instance.GetNode<Godot.Control>("Root"));
                return _L_Root;
            }
        }
        private Root _L_Root;

        /// <summary>
        /// 节点路径: RoomUI.MouseArea
        /// </summary>
        public MouseArea L_MouseArea
        {
            get
            {
                if (_L_MouseArea == null) _L_MouseArea = new MouseArea(UiPanel, Instance.GetNode<Godot.Area2D>("MouseArea"));
                return _L_MouseArea;
            }
        }
        private MouseArea _L_MouseArea;

        public WeaponRoulette(RoomUIPanel uiPanel, UI.game.WeaponRoulette.WeaponRoulettePanel node) : base(uiPanel, node) {  }
        public override WeaponRoulette Clone() => new (UiPanel, (UI.game.WeaponRoulette.WeaponRoulettePanel)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.RoomMap.Bg
    /// </summary>
    public class Bg_1 : UiNode<RoomUIPanel, Godot.ColorRect, Bg_1>
    {
        public Bg_1(RoomUIPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override Bg_1 Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.RoomMap.MapBar.DrawContainer.Root
    /// </summary>
    public class Root_1 : UiNode<RoomUIPanel, Godot.Node2D, Root_1>
    {
        public Root_1(RoomUIPanel uiPanel, Godot.Node2D node) : base(uiPanel, node) {  }
        public override Root_1 Clone() => new (UiPanel, (Godot.Node2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.RoomMap.MapBar.DrawContainer.Mark
    /// </summary>
    public class Mark : UiNode<RoomUIPanel, Godot.Sprite2D, Mark>
    {
        public Mark(RoomUIPanel uiPanel, Godot.Sprite2D node) : base(uiPanel, node) {  }
        public override Mark Clone() => new (UiPanel, (Godot.Sprite2D)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.RoomMap.MapBar.DrawContainer
    /// </summary>
    public class DrawContainer : UiNode<RoomUIPanel, Godot.TextureRect, DrawContainer>
    {
        /// <summary>
        /// 节点路径: RoomUI.game.RoomMap.MapBar.Root
        /// </summary>
        public Root_1 L_Root
        {
            get
            {
                if (_L_Root == null) _L_Root = new Root_1(UiPanel, Instance.GetNode<Godot.Node2D>("Root"));
                return _L_Root;
            }
        }
        private Root_1 _L_Root;

        /// <summary>
        /// 节点路径: RoomUI.game.RoomMap.MapBar.Mark
        /// </summary>
        public Mark L_Mark
        {
            get
            {
                if (_L_Mark == null) _L_Mark = new Mark(UiPanel, Instance.GetNode<Godot.Sprite2D>("Mark"));
                return _L_Mark;
            }
        }
        private Mark _L_Mark;

        public DrawContainer(RoomUIPanel uiPanel, Godot.TextureRect node) : base(uiPanel, node) {  }
        public override DrawContainer Clone() => new (UiPanel, (Godot.TextureRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.RoomMap.MapBar
    /// </summary>
    public class MapBar : UiNode<RoomUIPanel, Godot.NinePatchRect, MapBar>
    {
        /// <summary>
        /// 节点路径: RoomUI.game.RoomMap.DrawContainer
        /// </summary>
        public DrawContainer L_DrawContainer
        {
            get
            {
                if (_L_DrawContainer == null) _L_DrawContainer = new DrawContainer(UiPanel, Instance.GetNode<Godot.TextureRect>("DrawContainer"));
                return _L_DrawContainer;
            }
        }
        private DrawContainer _L_DrawContainer;

        public MapBar(RoomUIPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override MapBar Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.game.RoomMap.MagnifyMapBar
    /// </summary>
    public class MagnifyMapBar : UiNode<RoomUIPanel, Godot.NinePatchRect, MagnifyMapBar>
    {
        public MagnifyMapBar(RoomUIPanel uiPanel, Godot.NinePatchRect node) : base(uiPanel, node) {  }
        public override MagnifyMapBar Clone() => new (UiPanel, (Godot.NinePatchRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: RoomUI.RoomMap
    /// </summary>
    public class RoomMap : UiNode<RoomUIPanel, UI.game.RoomMap.RoomMapPanel, RoomMap>
    {
        /// <summary>
        /// 节点路径: RoomUI.Bg
        /// </summary>
        public Bg_1 L_Bg
        {
            get
            {
                if (_L_Bg == null) _L_Bg = new Bg_1(UiPanel, Instance.GetNode<Godot.ColorRect>("Bg"));
                return _L_Bg;
            }
        }
        private Bg_1 _L_Bg;

        /// <summary>
        /// 节点路径: RoomUI.MapBar
        /// </summary>
        public MapBar L_MapBar
        {
            get
            {
                if (_L_MapBar == null) _L_MapBar = new MapBar(UiPanel, Instance.GetNode<Godot.NinePatchRect>("MapBar"));
                return _L_MapBar;
            }
        }
        private MapBar _L_MapBar;

        /// <summary>
        /// 节点路径: RoomUI.MagnifyMapBar
        /// </summary>
        public MagnifyMapBar L_MagnifyMapBar
        {
            get
            {
                if (_L_MagnifyMapBar == null) _L_MagnifyMapBar = new MagnifyMapBar(UiPanel, Instance.GetNode<Godot.NinePatchRect>("MagnifyMapBar"));
                return _L_MagnifyMapBar;
            }
        }
        private MagnifyMapBar _L_MagnifyMapBar;

        public RoomMap(RoomUIPanel uiPanel, UI.game.RoomMap.RoomMapPanel node) : base(uiPanel, node) {  }
        public override RoomMap Clone() => new (UiPanel, (UI.game.RoomMap.RoomMapPanel)Instance.Duplicate());
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
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.LifeBar.Life.LifeIcon
    /// </summary>
    public LifeIcon S_LifeIcon => L_Control.L_LifeBar.L_Life.L_LifeIcon;

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
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.WeaponBar.WeaponPanel.WeaponSprite
    /// </summary>
    public WeaponSprite S_WeaponSprite => L_Control.L_WeaponBar.L_WeaponPanel.L_WeaponSprite;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.WeaponBar.WeaponPanel
    /// </summary>
    public WeaponPanel S_WeaponPanel => L_Control.L_WeaponBar.L_WeaponPanel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.WeaponBar.AmmoCount
    /// </summary>
    public AmmoCount S_AmmoCount => L_Control.L_WeaponBar.L_AmmoCount;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control.WeaponBar
    /// </summary>
    public WeaponBar S_WeaponBar => L_Control.L_WeaponBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Control
    /// </summary>
    public Control S_Control => L_Control;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotUi.WeaponUi.WeaponIcon
    /// </summary>
    public WeaponIcon S_WeaponIcon => L_WeaponRoulette.L_Root.L_RouletteBg.L_WeaponSlotNode.L_SlotUi.L_WeaponUi.L_WeaponIcon;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotUi.WeaponUi.AmmoLabel
    /// </summary>
    public AmmoLabel S_AmmoLabel => L_WeaponRoulette.L_Root.L_RouletteBg.L_WeaponSlotNode.L_SlotUi.L_WeaponUi.L_AmmoLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotUi.WeaponUi
    /// </summary>
    public WeaponUi S_WeaponUi => L_WeaponRoulette.L_Root.L_RouletteBg.L_WeaponSlotNode.L_SlotUi.L_WeaponUi;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotUi.LockSprite
    /// </summary>
    public LockSprite S_LockSprite => L_WeaponRoulette.L_Root.L_RouletteBg.L_WeaponSlotNode.L_SlotUi.L_LockSprite;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotUi
    /// </summary>
    public SlotUi S_SlotUi => L_WeaponRoulette.L_Root.L_RouletteBg.L_WeaponSlotNode.L_SlotUi;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotAreaNode.CollisionPolygon2D
    /// </summary>
    public CollisionPolygon2D S_CollisionPolygon2D => L_WeaponRoulette.L_Root.L_RouletteBg.L_WeaponSlotNode.L_SlotAreaNode.L_CollisionPolygon2D;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode.SlotAreaNode
    /// </summary>
    public SlotAreaNode S_SlotAreaNode => L_WeaponRoulette.L_Root.L_RouletteBg.L_WeaponSlotNode.L_SlotAreaNode;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg.WeaponSlotNode
    /// </summary>
    public WeaponSlotNode S_WeaponSlotNode => L_WeaponRoulette.L_Root.L_RouletteBg.L_WeaponSlotNode;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.Root.RouletteBg
    /// </summary>
    public RouletteBg S_RouletteBg => L_WeaponRoulette.L_Root.L_RouletteBg;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.Root.UpBar.Label2
    /// </summary>
    public Label2 S_Label2 => L_WeaponRoulette.L_Root.L_UpBar.L_Label2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.Root.UpBar.PageLabel
    /// </summary>
    public PageLabel S_PageLabel => L_WeaponRoulette.L_Root.L_UpBar.L_PageLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.Root.UpBar
    /// </summary>
    public UpBar S_UpBar => L_WeaponRoulette.L_Root.L_UpBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.Root.DownBar
    /// </summary>
    public DownBar S_DownBar => L_WeaponRoulette.L_Root.L_DownBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.MouseArea.CollisionShape2D
    /// </summary>
    public CollisionShape2D S_CollisionShape2D => L_WeaponRoulette.L_MouseArea.L_CollisionShape2D;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.WeaponRoulette.MouseArea
    /// </summary>
    public MouseArea S_MouseArea => L_WeaponRoulette.L_MouseArea;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.WeaponRoulette
    /// </summary>
    public WeaponRoulette S_WeaponRoulette => L_WeaponRoulette;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.RoomMap.MapBar.DrawContainer.Mark
    /// </summary>
    public Mark S_Mark => L_RoomMap.L_MapBar.L_DrawContainer.L_Mark;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.RoomMap.MapBar.DrawContainer
    /// </summary>
    public DrawContainer S_DrawContainer => L_RoomMap.L_MapBar.L_DrawContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.RoomMap.MapBar
    /// </summary>
    public MapBar S_MapBar => L_RoomMap.L_MapBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.game.RoomMap.MagnifyMapBar
    /// </summary>
    public MagnifyMapBar S_MagnifyMapBar => L_RoomMap.L_MagnifyMapBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.RoomMap
    /// </summary>
    public RoomMap S_RoomMap => L_RoomMap;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: RoomUI.Mask
    /// </summary>
    public Mask S_Mask => L_Mask;

}
