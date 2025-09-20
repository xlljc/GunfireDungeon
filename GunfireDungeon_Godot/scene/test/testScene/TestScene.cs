using Godot;
using System;

public partial class TestScene : Node2D
{

    [Export] public Sprite2D Template;
    
    public override void _Ready()
    {
        if (Template == null)
        {
            GD.PrintErr("Template 未赋值");
            return;
        }
    
        int cols = 100;
        int rows = 60;
        float spacing = 20f;
    
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                var sprite = (Sprite2D)Template.Duplicate();
                sprite.Position = new Vector2(c * spacing, r * spacing);
                AddChild(sprite);
            }
        }
    }
}
