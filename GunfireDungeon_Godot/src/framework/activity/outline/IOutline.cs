
using Godot;

/// <summary>
/// 描边属性接口
/// </summary>
public interface IOutline
{
    /// <summary>
    /// 是否开启描边
    /// </summary>
    bool ShowOutline { get; set; }
    
    /// <summary>
    /// 描边颜色
    /// </summary>
    Color OutlineColor { get; set; }
}