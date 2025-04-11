
using System.Collections.Generic;

/// <summary>
/// 武器逻辑块列表
/// </summary>
public class LogicBlockList
{
    /// <summary>
    /// 列表长度
    /// </summary>
    public int Length => _logicBlocks.Length;
    
    /// <summary>
    /// 所属武器
    /// </summary>
    public Weapon Weapon { get; }

    private readonly LogicBlockBase[] _logicBlocks;
    private bool _dirty = true;
    
    public LogicBlockList(int maxLen, Weapon weapon)
    {
        _logicBlocks = new LogicBlockBase[maxLen];
        Weapon = weapon;
    }

    /// <summary>
    /// 为指定索引设置逻辑块
    /// </summary>
    public LogicBlockBase SetLogicBlock(int index, LogicBlockBase logicBlock)
    {
        if (index >= 0 && index < _logicBlocks.Length)
        {
            logicBlock.LogicBlockList = this;
            logicBlock.Weapon = Weapon;
            logicBlock.Index = index;
            
            var prev = _logicBlocks[index];
            if (prev != null)
            {
                logicBlock.Index = -1;
                logicBlock.Weapon = null;
            }
            _logicBlocks[index] = logicBlock;
            _dirty = true;
            return logicBlock;
        }

        return null;
    }

    /// <summary>
    /// 获取指定位置逻辑块
    /// </summary>
    public LogicBlockBase GetLogicBlock(int index)
    {
        if (index >= 0 && index < _logicBlocks.Length)
        {
            return _logicBlocks[index];
        }

        return null;
    }

    /// <summary>
    /// 移除指定位置逻辑块
    /// </summary>
    public LogicBlockBase RemoveLogicBlock(int index)
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
    /// 获取第一个逻辑块
    /// </summary>
    public LogicBlockBase GetFirstLogicBlock()
    {
        LogicBlockBase temp = null;
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
    
    /// <summary>
    /// 规划下一次执行的逻辑块，并组装成一个链表，然后调用该链表的 Execute() 方法执行整个逻辑块
    /// </summary>
    public PlanningLogicItem Planning()
    {
        if (_dirty)
        {
            _dirty = false;
            RefreshLogicTree();
        }
        
        var temp = GetFirstLogicBlock();

        if (temp != null)
        {
            var start = new PlanningLogicItem(temp);
            PlanningEach(start);
            return start;
        }

        return null;
    }

    private void PlanningEach(PlanningLogicItem root)
    {
        var next = root.LogicBlock.PlanningNext(root.LogicBlock.Children);
        if (next == null || next.Length == 0)
        {
            return;
        }

        var temp = root;
        foreach (var block in next)
        {
            if (block == null)
            {
                continue;
            }
            var tempNext = new PlanningLogicItem(block);
            temp.Next = tempNext;
            tempNext.Prev = temp;
            temp = tempNext;
            PlanningEach(tempNext);
        }
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
                logic.Children = new LogicBlockBase[logic.Occupancy];
            }
        }

        var logicBlock = GetFirstLogicBlock();
        if (logicBlock != null)
        {
            EachTree(logicBlock);
        }
    }

    private int EachTree(LogicBlockBase logicBlock)
    {
        if (logicBlock.Occupancy <= 0)
        {
            return 0;
        }

        var v = 0;
        for (var i = 1; i <= logicBlock.Occupancy; i++)
        {
            var next = GetLogicBlock(logicBlock.Index + i + v);
            if (next != null)
            {
                v += EachTree(next);
                logicBlock.Children[i - 1] = next;
            }
        }

        return logicBlock.Occupancy;
    }
}