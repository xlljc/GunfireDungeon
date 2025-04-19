using System.Collections.Generic;
using System.Linq;
using DsUi;
using Godot;

namespace UI.game.PartPackUI;

public class WeaponListCell : UiCell<PartPackUI.WeaponItem, Weapon>
{
    private UiGrid<PartPackUI.PartListItem, PartListCellData> _partListGrid;
    
    public override void OnInit()
    {
        _partListGrid = CellNode.UiPanel.CreateUiGrid<PartPackUI.PartListItem, PartListCellData, PartListCell>(CellNode.L_PartListItem);
        _partListGrid.SetColumns(1);
        _partListGrid.SetCellOffset(new Vector2I(0, 0));
        _partListGrid.GridContainer.Resized += OnPartListGridResized;
    }

    public override void OnSetData(Weapon data)
    {
        //图标
        CellNode.L_Control.L_WeaponIcon.Instance.Texture = data.GetDefaultTexture();

        var partLists = new List<PartListCellData>();
        foreach (var keyValuePair in data.PartListMap)
        {
            partLists.Add(new PartListCellData(keyValuePair.Key, keyValuePair.Value, this));
        }
        
        _partListGrid.SetDataList(partLists);
        RefreshBaseInfo();
    }

    public override void Process(float delta)
    {
        RefreshBaseInfo();
    }

    private void RefreshBaseInfo()
    {
        if (Data == null)
        {
            return;
        }
        //法力值：99/99
        CellNode.L_VBoxContainer.L_WeaponMana.Instance.Text = "法力值：" + Data.CurrMana + "/" + Data.Attribute.MaxMana;
        //缓冲区：99/99
        CellNode.L_VBoxContainer.L_WeaponBuffMana.Instance.Text = "缓冲区：" + Data.CurrBufferMana + "/" + Data.Attribute.MaxBufferMana;
    }

    private void OnPartListGridResized()
    {
        var minimumSize = CellNode.Instance.CustomMinimumSize;
        minimumSize.Y = CellNode.UiPanel.WeaponCellOriginHeight + _partListGrid.GridContainer.Size.Y;
        CellNode.Instance.CustomMinimumSize = minimumSize;
    }
}