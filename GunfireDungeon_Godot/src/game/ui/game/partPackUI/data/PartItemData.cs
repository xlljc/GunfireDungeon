namespace UI.game.PartPackUI;

public class PartItemData
{
    public PartProp PartProp;
    
    private PartPackage _partPackage;
    private PartList _partList;
    
    public PartItemData(PartProp partProp, PartPackage partPackage)
    {
        PartProp = partProp;
        _partPackage = partPackage;
    }
    
    public PartItemData(PartProp partProp, PartList partList)
    {
        PartProp = partProp;
        _partList = partList;
    }
    
    public void DoPut(int index, PartProp partProp)
    {
        PartProp = partProp;
        if (_partPackage != null)
        {
            _partPackage.Set(index, partProp);
        }
        else if (_partList != null)
        {
            _partList.SetLogicBlock(index, partProp);
        }
    }
    
    public void DoRemove(int index)
    {
        PartProp = null;
        if (_partPackage != null)
        {
            var t = _partPackage.Remove(index);
        }
        else if (_partList != null)
        {
            var t2 = _partList.RemoveLogicBlock(index);
        }
    }
}