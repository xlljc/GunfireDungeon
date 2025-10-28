using DsUi;

namespace UI.game.PartPackUI;


public class PartPropCellData
{
    /// <summary>
    /// 零件槽位
    /// </summary>
    public PartPropSlot Slot;

    /// <summary>
    /// 原始的零件数据
    /// </summary>
    public PartProp OriginPartProp;
    
    public PartPropCellData(PartPropSlot slot, PartProp originPartProp)
    {
        Slot = slot;
        OriginPartProp = originPartProp;
    }
}