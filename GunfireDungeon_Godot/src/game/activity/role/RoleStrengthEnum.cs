
/// <summary>
/// 角色强度，
/// 作为非玩家角色，标识该敌人或NPC是 普通、稀有、精英等，不同类型的敌人生命血条会有特殊表现。其强度也不相同。暂定未军衔
/// </summary>
public enum RoleStrengthEnum
{
    /// <summary>
    /// 普通
    /// </summary>
    Normal,

    /// <summary>
    /// 稀有
    /// </summary>
    Rare,

    /// <summary>
    /// 精英
    /// </summary>
    Elite,

    /// <summary>
    /// 头目
    /// </summary>
    Boss,
}