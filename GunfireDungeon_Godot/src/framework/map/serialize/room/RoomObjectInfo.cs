
using System.Text.Json.Serialization;
using Config;
using DsUi;

/// <summary>
/// 房间中的自定义物体
/// </summary>
public class RoomObjectInfo : IClone<RoomObjectInfo>
{
    /// <summary>
    /// 对应 <see cref="Config.ExcelConfig.EditorObject"/> 表中的 id
    /// </summary>
    [JsonInclude]
    public string Id;

    /// <summary>
    /// X 坐标, 单位: 像素
    /// </summary>
    [JsonInclude]
    public int X;
    
    /// <summary>
    /// Y 坐标: 单位: 像素
    /// </summary>
    [JsonInclude]
    public int Y;

    public RoomObjectInfo Clone()
    {
        return new RoomObjectInfo
        {
            Id = Id,
            X = X,
            Y = Y,
        };
    }

    /// <summary>
    /// 获取 EditorObject 配置表数据
    /// </summary>
    public ExcelConfig.EditorObject GetConfig()
    {
        if (ExcelConfig.EditorObject_Map.TryGetValue(Id, out var config))
        {
            return config;
        }
        
        return null;
    }
}