
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using Config;
using DsUi;
using Godot;
using UI.game.BottomTips;

public partial class GameApplication : Node2D, ICoroutine
{
    public static GameApplication Instance { get; private set; }

    /// <summary>
    /// 是否启用调试绘制
    /// </summary>
    [Export]
    public bool DebugDraw;

    /// <summary>
    /// 场景根节点
    /// </summary>
    [Export]
    public Node2D SceneRoot;
    
    /// <summary>
    /// 全局根节点
    /// </summary>
    [Export]
    public Node2D GlobalNodeRoot;
    
    /// <summary>
    /// 游戏渲染视口
    /// </summary>
    [Export]
    private SubViewport SubViewport;

    /// <summary>
    /// SubViewportContainer 组件
    /// </summary>
    [Export]
    private SubViewportContainer SubViewportContainer;

    [Export]
    private CanvasLayer ViewCanvas;

    [Export]
    private Node NoPerfectPixelRoot;

    /// <summary>
    /// 是否使用完美像素
    /// </summary>
    public bool PerfectPixel { get; private set; } = true;
    
    /// <summary>
    /// 游戏目标帧率
    /// </summary>
    public int TargetFps { get; private set; }
    
    /// <summary>
    /// 鼠标指针
    /// </summary>
    public Cursor Cursor { get; private set; }

    /// <summary>
    /// 地牢管理器
    /// </summary>
    public DungeonManager DungeonManager { get; private set; }
    
    /// <summary>
    /// 房间配置
    /// </summary>
    public Dictionary<string, DungeonRoomGroup> RoomConfig { get; private set; }
    
    /// <summary>
    /// TileSet配置
    /// </summary>
    public Dictionary<string, TileSetSplit> TileSetConfig { get; private set; }
    
    // /// <summary>
    // /// 房间配置数据, key: 模板房间资源路径
    // /// </summary>
    // public Dictionary<string, DungeonRoomSplit> RoomConfigMap { get; private set; }

    /// <summary>
    /// 游戏视图大小
    /// </summary>
    public Vector2 ViewportSize { get; private set; } = new Vector2(480, 270);
    
    /// <summary>
    /// 像素缩放
    /// </summary>
    public int PixelScale { get; private set; } = 4;
    
    /// <summary>
    /// 第一层地牢配置信息
    /// </summary>
    public DungeonConfig FirstDungeonConfig { get; private set; }

    /// <summary>
    /// 地牢组加载顺序
    /// </summary>
    public List<string> DungeonGroupList { get; } = new List<string>();

    /// <summary>
    /// 游戏存档
    /// </summary>
    public GameSave GameSave { get; private set; }
    
    /// <summary>
    /// 默认相机缩放
    /// </summary>
    public Vector2 DefaultCameraZoom { get; private set; } = Vector2.One;
    
    //开启的协程
    private List<CoroutineData> _coroutineList;
    
    public GameApplication()
    {
        Instance = this;
        TargetFps = Mathf.RoundToInt(DisplayServer.ScreenGetRefreshRate());
        
        Utils.InitRandom();

        //初始化配置表
        ExcelConfig.Init();
        PreinstallMarkManager.Init();
        PropFragmentRegister.Init();
        //初始化房间配置数据
        InitRoomConfig();
        //初始化TileSet配置数据
        InitTileSetConfig();
        //初始化武器数据
        Weapon.InitWeaponAttribute();
        //初始化敌人数据
        Enemy.InitEnemyAttribute();
        //初始化buff数据
        BuffProp.InitBuffAttribute();
        //初始化主动道具数据
        ActiveProp.InitActiveAttribute();
        //初始化零件数据
        PartProp.InitPartAttribute();
        
        foreach (var dungeonRoomGroup in RoomConfig)
        {
            DungeonGroupList.Add(dungeonRoomGroup.Key);
        }

        FirstDungeonConfig = GetDungeonConfig(DungeonGroupList[0], 1);
        
        //临时处理
        //RoomConfig[DungeonGroupList[0]].BgColor = new Color("0a0a19");
        RoomConfig[DungeonGroupList[0]].SoundId = null; //"level1_bgm";
    }

    /// <summary>
    /// 获取地牢配置数据
    /// </summary>
    public DungeonConfig GetDungeonConfig(string groupName, int layer)
    {
        var config = new DungeonConfig();
        config.DungeonLayer = layer;
        config.GroupName = groupName;
        config.RandomSeed = null;

        config.BattleRoomCount = 12;
        config.RewardRoomCount = 2;
        config.BossRoomCount = 0;

        config.ShopRoomCount = 1;
        config.EnableLimitRange = false;
        config.AllowedCornerAisles = false;
        return config;
    }

    /// <summary>
    /// 获取下一个地牢组名称
    /// </summary>
    /// <param name="currGroupName">当前地牢组名称</param>
    public string GetNextDungeonGroup(string currGroupName)
    {
        var index = DungeonGroupList.IndexOf(currGroupName);
        if (index == -1 || index == DungeonGroupList.Count - 1)
        {
            return null;
        }
        return DungeonGroupList[index + 1];
    }

    public override void _EnterTree()
    {
        //编辑器弹窗设置为使用windows弹窗
        GetViewport().GuiEmbedSubwindows = false;
        //背景颜色
        RenderingServer.SetDefaultClearColor(new Color(0, 0, 0, 1));
        //随机化种子
        GD.Randomize();
        //固定帧率
        //Engine.MaxFps = TargetFps;
        //调试绘制开关
        ActivityObject.IsDebug = DebugDraw;
        //Engine.TimeScale = 0.2f;
        
        //调整窗口分辨率
        OnWindowSizeChanged();
        //窗体大小改变
        //GetWindow().SizeChanged += OnWindowSizeChanged;

        ImageCanvas.Init(GetTree().CurrentScene);
        
        //加载存档
        LoadGameSave(this);
        
        //调试Ui
        UiManager.Open_Debug_Debugger();
        
        // 初始化鼠标
        InitCursor();
        //地牢管理器
        DungeonManager = new DungeonManager(ActivityObject.Ids.Id_role0001);
        DungeonManager.Name = "DungeonManager";
        SceneRoot.AddChild(DungeonManager);

        MapProjectManager.Init();
        EditorTileSetManager.Init();
        BottomTipsPanel.Init();

        this.CallDelay(0, () =>
        {
            //打开主菜单Ui
            UiManager.Open_Game_Main();
        });
    }

    public override void _Process(double delta)
    {
        var newDelta = (float)delta;
        InputManager.Update(newDelta);
        SoundManager.Update(newDelta);
        
        //协程更新
        ProxyCoroutineHandler.ProxyUpdateCoroutine(ref _coroutineList, newDelta);
    }

    /// <summary>
    /// 将Ui坐标转换为游戏中的世界坐标
    /// </summary>
    public Vector2 UiToWorldPosition(Vector2 uiPos)
    {
        if (PerfectPixel)
        {
            return uiPos / PixelScale - ViewportSize / 2 + GameCamera.Main.GlobalPosition - GameCamera.Main.PixelOffset;
        }

        return (uiPos - GetWindow().Size / 2) / GameCamera.Main.Zoom + GameCamera.Main.GlobalPosition + GameCamera.Main.Offset;
    }

    /// <summary>
    /// 将游戏中的世界坐标转换为Ui坐标
    /// </summary>
    public Vector2 WorldToUiPosition(Vector2 worldPos)
    {
        if (PerfectPixel)
        {
            return (worldPos + GameCamera.Main.PixelOffset - (GameCamera.Main.GlobalPosition + GameCamera.Main.Offset) + ViewportSize / 2) * PixelScale;
        }

        return (worldPos - GameCamera.Main.GlobalPosition - GameCamera.Main.Offset) * GameCamera.Main.Zoom + GetWindow().Size / 2;
    }

    public long StartCoroutine(IEnumerator able)
    {
        return ProxyCoroutineHandler.ProxyStartCoroutine(ref _coroutineList, able);
    }
    
    public void StopCoroutine(long coroutineId)
    {
        ProxyCoroutineHandler.ProxyStopCoroutine(ref _coroutineList, coroutineId);
    }

    public bool IsCoroutineOver(long coroutineId)
    {
        return ProxyCoroutineHandler.ProxyIsCoroutineOver(ref _coroutineList, coroutineId);
    }

    public void StopAllCoroutine()
    {
        ProxyCoroutineHandler.ProxyStopAllCoroutine(ref _coroutineList);
    }

    public void SetRoomConfig(Dictionary<string,DungeonRoomGroup> roomConfig)
    {
        foreach (var dungeonRoomGroup in roomConfig)
        {
            if (RoomConfig.TryGetValue(dungeonRoomGroup.Key, out var temp))
            {
                dungeonRoomGroup.Value.BgColor = temp.BgColor;
                dungeonRoomGroup.Value.SoundId = temp.SoundId;
            }
        }
        RoomConfig = roomConfig;
        InitReadyRoom();
    }

    /// <summary>
    /// 获取子视图容器的材质，该材质用于完美像素
    /// </summary>
    /// <returns></returns>
    public ShaderMaterial GetSubViewportContainerMaterial()
    {
        return (ShaderMaterial)SubViewportContainer.Material;
    }

    /// <summary>
    /// 设置是否启用完美像素
    /// </summary>
    public void SetPerfectPixel(bool v)
    {
        if (PerfectPixel == v) return;
        PerfectPixel = v;

        if (v) //完美像素
        {
            DefaultCameraZoom = Vector2.One;
            GameCamera.Main.Zoom = DefaultCameraZoom;
            SceneRoot.Reparent(SubViewport);
            GameCamera.Main.Reparent(SubViewport);
        }
        else
        {
            DefaultCameraZoom = new Vector2(PixelScale, PixelScale);
            GameCamera.Main.Zoom = DefaultCameraZoom;
            SceneRoot.Reparent(NoPerfectPixelRoot);
            GameCamera.Main.Reparent(NoPerfectPixelRoot);
        }
    }

    //初始化房间配置
    private void InitRoomConfig()
    {
        //加载房间配置信息
        var asText = ResourceManager.LoadText("res://" + GameConfig.RoomTileDir + GameConfig.RoomGroupConfigFile);
        RoomConfig = JsonSerializer.Deserialize<Dictionary<string, DungeonRoomGroup>>(asText);

        InitReadyRoom();
    }
    
    //初始化房间数据
    private void InitReadyRoom()
    {
        foreach (var dungeonRoomGroup in RoomConfig)
        {
            RemoveUnreadyRooms(dungeonRoomGroup.Value.BattleList);
            RemoveUnreadyRooms(dungeonRoomGroup.Value.InletList);
            RemoveUnreadyRooms(dungeonRoomGroup.Value.OutletList);
            RemoveUnreadyRooms(dungeonRoomGroup.Value.BossList);
            RemoveUnreadyRooms(dungeonRoomGroup.Value.ShopList);
            RemoveUnreadyRooms(dungeonRoomGroup.Value.RewardList);
            RemoveUnreadyRooms(dungeonRoomGroup.Value.EventList);
        }
    }
    
    //移除未准备好的房间
    private void RemoveUnreadyRooms(List<DungeonRoomSplit> roomInfos)
    {
        for (var i = 0; i < roomInfos.Count; i++)
        {
            if (roomInfos[i].ErrorType != RoomErrorType.None) //存在错误
            {
                roomInfos.RemoveAt(i);
                i--;
            }
        }
    }

    //初始化TileSet配置
    private void InitTileSetConfig()
    {
        //加载房间配置信息
        var asText = ResourceManager.LoadText("res://" + GameConfig.RoomTileSetDir + GameConfig.TileSetConfigFile);
        TileSetConfig = JsonSerializer.Deserialize<Dictionary<string, TileSetSplit>>(asText);
        
        //加载所有数据
        foreach (var tileSetSplit in TileSetConfig)
        {
            tileSetSplit.Value.ReloadTileSetInfo();
        }
    }

    //窗体大小改变
    private void OnWindowSizeChanged()
    {
        var size = GetWindow().Size;
        ViewportSize = size / PixelScale;
        RefreshSubViewportSize();
    }
    
    //刷新视窗大小
    private void RefreshSubViewportSize()
    {
        var s = new Vector2I((int)ViewportSize.X, (int)ViewportSize.Y);
        s.X = s.X / 2 * 2 + 2;
        s.Y = s.Y / 2 * 2 + 2;
        SubViewport.Size = s;
        SubViewportContainer.Scale = new Vector2(PixelScale, PixelScale);
        SubViewportContainer.Size = s;
        SubViewportContainer.Position = new Vector2(-PixelScale, -PixelScale);
    }

    //初始化鼠标
    private void InitCursor()
    {
        Cursor = ResourceManager.LoadAndInstantiate<Cursor>(ResourcePath.prefab_Cursor_tscn);
        var cursorLayer = new CanvasLayer();
        cursorLayer.Name = "CursorLayer";
        cursorLayer.Layer = UiManager.GetUiLayer(UiLayer.Pop).Layer + 10;
        AddChild(cursorLayer);
        cursorLayer.AddChild(Cursor);
    }

    private void LoadGameSave(GameApplication app)
    {
        GameSave = GameSave.Load();
        GameSave.Init(app);
    }
}
