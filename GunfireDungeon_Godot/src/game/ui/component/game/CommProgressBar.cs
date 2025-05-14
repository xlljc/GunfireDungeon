using Godot;
using System;

/// <summary>
/// 自定义进度条
/// </summary>
public partial class CommProgressBar : ColorRect
{
    /// <summary>
    /// 控制增长速率的因子，值越小增长越慢
    /// </summary>
    private const float ScalingFactor = 0.002f;

    /// <summary>
    /// 显示数字的标签
    /// </summary>
    [Export]
    public Label NumberLabel;

    /// <summary>
    /// 值的颜色
    /// </summary>
    [Export] public Color ValueColor = new Color(1, 1, 1, 1);
    
    /// <summary>
    /// 值变化后显示的临时进度条
    /// </summary>
    [Export]
    public Color TempColor = new Color(1, 1, 1, 1);
    
    /// <summary>
    /// 值颜色节点
    /// </summary>
    [Export]
    public ColorRect ValueRect;
    
    /// <summary>
    /// 临时进度条节点
    /// </summary>
    [Export]
    public ColorRect TempRect;
    
    /// <summary>
    /// 临时进度条多久开始变化，如果值小于0，则表示不启用
    /// </summary>
    [Export]
    public float TempTime = 1.5f;

    /// <summary>
    /// 临时进度条变化速度，单位：秒，表示从 0 到 1 总共需要多少秒
    /// </summary>
    [Export]
    public float TempSpeed = 3.5f;
    
    public float Value
    {
        set
        {
            var result = Mathf.Clamp(value, 0, _maxValue);
            if (result == _value)
            {
                return;
            }

            var v = value / _maxValue;
            ValueRect.Size = new Vector2(v * Size.X, ValueRect.Size.Y);
            NumberLabel.Text = ((int)value).ToString();

            if (result > _value) // 值变大
            {
                if (ValueRect.Size > TempRect.Size)
                {
                    TempRect.Size = new Vector2(v * Size.X, TempRect.Size.Y);
                    _timer = 0;
                }
            }
            else // 值变小
            {
                _timer = TempTime;
            }
            
            _value = result;
        }
        get => _value;
    }
    
    public float MaxValue
    {
        set
        {
            var result = Mathf.Max(value, 0);
            if (result == _maxValue)
            {
                return;
            }
            _maxValue = result;

            if (Value > _maxValue)
            {
                Value = _maxValue;
            }
            
            RefreshLength();
        }
        get => _maxValue;
    }

    private float _value = 0;
    private float _maxValue = 0;
    
    private float _maxLength;
    private float _minLength;

    private float _timer;

    public override void _Ready()
    {
        if (TempTime < 0)
        {
            TempRect.Visible = false;
        }
        TempRect.Color = TempColor;
        ValueRect.Color = ValueColor;

        Resized += OnResize;
    }

    public override void _Process(double delta)
    {
        if (_maxValue <= 0)
        {
            return;
        }
        var d = (float)delta;
        if (_timer >= 0)
        {
            _timer -= d;
        }
        else if (TempTime >= 0)
        {
            var target = Value / _maxValue * Size.X;
            var curr = TempRect.Size;
            TempRect.Size = TempRect.Size.MoveToward(new Vector2(target, curr.Y), Size.X / TempSpeed * d);
        }
    }

    private void OnResize()
    {

        float v;
        if (_maxValue == 0)
        {
            v = 0;
        }
        else
        {
            v = Value / _maxValue * Size.X;
        }

        ValueRect.Size = new Vector2(v, ValueRect.Size.Y);
        TempRect.Size = new Vector2(v, TempRect.Size.Y);
        _timer = 0;
    }

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
            // 使用线性函数计算长度
            currentLength = Utils.LinearApproximation(MaxValue, _minLength, _maxLength, ScalingFactor);
        }
    
        // 确保长度在minLength和maxLength之间
        currentLength = Mathf.Clamp(currentLength, _minLength, _maxLength);
    
        // 应用计算的长度
        CustomMinimumSize = new Vector2(currentLength, CustomMinimumSize.Y);
    }
}
