
using Config;

/// <summary>
/// 轮流执行 A、B、C
/// </summary>
[Part("TakeTurnsBuff")]
public class TakeTurnsBuffPart : BuffPart
{
    private int _index = 0;

    public override void InitParam(ExcelConfig.PartBase config)
    {
        base.InitParam(config);
        Occupancy = 2;
    }

    public override IBullet[] Execute(PlanningParam param)
    {
        if (!param.UseManaBuff(Mana))
        {
            return null;
        }
        if (_index >= Children.Length)
        {
            _index = 0;
        }

        var child = Children[_index++];
        if (child != null)
        {
            return child.Execute(param);
        }
        
        return null;
    }
}