
/// <summary>
/// 异常状态数据
/// </summary>
public class AbnormalData
{
    /// <summary>
    /// 异常状态类型
    /// </summary>
    public AbnormalStateType Type;
    
    /// <summary>
    /// 异常状态数值
    /// </summary>
    public int Value;

    public AbnormalData(AbnormalStateType type, int value)
    {
        Type = type;
        Value = value;
    }

    public AbnormalData()
    {
    }
}