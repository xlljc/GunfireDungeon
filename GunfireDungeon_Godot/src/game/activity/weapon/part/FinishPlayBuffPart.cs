
/// <summary>
/// 在 A 结束时释放 B
/// </summary>
public class FinishPlayBuffPart : BuffPart
{
    public override IBullet[] Execute(float fireRotation, PlanningResult result)
    {
        if (!UseMana(GetMana()))
        {
            result.Error = PlanningResult.ErrorType.NoMana;
            return null;
        }

        var child1 = Children[0];
        if (child1 != null)
        {
            var bulletArray = child1.Execute(fireRotation, result);
            var child2 = Children[1];
            if (child2 != null && bulletArray != null && bulletArray.Length > 0)
            {
                var bullet = bulletArray[0];
                // bullet.OnReclaimEvent += () =>
                // {
                //     child2.Execute(fireRotation, new PlanningResult());
                // };
            }
            
            return bulletArray;
        }
        
        return null;
    }
}