using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DsUi;
using Godot;

/// <summary>
/// 游戏世界
/// </summary>
public partial class World : CanvasModulate, ICoroutine, IDestroy
{
    /// <summary>
    /// 当前的游戏世界对象
    /// </summary>
    public static World Current => GameApplication.Instance.DungeonManager.CurrWorld;
    
    /// <summary>
    /// 当前操作的玩家
    /// </summary>
    public Role Player { get; private set; }
    
    /// <summary>
    /// //对象根节点
    /// </summary>
    public Node2D NormalLayer;
    
    /// <summary>
    /// 对象根节点, 带y轴排序功能
    /// </summary>
    public Node2D YSortLayer;
    
    /// <summary>
    /// 地图根节点
    /// </summary>
    public TileMap TileRoot;

    /// <summary>
    /// 背景音乐播放器
    /// </summary>
    public SoundManager.GameAudioPlayer BgmAudio { get; private set; }
    
    public bool IsDestroyed { get; private set; }
    
    public Node2D StaticSpriteRoot;
    public Node2D AffiliationAreaRoot;
    public Node2D FogMaskRoot;
    public Node2D NavigationRoot;
    
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
    /// 液体画布
    /// </summary>
    public LiquidCanvas LiquidCanvas { get; private set; }
    
    /// <summary>
    /// 角色死亡事件
    /// </summary>
    public event Action<Role> OnRoleDieEvent; 
    
    private bool _pause = false;
    private List<CoroutineData> _coroutineList;

    public override void _Ready()
    {
        //TileRoot.YSortEnabled = false;
        NormalLayer = GetNode<Node2D>("TileRoot/NormalLayer");
        YSortLayer = GetNode<Node2D>("TileRoot/YSortLayer");
        TileRoot = GetNode<TileMap>("TileRoot");
        StaticSpriteRoot = GetNode<Node2D>("TileRoot/StaticSpriteRoot");
        FogMaskRoot = GetNode<Node2D>("TileRoot/FogMaskRoot");
        NavigationRoot = GetNode<Node2D>("TileRoot/NavigationRoot");
        AffiliationAreaRoot = GetNode<Node2D>("TileRoot/AffiliationAreaRoot");
        LiquidCanvas = GetNode<LiquidCanvas>("TileRoot/StaticSpriteRoot/LiquidCanvas");
    }

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
}
