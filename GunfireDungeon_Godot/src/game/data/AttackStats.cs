
/// <summary>
/// 攻击属性，用于参与伤害计算的数据
/// </summary>
public class AttackStats
{
    public AttackStats()
    {
    }
    
    public AttackStats(int baseDamage, DamageType type)
    {
        BaseDamage = baseDamage;
        Type = type;
    }
    
    public AttackStats(int baseDamage, DamageType type, float critRate, float critBonus, float critArmorPenetration)
    {
        BaseDamage = baseDamage;
        Type = type;
        CritRate = critRate;
        CritBonus = critBonus;
        CritArmorPenetration = critArmorPenetration;
    }

    /// <summary>
    /// 基础伤害
    /// </summary>
    public int BaseDamage;
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
