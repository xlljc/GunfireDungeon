
using System;
using Config;
using Godot;

public partial class TipState : TextureProgressBar
{
    [Export]
    public NumberSprite NumberSprite;

    public RoleTip RoleTip;
    public ExcelConfig.AbnormalStateConfig Config;
    //是否已经激活该状态
    private bool _flag;
    private float _value;
    
    public void Init(RoleTip roleTip, ExcelConfig.AbnormalStateConfig config)
    {
        NumberSprite.Visible = false;
        RoleTip = roleTip;
        Config = config;
        SetActivateFlag(false);
    }

    /// <summary>
    /// 添加状态累计值
    /// </summary>
    public void AddAbnormalStateValue(float value)
    {
        // RoleTip.Role.
        if (!_flag)
        {
            var roleV = 860 * Config.Gradient[0];
            _value = Math.Clamp(_value + value, 0, roleV);

            SetProgress(_value / roleV);
            SetActivateFlag(_value >= roleV);
        }
    }
    
    
    /// <summary>
    /// 设置是否已经激活该状态
    /// </summary>
    public void SetActivateFlag(bool flag)
    {
        FillMode = (int)(flag ? FillModeEnum.Clockwise : FillModeEnum.CounterClockwise);
        _flag = flag;
    }
    
    /// <summary>
    /// 设置进度，0 - 1
    /// </summary>
    private void SetProgress(float progress)
    {
        progress = Math.Clamp(progress, 0, 1);
        if (_flag)
        {
            Value = progress;
        }
        else
        {
            Value = 1 - progress;
        }
    }
}