
using System.Collections.Generic;

/// <summary>
/// 可以受到伤害的接口
/// </summary>
public interface IHurt
{
    /// <summary>
    /// 返回是否可以造成伤害
    /// </summary>
    /// <param name="targetCamp">攻击目标所属层级</param>
    bool CanHurt(CampEnum targetCamp);

    /// <summary>
    /// 受到伤害
    /// </summary>
    /// <param name="target">触发伤害的对象, 为 null 表示不存在对象或者对象已经被销毁</param>
    /// <param name="damages">伤害数据，可以是多段伤害数据，可以为 null</param>
    /// <param name="abnormals">累计的异常状态数据，可以为 null</param>
    /// <param name="angle">伤害角度（弧度制）</param>
    void Hurt(ActivityObject target, List<AttackStats> damages, List<AbnormalData> abnormals, float angle);
}