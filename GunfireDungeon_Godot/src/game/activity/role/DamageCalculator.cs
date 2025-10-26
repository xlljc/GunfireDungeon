
using Config;
using Godot;

public class AttackStats
{
    /// <summary>
    /// 基础伤害
    /// </summary>
    public float BaseDamage;
    /// <summary>
    /// 伤害类型
    /// </summary>
    public DamageType Type;
    /// <summary>
    /// 暴击率
    /// </summary>
    public float CritRate;
    /// <summary>
    /// 暴击伤害修正（例如0.25表示+25%）
    /// </summary>
    public float CritBonus;
    /// <summary>
    /// 暴击穿透装甲比例（例如0.25）
    /// </summary>
    public float CritArmorPenetration;
}

public class DamageResult
{
    /// <summary>
    /// 护盾伤害
    /// </summary>
    public float ShieldDamage;
    
    /// <summary>
    /// 装甲伤害
    /// </summary>
    public float ArmorDamage;
    
    /// <summary>
    /// 生命伤害
    /// </summary>
    public float HealthDamage;
}

public class DamageCalculator
{
    /// <summary>
    /// 伤害计算
    /// </summary>
    public static DamageResult ApplyDamage(ExcelConfig.RoleBase roleBase, AttackStats attackStats)
    {
        // ------------------------- 减免后逻辑
        var damageConfig = ExcelConfig.DamageConfig_Map[attackStats.Type.ToString()];
        float resist;
        if (damageConfig.MinReduce > damageConfig.MaxReduce)
        {
            resist = Mathf.Clamp(roleBase.GetDamageResist(attackStats.Type), damageConfig.MaxReduce, damageConfig.MinReduce);
        }
        else
        {
            resist = Mathf.Clamp(roleBase.GetDamageResist(attackStats.Type), damageConfig.MinReduce, damageConfig.MaxReduce);
        }
        var damage = attackStats.BaseDamage * (1 - resist);
        
        // ------------------------- 护盾逻辑
        var shieldMultiplier = damageConfig.ShieldMultiplier;
        var shieldDamage = damage * shieldMultiplier;
        var shieldOverflow = (shieldDamage - roleBase.Shield) / shieldMultiplier;

        // ------------------------- 暴击逻辑
        var criticalHitRate = attackStats.CritRate - roleBase.CritResist;
        var criticalHit = shieldOverflow * (1 + attackStats.CritBonus);

        var armorMultiplier = damageConfig.ArmorMultiplier;
        var healthMultiplier = damageConfig.HealthMultiplier;

        float armorDamage;
        float armorOverflow;
        float healthDamage;
        
        // 未溢出伤害的情况下不能触发暴击，不同的伤害类型也有可能不能触发暴击
        var isCrit = shieldOverflow > 0 && damageConfig.Critable && Utils.Random.RandomBoolean(criticalHitRate);
        if (isCrit)
        {
            armorDamage = criticalHit * (1 - attackStats.CritArmorPenetration) * armorMultiplier;
            armorOverflow = Mathf.Max(0, (armorDamage - roleBase.Armor) / armorMultiplier);
            healthDamage = (criticalHit * attackStats.CritArmorPenetration + armorOverflow) * healthMultiplier;
            return new DamageResult
            {
                ShieldDamage = shieldDamage,
                ArmorDamage = Mathf.Max(armorDamage, 0),
                HealthDamage = Mathf.Max(healthDamage, 0)
            };
        }
        armorDamage = shieldOverflow * armorMultiplier;
        armorOverflow = Mathf.Max(0, (armorDamage - roleBase.Armor) / armorMultiplier);
        healthDamage = armorOverflow * healthMultiplier;
        
        return new DamageResult
        {
            ShieldDamage = shieldDamage,
            ArmorDamage = Mathf.Max(armorDamage, 0),
            HealthDamage = Mathf.Max(healthDamage, 0)
        };
    }
    
    /// <summary>
    /// 伤害计算，包含log
    /// </summary>
    public static DamageResult ApplyDamage_Log(ExcelConfig.RoleBase roleBase, AttackStats attackStats)
    {
        // ------------------------- 减免后逻辑
        GD.Print("----------减免后逻辑");
        var damageConfig = ExcelConfig.DamageConfig_Map[attackStats.Type.ToString()];
        float resist;
        if (damageConfig.MinReduce > damageConfig.MaxReduce)
        {
            resist = Mathf.Clamp(roleBase.GetDamageResist(attackStats.Type), damageConfig.MaxReduce, damageConfig.MinReduce);
        }
        else
        {
            resist = Mathf.Clamp(roleBase.GetDamageResist(attackStats.Type), damageConfig.MinReduce, damageConfig.MaxReduce);
        }
        
        GD.Print($"减免伤害：{resist * 100}%");

        var damage = attackStats.BaseDamage * (1 - resist);
        GD.Print($"真实伤害：{damage}");
        
        // ------------------------- 护盾逻辑
        GD.Print("----------护盾逻辑");
        
        var shieldMultiplier = damageConfig.ShieldMultiplier;
        GD.Print($"护盾倍率：{shieldMultiplier}");
        
        var shieldDamage = damage * shieldMultiplier;
        GD.Print($"伤害修正：{shieldDamage}");
        
        var shieldOverflow = (shieldDamage - roleBase.Shield) / shieldMultiplier;
        GD.Print($"护盾溢出：{shieldOverflow}");

        // ------------------------- 暴击逻辑
        GD.Print("----------暴击逻辑");
        
        var criticalHitRate = attackStats.CritRate - roleBase.CritResist;
        GD.Print($"真暴击率：{criticalHitRate * 100}%");
        
        var criticalHit = shieldOverflow * (1 + attackStats.CritBonus);
        GD.Print($"暴击伤害：{criticalHit}");

        var armorMultiplier = damageConfig.ArmorMultiplier;
        var healthMultiplier = damageConfig.HealthMultiplier;

        float armorDamage;
        float armorOverflow;
        float healthDamage;
        
        // 未溢出伤害的情况下不能触发暴击，不同的伤害类型也有可能不能触发暴击
        var isCrit = shieldOverflow > 0 && damageConfig.Critable && Utils.Random.RandomBoolean(criticalHitRate);
        if (isCrit)
        {
            GD.Print("触发暴击！");
            GD.Print($"装甲倍率：{armorMultiplier}");

            armorDamage = criticalHit * (1 - attackStats.CritArmorPenetration) * armorMultiplier;
            GD.Print($"伤害修正（暴击）：{armorDamage}");

            armorOverflow = Mathf.Max(0, (armorDamage - roleBase.Armor) / armorMultiplier);
            GD.Print($"装甲溢出：{armorOverflow}");
            
            GD.Print($"生命倍率：{healthMultiplier}");

            healthDamage = (criticalHit * attackStats.CritArmorPenetration + armorOverflow) * healthMultiplier;
            GD.Print($"伤害修正：{healthDamage}");
            
            return new DamageResult
            {
                ShieldDamage = shieldDamage,
                ArmorDamage = Mathf.Max(armorDamage, 0),
                HealthDamage = Mathf.Max(healthDamage, 0)
            };
        }
        GD.Print("未触发暴击。");
        GD.Print($"装甲倍率：{armorMultiplier}");
        
        armorDamage = shieldOverflow * armorMultiplier;
        GD.Print($"伤害修正（非暴击）：{armorDamage}");
        
        armorOverflow = Mathf.Max(0, (armorDamage - roleBase.Armor) / armorMultiplier);
        GD.Print($"装甲溢出：{armorOverflow}");
        
        GD.Print($"生命倍率：{healthMultiplier}");
        
        healthDamage = armorOverflow * healthMultiplier;
        GD.Print($"伤害修正：{healthDamage}");
        
        return new DamageResult
        {
            ShieldDamage = shieldDamage,
            ArmorDamage = Mathf.Max(armorDamage, 0),
            HealthDamage = Mathf.Max(healthDamage, 0)
        };
    }
}