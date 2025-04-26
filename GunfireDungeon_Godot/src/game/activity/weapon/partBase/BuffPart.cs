
/// <summary>
/// 子弹增益零件
/// </summary>
public abstract class BuffPart : PartLogicBase
{
    /// <summary>
    /// 零件消耗法力值
    /// </summary>
    public int Mana { get; set; }
    
    public BuffPart(PartProp prop) : base(prop, PartType.Buff)
    {
    }

    public override int GetMana()
    {
        return Mana;
    }
}