
using System.Text.Json;
using System.Text.Json.Serialization;
using Aspose.Cells;

/// <summary>
/// 可序列化的 Vector2 对象
/// </summary>
[CustomName("Vector2")]
public class SerializeVector2 : ICustomFormat
{
    public SerializeVector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public SerializeVector2(SerializeVector2 v)
    {
        X = v.X;
        Y = v.Y;
    }

    public SerializeVector2()
    {
        
    }

    [JsonInclude]
    public float X { get; private set; }
    [JsonInclude]
    public float Y  { get; private set; }
    
    public object DoFormat(string str, Cell cell)
    {
        if (string.IsNullOrEmpty(str))
        {
            return null;
        }

        if (str.StartsWith("{"))
        {
            var newObj = JsonSerializer.Deserialize<SerializeVector3>(str);
            X = newObj.X;
            Y = newObj.Y;
            return this;
        }

        var strings = str.Split(',');
        X = float.Parse(strings[0]);
        Y = float.Parse(strings[1]);
        
        return this;
    }
}