
using Config;
using Godot;

/// <summary>
/// 子弹零件
/// </summary>
public class BulletPart : PartBase
{
    /// <summary>
    /// 逻辑块消耗法力值
    /// </summary>
    public int Mana { get; set; }
    
    /// <summary>
    /// 散射角度
    /// </summary>
    public float ScatteringAngle { get; set; } = 5;
    
    /// <summary>
    /// 发射的子弹
    /// </summary>
    public ExcelConfig.BulletBase Bullet { get; set; }

    public BulletPart() : base(PartType.Bullet)
    {
    }
    
    public override int GetMana()
    {
        return Mana;
    }
    
    public override IBullet[] Execute(float fireRotation, PlanningResult result)
    {
        if (!UseMana(GetMana()))
        {
            result.Error = PlanningResult.ErrorType.NoMana;
            return null;
        }
        Debug.Log($"射击子弹({Index}), fireRotation:{fireRotation}");
        if (Bullet != null)
        {
            if (!result.HasValue(PlanningResult.FirstBullet))
            {
                result.Error = PlanningResult.ErrorType.None;
                result.SetValue(PlanningResult.FirstBullet, Bullet);
            }
            var bullet = ShootBullet(fireRotation, Bullet);
            return new [] {bullet};
        }
        
        return null;
    }

    public IBullet ShootBullet(float fireRotation, ExcelConfig.BulletBase bullet)
    {
        fireRotation += Mathf.DegToRad(Utils.Random.RandomRangeFloat(-ScatteringAngle, ScatteringAngle));
        if (Weapon.Master != null && !Weapon.Master.IsDestroyed)
        {
            var calcBullet = Weapon.Master.RoleState.CalcBullet(bullet);
            var bInst = FireManager.ShootBullet(Weapon, fireRotation, calcBullet);
            Weapon.Master.ShootBulletHandler(Weapon, fireRotation, bInst);
            return bInst;
        }
        else if (Weapon.TriggerRole != null && !Weapon.TriggerRole.IsDestroyed)
        {
            var calcBullet = Weapon.TriggerRole.RoleState.CalcBullet(bullet);
            var bInst = FireManager.ShootBullet(Weapon, fireRotation, calcBullet);
            Weapon.TriggerRole.ShootBulletHandler(Weapon, fireRotation, bInst);
            return bInst;
        }
        else
        {
            var bInst = FireManager.ShootBullet(Weapon, fireRotation, bullet);
            Weapon.Master?.ShootBulletHandler(Weapon, fireRotation, bInst);
            return bInst;
        }
    }
}