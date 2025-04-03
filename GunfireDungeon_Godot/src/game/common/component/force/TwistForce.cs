
using Godot;

/// <summary>
/// 扭曲运动外力
/// </summary>
public class TwistForce : ExternalForce
{
    /// <summary>
    /// 移动方向, 弧度制
    /// </summary>
    public float MoveRotation { get; set; }

    /// <summary>
    /// 周期时间缩放
    /// </summary>
    public float CycleTimeScale { get; set; } = 7;

    /// <summary>
    /// 扭曲强度
    /// </summary>
    public float Strength { get; set; } = 50;
    
    /// <summary>
    /// 时间偏移
    /// </summary>
    public float TimeOffset { get; set; }

    public TwistForce() : base(nameof(TwistForce))
    {
        AutoDestroy = false;
    }

    public override void PhysicsProcess(float delta)
    {
        TimeOffset += delta * CycleTimeScale;
        var sin = Mathf.Sin(TimeOffset);
        Velocity = new Vector2(0, sin * Strength).Rotated(MoveRotation);
    }


}