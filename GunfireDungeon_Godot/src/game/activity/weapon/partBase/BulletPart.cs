
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
        if (!param.UseManaBuff(Mana))
        {
            param.Error = PlanningParam.ErrorType.NoMana;
            param.SetValue(PlanningParam.NoManaIndex, Index);
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

            Vector2 firePos; // 开火位置
            float altitude; //子弹高度
            if (param.HasValue(PlanningParam.PrevBullet))
            {
                var bulletInst = param.GetValue<IBullet>(PlanningParam.PrevBullet);
                firePos = bulletInst.GetEndPosition();
                altitude = bulletInst.Altitude;
            }
            else
            {
                firePos = Weapon.FirePoint.GlobalPosition;
                if (Weapon.TriggerRole != null && !Weapon.TriggerRole.IsDestroyed)
                {
                    altitude = Weapon.TriggerRole.GetFirePointAltitude();
                }
                else
                {
                    altitude = 1;
                }
            }
            
            var bullet = ShootBullet(firePos, altitude, param.FireRotation, Bullet);
            return new [] {bullet};
        }
        
        return null;
    }

    public IBullet ShootBullet(Vector2 position, float altitude, float fireRotation, ExcelConfig.BulletBase bullet)
    {
        fireRotation += Mathf.DegToRad(Utils.Random.RandomRangeFloat(-ScatteringAngle, ScatteringAngle));
        if (Weapon.Master != null && !Weapon.Master.IsDestroyed)
        {
            var calcBullet = Weapon.Master.RoleState.CalcBullet(bullet);
            var bInst = FireManager.ShootBullet(Weapon, position, altitude, fireRotation, calcBullet);
            Weapon.Master.ShootBulletHandler(Weapon, fireRotation, bInst);
            return bInst;
        }
        else if (Weapon.TriggerRole != null && !Weapon.TriggerRole.IsDestroyed)
        {
            var calcBullet = Weapon.TriggerRole.RoleState.CalcBullet(bullet);
            var bInst = FireManager.ShootBullet(Weapon, position, altitude, fireRotation, calcBullet);
            Weapon.TriggerRole.ShootBulletHandler(Weapon, fireRotation, bInst);
            return bInst;
        }
        else
        {
            var bInst = FireManager.ShootBullet(Weapon, position, altitude, fireRotation, bullet);
            Weapon.Master?.ShootBulletHandler(Weapon, fireRotation, bInst);
            return bInst;
        }
    }
}