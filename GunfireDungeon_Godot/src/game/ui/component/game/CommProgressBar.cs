using Godot;
using System;

/// <summary>
/// 自定义进度条
/// </summary>
public partial class CommProgressBar : TextureProgressBar
{
    /// <summary>
    /// 控制增长速率的因子，值越小增长越慢
    /// </summary>
    private const float ScalingFactor = 0.002f;
    
    [Export]
    public Label NumberLabel;

    public new double Value
    {
        set
        {
            base.Value = value;
            NumberLabel.Text = ((int)value).ToString();
        }
        get => base.Value;
    }
    
    public new double MaxValue
    {
        set
        {
            base.MaxValue = value;
            RefreshLength();
        }
        get => base.MaxValue;
    }
    
    private float _maxLength;
    private float _minLength;

    /// <summary>
    /// 设置自动长度范围，当最大长度变化时，会自动设置进度条长度
    /// </summary>
    public void SetAutoLengthRange(int min, int max)
    {
        _minLength = min;
        _maxLength = max;
        RefreshLength();
    }

    //根据最大 MaxValue 判断自动设置长度，长度从 _minLength 开始，MaxValue 越大就会越无限趋近于 _maxLength
    //使用线性函数
    //MaxValue从 0 开始，可以无限大
    private void RefreshLength()
    {
        // 计算当前长度
        var currentLength = _minLength;
    
        if (MaxValue > 0)
        {
            // 使用线性函数计算长度：minLength + (maxLength - minLength) * (1 - 1/(1 + scalingFactor*MaxValue))
            // 这个函数确保当MaxValue趋近于无穷大时，长度趋近于maxLength
            currentLength = (float)(_minLength + (_maxLength - _minLength) *
                (1 - 1 / (1 + ScalingFactor * MaxValue)));
        }
    
        // 确保长度在minLength和maxLength之间
        currentLength = Mathf.Clamp(currentLength, _minLength, _maxLength);
    
        // 应用计算的长度
        CustomMinimumSize = new Vector2(currentLength, CustomMinimumSize.Y);
    }
}
