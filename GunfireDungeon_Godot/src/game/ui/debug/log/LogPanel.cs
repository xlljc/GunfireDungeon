using Godot;
using UI.debug.Debugger;

namespace UI.debug.Log;

public partial class LogPanel : Log
{
    
    private int _len = 0;

    public override void OnCreateUi()
    {
#if TOOLS
        S_LogText.Instance.Text = "<编辑器模式下禁用日志输出>";
#else
        S_Clear.Instance.Pressed += OnClear;
#endif
    }

    public override void Process(float delta)
    {
#if !TOOLS
        if (ParentUi != null && ParentUi is DebuggerPanel panel && panel.ShowPanel)
        {
            if (Debug.AllLogMessage.Length != _len)
            {
                S_LogText.Instance.Text = Debug.AllLogMessage;
                _len = Debug.AllLogMessage.Length;
            }
        }
#endif
    }

    private void OnClear()
    {
        Debug.Clear();
        S_LogText.Instance.Text = "";
        _len = 0;
    }
}
