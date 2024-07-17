
using Godot;

/// <summary>
/// 地牢房间出口
/// </summary>
public partial class RoomExit : Area2D
{
    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }
    
    private void OnBodyEntered(Node body)
    {
        if (body is Role role)
        {
            //Debug.Log("::RoomExit::OnBodyEntered");
            var gameApplication = GameApplication.Instance;

            if (gameApplication.DungeonManager.IsEditorMode) //编辑器模式下下一层就是当前层, 相当于重新开始
            {
                EditorPlayManager.Restart();
            }
            else
            {
                var nextName = gameApplication.GetNextDungeonGroup(gameApplication.DungeonManager.CurrConfig.GroupName);
                if (string.IsNullOrEmpty(nextName)) //没有下一层, 表示已经通关
                {
                    World.Current.Pause = true;
                    var openVictory = UiManager.Open_Victory();
                    openVictory.Callback = () =>
                    {
                        //先直接返回大厅, 后面再补充流程
                        UiManager.Open_Loading();
                        GameApplication.Instance.DungeonManager.LoadRoleId = ActivityObject.Ids.Id_role0001;
                        GameApplication.Instance.DungeonManager.ExitDungeon(false, () =>
                        {
                            GameApplication.Instance.DungeonManager.LoadHall(() =>
                            {
                                World.Current.Pause = false;
                                UiManager.Destroy_Loading();
                            });
                        });
                    };
                }
                else //有下一层
                {
                    var config = gameApplication.GetDungeonConfig(nextName, gameApplication.DungeonManager.CurrConfig.DungeonLayer + 1);
                    
                    UiManager.Open_Loading();
                    GameApplication.Instance.DungeonManager.RestartDungeon(true, config, () =>
                    {
                        UiManager.Destroy_Loading();
                    });
                }
            }
        }
    }
}