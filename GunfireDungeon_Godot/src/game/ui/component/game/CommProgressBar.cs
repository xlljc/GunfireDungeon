using Godot;
using System;

/// <summary>
/// 自定义进度条
/// </summary>
public partial class CommProgressBar : TextureProgressBar
{
    [Export]
    public Label NumberLabel;
    
    private double _value = double.MinValue;

    public override void _Process(double delta)
    {
        var v = Value;
        if (Math.Abs(_value - v) > 0.001f)
        {
            NumberLabel.Text = ((int)v).ToString();
            _value = v;
        }
    }
}
