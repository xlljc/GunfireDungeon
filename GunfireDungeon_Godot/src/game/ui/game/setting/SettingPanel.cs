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
        S_FullScreen.L_CheckBox.Instance.ButtonPressed = DisplayServer.WindowGetMode() == DisplayServer.WindowMode.Fullscreen;
        S_FullScreen.L_CheckBox.Instance.Pressed += OnChangeFullScreen;
        //-----------------------------------------------------------
    }

    public override void OnDestroyUi()
    {
        GameApplication.Instance.GameSave.Save();
    }

    //切换全屏/非全屏
    private void OnChangeFullScreen()
    {
        var checkBox = S_FullScreen.L_CheckBox.Instance;
        GameApplication.Instance.GameSave.FullScreen = checkBox.ButtonPressed;
        if (checkBox.ButtonPressed)
        {
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
        }
        else
        {
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
        }
    }

}
