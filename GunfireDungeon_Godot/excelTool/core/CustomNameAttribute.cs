
/// <summary>
/// 自定义名称，被标记的类必须实现 ICustomFormat 或者 ICustomMember 接口
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
public class CustomNameAttribute : Attribute
{
    public string Name { get; set; }
    
    public CustomNameAttribute(string name)
    {
        Name = name;
    }
}