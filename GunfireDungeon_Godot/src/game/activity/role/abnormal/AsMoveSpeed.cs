
using System.Text.Json;
using Config;

public class AsMoveSpeed : Component<Role>, IAbnormalStateComp
{
    private int _currLevel;
    
    private bool _isPercentage;

    private float _speedDelta;
    
    public void InitConfig(ExcelConfig.AbnormalStateConfig config, JsonElement[] param)
    {
        var value = param[0].GetSingle();
        _isPercentage = param[1].GetBoolean();
        if (_isPercentage)
        {
            _speedDelta = value * Master.RoleState.RoleBase.MoveSpeed;
        }
        else
        {
            _speedDelta = value;
        }
    }

    public void OnActivate(int level)
    {
        DoChangeLevel(level);
    }

    public void OnDeactivate(int level)
    {
        DoChangeLevel(level);
    }

    public void OnLevelUp(int level)
    {
        DoChangeLevel(level);
    }

    public void OnLevelDown(int level)
    {
        DoChangeLevel(level);
    }
    
    private void DoChangeLevel(int level)
    {
        if (_currLevel == level)
        {
            return;
        }
        
        var change = level - _currLevel;
        _currLevel = level;
        var moveSpeed = change * _speedDelta;
        
        Master.RoleState.MoveSpeed += moveSpeed;
        Master.RoleState.Acceleration += moveSpeed * 1.4f;
        Master.RoleState.Friction += moveSpeed * 10;
    }
}