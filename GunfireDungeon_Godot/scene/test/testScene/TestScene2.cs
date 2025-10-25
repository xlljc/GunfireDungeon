using Godot;
using System;
using Test;
using DType = Test.DamageType;

public partial class TestScene2 : Node2D
{
    public override void _Ready()
    {
        var target = new CharacterStats
        {
            Shield = 100, // 护盾值
            Armor = 100, // 装甲值
            Health = 100, // 生命值
            PhysicalDamageReduction = 0.0f, // 物理伤害减免率
            FireDamageReduction = 0.06f, // 火焰伤害减免率
            ElectricDamageReduction = 0.12f, // 电击伤害减免率
            ChemicalDamageReduction = 0.09f, // 化学伤害减免率
            OpticalDamageReduction = 0.23f, // 光学伤害减免率
            DarkMatterDamageReduction = 0.27f, // 暗物质伤害减免率
            ExplosiveDamageReduction = 0.18f, // 爆破伤害减免率
            CritResistRate = 0.1f // 抗暴率
        };
        var attack = new AttackStats
        {
            Type = DType.Electric, // 伤害类型
            BaseDamage = 200, // 基础伤害
            CritRate = 0.6f, // 暴击率
            CritBonus = 0.25f, // 暴击伤害修正
            CritArmorPenetration = 0.25f // 暴击穿透装甲比例
        };

        DamageCalculator.ApplyDamage(target, attack);
        GD.Print($"\n最终状态 -> 护盾:{target.Shield} 装甲:{target.Armor} 生命:{target.Health}");
    }
}
