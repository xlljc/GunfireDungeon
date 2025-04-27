
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Godot;

public class GameSave
{
    /// <summary>
    /// 是否全屏
    /// </summary>
    [JsonInclude]
    public bool FullScreen = false;
    
    /// <summary>
    /// 背景音乐音量, (0 - 1)
    /// </summary>
    [JsonInclude]
    public float BgmVolume = 0.5f;
    
    /// <summary>
    /// 音效音量, (0 - 1)
    /// </summary>
    [JsonInclude]
    public float SfxVolume = 0.5f;

    /// <summary>
    /// 鼠标跟随进度（0 - 1）
    /// </summary>
    [JsonInclude]
    public float FollowsMouseAmount = 0f;

    /// <summary>
    /// 是否使用完美像素
    /// </summary>
    [JsonInclude]
    public bool PerfectPixel = true;

    public void Init(GameApplication app)
    {
        if (FullScreen)
        {
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
        }
        else
        {
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
        }
        
        SoundManager.SetBusValue(BUS.BGM, BgmVolume);
        SoundManager.SetBusValue(BUS.SFX, SfxVolume);
        app.SetPerfectPixel(PerfectPixel);
    }

    public void Save()
    {
        var options = new JsonSerializerOptions();
        options.WriteIndented = true;
        var serialize = JsonSerializer.Serialize(this, options);
        File.WriteAllText(GameConfig.GameSaveFile, serialize);
    }

    public static GameSave Load()
    {
        GameSave save;
        if (!File.Exists(GameConfig.GameSaveFile))
        {
            save = new GameSave();
            save.Save();
        }
        else
        {
            save = JsonSerializer.Deserialize<GameSave>(File.ReadAllText(GameConfig.GameSaveFile));
        }
        
        return save;
    }
}