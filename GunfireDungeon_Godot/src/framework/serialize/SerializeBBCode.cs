

using System.Text.Json.Serialization;

/// <summary>
/// 可序列化的富文本值
/// </summary>
public class SerializeBBCode
{
    /// <summary>
    /// 富文本值
    /// </summary>
    [JsonInclude]
    public string Code { get; private set; }
}