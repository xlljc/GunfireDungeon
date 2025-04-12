
using System;
using System.Collections.Generic;
using System.Linq;
using AiState;
using Godot;

/// <summary>
/// Ai角色
/// </summary>
public abstract partial class AiRole : Role
{
    /// <summary>
    /// 目标是否在视野内, 视野内不能有墙壁遮挡
    /// </summary>
    public bool TargetInView { get; private set; } = false;

    /// <summary>
    /// 目标间是否有墙壁遮挡
    /// </summary>
    public bool TargetHasOcclusion { get; private set; } = false;
    
    /// <summary>
    /// 目标是否在视野范围内, 不会考虑是否被枪遮挡
    /// </summary>
    public bool TargetInViewRange { get; private set; } = false;
    
    /// <summary>
    /// 敌人身上的状态机控制器
    /// </summary>
    public StateController<AiRole, AIStateEnum> StateController { get; private set; }
    
    /// <summary>
    /// 视野检测射线, 朝玩家打射线, 检测是否碰到墙
    /// </summary>
    [Export, ExportFillNode]
    public RayCast2D ViewRay { get; set; }

    /// <summary>
    /// 导航代理
    /// </summary>
    [Export, ExportFillNode]
    public NavigationAgent2D NavigationAgent2D { get; set; }

    /// <summary>
    /// 导航代理中点
    /// </summary>
    [Export, ExportFillNode]
    public Marker2D NavigationPoint { get; set; }

    /// <summary>
    /// 不通过武发射子弹的开火点
    /// </summary>
    [Export, ExportFillNode]
    public Marker2D FirePoint { get; set; }
    
    /// <summary>
    /// 当前敌人所看向的对象, 也就是枪口指向的对象
    /// </summary>
    public ActivityObject LookTarget { get; set; }

    /// <summary>
    /// 攻击锁定目标时间
    /// </summary>
    public float LockingTime { get; set; } = 1f;
    
    /// <summary>
    /// 锁定目标已经走过的时间
    /// </summary>
    public float LockTargetTime { get; set; } = 0;

    /// <summary>
    /// 开火时是否站立不动
    /// </summary>
    public bool FiringStand { get; set; } = false;

    /// <summary>
    /// 视野半径, 单位像素, 发现玩家后改视野范围可以穿墙
    /// </summary>
    public float ViewRange { get; set; } = -1;

    /// <summary>
    /// 默认视野半径
    /// </summary>
    public float DefaultViewRange { get; set; } = 250;

    /// <summary>
    /// 发现玩家后跟随玩家的视野半径
    /// </summary>
    public float TailAfterViewRange { get; set; } = 400;
    
    /// <summary>
    /// 视野角度, 角度制
    /// </summary>
    public float ViewAngleRange { get; set; } = 150;
    
    /// <summary>
    /// 攻击间隔时间, 秒
    /// </summary>
    public float AttackInterval { get; set; } = 0;

    /// <summary>
    /// 当前Ai是否有攻击欲望
    /// </summary>
    public bool HasAttackDesire { get; private set; } = true;
    
    /// <summary>
    /// 是否有移动欲望, 仅在 AiNormal 状态下有效, 其他状态都可以移动
    /// </summary>
    public bool HasMoveDesire { get; private set; } = true;

    public override void OnInit()
    {
        base.OnInit();
        IsAi = true;
        
        StateController = AddComponent<StateController<AiRole, AIStateEnum>>();
        
        //注册Ai状态机
        StateController.Register(new AiNormalState());
        StateController.Register(new AiTailAfterState());
        StateController.Register(new AiFollowUpState());
        StateController.Register(new AiSurroundState());
        StateController.Register(new AiFindAmmoState());
        StateController.Register(new AiAttackState());
        
        //默认状态
        StateController.ChangeStateInstant(AIStateEnum.AiNormal);

        //NavigationAgent2D.VelocityComputed += OnVelocityComputed;
    }

    protected override void Process(float delta)
    {
        base.Process(delta);
        
        if (LookTarget != null)
        {
            if (LookTarget.IsDestroyed)
            {
                LookTarget = null;
                TargetInViewRange = false;
                TargetHasOcclusion = false;
                TargetInView = false;
            }
            else
            {
                //判断目标是否被墙壁遮挡
                TargetHasOcclusion = TestViewRayCast(LookTarget.GetCenterPosition());
                TestViewRayCastOver();

                TargetInViewRange = true;
                TargetInView = !TargetHasOcclusion;
            }
        }

        //更新视野范围
        ViewRange = StateController.CurrState == AIStateEnum.AiNormal ? DefaultViewRange : TailAfterViewRange;
    }

    /// <summary>
    /// 计算攻击目标
    /// </summary>
    public Role CalcAttackTarget()
    {
        var enemyItems = AffiliationArea?.FindEnterItems(
            o => o is Role role && !role.IsDestroyed && IsEnemy(role));
        if (enemyItems == null || enemyItems.Length == 0) return null;

        try
        {
            var pos = Position;
            //排序距离升序
            var enumerable = enemyItems
                .Select(i => new KeyValuePair<Role, float>((Role)i, i.Position.DistanceSquaredTo(pos)))
                .OrderBy(i => i.Value).ToArray();
            foreach (var pair in enumerable)
            {
                if (TestViewRayCast(pair.Key.GetCenterPosition()))
                {
                    return pair.Key;
                }
            }

            return enumerable.First().Key;
        }
        finally
        {
            TestViewRayCastOver();
        }
    }
    
    /// <summary>
    /// 返回地上的武器是否有可以拾取的, 也包含没有被其他敌人标记的武器
    /// </summary>
    public bool CheckUsableWeaponInUnclaimed()
    {
        foreach (var unclaimedWeapon in World.Weapon_UnclaimedList)
        {
            //判断是否能拾起武器, 条件: 相同的房间
            if (unclaimedWeapon.AffiliationArea == AffiliationArea)
            {
                if (!unclaimedWeapon.IsTotalAmmoEmpty())
                {
                    if (!unclaimedWeapon.HasSign(SignNames.AiFindWeaponSign))
                    {
                        return true;
                    }
                    else
                    {
                        //判断是否可以移除该标记
                        var enemy = unclaimedWeapon.GetSign<Enemy>(SignNames.AiFindWeaponSign);
                        if (enemy == null || enemy.IsDestroyed) //标记当前武器的敌人已经被销毁
                        {
                            unclaimedWeapon.RemoveSign(SignNames.AiFindWeaponSign);
                            return true;
                        }
                        else if (!enemy.IsAllWeaponTotalAmmoEmpty()) //标记当前武器的敌人已经有新的武器了
                        {
                            unclaimedWeapon.RemoveSign(SignNames.AiFindWeaponSign);
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }
    
    /// <summary>
    /// 寻找可用的武器
    /// </summary>
    public Weapon FindTargetWeapon()
    {
        Weapon target = null;
        var position = Position;
        foreach (var weapon in World.Weapon_UnclaimedList)
        {
            //判断是否能拾起武器, 条件: 相同的房间, 或者当前房间目前没有战斗, 或者不在战斗房间
            if (weapon.AffiliationArea == AffiliationArea)
            {
                //还有弹药
                if (!weapon.IsTotalAmmoEmpty())
                {
                    //查询是否有其他敌人标记要拾起该武器
                    if (weapon.HasSign(SignNames.AiFindWeaponSign))
                    {
                        var enemy = weapon.GetSign<Enemy>(SignNames.AiFindWeaponSign);
                        if (enemy == this) //就是自己标记的
                        {

                        }
                        else if (enemy == null || enemy.IsDestroyed) //标记当前武器的敌人已经被销毁
                        {
                            weapon.RemoveSign(SignNames.AiFindWeaponSign);
                        }
                        else if (!enemy.IsAllWeaponTotalAmmoEmpty()) //标记当前武器的敌人已经有新的武器了
                        {
                            weapon.RemoveSign(SignNames.AiFindWeaponSign);
                        }
                        else //放弃这把武器
                        {
                            continue;
                        }
                    }

                    if (target == null) //第一把武器
                    {
                        target = weapon;
                    }
                    else if (target.Position.DistanceSquaredTo(position) >
                             weapon.Position.DistanceSquaredTo(position)) //距离更近
                    {
                        target = weapon;
                    }
                }
            }
        }

        return target;
    }

    /// <summary>
    /// 调用视野检测, 如果被墙壁和其它物体遮挡, 则返回true
    /// </summary>
    public bool TestViewRayCast(Vector2 target)
    {
        ViewRay.Enabled = true;
        ViewRay.TargetPosition = ViewRay.ToLocal(target);
        ViewRay.ForceRaycastUpdate();
        return ViewRay.IsColliding();
    }

    /// <summary>
    /// 调用视野检测完毕后, 需要调用 TestViewRayCastOver() 来关闭视野检测射线
    /// </summary>
    public void TestViewRayCastOver()
    {
        ViewRay.Enabled = false;
    }

    /// <summary>
    /// AI 拾起武器操作
    /// </summary>
    public void DoPickUpWeapon()
    {
        //这几个状态不需要主动拾起武器操作
        var state = StateController.CurrState;
        if (state == AIStateEnum.AiNormal || state == AIStateEnum.AiAttack)
        {
            return;
        }
        
        //拾起地上的武器
        foreach (var interactive in InteractiveItemList)
        {
            if (interactive is Weapon weapon)
            {
                if (WeaponPack.ActiveItem == null) //手上没有武器, 无论如何也要拾起
                {
                    TriggerInteractive();
                    return;
                }

                //没弹药了
                if (weapon.IsTotalAmmoEmpty())
                {
                    return;
                }

                // var index2 = Holster.FindWeapon((we, i) =>
                //     we.Attribute.WeightType == weapon.Attribute.WeightType && we.IsTotalAmmoEmpty());
                var index2 = WeaponPack.FindIndex((we, i) => we.IsTotalAmmoEmpty());
                if (index2 != -1) //扔掉没子弹的武器
                {
                    ThrowWeapon(index2);
                    TriggerInteractive();
                    return;
                }
            
                // if (Holster.HasVacancy()) //有空位, 拾起武器
                // {
                //     TriggerInteractive();
                //     return;
                // }
            }
        }
        
    }
    
    /// <summary>
    /// 获取锁定目标的剩余时间
    /// </summary>
    public float GetLockRemainderTime()
    {
        var weapon = WeaponPack.ActiveItem;
        if (weapon == null)
        {
            return LockingTime - LockTargetTime;
        }
        return weapon.Attribute.AiAttackAttr.LockingTime - LockTargetTime;
    }

    public override void LookTargetPosition(Vector2 pos)
    {
        LookTarget = null;
        base.LookTargetPosition(pos);
    }
    
    /// <summary>
    /// 执行移动操作
    /// </summary>
    public void DoMove()
    {
        // //计算移动
        // NavigationAgent2D.MaxSpeed = EnemyRoleState.MoveSpeed;
        // var nextPos = NavigationAgent2D.GetNextPathPosition();
        // NavigationAgent2D.Velocity = (nextPos - Position - NavigationPoint.Position).Normalized() * RoleState.MoveSpeed;
        
        AnimatedSprite.Play(AnimatorNames.Run);
        //计算移动
        var nextPos = NavigationAgent2D.GetNextPathPosition();
        BasisVelocity = (nextPos - Position - NavigationPoint.Position).Normalized() * RoleState.MoveSpeed;
    }

    /// <summary>
    /// 执行站立操作
    /// </summary>
    public void DoIdle()
    {
        AnimatedSprite.Play(AnimatorNames.Idle);
        BasisVelocity = Vector2.Zero;
    }
        
    /// <summary>
    /// 更新房间中标记的目标位置
    /// </summary>
    public void UpdateMarkTargetPosition()
    {
        if (LookTarget != null && AffiliationArea != null)
        {
            AffiliationArea.RoomInfo.MarkTargetPosition[LookTarget.Id] = LookTarget.Position;
        }
    }

    protected override void OnDie()
    {
        //扔掉所有武器
        ThrowAllWeapon();
        //创建金币
        Gold.CreateGold(Position, RoleState.Gold);
        //销毁
        Destroy();
    }

    /// <summary>
    /// 设置Ai是否有攻击欲望
    /// </summary>
    public void SetAttackDesire(bool v)
    {
        if (v != HasAttackDesire)
        {
            HasAttackDesire = v;
            StateController.ChangeState(AIStateEnum.AiNormal);
        }
    }

    /// <summary>
    /// 设置Ai是否有移动欲望
    /// </summary>
    public void SetMoveDesire(bool v)
    {
        HasMoveDesire = v;
    }

    /// <summary>
    /// 更新玩家脸的朝向
    /// </summary>
    public void UpdateFace()
    {
        //看向目标
        if (LookTarget != null && MountLookTarget)
        {
            var pos = LookTarget.Position;
            LookPosition = pos;
            //脸的朝向
            var gPos = Position;
            if (pos.X > gPos.X && Face == FaceDirection.Left)
            {
                Face = FaceDirection.Right;
            }
            else if (pos.X < gPos.X && Face == FaceDirection.Right)
            {
                Face = FaceDirection.Left;
            }

            //枪口跟随目标
            MountPoint.SetLookAt(pos);
        }
    }
    
    protected override void OnHit(ActivityObject target, int damage, float angle, bool realHarm)
    {
        //受到伤害
        var state = StateController.CurrState;
        if (state == AIStateEnum.AiNormal)
        {
            if (target is Role role)
            {
                //进入跟随状态
                StateController.ChangeState(AIStateEnum.AiTailAfter, role);
            }
        }
        else if (state == AIStateEnum.AiFindAmmo)
        {
            if (LookTarget == null)
            {
                if (target is Role role)
                {
                    LookTarget = target;
                }
                var findAmmo = (AiFindAmmoState)StateController.CurrStateBase;
                StateController.ChangeState(AIStateEnum.AiFindAmmo, findAmmo.TargetWeapon);
            }
        }
        else if (TargetHasOcclusion || !TargetInView)
        {
            if (target is Role role)
            {
                LookTarget = target;
            }
        }
    }
    
    // private void OnVelocityComputed(Vector2 velocity)
    // {
    //     if (Mathf.Abs(velocity.X) >= 0.01f && Mathf.Abs(velocity.Y) >= 0.01f)
    //     {
    //         AnimatedSprite.Play(AnimatorNames.Run);
    //         BasisVelocity = velocity;
    //     }
    // }
}