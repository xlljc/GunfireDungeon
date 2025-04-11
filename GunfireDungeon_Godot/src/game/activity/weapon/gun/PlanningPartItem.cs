
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
        return GetMana() + (Next != null ? Next.CalcMana() : 0);
    }

    /// <summary>
    /// 获取法力值消耗
    /// </summary>
    public int GetMana()
    {
        if (Part is BuffPart buffPart)
        {
            return buffPart.UseMana;
        }
        else if (Part is BulletPart bulletPart)
        {
            return bulletPart.UseMana;
        }

        return 0;
    }

    /// <summary>
    /// 执行法术, 如果成功，则返回 -1，如果因为法力值不够导致的部分法术执行失败，则返回导致失败的法术索引
    /// </summary>
    public int Execute(float fireRotation)
    {
        return Execute(0, fireRotation);
    }

    private int Execute(int index, float fireRotation)
    {
        var mana = GetMana();
        if (mana > 0 && !Part.Weapon.UseManaBuff(mana))
        {
            return index;
        }

        Part.Execute(fireRotation);
        
        if (Next != null)
        {
            return Next.Execute(index + 1, fireRotation);
        }

        return -1;
    }
}