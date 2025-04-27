namespace UI.game.PartPackUI;

public class PartListCellData
{
    public string ListName;
    public PartList PartList;
    public WeaponListCell WeaponListCell;
    
    public PartListCellData(string listName, PartList partList, WeaponListCell weaponListCell)
    {
        ListName = listName;
        PartList = partList;
        WeaponListCell = weaponListCell;
    }
}