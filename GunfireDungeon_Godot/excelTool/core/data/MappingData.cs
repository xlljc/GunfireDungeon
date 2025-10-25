/// <summary>
/// 映射数据类
/// </summary>
public class MappingData
{
    /// <summary>
    /// 类型字符串
    /// </summary>
    public string TypeStr;
    /// <summary>
    /// 类型名称
    /// </summary>
    public string TypeName;
    /// <summary>
    /// 集合类型
    /// </summary>
    public CollectionsType CollectionsType;
    /// <summary>
    /// 是否自动括号
    /// </summary>
    public bool AutoParentheses = false;
        
    /// <summary>
    /// 是否引用Excel
    /// </summary>
    public bool IsRefExcel;
    /// <summary>
    /// 引用类型字符串
    /// </summary>
    public string RefTypeStr;
    /// <summary>
    /// 引用类型名称
    /// </summary>
    public string RefTypeName;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="typeStr">类型字符串</param>
    /// <param name="typeName">类型名称</param>
    /// <param name="collectionsType">集合类型</param>
    public MappingData(string typeStr, string typeName, CollectionsType collectionsType)
    {
        TypeStr = typeStr;
        TypeName = typeName;
        CollectionsType = collectionsType;
        IsRefExcel = false;
    }
        
    /// <summary>
    /// 构造函数（带引用）
    /// </summary>
    /// <param name="typeStr">类型字符串</param>
    /// <param name="typeName">类型名称</param>
    /// <param name="collectionsType">集合类型</param>
    /// <param name="refTypeStr">引用类型字符串</param>
    /// <param name="refTypeName">引用类型名称</param>
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