using Config;
using Godot;


public class DamageManager
{
    /// <summary>
    /// 伤害计算
    /// </summary>
    public static DamageCalcResult ApplyDamage(Role role, AttackStats attackStats)
    {
        // ------------------------- 减免后逻辑
        var roleBase = role.RoleState.RoleBase;
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
        var shieldOverflow = (shieldDamage - role.RealShield) / shieldMultiplier;

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
            armorOverflow = Mathf.Max(0, (armorDamage - role.Armor) / armorMultiplier);
            healthDamage = (criticalHit * attackStats.CritArmorPenetration + armorOverflow) * healthMultiplier;
            return new DamageCalcResult
            {
                IsCritical = true,
                ShieldDamage = (int)shieldDamage,
                ArmorDamage = Mathf.Max((int)armorDamage, 0),
                HealthDamage = Mathf.Max((int)healthDamage, 0),
                SubShieldDamage = Mathf.Min((int)shieldDamage, role.Shield),
                SubArmorDamage = Mathf.Min(Mathf.Max((int)armorDamage, 0), role.Armor),
                SubHealthDamage = Mathf.Min(Mathf.Max((int)healthDamage, 0), role.Hp)
            };
        }
        armorDamage = shieldOverflow * armorMultiplier;
        armorOverflow = Mathf.Max(0, (armorDamage - role.Armor) / armorMultiplier);
        healthDamage = armorOverflow * healthMultiplier;
        return new DamageCalcResult
        {
            IsCritical = false,
            ShieldDamage = (int)shieldDamage,
            ArmorDamage = Mathf.Max((int)armorDamage, 0),
            HealthDamage = Mathf.Max((int)healthDamage, 0),
            SubShieldDamage = Mathf.Min((int)shieldDamage, role.Shield),
            SubArmorDamage = Mathf.Min(Mathf.Max((int)armorDamage, 0), role.Armor),
            SubHealthDamage = Mathf.Min(Mathf.Max((int)healthDamage, 0), role.Hp)
        };
    }
    
    /// <summary>
    /// 伤害计算
    /// </summary>
    public static DamageCalcResult ApplyDamage(ExcelConfig.RoleBase roleBase, AttackStats attackStats)
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
            return new DamageCalcResult
            {
                IsCritical = true,
                ShieldDamage = (int)shieldDamage,
                ArmorDamage = Mathf.Max((int)armorDamage, 0),
                HealthDamage = Mathf.Max((int)healthDamage, 0),
                SubShieldDamage = Mathf.Min((int)shieldDamage, roleBase.Shield),
                SubArmorDamage = Mathf.Min(Mathf.Max((int)armorDamage, 0), roleBase.Armor),
                SubHealthDamage = Mathf.Min(Mathf.Max((int)healthDamage, 0), roleBase.Hp)
            };
        }
        armorDamage = shieldOverflow * armorMultiplier;
        armorOverflow = Mathf.Max(0, (armorDamage - roleBase.Armor) / armorMultiplier);
        healthDamage = armorOverflow * healthMultiplier;
        
        return new DamageCalcResult
        {
            IsCritical = false,
            ShieldDamage = (int)shieldDamage,
            ArmorDamage = Mathf.Max((int)armorDamage, 0),
            HealthDamage = Mathf.Max((int)healthDamage, 0),
            SubShieldDamage = Mathf.Min((int)shieldDamage, roleBase.Shield),
            SubArmorDamage = Mathf.Min(Mathf.Max((int)armorDamage, 0), roleBase.Armor),
            SubHealthDamage = Mathf.Min(Mathf.Max((int)healthDamage, 0), roleBase.Hp)
        };
    }
    
    /// <summary>
    /// 伤害计算，包含log
    /// </summary>
    public static DamageCalcResult ApplyDamage_Log(ExcelConfig.RoleBase roleBase, AttackStats attackStats)
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
            
            return new DamageCalcResult
            {
                IsCritical = true,
                ShieldDamage = (int)shieldDamage,
                ArmorDamage = Mathf.Max((int)armorDamage, 0),
                HealthDamage = Mathf.Max((int)healthDamage, 0),
                SubShieldDamage = Mathf.Min((int)shieldDamage, roleBase.Shield),
                SubArmorDamage = Mathf.Min(Mathf.Max((int)armorDamage, 0), roleBase.Armor),
                SubHealthDamage = Mathf.Min(Mathf.Max((int)healthDamage, 0), roleBase.Hp)
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
        
        return new DamageCalcResult
        {
            IsCritical = false,
            ShieldDamage = (int)shieldDamage,
            ArmorDamage = Mathf.Max((int)armorDamage, 0),
            HealthDamage = Mathf.Max((int)healthDamage, 0),
            SubShieldDamage = Mathf.Min((int)shieldDamage, roleBase.Shield),
            SubArmorDamage = Mathf.Min(Mathf.Max((int)armorDamage, 0), roleBase.Armor),
            SubHealthDamage = Mathf.Min(Mathf.Max((int)healthDamage, 0), roleBase.Hp)
        };
    }
}