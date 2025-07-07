using System;
using System.Collections.Generic;
using Godot;
using UI.debug.Debugger;

namespace UI.debug.Tools;

public partial class ToolsPanel : Tools
{
    private GameSave _save;
    // 监听按键按下 
    private List<KeyValuePair<MouseButton, Action>> _listeningMouseKey = new List<KeyValuePair<MouseButton, Action>>();
    
    public override void OnCreateUi()
    {
        _save = GameApplication.Instance.GameSave;

        // 显示帧率
        RefreshFpsVisible();
        S_FpsCheck.Instance.Pressed += () =>
        {
            _save.Debug.ShoFps = !_save.Debug.ShoFps;
            RefreshFpsVisible();
            _save.LateSave();
        };
        
        //帧率上限
        S_FPSInput.Instance.Text = _save.Debug.Fps.ToString();
        RefreshFps();
        S_FPSBtn.Instance.Pressed += () =>
        {
            _save.Debug.Fps = int.Parse(S_FPSInput.Instance.Text);
            RefreshFps();
            _save.LateSave();
        };
        
        // 调试绘制
        RefreshDebugDrawVisible();
        S_DebugDrawCheck.Instance.Pressed += () =>
        {
            _save.Debug.DebugDraw = !_save.Debug.DebugDraw;
            RefreshDebugDrawVisible();
            _save.LateSave();
        };
        
        // 消灭房间内的敌人
        S_KellEnemyBtn.Instance.Pressed += KellEnemyBtnClick;
        
        // 自杀
        S_KellSelfBtn.Instance.Pressed += KellSelfBtnClick;
        
        // 血量上限
        S_MaxHpBtn.Instance.Pressed += MaxHpBtnClick;
        
        // 血量
        S_HpBtn.Instance.Pressed += HpBtnClick;
                
        // 护盾上限
        S_MaxShieldBtn.Instance.Pressed += MaxShieldBtnClick;
        
        // 护盾
        S_ShieldBtn.Instance.Pressed += ShieldBtnClick;
        
        // 创建物体
        S_CreateObjectBtn.Instance.Pressed += CreateObjectBtnClick;
        
        // 相机距离
        S_CameraZoomNearly.Instance.Pressed += () =>
        {
            GameCamera.Main.Zoom *= 1.1f;
        };
        S_CameraZoomFar.Instance.Pressed += () =>
        {
            GameCamera.Main.Zoom /= 1.1f;
        };
        S_CameraZoomResult.Instance.Pressed += () =>
        {
            GameCamera.Main.Zoom = GameApplication.Instance.DefaultCameraZoom;
        };
        
        // 关闭房间迷雾
        S_CloseRoomFog.Instance.Pressed += CloseRoomFogClick;
    }

    public override void OnDestroyUi()
    {
        
    }

    public override void Process(float delta)
    {
        for (var i = 0; i < _listeningMouseKey.Count; i++)
        {
            var keyValuePair = _listeningMouseKey[i];
            if (Input.IsMouseButtonPressed(keyValuePair.Key))
            {
                try
                {
                    keyValuePair.Value();
                }
                finally
                {
                    _listeningMouseKey.RemoveAt(i--);
                }
            }
        }
    }

    private void RefreshFpsVisible()
    {
        S_FpsCheck.Instance.ButtonPressed = _save.Debug.ShoFps;
        if (ParentUi is DebuggerPanel debuggerPanel)
        {
            debuggerPanel.S_Fps.Instance.Visible = _save.Debug.ShoFps;
        }
    }

    private void RefreshFps()
    {
        Engine.MaxFps = _save.Debug.Fps;
    }

    private void RefreshDebugDrawVisible()
    {
        S_DebugDrawCheck.Instance.ButtonPressed = _save.Debug.DebugDraw;
        ActivityObject.IsDebug = _save.Debug.DebugDraw;
        GameApplication.Instance.DungeonManager?.QueueRedraw();
    }

    private void KellEnemyBtnClick()
    {
        var player = GameApplication.Instance.DungeonManager?.CurrWorld?.Player;
        if (player == null)
        {
            return;
        }

        var enemyList = player.AffiliationArea.FindIncludeItems(o => o is Role role && role.IsEnemyWithPlayer());
        foreach (var enemy in enemyList)
        {
            var hurt = ((Enemy)enemy).HurtArea;
            if (hurt.CanHurt(player.Camp))
            {
                var damage = new Dictionary<DamageType, int>();
                damage.Add(DamageType.Real, 10000);
                hurt.Hurt(player, damage, null, 0);
            }
        }
    }

    private void KellSelfBtnClick()
    {
        var player = GetPlayer();
        if (player == null)
        {
            return;
        }
        
        player.Hp = 0;
        player.HurtHandler(player, 10000, DamageType.Real, 0);
    }

    private void MaxHpBtnClick()
    {
        var player = GetPlayer();
        if (player == null)
        {
            return;
        }

        player.MaxHp = int.Parse(S_MaxHpInput.Instance.Text);
    }

    private void HpBtnClick()
    {
        var player = GetPlayer();
        if (player == null)
        {
            return;
        }

        player.Hp = int.Parse(S_HpInput.Instance.Text);
    }

    
    private void MaxShieldBtnClick()
    {
        var player = GetPlayer();
        if (player == null)
        {
            return;
        }

        player.MaxShield = int.Parse(S_MaxShieldInput.Instance.Text);
    }

    private void ShieldBtnClick()
    {
        var player = GetPlayer();
        if (player == null)
        {
            return;
        }

        player.Shield = int.Parse(S_ShieldInput.Instance.Text);
    }
    
    private void CreateObjectBtnClick()
    {
        ActivityType[] activityTypes = [ActivityType.Weapon, ActivityType.Prop, ActivityType.Enemy, ActivityType.Boss, ActivityType.Treasure];
        EditorWindowManager.ShowSelectObject(activityTypes, (item) =>
        {
            var dungeonManager = GameApplication.Instance.DungeonManager;
            if (item == null || !dungeonManager.IsInDungeon)
            {
                return;
            }
            
            if (ParentUi is DebuggerPanel debugger)
            {
                debugger.OnClose();
                // 监听右键按下
                var instanceId = GetInstanceId();
                GameApplication.Instance.Cursor.AddBlockageMarking(instanceId);
                _listeningMouseKey.Add(new KeyValuePair<MouseButton, Action>(MouseButton.Left, () =>
                {
                    this.CallDelayInNode(0.5f, () => GameApplication.Instance.Cursor.RemoveBlockageMarking(instanceId));
                    var o = ActivityObject.Create(item);
                    o.PutDown(InputManager.CursorPosition, o.DefaultLayer);
                }));
            }
        }, ParentUi);
    }


    private Role GetPlayer()
    {
        return GameApplication.Instance.DungeonManager?.CurrWorld?.Player;
    }

    private void CloseRoomFogClick()
    {
        var dungeonManager = GameApplication.Instance.DungeonManager;
        if (dungeonManager.CurrWorld != null)
        {
            dungeonManager.CurrWorld.Color = new Color(1, 1, 1, 1); //关闭迷雾
            this.CallDelay(1, () =>
            {
                dungeonManager.StartRoomInfo?.EachRoom(info =>
                {
                    info.PreviewSprite.Visible = true;
                    foreach (var roomDoorInfo in info.Doors)
                    {
                        roomDoorInfo.AislePreviewSprite.Visible = true;
                    }
                });
            });
        }
    }
}
