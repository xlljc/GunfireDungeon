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
        var sb = new StringBuilder();
        sb.AppendLine(partProp.PartBase.Name + "\t（" + partProp.PartBase.Type.ToRichText() + "）");
        sb.AppendLine();
        sb.AppendLine(partProp.PartBase.Intro.Code);
        S_Text.Instance.Text = sb.ToString();
        
        S_PanelRoot.Instance.ResetSize();
    }
}
