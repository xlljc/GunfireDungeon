using Config;
using Godot;

using DsUi;

namespace UI.game.Setting;

public partial class SettingPanel : Setting
{
    public override void OnCreateUi()
    {
        if (PrevUi != null)
        {
            //返回上一级UI
            S_Back.Instance.Pressed += () =>
            {
                OpenPrevUi();
            };
        }
        else
        {
            S_Back.Instance.Pressed += () =>
            {
                Destroy();
            };
        }
        
        //声音设置BGM
        var save = GameApplication.Instance.GameSave;
        S_BGM.Instance.ValueChanged += (double v) =>
        {
            var value = (float)v;
            save.BgmVolume = value;
            SoundManager.SetBusValue(BUS.BGM, value);
        };
        //声音设置SFX
        S_SFX.Instance.ValueChanged += (double v) =>
        {
            var value = (float)v;
            save.SfxVolume = value;
            SoundManager.SetBusValue(BUS.SFX, value);
        };
        //鼠标跟随进度
        S_FollowsMouseAmount.Instance.ValueChanged += (double v) =>
        {
            save.FollowsMouseAmount = (float)v;
            if (GameCamera.Main != null)
            {
                GameCamera.Main.FollowsMouseAmount = (float)v;
            }
        };
        //声音设置设置BGM SFX的值
        S_SFX.Instance.VisibilityChanged += () =>
        {
            S_BGM.Instance.Value = save.BgmVolume;
            S_SFX.Instance.Value = save.SfxVolume;
            S_FollowsMouseAmount.Instance.Value = save.FollowsMouseAmount;
        };


        //---------------------- 视频设置 -----------------------------
        //全屏属性
        S_FullScreen.Instance.ButtonPressed = save.FullScreen;
        S_FullScreen.Instance.Pressed += OnChangeFullScreen;
        
        //垂直同步
        S_VerticalSync.Instance.ButtonPressed = save.VerticalSync;
        S_VerticalSync.Instance.Pressed += OnChangeVerticalSync;
        
        //完美像素
        S_PerfectPixel.Instance.ButtonPressed = save.PerfectPixel;
        S_PerfectPixel.Instance.Pressed += () =>
        {
            save.PerfectPixel = S_PerfectPixel.Instance.ButtonPressed;
            GameApplication.Instance.SetPerfectPixel(save.PerfectPixel);
        };
        
        //----------------------- 手柄设置 -----------------------------

        S_LockAiming.Instance.ButtonPressed = save.JoystickAimAssist;
        S_LockAiming.Instance.Pressed += () =>
        {
            save.JoystickAimAssist = S_LockAiming.Instance.ButtonPressed;
            GameApplication.Instance.SetJoystickAimAssist(save.JoystickAimAssist);
        };
        
        S_AimStrength.Instance.Value = save.JoystickAimAssistStrength;
        S_AimStrength.Instance.ValueChanged += (double v) =>
        {
            save.JoystickAimAssistStrength = (float)v;
            GameApplication.Instance.SetJoystickAimAssistStrength(save.JoystickAimAssistStrength);
        };
    }
    
    public override void OnShowUi()
    {
        InputManager.AddBlockageMarking(GetInstanceId());
        HandlerFocusList();
    }

    public override void OnHideUi()
    {
        InputManager.RemoveBlockageMarking(GetInstanceId());
    }

    public override void OnDestroyUi()
    {
        GameApplication.Instance.GameSave.Save();
    }

    public override void Process(float delta)
    {
        if (Input.IsActionJustPressed(InputAction.UiCancel))
        {
            if (PrevUi != null)
            {
                OpenPrevUi();
            }
            else
            {
                Destroy();
            }
        }
    }

    private void HandlerFocusList()
    {
        Control prev = null;
        foreach (var child in S_SettingMenu.Instance.GetChildren())
        {
            if (child is HBoxContainer box && box.Visible)
            {
                foreach (var node in child.GetChildren())
                {
                    if (node is Control temp && (temp is CheckBox || temp is HSlider))
                    {
                        if (prev == null)
                        {
                            prev = temp;
                            temp.GrabFocus();
                        }
                        else
                        {
                            prev.FocusNext = prev.GetPathTo(temp);
                            prev = temp;
                        }
                        break;
                    }
                }
            }
            else if (child is Button btn && btn.Visible)
            {
                if (prev == null)
                {
                    prev = btn;
                    btn.GrabFocus();
                }
                else
                {
                    prev.FocusNext = prev.GetPathTo(btn);
                    prev = btn;
                }
            }
        }
    }

    //切换全屏/非全屏
    private void OnChangeFullScreen()
    {
        var pressed = S_FullScreen.Instance.ButtonPressed;
        GameApplication.Instance.GameSave.FullScreen = pressed;
        DisplayServer.WindowSetMode(pressed ? DisplayServer.WindowMode.Fullscreen : DisplayServer.WindowMode.Windowed);
    }

    //切换垂直同步
    private void OnChangeVerticalSync()
    {
        var pressed = S_VerticalSync.Instance.ButtonPressed;
        GameApplication.Instance.GameSave.VerticalSync = pressed;
        DisplayServer.WindowSetVsyncMode(pressed ? DisplayServer.VSyncMode.Enabled : DisplayServer.VSyncMode.Disabled);
    }

}
