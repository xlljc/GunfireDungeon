using System;
using System.Collections.Generic;
using DsUi;
using Godot;


/// <summary>
/// 玩家角色基类, 所有角色都必须继承该类
/// </summary>
public partial class Player : Role
{
    /// <summary>
    /// 当玩家第一次进入房间时调用
    /// </summary>
    public event Action<RoomInfo> OnFirstEnterRoomEvent;
    
    /// <summary>
    /// 玩家身上的状态机控制器
    /// </summary>
    public StateController<Player, PlayerStateEnum> StateController { get; private set; }
    
    /// <summary>
    /// 是否可以翻滚
    /// </summary>
    public bool CanRoll => _rollCoolingTimer <= 0;
    
    //翻滚冷却计时器
    private float _rollCoolingTimer = 0;
    
    private BrushImageData _brushData;
    private List<KeyValuePair<long, int>> _hurtList = new List<KeyValuePair<long, int>>();

    // 记录摇杆瞄准位置
    private Vector2 _recordJoystickMousePos = new Vector2(100, 0);
    
    private Role _aimLockRole;
    
    public override void OnInit()
    {
        base.OnInit();

        StateController = AddComponent<StateController<Player, PlayerStateEnum>>();
        
        // debug用
        // DebugSet();

        //注册状态机
        StateController.Register(new PlayerIdleState());
        StateController.Register(new PlayerMoveState());
        StateController.Register(new PlayerRollState());
        //默认状态
        StateController.ChangeStateInstant(PlayerStateEnum.Idle);
        
        //InitSubLine();
        
        _brushData = LiquidBrushManager.GetBrush("0001");
        PickUpWeapon(Create<Weapon>(Ids.Id_weapon0003));
        PickUpWeapon(Create<Weapon>(Ids.Id_weapon0002));

        PickUpPartProp(PartProp.CreatePropActivity("3001"));
        PickUpPartProp(PartProp.CreatePropActivity("0001"));
        PickUpPartProp(PartProp.CreatePropActivity("0002"));

        // this.CallDelay(1f, () =>
        // {
        //     DrawLiquid(_brushData2);
        // });
    }

    private void DebugSet()
    {
        if (World is Hall)
        {
            return;
        }
        RoleState.Acceleration = 3000;
        RoleState.Friction = 3000;
        RoleState.MoveSpeed = 500;
        CollisionLayer = PhysicsLayer.None;
        CollisionMask = PhysicsLayer.None;
        
        this.CallDelay(1, () =>
        {
            GameCamera.Main.Zoom = GameApplication.Instance.DefaultCameraZoom / 2f;
        });
        
        World.TileRoot.SetLayerEnabled(MapLayer.AutoTopLayer, false);
        World.TileRoot.SetLayerEnabled(MapLayer.AutoMiddleLayer, false);
        
        this.CallDelay(0.5f, () =>
        {
            PickUpWeapon(Create<Weapon>(Ids.Id_weapon0003));
        });
        World.Color = new Color(1, 1, 1, 1); //关闭迷雾
        //显示房间小地图
        this.CallDelay(1, () =>
        {
            GameApplication.Instance.DungeonManager.StartRoomInfo.EachRoom(info =>
            {
                info.PreviewSprite.Visible = true;
                foreach (var roomDoorInfo in info.Doors)
                {
                    roomDoorInfo.AislePreviewSprite.Visible = true;
                }
            });
        });

    }

    protected override void Process(float delta)
    {
        base.Process(delta);
        if (IsDie)
        {
            return;
        }
        
        //更新每秒受到的伤害计数
        if (_hurtList.Count > 0)
        {
            var time = DateTime.Now.Ticks - 1000000;
            for (var i = 0; i < _hurtList.Count; i++)
            {
                var temp = _hurtList[i];
                if (temp.Key <= time) // 超过1秒
                {
                    // 移除
                    // Debug.Log("移除伤害：" + _hurtList[i]);
                    _hurtList.RemoveAt(i);
                    i--;
                }
                else
                {
                    break;
                }
            }
        }


        if (_rollCoolingTimer > 0)
        {
            _rollCoolingTimer -= delta;
        }
        
        if (MountLookTarget) //看向目标
        {
            HandlerAiming();
        }

        if (InputManager.ExchangeWeapon) //切换武器
        {
            ExchangeNextWeapon();
        }
        else if (InputManager.ThrowWeapon) //扔掉武器
        {
            ThrowWeapon();
        }
        else if (InputManager.Interactive) //互动物体
        {
            TriggerInteractive();
        }
        else if (InputManager.Reload) //换弹
        {
            Reload();
        }

        var meleeAttackFlag = false;
        if (InputManager.MeleeAttack) //近战攻击
        {
            if (StateController.CurrState != PlayerStateEnum.Roll) //不能是翻滚状态
            {
                if (WeaponPack.ActiveItem != null && WeaponPack.ActiveItem.Attribute.CanMeleeAttack)
                {
                    meleeAttackFlag = true;
                    MeleeAttack();
                }
            }
        }

        if (!meleeAttackFlag && InputManager.Fire) //正常开火
        {
            if (StateController.CurrState != PlayerStateEnum.Roll) //不能是翻滚状态
            {
                Attack();
            }
        }

        if (InputManager.UseActiveProp) //使用道具
        {
            UseActiveProp();
        }
        else if (InputManager.ExchangeProp) //切换道具
        {
            ExchangeNextActiveProp();
        }
        else if (InputManager.RemoveProp) //扔掉道具
        {
            ThrowActiveProp();
        }

        // //测试用
        // if (InputManager.Roll) //鼠标处触发互动物体
        // {
        //     var now = DateTime.Now;
        //     var mousePosition = GetGlobalMousePosition();
        //     var freezeSprites = AffiliationArea.RoomInfo.StaticSprite.CollisionCircle(mousePosition, 25, true);
        //     Debug.Log("检测数量: " + freezeSprites.Count + ", 用时: " + (DateTime.Now - now).TotalMilliseconds);
        //     foreach (var freezeSprite in freezeSprites)
        //     {
        //         var temp = freezeSprite.Position - mousePosition;
        //         freezeSprite.ActivityObject.MoveController.AddForce(temp.Normalized() * 300 * (25f - temp.Length()) / 25f);
        //     }
        // }
        
        // DrawLiquid(_brushData, ExcelConfig.LiquidLayer_List[0]);
    }
    
    private void HandlerAiming()
    {
        //脸的朝向
        var gPos = Position;
        Vector2 mousePos = CalcMousePosition(gPos);
            
        if (mousePos.X > gPos.X && Face == FaceDirection.Left)
        {
            Face = FaceDirection.Right;
        }
        else if (mousePos.X < gPos.X && Face == FaceDirection.Right)
        {
            Face = FaceDirection.Left;
        }
            
        //枪口跟随鼠标
        MountPoint.SetLookAt(mousePos);
    }
    
    private Vector2 CalcMousePosition(Vector2 gPos)
    {
        var app = GameApplication.Instance;
        Vector2 mousePos;
        if (_aimLockRole != null && (!app.GameSave.JoystickAimAssist || _aimLockRole.IsDie || _aimLockRole.IsDestroyed))
        {
            _aimLockRole = null;
        }
        if (InputManager.IsJoystickInput) // 摇杆瞄准
        {
            if (!InputManager.IsJoystickRInput) // 摇杆没有输入
            {
                if (app.GameSave.JoystickAimAssist && World != null) // 锁定瞄准
                {
                    if (_aimLockRole == null ||
                        Position.DistanceTo(_aimLockRole.Position) > GameConfig.MaxJoystickLockingDistance) // 之前帧没有记录 或者 锁定目标超出最大距离
                    {
                        _aimLockRole = GetNearestEnemy(GameConfig.MaxJoystickLockingDistance);
                    }
                    else // 之前帧有记录
                    {
                        // 需要更新，看看有没有更近的敌人 （比之前的敌人近50px）
                        var closerRole = TryFindCloserEnemy(_aimLockRole, 50f);
                        if (closerRole != null)
                        {
                            _aimLockRole = closerRole;
                        }
                    }

                    if (_aimLockRole != null) // 有锁定瞄准目标
                    {
                        mousePos = _aimLockRole.GetCenterPosition();
                    }
                    else // 没有锁定瞄准目标
                    {
                        mousePos = GetRecordJoystickMousePos(gPos);
                    }
                }
                else // 没有锁定瞄准
                {
                    mousePos = GetRecordJoystickMousePos(gPos);
                }
            }
            else // 摇杆有输入
            {
                if (app.GameSave.JoystickAimAssistStrength > 0.01f) // 有辅助瞄准
                {
                    _aimLockRole = GetAimAssistEnemy(gPos, InputManager.AimingPosition, app.GameSave.JoystickAimAssistStrength);
                    if (_aimLockRole != null)
                    {
                        mousePos = _aimLockRole.GetCenterPosition();
                    }
                    else
                    {
                        mousePos = InputManager.AimingPosition;
                    }
                }
                else // 没有辅助瞄准
                {
                    mousePos = InputManager.AimingPosition;
                }
            }
        }
        else // 鼠标瞄准
        {
            mousePos = InputManager.AimingPosition;
        }

        if (InputManager.IsJoystickInput && _aimLockRole != null)
        {
            app.Cursor.CustomHandlerFlag = true;
            app.Cursor.Position = app.WorldToUiPosition(mousePos);
            // app.Cursor.Position = app.WorldToUiPosition(_aimLockRole.GetCenterPosition());
        }
        else
        {
            app.Cursor.CustomHandlerFlag = false;
        }
        return mousePos;
    }

    // 获取记录摇杆瞄准位置
    private Vector2 GetRecordJoystickMousePos(Vector2 gPos)
    {
        if (InputManager.MoveAxis.LengthSquared() > 0.001f)
        {
            _recordJoystickMousePos = InputManager.MoveAxis.Normalized() * 120f;
        }
        return gPos + _recordJoystickMousePos;
    }
    
    /// <summary>
    /// 获取最近的敌人
    /// </summary>
    public Role GetNearestEnemy(float maxDistance)
    {
        Role nearestRole = null;
        float nearestDistanceSquared = maxDistance * maxDistance;
        foreach (var role in World.Role_InstanceList)
        {
            if (!role.IsEnemy(this) || role.IsDie || role.IsDestroyed)
            {
                continue;
            }

            var distanceSquared = Position.DistanceSquaredTo(role.Position);
            if (distanceSquared < nearestDistanceSquared)
            {
                nearestDistanceSquared = distanceSquared;
                nearestRole = role;
            }
        }

        return nearestRole;
    }

    /// <summary>
    /// 尝试找到比当前敌人更近的敌人（至少近指定距离）
    /// </summary>
    private Role TryFindCloserEnemy(Role currentRole, float minCloserDistance)
    {
        var currentDistSq = Position.DistanceSquaredTo(currentRole.Position);
        var threshold = currentDistSq - minCloserDistance * minCloserDistance;
        Role closerRole = null;
        float minDistSq = float.MaxValue;
        foreach (var role in World.Role_InstanceList)
        {
            if (!role.IsEnemy(this) || role.IsDie || role.IsDestroyed || role == currentRole)
            {
                continue;
            }
            var distSq = Position.DistanceSquaredTo(role.Position);
            if (distSq < threshold && distSq < minDistSq)
            {
                minDistSq = distSq;
                closerRole = role;
            }
        }
        return closerRole;
    }
    
    
    /// <summary>
    /// 获取辅助瞄准的敌人
    /// </summary>
    private Role GetAimAssistEnemy(Vector2 gPos, Vector2 aimPos, float assistStrength)
    {
        var fireDir = (aimPos - gPos).Normalized();
        var assistAngle = Mathf.DegToRad(60f * assistStrength);
        var minDist = float.MaxValue;
        Role nearestEnemy = null;
        // var nearestEnemyPos = Vector2.Zero;

        foreach (var role in World.Role_InstanceList)
        {
            if (!role.IsEnemy(this) || role.IsDie || role.IsDestroyed)
                continue;
            var toEnemy = role.GetCenterPosition() - gPos;
            var angle = fireDir.AngleTo(toEnemy.Normalized());
            if (Mathf.Abs(angle) <= assistAngle)
            {
                float dist = toEnemy.Length();
                if (dist < minDist)
                {
                    minDist = dist;
                    nearestEnemy = role;
                    // nearestEnemyPos = role.GetCenterPosition();
                }
            }
        }
        // if (nearestEnemy != null)
        // {
        //     return gPos.Lerp(nearestEnemyPos, assistStrength);
        // }
        return nearestEnemy;
    }
    
    protected override void OnAffiliationChange(AffiliationArea prevArea)
    {
        BrushPrevPosition = null;
        base.OnAffiliationChange(prevArea);
    }

    protected override void OnPickUpWeapon(Weapon weapon)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerPickUpWeapon, weapon);
    }

    protected override void OnThrowWeapon(Weapon weapon)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerRemoveWeapon, weapon);
    }

    protected override void OnShieldDestroy()
    {
        //破盾
        PlayInvincibleFlashing(RoleState.ShieldInv);
    }

    protected override int OnHandlerHurt(int damage)
    {
        if (Shield > 0)
        {
            return damage;
        }

        var value = Mathf.CeilToInt(RoleState.WoundMaxPct * MaxHp);
        return damage >= value ? //触发保护机制
            value : damage;
    }
    
    protected override void OnHit(ActivityObject target, int damage, float angle, bool realHarm)
    {
        //进入无敌状态
        if (realHarm) //真实伤害，不是护盾抵消掉的
        {
            _hurtList.Add(new KeyValuePair<long, int>(DateTime.Now.Ticks, damage));
            if (damage >= Mathf.CeilToInt(RoleState.WoundMaxPct * MaxHp)) //触发保护机制的无敌时间
            {
                PlayInvincibleFlashing(RoleState.WoundMaxInv);
            }
            else if (GetDamageTakenInTheLastSecond() >= Mathf.CeilToInt(RoleState.WoundInvPct * MaxHp)) //触发无敌
            {
                PlayInvincibleFlashing(RoleState.WoundInv);
            }
        }

        //血量为0, 扔掉所有武器
        if (Hp <= 0) //死亡
        {
            BasisVelocity = Vector2.Zero;
            Velocity = Vector2.Zero;
            ThrowAllWeapon();
            
            GameCamera.Main.CreateShake(new Vector2(3, 3), 1f, true);
            GameCamera.Main.FollowsMouseAmount = 0;
            GameCamera.Main.PlayZoomAnimation(GameApplication.Instance.DefaultCameraZoom * 2, 5);

            SoundManager.PlaySoundByConfig("role_die", Position);
        }
        else //受伤
        {
            SoundManager.PlaySoundByConfig("role_hurt", Position);
        }
    }

    protected override void ChangeInteractiveItem(CheckInteractiveResult prev, CheckInteractiveResult result)
    {
        //派发互动对象改变事件
        EventManager.EmitEvent(EventEnum.OnPlayerChangeInteractiveItem, result);
    }
    
    protected override void OnChangeHp(int hp)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerHpChange, hp);
    }

    protected override void OnChangeMaxHp(int maxHp)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerMaxHpChange, maxHp);
    }

    protected override void OnChangeArmor(int armor)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerArmorChange, armor);
    }

    protected override void OnChangeMaxArmor(int maxArmor)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerMaxArmorChange, maxArmor);
    }
    
    protected override void OnChangeShield(int shield)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerShieldChange, shield);
    }

    protected override void OnChangeMaxShield(int maxShield)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerMaxShieldChange, maxShield);
    }

    protected override void OnDie()
    {
        StateController.Enable = false;
        GameCamera.Main.SetFollowTarget(null);
        BasisVelocity = Vector2.Zero;
        MoveController.ClearForce();
        Visible = false;

        World.CallDelay(0.5f, () =>
        {
            //暂停游戏
            World.Current.Pause = true;
            //弹出结算面板
            UiManager.Open_Game_Settlement();
        });
    }

    protected override void OnPickUpActiveProp(ActiveProp activeProp)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerPickUpProp, activeProp);
    }

    protected override void OnRemoveActiveProp(ActiveProp activeProp)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerRemoveProp, activeProp);
    }

    protected override void OnPickUpBuffProp(BuffProp buffProp)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerPickUpProp, buffProp);
    }

    protected override void OnRemoveBuffProp(BuffProp buffProp)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerRemoveProp, buffProp);
    }
    
    protected override void OnPickUpPartProp(PartProp partProp)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerRemoveProp, partProp);
    }

    protected override void OnRemovePartProp(PartProp partProp)
    {
        EventManager.EmitEvent(EventEnum.OnPlayerRemoveProp, partProp);
    }

    /// <summary>
    /// 处理角色移动的输入
    /// </summary>
    public void HandleMoveInput(float delta)
    {
        var dir = InputManager.MoveAxis;
        // 移动. 如果移动的数值接近0(是用 摇杆可能出现 方向 可能会出现浮点)，就friction的值 插值 到 0
        // 如果 有输入 就以当前速度，用acceleration 插值到 对应方向 * 最大速度
        if (Mathf.IsZeroApprox(dir.X))
        {
            BasisVelocity = new Vector2(Mathf.MoveToward(BasisVelocity.X, 0, RoleState.Friction * delta), BasisVelocity.Y);
        }
        else
        {
            BasisVelocity = new Vector2(Mathf.MoveToward(BasisVelocity.X, dir.X * RoleState.MoveSpeed, RoleState.Acceleration * delta), BasisVelocity.Y);
        }

        if (Mathf.IsZeroApprox(dir.Y))
        {
            BasisVelocity = new Vector2(BasisVelocity.X, Mathf.MoveToward(BasisVelocity.Y, 0, RoleState.Friction * delta));
        }
        else
        {
            BasisVelocity = new Vector2(BasisVelocity.X, Mathf.MoveToward(BasisVelocity.Y, dir.Y * RoleState.MoveSpeed, RoleState.Acceleration * delta));
        }
    }

    /// <summary>
    /// 翻滚结束
    /// </summary>
    public void OverRoll()
    {
        _rollCoolingTimer = RoleState.RollCoolingTime;
    }

    // protected override void DebugDraw()
    // {
    //     base.DebugDraw();
    //     DrawArc(GetLocalMousePosition(), 25, 0, Mathf.Pi * 2f, 20, Colors.Red, 1);
    // }

    public override void AddGold(int goldCount)
    {
        base.AddGold(goldCount);
        EventManager.EmitEvent(EventEnum.OnPlayerGoldChange, RoleState.Gold);
    }

    public override void UseGold(int goldCount)
    {
        base.UseGold(goldCount);
        EventManager.EmitEvent(EventEnum.OnPlayerGoldChange, RoleState.Gold);
    }

    /// <summary>
    /// 获取最近 1 秒内受到的伤害，只算真实伤害，护盾抵消的不算
    /// </summary>
    public int GetDamageTakenInTheLastSecond()
    {
        var v = 0;
        for (var i = 0; i < _hurtList.Count; i++)
        {
            v += _hurtList[i].Value;
        }

        return v;
    }

    /// <summary>
    /// 玩家第一次进入房间时调用
    /// </summary>
    public virtual void OnFirstEnterRoom(RoomInfo roomInfo)
    {
        if (OnFirstEnterRoomEvent != null)
        {
            OnFirstEnterRoomEvent(roomInfo);
        }
    }
}
