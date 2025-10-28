using DsUi;

namespace UI.debug.Debugger;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Debugger : UiBase
{
    /// <summary>
    /// 节点路径: Debugger.Bg
    /// </summary>
    public Bg L_Bg
    {
        get
        {
            if (_L_Bg == null) _L_Bg = new Bg((DebuggerPanel)this, GetNode<Godot.ColorRect>("Bg"));
            return _L_Bg;
        }
    }
    private Bg _L_Bg;

    /// <summary>
    /// 节点路径: Debugger.HoverButton
    /// </summary>
    public HoverButton L_HoverButton
    {
        get
        {
            if (_L_HoverButton == null) _L_HoverButton = new HoverButton((DebuggerPanel)this, GetNode<Godot.Button>("HoverButton"));
            return _L_HoverButton;
        }
    }
    private HoverButton _L_HoverButton;

    /// <summary>
    /// 节点路径: Debugger.Fps
    /// </summary>
    public Fps L_Fps
    {
        get
        {
            if (_L_Fps == null) _L_Fps = new Fps((DebuggerPanel)this, GetNode<Godot.Label>("Fps"));
            return _L_Fps;
        }
    }
    private Fps _L_Fps;


    public Debugger() : base(UiManager.UiName.Debug_Debugger)
    {
    }

    public sealed override void OnInitNestedUi()
    {

        var inst1 = L_Bg.L_Tab.L_MarginContainer;
        RecordNestedUi(inst1.L_Log.Instance, inst1, UiManager.RecordType.Open);
        inst1.L_Log.Instance.OnCreateUi();
        inst1.L_Log.Instance.OnInitNestedUi();

        var inst2 = L_Bg.L_Tab.L_MarginContainer2;
        RecordNestedUi(inst2.L_Tools.Instance, inst2, UiManager.RecordType.Open);
        inst2.L_Tools.Instance.OnCreateUi();
        inst2.L_Tools.Instance.OnInitNestedUi();

    }

    /// <summary>
    /// 路径: Debugger.Bg.Tab.MarginContainer.Log
    /// </summary>
    public class Log : UiNode<DebuggerPanel, UI.debug.Log.LogPanel, Log>
    {
        public Log(DebuggerPanel uiPanel, UI.debug.Log.LogPanel node) : base(uiPanel, node) {  }
        public override Log Clone()
        {
            var uiNode = new Log(UiPanel, (UI.debug.Log.LogPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 路径: Debugger.Bg.Tab.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<DebuggerPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 节点路径: Debugger.Bg.Tab.Log
        /// </summary>
        public Log L_Log
        {
            get
            {
                if (_L_Log == null) _L_Log = new Log(UiPanel, Instance.GetNode<UI.debug.Log.LogPanel>("Log"));
                return _L_Log;
            }
        }
        private Log _L_Log;

        public MarginContainer(DebuggerPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Debugger.Bg.Tab.MarginContainer2.Tools
    /// </summary>
    public class Tools : UiNode<DebuggerPanel, UI.debug.Tools.ToolsPanel, Tools>
    {
        public Tools(DebuggerPanel uiPanel, UI.debug.Tools.ToolsPanel node) : base(uiPanel, node) {  }
        public override Tools Clone()
        {
            var uiNode = new Tools(UiPanel, (UI.debug.Tools.ToolsPanel)Instance.Duplicate());
            UiPanel.RecordNestedUi(uiNode.Instance, this, UiManager.RecordType.Open);
            uiNode.Instance.OnCreateUi();
            uiNode.Instance.OnInitNestedUi();
            return uiNode;
        }
    }

    /// <summary>
    /// 路径: Debugger.Bg.Tab.MarginContainer2
    /// </summary>
    public class MarginContainer2 : UiNode<DebuggerPanel, Godot.MarginContainer, MarginContainer2>
    {
        /// <summary>
        /// 节点路径: Debugger.Bg.Tab.Tools
        /// </summary>
        public Tools L_Tools
        {
            get
            {
                if (_L_Tools == null) _L_Tools = new Tools(UiPanel, Instance.GetNode<UI.debug.Tools.ToolsPanel>("Tools"));
                return _L_Tools;
            }
        }
        private Tools _L_Tools;

        public MarginContainer2(DebuggerPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer2 Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Debugger.Bg.Tab
    /// </summary>
    public class Tab : UiNode<DebuggerPanel, Godot.TabContainer, Tab>
    {
        /// <summary>
        /// 节点路径: Debugger.Bg.MarginContainer
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

        /// <summary>
        /// 节点路径: Debugger.Bg.MarginContainer2
        /// </summary>
        public MarginContainer2 L_MarginContainer2
        {
            get
            {
                if (_L_MarginContainer2 == null) _L_MarginContainer2 = new MarginContainer2(UiPanel, Instance.GetNode<Godot.MarginContainer>("MarginContainer2"));
                return _L_MarginContainer2;
            }
        }
        private MarginContainer2 _L_MarginContainer2;

        public Tab(DebuggerPanel uiPanel, Godot.TabContainer node) : base(uiPanel, node) {  }
        public override Tab Clone() => new (UiPanel, (Godot.TabContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Debugger.Bg.Close
    /// </summary>
    public class Close : UiNode<DebuggerPanel, Godot.Button, Close>
    {
        public Close(DebuggerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Close Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Debugger.Bg
    /// </summary>
    public class Bg : UiNode<DebuggerPanel, Godot.ColorRect, Bg>
    {
        /// <summary>
        /// 节点路径: Debugger.Tab
        /// </summary>
        public Tab L_Tab
        {
            get
            {
                if (_L_Tab == null) _L_Tab = new Tab(UiPanel, Instance.GetNode<Godot.TabContainer>("Tab"));
                return _L_Tab;
            }
        }
        private Tab _L_Tab;

        /// <summary>
        /// 节点路径: Debugger.Close
        /// </summary>
        public Close L_Close
        {
            get
            {
                if (_L_Close == null) _L_Close = new Close(UiPanel, Instance.GetNode<Godot.Button>("Close"));
                return _L_Close;
            }
        }
        private Close _L_Close;

        public Bg(DebuggerPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override Bg Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Debugger.HoverButton
    /// </summary>
    public class HoverButton : UiNode<DebuggerPanel, Godot.Button, HoverButton>
    {
        public HoverButton(DebuggerPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override HoverButton Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Debugger.Fps
    /// </summary>
    public class Fps : UiNode<DebuggerPanel, Godot.Label, Fps>
    {
        public Fps(DebuggerPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Fps Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Debugger.Bg.Tab.MarginContainer.Log
    /// </summary>
    public Log S_Log => L_Bg.L_Tab.L_MarginContainer.L_Log;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Debugger.Bg.Tab.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_Bg.L_Tab.L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Debugger.Bg.Tab.MarginContainer2.Tools
    /// </summary>
    public Tools S_Tools => L_Bg.L_Tab.L_MarginContainer2.L_Tools;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Debugger.Bg.Tab.MarginContainer2
    /// </summary>
    public MarginContainer2 S_MarginContainer2 => L_Bg.L_Tab.L_MarginContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Debugger.Bg.Tab
    /// </summary>
    public Tab S_Tab => L_Bg.L_Tab;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Debugger.Bg.Close
    /// </summary>
    public Close S_Close => L_Bg.L_Close;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Debugger.Bg
    /// </summary>
    public Bg S_Bg => L_Bg;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Debugger.HoverButton
    /// </summary>
    public HoverButton S_HoverButton => L_HoverButton;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Debugger.Fps
    /// </summary>
    public Fps S_Fps => L_Fps;

}
