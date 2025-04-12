using Godot;
using System;
using DsUi;

public partial class CommProgressBar : TextureProgressBar
{
    [Export]
    public Label NumberLabel;

    public override void _Process(double delta)
    {
        NumberLabel.Text = ((int)Value).ToString();
    }
}
