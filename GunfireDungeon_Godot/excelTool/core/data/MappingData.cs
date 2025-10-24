

public class MappingData
{
    public string TypeStr;
    public string TypeName;
    public CollectionsType CollectionsType;
    public bool AutoParentheses = false;
        
    public bool IsRefExcel;
    public string RefTypeStr;
    public string RefTypeName;

    public MappingData(string typeStr, string typeName, CollectionsType collectionsType)
    {
        TypeStr = typeStr;
        TypeName = typeName;
        CollectionsType = collectionsType;
        IsRefExcel = false;
    }
        
    public MappingData(string typeStr, string typeName, CollectionsType collectionsType, string refTypeStr, string refTypeName)
    {
        TypeStr = typeStr;
        TypeName = typeName;
        CollectionsType = collectionsType;
        IsRefExcel = true;
        RefTypeStr = refTypeStr;
        RefTypeName = refTypeName;
    }
}