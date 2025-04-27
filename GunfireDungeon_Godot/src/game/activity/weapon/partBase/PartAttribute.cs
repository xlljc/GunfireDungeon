
using System;

/// <summary>
/// 注册零件处理类
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class PartAttribute : Attribute
{
    /// <summary>
    /// 零件类型
    /// </summary>
    public string Name { get; }
    
    public PartAttribute(string name)
    {
        Name = name;
    }
}