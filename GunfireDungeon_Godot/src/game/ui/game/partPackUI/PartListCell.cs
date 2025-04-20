using System.Collections.Generic;
using DsUi;
using Godot;

namespace UI.game.PartPackUI;

public class PartListCell : UiCell<PartPackUI.PartListItem, PartListCellData>
{

    private UiGrid<PartPackUI.PartPackItem, PartProp> _partGrid;
    
    public override void OnInit()
    {
        _partGrid = CellNode.UiPanel.CreateUiGrid<PartPackUI.PartPackItem, PartProp, PartPackCell>(
            CellNode.UiPanel.S_PartPackItem, CellNode.Instance, CellNode.UiPanel.WeaponCellPartPosition);
        _partGrid.SetAutoColumns(true);
        _partGrid.SetHorizontalExpand(true);
        _partGrid.SetCellOffset(new Vector2I(8, 8));
    }

    public override void Process(float delta)
    {
        if (Data != null)
        {
            //检测零件是否变化
            var count = Data.PartList.Length;
            if (count != _partGrid.Count) //长度变化
            {
                RefreshPartPack(Data.PartList);
            }
            else //内容变化
            {
                for (int i = 0; i < count; i++)
                {
                    if (Data.PartList.GetLogicBlock(i) != _partGrid.GetData(i))
                    {
                        RefreshPartPack(Data.PartList);
                        break;
                    }
                }
            }
        }
    }
    
    public void RefreshPartPack(PartList list)
    {
        var temp = new List<PartProp>();
        foreach (PartProp o in list)
        {
            temp.Add(o);
        }
    
        _partGrid.SetDataList(temp);
    }
    
}