
using System.Collections.Generic;

/// <summary>
/// 武器零件基类
/// </summary>
public abstract class PartLogicBase
{
    /// <summary>
    /// 零件类型
    /// </summary>
    public PartType PartType { get; }
    
    /// <summary>
    /// 占用后置零件数量，在调用 PlanningNext() 函数时，这个值就是 occupancy 参数的数组的长度
    /// </summary>
    public int Occupancy { get; set; }

    /// <summary>
    /// 所属武器，没有装备到武器上时该值为 null
    /// </summary>
    public Weapon Weapon => PartProp?.Weapon;
    
    /// <summary>
    /// 所属零件对象
    /// </summary>
    public PartProp PartProp { get; }

    /// <summary>
    /// 零件在武器逻辑槽中的索引，如果为 -1 则代表零件未加入到逻辑槽中
    /// </summary>
    public int Index { get; set; } = -1;

    /// <summary>
    /// 所属逻辑槽
    /// </summary>
    public PartList PartList { get; set; }
    
    /// <summary>
    /// 父零件，这个是由 PartList 控制的
    /// </summary>
    public PartLogicBase Parent { get; set; }
    
    /// <summary>
    /// 子零件列表，这个是由 PartList 控制的，长度与 Occupancy 一致
    /// </summary>
    public PartLogicBase[] Children { get; set; }

    public PartLogicBase(PartProp prop, PartType partType)
    {
        PartProp = prop;
        PartType = partType;
    }

    /// <summary>
    /// 执行零件，返回这一步产生的子弹对象，允许返回null
    /// </summary>
    /// <param name="param">执行逻辑树将会返回的数据，可以在上面绑定数据</param>
    public virtual IBullet[] Execute(PlanningParam param)
    {
        return null;
    }

    /// <summary>
    /// 获取法力值消耗
    /// </summary>
    public virtual int GetMana()
    {
        return 0;
    }
    
    public override string ToString()
    {
        return $"({GetType().Name}: Type: {PartType}, Occupancy: {Occupancy})";
    }

    public string GetTreeString()
    {
        var count = 0;
        return GetTreeString("", ref count);
    }
    
    private string GetTreeString(string s, ref int count)
    {
        var str = s + Index + "." + ToString();
        count += 1;
        str += "\n";
        for (var i = 0; i < Children.Length; i++)
        {
            var child = Children[i];
            if (child != null)
            {
                str += child.GetTreeString(s + "\t", ref count);
            }
            else
            {
                str += s + "\t" + (count) + ".(null)\n";
                count += 1;
            }
        }
        return str;
    }
}