
using System;
using Config;
using Godot;

/// <summary>
/// 角色头顶状态中的单项
/// </summary>
public partial class TipState : TextureProgressBar
{
    /// <summary>
    /// 用于层数显示
    /// </summary>
    [Export]
    public NumberSprite NumberSprite;

    /// <summary>
    /// 异常状态抗性
    /// </summary>
    public int AbnormalResistance;
    
    public RoleTip RoleTip;
    
    /// <summary>
    /// 异常状态数据
    /// </summary>
    public ExcelConfig.AbnormalStateConfig Config;
    
    public AbnormalStateType AbnormalStateType;
    
    private float _value;
    private int _level = 0;
    private float[] _levelArr;

    private bool _activateFlag;
    private float _lostTimer;
    
    public void Init(RoleTip roleTip, AbnormalStateType stateType, ExcelConfig.AbnormalStateConfig config)
    {
        NumberSprite.Visible = false;
        RoleTip = roleTip;
        Config = config;
        if (config.ActiveLostSpeed.Length != 2)
        {
            throw new Exception("AbnormalStateConfig.ActiveLostSpeed 置错误: " + config.Id + "，正确格式为[消退值，是否是百分比]");
        }
        AbnormalStateType = stateType;
        TextureUnder = ResourceManager.LoadTexture2D(config.Icon);
        AbnormalResistance  = roleTip.Role.RoleState.RoleBase.GetAbnormalStateResist(stateType);
        _levelArr = new float[config.Gradient.Length];
        var num = 0f;
        for (var i = 0; i < _levelArr.Length; i++)
        {
            num += AbnormalResistance * config.Gradient[i];
            _levelArr[i] = num;
        }
        // SetActivateFlag(false);
    }

    public override void _Process(double delta)
    {
        var newDelta = (float)delta;
        if (!_activateFlag) //未激活
        {
            if (Config.LostTime >= 0) //存在消失时间
            {
                if (_lostTimer >= Config.LostTime)
                {
                    _value -= Config.LostSpeed * newDelta;
                    RefreshValue();
                }
                else
                {
                    _lostTimer += newDelta;
                }
            }
        }
        else //已经激活
        {
            if (Config.ActiveLostTime >= 0) //存在消失时间
            {
                if (_lostTimer >= Config.ActiveLostTime)
                {
                    if (Config.ActiveLostSpeed[1] == 1f) //百分比消退
                    {
                        _value -= Config.ActiveLostSpeed[0] * newDelta;
                    }
                    else //数值消退
                    {
                        _value -= Config.ActiveLostSpeed[0] * newDelta;
                    }
                    
                    RefreshValue();
                }
                else
                {
                    _lostTimer += newDelta;
                }
            }
        }
    }

    /// <summary>
    /// 添加状态累计值，如果值为负数，则表示减去状态值
    /// </summary>
    public void AddAbnormalStateValue(float value)
    {
        // _value = Mathf.Clamp(value, 0, _levelArr[_levelArr.Length - 1]);

        _value += value;
        _lostTimer = 0;
        RefreshValue();
    }

    private void RefreshValue()
    {
        if (_value <= 0)
        {
            _value = 0;
            _level = 0;

            if (_activateFlag)
            {
                _activateFlag = false;
                OnDeactivate();
            }

            SetProgress(0);
            // FillMode = (int)(_level > 0 ? FillModeEnum.Clockwise : FillModeEnum.CounterClockwise);
            RefreshNumber();
            return;
        }
        
        var level = _levelArr.Length;
        //寻找等级
        for (var i = 0; i < _levelArr.Length; i++)
        {
            if (!(_value < _levelArr[i])) continue;
            level = i;
            break;
        }

        var refreshActivateFlag = level > _level;
        _level = level;
        
        if (level == _levelArr.Length) //到达最高层级
        {
            _value = _levelArr[_levelArr.Length - 1];
            SetProgress(1);
            RefreshNumber();
            
            if (refreshActivateFlag)
            {
                _activateFlag = true;
                OnActivate();
            }
            return;
        }
        
        // 当前等级所需值
        var currLevelMaxValue = AbnormalResistance * Config.Gradient[level];
        // 当前等级值
        var currLevelValue = level == 0 ? _value : (_value - _levelArr[level - 1]);

        if (level > 0 && currLevelValue == 0)
        {
            SetProgress(1);
        }
        else
        {
            SetProgress(currLevelValue / currLevelMaxValue);
        }

        RefreshNumber();
        
        if (refreshActivateFlag)
        {
            _activateFlag = true;
            OnActivate();
        }
    }

    private void RefreshNumber()
    {
        if (_level > 0)
        {
            NumberSprite.Visible = true;
            NumberSprite.SetNumber((uint)_level);
        }
        else
        {
            NumberSprite.Visible = false;
        }
    }
    
    /// <summary>
    /// 设置进度，0 - 1
    /// </summary>
    private void SetProgress(float progress)
    {
        progress = Math.Clamp(progress, 0, 1);
        // if (_activateFlag)
        // {
        //     Value = progress;
        // }
        // else
        {
            Value = 1 - progress;
        }
    }

    // 当前状态被激活
    private void OnActivate()
    {
        Debug.Log("激活: " + _level);
    }

    // 当前状态被取消激活
    private void OnDeactivate()
    {
        Debug.Log("取消激活");
    }
}