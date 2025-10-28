using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DsUi;
using Godot;
using Godot.Collections;

/// <summary>
/// 游戏世界
/// </summary>
public partial class World : CanvasModulate, ICoroutine, IDestroy
{
    /// <summary>
    /// 当前的游戏世界对象
    /// </summary>
    public static World Current => GameApplication.Instance.DungeonManager.CurrWorld;
    
    public bool IsDestroyed { get; private set; }
    
    /// <summary>
    /// 当前操作的玩家
    /// </summary>
    public Role Player { get; private set; }
    
    /// <summary>
    /// //对象根节点
    /// </summary>
    [Export]
    public Node2D NormalLayer;
    
    /// <summary>
    /// 对象根节点, 带y轴排序功能
    /// </summary>
    [Export]
    public Node2D YSortLayer;
    
    /// <summary>
    /// 静态精灵根节点
    /// </summary>
    [Export]
    public Node2D StaticSpriteRoot;
    
    /// <summary>
    /// 阵营区域根节点
    /// </summary>
    [Export]
    public Node2D AffiliationAreaRoot;
    
    /// <summary>
    /// 迷雾遮罩根节点
    /// </summary>
    [Export]
    public Node2D FogMaskRoot;
    
    /// <summary>
    /// 导航根节点
    /// </summary>
    [Export]
    public Node2D NavigationRoot;
    
    /// <summary>
    /// 背景音乐播放器
    /// </summary>
    public SoundManager.GameAudioPlayer BgmAudio { get; private set; }
    
    /// <summary>
    /// 是否暂停
    /// </summary>
    public bool Pause
    {
        get => _pause;
        set
        {
            if (_pause != value)
            {
                _pause = value;
                if (value) //暂停
                {
                    ProcessMode = ProcessModeEnum.WhenPaused;
                    if (BgmAudio != null)
                    {
                        BgmAudio.SetVolume(BgmAudio.DefaultVolume * 0.4f);
                    }
                }
                else //取消暂停
                {
                    ProcessMode = ProcessModeEnum.Inherit;
                    if (BgmAudio != null)
                    {
                        BgmAudio.SetVolume(BgmAudio.DefaultVolume);
                    }
                }
            }
        }
    }
    
    /// <summary>
    /// 所有被扔在地上的武器
    /// </summary>
    public HashSet<Weapon> Weapon_UnclaimedList { get; } = new HashSet<Weapon>();
    
    /// <summary>
    /// 记录所有存活的角色
    /// </summary>
    public List<Role> Role_InstanceList  { get; } = new List<Role>();
    
    /// <summary>
    /// 随机数对象
    /// </summary>
    public SeedRandom Random { get; private set; }
    
    /// <summary>
    /// 随机对象池
    /// </summary>
    public RandomPool RandomPool { get; private set; }
    
    /// <summary>
    /// 角色死亡事件
    /// </summary>
    public event Action<Role> OnRoleDieEvent; 
    
    private bool _pause = false;
    private List<CoroutineData> _coroutineList;
    // 地图层级字典
    private System.Collections.Generic.Dictionary<int, TileMapLayer> _tileMapLayers = new System.Collections.Generic.Dictionary<int, TileMapLayer>();
    // 地砖集
    private TileSet _tileSet;
    
    public override void _Process(double delta)
    {
        //协程更新
        ProxyCoroutineHandler.ProxyUpdateCoroutine(ref _coroutineList, (float)delta);
    }

    /// <summary>
    /// 获取指定层级根节点
    /// </summary>
    public Node2D GetRoomLayer(RoomLayerEnum layerEnum)
    {
        switch (layerEnum)
        {
            case RoomLayerEnum.NormalLayer:
                return NormalLayer;
            case RoomLayerEnum.YSortLayer:
                return YSortLayer;
        }

        return null;
    }

    /// <summary>
    /// 设置当前操作的玩家对象
    /// </summary>
    public void SetCurrentPlayer(Role player)
    {
        var flag = Player == player;
        Player = player;
        //设置相机和鼠标跟随玩家
        GameCamera.Main.SetFollowTarget(player);
        GameApplication.Instance.Cursor.SetMountRole(player);
        
        if (!flag)
        {
            //通知角色改变
            EventManager.EmitEvent(EventEnum.OnChangePlayerRole, player);
            OnChangePlayerRole(player);
        }
    }

    private void OnChangePlayerRole(Role player)
    {
    }

    public void PlayBgm(string soundId)
    {
        StopBgm();
        BgmAudio = SoundManager.PlayTransitionMusic(soundId, 1);
    }

    public void StopBgm()
    {
        if (BgmAudio != null && BgmAudio.Playing)
        {
            BgmAudio.TransitionToStop();
            BgmAudio = null;
        }
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

    /// <summary>
    /// 初始化随机池
    /// </summary>
    public void InitRandomPool(SeedRandom random)
    {
        Random = random;
        RandomPool = new  RandomPool(this);
    }

    /// <summary>
    /// 角色死亡
    /// </summary>
    public void OnRoleDie(Role role)
    {
        ObjectPool.AddRoleDie(role);
        if (OnRoleDieEvent != null)
        {
            OnRoleDieEvent(role);
        }
    }

    /// <summary>
    /// 世界加载完成回调
    /// </summary>
    public virtual void OnLoadSuccess()
    {
    }
    
    ///  <summary>
    /// 世界卸载完成回调
    /// </summary>
    public virtual void OnUnloadSuccess()
    {
        StopBgm();
    }
    
    public virtual void Destroy()
    {
        if (IsDestroyed) return;
        IsDestroyed = true;
        QueueFree();
    }
    
    /// <summary>
    /// 设置地砖集
    /// </summary>
    /// <param name="tileSet"></param>
    public void SetTileSet(TileSet tileSet)
    {
        _tileSet = tileSet;
        foreach (var tileMapLayer in _tileMapLayers)
        {
            tileMapLayer.Value.TileSet = tileSet;
        }
    }
    
    /// <summary>
    /// 获取地砖集
    /// </summary>
    public TileSet GetTileSet()
    {
        return _tileSet;
    }
    
    /// <summary>
    /// 获取指定层级的 TileMapLayer
    /// </summary>
    public TileMapLayer GetTileMapLayer(int position)
    {
        if (_tileMapLayers.TryGetValue(position, out var tileMapLayer))
        {
            return tileMapLayer;
        }

        return null;
    }
    
    /// <summary>
    /// 添加指定层级的 TileMapLayer
    /// </summary>
    public TileMapLayer AddTileMapLayer(int toPosition)
    {
        if (!_tileMapLayers.ContainsKey(toPosition))
        {
            var tileMapLayer = new TileMapLayer();
            tileMapLayer.Name = $"TileMapLayer_{toPosition}";
            tileMapLayer.TileSet = _tileSet;
            CallDeferred(Node.MethodName.AddChild, tileMapLayer);
            CallDeferred(Node.MethodName.MoveChild, tileMapLayer, _tileMapLayers.Count);
            _tileMapLayers.Add(toPosition, tileMapLayer);
        }
        
        return _tileMapLayers[toPosition];
    }
    
    /// <summary>
    /// 移除指定层级的 TileMapLayer
    /// </summary>
    public void RemoveTileMapLayer(int position)
    {
        if (_tileMapLayers.TryGetValue(position, out var tileMapLayer))
        {
            _tileMapLayers.Remove(position);
            tileMapLayer.QueueFree();
        }
    }
    
    /// <summary>
    /// 清空所有 TileMapLayer
    /// </summary>
    public void RemoveAllTileMapLayer()
    {
        foreach (var tileMapLayer in _tileMapLayers.Values)
        {
            tileMapLayer.QueueFree();
        }
        
        _tileMapLayers.Clear();
    }
    
    /// <summary>
    /// 获取 TileMapLayer 数量
    /// </summary>
    public int GetTileMapLayerCount()
    {
        return _tileMapLayers.Count;
    }

    public Vector2I GetCellAtlasCoords(int autoTopLayer, Vector2I pos)
    {
        var tileMapLayer = GetTileMapLayer(autoTopLayer);
        if (tileMapLayer != null)
        {
            return tileMapLayer.GetCellAtlasCoords(pos);
        }

        return new Vector2I(-1, -1);
    }
    
    public Rect2I GetUsedRect()
    {
        Rect2I? usedRect = null;
        foreach (var tileMapLayer in _tileMapLayers.Values)
        {
            var layerUsedRect = tileMapLayer.GetUsedRect();
            if (usedRect == null)
            {
                usedRect = layerUsedRect;
            }
            else
            {
                usedRect = usedRect.Value.Merge(layerUsedRect);
            }
        }

        return usedRect == null ? new Rect2I() : usedRect.Value;
    }

    public int GetCellSourceId(int autoTopLayer, Vector2I pos)
    {
        var tileMapLayer = GetTileMapLayer(autoTopLayer);
        if (tileMapLayer != null)
        {
            return tileMapLayer.GetCellSourceId(pos);
        }

        return -1;
    }

    public void SetLayerEnabled(int autoTopLayer, bool flag)
    {
        var tileMapLayer = GetTileMapLayer(autoTopLayer);
        if (tileMapLayer != null)
        {
            tileMapLayer.Visible = flag;
        }
    }

    public Array<Vector2I> GetUsedCells(int autoFloorLayer)
    {
        var tileMapLayer = GetTileMapLayer(autoFloorLayer);
        if (tileMapLayer != null)
        {
            return tileMapLayer.GetUsedCells();
        }

        return null;
    }

    public void ClearLayer(int autoMiddleLayer)
    {
        var tileMapLayer = GetTileMapLayer(autoMiddleLayer);
        if (tileMapLayer != null)
        {
            tileMapLayer.Clear();
        }
    }

    public void SetCell(int layer, Vector2I pos, int mainSource, Vector2I atlasCoords)
    {
        var tileMapLayer = GetTileMapLayer(layer);
        if (tileMapLayer != null)
        {
            tileMapLayer.SetCell(pos, mainSource, atlasCoords);
        }
    }

    public void SetCell(int layer, Vector2I pos, int mainSource)
    {
        var tileMapLayer = GetTileMapLayer(layer);
        if (tileMapLayer != null)
        {
            tileMapLayer.SetCell(pos, mainSource);
        }
    }
}
