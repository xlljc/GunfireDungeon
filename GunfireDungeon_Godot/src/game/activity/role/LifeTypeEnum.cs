
/// <summary>
/// 判断角色以生命值、护盾值、装甲值的其中一种作为存活判定。（玩家角色默认为生命值。不同的敌人有不同的配置）
/// </summary>
public enum LifeTypeEnum
{
    /// <summary>
    /// 生命值
    /// </summary>
    Hp,

    /// <summary>
    /// 护盾值
    /// </summary>
    Shield,

    /// <summary>
    /// 装甲值
    /// </summary>
    Armor,
}