
using Config;

/// <summary>
/// 随机释放 A、B
/// </summary>
[Part("RandomPlayBuff")]
public class RandomPlayBuffPart : BuffPart
{
    public override void InitParam(ExcelConfig.PartBase config)
    {
        base.InitParam(config);
        Occupancy = 2;
    }
    
    public override IBullet[] Execute(PlanningParam param)
    {
        if (!param.UseManaBuff(Mana))
        {
            //没有足够的法力值
            param.SufficientMana = false;
            param.SetValue(PlanningParam.NoManaIndex, Index);
            return null;
        }

        var child = Utils.Random.RandomChoose(Children);
        if (child != null)
        {
            return child.Execute(param);
        }
        
        return null;
    }
}