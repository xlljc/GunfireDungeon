using Godot;

using DsUi;

namespace UI.editor.EditorTips;

public partial class EditorTipsPanel : EditorTips
{
    /// <summary>
    /// 设置显示的文本
    /// </summary>
    public void SetMessage(string message)
    {
        S_Label.Instance.Text = message;
    }
}
