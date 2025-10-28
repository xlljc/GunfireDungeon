
using Aspose.Cells;

/// <summary>
/// 自定义格式化数据接口
/// </summary>
public interface ICustomFormat
{
    /// <summary>
    /// 执行格式化操作，返回格式化数据后的对象
    /// </summary>
    object DoFormat(string str, Cell cell);
}