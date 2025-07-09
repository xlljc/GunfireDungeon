
using System;
using System.Collections.Generic;
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
    
    /// <summary>
    /// 当前激活的等级
    /// </summary>
    public int CurrLevel { get; private set; }
    
    public AbnormalStateType AbnormalStateType;
    
    private float _value;
    //用于记录层级索引
    private int _levelIndex = 0;
    private int _prevLevelIndex = 0;
    private float[] _levelArr;

    private bool _activateFlag;
    private float _lostTimer;

    //异常状态处理组件
    private List<IAbnormalStateComp> _asComponentList = new List<IAbnormalStateComp>();
    
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
        TextureProgress = ResourceManager.LoadTexture2D(config.IconMask);
        AbnormalResistance  = roleTip.Role.RoleState.RoleBase.GetAbnormalStateResist(stateType);
        _levelArr = new float[config.Gradient.Length];
        var num = 0f;
        for (var i = 0; i < _levelArr.Length; i++)
        {
            num += AbnormalResistance * config.Gradient[i];
            _levelArr[i] = num;
        }

        TintUnder = new Color(0.5f, 0.5f, 0.5f, 1f);
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
                        var v = Mathf.Clamp(_levelIndex, 0, Config.Gradient.Length - 1);
                        var currLevelMaxValue = AbnormalResistance * Config.Gradient[v];
                        _value -= currLevelMaxValue * Config.ActiveLostSpeed[0] * newDelta;
                    }
                    else //数值消退
                    {
                        _value -= Config.ActiveLostSpeed[0] * newDelta;
                    }

                    if (RefreshValue() < 0 && _levelIndex < _levelArr.Length - 1) // 降低过层级
                    {
                        _lostTimer = 0;
                    }
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
        _value += value;
        _lostTimer = 0;
        RefreshValue();
    }

    /// <summary>
    /// 移除当前状态
    /// </summary>
    public void DoRemoveAbnormalState()
    {
        _value = 0;
        _lostTimer = 0;
        RefreshValue();
    }

    // 返回 -1，表示减少层级；返回0，层级未变化；返回1，表示增加层级
    private int RefreshValue()
    {
        var prevLevel = _levelIndex;
        if (_value <= 0)
        {
            _value = 0;
            _levelIndex = 0;
            
            RefreshNumber();
            
            if (_activateFlag)
            {
                _activateFlag = false;
                CurrLevel = 0;
                OnDeactivate();
            }
            SetProgress(0);
            return GetLevelCompIndex(prevLevel, _levelIndex);
        }
        
        var newLevel = _levelArr.Length;
        //寻找等级
        for (var i = 0; i < _levelArr.Length; i++)
        { 
            if (!(_value < _levelArr[i])) continue;
            newLevel = i;
            break;
        }

        var refreshActivateFlag = newLevel > _levelIndex;
        _levelIndex = newLevel;
        
        if (newLevel == _levelArr.Length) //到达最高层级
        {
            _value = _levelArr[_levelArr.Length - 1];
            
            if (refreshActivateFlag)
            {
                _activateFlag = true;
            }
            
            RefreshNumber();
            SetProgress(1);
            return GetLevelCompIndex(prevLevel, _levelIndex);
        }
        
        // 当前等级所需值
        var currLevelMaxValue = AbnormalResistance * Config.Gradient[newLevel];
        // 当前等级值
        var currLevelValue = newLevel == 0 ? _value : (_value - _levelArr[newLevel - 1]);

        RefreshNumber();
        if (newLevel > 0 && currLevelValue == 0)
        {
            SetProgress(1);
        }
        else
        {
            SetProgress(currLevelValue / currLevelMaxValue);
        }
        
        if (refreshActivateFlag)
        {
            _activateFlag = true;
        }
        
        return GetLevelCompIndex(prevLevel, _levelIndex);
    }

    private int GetLevelCompIndex(int oldLevel, int newLevel)
    {
        if (oldLevel == newLevel) return 0;
        if (newLevel > oldLevel) return 1;
        return -1;
    }
    
    private void RefreshNumber()
    {
        var prevLevel = _prevLevelIndex;
        if (prevLevel == _levelIndex)
        {
            return;
        }

        _prevLevelIndex = _levelIndex;

        var prevCl = CurrLevel;
        if (_levelIndex > prevLevel) //升级
        {
            FillMode = (int)FillModeEnum.CounterClockwise;
            NumberSprite.SetNumber((uint)_levelIndex);
            CurrLevel = _levelIndex;
            if (prevLevel == 0)
            {
                TintUnder = new Color(1, 1, 1, 1f);
                OnActivate();
            }
            else if (prevCl != CurrLevel)
            {
                OnLevelUp();
            }
        }
        else //降级
        {
            FillMode = (int)FillModeEnum.Clockwise;
            NumberSprite.SetNumber((uint)_levelIndex + 1);
            CurrLevel = _levelIndex + 1;
            if (prevCl != CurrLevel)
            {
                OnLevelDown();
            }
        }

        if (Config.Gradient.Length == 1 || CurrLevel == 0)
        {
            NumberSprite.Visible = false;
        }
        else
        {
            NumberSprite.Visible = true;
        }

        if (CurrLevel >= 1)
        {
            TintProgress = new Color(0, 0, 0, 0.9f);
        }
        else
        {
            TintProgress = new Color(0, 0, 0, 1f);
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
        //{
        Value = 1 - progress;
        //}

        if (progress <= 0)
        {
            RoleTip.RemoveTipState(this);
        }
    }

    private void DoInitAsComp()
    {
        foreach (var kv in Config.AsComp)
        {
            Type type = null;
            switch (kv.Key)
            {
                case "AsContinuousDamage":
                    type = typeof(AsContinuousDamage);
                    break;
            }

            if (type == null) return;
            var comp = RoleTip.Role.AddComponent(type);
            var ac = (IAbnormalStateComp)comp;
            ac.InitConfig(Config, kv.Value);
            _asComponentList.Add(ac);
        }
    }

    // 当前状态被激活
    private void OnActivate()
    {
        // Debug.Log("激活: " + CurrLevel);
        if (_asComponentList.Count == 0)
        {
            DoInitAsComp();
        }

        foreach (var item in _asComponentList)
        {
            item.OnActivate(CurrLevel);
        }
    }
    
    // 当前状态被取消激活
    private void OnDeactivate()
    {
        // Debug.Log("取消激活：" + CurrLevel);
        foreach (var item in _asComponentList)
        {
            item.OnDeactivate(CurrLevel);
        }
    }

    private void OnLevelUp()
    {
        // Debug.Log("升级: " + CurrLevel);
        foreach (var item in _asComponentList)
        {
            item.OnLevelUp(CurrLevel);
        }
    }
    
    private void OnLevelDown()
    {
        // Debug.Log("降级: " + CurrLevel);
        foreach (var item in _asComponentList)
        {
            item.OnLevelDown(CurrLevel);
        }
    }
}