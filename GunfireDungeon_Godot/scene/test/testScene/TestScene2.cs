using Godot;
using System;
using Config;

public partial class TestScene2 : Node2D
{
    public override void _Ready()
    {
        Utils.InitRandom();
        ExcelConfig.Init();

        var roleBase = new ExcelConfig.RoleBase()
        {
            Shield = 60, // 护盾值
            Armor = 40, // 装甲值
            Hp = 100, // 生命值
            PhysicalResist = -0.25f, // 物理伤害减免率
            FireResist = 0.15f, // 火焰伤害减免率
            ElectricResist = 0.3f, // 电击伤害减免率
            ChemicalResist = 0.5f, // 化学伤害减免率
            OpticalResist = 0.75f, // 光学伤害减免率
            DarkMatterResist = 0f, // 暗物质伤害减免率
            ExplosiveResist = -0.35f, // 爆破伤害减免率
            CritResist = 0 // 抗暴率
        };
        var attack = new AttackStats
        {
            Type = DamageType.Fire, // 伤害类型
            BaseDamage = 150, // 基础伤害
            CritRate = 1f, // 暴击率
            CritBonus = 0.5f, // 暴击伤害修正
            CritArmorPenetration = 0.5f // 暴击穿透装甲比例
        };
        var damageResult = DamageCalculator.ApplyDamage(roleBase, attack);
        roleBase.Shield -= (int)damageResult.ShieldDamage;
        roleBase.Armor -= (int)damageResult.ArmorDamage;
        roleBase.Hp -= (int)damageResult.HealthDamage;
        
        GD.Print($"\n最终伤害 -> 护盾伤害:{damageResult.ShieldDamage} 装甲伤害:{damageResult.ArmorDamage} 生命伤害:{damageResult.HealthDamage}");
        GD.Print($"最终状态 -> 护盾:{roleBase.Shield} 装甲:{roleBase.Armor} 生命:{roleBase.Hp}");

        // var target = new CharacterStats
        // {
        //     Shield = 100, // 护盾值
        //     Armor = 20, // 装甲值
        //     Health = 100, // 生命值
        //     PhysicalDamageReduction = -0.25f, // 物理伤害减免率
        //     FireDamageReduction = 0.15f, // 火焰伤害减免率
        //     ElectricDamageReduction = 0.3f, // 电击伤害减免率
        //     ChemicalDamageReduction = 0.5f, // 化学伤害减免率
        //     OpticalDamageReduction = 0.75f, // 光学伤害减免率
        //     DarkMatterDamageReduction = 0f, // 暗物质伤害减免率
        //     ExplosiveDamageReduction = -0.35f, // 爆破伤害减免率
        //     CritResistRate = 0 // 抗暴率
        // };

        //
        // DamageCalculator.TestApplyDamage(target, attack);
        // GD.Print($"\n最终状态 -> 护盾:{target.Shield} 装甲:{target.Armor} 生命:{target.Health}");
    }
}
