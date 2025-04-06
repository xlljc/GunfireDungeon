using Godot;

/// <summary>
/// 普通的枪
/// </summary>
public partial class Gun : Weapon
{
    protected override void OnFire()
    {
        if (Master == World.Player)
        {
            //创建抖动
            GameCamera.Main.DirectionalShake(Vector2.Right.Rotated(GlobalRotation) * Attribute.CameraShake);
        }

        //创建开火特效
        if (!string.IsNullOrEmpty(Attribute.FireEffect))
        {
            var effect = ObjectManager.GetPoolItem<IEffect>(Attribute.FireEffect);
            var sprite = (Node2D)effect;
            sprite.Position = GetLocalFirePosition();
            AddChild(sprite);
            effect.PlayEffect();
        }
    }

    protected override void OnShoot(float fireRotation)
    {
        if (Master != null && !Master.IsDestroyed)
        {
            var calcBullet = Master.RoleState.CalcBullet(Attribute.Bullet);
            FireManager.ShootBullet(this, fireRotation, calcBullet);
            Master.ShootBulletHandler(this, fireRotation, Attribute.Bullet);
        }
        else if (TriggerRole != null && !TriggerRole.IsDestroyed)
        {
            var calcBullet = TriggerRole.RoleState.CalcBullet(Attribute.Bullet);
            FireManager.ShootBullet(this, fireRotation, calcBullet);
            TriggerRole.ShootBulletHandler(this, fireRotation, Attribute.Bullet);
        }
        else
        {
            FireManager.ShootBullet(this, fireRotation, Attribute.Bullet);
            Master?.ShootBulletHandler(this, fireRotation, Attribute.Bullet);
        }
    }
}