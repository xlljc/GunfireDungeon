
using System;
using System.Collections.Generic;
using DsUi;
using Godot;

/// <summary>
/// 房间的数据描述
/// </summary>
public class RoomInfo : IDestroy
{
    public RoomInfo(int id, DungeonRoomType type)
    {
        Id = id;
        RoomType = type;
    }

    public RoomInfo(int id, DungeonRoomType type, DungeonRoomSplit roomSplit)
    {
        Id = id;
        RoomType = type;
        RoomSplit = roomSplit;
    }

    /// <summary>
    /// 所在世界对象
    /// </summary>
    public World World;
    
    /// <summary>
    /// 房间 id
    /// </summary>
    public int Id;

    /// <summary>
    /// 房间类型
    /// </summary>
    public DungeonRoomType RoomType;

    /// <summary>
    /// 层级, 也就是离初始房间间隔多少个房间
    /// </summary>
    public int Layer;
    
    /// <summary>
    /// 生成该房间使用的配置数据, 可能为 null
    /// </summary>
    public DungeonRoomSplit RoomSplit;
    
    /// <summary>
    /// 房间大小, 单位: 格
    /// </summary>
    public Vector2I Size;

    /// <summary>
    /// 房间位置, 单位: 格
    /// </summary>
    public Vector2I Position;
    
    /// <summary>
    /// 门
    /// </summary>
    public List<RoomDoorInfo> Doors = new List<RoomDoorInfo>();

    /// <summary>
    /// 连接该房间的过道占用区域信息
    /// </summary>
    public List<Rect2I> AisleArea = new List<Rect2I>();

    /// <summary>
    /// 下一个房间
    /// </summary>
    public List<RoomInfo> Next = new List<RoomInfo>();
    
    /// <summary>
    /// 上一个房间
    /// </summary>
    public RoomInfo Prev;

    /// <summary>
    /// 当前房间使用的预设
    /// </summary>
    public RoomPreinstall RoomPreinstall;

    /// <summary>
    /// 当前房间归属区域
    /// </summary>
    public AffiliationArea AffiliationArea;

    /// <summary>
    /// 静态渲染精灵根节点, 用于放置sprite
    /// </summary>
    public RoomStaticSprite StaticSprite;
    
    /// <summary>
    /// 静态精灵绘制画布
    /// </summary>
    public ImageCanvas StaticImageCanvas;

    /// <summary>
    /// 液体画布
    /// </summary>
    public LiquidCanvas LiquidCanvas;
    
    /// <summary>
    /// 房间迷雾
    /// </summary>
    public FogMask RoomFogMask;
    
    /// <summary>
    /// 房间坐标相对于画布坐标偏移量, 单位: 像素
    /// </summary>
    public Vector2I RoomOffset { get; private set; }
    
    /// <summary>
    /// 房间算上连接通道所占用的区域
    /// </summary>
    public Rect2I OuterRect { get; private set; }
    
    /// <summary>
    /// 画布占用区域, 单位: 像素
    /// </summary>
    public Rect2I CanvasRect { get; private set; }

    /// <summary>
    /// 是否处于闭关状态, 也就是房间门没有主动打开
    /// </summary>
    public bool IsSeclusion { get; private set; } = false;

    /// <summary>
    /// 用于标记攻击目标位置
    /// </summary>
    public Dictionary<long, Vector2> MarkTargetPosition { get; private set; } = new Dictionary<long, Vector2>();

    /// <summary>
    /// 房间预览纹理, 用于小地图
    /// </summary>
    public ImageTexture PreviewTexture { get; set; }

    /// <summary>
    /// 房间预览图, 用于小地图
    /// </summary>
    public TextureRect PreviewSprite { get; set; }
    
    /// <summary>
    /// 房间内的传送点, 单位: 格
    /// </summary>
    public Vector2I Waypoints { get; set; }

    /// <summary>
    /// 在 DungeonGenerator 中是否可以回滚, 如果可以回滚, 那么当前房间就只会有一个 NextRoom
    /// </summary>
    public bool CanRollback { get; set; } = false;
    
    public bool IsDestroyed { get; private set; }

    private bool _openDoorFlag = true;
    
    // private bool _beReady = false;
    // private bool _waveStart = false;
    // private int _currWaveIndex = 0;
    // private int _currWaveNumber = 0;
    //private List<ActivityMark> _currActivityMarks = new List<ActivityMark>();

    /// <summary>
    /// 重新计算占用的区域
    /// </summary>
    public void CalcRange()
    {
        var worldPos = GetWorldPosition();
        var pos = new Vector2I(worldPos.X, worldPos.Y);
        var minX = pos.X;
        var minY = pos.Y;
        var maxX = minX + GetWidth();
        var maxY = minY + GetHeight();

        //遍历每一个连接的门, 计算计算canvas覆盖范围
        foreach (var doorInfo in Doors)
        {
            var connectDoor = doorInfo.ConnectDoor;
            switch (connectDoor.Direction)
            {
                case DoorDirection.E:
                case DoorDirection.W:
                {
                    var (px1, py1) = connectDoor.GetWorldOriginPosition();
                    var py2 = py1 + 4 * GameConfig.TileCellSize;
                    if (px1 < minX)
                    {
                        minX = px1;
                    }
                    else if (px1 > maxX)
                    {
                        maxX = px1;
                    }

                    if (py1 < minY)
                    {
                        minY = py1;
                    }
                    else if (py1 > maxY)
                    {
                        maxY = py1;
                    }
                    
                    if (py2 < minY)
                    {
                        minY = py2;
                    }
                    else if (py2 > maxY)
                    {
                        maxY = py2;
                    }
                }
                    break;
                case DoorDirection.S:
                case DoorDirection.N:
                {
                    var (px1, py1) = connectDoor.GetWorldOriginPosition();
                    var px2 = px1 + 4 * GameConfig.TileCellSize;
                    if (px1 < minX)
                    {
                        minX = px1;
                    }
                    else if (px1 > maxX)
                    {
                        maxX = px1;
                    }

                    if (py1 < minY)
                    {
                        minY = py1;
                    }
                    else if (py1 > maxY)
                    {
                        maxY = py1;
                    }
                    
                    if (px2 < minX)
                    {
                        minX = px2;
                    }
                    else if (px2 > maxX)
                    {
                        maxX = px2;
                    }
                }
                    break;
            }
        }
        
        OuterRect = new Rect2I(minX, minY, maxX - minX, maxY - minY);
        
        var cMinX = minX - GameConfig.TileCellSize;
        var cMinY = minY - GameConfig.TileCellSize;
        var cMaxX = maxX + GameConfig.TileCellSize;
        var cMaxY = maxY + GameConfig.TileCellSize;
        CanvasRect = new Rect2I(cMinX, cMinY, cMaxX - cMinX, cMaxY - cMinY);

        RoomOffset = new Vector2I(worldPos.X - cMinX, worldPos.Y - cMinY);
    }
    
    /// <summary>
    /// 获取房间的全局坐标, 单位: 像素
    /// </summary>
    public Vector2I GetWorldPosition()
    {
        return new Vector2I(
            Position.X * GameConfig.TileCellSize,
            Position.Y * GameConfig.TileCellSize
        );
    }

    /// <summary>
    /// 获取房间左上角的 Tile 距离全局坐标原点的偏移, 单位: 像素
    /// </summary>
    /// <returns></returns>
    public Vector2I GetOffsetPosition()
    {
        if (RoomSplit == null)
        {
            return Vector2I.Zero;
        }
        return RoomSplit.RoomInfo.Position.AsVector2I() * GameConfig.TileCellSize;
    }
    
    /// <summary>
    /// 将房间配置中的坐标转为全局坐标, 单位: 像素
    /// </summary>
    public Vector2 ToGlobalPosition(Vector2 pos)
    {
        return GetWorldPosition() + pos - GetOffsetPosition();
    }
    
    /// <summary>
    /// 获取房间横轴结束位置, 单位: 格
    /// </summary>
    public int GetHorizontalEnd()
    {
        return Position.X + Size.X;
    }

    /// <summary>
    /// 获取房间纵轴结束位置, 单位: 格
    /// </summary>
    public int GetVerticalEnd()
    {
        return Position.Y + Size.Y;
    }
    
    /// <summary>
    /// 获取房间横轴开始位置, 单位: 格
    /// </summary>
    public int GetHorizontalStart()
    {
        return Position.X;
    }

    /// <summary>
    /// 获取房间纵轴开始位置, 单位: 格
    /// </summary>
    public int GetVerticalStart()
    {
        return Position.Y;
    }
    
    /// <summary>
    /// 获取房间门横轴结束位置, 单位: 格
    /// </summary>
    public int GetHorizontalDoorEnd()
    {
        return Position.X + Size.X - 1;
    }

    /// <summary>
    /// 获取房间门纵轴结束位置, 单位: 格
    /// </summary>
    public int GetVerticalDoorEnd()
    {
        return Position.Y + Size.Y - 1;
    }
    
    /// <summary>
    /// 获取房间门横轴开始位置, 单位: 格
    /// </summary>
    public int GetHorizontalDoorStart()
    {
        return Position.X + 1;
    }

    /// <summary>
    /// 获取房间门纵轴开始位置, 单位: 格
    /// </summary>
    public int GetVerticalDoorStart()
    {
        return Position.Y + 2;
    }

    /// <summary>
    /// 获取房间宽度, 单位: 像素
    /// </summary>
    public int GetWidth()
    {
        return Size.X * GameConfig.TileCellSize;
    }
    
    
    /// <summary>
    /// 获取房间高度, 单位: 像素
    /// </summary>
    public int GetHeight()
    {
        return Size.Y * GameConfig.TileCellSize;
    }
    
    /// <summary>
    /// 将世界坐标转为画布下的坐标
    /// </summary>
    public Vector2 ToCanvasPosition(Vector2 pos)
    {
        return pos - CanvasRect.Position;
    }
    
    public void Destroy()
    {
        if (IsDestroyed)
        {
            return;
        }

        IsDestroyed = true;
        //递归销毁下一个房间
        foreach (var nextRoom in Next)
        {
            nextRoom.Destroy();
        }
        Next.Clear();
        
        //销毁连接的门
        foreach (var roomDoorInfo in Doors)
        {
            roomDoorInfo.Destroy();
        }
        
        //销毁预设
        if (RoomPreinstall != null)
        {
            RoomPreinstall.Destroy();
            RoomPreinstall = null;
        }
        
        //销毁画布
        if (StaticImageCanvas != null)
        {
            StaticImageCanvas.Destroy();
        }
        
        //销毁液体画布
        if (LiquidCanvas != null)
        {
            LiquidCanvas.Destroy();
        }
        
        //销毁静态精灵节点
        if (StaticSprite != null)
        {
            StaticSprite.Destroy();
        }

        //销毁迷雾
        if (RoomFogMask != null)
        {
            RoomFogMask.Destroy();
        }

        //销毁所属区域对象
        if (AffiliationArea != null)
        {
            AffiliationArea.Destroy();
        }

        //销毁预览图
        if (PreviewTexture != null)
        {
            PreviewTexture.Dispose();
        }

        if (PreviewSprite != null)
        {
            PreviewSprite.QueueFree();
        }
        
        MarkTargetPosition.Clear();
    }
    
    /// <summary>
    /// 加载地牢完成
    /// </summary>
    public void OnReady()
    {
        //提前加载波
        RoomPreinstall.OnReady();
    }
    
    /// <summary>
    /// 玩家第一次进入房间, 房间准备好了, 准备刷敌人, 并且关闭所有<br/>
    /// 当清完每一波刷新的敌人后即可开门
    /// </summary>
    public void OnFirstEnter()
    {
        if (RoomPreinstall == null || RoomPreinstall.IsRunWave)
        {
            return;
        }
        
        //房间内有敌人, 或者会刷新敌人才会关门
        var hasEnemy = false;
        if (AffiliationArea.ExistEnterItem(activityObject => activityObject is Role role && role.IsEnemyWithPlayer())) //先判断房间里面是否有敌人
        {
            hasEnemy = true;
        }
        else if (RoomPreinstall.HasEnemy()) //在判断是否会刷出敌人
        {
            hasEnemy = true;
        }
        
        if (!hasEnemy) //没有敌人, 不关门
        {
            IsSeclusion = false;
            //执行第一波生成
            RoomPreinstall.StartWave();
            return;
        }

        //关门
        CloseDoor();
        IsSeclusion = true;

        //执行第一波生成
        RoomPreinstall.StartWave();
    }

    /// <summary>
    /// 当前房间所有敌人都被清除了
    /// </summary>
    public void OnClearRoom()
    {
        if (RoomPreinstall.IsLastWave) //所有 mark 都走完了
        {
            IsSeclusion = false;
            if (RoomPreinstall.HasEnemy())
            {
                //开门
                OpenDoor();
            }
            //所有标记执行完成
            RoomPreinstall.OverWave();
        }
        else //执行下一波
        {
            RoomPreinstall.NextWave();
        }
    }

    /// <summary>
    /// 打开所有门
    /// </summary>
    public void OpenDoor()
    {
        if (!_openDoorFlag)
        {
            _openDoorFlag = true;
            AffiliationArea.RestoreRegion();
        }
        
        foreach (var doorInfo in Doors)
        {
            doorInfo.Door.OpenDoor();
            
            //过道迷雾
            doorInfo.AisleFogArea.Monitoring = true;
            if (doorInfo.AisleFogMask.IsExplored)
            {
                //doorInfo.ClearFog();
                FogMaskHandler.RefreshAisleFog(doorInfo);
            }
        }
    }

    /// <summary>
    /// 关闭所有门
    /// </summary>
    public void CloseDoor()
    {
        if (_openDoorFlag)
        {
            _openDoorFlag = false;
            AffiliationArea.ExtendedRegion(new Vector2(GameConfig.TileCellSize * 4, GameConfig.TileCellSize * 4));
        }

        foreach (var doorInfo in Doors)
        {
            doorInfo.Door.CloseDoor();
            
            //过道迷雾
            doorInfo.AisleFogArea.Monitoring = false;
            if (doorInfo.AisleFogMask.IsExplored)
            {
                //doorInfo.DarkFog();
                FogMaskHandler.RefreshAisleFog(doorInfo);
            }
        }
    }
    
    /// <summary>
    /// 遍历房间以及后面的房间
    /// </summary>
    public void EachRoom(Action<RoomInfo> callback)
    {
        callback(this);
        if (Next != null)
        {
            foreach (var room in Next)
            {
                room.EachRoom(callback);
            }
        }
    }
}