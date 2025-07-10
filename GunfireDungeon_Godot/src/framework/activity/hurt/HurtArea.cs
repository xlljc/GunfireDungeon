using System.Collections.Generic;
using Godot;

/// <summary>
/// 可被子弹击中的区域
/// </summary>
public partial class HurtArea : Area2D, IHurt
{
    /// <summary>
    /// 所属角色
    /// </summary>
    public Role Master { get; private set; }

    public void InitRole(Role role)
    {
        Master = role;
    }

    public override void _Ready()
    {
        Monitoring = false;
    }

    public bool CanHurt(CampEnum targetCamp)
    {
        //无敌状态
        if (Master.Invincible)
        {
            return true;
        }
        
        return Master.IsEnemy(targetCamp);
    }

    public void Hurt(ActivityObject target, Dictionary<DamageType, int> damage, Dictionary<AbnormalStateType, int> abnormalState, float angle)
    {
        if (damage != null)
        {
            foreach (var item in damage)
            {
                Master.CallDeferred(nameof(Master.HurtHandler), target, item.Value, (int)item.Key, angle);
            }
        }
       
        if (abnormalState != null)
        {
            foreach (var item in abnormalState)
            {
                Master.CallDeferred(nameof(Master.AbnormalStateHandler), (int)item.Key, item.Value);
            }
        }
    }
}