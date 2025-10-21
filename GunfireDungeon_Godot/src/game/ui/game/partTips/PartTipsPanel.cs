using System.Text;
using Godot;

namespace UI.game.PartTips;

public partial class PartTipsPanel : PartTips
{
    /// <summary>
    /// 设置位置
    /// </summary>
    public void SetPosition(Vector2 position)
    {
        S_PanelRoot.Instance.GlobalPosition = position;
    }

    /// <summary>
    /// 设置显示的零件属性
    /// </summary>
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
