
public class ExcelData
{
    public string TableName;
    public string OutCode;
    public List<string> ColumnNames = new List<string>();
    public Dictionary<string, MappingData> ColumnMappingData = new Dictionary<string, MappingData>();
    public Dictionary<string, Type> ColumnType = new Dictionary<string, Type>();
    public List<Dictionary<string, object>> DataList = new List<Dictionary<string, object>>();
}