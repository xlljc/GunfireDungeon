
/// <summary>
/// 已经规划完成的零件，该类数据是一个链表结构
/// </summary>
public class PlanningPartItem
{
    /// <summary>
    /// 绑定的零件对象
    /// </summary>
    public PartBase Part { get; }
    
    /// <summary>
    /// 下一个零件
    /// </summary>
    public PlanningPartItem Next { get; set; }
    
    /// <summary>
    /// 上一个零件
    /// </summary>
    public PlanningPartItem Prev { get; set; }

    public PlanningPartItem(PartBase blockBase)
    {
        Part = blockBase;
    }

    /// <summary>
    /// 计算法力值消耗
    /// </summary>
    public int CalcMana()
    {
        return Part.GetMana() + (Next != null ? Next.CalcMana() : 0);
    }

    /// <summary>
    /// 执行法术, 返回执行结果 //如果因为法力值不够导致的部分法术执行失败，则返回导致失败的法术索引
    /// </summary>
    public PlanningResult Execute(float fireRotation)
    {
        var hasBullet = false;
        var result = Execute(0, fireRotation, ref hasBullet);
        if (result == null)
        {
            if (!hasBullet) //没有子弹零件
            {
                return new PlanningResult()
                {
                    Error = PlanningResult.ErrorType.NoBullet,
                };
            }
            
            return new PlanningResult()
            {
                Error = PlanningResult.ErrorType.None,
            };
        }
        return result;
    }

    private PlanningResult Execute(int index, float fireRotation, ref bool hasBullet)
    {
        if (Part.PartType == PartType.Bullet)
        {
            hasBullet = true;
        }
        
        var mana = Part.GetMana();
        if (mana > 0 && !Part.Weapon.UseManaBuff(mana))
        {
            return new PlanningResult()
            {
                Error = PlanningResult.ErrorType.NoMana,
                Data = index,
            };
        }

        Part.Execute(fireRotation);

        if (Next != null)
        {
            return Next.Execute(index + 1, fireRotation, ref hasBullet);
        }

        return null;
    }
}