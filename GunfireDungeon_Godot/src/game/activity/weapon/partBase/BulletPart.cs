
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
    
    public override IBullet[] Execute(PlanningParam param)
    {
        if (!UseMana(GetMana()))
        {
            param.Error = PlanningParam.ErrorType.NoMana;
            return null;
        }
        Debug.Log($"射击子弹({Index}), fireRotation:{param.FireRotation}");
        if (Bullet != null)
        {
            if (!param.HasValue(PlanningParam.FirstBullet))
            {
                param.Error = PlanningParam.ErrorType.None;
                param.SetValue(PlanningParam.FirstBullet, Bullet);
            }

            Vector2 firePos;
            if (param.HasValue(PlanningParam.PrevBullet))
            {
                firePos = param.GetValue<IBullet>(PlanningParam.PrevBullet).GetEndPosition();
            }
            else
            {
                firePos = Weapon.FirePoint.GlobalPosition;
            }
            var bullet = ShootBullet(param.FireRotation, firePos, Bullet);
            return new [] {bullet};
        }
        
        return null;
    }

    public IBullet ShootBullet(float fireRotation, Vector2 position, ExcelConfig.BulletBase bullet)
    {
        fireRotation += Mathf.DegToRad(Utils.Random.RandomRangeFloat(-ScatteringAngle, ScatteringAngle));
        if (Weapon.Master != null && !Weapon.Master.IsDestroyed)
        {
            var calcBullet = Weapon.Master.RoleState.CalcBullet(bullet);
            var bInst = FireManager.ShootBullet(Weapon, position, fireRotation, calcBullet);
            Weapon.Master.ShootBulletHandler(Weapon, fireRotation, bInst);
            return bInst;
        }
        else if (Weapon.TriggerRole != null && !Weapon.TriggerRole.IsDestroyed)
        {
            var calcBullet = Weapon.TriggerRole.RoleState.CalcBullet(bullet);
            var bInst = FireManager.ShootBullet(Weapon, position, fireRotation, calcBullet);
            Weapon.TriggerRole.ShootBulletHandler(Weapon, fireRotation, bInst);
            return bInst;
        }
        else
        {
            var bInst = FireManager.ShootBullet(Weapon, position, fireRotation, bullet);
            Weapon.Master?.ShootBulletHandler(Weapon, fireRotation, bInst);
            return bInst;
        }
    }
}