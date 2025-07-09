
using System;
using System.Text.Json;
using Config;
using Godot;

/// <summary>
/// 异常状态，持续伤害
/// </summary>
public class AsContinuousDamage : Component<Role>, IAbnormalStateComp
{
    private float _timer;

    private ExcelConfig.AbnormalStateConfig _config;

    private int _currLevel;

    private float _updateTime;
    private float _lostPercentage;
    private float _lostValue;
    
    public void InitConfig(ExcelConfig.AbnormalStateConfig config, JsonElement[] param)
    {
        _config = config;
        _updateTime = param[0].GetSingle();
        _lostPercentage = param[1].GetSingle();
        _lostValue = param[2].GetSingle();
    }
    
    public override void Process(float delta)
    {
        _timer += delta;
        if (_timer > _updateTime)
        {
            _timer %= _updateTime;
            var damage = Mathf.CeilToInt(Master.MaxHp * _lostPercentage * _currLevel + _lostValue * _currLevel);
            var angel = Master.MountPoint.RealRotation + Mathf.Pi;
            Master.HurtHandler(null, damage, DamageType.Real, angel);
        }
    }
    
    public void OnActivate(int level)
    {
        _currLevel = level;
        Enable = true;
        _timer = _updateTime;
    }

    public void OnDeactivate(int level)
    {
        _currLevel = level;
        Enable = false;
    }

    public void OnLevelUp(int level)
    {
        _currLevel = level;
    }

    public void OnLevelDown(int level)
    {
        _currLevel = level;
    }
}