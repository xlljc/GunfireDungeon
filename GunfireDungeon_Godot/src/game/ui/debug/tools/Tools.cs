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
    /// 路径: Tools.HFlowContainer.Control.Label
    /// </summary>
    public class Label : UiNode<ToolsPanel, Godot.Label, Label>
    {
        public Label(ToolsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.Control.CameraZoomNearly
    /// </summary>
    public class CameraZoomNearly : UiNode<ToolsPanel, Godot.Button, CameraZoomNearly>
    {
        public CameraZoomNearly(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CameraZoomNearly Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.Control.CameraZoomFar
    /// </summary>
    public class CameraZoomFar : UiNode<ToolsPanel, Godot.Button, CameraZoomFar>
    {
        public CameraZoomFar(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CameraZoomFar Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.Control.CameraZoomResult
    /// </summary>
    public class CameraZoomResult : UiNode<ToolsPanel, Godot.Button, CameraZoomResult>
    {
        public CameraZoomResult(ToolsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CameraZoomResult Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Tools.HFlowContainer.Control
    /// </summary>
    public class Control : UiNode<ToolsPanel, Godot.HBoxContainer, Control>
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

        public Control(ToolsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override Control Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
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
        /// 节点路径: Tools.Control
        /// </summary>
        public Control L_Control
        {
            get
            {
                if (_L_Control == null) _L_Control = new Control(UiPanel, Instance.GetNode<Godot.HBoxContainer>("Control"));
                return _L_Control;
            }
        }
        private Control _L_Control;

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
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.Control.Label
    /// </summary>
    public Label S_Label => L_HFlowContainer.L_Control.L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.Control.CameraZoomNearly
    /// </summary>
    public CameraZoomNearly S_CameraZoomNearly => L_HFlowContainer.L_Control.L_CameraZoomNearly;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.Control.CameraZoomFar
    /// </summary>
    public CameraZoomFar S_CameraZoomFar => L_HFlowContainer.L_Control.L_CameraZoomFar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.Control.CameraZoomResult
    /// </summary>
    public CameraZoomResult S_CameraZoomResult => L_HFlowContainer.L_Control.L_CameraZoomResult;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.Control
    /// </summary>
    public Control S_Control => L_HFlowContainer.L_Control;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer.CreateObjectBtn
    /// </summary>
    public CreateObjectBtn S_CreateObjectBtn => L_HFlowContainer.L_CreateObjectBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Tools.HFlowContainer
    /// </summary>
    public HFlowContainer S_HFlowContainer => L_HFlowContainer;

}
