using Godot;

using DsUi;

namespace UI.editor.EditorManager;

public partial class EditorManagerPanel : EditorManager
{

    public override void OnCreateUi()
    {
        if (PrevUi != null)
        {
            S_Back.Instance.Pressed += OpenPrevUi;
        }
        else
        {
            S_Back.Instance.Visible = false;
        }
        
        S_TabContainer.Instance.SetTabTitle(0, "地牢房间");
        S_TabContainer.Instance.SetTabTitle(1, "图块集");
    }

    public override void OnDestroyUi()
    {
        
    }

}
