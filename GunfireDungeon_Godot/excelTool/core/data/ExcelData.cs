/// <summary>
/// Excel数据类
/// </summary>
public class ExcelData
{
    /// <summary>
    /// 表名
    /// </summary>
    public string TableName;
    /// <summary>
    /// 输出代码
    /// </summary>
    public string OutCode;
    /// <summary>
    /// 列名列表
    /// </summary>
    public List<string> ColumnNames = new List<string>();
    /// <summary>
    /// 列映射数据字典
    /// </summary>
    public Dictionary<string, MappingData> ColumnMappingData = new Dictionary<string, MappingData>();
    /// <summary>
    /// 列类型字典
    /// </summary>
    public Dictionary<string, Type> ColumnType = new Dictionary<string, Type>();
    /// <summary>
    /// 数据列表
    /// </summary>
    public List<Dictionary<string, object>> DataList = new List<Dictionary<string, object>>();
}