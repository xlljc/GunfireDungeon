
/// <summary>
/// 子弹增益零件
/// </summary>
public abstract class BuffPart : PartBase
{
    /// <summary>
    /// 零件消耗法力值
    /// </summary>
    public int UseMana { get; set; }
    
    public BuffPart() : base(PartType.Buff)
    {
    }

    public override int GetMana()
    {
        return UseMana;
    }
}