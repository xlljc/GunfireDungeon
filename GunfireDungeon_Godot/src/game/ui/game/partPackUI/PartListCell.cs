using System;
using System.Collections.Generic;
using DsUi;
using Godot;

namespace UI.game.PartPackUI;

/// <summary>
/// 武器中可编辑零件列表Cell
/// </summary>
public class PartListCell : UiCell<PartPackUI.PartListItem, PartListCellData>
{
    public UiGrid<PartPackUI.PartPackItem, PartPropCellData> PartGrid;

    public override void OnInit()
    {
        PartGrid = CellNode.UiPanel.CreateUiGrid<PartPackUI.PartPackItem, PartPropCellData, PartPackCell>(
            CellNode.UiPanel.S_PartPackItem, CellNode.Instance, CellNode.UiPanel.WeaponCellPartPosition);
        PartGrid.SetColumns(15);
        PartGrid.SetCellOffset(CellNode.UiPanel.CellOffset);
        PartGrid.GridContainer.Resized += OnResized;
    }

    public override void Process(float delta)
    {
        if (Data != null)
        {
            //检测零件是否变化
            var count = Data.PartList.Length;
            if (count != PartGrid.Count) //长度变化
            {
                RefreshPartPack(Data.PartList);
            }
            else //内容变化
            {
                for (var i = 0; i < count; i++)
                {
                    var temp = PartGrid.GetData(i);
                    if (temp != null && Data.PartList.GetLogicBlock(i) != temp.OriginPartProp)
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
        var temp = new List<PartPropCellData>();
        var i = 0;
        foreach (var o in list)
        {
            temp.Add(new PartPropCellData(new PartPropSlot(i++, list), (PartProp)o));
        }

        PartGrid.SetDataList(temp);
    }

    private void OnResized()
    {
        var rect = Data.WeaponListCell.CellNode.Instance;
        var minimumSize = rect.CustomMinimumSize;
        minimumSize.X = CellNode.UiPanel.WeaponCellPartPosition.X + PartGrid.GridContainer.Size.X +
                        CellNode.UiPanel.CellOffset.X * 2;
        minimumSize.X = Math.Max(minimumSize.X, CellNode.UiPanel.WeaponCellOriginSize.X);
        rect.CustomMinimumSize = minimumSize;

        var cellSize = new Vector2(minimumSize.X,
            PartGrid.GridContainer.Size.Y + 6f * GameApplication.Instance.PixelScale);
        CellNode.Instance.CustomMinimumSize = cellSize;
        CellNode.Instance.Size = cellSize;
    }

    // private void OnPutPart(object obj)
    // {
    //     if (Data == null)
    //     {
    //         return;
    //     }
    //
    //     var param = (DropPartData)obj;
    //     Data.PartList.SetLogicBlock(param.Index, param.Data);
    // }
    //
    // private void OnDropPart(object obj)
    // {
    //     if (Data == null)
    //     {
    //         return;
    //     }
    //
    //     Data.PartList.RemoveLogicBlock((int)obj);
    // }
}