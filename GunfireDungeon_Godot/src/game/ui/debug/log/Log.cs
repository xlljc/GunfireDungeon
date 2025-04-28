using DsUi;

namespace UI.debug.Log;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Log : UiBase
{
    /// <summary>
    /// 节点路径: Log.VBoxContainer
    /// </summary>
    public VBoxContainer L_VBoxContainer
    {
        get
        {
            if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer((LogPanel)this, GetNode<Godot.VBoxContainer>("VBoxContainer"));
            return _L_VBoxContainer;
        }
    }
    private VBoxContainer _L_VBoxContainer;


    public Log() : base(UiManager.UiName.Debug_Log)
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: Log.VBoxContainer.Clear
    /// </summary>
    public class Clear : UiNode<LogPanel, Godot.Button, Clear>
    {
        public Clear(LogPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Clear Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Log.VBoxContainer.ScrollContainer.LogText
    /// </summary>
    public class LogText : UiNode<LogPanel, Godot.Label, LogText>
    {
        public LogText(LogPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override LogText Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Log.VBoxContainer.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<LogPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 节点路径: Log.VBoxContainer.LogText
        /// </summary>
        public LogText L_LogText
        {
            get
            {
                if (_L_LogText == null) _L_LogText = new LogText(UiPanel, Instance.GetNode<Godot.Label>("LogText"));
                return _L_LogText;
            }
        }
        private LogText _L_LogText;

        public ScrollContainer(LogPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Log.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<LogPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 节点路径: Log.Clear
        /// </summary>
        public Clear L_Clear
        {
            get
            {
                if (_L_Clear == null) _L_Clear = new Clear(UiPanel, Instance.GetNode<Godot.Button>("Clear"));
                return _L_Clear;
            }
        }
        private Clear _L_Clear;

        /// <summary>
        /// 节点路径: Log.ScrollContainer
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

        public VBoxContainer(LogPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Log.VBoxContainer.Clear
    /// </summary>
    public Clear S_Clear => L_VBoxContainer.L_Clear;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Log.VBoxContainer.ScrollContainer.LogText
    /// </summary>
    public LogText S_LogText => L_VBoxContainer.L_ScrollContainer.L_LogText;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Log.VBoxContainer.ScrollContainer
    /// </summary>
    public ScrollContainer S_ScrollContainer => L_VBoxContainer.L_ScrollContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Log.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_VBoxContainer;

}
