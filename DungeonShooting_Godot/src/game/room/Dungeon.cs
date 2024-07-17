using Godot;

/// <summary>
/// 地牢类
/// </summary>
public partial class Dungeon : World
{
    /// <summary>
    /// 地牢配置
    /// </summary>
    public DungeonConfig DungeonConfig { get; set; }
    
    /// <summary>
    /// 地牢房间组
    /// </summary>
    public DungeonRoomGroup RoomGroup { get; set; }

    public override void _Ready()
    {
        base._Ready();
        Color = Colors.Black;
        //Debug.Log("[临时处理]: 这里设置房间迷雾");
    }

    /// <summary>
    /// 初始化 TileMap 中的层级
    /// </summary>
    public void InitLayer()
    {
        MapLayerManager.InitMapLayer(TileRoot);
    }
}