
using Config;
using Godot;

/// <summary>
/// 子弹零件
/// </summary>
[Part("Bullet")]
public class BulletPart : PartLogicBase
{
    /// <summary>
    /// 逻辑块消耗法力值
    /// </summary>
    public int Mana { get; set; }
    
    /// <summary>
    /// 散射角度
    /// </summary>
    public int ScatteringAngle { get; set; } = 5;
    
    /// <summary>
    /// 发射的子弹
    /// </summary>
    public ExcelConfig.BulletBase Bullet { get; set; }
    
    /// <summary>
    /// 子弹数量
    /// </summary>
    public int Count { get; set; }

    public override int GetMana()
    {
        return Mana;
    }

    public override void InitParam(ExcelConfig.PartBase config)
    {
        Mana = config.BaseMana;
        var bulletId = config.Param["Bullet"].GetString();
        Bullet = ExcelConfig.BulletBase_Map[bulletId];
        ScatteringAngle = Utils.Random.RandomConfigRange(config.GetParam<int[]>("ScatteringAngle", [ScatteringAngle]));
        Count = config.GetParam("Count", Count);
        
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
            
            var bulletParam = new FireBulletParam(Bullet);
            bulletParam.FireRotation = param.FireRotation;
            if (param.HasValue(PlanningParam.PrevBullet))
            {
                var bulletInst = param.GetValue<IBullet>(PlanningParam.PrevBullet);
                bulletParam.Position = bulletInst.GetEndPosition();
                bulletParam.Altitude = bulletInst.Altitude;
                bulletParam.Camp = bulletInst.Camp;
            }
            else
            {
                bulletParam.Position = Weapon.FirePoint.GlobalPosition;
                if (Weapon.TriggerRole != null && !Weapon.TriggerRole.IsDestroyed)
                {
                    bulletParam.Camp = Weapon.TriggerRole.Camp;
                    bulletParam.Altitude = Weapon.TriggerRole.GetFirePointAltitude();
                }
                else
                {
                    bulletParam.Camp = CampEnum.None;
                    bulletParam.Altitude = 1;
                }
            }
            
            var bullet = ShootBullet(bulletParam);
            return new [] {bullet};
        }
        
        return null;
    }

    public IBullet ShootBullet(FireBulletParam param)
    {
        param.FireRotation += Mathf.DegToRad(Utils.Random.RandomRangeFloat(-ScatteringAngle, ScatteringAngle));
        if (Weapon.Master != null && !Weapon.Master.IsDestroyed)
        {
            param.Bullet = Weapon.Master.RoleState.CalcBullet(param.Bullet);
            var bInst = FireManager.ShootBullet(Weapon, param);
            Weapon.Master.ShootBulletHandler(Weapon, param.FireRotation, bInst);
            return bInst;
        }
        else if (Weapon.TriggerRole != null && !Weapon.TriggerRole.IsDestroyed)
        {
            param.Bullet = Weapon.TriggerRole.RoleState.CalcBullet(param.Bullet);
            var bInst = FireManager.ShootBullet(Weapon, param);
            Weapon.TriggerRole.ShootBulletHandler(Weapon, param.FireRotation, bInst);
            return bInst;
        }
        else
        {
            var bInst = FireManager.ShootBullet(Weapon, param);
            Weapon.Master?.ShootBulletHandler(Weapon, param.FireRotation, bInst);
            return bInst;
        }
    }
}