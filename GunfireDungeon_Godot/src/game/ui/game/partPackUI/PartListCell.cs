using System;
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
        _partGrid.SetColumns(15);
        _partGrid.SetCellOffset(CellNode.UiPanel.CellOffset);
        _partGrid.GridContainer.Resized += OnResized;
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
        var i = 0;
        foreach (PartProp o in list)
        {
            if (i++>=1)
            {
                break;
            }
            temp.Add(o);
        }
    
        _partGrid.SetDataList(temp);
    }
    
    private void OnResized()
    {
        var rect = Data.WeaponListCell.CellNode.Instance;
        var minimumSize = rect.CustomMinimumSize;
        minimumSize.X = CellNode.UiPanel.WeaponCellPartPosition.X + _partGrid.GridContainer.Size.X + CellNode.UiPanel.CellOffset.X * 2;
        minimumSize.X = Math.Max(minimumSize.X, CellNode.UiPanel.WeaponCellOriginSize.X);
        rect.CustomMinimumSize = minimumSize;

        var cellSize = new Vector2(minimumSize.X, _partGrid.GridContainer.Size.Y + 6f * GameApplication.Instance.PixelScale);
        CellNode.Instance.CustomMinimumSize = cellSize;
        CellNode.Instance.Size = cellSize;
    }
    
}