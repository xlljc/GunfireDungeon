
using System.Collections.Generic;

/// <summary>
/// 武器零件列表
/// </summary>
public class PartList
{
    /// <summary>
    /// 列表长度
    /// </summary>
    public int Length => _logicBlocks.Length;
    
    /// <summary>
    /// 所属武器
    /// </summary>
    public Weapon Weapon { get; }

    private readonly PartBase[] _logicBlocks;
    private bool _dirty = true;
    
    public PartList(int maxLen, Weapon weapon)
    {
        _logicBlocks = new PartBase[maxLen];
        Weapon = weapon;
    }

    /// <summary>
    /// 为指定索引设置零件
    /// </summary>
    public PartBase SetLogicBlock(int index, PartBase part)
    {
        if (index >= 0 && index < _logicBlocks.Length)
        {
            part.PartList = this;
            part.Weapon = Weapon;
            part.Index = index;
            
            var prev = _logicBlocks[index];
            if (prev != null)
            {
                part.Index = -1;
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
    public PartBase GetLogicBlock(int index)
    {
        if (index >= 0 && index < _logicBlocks.Length)
        {
            return _logicBlocks[index];
        }

        return null;
    }

    /// <summary>
    /// 移除指定位置零件
    /// </summary>
    public PartBase RemoveLogicBlock(int index)
    {
        if (index >= 0 && index < _logicBlocks.Length)
        {
            var logicBlock = _logicBlocks[index];
            logicBlock.Index = -1;
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
    public PartBase GetFirstLogicBlock()
    {
        PartBase temp = null;
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
    
    public PlanningResult Execute(float fireRotation)
    {
        if (_dirty)
        {
            _dirty = false;
            RefreshLogicTree();
        }
        
        var result = new PlanningResult();
        var first = GetFirstLogicBlock();
        if (first != null)
        {
            first.Execute(fireRotation, result);
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
                logic.Children = new PartBase[logic.Occupancy];
                logic.Parent = null;
            }
        }

        var logicBlock = GetFirstLogicBlock();
        if (logicBlock != null)
        {
            EachTree(logicBlock);
        }
    }

    private int EachTree(PartBase part)
    {
        if (part.Occupancy <= 0)
        {
            return 0;
        }

        var v = 0;
        for (var i = 1; i <= part.Occupancy; i++)
        {
            var next = GetLogicBlock(part.Index + i + v);
            if (next != null)
            {
                v += EachTree(next);
                next.Parent = part;
                part.Children[i - 1] = next;
            }
        }

        return part.Occupancy;
    }
}