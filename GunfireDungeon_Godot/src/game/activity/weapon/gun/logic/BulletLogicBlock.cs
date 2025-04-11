
using Config;
using Godot;

public class BulletLogicBlock : LogicBlockBase
{
    /// <summary>
    /// 散射角度
    /// </summary>
    public float ScatteringAngle { get; set; } = 5;
    
    /// <summary>
    /// 发射的子弹
    /// </summary>
    public ExcelConfig.BulletBase Bullet { get; set; }

    public override void Execute(float fireRotation)
    {
        Debug.Log($"射击子弹({Index}), fireRotation:{fireRotation}");
        if (Bullet != null)
        {
            ShootBullet(fireRotation, Bullet);
        }
    }

    public void ShootBullet(float fireRotation, ExcelConfig.BulletBase bullet)
    {
        fireRotation += Mathf.DegToRad(Utils.Random.RandomRangeFloat(-ScatteringAngle, ScatteringAngle));
        if (Weapon.Master != null && !Weapon.Master.IsDestroyed)
        {
            var calcBullet = Weapon.Master.RoleState.CalcBullet(bullet);
            FireManager.ShootBullet(Weapon, fireRotation, calcBullet);
            Weapon.Master.ShootBulletHandler(Weapon, fireRotation, bullet);
        }
        else if (Weapon.TriggerRole != null && !Weapon.TriggerRole.IsDestroyed)
        {
            var calcBullet = Weapon.TriggerRole.RoleState.CalcBullet(bullet);
            FireManager.ShootBullet(Weapon, fireRotation, calcBullet);
            Weapon.TriggerRole.ShootBulletHandler(Weapon, fireRotation, bullet);
        }
        else
        {
            FireManager.ShootBullet(Weapon, fireRotation, bullet);
            Weapon.Master?.ShootBulletHandler(Weapon, fireRotation, bullet);
        }
    }
}