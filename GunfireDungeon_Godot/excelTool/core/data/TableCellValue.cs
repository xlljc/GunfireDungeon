using Aspose.Cells;

/// <summary>
/// 表格单元格值类
/// </summary>
public class TableCellValue
{
    /// <summary>
    /// 行号
    /// </summary>
    public int Row;
    /// <summary>
    /// 列号
    /// </summary>
    public int Column;
    /// <summary>
    /// 文本
    /// </summary>
    public string Text;
    /// <summary>
    /// 单元格
    /// </summary>
    public Cell Cell;
    /// <summary>
    /// Excel数据
    /// </summary>
    public ExcelData ExcelData;
    /// <summary>
    /// 行字典
    /// </summary>
    public Dictionary<string, object> RowDictionary;
}