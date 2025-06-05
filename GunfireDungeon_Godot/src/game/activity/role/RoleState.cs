
using System;
using Config;
using Godot;

/// <summary>
/// 角色属性类
/// </summary>
public class RoleState
{
    public RoleState(ExcelConfig.RoleBase roleBase)
    {
        RoleBase = roleBase;
    }

    /// <summary>
    /// 角色原始配置数据
    /// </summary>
    public readonly ExcelConfig.RoleBase RoleBase;

    /// <summary>
    /// 金币数量
    /// </summary>
    public int Gold = 0;

    /// <summary>
    /// 是否可以拾起武器
    /// </summary>
    public bool CanPickUpWeapon = false;

    /// <summary>
    /// 移动速度
    /// </summary>
    public float MoveSpeed = 120f;

    /// <summary>
    /// 移动加速度
    /// </summary>
    public float Acceleration = 1500f;

    /// <summary>
    /// 移动摩擦力, 仅用于人物基础移动
    /// </summary>
    public float Friction = 900f;

    /// <summary>
    /// 护盾恢复时间, 单位: 秒
    /// </summary>
    public float ShieldRecoveryTime = 10;

    /// <summary>
    /// 护盾恢复速度，每秒恢复量
    /// </summary>
    public float ShieldRecoverySpeed = 2;

    /// <summary>
    /// 破盾后的无敌时间, 单位: 秒
    /// </summary>
    public float ShieldInvincibleTime = 1.5f;

    /// <summary>
    /// 每秒受到多少百分比伤害后触发无敌
    /// </summary>
    public float WoundedInvinciblePercent = 0.15f;

    /// <summary>
    /// 受伤后的无敌时间, 单位: 秒
    /// </summary>
    public float WoundedInvincibleTime = 1f;

    /// <summary>
    /// 单次能受到最大的百分比伤害，也就是保护机制
    /// </summary>
    public float WoundedMaxDamagePercent = 0.75f;

    /// <summary>
    /// 触发保护机制后的无敌时间, 单位: 秒
    /// </summary>
    public float WoundedMaxDamageInvincibleTime = 2.5f;

    /// <summary>
    /// 近战攻击间隔时间
    /// </summary>
    public float MeleeAttackTime = 0.5f;

    /// <summary>
    /// 翻滚速度
    /// </summary>
    public float RollSpeed = 170f;

    /// <summary>
    /// 翻滚持续时间
    /// </summary>
    public float RollTime = 0.15f;

    /// <summary>
    /// 翻滚冷却时间
    /// </summary>
    public float RollCoolingTime = 0.2f;

    /// <summary>
    /// 物理属性伤害抗性
    /// </summary>
    public float PhysicalResist;

    /// <summary>
    /// 魔法属性伤害抗性
    /// </summary>
    public float MagicResist;

    /// <summary>
    /// 火焰属性伤害抗性
    /// </summary>
    public float FireResist;

    /// <summary>
    /// 冰霜属性伤害抗性
    /// </summary>
    public float IceResist;

    /// <summary>
    /// 雷电属性伤害抗性
    /// </summary>
    public float ThunderResist;

    /// <summary>
    /// 光明属性伤害抗性
    /// </summary>
    public float LightResist;

    /// <summary>
    /// 暗影属性伤害抗性
    /// </summary>
    public float DarkResist;

    /// <summary>
    /// 魔法属性伤害抗性
    /// </summary>
    public float RealResist;

    /// <summary>
    /// 计算抗性伤害
    /// </summary>
    public int CalcResistDamage(int damage, DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Physical:
                return Mathf.CeilToInt(damage * PhysicalResist);
            case DamageType.Magic:
                return Mathf.CeilToInt(damage * MagicResist);
            case DamageType.Fire:
                return Mathf.CeilToInt(damage * FireResist);
            case DamageType.Ice:
                return Mathf.CeilToInt(damage * IceResist);
            case DamageType.Thunder:
                return Mathf.CeilToInt(damage * ThunderResist);
            case DamageType.Light:
                return Mathf.CeilToInt(damage * LightResist);
            case DamageType.Dark:
                return Mathf.CeilToInt(damage * DarkResist);
        }

        return damage;
    }

    public delegate void CalcDamageEventHandler(int damage, DamageType damageType, RefValue<int> result);

    /// <summary>
    /// 攻击/发射后计算伤害
    /// </summary>
    public event CalcDamageEventHandler CalcDamageEvent;

    public int CalcDamage(int damage, DamageType damageType)
    {
        if (CalcDamageEvent != null)
        {
            var result = new RefValue<int>(damage);
            CalcDamageEvent(damage, damageType, result);
            return result.Value;
        }

        return damage;
    }

    public delegate void CalcHurtDamageEventHandler(int damage, DamageType damageType, RefValue<int> result);

    /// <summary>
    /// 受伤后计算受到的伤害
    /// </summary>
    public event CalcHurtDamageEventHandler CalcHurtDamageEvent;

    public int CalcHurtDamage(int damage, DamageType damageType)
    {
        if (CalcHurtDamageEvent != null)
        {
            var result = new RefValue<int>(damage);
            CalcHurtDamageEvent(damage, damageType, result);
            return result.Value;
        }

        return damage;
    }

    public delegate void CalcStartScatteringEventHandler(float value, RefValue<float> result);

    /// <summary>
    /// 武器初始散射值增量
    /// </summary>
    public event CalcStartScatteringEventHandler CalcStartScatteringEvent;

    public float CalcStartScattering(float value)
    {
        if (CalcStartScatteringEvent != null)
        {
            var result = new RefValue<float>(value);
            CalcStartScatteringEvent(value, result);
            return result.Value;
        }

        return value;
    }

    public delegate void CalcFinalScatteringEventHandler(float value, RefValue<float> result);

    /// <summary>
    /// 武器最终散射值增量
    /// </summary>
    public event CalcFinalScatteringEventHandler CalcFinalScatteringEvent;

    public float CalcFinalScattering(float value)
    {
        if (CalcFinalScatteringEvent != null)
        {
            var result = new RefValue<float>(value);
            CalcFinalScatteringEvent(value, result);
            return result.Value;
        }

        return value;
    }

    public delegate void CalcBulletCountEventHandler(int count, RefValue<int> result);

    /// <summary>
    /// 武器开火发射子弹数量
    /// </summary>
    public event CalcBulletCountEventHandler CalcBulletCountEvent;

    public int CalcBulletCount(int count)
    {
        if (CalcBulletCountEvent != null)
        {
            var result = new RefValue<int>(count);
            CalcBulletCountEvent(count, result);
            return result.Value;
        }

        return count;
    }

    public delegate void CalcBulletDeviationAngleEventHandler(float angle, RefValue<float> result);

    /// <summary>
    /// 子弹偏移角度, 角度制
    /// </summary>
    public event CalcBulletDeviationAngleEventHandler CalcBulletDeviationAngleEvent;

    public float CalcBulletDeviationAngle(float angle)
    {
        if (CalcBulletDeviationAngleEvent != null)
        {
            var result = new RefValue<float>(angle);
            CalcBulletDeviationAngleEvent(angle, result);
            return result.Value;
        }

        return angle;
    }

    public delegate void CalcBulletSpeedEventHandler(float speed, RefValue<float> result);

    /// <summary>
    /// 子弹速度
    /// </summary>
    public event CalcBulletSpeedEventHandler CalcBulletSpeedEvent;

    public float CalcBulletSpeed(float speed)
    {
        if (CalcBulletSpeedEvent != null)
        {
            var result = new RefValue<float>(speed);
            CalcBulletSpeedEvent(speed, result);
            return result.Value;
        }

        return speed;
    }

    public delegate void CalcBulletDistanceEventHandler(float distance, RefValue<float> result);

    /// <summary>
    /// 子弹射程
    /// </summary>
    public event CalcBulletDistanceEventHandler CalcBulletDistanceEvent;

    public float CalcBulletDistance(float distance)
    {
        if (CalcBulletDistanceEvent != null)
        {
            var result = new RefValue<float>(distance);
            CalcBulletDistanceEvent(distance, result);
            return result.Value;
        }

        return distance;
    }

    public delegate void CalcBulletRepelEventHandler(float distance, RefValue<float> result);

    /// <summary>
    /// 子弹击退
    /// </summary>
    public event CalcBulletRepelEventHandler CalcBulletRepelEvent;

    public float CalcBulletRepel(float distance)
    {
        if (CalcBulletRepelEvent != null)
        {
            var result = new RefValue<float>(distance);
            CalcBulletRepelEvent(distance, result);
            return result.Value;
        }

        return distance;
    }

    public delegate void CalcBulletBounceCountEventHandler(int distance, RefValue<int> result);

    /// <summary>
    /// 子弹反弹次数
    /// </summary>
    public event CalcBulletBounceCountEventHandler CalcBulletBounceCountEvent;

    public int CalcBulletBounceCount(int distance)
    {
        if (CalcBulletBounceCountEvent != null)
        {
            var result = new RefValue<int>(distance);
            CalcBulletBounceCountEvent(distance, result);
            return result.Value;
        }

        return distance;
    }

    public delegate void CalcBulletPenetrationEventHandler(int distance, RefValue<int> result);

    /// <summary>
    /// 子弹穿透次数
    /// </summary>
    public event CalcBulletPenetrationEventHandler CalcBulletPenetrationEvent;

    public int CalcBulletPenetration(int distance)
    {
        if (CalcBulletPenetrationEvent != null)
        {
            var result = new RefValue<int>(distance);
            CalcBulletPenetrationEvent(distance, result);
            return result.Value;
        }

        return distance;
    }

    public delegate void CalcGetGoldEventHandler(int gold, RefValue<int> result);

    /// <summary>
    /// 计算获取的金币
    /// </summary>
    public event CalcGetGoldEventHandler CalcGetGoldEvent;

    public int CalcGetGold(int gold)
    {
        if (CalcGetGoldEvent != null)
        {
            var result = new RefValue<int>(gold);
            CalcGetGoldEvent(gold, result);
            return result.Value;
        }

        return gold;
    }

    public delegate void CalcBulletEventHandler(ExcelConfig.BulletBase attributeBullet, RefValue<ExcelConfig.BulletBase> result);

    /// <summary>
    /// 计算射出的子弹
    /// </summary>
    public event CalcBulletEventHandler CalcBulletEvent;

    public ExcelConfig.BulletBase CalcBullet(ExcelConfig.BulletBase attributeBullet)
    {
        if (CalcBulletEvent != null)
        {
            var result = new RefValue<ExcelConfig.BulletBase>(attributeBullet);
            CalcBulletEvent(attributeBullet, result);
            return result.Value;
        }

        return attributeBullet;
    }
}