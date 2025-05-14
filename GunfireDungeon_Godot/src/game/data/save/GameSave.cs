
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Godot;
using FileAccess = Godot.FileAccess;

public partial class GameSave
{
    /// <summary>
    /// 是否全屏
    /// </summary>
    [JsonInclude]
    public bool FullScreen = false;
    
    /// <summary>
    /// 是否垂直同步
    /// </summary>
    [JsonInclude]
    public bool VerticalSync = true;
    
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
    
    private float _timer;

    public void Init(GameApplication app)
    {
        DisplayServer.WindowSetMode(FullScreen ? DisplayServer.WindowMode.Fullscreen : DisplayServer.WindowMode.Windowed);
        DisplayServer.WindowSetVsyncMode(VerticalSync ? DisplayServer.VSyncMode.Enabled : DisplayServer.VSyncMode.Disabled);
        SoundManager.SetBusValue(BUS.BGM, BgmVolume);
        SoundManager.SetBusValue(BUS.SFX, SfxVolume);
        app.SetPerfectPixel(PerfectPixel);
    }

    public void Save()
    {
        var options = new JsonSerializerOptions();
        options.WriteIndented = true;
        var serialize = JsonSerializer.Serialize(this, options);
        
        SaveFile(GameConfig.GameSaveFile, serialize);
    }

    public static GameSave Load()
    {
        GameSave save;
        if (!HasFile(GameConfig.GameSaveFile))
        {
            save = new GameSave();
            save.Save();
        }
        else
        {
            save = JsonSerializer.Deserialize<GameSave>(ReadFile(GameConfig.GameSaveFile));
        }
        
        if (save.Debug == null)
        {
            save.Debug = new DebugData();
            save.Debug.Init();
        }
        
        return save;
    }

    /// <summary>
    /// 延时保存
    /// </summary>
    public void LateSave()
    {
        _timer = 3f;
    }

    public void Tick(float delta)
    {
        if (_timer > 0)
        {
            _timer -= delta;
            if (_timer <= 0)
            {
                Save();
            }
        }
    }

    private static void SaveFile(string fileName, string text)
    {
        var osName = OS.GetName();
        if (osName == "Windows")
        {
            File.WriteAllText(fileName, text);
        }
        else if (osName == "macOS")
        {
#if TOOLS
            File.WriteAllText(fileName, text);
#else
            var file = FileAccess.Open("user://" + fileName, FileAccess.ModeFlags.Write);
            file.StoreString(text);
            file.Close();
#endif
        }
        else
        {
            var file = FileAccess.Open("user://" + fileName, FileAccess.ModeFlags.Write);
            file.StoreString(text);
            file.Close();
        }
    }

    private static bool HasFile(string fileName)
    {
        var osName = OS.GetName();
        if (osName == "Windows")
        {
            return File.Exists(fileName);
        }
        else if (osName == "macOS")
        {
#if TOOLS
            return File.Exists(fileName);
#else
            return FileAccess.FileExists("user://" + fileName);
#endif
        }
        else
        {
            return FileAccess.FileExists("user://" + fileName);
        }
    }

    private static string ReadFile(string fileName)
    {
        var osName = OS.GetName();
        if (osName == "Windows")
        {
            return File.ReadAllText(fileName);
        }
        else if (osName == "macOS")
        {
#if TOOLS
            return File.ReadAllText(fileName);
#else
            var file = FileAccess.Open("user://" + fileName, FileAccess.ModeFlags.Write);
            var save = file.GetAsText();
            file.Close();
            return save;
            
#endif
        }
        else
        {
            var file = FileAccess.Open("user://" + fileName, FileAccess.ModeFlags.Read);
            var save = file.GetAsText();
            file.Close();
            return save;
        }
    }
}