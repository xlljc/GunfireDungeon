
using System.Collections.Generic;

/// <summary>
/// 合并执行逻辑
/// </summary>
public class MergePlayBuffPart : BuffPart
{
    
    public MergePlayBuffPart(PartProp prop) : base(prop)
    {
    }
    
    public override IBullet[] Execute(PlanningParam param)
    {
        if (!param.UseManaBuff(Mana))
        {
            return null;
        }

        var bulletList = new List<IBullet>();
        foreach (var part in Children)
        {
            if (part == null)
            {
                continue;
            }

            var bullets = part.Execute(param);
            if (bullets != null && bullets.Length > 0)
            {
                bulletList.AddRange(bullets);
            }
        }
        
        if (bulletList.Count > 0)
        {
            return bulletList.ToArray();
        }
        
        return null;
    }
}