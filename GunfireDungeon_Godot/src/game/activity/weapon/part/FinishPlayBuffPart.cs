
/// <summary>
/// 在 A 结束时释放 B
/// </summary>
public class FinishPlayBuffPart : BuffPart
{
    public int BehindMaxMana { get; set; }
    
    public override IBullet[] Execute(PlanningParam param)
    {
        if (!param.UseManaBuff(Mana))
        {
            //没有足够的法力值
            param.Error = PlanningParam.ErrorType.NoMana;
            param.SetValue(PlanningParam.NoManaIndex, Index);
            return null;
        }

        var child1 = Children[0];
        if (child1 != null)
        {
            // 执行第一个，获取子弹
            var bulletArray = child1.Execute(param);
            
            var child2 = Children[1];
            if (child2 != null && bulletArray != null && bulletArray.Length > 0)
            {
                var bullet = bulletArray[0];
                var currMana = new RefValue<int>(BehindMaxMana);

                var planningParam = new PlanningParam(bullet.BulletData.Rotation, (mana) =>
                {
                    if (mana > currMana.Value)
                    {
                        return false;
                    }
                    currMana.Value -= mana;
                    return true;
                });
                planningParam.SetValue(PlanningParam.PrevBullet, bullet);
                
                //结束后释放
                bullet.BindSingleLogicalFinishEvent(() =>
                {
                    child2.Execute(planningParam);
                });
            }
            
            return bulletArray;
        }
        
        return null;
    }
}