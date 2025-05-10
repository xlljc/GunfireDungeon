using Godot;
using System;

/// <summary>
/// 自定义进度条
/// </summary>
public partial class CommProgressBar : TextureProgressBar
{
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
}
