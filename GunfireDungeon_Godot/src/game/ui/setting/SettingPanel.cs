using Config;
using Godot;

using DsUi;

namespace UI.Setting;

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
        S_BGM.Instance.ValueChanged += (double v) =>
        {
            var value = (float)v;
            GameApplication.Instance.GameSave.BgmVolume = value;
            SoundManager.SetBusValue(BUS.BGM, value);
        };
        //声音设置SFX
        S_SFX.Instance.ValueChanged += (double v) =>
        {
            var value = (float)v;
            GameApplication.Instance.GameSave.SfxVolume = value;
            SoundManager.SetBusValue(BUS.SFX, value);
        };
        //声音设置设置BGM SFX的值
        S_SFX.Instance.VisibilityChanged += () =>
        {
            S_BGM.Instance.Value = GameApplication.Instance.GameSave.BgmVolume;
            S_SFX.Instance.Value = GameApplication.Instance.GameSave.SfxVolume;
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
