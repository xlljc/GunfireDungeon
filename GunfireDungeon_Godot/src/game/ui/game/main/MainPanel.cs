using Godot;

using DsUi;

namespace UI.game.Main;

/// <summary>
/// 主菜单
/// </summary>
public partial class MainPanel : Main
{

    public override void OnCreateUi()
    {
        S_Start.Instance.Pressed += OnStartGameClick;
        S_Exit.Instance.Pressed += OnExitClick;
        S_Tools.Instance.Pressed += OnToolsClick;
        S_Setting.Instance.Pressed += OnSettingClick;

#if !TOOLS
        S_Tools.Instance.Visible = false;
#endif
        
        // var osName = OS.GetName();
        // if (osName == "Android")
        // {
        //     S_Tools.Instance.Visible = false;
        // }
    }
    
    //点击开始游戏
    private void OnStartGameClick()
    {
        UiManager.Open_Game_Loading();
        GameApplication.Instance.DungeonManager.LoadHall(() =>
        {
            UiManager.Destroy_Game_Loading();
        });
        HideUi();
    }

    //退出游戏
    private void OnExitClick()
    {
        GetTree().Quit();
    }

    //点击开发者工具
    private void OnToolsClick()
    {
        OpenNextUi(UiManager.UiName.Editor_EditorManager);
    }

    //点击设置按钮
    private void OnSettingClick()
    {
        OpenNextUi(UiManager.UiName.Game_Setting);
    }
}
