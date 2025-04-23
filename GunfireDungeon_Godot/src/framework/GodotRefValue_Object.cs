
/// <summary>
/// 可与 Godot 底层传递数值的引用值数据类
/// </summary>
public partial class GodotRefValue : GodotRefValue<object>
{
    public GodotRefValue(object value) : base(value)
    {
    }
}