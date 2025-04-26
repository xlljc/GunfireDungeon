using System.Text;
using Godot;

namespace UI.game.PartTips;

public partial class PartTipsPanel : PartTips
{
    public override void Process(float delta)
    {
        S_PanelRoot.Instance.GlobalPosition = GetGlobalMousePosition();
    }

    public void SetPartProp(PartProp partProp)
    {
        /*
         Name
         描述
         Type
         */
        var sb = new StringBuilder();
        sb.AppendLine(partProp.ActivityBase.Name);
        sb.AppendLine();
        sb.AppendLine($"[color=#ff0000]{partProp.ActivityBase.Type}[/color]");
        sb.AppendLine($"[color=#ff0000]{partProp.PartLogicBase.PartType}[/color]");
        S_Text.Instance.Text = sb.ToString();
    }
}
