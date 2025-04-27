
using Config;
using DsUi;
using Godot;

/// <summary>
/// 开火
/// </summary>
public class FireBulletParam : IClone<FireBulletParam>
{
    /// <summary>
    /// 子弹数据
    /// </summary>
    public ExcelConfig.BulletBase Bullet;

    /// <summary>
    /// 开火位置
    /// </summary>
    public Vector2 Position;
    
    /// <summary>
    /// 初始位置
    /// </summary>
    public float Altitude;
    
    /// <summary>
    /// 开火角度
    /// </summary>
    public float FireRotation;
    
    /// <summary>
    /// 阵营
    /// </summary>
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

    public FireBulletParam Clone()
    {
        return new FireBulletParam(this);
    }
}