using DsUi;
using Godot;
using UI.game.PartTips;

/// <summary>
/// 通用Ui管理
/// </summary>
public static class CommonUiManager
{

    private static PartTipsPanel _partTipsPanel;
    
    /// <summary>
    /// 显示道具提示Ui
    /// </summary>
    public static void ShowPartTips(PartProp partProp)
    {
        if (_partTipsPanel == null)
        {
            _partTipsPanel = UiManager.CreateUi<PartTipsPanel>(UiManager.UiName.Game_PartTips);
        }

        _partTipsPanel.SetPartProp(partProp);
        _partTipsPanel.ShowUi();
    }

    /// <summary>
    /// 隐藏道具提示Ui
    /// </summary>
    public static void HidePartTips()
    {
        if (_partTipsPanel != null)
        {
            _partTipsPanel.HideUi();
        }
    }
}