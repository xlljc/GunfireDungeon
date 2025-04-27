using Godot;
using System;
using System.Collections.Generic;
using Config;

/// <summary>
/// 武器的基类
/// </summary>
public abstract partial class Weapon : ActivityObject, IPackageItem<Role>
{
    /// <summary>
    /// 武器使用的属性数据, 该属性会根据是否是玩家使用武器, 如果是Ai使用武器, 则会返回 AiUseAttribute 的属性对象
    /// </summary>
    public ExcelConfig.WeaponBase Attribute => _weaponAttribute;

    /// <summary>
    /// Ai使用该武器的属性
    /// </summary>
    public ExcelConfig.WeaponBase AiUseAttribute => _aiWeaponAttribute;

    /// <summary>
    /// 玩家使用该武器的属性
    /// </summary>
    public ExcelConfig.WeaponBase PlayerUseAttribute => _playerWeaponAttribute;
    
    private ExcelConfig.WeaponBase _weaponAttribute;
    private ExcelConfig.WeaponBase _playerWeaponAttribute;
    private ExcelConfig.WeaponBase _aiWeaponAttribute;

    public Role Master { get; set; }

    public int PackageIndex { get; set; } = -1;

    /// <summary>
    /// 当前弹夹弹药剩余量
    /// </summary>
    public int CurrAmmo { get; private set; }

    /// <summary>
    /// 武器管的开火点
    /// </summary>
    [Export, ExportFillNode]
    public Marker2D FirePoint { get; set; }

    /// <summary>
    /// 弹壳抛出的点
    /// </summary>
    [Export, ExportFillNode]
    public Marker2D ShellPoint { get; set; }
    
    /// <summary>
    /// 武器的当前散射半径
    /// </summary>
    public float CurrScatteringRange { get; private set; } = 0;

    /// <summary>
    /// 是否在换弹中
    /// </summary>
    /// <value></value>
    public bool Reloading { get; private set; } = false;

    /// <summary>
    /// 换弹进度 (从 0 到 1)
    /// </summary>
    public float ReloadProgress
    {
        get
        {
            if (!Reloading)
            {
                return 1;
            }

            if (Attribute.AloneReload)
            {
                //总时间
                var total = Attribute.AloneReloadBeginIntervalTime + (Attribute.ReloadTime * Attribute.AmmoCapacity) + Attribute.AloneReloadFinishIntervalTime;
                //当前时间
                float current;
                if (_aloneReloadState == 1)
                {
                    current = (Attribute.AloneReloadBeginIntervalTime - _reloadTimer) + Attribute.ReloadTime * CurrAmmo;
                }
                else if (_aloneReloadState == 2)
                {
                    current = Attribute.AloneReloadBeginIntervalTime + (Attribute.ReloadTime * (CurrAmmo + (1 - _reloadTimer / Attribute.ReloadTime)));
                }
                else
                {
                    current = Attribute.AloneReloadBeginIntervalTime + (Attribute.ReloadTime * CurrAmmo) + (Attribute.AloneReloadFinishIntervalTime - _reloadTimer);
                }

                return current / total;
            }

            return 1 - _reloadTimer / Attribute.ReloadTime;
        }
    }

    /// <summary>
    /// 返回是否在蓄力中,
    /// 注意, 属性仅在 Attribute.LooseShoot == false 时有正确的返回值, 否则返回 false
    /// </summary>
    public bool IsCharging => _looseShootFlag;

    /// <summary>
    /// 返回武器是否在武器背包中
    /// </summary>
    public bool IsInHolster => Master != null;

    /// <summary>
    /// 返回是否真正使用该武器
    /// </summary>
    public bool IsActive => Master != null && Master.WeaponPack.ActiveItem == this;
    
    /// <summary>
    /// 动画播放器
    /// </summary>
    [Export, ExportFillNode]
    public AnimationPlayer AnimationPlayer { get; set; }

    /// <summary>
    /// 是否自动播放 SpriteFrames 的动画
    /// </summary>
    public bool IsAutoPlaySpriteFrames { get; set; } = true;

    /// <summary>
    /// 在没有所属 Master 的时候是否可以触发扳机
    /// </summary>
    public bool NoMasterCanTrigger { get; set; } = true;
    
    /// <summary>
    /// 上一次触发改武器开火的角色, 可能为 null
    /// </summary>
    public Role TriggerRole { get; private set; }
    
    /// <summary>
    /// 武器当前射速
    /// </summary>
    public float CurrFiringSpeed { get; private set; }

    /// <summary>
    /// 当前存储法力值
    /// </summary>
    public int CurrMana { get; private set; }

    /// <summary>
    /// 当前缓冲区法力值
    /// </summary>
    public int CurrBufferMana { get; private set; }
    
    /// <summary>
    /// 开火零件列表
    /// </summary>
    public PartList FirePartList { get; private set; }

    /// <summary>
    /// 所有零件列表
    /// </summary>
    public Dictionary<string, PartList> PartListMap { get; } = new Dictionary<string, PartList>();
    
    //--------------------------------------------------------------------------------------------

    //回复法力值计时器
    private float _manaRecoveryValue;
    
    //触发板机是是否计算弹药消耗
    private bool _triggerCalcAmmon = true;
    
    //用于记录是否有角色操作过这把武器
    private bool _triggerRoleFlag = false;
    
    //是否按下
    private bool _triggerFlag = false;

    //扳机计时器
    private float _triggerTimer = 0;

    //开火前延时时间
    private float _delayedTime = 0;

    //开火间隙时间
    private float _fireInterval = 0;

    //开火武器口角度
    private float _fireAngle = 0;

    //攻击冷却计时
    private float _attackTimer = 0;

    //攻击状态
    private bool _attackFlag = false;
    
    //多久没开火了
    private float _noAttackTime = 0;

    //按下的时间
    private float _downTimer = 0;

    //松开的时间
    private float _upTimer = 0;

    //连发次数
    private int _continuousCount = 0;

    //连发状态记录
    private bool _continuousShootFlag = false;

    //松开扳机是否开火
    private bool _looseShootFlag = false;

    //蓄力攻击时长
    private float _chargeTime = 0;

    //是否需要重置武器数据
    private bool _dirtyFlag = false;

    //当前后坐力导致的偏移长度
    private float _currBacklashLength = 0;

    //握把位置
    private Vector2 _gripPoint;

    //持握时 Sprite 偏移
    private Vector2 _gripOffset;

    //碰撞器位置
    private Vector2 _collPoint1;
    private Vector2 _collPoint2;

    //换弹计时器
    private float _reloadTimer = 0;
    
    //单独换弹设置下的换弹状态, 0: 未换弹, 1: 装第一颗子弹之前, 2: 单独装弹中, 3: 单独装弹完成
    private byte _aloneReloadState = 3;

    //单独换弹状态下是否强制结束换弹过程
    private bool _aloneReloadStop = false;
    
    //本次换弹已用时间
    private float _reloadUseTime = 0;

    //是否播放过换弹完成音效
    private bool _playReloadFinishSoundFlag = false;

    //上膛状态,-1: 等待执行自动上膛 , 0: 未上膛, 1: 上膛中, 2: 已经完成上膛
    private sbyte _beLoadedState = 2;

    //上膛计时器
    private float _beLoadedStateTimer = -1;

    //换弹投抛弹壳记录
    private bool _reloadShellFlag = false;

    //抖动强度
    private float _shakeStrength = 0;
    
    //抖动间隔
    private float _shakeInterval = 1 / 60f;
    
    //抖动计时器
    private float _shakeTimer = 0;

    //换弹完成后播放的动画
    private string _reloadNextAnimation;
    
    // ----------------------------------------------
    private uint _tempLayer;

    private static bool _init = false;
    private static Dictionary<string, ExcelConfig.WeaponBase> _weaponAttributeMap =
        new Dictionary<string, ExcelConfig.WeaponBase>();

    /// <summary>
    /// 初始化武器属性数据
    /// </summary>
    public static void InitWeaponAttribute()
    {
        if (_init)
        {
            return;
        }

        _init = true;
        foreach (var weaponAttr in ExcelConfig.WeaponBase_List)
        {
            if (weaponAttr.Activity != null)
            {
                if (!_weaponAttributeMap.TryAdd(weaponAttr.Activity.Id, weaponAttr))
                {
                    Debug.LogError("发现重复注册的武器属性: " + weaponAttr.Id);
                }
            }
        }
    }
    
    /// <summary>
    /// 根据 ActivityBase.Id 获取对应武器的属性数据
    /// </summary>
    public static ExcelConfig.WeaponBase GetWeaponAttribute(string itemId)
    {
        if (itemId == null)
        {
            return null;
        }
        if (_weaponAttributeMap.TryGetValue(itemId, out var attr))
        {
            return attr;
        }

        throw new Exception($"武器'{itemId}'没有在 WeaponBase 表中配置属性数据!");
    }
    
    public override void OnInit()
    {
        InitWeapon(GetWeaponAttribute(ActivityBase.Id));
        AnimatedSprite.AnimationFinished += OnAnimatedSpriteFinished;
        AnimationPlayer.AnimationFinished += OnAnimationPlayerFinished;
        _gripPoint = AnimatedSprite.Position;
        _gripOffset = AnimatedSprite.Offset;
        _collPoint1 = Collision.Position;
        _collPoint2 = _collPoint1 - AnimatedSprite.Offset - AnimatedSprite.Position;
        AnimatedSprite.Position = Vector2.Zero;
        AnimatedSprite.Offset = Vector2.Zero;
        Collision.Position = _collPoint2;
    }

    /// <summary>
    /// 初始化武器属性
    /// </summary>
    private void InitWeapon(ExcelConfig.WeaponBase attribute)
    {
        attribute = attribute.Clone();
        _playerWeaponAttribute = attribute;
        SetCurrentWeaponAttribute(attribute);
        if (ExcelConfig.WeaponBase_Map.TryGetValue(attribute.Id + "_ai", out var aiAttr))
        {
            _aiWeaponAttribute = aiAttr.Clone();
        }
        else
        {
            Debug.LogError("警告: 未找到 AI 武器属性: " + attribute.Id);
            _aiWeaponAttribute = attribute.Clone();
        }
        
        //弹药量
        SetCurrAmmo(Attribute.AmmoCapacity);
        //当前缓冲区法力值
        SetCurrBufferMana(Attribute.MaxBufferMana);
        //当前法力值
        SetCurrMana(Attribute.MaxMana);

        if (attribute.PartPack.TryGetValue("Fire", out var partList))
        {
            FirePartList = new PartList(partList.Length, this);
            SetPartListItem(FirePartList, partList);
        }
        else
        {
            FirePartList = new PartList(0, this);
        }
        PartListMap.Add("Fire", FirePartList);
    }

    private void SetPartListItem(PartList list, string[] ids)
    {
        for (var i = 0; i < ids.Length; i++)
        {
            var id = ids[i];
            if (string.IsNullOrEmpty(id))
            {
                continue;
            }

            list.SetLogicBlock(i, PartProp.CreatePropActivity(id));
        }
    }

    /// <summary>
    /// 单次开火时调用的函数
    /// </summary>
    protected virtual void OnFire()
    {
    }

    /// <summary>
    /// 上膛开始时调用
    /// </summary>
    protected virtual void OnBeginBeLoaded()
    {
    }
    
    /// <summary>
    /// 上膛结束时调用
    /// </summary>
    protected virtual void OnBeLoadedFinish()
    {
    }
    
    /// <summary>
    /// 当按下扳机时调用
    /// </summary>
    protected virtual void OnDownTrigger()
    {
    }

    /// <summary>
    /// 当松开扳机时调用
    /// </summary>
    protected virtual void OnUpTrigger()
    {
    }

    /// <summary>
    /// 开始蓄力时调用, 
    /// 注意, 该函数仅在 Attribute.LooseShoot == false 时才能被调用
    /// </summary>
    protected virtual void OnBeginCharge()
    {
    }

    /// <summary>
    /// 结束蓄力时调用
    /// 注意, 该函数仅在 Attribute.LooseShoot == false 时才能被调用
    /// </summary>
    protected virtual void OnEndCharge()
    {
    }
    
    /// <summary>
    /// 蓄力完成时调用
    /// </summary>
    protected virtual void OnChargeFinish()
    {
    }
    
    /// <summary>
    /// 蓄力时每帧调用
    /// 注意, 该函数仅在 Attribute.LooseShoot == false 时才能被调用
    /// </summary>
    /// <param name="delta"></param>
    /// <param name="charge">蓄力时长</param>
    protected virtual void OnChargeProcess(float delta, float charge)
    {
    }

    /// <summary>
    /// 当换弹时调用, 如果设置单独装弹, 则每装一次弹调用一次该函数
    /// </summary>
    protected virtual void OnReload()
    {
    }

    /// <summary>
    /// 当开始换弹时调用
    /// </summary>
    protected virtual void OnBeginReload()
    {
    }
    
    /// <summary>
    /// 当换弹完成时调用
    /// </summary>
    protected virtual void OnReloadFinish()
    {
    }

    /// <summary>
    /// 单独装弹完成时调用
    /// </summary>
    protected virtual void OnAloneReloadStateFinish()
    {
    }
    
    /// <summary>
    /// 当武器被拾起时调用
    /// </summary>
    /// <param name="master">拾起该武器的角色</param>
    protected virtual void OnPickUp(Role master)
    {
    }

    /// <summary>
    /// 当武器从武器背包中移除时调用
    /// </summary>
    /// <param name="master">移除该武器的角色</param>
    protected virtual void OnRemove(Role master)
    {
    }

    /// <summary>
    /// 当武器被激活时调用, 也就是使用当武器时调用
    /// </summary>
    protected virtual void OnActive()
    {
    }

    /// <summary>
    /// 当武器被收起时调用
    /// </summary>
    protected virtual void OnConceal()
    {
    }

    /// <summary>
    /// 射击时调用, 返回消耗弹药数量, 默认为1, 如果返回为 0, 则不消耗弹药
    /// </summary>
    protected virtual int UseAmmoCount()
    {
        return 1;
    }

    public override void _EnterTree()
    {
        //收集落在地上的武器
        if (IsInGround())
        {
            World.Weapon_UnclaimedList.Add(this);
        }
    }

    public override void _ExitTree()
    {
        World.Weapon_UnclaimedList.Remove(this);
    }

    protected override void Process(float delta)
    {
        //抖动 AnimatedSprite
        if (_shakeStrength != 0)
        {
            _shakeTimer += delta;
            if (_shakeTimer >= _shakeInterval)
            {
                _shakeTimer = 0;
                AnimatedSprite.Offset = new Vector2(
                    Utils.Random.RandomRangeFloat(-_shakeStrength, _shakeStrength),
                    Utils.Random.RandomRangeFloat(-_shakeStrength, _shakeStrength)
                );
            }
        }
        else
        {
            _shakeTimer = 0;
        }
        
        //未开火时间
        _noAttackTime += delta;
        
        //缓冲区充能
        if (CurrMana > 0 && Attribute.ManaRecoverySpeed > 0 && CurrBufferMana < Attribute.MaxBufferMana)
        {
            _manaRecoveryValue += Mathf.Min(Attribute.ManaRecoverySpeed * delta, Attribute.MaxBufferMana - CurrBufferMana);
            if (_manaRecoveryValue >= 1f)
            {
                var tempVal = _manaRecoveryValue % 1f;
                var value = (int)(_manaRecoveryValue - tempVal);
                if (CurrMana >= value)
                {
                    CurrMana -= value;
                    CurrBufferMana += value;
                    _manaRecoveryValue = tempVal;
                }
                else
                {
                    CurrBufferMana += CurrMana;
                    CurrMana = 0;
                    _manaRecoveryValue = 0;
                }
            }
        }
        
        //这把武器被扔在地上, 或者当前武器没有被使用
        //if (Master == null || Master.WeaponPack.ActiveItem != this)
        if ((Master != null && Master.WeaponPack.ActiveItem != this) || !_triggerRoleFlag) //在背上, 或者被扔出去了
        {
            //_triggerTimer
            _triggerTimer = _triggerTimer > 0 ? _triggerTimer - delta : 0;
            //攻击冷却计时
            _attackTimer = _attackTimer > 0 ? _attackTimer - delta : 0;
            //武器的当前散射半径
            ScatteringRangeBackHandler(delta);
            //武器当前射速
            FiringSpeedBackHandler(delta);
            //松开扳机
            if (_triggerFlag || _downTimer > 0)
            {
                UpTrigger();
                _downTimer = 0;
            }
            
            _triggerFlag = false;

            //重置数据
            if (_dirtyFlag)
            {
                _dirtyFlag = false;
                //_aloneReloadState = 0;
                StopReload();
                _attackFlag = false;
                _continuousCount = 0;
                _delayedTime = 0;
                _upTimer = 0;
                _looseShootFlag = false;
                _chargeTime = 0;
                _beLoadedStateTimer = -1;
            }
        }
        else //正在使用中
        {
            _dirtyFlag = true;
            
            //上膛
            if (_beLoadedState == 1)
            {
                _beLoadedStateTimer -= delta;
                //上膛完成
                if (_beLoadedStateTimer <= 0)
                {
                    _beLoadedStateTimer = -1;
                    _beLoadedState = 2;
                    OnBeLoadedFinish();
                }
            }
            
            //换弹
            if (Reloading)
            {
                //换弹用时
                _reloadUseTime += delta;
                _reloadTimer -= delta;

                if (Attribute.AloneReload) //单独装弹模式
                {
                    switch (_aloneReloadState)
                    {
                        case 0:
                            Debug.LogError("AloneReload状态错误!");
                            break;
                        case 1: //装第一颗子弹之前
                        {
                            if (_reloadTimer <= 0)
                            {
                                //开始装第一颗子弹
                                _aloneReloadState = 2;
                                ReloadHandler();
                            }
                            _aloneReloadStop = false;
                        }
                            break;
                        case 2: //单独装弹中
                        {
                            if (_reloadTimer <= 0)
                            {
                                ReloadSuccess();
                                if (_aloneReloadStop || CurrAmmo == Attribute.AmmoCapacity) //单独装弹完成
                                {
                                    AloneReloadStateFinish();
                                    if (Attribute.AloneReloadFinishIntervalTime <= 0)
                                    {
                                        //换弹完成
                                        StopReload();
                                        ReloadFinishHandler();
                                    }
                                    else
                                    {
                                        _reloadTimer = Attribute.AloneReloadFinishIntervalTime;
                                        _aloneReloadState = 3;
                                    }
                                }
                            }
                        }
                            break;
                        case 3: //单独装弹完成
                        {
                            //播放换弹完成音效
                            if (!_playReloadFinishSoundFlag && Attribute.ReloadFinishSound != null && _reloadTimer <= Attribute.ReloadFinishSoundAdvanceTime)
                            {
                                _playReloadFinishSoundFlag = true;
                                // Debug.Log("播放换弹完成音效.");
                                PlayReloadFinishSound();
                            }
                            
                            if (_reloadTimer <= 0)
                            {
                                //换弹完成
                                StopReload();
                                ReloadFinishHandler();
                            }
                            _aloneReloadStop = false;
                        }
                            break;
                    }
                }
                else //普通换弹模式
                {
                    //播放换弹完成音效
                    if (!_playReloadFinishSoundFlag && Attribute.ReloadFinishSound != null && _reloadTimer <= Attribute.ReloadFinishSoundAdvanceTime)
                    {
                        _playReloadFinishSoundFlag = true;
                        // Debug.Log("播放换弹完成音效.");
                        PlayReloadFinishSound();
                    }

                    if (_reloadTimer <= 0)
                    {
                        ReloadSuccess();
                    }
                }
            }

            //攻击的计时器
            if (_attackTimer > 0)
            {
                _attackTimer -= delta;
                if (_attackTimer < 0)
                {
                    _delayedTime += _attackTimer;
                    _attackTimer = 0;
                    //枪口默认角度
                    if (Master != null)
                    {
                        RotationDegrees = -Attribute.DefaultAngle;
                    }

                    //自动上膛
                    if (_beLoadedState == -1)
                    {
                        BeLoaded();
                    }
                    
                    //子弹换弹
                    if (CurrAmmo <= 0 && Attribute.AutoReload)
                    {
                        Reload();
                    }
                }
            }
            else if (_delayedTime > 0) //攻击延时
            {
                _delayedTime -= delta;
                if (_attackTimer < 0)
                {
                    _delayedTime = 0;
                }
            }
            
            //扳机判定
            if (_triggerFlag)
            {
                if (_looseShootFlag) //蓄力时长
                {
                    var pv = _chargeTime;
                    _chargeTime += delta;
                    OnChargeProcess(delta, _chargeTime);
                    //蓄力完成
                    if (pv < Attribute.MinChargeTime && _chargeTime >= Attribute.MinChargeTime)
                    {
                        OnChargeFinish();
                    }
                }

                _downTimer += delta;
                if (_upTimer > 0) //第一帧按下扳机
                {
                    DownTrigger();
                    _upTimer = 0;
                }
            }
            else
            {
                _upTimer += delta;
                if (_downTimer > 0) //第一帧松开扳机
                {
                    UpTrigger();
                    _downTimer = 0;
                }
            }

            //连发判断
            if (!_looseShootFlag && _continuousCount > 0 && _delayedTime <= 0 && _attackTimer <= 0)
            {
                //连发开火
                TriggerFire();
                //连发最后一发打完了
                if (Attribute.ManualBeLoaded && _continuousCount <= 0)
                {
                    //执行上膛逻辑
                    RunBeLoaded();
                }
            }

            //散射值消退
            if (_noAttackTime >= Attribute.ScatteringRangeBackDelayTime)
            {
                ScatteringRangeBackHandler(delta);
            }

            if (_triggerFlag) //射速增加
            {
                FiringSpeedAddHandler(delta);
            }
            else if (_noAttackTime >= Attribute.FiringSpeedBackTime) //射速消退
            {
                FiringSpeedBackHandler(delta);
            }

            _triggerTimer = _triggerTimer > 0 ? _triggerTimer - delta : 0;
            _triggerFlag = false;
            _attackFlag = false;
            
            //武器身回归
            //Position = Position.MoveToward(Vector2.Zero, Attribute.BacklashRegressionSpeed * delta).Rotated(Rotation);
            _currBacklashLength = Mathf.MoveToward(_currBacklashLength, 0, Attribute.BacklashRegressionSpeed * delta);
            if (Master != null)
            {
                Position = new Vector2(_currBacklashLength, 0).Rotated(Rotation);
                if (_attackTimer > 0)
                {
                    RotationDegrees = Mathf.Lerp(
                        _fireAngle, -Attribute.DefaultAngle,
                        Mathf.Clamp((_fireInterval - _attackTimer) * Attribute.UpliftAngleRestore / _fireInterval, 0, 1)
                    );
                }
            }
        }
    }

    /// <summary>
    /// 设置抖动强度
    /// </summary>
    public void SetShake(float strength)
    {
        _shakeStrength = strength;
    }
    
    /// <summary>
    /// 设置抖动间隔
    /// </summary>
    public void SetShakeInterval(float interval)
    {
        _shakeInterval = interval;
    }

    /// <summary>
    /// 返回武器是否在地上
    /// </summary>
    /// <returns></returns>
    public bool IsInGround()
    {
        return Master == null && GetParent() == World.Current.NormalLayer;
    }

    /// <summary>
    /// 清除触发角色开火标记数据
    /// </summary>
    public void ClearTriggerRole()
    {
        _triggerRoleFlag = false;
        if (Master == null)
        {
            if (Reloading)
            {
                _reloadNextAnimation = AnimatorNames.Floodlight;
            }
            else
            {
                AnimationPlayer.Play(AnimatorNames.Floodlight);
            }
        }
    }

    /// <summary>
    /// 扳机函数, 调用即视为按下扳机
    /// </summary>
    /// <param name="triggerRole">按下扳机的角色, 如果传 null, 则视为走火</param>
    public void Trigger(Role triggerRole)
    {
        if (triggerRole == null || !triggerRole.IsAi)
        {
            Trigger(triggerRole, true);
        }
        else
        {
            Trigger(triggerRole, Utils.Random.RandomBoolean(AiUseAttribute.AiAttackAttr.AmmoConsumptionProbability));
        }
    }
    
    /// <summary>
    /// 扳机函数, 调用即视为按下扳机
    /// </summary>
    /// <param name="triggerRole">按下扳机的角色, 如果传 null, 则视为走火</param>
    /// <param name="calcAmmo">是否计算弹药消耗</param>
    public void Trigger(Role triggerRole, bool calcAmmo)
    {
        //不能触发扳机
        if (!NoMasterCanTrigger && Master == null) return;

        //这一帧已经按过了, 不需要再按下
        if (_triggerFlag) return;

        //更新武器属性信息
        _triggerFlag = true;
        if (!_triggerRoleFlag && AnimationPlayer.CurrentAnimation == AnimatorNames.Floodlight)
        {
            AnimationPlayer.Play(AnimatorNames.Reset);
        }
        _triggerRoleFlag = true;
        _triggerCalcAmmon = calcAmmo;
        if (triggerRole != null)
        {
            TriggerRole = triggerRole;
            SetCurrentWeaponAttribute(triggerRole.IsAi ? _aiWeaponAttribute : _playerWeaponAttribute);
        }
        else if (Master != null)
        {
            TriggerRole = Master;
            SetCurrentWeaponAttribute(Master.IsAi ? _aiWeaponAttribute : _playerWeaponAttribute);
        }

        //是否第一帧按下
        var justDown = _downTimer == 0;
        if (_beLoadedState == 0 || _beLoadedState == -1) //需要执行上膛操作
        {
            if (justDown && !Reloading && triggerRole != null)
            {
                if (CurrAmmo <= 0)
                {
                    //子弹不够, 触发换弹
                    Reload();
                }
                else if (_attackTimer <= 0)
                {
                    //触发上膛操作
                    BeLoaded();
                }
            }
        }
        else if (_beLoadedState == 1) //上膛中
        {

        }
        else //上膛完成
        {
            //是否能发射
            var flag = false;
            if (_continuousCount <= 0) //不能处于连发状态下
            {
                if (Attribute.ContinuousShoot) //自动射击
                {
                    if (_triggerTimer > 0)
                    {
                        if (_continuousShootFlag)
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        flag = true;
                        if (_delayedTime <= 0 && _attackTimer <= 0)
                        {
                            _continuousShootFlag = true;
                        }
                    }
                }
                else //半自动
                {
                    if (justDown && _triggerTimer <= 0 && _attackTimer <= 0)
                    {
                        flag = true;
                    }
                }
            }

            if (flag)
            {
                var fireFlag = true; //是否能开火
                if (Reloading) //换弹中
                {
                    fireFlag = false;
                    if (CurrAmmo > 0 && Attribute.AloneReload && Attribute.AloneReloadCanShoot)
                    {
                        //检查是否允许停止换弹
                        if (_aloneReloadState == 2 || _aloneReloadState == 1)
                        {
                            //强制结束
                            _aloneReloadStop = true;
                        }
                    }
                }
                else if (CurrAmmo <= 0) //子弹不够
                {
                    fireFlag = false;
                    if (justDown && triggerRole != null)
                    {
                        //第一帧按下, 触发换弹
                        Reload();
                    }
                }

                if (fireFlag)
                {
                    if (justDown)
                    {
                        //开火前延时
                        if (!Attribute.LooseShoot)
                        {
                            _delayedTime = Attribute.DelayedTime;
                        }

                        //扳机按下间隔
                        _triggerTimer = Attribute.TriggerInterval;
                        //连发数量
                        if (!Attribute.ContinuousShoot)
                        {
                            _continuousCount = Utils.Random.RandomConfigRange(Attribute.ContinuousCountRange);
                        }
                    }

                    if (_delayedTime <= 0 && _attackTimer <= 0)
                    {
                        if (Attribute.LooseShoot) //松发开火
                        {
                            _looseShootFlag = true;
                            OnBeginCharge();
                        }
                        else
                        {
                            //开火
                            TriggerFire();

                            //非连射模式
                            if (!Attribute.ContinuousShoot && Attribute.ManualBeLoaded && _continuousCount <= 0)
                            {
                                //执行上膛逻辑
                                RunBeLoaded();
                            }
                        }
                    }
                }
            }
            else //不能开火
            {
                if (CurrAmmo <= 0 && justDown && triggerRole != null) //子弹不够
                {
                    //第一帧按下, 触发换弹
                    Reload();
                }
            }
        }
    }

    /// <summary>
    /// 返回是否按下扳机
    /// </summary>
    public bool IsPressTrigger()
    {
        return _triggerFlag;
    }
    
    /// <summary>
    /// 获取本次扳机按下的时长, 单位: 秒
    /// </summary>
    public float GetTriggerDownTime()
    {
        return _downTimer;
    }

    /// <summary>
    /// 获取扳机蓄力时长, 计算按下扳机后从可以开火到当前一共经过了多长时间, 可用于计算蓄力攻击
    /// 注意, 该函数仅在 Attribute.LooseShoot == false 时有正确的返回值, 否则返回 0
    /// </summary>
    public float GetTriggerChargeTime()
    {
        return _chargeTime;
    }
    
    /// <summary>
    /// 获取蓄力是否结束
    /// 注意, 该函数仅在 Attribute.LooseShoot == false 时有正确的返回值, 否则返回 false
    /// </summary>
    public bool IsChargeFinish()
    {
        return _chargeTime >= Attribute.MinChargeTime;
    }
    
    /// <summary>
    /// 获取延时射击倒计时, 单位: 秒
    /// </summary>
    public float GetDelayedAttackTime()
    {
        return _delayedTime;
    }

    /// <summary>
    /// 获取当前需要连发弹药的数量, 配置了 ContinuousCountRange 时生效
    /// </summary>
    public int GetContinuousCount()
    {
        return _continuousCount;
    }

    /// <summary>
    /// 获取攻击冷却计时时间, 小于等于 0 表示冷却完成
    /// </summary>
    public float GetAttackTimer()
    {
        return _attackTimer;
    }

    /// <summary>
    /// 返回是否是攻击间隙时间
    /// </summary>
    public bool IsAttackIntervalTime()
    {
        return _attackTimer > 0 || _triggerTimer > 0;
    }

    /// <summary>
    /// 是否可以按下扳机并发射了
    /// </summary>
    public bool TriggerIsReady()
    {
        return GetBeLoadedStateState() >= 2 && !IsAttackIntervalTime();
    }

    /// <summary>
    /// 获取上膛状态,-1: 等待执行自动上膛 , 0: 未上膛, 1: 上膛中, 2: 已经完成上膛
    /// </summary>
    public sbyte GetBeLoadedStateState()
    {
        return _beLoadedState;
    }
    
    /// <summary>
    /// 刚按下扳机
    /// </summary>
    private void DownTrigger()
    {
        OnDownTrigger();
    }

    /// <summary>
    /// 刚松开扳机
    /// </summary>
    private void UpTrigger()
    {
        _continuousShootFlag = false;
        if (_delayedTime > 0)
        {
            _continuousCount = 0;
        }

        //松发开火执行
        if (_looseShootFlag)
        {
            _looseShootFlag = false;
            if (_chargeTime >= Attribute.MinChargeTime) //判断蓄力是否够了
            {
                TriggerFire();
                //非连射模式
                if (!Attribute.ContinuousShoot && Attribute.ManualBeLoaded && _continuousCount <= 0)
                {
                    //执行上膛逻辑
                    RunBeLoaded();
                }
            }
            else //不能攻击
            {
                _continuousCount = 0;
            }
            _chargeTime = 0;
            OnEndCharge();
        }

        OnUpTrigger();
    }

    /// <summary>
    /// 触发开火
    /// </summary>
    private void TriggerFire()
    {
        if (CurrAmmo == 0)
        {
            _continuousCount = 0;
        }
        else
        {
            _continuousCount = _continuousCount > 0 ? _continuousCount - 1 : 0;
        }
        

        //武器口角度
        var angle = new Vector2(GameConfig.ScatteringDistance, CurrScatteringRange).Angle();

        //先算武器口方向
        var tempRotation = Utils.Random.RandomRangeFloat(-angle, angle);
        var tempAngle = Mathf.RadToDeg(tempRotation);

        //开火时枪口角度
        var fireRotation = tempRotation;
        
        if (Master != null)
        {
            fireRotation += Master.MountPoint.RealRotation;
        }
        else
        {
            fireRotation += GlobalRotation;
        }

        //执行零件
        var result = FirePartList.Execute(fireRotation);
        if (!result.HasBullet) //没有发射子弹零件
        {
            Debug.Log("没有成功发射子弹零件!!!");
            return;
        }
        if (result.SufficientMana) //没有足够的法力值
        {
            if (result.HasValue(PlanningParam.NoManaIndex))
            {
                Debug.Log("没有足够的法力值!!! ------ index:" + result.GetValue<int>(PlanningParam.NoManaIndex));
            }
        }
        
        _attackFlag = true;
        _noAttackTime = 0;
        _reloadShellFlag = false;

        CurrAmmo -= UseAmmoCount();
        
        //开火间隙, 这里的60指的是60秒
        _fireInterval = 60 / CurrFiringSpeed;
        //攻击冷却
        _attackTimer += _fireInterval;

        //播放开火动画
        if (IsAutoPlaySpriteFrames)
        {
            if (!PlayAnimationPlayer(AnimatorNames.Fire))
            {
                PlaySpriteAnimation(AnimatorNames.Fire);
            }
        }

        if (result.HasValue(PlanningParam.FirstBullet))
        {
            //播放射击音效
            PlayShootSound(result.GetValue<ExcelConfig.BulletBase>(PlanningParam.FirstBullet).ShootSound);
        }
       
        //抛弹
        if (!Attribute.ReloadThrowShell && (Attribute.ContinuousShoot || !Attribute.ManualBeLoaded))
        {
            ThrowShellHandler(1f);
        }

        //触发开火函数
        OnFire();
        
        //开火添加散射值
        ScatteringRangeAddHandler();
        
        //武器的旋转角度
        tempAngle -= Attribute.UpliftAngle;
        _fireAngle = tempAngle;
        
        if (Master != null) //被拾起
        {
            //武器身位置
            var max = Mathf.Abs(Mathf.Max(Utils.GetConfigRangeStart(Attribute.BacklashRange), Utils.GetConfigRangeEnd(Attribute.BacklashRange)));
            _currBacklashLength = Mathf.Clamp(
                _currBacklashLength - Utils.Random.RandomConfigRange(Attribute.BacklashRange),
                -max, max
            );
            Position = new Vector2(_currBacklashLength, 0).Rotated(Rotation);
            RotationDegrees = tempAngle;
        }
        else //在地上
        {
            var v = Utils.Random.RandomConfigRange(Attribute.BacklashRange) * 15;
            var externalForce = MoveController.AddForce(new Vector2(-v, 0).Rotated(Rotation));
            externalForce.RotationSpeed = -Mathf.DegToRad(50);
            externalForce.RotationResistance = Mathf.DegToRad(80);
        }

        if (IsInGround())
        {
            //在地上弹药打光
            if (IsTotalAmmoEmpty())
            {
                //停止动画
                AnimationPlayer.Stop();
                //清除泛白效果
                SetBlendSchedule(0);
            }
        }
    }

    // /// <summary>
    // /// 触发武器的近战攻击
    // /// </summary>
    // public virtual void TriggerMeleeAttack(Role trigger)
    // {
    //     
    // }

    /// <summary>
    /// 根据触扳机的角色对象判断该角色使用的武器数据
    /// </summary>
    public ExcelConfig.WeaponBase GetUseAttribute(Role triggerRole)
    {
        if (triggerRole == null || !triggerRole.IsAi)
        {
            return PlayerUseAttribute;
        }

        return AiUseAttribute;
    }

    /// <summary>
    /// 返回弹夹是否打空
    /// </summary>
    public bool IsAmmoEmpty()
    {
        return CurrAmmo == 0;
    }
    
    /// <summary>
    /// 返回是否弹药耗尽
    /// </summary>
    public bool IsTotalAmmoEmpty()
    {
        // 判断法力值和弹丸法术是否消耗殆尽
        return CurrBufferMana + CurrMana <= 0;
    }

    /// <summary>
    /// 强制修改当前弹夹弹药量
    /// </summary>
    public void SetCurrAmmo(int count)
    {
        CurrAmmo = Mathf.Clamp(count, 0, Attribute.AmmoCapacity);
    }
    
    /// <summary>
    /// 强制设置当前武器法力值
    /// </summary>
    public void SetCurrMana(int count)
    {
        CurrMana = Mathf.Clamp(count, 0, Attribute.MaxMana);
    }

    /// <summary>
    /// 强制设置当前武器缓冲区法力值
    /// </summary>
    public void SetCurrBufferMana(int count)
    {
        CurrBufferMana = Mathf.Clamp(count, 0, Attribute.MaxBufferMana);
    }

    /// <summary>
    /// 使用法力值，返回是否成功
    /// </summary>
    public bool UseBufferMana(int mana)
    {
        if (!_triggerCalcAmmon)
        {
            return true;
        }
        if (CurrBufferMana < mana)
        {
            return false;
        }
        CurrBufferMana -= mana;

        return true;
    }
    
    /// <summary>
    /// 触发换弹
    /// </summary>
    public void Reload()
    {
        if (!Reloading && CurrAmmo < Attribute.AmmoCapacity && _beLoadedState != 1)
        {
            Reloading = true;
            _playReloadFinishSoundFlag = false;

            //播放开始换弹音效
            PlayBeginReloadSound();
            
            // Debug.Log("开始换弹.");
            //抛弹
            if (!Attribute.ReloadThrowShell && !Attribute.ContinuousShoot &&
                (_beLoadedState == 0 || _beLoadedState == -1) && Attribute.BeLoadedTime > 0)
            {
                ThrowShellHandler(0.6f);
            }
            
            //第一次换弹
            OnBeginReload();

            if (Attribute.AloneReload)
            {
                //单独换弹, 特殊处理
                AloneReloadHandler();
            }
            else
            {
                //普通换弹处理
                ReloadHandler();
            }
            
            //上膛标记完成
            _beLoadedState = 2;
        }
    }

    /// <summary>
    /// 强制停止换弹, 或者结束换弹状态
    /// </summary>
    public void StopReload()
    {
        _aloneReloadState = 0;
        if (_beLoadedState == -1)
        {
            _beLoadedState = 0;
        }
        else if (_beLoadedState == 1)
        {
            _beLoadedState = 2;
        }

        Reloading = false;
        _reloadTimer = 0;
        _reloadUseTime = 0;
    }

    /// <summary>
    /// 触发上膛
    /// </summary>
    public void BeLoaded()
    {
        if (_beLoadedState > 0)
        {
            return;
        }
        //上膛抛弹
        if (!Attribute.ReloadThrowShell && !Attribute.ContinuousShoot && Attribute.BeLoadedTime > 0)
        {
            ThrowShellHandler(0.6f);
        }

        //开始上膛
        OnBeginBeLoaded();

        //上膛时间为0, 直接结束上膛
        if (Attribute.BeLoadedTime <= 0)
        {
            //直接上膛完成
            _beLoadedState = 2;
            OnBeLoadedFinish();
            return;
        }
        
        //上膛中
        _beLoadedState = 1;
        _beLoadedStateTimer = Attribute.BeLoadedTime;
        
        //播放上膛动画
        if (IsAutoPlaySpriteFrames)
        {
            if (Attribute.BeLoadedSoundDelayTime <= 0)
            {
                if (!PlayAnimationPlayer(AnimatorNames.BeLoaded))
                {
                    PlaySpriteAnimation(AnimatorNames.BeLoaded);
                }
            }
            else
            {
                this.CallDelay(Attribute.BeLoadedSoundDelayTime, () =>
                {
                    if (!PlayAnimationPlayer(AnimatorNames.BeLoaded))
                    {
                        PlaySpriteAnimation(AnimatorNames.BeLoaded);
                    }
                });
            }
        }

        //播放上膛音效
        PlayBeLoadedSound();
    }
    
    //播放换弹开始音效
    private void PlayBeginReloadSound()
    {
        if (Attribute.BeginReloadSound != null)
        {
            if (Attribute.BeginReloadSoundDelayTime <= 0)
            {
                SoundManager.PlaySoundByConfig(Attribute.BeginReloadSound, GlobalPosition, TriggerRole);
            }
            else
            {
                SoundManager.PlaySoundByConfigDelay(Attribute.BeginReloadSound, GlobalPosition, Attribute.BeginReloadSoundDelayTime, TriggerRole);
            }
        }
    }
    
    //播放换弹音效
    private void PlayReloadSound()
    {
        if (Attribute.ReloadSound != null)
        {
            if (Attribute.ReloadSoundDelayTime <= 0)
            {
                SoundManager.PlaySoundByConfig(Attribute.ReloadSound, GlobalPosition, TriggerRole);
            }
            else
            {
                SoundManager.PlaySoundByConfigDelay(Attribute.ReloadSound, GlobalPosition, Attribute.ReloadSoundDelayTime, TriggerRole);
            }
        }
    }
    
    //播放换弹完成音效
    private void PlayReloadFinishSound()
    {
        if (Attribute.ReloadFinishSound != null)
        {
            SoundManager.PlaySoundByConfig(Attribute.ReloadFinishSound, GlobalPosition, TriggerRole);
        }
    }

    //播放射击音效
    private void PlayShootSound(ExcelConfig.Sound sound)
    {
        if (sound != null)
        {
            SoundManager.PlaySoundByConfig(sound, GlobalPosition, TriggerRole);
        }
    }

    //播放上膛音效
    private void PlayBeLoadedSound()
    {
        if (Attribute.BeLoadedSound != null)
        {
            if (Attribute.BeLoadedSoundDelayTime <= 0)
            {
                SoundManager.PlaySoundByConfig(Attribute.BeLoadedSound, GlobalPosition, TriggerRole);
            }
            else
            {
                SoundManager.PlaySoundByConfigDelay(Attribute.BeLoadedSound, GlobalPosition, Attribute.BeLoadedSoundDelayTime, TriggerRole);
            }
        }
    }

    //执行上膛逻辑
    private void RunBeLoaded()
    {
        if (Attribute.AutoManualBeLoaded)
        {
            if (_attackTimer <= 0)
            {
                //执行自动上膛
                BeLoaded();
            }
            else if (CurrAmmo > 0)
            {
                //等待执行自动上膛
                _beLoadedState = -1;
            }
            else
            {
                //没子弹了, 需要手动上膛
                _beLoadedState = 0;
            }
        }
        else
        {
            //手动上膛
            _beLoadedState = 0;
        }
    }

    //单独换弹处理
    private void AloneReloadHandler()
    {
        if (Attribute.AloneReloadBeginIntervalTime <= 0)
        {
            //开始装第一颗子弹
            _aloneReloadState = 2;
            ReloadHandler();
        }
        else
        {
            _aloneReloadState = 1;
            _reloadTimer = Attribute.AloneReloadBeginIntervalTime;
        }
    }

    //换弹处理逻辑
    private void ReloadHandler()
    {
        _reloadTimer = Attribute.ReloadTime;
        
        //播放换弹动画
        if (IsAutoPlaySpriteFrames)
        {
            if (!PlayAnimationPlayer(AnimatorNames.Reloading))
            {
                PlaySpriteAnimation(AnimatorNames.Reloading);
            }
        }
            
        //播放换弹音效
        PlayReloadSound();
        
        //抛出弹壳
        if (Attribute.ReloadThrowShell && !_reloadShellFlag)
        {
            ThrowShellHandler(0.6f);
        }
        
        OnReload();
        // Debug.Log("装弹.");
    }
    
    //换弹完成处理逻辑
    private void ReloadFinishHandler()
    {
        // Debug.Log("装弹完成.");
        if (_reloadNextAnimation != null)
        {
            AnimationPlayer.Play(_reloadNextAnimation);
            _reloadNextAnimation = null;
        }
        OnReloadFinish();
    }

    //单独装弹完成
    private void AloneReloadStateFinish()
    {
        // Debug.Log("单独装弹完成.");
        OnAloneReloadStateFinish();
    }

    //抛弹逻辑
    private void ThrowShellHandler(float speedScale)
    {
        var attribute = Attribute;
        if (attribute.Shell == null)
        {
            return;
        }
        //创建一个弹壳
        if (attribute.ThrowShellDelayTime > 0)
        {
            this.CallDelay(attribute.ThrowShellDelayTime, () =>
            {
                _reloadShellFlag = true;
                for (var i = 0; i < attribute.ThrowShellCount; i++)
                {
                    FireManager.ThrowShell(this, attribute.Shell, speedScale);
                }
            });
        }
        else if (attribute.ThrowShellDelayTime == 0)
        {
            _reloadShellFlag = true;
            for (var i = 0; i < attribute.ThrowShellCount; i++)
            {
                FireManager.ThrowShell(this, attribute.Shell, speedScale);
            }
        }
    }

    //散射值消退处理
    private void ScatteringRangeBackHandler(float delta)
    {
        var startScatteringRange = Attribute.StartScatteringRange;
        var finalScatteringRange = Attribute.FinalScatteringRange;
        if (Master != null)
        {
            startScatteringRange = Master.RoleState.CalcStartScattering(startScatteringRange);
            finalScatteringRange = Master.RoleState.CalcFinalScattering(finalScatteringRange);
        }
        if (startScatteringRange <= finalScatteringRange)
        {
            CurrScatteringRange = Mathf.Max(CurrScatteringRange - Attribute.ScatteringRangeBackSpeed * delta,
                startScatteringRange);
        }
        else
        {
            CurrScatteringRange = Mathf.Min(CurrScatteringRange + Attribute.ScatteringRangeBackSpeed * delta,
                startScatteringRange);
        }
    }

    //散射值添加处理
    private void ScatteringRangeAddHandler()
    {
        var startScatteringRange = Attribute.StartScatteringRange;
        var finalScatteringRange = Attribute.FinalScatteringRange;
        if (Master != null)
        {
            startScatteringRange = Master.RoleState.CalcStartScattering(startScatteringRange);
            finalScatteringRange = Master.RoleState.CalcFinalScattering(finalScatteringRange);
        }
        if (startScatteringRange <= finalScatteringRange)
        {
            CurrScatteringRange = Mathf.Min(CurrScatteringRange + Attribute.ScatteringRangeAddValue,
                finalScatteringRange);
        }
        else
        {
            CurrScatteringRange = Mathf.Min(CurrScatteringRange - Attribute.ScatteringRangeAddValue,
                finalScatteringRange);
        }
    }

    //射速增加处理
    private void FiringSpeedAddHandler(float delta)
    {
        if (Attribute.ContinuousShoot)
        {
            CurrFiringSpeed = Mathf.MoveToward(CurrFiringSpeed, Attribute.FinalFiringSpeed,
                Attribute.FiringSpeedAddSpeed * delta);
        }
        else
        {
            CurrFiringSpeed = Attribute.StartFiringSpeed;
        }
    }
    
    //射速衰减处理
    private void FiringSpeedBackHandler(float delta)
    {
        if (Attribute.ContinuousShoot)
        {
            CurrFiringSpeed = Mathf.MoveToward(CurrFiringSpeed, Attribute.StartFiringSpeed, 
                Attribute.FiringSpeedBackSpeed * delta);
        }
        else
        {
            CurrFiringSpeed = Attribute.StartFiringSpeed;
        }
    }

    /// <summary>
    /// 换弹计时器时间到, 执行换弹操作
    /// </summary>
    private void ReloadSuccess()
    {
        if (Attribute.AloneReload) //单独装填
        {

            if (CurrAmmo + Attribute.AloneReloadCount <= Attribute.AmmoCapacity)
            {
                CurrAmmo += Attribute.AloneReloadCount;
            }
            else //子弹满了
            {
                CurrAmmo = Attribute.AmmoCapacity;
            }


            if (!_aloneReloadStop && CurrAmmo != Attribute.AmmoCapacity) //继续装弹
            {
                ReloadHandler();
            }
        }
        else //换弹结束
        {
            CurrAmmo = Attribute.AmmoCapacity;

            StopReload();
            ReloadFinishHandler();
        }
    }

    /// <summary>
    /// 播放 AnimationPlayer 动画, 如果这个动画不存在, 则什么也不会发生
    /// </summary>
    public bool PlayAnimationPlayer(string name)
    {
        if (AnimationPlayer != null && AnimationPlayer.HasAnimation(name))
        {
            AnimationPlayer.Play(name);
            return true;
        }

        return false;
    }

    //帧动画播放结束
    private void OnAnimatedSpriteFinished()
    {
        // Debug.Log("帧动画播放结束...");
        AnimatedSprite.Play(AnimatorNames.Default);
    }

    //动画播放器播放结束
    private void OnAnimationPlayerFinished(StringName name)
    {
        if (Master != null && !IsActive)
        {
            Master.OnPutBackMount(this, PackageIndex);
        }
    }

    public override CheckInteractiveResult CheckInteractive(ActivityObject master)
    {
        var result = new CheckInteractiveResult(this);

        if (master is Role roleMaster) //碰到角色
        {
            if (Master == null)
            {
                if (roleMaster.WeaponPack.Capacity == 0)
                {
                    //容量为0
                    return result;
                }

                var masterWeapon = roleMaster.WeaponPack.ActiveItem;
                if (roleMaster.WeaponPack.HasVacancy()) //有空位, 能拾起武器
                {
                    //可以互动, 拾起武器
                    result.CanInteractive = true;
                    result.Type = CheckInteractiveResult.InteractiveType.PickUp;
                    return result;
                }
                else if (masterWeapon != null) //替换武器  // && masterWeapon.Attribute.WeightType == Attribute.WeightType)
                {
                    //可以互动, 切换武器
                    result.CanInteractive = true;
                    result.Type = CheckInteractiveResult.InteractiveType.Replace;
                    return result;
                }
            }
        }

        return result;
    }

    public override void Interactive(ActivityObject master)
    {
        if (master is Role roleMaster) //与role互动
        {
            if (roleMaster.WeaponPack.Capacity == 0)
            {
                //容量为0
                return;
            }
            var holster = roleMaster.WeaponPack;
            if (!holster.HasVacancy()) //没有空位置, 扔掉当前武器
            {
                //替换武器
                roleMaster.ThrowWeapon();
            }
            roleMaster.PickUpWeapon(this);
        }
    }

    /// <summary>
    /// 获取当前武器真实的旋转角度(弧度制), 由于武器旋转时加入了旋转吸附, 所以需要通过该函数来来知道当前武器的真实旋转角度
    /// </summary>
    public float GetRealGlobalRotation()
    {
        return Mathf.DegToRad(Master.MountPoint.RealRotationDegrees) + Rotation;
    }

    /// <summary>
    /// 触发扔掉武器时抛出的效果, 并不会管武器是否在武器背包中
    /// </summary>
    /// <param name="master">触发扔掉该武器的的角色</param>
    public void ThrowWeapon(Role master)
    {
        ThrowWeapon(master, master.GlobalPosition);
    }

    /// <summary>
    /// 触发扔掉武器时抛出的效果, 并不会管武器是否在武器背包中
    /// </summary>
    /// <param name="master">触发扔掉该武器的的角色</param>
    /// <param name="startPosition">投抛起始位置</param>
    public void ThrowWeapon(Role master, Vector2 startPosition)
    {
        //阴影偏移
        ShadowOffset = new Vector2(0, 2);

        if (master.Face == FaceDirection.Left)
        {
            Scale *= new Vector2(1, -1);
        }

        var rotation = master.MountPoint.GlobalRotation;
        GlobalRotation = rotation;

        if (master.Face == FaceDirection.Right)
        {
            startPosition += _gripPoint.Rotated(rotation);
        }
        else
        {
            startPosition += new Vector2(_gripPoint.X, -_gripPoint.Y).Rotated(rotation);
        }

        var startHeight = -master.MountPoint.Position.Y;
        var velocity = new Vector2(20, 0).Rotated(rotation);
        var yf = Utils.Random.RandomRangeInt(50, 70);
        Throw(startPosition, startHeight, yf, velocity, 0);
        
        //继承role的移动速度
        InheritVelocity(master);
    }

    protected override void OnThrowStart()
    {
        //禁用碰撞
        //Collision.Disabled = true;
        //AnimationPlayer.Play(AnimatorNames.Floodlight);
    }

    protected override void OnThrowOver()
    {
        //启用碰撞
        //Collision.Disabled = false;
        //还有弹药, 播放泛白效果
        if (!IsTotalAmmoEmpty())
        {
            AnimationPlayer.Play(AnimatorNames.Floodlight);
        }
    }

    /// <summary>
    /// 触发启用武器, 这个函数由 Holster 对象调用
    /// </summary>
    private void Active()
    {
        //调整阴影
        //ShadowOffset = new Vector2(0, Master.GlobalPosition.Y - GlobalPosition.Y);
        //ShadowOffset = new Vector2(0, -Master.MountPoint.Position.Y + 2);
        ShadowOffset = new Vector2(0, -Master.MountPoint.Position.Y);
        //枪口默认抬起角度
        RotationDegrees = -Attribute.DefaultAngle;
        ShowShadowSprite();
        OnActive();
    }

    /// <summary>
    /// 触发收起武器, 这个函数由 Holster 对象调用
    /// </summary>
    private void Conceal()
    {
        //停止换弹动画
        if (AnimationPlayer.CurrentAnimation == AnimatorNames.Reloading && AnimationPlayer.IsPlaying())
        {
            AnimationPlayer.Play(AnimatorNames.Reset);
        }
        
        HideShadowSprite();
        OnConceal();
    }
    
    public void OnRemoveItem()
    {
        //要重置部分重要属性属性
        if (Master.IsAi)
        {
            _triggerTimer = 0;
        }
        GetParent().RemoveChild(this);
        _triggerRoleFlag = false;
        SetCurrentWeaponAttribute(_playerWeaponAttribute);
        CollisionLayer = _tempLayer;

        //精灵位置, 旋转中心点
        AnimatedSprite.Position = Vector2.Zero;
        AnimatedSprite.Offset = Vector2.Zero;
        Collision.Position = _collPoint2;
        //清除 Ai 拾起标记
        RemoveSign(SignNames.AiFindWeaponSign);
        //停止换弹
        if (Reloading)
        {
            StopReload();
        }
        //停止换弹动画
        if (AnimationPlayer.CurrentAnimation == AnimatorNames.Reloading && AnimationPlayer.IsPlaying())
        {
            AnimationPlayer.Play(AnimatorNames.Reset);
        }
        OnRemove(Master);
    }

    public void OnPickUpItem()
    {
        Pickup();
        _triggerRoleFlag = true;
        SetCurrentWeaponAttribute(Master.IsAi ? _aiWeaponAttribute : _playerWeaponAttribute);
        //停止动画
        AnimationPlayer.Stop();
        //清除泛白效果
        SetBlendSchedule(0);
        ZIndex = 0;
        //禁用碰撞
        //Collision.Disabled = true;
        AnimatedSprite.Position = _gripPoint;
        AnimatedSprite.Offset = _gripOffset;
        Collision.Position = _collPoint1;
        //修改层级
        _tempLayer = CollisionLayer;
        CollisionLayer = PhysicsLayer.OnHand;
        //清除 Ai 拾起标记
        RemoveSign(SignNames.AiFindWeaponSign);
        OnPickUp(Master);
    }

    public void OnActiveItem()
    {
        //更改父节点
        var parent = GetParentOrNull<Node>();
        if (parent == null)
        {
            Master.MountPoint.AddChild(this);
        }
        else if (parent != Master.MountPoint)
        {
            parent.RemoveChild(this);
            Master.MountPoint.AddChild(this);
        }

        Position = Vector2.Zero;
        Scale = Vector2.One;
        RotationDegrees = 0;
        Visible = true;
        Active();
    }

    public void OnConcealItem()
    {
        var tempParent = GetParentOrNull<Node2D>();
        if (tempParent != null)
        {
            tempParent.RemoveChild(this);
            Master.BackMountPoint.AddChild(this);
            Master.OnPutBackMount(this, PackageIndex);
            Conceal();
        }
    }

    public void OnOverflowItem()
    {
        Master.ThrowWeapon(PackageIndex);
    }

    /// <summary>
    /// 获取相对于武器本地坐标的开火位置
    /// </summary>
    public Vector2 GetLocalFirePosition()
    {
        return AnimatedSprite.Position + FirePoint.Position;
    }
    
    /// <summary>
    /// 获取相对于武器本地坐标的抛壳位置
    /// </summary>
    public Vector2 GetLocalShellPosition()
    {
        return AnimatedSprite.Position + ShellPoint.Position;
    }

    /// <summary>
    /// 获取握把位置, 相当于武器的原点坐标
    /// </summary>
    public Vector2 GetGripPosition()
    {
        return _gripPoint + _gripOffset;
    }

    //设置当前使用的武器属性
    private void SetCurrentWeaponAttribute(ExcelConfig.WeaponBase attr)
    {
        if (attr != _weaponAttribute)
        {
            _weaponAttribute = attr;
            //重置开火速率
            CurrFiringSpeed = _weaponAttribute.StartFiringSpeed;
        }
    }

    //-------------------------------- Ai相关 -----------------------------
    
    /// <summary>
    /// Ai调用, 触发扣动扳机, 并返回攻击状态
    /// </summary>
    public AiAttackEnum AiTriggerAttackState(AiAttackEnum prevState)
    {
        var chargeFinish = false;
        if (prevState == AiAttackEnum.AttackCharge) //蓄力中
        {
            var enemy = (Enemy)Master;
            if (!IsChargeFinish())
            {
                enemy.Attack();
                return prevState;
            }

            chargeFinish = true;
            enemy.LockingTime = 0;
        }
        
        AiAttackEnum flag;
        if (IsTotalAmmoEmpty()) //当前武器弹药打空
        {
            //切换到有子弹的武器
            var index = Master.WeaponPack.FindIndex((we, i) => !we.IsTotalAmmoEmpty());
            if (index != -1)
            {
                flag = AiAttackEnum.ExchangeWeapon;
                Master.WeaponPack.ExchangeByIndex(index);
            }
            else //所有子弹打光
            {
                flag = AiAttackEnum.NoAmmo;
            }
        }
        else if (Reloading) //换弹中
        {
            flag = AiAttackEnum.TriggerReload;
        }
        else if (IsAmmoEmpty()) //弹夹已经打空
        {
            flag = AiAttackEnum.Reloading;
            Reload();
        }
        else if (_beLoadedState == 0 || _beLoadedState == -1) //需要上膛
        {
            flag = AiAttackEnum.AttackInterval;
            if (_attackTimer <= 0)
            {
                BeLoaded();
            }
        }
        else if (_beLoadedState == 1) //上膛中
        {
            flag = AiAttackEnum.AttackInterval;
        }
        else if (_continuousCount >= 1 && (!chargeFinish || _continuousCount >= 2)) //连发中
        {
            flag = AiAttackEnum.Attack;
        }
        else if (IsAttackIntervalTime()) //开火间隙
        {
            flag = AiAttackEnum.AttackInterval;
        }
        else
        {
            var enemy = (Enemy)Master;
            if (enemy.LockTargetTime >= Attribute.AiAttackAttr.LockingTime) //正常射击
            {
                if (GetDelayedAttackTime() > 0)
                {
                    flag = AiAttackEnum.Attack;
                    enemy.Attack();
                    if (_attackFlag) //成功触发攻击
                    {
                        enemy.LockingTime = 0;
                    }
                }
                else
                {
                    if (Attribute.ContinuousShoot) //连发
                    {
                        flag = AiAttackEnum.Attack;
                        enemy.Attack();
                        if (_attackFlag) //成功触发攻击
                        {
                            enemy.LockingTime = 0;
                        }
                    }
                    else //单发
                    {
                        if (Attribute.LooseShoot && Attribute.MinChargeTime > 0) //松发并蓄力攻击
                        {
                            flag = AiAttackEnum.AttackCharge;
                            enemy.Attack();
                        }
                        else
                        {
                            flag = AiAttackEnum.Attack;
                            enemy.Attack();
                            if (_attackFlag && _attackTimer > 0) //成功触发攻击
                            {
                                enemy.LockingTime = 0;
                            }
                        }
                    }
                }
            }
            else //锁定时间没到
            {
                flag = AiAttackEnum.LockingTime;
            }
        }

        return flag;
    }

    // /// <summary>
    // /// 获取 Ai 对于该武器的评分, 评分越高, 代表 Ai 会越优先选择该武器, 如果为 -1, 则表示 Ai 不会使用该武器
    // /// </summary>
    // public float GetAiScore()
    // {
    //     return 1;
    // }
}