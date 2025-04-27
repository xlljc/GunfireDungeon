
using Godot;

/// <summary>
/// 可与 Godot 底层传递数值的引用值数据类
/// </summary>
public partial class GodotRefValue<T> : GodotObject
{
    public T Value;

    public GodotRefValue(T value)
    {
        Value = value;
    }
}