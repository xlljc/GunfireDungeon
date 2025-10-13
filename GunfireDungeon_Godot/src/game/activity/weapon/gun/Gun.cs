using Config;
using Godot;

/// <summary>
/// 普通的枪
/// </summary>
public partial class Gun : Weapon
{
    protected override void OnFire()
    {
        base.OnFire();
        
        if (TriggerRole != null && TriggerRole.IsPlayer())
        {
            Input.StartJoyVibration(0, 0, 0.9f, 0.2f);
        }
    }
}