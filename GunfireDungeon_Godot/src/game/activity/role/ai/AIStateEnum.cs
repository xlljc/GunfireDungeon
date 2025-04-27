
public enum AIStateEnum
{
    /// <summary>
    /// Ai 状态, 正常
    /// </summary>
    AiNormal,
    /// <summary>
    /// 发现目标, 目标不在视野内, 但是知道位置
    /// </summary>
    AiTailAfter,
    /// <summary>
    /// 目标在视野内, 跟进目标, 如果距离在子弹有效射程内, 则开火
    /// </summary>
    AiFollowUp,
    /// <summary>
    /// 距离足够近, 在目标附近随机移动
    /// </summary>
    AiSurround,
    /// <summary>
    /// Ai 寻找弹药
    /// </summary>
    AiFindAmmo,
    /// <summary>
    /// Ai攻击
    /// </summary>
    AiAttack,
}