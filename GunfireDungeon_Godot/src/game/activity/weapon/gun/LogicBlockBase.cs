
using System.Collections.Generic;

/// <summary>
/// 武器逻辑块基类
/// </summary>
public abstract class LogicBlockBase
{
    /// <summary>
    /// 逻辑块消耗法力值
    /// </summary>
    public int UseMana { get; set; }
    
    /// <summary>
    /// 占用后置逻辑块数量，在调用 PlanningNext() 函数时，这个值就是 occupancy 参数的数组的长度
    /// </summary>
    public int Occupancy { get; set; }

    /// <summary>
    /// 所属武器，没有装备到武器上时该值为 null
    /// </summary>
    public Weapon Weapon { get; set; }

    /// <summary>
    /// 逻辑块在武器逻辑槽中的索引，如果为 -1 则代表逻辑块未加入到逻辑槽中
    /// </summary>
    public int Index { get; set; } = -1;

    /// <summary>
    /// 所属逻辑槽
    /// </summary>
    public LogicBlockList LogicBlockList { get; set; }
    
    /// <summary>
    /// 子逻辑块列表，这个是由 LogicBlockList 控制的
    /// </summary>
    public LogicBlockBase[] Children { get; set; }

    /// <summary>
    /// 执行逻辑块
    /// </summary>
    /// <param name="fireRotation">开火时武器角度</param>
    public abstract void Execute(float fireRotation);

    /// <summary>
    /// 获取下一个与该逻辑块绑定运行的逻辑块，如果没有则返回 null
    /// <param name="occupancy">后置逻辑块对象数组</param>
    /// </summary>
    public virtual LogicBlockBase[] PlanningNext(LogicBlockBase[] occupancy)
    {
        return occupancy;
    }

    public override string ToString()
    {
        return $"({GetType().Name}: UseMana: {UseMana}, Occupancy: {Occupancy})";
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