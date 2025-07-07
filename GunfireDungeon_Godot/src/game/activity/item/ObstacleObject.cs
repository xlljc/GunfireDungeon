
using System.Collections.Generic;
using Godot;

/// <summary>
/// 障碍物, 会阻挡玩家移动, 也会被子弹击中
/// </summary>
public partial class ObstacleObject : ActivityObject, IHurt
{
    public virtual bool CanHurt(CampEnum targetCamp)
    {
        return true;
    }

    public virtual void Hurt(ActivityObject target, Dictionary<DamageType, int> damage, Dictionary<AbnormalStateType, int> abnormalState, float angle)
    {
    }
}
