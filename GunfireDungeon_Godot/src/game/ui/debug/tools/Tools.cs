using DsUi;

namespace UI.debug.Tools;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Tools : UiBase
{
    /// <summary>
    /// 节点路径: Tools.HFlowContainer
    /// </summary>
    public HFlowContainer L_HFlowContainer
    {
        get
        {
            if (_L_HFlowContainer == null) _L_HFlowContainer = new HFlowContainer((ToolsPanel)this, GetNode<Godot.HFlowContainer>("HFlowContainer"));
            return _L_HFlowContainer;
        }
    }
    private HFlowContainer _L_HFlowContainer;


    public Tools() : base(UiManager.UiName.Debug_Tools)
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.FpsCheck
    /// </summary>
    public class FpsCheck : UiNode<ToolsPanel, Godot.CheckButton, FpsCheck>
    {
        public FpsCheck(ToolsPanel uiPanel, Godot.CheckButton node) : base(uiPanel, node) {  }
        public override FpsCheck Clone() => new (UiPanel, (Godot.CheckButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer.FPSBtn
    /// </summary>
    public class FPSBtn : UiNode<ToolsPanel, Godot.Button, FPSBtn>
    {
        public FPSBtn(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override FPSBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer.FPSInput
    /// </summary>
    public class FPSInput : UiNode<ToolsPanel, Godot.LineEdit, FPSInput>
    {
        public FPSInput(ToolsPanel uiPanel, Godot.LineEdit node) : base(uiPanel, node) {  }
        public override FPSInput Clone() => new (UiPanel, (Godot.LineEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<ToolsPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 节点路径: Tools.HFlowContainer.FPSBtn
        /// </summary>
        public FPSBtn L_FPSBtn
        {
            get
            {
                if (_L_FPSBtn == null) _L_FPSBtn = new FPSBtn(UiPanel, Instance.GetNode<Godot.Button>("FPSBtn"));
                return _L_FPSBtn;
            }
        }
        private FPSBtn _L_FPSBtn;

        /// <summary>
        /// 节点路径: Tools.HFlowContainer.FPSInput
        /// </summary>
        public FPSInput L_FPSInput
        {
            get
            {
                if (_L_FPSInput == null) _L_FPSInput = new FPSInput(UiPanel, Instance.GetNode<Godot.LineEdit>("FPSInput"));
                return _L_FPSInput;
            }
        }
        private FPSInput _L_FPSInput;

        public HBoxContainer(ToolsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.DebugDrawCheck
    /// </summary>
    public class DebugDrawCheck : UiNode<ToolsPanel, Godot.CheckButton, DebugDrawCheck>
    {
        public DebugDrawCheck(ToolsPanel uiPanel, Godot.CheckButton node) : base(uiPanel, node) {  }
        public override DebugDrawCheck Clone() => new (UiPanel, (Godot.CheckButton)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.KellEnemyBtn
    /// </summary>
    public class KellEnemyBtn : UiNode<ToolsPanel, Godot.Button, KellEnemyBtn>
    {
        public KellEnemyBtn(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override KellEnemyBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.KellSelfBtn
    /// </summary>
    public class KellSelfBtn : UiNode<ToolsPanel, Godot.Button, KellSelfBtn>
    {
        public KellSelfBtn(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override KellSelfBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer3.MaxHpBtn
    /// </summary>
    public class MaxHpBtn : UiNode<ToolsPanel, Godot.Button, MaxHpBtn>
    {
        public MaxHpBtn(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override MaxHpBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer3.MaxHpInput
    /// </summary>
    public class MaxHpInput : UiNode<ToolsPanel, Godot.LineEdit, MaxHpInput>
    {
        public MaxHpInput(ToolsPanel uiPanel, Godot.LineEdit node) : base(uiPanel, node) {  }
        public override MaxHpInput Clone() => new (UiPanel, (Godot.LineEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer3
    /// </summary>
    public class HBoxContainer3 : UiNode<ToolsPanel, Godot.HBoxContainer, HBoxContainer3>
    {
        /// <summary>
        /// 节点路径: Tools.HFlowContainer.MaxHpBtn
        /// </summary>
        public MaxHpBtn L_MaxHpBtn
        {
            get
            {
                if (_L_MaxHpBtn == null) _L_MaxHpBtn = new MaxHpBtn(UiPanel, Instance.GetNode<Godot.Button>("MaxHpBtn"));
                return _L_MaxHpBtn;
            }
        }
        private MaxHpBtn _L_MaxHpBtn;

        /// <summary>
        /// 节点路径: Tools.HFlowContainer.MaxHpInput
        /// </summary>
        public MaxHpInput L_MaxHpInput
        {
            get
            {
                if (_L_MaxHpInput == null) _L_MaxHpInput = new MaxHpInput(UiPanel, Instance.GetNode<Godot.LineEdit>("MaxHpInput"));
                return _L_MaxHpInput;
            }
        }
        private MaxHpInput _L_MaxHpInput;

        public HBoxContainer3(ToolsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer3 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer4.HpBtn
    /// </summary>
    public class HpBtn : UiNode<ToolsPanel, Godot.Button, HpBtn>
    {
        public HpBtn(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override HpBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer4.HpInput
    /// </summary>
    public class HpInput : UiNode<ToolsPanel, Godot.LineEdit, HpInput>
    {
        public HpInput(ToolsPanel uiPanel, Godot.LineEdit node) : base(uiPanel, node) {  }
        public override HpInput Clone() => new (UiPanel, (Godot.LineEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer4
    /// </summary>
    public class HBoxContainer4 : UiNode<ToolsPanel, Godot.HBoxContainer, HBoxContainer4>
    {
        /// <summary>
        /// 节点路径: Tools.HFlowContainer.HpBtn
        /// </summary>
        public HpBtn L_HpBtn
        {
            get
            {
                if (_L_HpBtn == null) _L_HpBtn = new HpBtn(UiPanel, Instance.GetNode<Godot.Button>("HpBtn"));
                return _L_HpBtn;
            }
        }
        private HpBtn _L_HpBtn;

        /// <summary>
        /// 节点路径: Tools.HFlowContainer.HpInput
        /// </summary>
        public HpInput L_HpInput
        {
            get
            {
                if (_L_HpInput == null) _L_HpInput = new HpInput(UiPanel, Instance.GetNode<Godot.LineEdit>("HpInput"));
                return _L_HpInput;
            }
        }
        private HpInput _L_HpInput;

        public HBoxContainer4(ToolsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer4 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer5.MaxShieldBtn
    /// </summary>
    public class MaxShieldBtn : UiNode<ToolsPanel, Godot.Button, MaxShieldBtn>
    {
        public MaxShieldBtn(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override MaxShieldBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer5.MaxShieldInput
    /// </summary>
    public class MaxShieldInput : UiNode<ToolsPanel, Godot.LineEdit, MaxShieldInput>
    {
        public MaxShieldInput(ToolsPanel uiPanel, Godot.LineEdit node) : base(uiPanel, node) {  }
        public override MaxShieldInput Clone() => new (UiPanel, (Godot.LineEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer5
    /// </summary>
    public class HBoxContainer5 : UiNode<ToolsPanel, Godot.HBoxContainer, HBoxContainer5>
    {
        /// <summary>
        /// 节点路径: Tools.HFlowContainer.MaxShieldBtn
        /// </summary>
        public MaxShieldBtn L_MaxShieldBtn
        {
            get
            {
                if (_L_MaxShieldBtn == null) _L_MaxShieldBtn = new MaxShieldBtn(UiPanel, Instance.GetNode<Godot.Button>("MaxShieldBtn"));
                return _L_MaxShieldBtn;
            }
        }
        private MaxShieldBtn _L_MaxShieldBtn;

        /// <summary>
        /// 节点路径: Tools.HFlowContainer.MaxShieldInput
        /// </summary>
        public MaxShieldInput L_MaxShieldInput
        {
            get
            {
                if (_L_MaxShieldInput == null) _L_MaxShieldInput = new MaxShieldInput(UiPanel, Instance.GetNode<Godot.LineEdit>("MaxShieldInput"));
                return _L_MaxShieldInput;
            }
        }
        private MaxShieldInput _L_MaxShieldInput;

        public HBoxContainer5(ToolsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer5 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer6.ShieldBtn
    /// </summary>
    public class ShieldBtn : UiNode<ToolsPanel, Godot.Button, ShieldBtn>
    {
        public ShieldBtn(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ShieldBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer6.ShieldInput
    /// </summary>
    public class ShieldInput : UiNode<ToolsPanel, Godot.LineEdit, ShieldInput>
    {
        public ShieldInput(ToolsPanel uiPanel, Godot.LineEdit node) : base(uiPanel, node) {  }
        public override ShieldInput Clone() => new (UiPanel, (Godot.LineEdit)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer6
    /// </summary>
    public class HBoxContainer6 : UiNode<ToolsPanel, Godot.HBoxContainer, HBoxContainer6>
    {
        /// <summary>
        /// 节点路径: Tools.HFlowContainer.ShieldBtn
        /// </summary>
        public ShieldBtn L_ShieldBtn
        {
            get
            {
                if (_L_ShieldBtn == null) _L_ShieldBtn = new ShieldBtn(UiPanel, Instance.GetNode<Godot.Button>("ShieldBtn"));
                return _L_ShieldBtn;
            }
        }
        private ShieldBtn _L_ShieldBtn;

        /// <summary>
        /// 节点路径: Tools.HFlowContainer.ShieldInput
        /// </summary>
        public ShieldInput L_ShieldInput
        {
            get
            {
                if (_L_ShieldInput == null) _L_ShieldInput = new ShieldInput(UiPanel, Instance.GetNode<Godot.LineEdit>("ShieldInput"));
                return _L_ShieldInput;
            }
        }
        private ShieldInput _L_ShieldInput;

        public HBoxContainer6(ToolsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer6 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer8.AsBtn
    /// </summary>
    public class AsBtn : UiNode<ToolsPanel, Godot.Button, AsBtn>
    {
        public AsBtn(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override AsBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer8
    /// </summary>
    public class HBoxContainer8 : UiNode<ToolsPanel, Godot.HBoxContainer, HBoxContainer8>
    {
        /// <summary>
        /// 节点路径: Tools.HFlowContainer.AsBtn
        /// </summary>
        public AsBtn L_AsBtn
        {
            get
            {
                if (_L_AsBtn == null) _L_AsBtn = new AsBtn(UiPanel, Instance.GetNode<Godot.Button>("AsBtn"));
                return _L_AsBtn;
            }
        }
        private AsBtn _L_AsBtn;

        public HBoxContainer8(ToolsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer8 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer2.Label
    /// </summary>
    public class Label : UiNode<ToolsPanel, Godot.Label, Label>
    {
        public Label(ToolsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer2.CameraZoomNearly
    /// </summary>
    public class CameraZoomNearly : UiNode<ToolsPanel, Godot.Button, CameraZoomNearly>
    {
        public CameraZoomNearly(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CameraZoomNearly Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer2.CameraZoomFar
    /// </summary>
    public class CameraZoomFar : UiNode<ToolsPanel, Godot.Button, CameraZoomFar>
    {
        public CameraZoomFar(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CameraZoomFar Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer2.CameraZoomResult
    /// </summary>
    public class CameraZoomResult : UiNode<ToolsPanel, Godot.Button, CameraZoomResult>
    {
        public CameraZoomResult(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CameraZoomResult Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer2
    /// </summary>
    public class HBoxContainer2 : UiNode<ToolsPanel, Godot.HBoxContainer, HBoxContainer2>
    {
        /// <summary>
        /// 节点路径: Tools.HFlowContainer.Label
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
        /// 节点路径: Tools.HFlowContainer.CameraZoomNearly
        /// </summary>
        public CameraZoomNearly L_CameraZoomNearly
        {
            get
            {
                if (_L_CameraZoomNearly == null) _L_CameraZoomNearly = new CameraZoomNearly(UiPanel, Instance.GetNode<Godot.Button>("CameraZoomNearly"));
                return _L_CameraZoomNearly;
            }
        }
        private CameraZoomNearly _L_CameraZoomNearly;

        /// <summary>
        /// 节点路径: Tools.HFlowContainer.CameraZoomFar
        /// </summary>
        public CameraZoomFar L_CameraZoomFar
        {
            get
            {
                if (_L_CameraZoomFar == null) _L_CameraZoomFar = new CameraZoomFar(UiPanel, Instance.GetNode<Godot.Button>("CameraZoomFar"));
                return _L_CameraZoomFar;
            }
        }
        private CameraZoomFar _L_CameraZoomFar;

        /// <summary>
        /// 节点路径: Tools.HFlowContainer.CameraZoomResult
        /// </summary>
        public CameraZoomResult L_CameraZoomResult
        {
            get
            {
                if (_L_CameraZoomResult == null) _L_CameraZoomResult = new CameraZoomResult(UiPanel, Instance.GetNode<Godot.Button>("CameraZoomResult"));
                return _L_CameraZoomResult;
            }
        }
        private CameraZoomResult _L_CameraZoomResult;

        public HBoxContainer2(ToolsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer2 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer7.Label
    /// </summary>
    public class Label_1 : UiNode<ToolsPanel, Godot.Label, Label_1>
    {
        public Label_1(ToolsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer7.CloseRoomFog
    /// </summary>
    public class CloseRoomFog : UiNode<ToolsPanel, Godot.Button, CloseRoomFog>
    {
        public CloseRoomFog(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CloseRoomFog Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.HBoxContainer7
    /// </summary>
    public class HBoxContainer7 : UiNode<ToolsPanel, Godot.HBoxContainer, HBoxContainer7>
    {
        /// <summary>
        /// 节点路径: Tools.HFlowContainer.Label
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
        /// 节点路径: Tools.HFlowContainer.CloseRoomFog
        /// </summary>
        public CloseRoomFog L_CloseRoomFog
        {
            get
            {
                if (_L_CloseRoomFog == null) _L_CloseRoomFog = new CloseRoomFog(UiPanel, Instance.GetNode<Godot.Button>("CloseRoomFog"));
                return _L_CloseRoomFog;
            }
        }
        private CloseRoomFog _L_CloseRoomFog;

        public HBoxContainer7(ToolsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer7 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.CreateObjectBtn
    /// </summary>
    public class CreateObjectBtn : UiNode<ToolsPanel, Godot.Button, CreateObjectBtn>
    {
        public CreateObjectBtn(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CreateObjectBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer
    /// </summary>
    public class HFlowContainer : UiNode<ToolsPanel, Godot.HFlowContainer, HFlowContainer>
    {
        /// <summary>
        /// 节点路径: Tools.FpsCheck
        /// </summary>
        public FpsCheck L_FpsCheck
        {
            get
            {
                if (_L_FpsCheck == null) _L_FpsCheck = new FpsCheck(UiPanel, Instance.GetNode<Godot.CheckButton>("FpsCheck"));
                return _L_FpsCheck;
            }
        }
        private FpsCheck _L_FpsCheck;

        /// <summary>
        /// 节点路径: Tools.HBoxContainer
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
        /// 节点路径: Tools.DebugDrawCheck
        /// </summary>
        public DebugDrawCheck L_DebugDrawCheck
        {
            get
            {
                if (_L_DebugDrawCheck == null) _L_DebugDrawCheck = new DebugDrawCheck(UiPanel, Instance.GetNode<Godot.CheckButton>("DebugDrawCheck"));
                return _L_DebugDrawCheck;
            }
        }
        private DebugDrawCheck _L_DebugDrawCheck;

        /// <summary>
        /// 节点路径: Tools.KellEnemyBtn
        /// </summary>
        public KellEnemyBtn L_KellEnemyBtn
        {
            get
            {
                if (_L_KellEnemyBtn == null) _L_KellEnemyBtn = new KellEnemyBtn(UiPanel, Instance.GetNode<Godot.Button>("KellEnemyBtn"));
                return _L_KellEnemyBtn;
            }
        }
        private KellEnemyBtn _L_KellEnemyBtn;

        /// <summary>
        /// 节点路径: Tools.KellSelfBtn
        /// </summary>
        public KellSelfBtn L_KellSelfBtn
        {
            get
            {
                if (_L_KellSelfBtn == null) _L_KellSelfBtn = new KellSelfBtn(UiPanel, Instance.GetNode<Godot.Button>("KellSelfBtn"));
                return _L_KellSelfBtn;
            }
        }
        private KellSelfBtn _L_KellSelfBtn;

        /// <summary>
        /// 节点路径: Tools.HBoxContainer3
        /// </summary>
        public HBoxContainer3 L_HBoxContainer3
        {
            get
            {
                if (_L_HBoxContainer3 == null) _L_HBoxContainer3 = new HBoxContainer3(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer3"));
                return _L_HBoxContainer3;
            }
        }
        private HBoxContainer3 _L_HBoxContainer3;

        /// <summary>
        /// 节点路径: Tools.HBoxContainer4
        /// </summary>
        public HBoxContainer4 L_HBoxContainer4
        {
            get
            {
                if (_L_HBoxContainer4 == null) _L_HBoxContainer4 = new HBoxContainer4(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer4"));
                return _L_HBoxContainer4;
            }
        }
        private HBoxContainer4 _L_HBoxContainer4;

        /// <summary>
        /// 节点路径: Tools.HBoxContainer5
        /// </summary>
        public HBoxContainer5 L_HBoxContainer5
        {
            get
            {
                if (_L_HBoxContainer5 == null) _L_HBoxContainer5 = new HBoxContainer5(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer5"));
                return _L_HBoxContainer5;
            }
        }
        private HBoxContainer5 _L_HBoxContainer5;

        /// <summary>
        /// 节点路径: Tools.HBoxContainer6
        /// </summary>
        public HBoxContainer6 L_HBoxContainer6
        {
            get
            {
                if (_L_HBoxContainer6 == null) _L_HBoxContainer6 = new HBoxContainer6(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer6"));
                return _L_HBoxContainer6;
            }
        }
        private HBoxContainer6 _L_HBoxContainer6;

        /// <summary>
        /// 节点路径: Tools.HBoxContainer8
        /// </summary>
        public HBoxContainer8 L_HBoxContainer8
        {
            get
            {
                if (_L_HBoxContainer8 == null) _L_HBoxContainer8 = new HBoxContainer8(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer8"));
                return _L_HBoxContainer8;
            }
        }
        private HBoxContainer8 _L_HBoxContainer8;

        /// <summary>
        /// 节点路径: Tools.HBoxContainer2
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
        /// 节点路径: Tools.HBoxContainer7
        /// </summary>
        public HBoxContainer7 L_HBoxContainer7
        {
            get
            {
                if (_L_HBoxContainer7 == null) _L_HBoxContainer7 = new HBoxContainer7(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer7"));
                return _L_HBoxContainer7;
            }
        }
        private HBoxContainer7 _L_HBoxContainer7;

        /// <summary>
        /// 节点路径: Tools.CreateObjectBtn
        /// </summary>
        public CreateObjectBtn L_CreateObjectBtn
        {
            get
            {
                if (_L_CreateObjectBtn == null) _L_CreateObjectBtn = new CreateObjectBtn(UiPanel, Instance.GetNode<Godot.Button>("CreateObjectBtn"));
                return _L_CreateObjectBtn;
            }
        }
        private CreateObjectBtn _L_CreateObjectBtn;

        public HFlowContainer(ToolsPanel uiPanel, Godot.HFlowContainer node) : base(uiPanel, node) {  }
        public override HFlowContainer Clone() => new (UiPanel, (Godot.HFlowContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.FpsCheck
    /// </summary>
    public FpsCheck S_FpsCheck => L_HFlowContainer.L_FpsCheck;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer.FPSBtn
    /// </summary>
    public FPSBtn S_FPSBtn => L_HFlowContainer.L_HBoxContainer.L_FPSBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer.FPSInput
    /// </summary>
    public FPSInput S_FPSInput => L_HFlowContainer.L_HBoxContainer.L_FPSInput;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_HFlowContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.DebugDrawCheck
    /// </summary>
    public DebugDrawCheck S_DebugDrawCheck => L_HFlowContainer.L_DebugDrawCheck;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.KellEnemyBtn
    /// </summary>
    public KellEnemyBtn S_KellEnemyBtn => L_HFlowContainer.L_KellEnemyBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.KellSelfBtn
    /// </summary>
    public KellSelfBtn S_KellSelfBtn => L_HFlowContainer.L_KellSelfBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer3.MaxHpBtn
    /// </summary>
    public MaxHpBtn S_MaxHpBtn => L_HFlowContainer.L_HBoxContainer3.L_MaxHpBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer3.MaxHpInput
    /// </summary>
    public MaxHpInput S_MaxHpInput => L_HFlowContainer.L_HBoxContainer3.L_MaxHpInput;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer3
    /// </summary>
    public HBoxContainer3 S_HBoxContainer3 => L_HFlowContainer.L_HBoxContainer3;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer4.HpBtn
    /// </summary>
    public HpBtn S_HpBtn => L_HFlowContainer.L_HBoxContainer4.L_HpBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer4.HpInput
    /// </summary>
    public HpInput S_HpInput => L_HFlowContainer.L_HBoxContainer4.L_HpInput;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer4
    /// </summary>
    public HBoxContainer4 S_HBoxContainer4 => L_HFlowContainer.L_HBoxContainer4;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer5.MaxShieldBtn
    /// </summary>
    public MaxShieldBtn S_MaxShieldBtn => L_HFlowContainer.L_HBoxContainer5.L_MaxShieldBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer5.MaxShieldInput
    /// </summary>
    public MaxShieldInput S_MaxShieldInput => L_HFlowContainer.L_HBoxContainer5.L_MaxShieldInput;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer5
    /// </summary>
    public HBoxContainer5 S_HBoxContainer5 => L_HFlowContainer.L_HBoxContainer5;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer6.ShieldBtn
    /// </summary>
    public ShieldBtn S_ShieldBtn => L_HFlowContainer.L_HBoxContainer6.L_ShieldBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer6.ShieldInput
    /// </summary>
    public ShieldInput S_ShieldInput => L_HFlowContainer.L_HBoxContainer6.L_ShieldInput;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer6
    /// </summary>
    public HBoxContainer6 S_HBoxContainer6 => L_HFlowContainer.L_HBoxContainer6;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer8.AsBtn
    /// </summary>
    public AsBtn S_AsBtn => L_HFlowContainer.L_HBoxContainer8.L_AsBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer8
    /// </summary>
    public HBoxContainer8 S_HBoxContainer8 => L_HFlowContainer.L_HBoxContainer8;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer2.CameraZoomNearly
    /// </summary>
    public CameraZoomNearly S_CameraZoomNearly => L_HFlowContainer.L_HBoxContainer2.L_CameraZoomNearly;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer2.CameraZoomFar
    /// </summary>
    public CameraZoomFar S_CameraZoomFar => L_HFlowContainer.L_HBoxContainer2.L_CameraZoomFar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer2.CameraZoomResult
    /// </summary>
    public CameraZoomResult S_CameraZoomResult => L_HFlowContainer.L_HBoxContainer2.L_CameraZoomResult;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer2
    /// </summary>
    public HBoxContainer2 S_HBoxContainer2 => L_HFlowContainer.L_HBoxContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer7.CloseRoomFog
    /// </summary>
    public CloseRoomFog S_CloseRoomFog => L_HFlowContainer.L_HBoxContainer7.L_CloseRoomFog;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.HBoxContainer7
    /// </summary>
    public HBoxContainer7 S_HBoxContainer7 => L_HFlowContainer.L_HBoxContainer7;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.CreateObjectBtn
    /// </summary>
    public CreateObjectBtn S_CreateObjectBtn => L_HFlowContainer.L_CreateObjectBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer
    /// </summary>
    public HFlowContainer S_HFlowContainer => L_HFlowContainer;

}
