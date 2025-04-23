using System;
using DsUi;
using Godot;
using Godot.Collections;

namespace UI.game.PartPackUI;

/// <summary>
/// 零件Cell
/// </summary>
public class PartPackCell : UiCell<PartPackUI.PartPackItem, PartProp>
{
    public override void OnInit()
    {
        CellNode.L_PartIcon.Instance.Visible = false;
        CellNode.Instance.SetDragForwarding(
            Callable.From(new Func<Vector2, Variant>(_GetDragData)),
            Callable.From(new Func<Vector2, Variant, bool>(_CanDropData)),
            Callable.From(new Action<Vector2, Variant>(_DropData))
        );
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
    
    private Variant _GetDragData(Vector2 atPosition)
    {
        if (Data != null)
        {
            var sprite = new TextureRect();
            sprite.Scale = Vector2.One * GameApplication.Instance.PixelScale;
            sprite.Texture = Data.Icon;
            CellNode.Instance.SetDragPreview(sprite);
        }
        else
        {
            return new Variant();
        }
        return new Dictionary()
        {
            ["Index"] = Index,
            ["UiGrid"] = new GodotRefValue(Grid),
        };
    }
    
    
    private bool _CanDropData(Vector2 atPosition, Variant data)
    {
        if (data.VariantType != Variant.Type.Dictionary)
        {
            return false;
        }
        var dictionary = data.AsGodotDictionary();
        if (!dictionary.ContainsKey("Index"))
        {
            return false;
        }

        var index = dictionary["Index"].AsInt32();
        var grid = (UiGrid<PartPackUI.PartPackItem, PartProp>)dictionary["UiGrid"].As<GodotRefValue>().Value;
        return index != Index || grid != Grid;
    }

    private void _DropData(Vector2 atPosition, Variant data)
    {
        var dic = data.AsGodotDictionary();
        var targetIndex = dic["Index"].AsInt32();
        var targetGrid = (UiGrid<PartPackUI.PartPackItem, PartProp>)dic["UiGrid"].As<GodotRefValue>().Value;
        var targetData = targetGrid.GetData(targetIndex);
        
        Grid.EventPackage.EmitEvent(PartPackUIPanel.OnDropPartEventName, new DropPartData(Index, targetData));
        targetGrid.EventPackage.EmitEvent(PartPackUIPanel.OnDropPartEventName, new DropPartData(targetIndex, Data));
    }
    
}