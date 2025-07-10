
using Config;

/// <summary>
/// 子弹增益零件
/// </summary>
public abstract class BuffPart : PartLogicBase
{
    /// <summary>
    /// 零件消耗法力值
    /// </summary>
    public int Mana { get; set; }

    public override void InitParam(ExcelConfig.PartBase config)
    {
        Mana = config.BaseMana;
    }

    public override int GetMana()
    {
        return Mana;
    }
}