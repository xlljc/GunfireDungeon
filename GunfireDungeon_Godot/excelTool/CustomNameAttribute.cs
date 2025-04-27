
/// <summary>
/// 自定义名称
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