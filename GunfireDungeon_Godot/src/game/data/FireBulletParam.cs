
using Config;
using Godot;

/// <summary>
/// 开火
/// </summary>
public class FireBulletParam
{
    /// <summary>
    /// 子弹数据
    /// </summary>
    public ExcelConfig.BulletBase Bullet;

    public Vector2 Position;
    public float Altitude;
    public float FireRotation;
    public CampEnum Camp = CampEnum.None;

    public FireBulletParam(ExcelConfig.BulletBase bullet)
    {
        Bullet = bullet;
    }

    public FireBulletParam(FireBulletParam data)
    {
        Bullet = data.Bullet;
        Position = data.Position;
        Altitude = data.Altitude;
        FireRotation = data.FireRotation;
        Camp = data.Camp;
    }
}