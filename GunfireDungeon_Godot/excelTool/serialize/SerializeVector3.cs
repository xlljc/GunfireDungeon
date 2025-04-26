using System.Text.Json;
using System.Text.Json.Serialization;
using Aspose.Cells;

/// <summary>
/// 可序列化的 Vector3 对象
/// </summary>
[CustomName("Vector3")]
public class SerializeVector3 : ICustomFormat
{
    public SerializeVector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public SerializeVector3(SerializeVector3 v)
    {
        X = v.X;
        Y = v.Y;
    }
    
    public SerializeVector3()
    {
    }
    
    [JsonInclude]
    public float X { get; private set; }
    [JsonInclude]
    public float Y  { get; private set; }
    [JsonInclude]
    public float Z  { get; private set; }

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
            Z = newObj.Z;
            return this;
        }

        var strings = str.Split(',');
        X = float.Parse(strings[0]);
        Y = float.Parse(strings[1]);
        Z = float.Parse(strings[2]);
        
        return this;
    }
}