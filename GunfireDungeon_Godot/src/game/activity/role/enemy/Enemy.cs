
using System;
using System.Collections.Generic;
using Config;
using AiState;
using Godot;

/// <summary>
/// 敌人，可以携带武器
/// </summary>
public partial class Enemy : AiRole
{
    /// <summary>
    /// 敌人属性
    /// </summary>
    private ExcelConfig.EnemyBase _enemyAttribute;

    private static bool _init = false;
    private static Dictionary<string, ExcelConfig.EnemyBase> _enemyAttributeMap =
        new Dictionary<string, ExcelConfig.EnemyBase>();
    
    /// <summary>
    /// 初始化敌人属性数据
    /// </summary>
    public static void InitEnemyAttribute()
    {
        if (_init)
        {
            return;
        }

        _init = true;
        foreach (var enemyAttr in ExcelConfig.EnemyBase_List)
        {
            if (enemyAttr.Activity != null)
            {
                if (!_enemyAttributeMap.TryAdd(enemyAttr.Activity.Id, enemyAttr))
                {
                    Debug.LogError("发现重复注册的敌人属性: " + enemyAttr.Id);
                }
            }
        }
    }

    /// <summary>
    /// 根据 ActivityBase.Id 获取对应敌人的属性数据
    /// </summary>
    public static ExcelConfig.EnemyBase GetEnemyAttribute(string itemId)
    {
        if (itemId == null)
        {
            return null;
        }
        if (_enemyAttributeMap.TryGetValue(itemId, out var attr))
        {
            return attr;
        }

        throw new Exception($"敌人'{itemId}'没有在 EnemyBase 表中配置属性数据!");
    }
    
    public override void OnInit()
    {
        base.OnInit();
        Camp = CampEnum.Camp2;
    }

    protected override RoleState OnCreateRoleState()
    {
        var roleState = new RoleState();
        var enemyBase = GetEnemyAttribute(ActivityBase.Id).Clone();
        _enemyAttribute = enemyBase;

        MaxHp = enemyBase.Hp;
        Hp = enemyBase.Hp;
        roleState.CanPickUpWeapon = enemyBase.CanPickUpWeapon;
        roleState.MoveSpeed = enemyBase.MoveSpeed;
        roleState.Acceleration = enemyBase.Acceleration;
        roleState.Friction = enemyBase.Friction;
        ViewRange = enemyBase.ViewRange;
        DefaultViewRange = enemyBase.ViewRange;
        TailAfterViewRange = enemyBase.TailAfterViewRange;
        AttackInterval = enemyBase.AttackInterval;
        ViewAngleRange = enemyBase.ViewAngleRange;
        
        roleState.Gold = Mathf.Max(0, Utils.Random.RandomConfigRange(enemyBase.Gold));
        return roleState;
    }

    protected override void OnHit(ActivityObject target, int damage, float angle, bool realHarm)
    {
        base.OnHit(target, damage, angle, realHarm);

        if (Hp > 0) //受伤
        {
            SoundManager.PlaySoundByConfig("enemy_hurt", Position);
        }
        else if (Hp <= 0) //死亡
        {
            SoundManager.PlaySoundByConfig("enemy_die", Position);
        }
    }

    protected override void OnDie()
    {
        Color color;
        if (!string.IsNullOrEmpty(_enemyAttribute.BloodColor))
        {
            color = Color.FromHtml(_enemyAttribute.BloodColor);
        }
        else
        {
            color = new Color(1, 1, 1, 0.5f);
        }
        
        var effPos = Position + new Vector2(0, -Altitude);
        //血液特效
        var blood = ObjectManager.GetPoolItem<AutoDestroyParticles>(ResourcePath.prefab_effect_enemy_EnemyBlood0001_tscn);
        blood.Position = effPos - new Vector2(0, 12);
        blood.AddToActivityRoot(RoomLayerEnum.NormalLayer);
        blood.PlayEffect();
        
        var realVelocity = GetRealVelocity();
        var velocity = (realVelocity * 1.5f).LimitLength(80);
        //创建敌人碎片
        if (_enemyAttribute.BodyFragment != null)
        {
            var count = Utils.Random.RandomRangeInt(3, 6);
            for (var i = 0; i < count; i++)
            {
                var debris = Create(_enemyAttribute.BodyFragment);
                debris.PutDown(effPos, RoomLayerEnum.NormalLayer);
                debris.MoveController.AddForce(velocity);
                
                // 设置颜色
                if (debris is ICorpsesFragment corpsesFragment)
                {
                    corpsesFragment.SetBloodColor(color);
                }
            }
        }
        
        //派发敌人死亡信号
        EventManager.EmitEvent(EventEnum.OnEnemyDie, this);

        var obj = ResourceManager.LoadAndInstantiate<EnemyBlood0002>(
            Utils.Random.RandomChoose(
                ResourcePath.prefab_effect_enemy_EnemyBlood0002_tscn,
                ResourcePath.prefab_effect_enemy_EnemyBlood0003_tscn,
                ResourcePath.prefab_effect_enemy_EnemyBlood0004_tscn
            )
        );
        obj.AddToActivityRoot(RoomLayerEnum.NormalLayer);
        obj.InitRoom(AffiliationArea.RoomInfo);
        obj.Position = Position;
        obj.Rotation = PrevHitAngle;
        obj.ZIndex = AffiliationArea.RoomInfo.StaticImageCanvas.ZIndex;
        obj.Modulate = color;

        if (Utils.Random.RandomBoolean(0.04f)) //掉落心之容器
        {
            var activityObject = Create(Ids.Id_prop0002);
            activityObject.Throw(Position, 8, 35, Vector2.Zero, 0);
        }
        else if (Utils.Random.RandomBoolean(0.015f)) //掉落护盾
        {
            var activityObject = Create(Ids.Id_prop0003);
            activityObject.Throw(Position, 8, 35, Vector2.Zero, 0);
        }
        
        base.OnDie();
    }

    protected override void Process(float delta)
    {
        base.Process(delta);
        if (IsDie)
        {
            return;
        }
        
        UpdateFace();

        if (RoleState.CanPickUpWeapon)
        {
            //拾起武器操作
            DoPickUpWeapon();
        }
    }

    public override bool IsAllWeaponTotalAmmoEmpty()
    {
        if (!_enemyAttribute.CanPickUpWeapon)
        {
            return false;
        }
        return base.IsAllWeaponTotalAmmoEmpty();
    }

    /// <summary>
    /// 从标记出生时调用, 预加载波不会调用
    /// </summary>
    public virtual void OnBornFromMark()
    {
        //罚站 0.7 秒
        StateController.Enable = false;
        this.CallDelay(0.7f, () => StateController.Enable = true);
    }
}
