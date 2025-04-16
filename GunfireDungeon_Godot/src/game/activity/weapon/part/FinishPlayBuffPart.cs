
/// <summary>
/// 在 A 结束时释放 B
/// </summary>
public class FinishPlayBuffPart : BuffPart
{
    public override IBullet[] Execute(PlanningParam param)
    {
        if (!UseMana(GetMana()))
        {
            param.Error = PlanningParam.ErrorType.NoMana;
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
                var planningParam = new PlanningParam(bullet.BulletData.Rotation);
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