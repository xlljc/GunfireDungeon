using Godot;

/// <summary>
/// 零件包槽位
/// </summary>
public partial class PartPackSlot : NinePatchRect
{
    
    [Export]
    public NinePatchRect SelectTex { get; private set; }

    public override void _Ready()
    {
        SelectTex.Visible = false;
        
        MouseEntered += OnMouseEntered;
        MouseExited += OnMouseExited;
    }
    
    public void SetSelect(bool isSelect)
    {
        SelectTex.Visible = isSelect;
    }
    
    private void OnMouseEntered()
    {
        if (!InputManager.IsJoystickInput)
        {
            SelectTex.Visible = true;
        }
    }
    
    private void OnMouseExited()
    {
        if (!InputManager.IsJoystickInput)
        {
            SelectTex.Visible = false;
        }
    }
}
