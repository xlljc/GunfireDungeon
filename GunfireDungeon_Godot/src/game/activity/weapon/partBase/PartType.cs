
/// <summary>
/// 零件类型
/// </summary>
public enum PartType
{
    /// <summary>
    /// 弹丸零件
    /// </summary>
    Bullet,

    /// <summary>
    /// 弹丸增益效果零件
    /// </summary>
    Buff,

    /// <summary>
    /// 被动效果零件
    /// </summary>
    Passive,
}

public static class PartTypeName
{
    public static string ToText(this PartType type)
    {
        switch (type)
        {
            case PartType.Bullet:
                return "弹丸";
            case PartType.Buff:
                return "增益";
            case PartType.Passive:
                return "被动";
            default:
                return "<未知>";
        }
    }
    
    public static string ToRichText(this PartType type)
    {
        switch (type)
        {
            case PartType.Bullet:
                return "[color=#9fc366]弹丸[/color]";
            case PartType.Buff:
                return "[color=#7bc1d5]增益[/color]";
            case PartType.Passive:
                return "[color=#d57bb9]被动[/color]";
            default:
                return "<未知>";
        }
    }
}