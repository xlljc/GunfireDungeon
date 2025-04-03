namespace UI.MapEditorTools;

public class ToolButtonCell : UiCell<MapEditorTools.ToolButton, EditorToolBase>
{
    public override void OnInit()
    {
        CellNode.L_Select.Instance.Visible = false;
    }

    public override void OnSetData(EditorToolBase data)
    {
        CellNode.Instance.TextureNormal = ResourceManager.LoadTexture2D(data.Icon);
        CellNode.Instance.TooltipText = data.TipText;
    }

    public override void Process(float delta)
    {
        if (Grid.SelectIndex == Index)
        {
            Data.Process(delta);
        }
    }

    public override bool CanSelect()
    {
        return Data.CanSelect;
    }

    public override void OnSelect()
    {
        CellNode.L_Select.Instance.Visible = true;
        Data.EditorTileMap.MapInputEvent += Data.OnMapInputEvent;
        Data.EditorTileMap.MapDrawToolEvent += Data.OnMapDrawTool;
        Data.OnSetSelected(true);
    }

    public override void OnUnSelect()
    {
        CellNode.L_Select.Instance.Visible = false;
        Data.EditorTileMap.MapInputEvent -= Data.OnMapInputEvent;
        Data.EditorTileMap.MapDrawToolEvent -= Data.OnMapDrawTool;
        Data.OnSetSelected(false);
    }

    public override void OnClick()
    {
        Data.OnClick();
    }

}