
using Godot;

public static class GameConfig
{
    // --------------------- 可配置项 ---------------------
    
    /// <summary>
    /// 散射计算的默认距离
    /// </summary>
    public static float ScatteringDistance = 300;
    /// <summary>
    /// 重力加速度
    /// </summary>
    public static float G = 250f;
    /// <summary>
    /// Ai攻击距离
    /// </summary>
    public static float AiAttackDistance = 300;
    
    // ----------------------- 常量 -----------------------

    /// <summary>
    /// 液体画布渐变梯度
    /// </summary>
    public const float LiquidGradient = 0.1f;

    /// <summary>
    /// 液体画布可绘制区域边距
    /// </summary>
    public const int LiquidMargin = 2;
    
    /// <summary>
    /// 连接房间的过道宽度
    /// </summary>
    public const int CorridorWidth = 4;
    /// <summary>
    /// 游戏地图网格大小, 值为 16
    /// </summary>
    public const int TileCellSize = 16;
    /// <summary>
    /// 游戏地图网格大小, 向量表示
    /// </summary>
    public static readonly Vector2I TileCellSizeVector2I = new Vector2I(TileCellSize, TileCellSize);
    /// <summary>
    /// 房间最小间距
    /// </summary>
    public const int RoomSpace = 4;

    /// <summary>
    /// 地图配置路径
    /// </summary>
    public const string RoomTileDir = "resource/map/tileMaps/";
    /// <summary>
    /// 房间TileSet路径
    /// </summary>
    public const string RoomTileSetDir = "resource/map/tileSet/";
    /// <summary>
    /// 房间组配置文件名称
    /// </summary>
    public const string RoomGroupConfigFile = "GroupConfig.json";
    /// <summary>
    /// TileSet配置文件
    /// </summary>
    public const string TileSetConfigFile = "TileSetConfig.json";
    /// <summary>
    /// ui预制体路径
    /// </summary>
    public const string UiPrefabDir = "prefab/ui/";
    /// <summary>
    /// ui代码根路径
    /// </summary>
    public const string UiCodeDir = "src/game/ui/";

    /// <summary>
    /// 配置层级的自定义数据名称
    /// </summary>
    public const string CustomTileLayerName = "TileLayer";

    /// <summary>
    /// 预览图大小
    /// </summary>
    public const int PreviewImageSize = 196;

    /// <summary>
    /// 变暗迷雾的透明度值
    /// </summary>
    public const float DarkFogAlpha = 0.2f;

    /// <summary>
    /// 迷雾过渡时间
    /// </summary>
    public const float FogTransitionTime = 0.3f;

    /// <summary>
    /// 导航网格代理收缩半径
    /// </summary>
    public const float NavigationAgentRadius = 6f;

    /// <summary>
    /// 寻路导航单格步长
    /// </summary>
    public const float NavigationCellSize = 4;
    
    /// <summary>
    /// 游戏存档文件名称
    /// </summary>
    public const string GameSaveFile = "GameSave.json";
    
    /// <summary>
    /// 地形掩码纹理大小, 顶部墙壁/47格地形
    /// </summary>
    public static readonly Vector2I TerrainBit3x3 = new Vector2I(12, 4);
    /// <summary>
    /// 地形掩码纹理大小, 13格地形
    /// </summary>
    public static readonly Vector2I TerrainBit2x2 = new Vector2I(5, 3);
    /// <summary>
    /// 地形掩码纹理大小, 侧方墙壁
    /// </summary>
    public static readonly Vector2I TerrainBitMiddle = new Vector2I(4, 2);
    /// <summary>
    /// 地形掩码纹理大小, 地板
    /// </summary>
    public static readonly Vector2I TerrainBitFloor = new Vector2I(1, 1);
}