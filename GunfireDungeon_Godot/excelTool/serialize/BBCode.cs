

using System.Text.Json.Serialization;
using Aspose.Cells;

/// <summary>
/// 富文本类型
/// </summary>
public class BBCode : ICustomFormat
{
    [JsonInclude]
    public string Code { get; private set; }

    public object DoFormat(string str, Cell cell)
    {
        var htmlString = cell.GetHtmlString(false);
        var result = "";

        // 使用正则表达式匹配所有Font标签及其内容
        var fontMatches = System.Text.RegularExpressions.Regex.Matches(htmlString, @"<Font[^>]*>(.*?)</Font>");

        foreach (System.Text.RegularExpressions.Match match in fontMatches)
        {
            string style = match.Value;
            string text = match.Groups[1].Value;

            // 提取样式属性
            var styleMatch = System.Text.RegularExpressions.Regex.Match(style, @"Style=""([^""]*)""");
            if (!styleMatch.Success) continue;

            string styleValue = styleMatch.Groups[1].Value;
            var styleParts = styleValue.Split(';');

            // 解析样式
            bool isBold = false;
            bool isItalic = false;
            bool isUnderline = false;
            bool isStrikeThrough = false;
            string color = "#000000";
            string fontSize = "11pt";

            foreach (var part in styleParts)
            {
                if (string.IsNullOrWhiteSpace(part)) continue;

                var kv = part.Split(':');
                if (kv.Length != 2) continue;

                string key = kv[0].Trim().ToUpper();
                string value = kv[1].Trim();

                switch (key)
                {
                    case "FONT-WEIGHT":
                        isBold = value.Equals("bold", StringComparison.OrdinalIgnoreCase);
                        break;
                    case "FONT-STYLE":
                        isItalic = value.Equals("italic", StringComparison.OrdinalIgnoreCase);
                        break;
                    case "TEXT-DECORATION":
                        if (value.Contains("underline")) isUnderline = true;
                        if (value.Contains("line-through")) isStrikeThrough = true;
                        break;
                    case "COLOR":
                        color = value;
                        break;
                    case "FONT-SIZE":
                        fontSize = value;
                        break;
                }
            }

            // 构建标记文本
            string formattedText = text;

            // 处理颜色
            if (color != "#000000")
            {
                formattedText = $"[color={color}]{formattedText}[/color]";
            }

            // 处理字体大小
            if (fontSize != "11pt")
            {
                string size = fontSize.Replace("pt", "");
                formattedText = $"[font_size={size}]{formattedText}[/font_size]";
            }

            // 处理文本样式
            if (isBold) formattedText = $"[b]{formattedText}[/b]";
            if (isItalic) formattedText = $"[i]{formattedText}[/i]";
            if (isUnderline) formattedText = $"[u]{formattedText}[/u]";
            if (isStrikeThrough) formattedText = $"[s]{formattedText}[/s]";

            result += formattedText;
        }

        // 处理换行标签
        result = result.Replace("<Br>", "\n");

        Code = result;
        return this;
    }
}