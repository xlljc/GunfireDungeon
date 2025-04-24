
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 武器零件列表
/// </summary>
public class PartList : IEnumerable
{
    /// <summary>
    /// 列表长度
    /// </summary>
    public int Length => _logicBlocks.Length;

    /// <summary>
    /// 所属武器
    /// </summary>
    public Weapon Weapon { get; }

    private readonly PartProp[] _logicBlocks;
    private bool _dirty = true;

    public PartList(int maxLen, Weapon weapon)
    {
        _logicBlocks = new PartProp[maxLen];
        Weapon = weapon;
    }

    /// <summary>
    /// 为指定索引设置零件，并返回原位置零件
    /// </summary>
    public PartProp SetLogicBlock(int index, PartProp part)
    {
        if (part == null)
        {
            return null;
        }
        if (index >= 0 && index < _logicBlocks.Length)
        {
            part.PartBase.PartList = this;
            part.Weapon = Weapon;
            part.PartBase.Index = index;

            var prev = _logicBlocks[index];
            if (prev != null)
            {
                part.PartBase.Index = -1;
                part.Weapon = null;
            }

            _logicBlocks[index] = part;
            _dirty = true;
            return part;
        }

        return null;
    }

    /// <summary>
    /// 获取指定位置零件
    /// </summary>
    public PartProp GetLogicBlock(int index)
    {
        if (index >= 0 && index < _logicBlocks.Length)
        {
            return _logicBlocks[index];
        }

        return null;
    }

    /// <summary>
    /// 移除指定位置零件并返回
    /// </summary>
    public PartProp RemoveLogicBlock(int index)
    {
        if (index >= 0 && index < _logicBlocks.Length)
        {
            var logicBlock = _logicBlocks[index];
            if (logicBlock == null)
            {
                return null;
            }
            logicBlock.PartBase.Index = -1;
            logicBlock.Weapon = null;
            _logicBlocks[index] = null;
            _dirty = true;
            return logicBlock;
        }

        return null;
    }

    /// <summary>
    /// 获取第一个零件
    /// </summary>
    public PartProp GetFirstLogicBlock()
    {
        PartProp temp = null;
        for (var i = 0; i < _logicBlocks.Length; i++)
        {
            temp = _logicBlocks[i];
            if (temp != null)
            {
                break;
            }
        }

        return temp;
    }

    public PlanningParam Execute(float fireRotation)
    {
        if (_dirty)
        {
            _dirty = false;
            RefreshLogicTree();
        }

        var result = new PlanningParam(fireRotation, Weapon.UseBufferMana);
        var first = GetFirstLogicBlock();
        if (first != null)
        {
            first.PartBase.Execute(result);
        }

        return result;
    }

    /// <summary>
    /// 刷新逻辑树
    /// </summary>
    public void RefreshLogicTree()
    {
        foreach (var logic in _logicBlocks)
        {
            if (logic != null)
            {
                logic.PartBase.Children = new PartBase[logic.PartBase.Occupancy];
                logic.PartBase.Parent = null;
            }
        }

        var logicBlock = GetFirstLogicBlock();
        if (logicBlock != null)
        {
            EachTree(logicBlock);
        }

        var block = GetFirstLogicBlock();
        if (block != null && block.PartBase != null)
        {
            Debug.Log("刷新零件逻辑树：\n" + block.PartBase.GetTreeString());
        }
    }

    private int EachTree(PartProp part)
    {
        if (part.PartBase.Occupancy <= 0)
        {
            return 0;
        }

        var v = 0;
        for (var i = 1; i <= part.PartBase.Occupancy; i++)
        {
            var next = GetLogicBlock(part.PartBase.Index + i + v);
            if (next != null)
            {
                v += EachTree(next);
                next.PartBase.Parent = part.PartBase;
                part.PartBase.Children[i - 1] = next.PartBase;
            }
        }

        return part.PartBase.Occupancy;
    }

    public IEnumerator GetEnumerator()
    {
        return _logicBlocks.GetEnumerator();
    }
}