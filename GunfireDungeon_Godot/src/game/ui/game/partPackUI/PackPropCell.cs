using DsUi;

namespace UI.game.PartPackUI;

public class PartPackCell : UiCell<PartPackUI.PartPackItem, PartProp>
{
    public override void OnInit()
    {
        CellNode.L_PartIcon.Instance.Visible = false;
    }

    public override void OnSetData(PartProp data)
    {
        if (data != null)
        {
            CellNode.L_PartIcon.Instance.Visible = true;
            CellNode.L_PartIcon.Instance.Texture = data.Icon;
        }
        else
        {
            CellNode.L_PartIcon.Instance.Visible = false;
        }
    }
}