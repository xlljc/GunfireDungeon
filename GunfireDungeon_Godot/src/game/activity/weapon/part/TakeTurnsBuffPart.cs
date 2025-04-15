
/// <summary>
/// 轮流执行 A、B、C
/// </summary>
public class TakeTurnsBuffPart : BuffPart
{
    private int index = 0;

    public override IBullet[] Execute(float fireRotation, PlanningResult result)
    {
        if (!UseMana(GetMana()))
        {
            return null;
        }
        if (index >= Children.Length)
        {
            index = 0;
        }

        var child = Children[index++];
        if (child != null)
        {
            return child.Execute(fireRotation, result);
        }
        
        return null;
    }
}