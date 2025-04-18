using Godot;
using UI.game.RoomUI;

namespace UI.game.PartPackUI;

public partial class PartPackUIPanel : PartPackUI
{
    public RoomUIPanel UiPanel;

    public override void OnCreateUi()
    {
        if (ParentUi is RoomUIPanel uiPanel)
        {
            UiPanel = uiPanel;
        }
    }

    public override void OnShowUi()
    {
        if (UiPanel != null)
        {
            UiPanel.OcclusionCount++;
        }
    }

    public override void OnHideUi()
    {
        if (UiPanel != null)
        {
            UiPanel.OcclusionCount--;
        }
    }
}
