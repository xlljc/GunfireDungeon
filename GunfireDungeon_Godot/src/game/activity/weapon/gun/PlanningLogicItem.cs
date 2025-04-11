
/// <summary>
/// 已经规划完成的逻辑块，该类数据是一个链表结构
/// </summary>
public class PlanningLogicItem
{
    /// <summary>
    /// 绑定的逻辑块对象
    /// </summary>
    public LogicBlockBase LogicBlock { get; }
    
    /// <summary>
    /// 下一个逻辑块
    /// </summary>
    public PlanningLogicItem Next { get; set; }
    
    /// <summary>
    /// 上一个逻辑块
    /// </summary>
    public PlanningLogicItem Prev { get; set; }

    public PlanningLogicItem(LogicBlockBase blockBase)
    {
        LogicBlock = blockBase;
    }

    /// <summary>
    /// 计算法力值消耗
    /// </summary>
    public float CalcMana()
    {
        return LogicBlock.UseMana + (Next != null ? Next.CalcMana() : 0);
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
        if (!LogicBlock.Weapon.UseManaBuff(LogicBlock.UseMana))
        {
            return index;
        }

        LogicBlock.Execute(fireRotation);
        
        if (Next != null)
        {
            return Next.Execute(index + 1, fireRotation);
        }

        return -1;
    }
}