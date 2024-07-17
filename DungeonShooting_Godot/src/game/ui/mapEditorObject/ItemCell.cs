using System.Collections;
using Config;

namespace UI.MapEditorObject;

public class ItemCell : UiCell<MapEditorObject.Item, RoomObjectInfo>
{
    public override void OnInit()
    {
        CellNode.L_ItemButton.L_Select.Instance.Visible = false;
        CellNode.L_ItemButton.Instance.Pressed += Click;
    }

    public override void OnSetData(RoomObjectInfo data)
    {
        var config = ExcelConfig.EditorObject_Map[data.Id];
        CellNode.L_ItemButton.Instance.Text = config.GetRealName();
        CellNode.L_ItemButton.L_Icon.Instance.Texture = config.GetIcon();
    }

    public override void OnSelect()
    {
        CellNode.L_ItemButton.L_Select.Instance.Visible = true;
        EventManager.EmitEvent(EventEnum.OnSelectObject, Data);
    }

    public override void OnUnSelect()
    {
        CellNode.L_ItemButton.L_Select.Instance.Visible = false;
    }

    public override void OnDoubleClick()
    {
        CellNode.UiPanel.FoceSelectObject(Data);
    }
}