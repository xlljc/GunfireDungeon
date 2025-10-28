using System;
using Godot;
using Config;

// 根据配置表公式, 该类是自动生成的, 请不要手动编辑!
public partial class CommonFormula
{
    /// <summary>
    /// 测试公式
    /// </summary>
    public static float Test(float a, float b)
    {
        return a+b;
    }

    /// <summary>
    /// 测试公式
    /// </summary>
    public static float Test2(float a, int b)
    {
        return a+b;
    }

    /// <summary>
    /// 测试公式
    /// </summary>
    public static double Test3(float a, int b)
    {
        var c = a * a;
        var d = b * b;
        return c * d;
    }

}
