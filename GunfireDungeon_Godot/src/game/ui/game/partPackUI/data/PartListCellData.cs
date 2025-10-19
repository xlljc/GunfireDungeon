
namespace UI.game.PartPackUI;

public class PartListCellData
{
    // 列表名称
    public string ListName;
    // 部件列表
    public PartList PartList;
    // 武器列表单元格
    public WeaponListCell WeaponListCell;
    
    public PartListCellData(string listName, PartList partList, WeaponListCell weaponListCell)
    {
        ListName = listName;
        PartList = partList;
        WeaponListCell = weaponListCell;
    }
}