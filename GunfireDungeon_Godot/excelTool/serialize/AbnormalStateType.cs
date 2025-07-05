
/// <summary>
/// 异常状态类型
/// - **燃烧**：每秒扣除（3%最大生命值+5）的生命值，持续10秒
/// - **中毒**：累计中毒可以叠加层数，每层每秒受到（2%最大生命值+2）的生命值，每层持续8秒
/// </summary>
public enum AbnormalStateType
{
    /// <summary>
    /// 燃烧
    /// </summary>
    Burning,
    /// <summary>
    /// 中毒
    /// </summary>
    Poisoning
}