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
        //-----------------------------------------------------------
    }
    
    public override void OnShowUi()
    {
        GameApplication.Instance.Cursor.AddBlockageMarking(GetInstanceId());
    }

    public override void OnHideUi()
    {
        GameApplication.Instance.Cursor.RemoveBlockageMarking(GetInstanceId());
    }

    public override void OnDestroyUi()
    {
        GameApplication.Instance.GameSave.Save();
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
