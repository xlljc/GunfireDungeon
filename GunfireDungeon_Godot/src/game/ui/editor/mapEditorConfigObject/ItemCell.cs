using System.Collections;
using Config;

using DsUi;

namespace UI.MapEditorConfigObject;

public class ItemCell : UiCell<MapEditorConfigObject.CellButton, ExcelConfig.EditorObject>
{
    public override void OnInit()
    {
        CellNode.L_SelectTexture.Instance.Visible = false;
    }

    public override IEnumerator OnSetDataCoroutine(ExcelConfig.EditorObject data)
    {
        CellNode.L_CellName.Instance.Text = data.GetRealName();
        CellNode.L_PreviewImage.Instance.Texture = data.GetIcon();
        yield return null;
    }

    public override void OnSelect()
    {
        CellNode.L_SelectTexture.Instance.Visible = true;
    }

    public override void OnUnSelect()
    {
        CellNode.L_SelectTexture.Instance.Visible = false;
    }
}