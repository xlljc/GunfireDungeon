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

    public void Hurt(ActivityObject target, List<AttackStats> damages, List<AbnormalData> abnormals, float angle)
    {
        if (damages != null)
        {
            foreach (var item in damages)
            {
                var attackStats = new AttackStats();
                Master.CallDeferred(nameof(Master.HurtHandlerByDeferred), target, new GodotRefValue<AttackStats>(attackStats), angle);
            }
        }
       
        if (abnormals != null)
        {
            foreach (var item in abnormals)
            {
                Master.CallDeferred(nameof(Master.AbnormalStateHandler), (int)item.Type, item.Value);
            }
        }
    }
}