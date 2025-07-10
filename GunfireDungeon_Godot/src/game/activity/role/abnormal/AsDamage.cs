
using System.Text.Json;
using Config;
using Godot;

/// <summary>
/// 异常状态，单次伤害
/// </summary>
public class AsDamage : Component<Role>, IAbnormalStateComp
{

    //百分比伤害
    private float _percentage;
    //固定伤害
    private int _fixed;

    private TipState _tipState;
    
    public void InitConfig(TipState tipState, JsonElement[] param)
    {
        _tipState = tipState;
        _percentage = param[0].GetSingle();
        _fixed = param[1].GetInt32();
    }

    public void OnActivate(int level)
    {
        var damage = Mathf.CeilToInt(Master.MaxHp * _percentage + _fixed);
        var angel = Master.MountPoint.RealRotation + Mathf.Pi;
        Master.HurtHandler(null, damage, DamageType.Real, angel);
        this.CallDelay(1f, () =>
        {
            _tipState.DoRemoveAbnormalState();
        });
    }

    public void OnDeactivate(int level)
    {
        
    }

    public void OnLevelUp(int level)
    {
        
    }

    public void OnLevelDown(int level)
    {
        
    }
}