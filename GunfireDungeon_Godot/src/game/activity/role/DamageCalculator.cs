using System;
using Config;
using Godot;

// public class CharacterStats
// {
//     public float Shield; // 护盾
//     public float Armor; // 装甲
//     public float Health; // 生命
//
//     public float PhysicalDamageReduction; // 物理伤害减免率
//     public float FireDamageReduction; // 火焰伤害减免率
//     public float ElectricDamageReduction; // 电击伤害减免率
//     public float ChemicalDamageReduction; // 化学伤害减免率
//     public float OpticalDamageReduction; // 光学伤害减免率
//     public float DarkMatterDamageReduction; // 暗物质伤害减免率
//     public float ExplosiveDamageReduction; // 爆破伤害减免率
//
//     public float CritResistRate;  // 抗暴率
//
//     public bool IsDead => Health <= 0;
// }

public class AttackStats
{
    public float BaseDamage; // 基础伤害
    public DamageType Type; // 伤害类型
    public float CritRate;            // 暴击率
    public float CritBonus;           // 暴击伤害修正（例如0.25表示+25%）
    public float CritArmorPenetration; // 暴击穿透装甲比例（例如0.25）
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
        
        var isCrit = Utils.Random.RandomBoolean(criticalHitRate);
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
    

    // private static Random _rand = new Random();
    // public static void TestApplyDamage(CharacterStats target, AttackStats attack)
    // {
    //     if (target.IsDead)
    //     {
    //         GD.Print("目标已死亡。");
    //         return;
    //     }
    //
    //     GD.Print($"\n=== 原始数据 ===");
    //     GD.Print($"基础伤害: {attack.BaseDamage}, 类型: {attack.Type}");
    //     GD.Print($"目标初始状态 -> 护盾: {target.Shield}, 装甲: {target.Armor}, 生命: {target.Health}");
    //     GD.Print($"目标减免 -> 物理: {target.PhysicalDamageReduction}, 火焰: {target.FireDamageReduction}, 电击: {target.ElectricDamageReduction}, 化学: {target.ChemicalDamageReduction}, 光学: {target.OpticalDamageReduction}, 暗物质: {target.DarkMatterDamageReduction}, 爆破: {target.ExplosiveDamageReduction}, 抗暴率: {target.CritResistRate * 100}%");
    //     GD.Print($"攻击属性 -> 暴击率: {attack.CritRate * 100}%, 暴击伤害修正: {attack.CritBonus}, 暴击穿透: {attack.CritArmorPenetration}");
    //
    //     GD.Print($"\n=== 开始计算伤害 ===");
    //     
    //     float[] mult = {
    //         DamageMatrix[(int)attack.Type, 0],
    //         DamageMatrix[(int)attack.Type, 1],
    //         DamageMatrix[(int)attack.Type, 2]
    //     };
    //     GD.Print($"伤害倍率 [护盾: {mult[0]}, 装甲: {mult[1]}, 生命: {mult[2]}]");
    //
    //     // 计算减免后伤害
    //     float reduction = attack.Type switch {
    //         DamageType.Physical => target.PhysicalDamageReduction,
    //         DamageType.Fire => target.FireDamageReduction,
    //         DamageType.Electric => target.ElectricDamageReduction,
    //         DamageType.Chemical => target.ChemicalDamageReduction,
    //         DamageType.Optical => target.OpticalDamageReduction,
    //         DamageType.DarkMatter => target.DarkMatterDamageReduction,
    //         DamageType.Explosive => target.ExplosiveDamageReduction,
    //         _ => 0f
    //     };
    //     float originalReduction = reduction;
    //     reduction = Mathf.Clamp(reduction, DefaultMinReduction, DefaultMaxReduction);
    //     if (Math.Abs(originalReduction - reduction) > 0.001f)
    //     {
    //         GD.Print($"减免率限制: {originalReduction} -> {reduction} (上限: {DefaultMaxReduction}, 下限: {DefaultMinReduction})");
    //     }
    //     GD.Print($"\n参数: 基础伤害 = {attack.BaseDamage}, 减免率 = {reduction}");
    //     float reducedDamage = attack.BaseDamage * (1 - reduction);
    //     GD.Print($"减免后伤害【float】 = 基础伤害 * (1 - 减免率) = {reducedDamage:F2}");
    //
    //     // 护盾阶段
    //     GD.Print($"\n参数: 减免后伤害 = {reducedDamage:F2}, 护盾倍率 = {mult[0]}");
    //     float shieldDamage = reducedDamage * mult[0];
    //     GD.Print($"护盾伤害【float】 = 减免后伤害 * 护盾倍率 = {shieldDamage:F2}");
    //     float shieldOverflow = 0;
    //
    //     if (target.Shield > 0)
    //     {
    //         if (target.Shield >= shieldDamage)
    //         {
    //             target.Shield -= shieldDamage;
    //             GD.Print($"护盾吸收 {shieldDamage:F0} 伤害，剩余护盾 {target.Shield:F0}");
    //             return;
    //         }
    //         else
    //         {
    //             GD.Print($"\n参数: 护盾伤害 = {shieldDamage:F2}, 当前护盾 = {target.Shield}, 护盾倍率 = {mult[0]}");
    //             shieldOverflow = (shieldDamage - target.Shield) / mult[0];
    //             GD.Print($"护盾溢出伤害【float】 = (护盾伤害 - 当前护盾) / 护盾倍率 = {shieldOverflow:F2}");
    //             GD.Print($"护盾破裂，吸收 {target.Shield:F0}，溢出伤害 {shieldOverflow:F2}");
    //             target.Shield = 0;
    //         }
    //     }
    //
    //     // 是否暴击
    //     float critChance = (attack.CritRate - target.CritResistRate) * 100;
    //     bool isCrit = _rand.NextDouble() * 100 < critChance;
    //     GD.Print($"暴击判断公式: 随机数 < (({attack.CritRate} - {target.CritResistRate}) * 100) = {critChance:F2}%");
    //     if (isCrit) GD.Print("🔥 触发暴击!");
    //
    //     // 装甲阶段
    //     float armorDamageBase = isCrit
    //         ? shieldOverflow * (1 + attack.CritBonus)
    //         : shieldOverflow;
    //     if (isCrit)
    //     {
    //         GD.Print($"\n参数: 护盾溢出伤害 = {shieldOverflow:F2}, 暴击伤害修正 = {attack.CritBonus}");
    //         GD.Print($"装甲基础伤害【float】 = 护盾溢出伤害 * (1 + 暴击伤害修正) = {armorDamageBase:F2} (暴击时)");
    //     }
    //     else
    //     {
    //         GD.Print($"\n参数: 护盾溢出伤害 = {shieldOverflow:F2}");
    //         GD.Print($"装甲基础伤害【float】 = 护盾溢出伤害 = {armorDamageBase:F2} (非暴击)");
    //     }
    //
    //     GD.Print($"\n参数: 装甲基础伤害 = {armorDamageBase:F2}, 装甲倍率 = {mult[1]}");
    //     float armorDamage = armorDamageBase * mult[1];
    //     GD.Print($"装甲伤害【float】 = 装甲基础伤害 * 装甲倍率 = {armorDamage:F2}");
    //     float armorOverflow = 0;
    //
    //     if (target.Armor > 0)
    //     {
    //         float armorPenetrateRatio = isCrit ? attack.CritArmorPenetration : 0f;
    //         GD.Print($"装甲穿透比例: {armorPenetrateRatio:F2}");
    //         GD.Print($"\n参数: 装甲伤害 = {armorDamage:F2}, 装甲穿透比例 = {armorPenetrateRatio}");
    //         float armorAbsorb = armorDamage * (1 - armorPenetrateRatio);
    //         float healthPenetrate = armorDamage * armorPenetrateRatio;
    //         GD.Print($"装甲吸收【float】 = 装甲伤害 * (1 - 装甲穿透比例) = {armorAbsorb:F2}");
    //         GD.Print($"穿透伤害【float】 = 装甲伤害 * 装甲穿透比例 = {healthPenetrate:F2}");
    //
    //         if (target.Armor >= armorAbsorb)
    //         {
    //             target.Armor -= armorAbsorb;
    //             GD.Print($"装甲吸收 {armorAbsorb:F0} 伤害，剩余装甲 {target.Armor:F0}");
    //             GD.Print($"\n参数: 穿透伤害 = {healthPenetrate:F2}, 生命倍率 = {mult[2]}");
    //             float healthPenetrateFinal = healthPenetrate * mult[2];
    //             target.Health -= (int)healthPenetrateFinal;
    //             GD.Print($"穿透伤害最终【float】 = 穿透伤害 * 生命倍率 = {healthPenetrateFinal:F2}，作用于生命值");
    //             return;
    //         }
    //         else
    //         {
    //             GD.Print($"\n参数: 装甲吸收 = {armorAbsorb:F2}, 当前装甲 = {target.Armor}, 装甲倍率 = {mult[1]}");
    //             armorOverflow = (armorAbsorb - target.Armor) / mult[1];
    //             GD.Print($"装甲溢出伤害【float】 = (装甲吸收 - 当前装甲) / 装甲倍率 = {armorOverflow:F2}");
    //             GD.Print($"装甲破裂，吸收 {target.Armor:F0}，溢出伤害 {armorOverflow:F2}");
    //             target.Armor = 0;
    //         }
    //     }
    //     else
    //     {
    //         armorOverflow = armorDamageBase;
    //         GD.Print($"无装甲，溢出伤害: {armorOverflow:F2}");
    //     }
    //
    //     // 生命阶段
    //     GD.Print($"\n参数: 装甲溢出伤害 = {armorOverflow:F2}, 生命倍率 = {mult[2]}");
    //     float healthDamage = armorOverflow * mult[2];
    //     GD.Print($"生命伤害【float】 = 装甲溢出伤害 * 生命倍率 = {healthDamage:F2}");
    //     target.Health -= (int)healthDamage;
    //
    //     GD.Print($"生命承受 {healthDamage:F0} 伤害，剩余生命 {target.Health:F0}");
    //
    //     if (target.Health <= 0)
    //     {
    //         target.Health = 0;
    //         GD.Print("💀 目标死亡！");
    //     }
    // }
}