
/// <summary>
/// 伤害计算结果
/// </summary>
public class DamageCalcResult
{
    /// <summary>
    /// 是否触发了暴击
    /// </summary>
    public bool IsCritical;
    
    /// <summary>
    /// 护盾伤害
    /// </summary>
    public int ShieldDamage;
    
    /// <summary>
    /// 装甲伤害
    /// </summary>
    public int ArmorDamage;
    
    /// <summary>
    /// 生命伤害
    /// </summary>
    public int HealthDamage;

    /// <summary>
    /// 扣除的护盾伤害，这个伤害值不会超过当前护盾值
    /// </summary>
    public int SubShieldDamage;
    
    /// <summary>
    /// 扣除的装甲伤害，这个伤害值不会超过当前装甲值
    /// </summary>
    public int SubArmorDamage;
    
    /// <summary>
    /// 扣除的生命伤害，这个伤害值不会超过当前生命值
    /// </summary>
    public int SubHealthDamage;
    
    /// <summary>
    /// 总伤害
    /// </summary>
    public int TotalDamage => SubShieldDamage + SubArmorDamage + SubHealthDamage;
}