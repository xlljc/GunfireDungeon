

using System.Text.Json.Serialization;
using Aspose.Cells;

/// <summary>
/// 可序列化的 Color 对象
/// </summary>
[CustomName("Color")]
public class SerializeColor : ICustomFormat
{
    public SerializeColor(float r, float g, float b, float a)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

    public SerializeColor()
    {
    }
    
    [JsonInclude]
    public float R { get; private set; }
    [JsonInclude]
    public float G  { get; private set; }
    [JsonInclude]
    public float B  { get; private set; }
    [JsonInclude]
    public float A  { get; private set; }

    public object DoFormat(string str, Cell cell)
    {
        if (string.IsNullOrEmpty(str))
        {
            FromHtml(cell.GetHtmlString(false));
        }
        else
        {
            // 从十六进制颜色转为 RGBA
            FromHex(str);
        }

        return this;
    }

    private void FromHtml(string xml)
    {
        // 参数为值参考：<Font Style="FONT-FAMILY: 宋体;FONT-SIZE: 11pt;COLOR: #000000;VERTICAL-ALIGN: middle;Background-Color: #00b0f0;"></Font>
        // 解析这一段值，并提取出 Background-Color 然后调用 FromHex(string hexColor) 函数
        
        // 提取 Background-Color 属性值
        string bgColorHex = null;
        int bgColorIndex = xml.IndexOf("Background-Color:", StringComparison.OrdinalIgnoreCase);
    
        if (bgColorIndex >= 0)
        {
            int start = bgColorIndex + 17; // "Background-Color:".Length
            int end = xml.IndexOf(';', start);
        
            if (end == -1) end = xml.Length;
        
            bgColorHex = xml.Substring(start, end - start).Trim();
        }

        // 调用 FromHex 处理颜色值
        if (!string.IsNullOrEmpty(bgColorHex))
        {
            FromHex(bgColorHex);
        }
        
    }

    // 从十六进制转为 RGBA 颜色，参数有可能是 #ffffff 或者 #ffffffff 这样的，不区分大小写
    private void FromHex(string str)
    {
        // 检查输入是否有效
        if (string.IsNullOrEmpty(str) || !str.StartsWith("#"))
        {
            return; // 返回默认颜色
        }

        // 移除 # 号并统一转为小写
        string hex = str.Substring(1).ToLower();
    
        // 处理3位或4位简写形式（如 #RGB 或 #RGBA）
        if (hex.Length == 3 || hex.Length == 4)
        {
            hex = string.Concat(hex.Select(c => $"{c}{c}"));
        }

        // 根据长度解析颜色值
        if (hex.Length == 6) // RGB
        {
            R = Convert.ToByte(hex.Substring(0, 2), 16) / 255f;
            G = Convert.ToByte(hex.Substring(2, 2), 16) / 255f;
            B = Convert.ToByte(hex.Substring(4, 2), 16) / 255f;
            A = 1f;
        }
        else if (hex.Length == 8) // RGBA
        {
            R = Convert.ToByte(hex.Substring(6, 2), 16) / 255f;
            G = Convert.ToByte(hex.Substring(0, 2), 16) / 255f;
            B = Convert.ToByte(hex.Substring(2, 2), 16) / 255f;
            A = Convert.ToByte(hex.Substring(4, 2), 16) / 255f;
        }
    }
}