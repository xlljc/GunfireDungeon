/// <summary>
/// 零件道具槽位类，用于管理零件道具的存储和操作。
/// </summary>
public class PartPropSlot
{
    /// <summary>
    /// 获取槽位的索引。
    /// </summary>
    public int Index { get; }
    
    private PartPackage _partPackage;
    private PartList _partList;
    
    /// <summary>
    /// 使用零件包初始化槽位。
    /// </summary>
    /// <param name="index">槽位索引。</param>
    /// <param name="partPackage">零件包。</param>
    public PartPropSlot(int index, PartPackage partPackage)
    {
        Index = index;
        _partPackage = partPackage;
    }
    
    /// <summary>
    /// 使用零件列表初始化槽位。
    /// </summary>
    /// <param name="index">槽位索引。</param>
    /// <param name="partList">零件列表。</param>
    public PartPropSlot(int index, PartList partList)
    {
        Index = index;
        _partList = partList;
    }
    
    /// <summary>
    /// 获取当前槽位中的零件道具。
    /// </summary>
    /// <returns>零件道具，如果不存在则返回null。</returns>
    public PartProp Get()
    {
        if (_partPackage != null)
        {
            return _partPackage.Get(Index);
        }
        else if (_partList != null)
        {
            return _partList.GetLogicBlock(Index);
        }

        return null;
    }
    
    /// <summary>
    /// 设置当前槽位中的零件道具。
    /// </summary>
    /// <param name="partProp">要设置的零件道具。</param>
    public void Set(PartProp partProp)
    {
        if (_partPackage != null)
        {
            _partPackage.Set(Index, partProp);
        }
        else if (_partList != null)
        {
            _partList.SetLogicBlock(Index, partProp);
        }
    }
    
    /// <summary>
    /// 从当前槽位中移除零件道具。
    /// </summary>
    public void Remove()
    {
        if (_partPackage != null)
        {
            _partPackage.Remove(Index);
        }
        else if (_partList != null)
        {
            _partList.RemoveLogicBlock(Index);
        }
    }
    
    /// <summary>
    /// 比较两个槽位是否相等。
    /// </summary>
    /// <param name="other">要比较的另一个槽位。</param>
    /// <returns>如果相等则返回true，否则返回false。</returns>
    public bool Equals(PartPropSlot other)
    {
        if (other == null)
        {
            return false;
        }
        
        return Index == other.Index && (_partPackage == other._partPackage || _partList == other._partList);
    }
}