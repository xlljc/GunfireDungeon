using System;
using DsUi;
using Godot;
using Godot.Collections;

namespace UI.game.PartPackUI;

/// <summary>
/// 零件Cell
/// </summary>
public class PartPackCell : UiCell<PartPackUI.PartPackItem, PartItemData>
{
    public override void OnInit()
    {
        CellNode.L_PartIcon.Instance.Visible = false;
        CellNode.Instance.SetDragForwarding(
            Callable.From(new Func<Vector2, Variant>(_GetDragData)),
            Callable.From(new Func<Vector2, Variant, bool>(_CanDropData)),
            Callable.From(new Action<Vector2, Variant>(_DropData))
        );

        CellNode.Instance.MouseEntered += OnFocusEntered;
        CellNode.Instance.MouseExited += OnFocusExited;
    }
    
    public override void OnSetData(PartItemData data)
    {
        if (data != null && data.PartProp != null)
        {
            CellNode.L_PartIcon.Instance.Visible = true;
            CellNode.L_PartIcon.Instance.Texture = data.PartProp.Icon;
        }
        else
        {
            CellNode.L_PartIcon.Instance.Visible = false;
        }
    }

    public void OnFocusEntered()
    {
        if (Data == null || Data.PartProp == null)
        {
            return;
        }
        CommonUiManager.ShowPartTips(Data.PartProp);
    }

    public void OnFocusExited()
    {
        if (Data == null || Data.PartProp == null)
        {
            return;
        }
        CommonUiManager.HidePartTips();
    }
    
    private Variant _GetDragData(Vector2 atPosition)
    {
        if (Data != null && Data.PartProp != null)
        {
            var sprite = new TextureRect();
            sprite.Scale = Vector2.One * GameApplication.Instance.PixelScale;
            sprite.Texture = Data.PartProp.Icon;
            CellNode.Instance.SetDragPreview(sprite);
        }
        else
        {
            return new Variant();
        }
        // 改这里，变成指定对象数据
        // return new Dictionary()
        // {
        //     ["Index"] = Index,
        //     ["UiGrid"] = new GodotRefValue(Grid),
        // };
        return new GodotRefValue<DropPartData>(new DropPartData(Index, Data));
    }
    
    
    private bool _CanDropData(Vector2 atPosition, Variant data)
    {
        if (Data == null)
        {
            return false;
        }
        // 判断是否可以放置
        if (data.Obj is GodotRefValue<DropPartData> dropDataValue)
        {
            var dropData = dropDataValue.Value;
            return dropData.Index != Index || dropData.Data != Data;
        }

        return false;
    }

    private void _DropData(Vector2 atPosition, Variant data)
    {
        if (Data == null)
        {
            return;
        }
        if (data.Obj is GodotRefValue<DropPartData> dropDataValue)  
        {
            // 被拖拽的对象从原位置移除
            var targetPropData = dropDataValue.Value;
            var targetProp = targetPropData.Data.PartProp;
            targetPropData.Data.DoRemove(targetPropData.Index);
            //
            // var currProp = Data.PartProp;
            // if (currProp != null)
            // {
            //     // 移除当前位置的对象
            //     Data.DoRemove(Index);
            //     // 放入被拖拽的对象到原位置
            //     targetPropData.Data.DoPut(targetPropData.Index, currProp);
            // }
            //
            // // 当前位置放置对象
            // Data.DoPut(Index, targetProp);
        }

        // var dic = data.AsGodotDictionary();
        // var targetIndex = dic["Index"].AsInt32();
        // var targetGrid = (UiGrid<PartPackUI.PartPackItem, PartItemData>)dic["UiGrid"].As<GodotRefValue>().Value;
        // var targetData = targetGrid.GetData(targetIndex);
        //
        // Grid.EventPackage.EmitEvent(PartPackUIPanel.OnRemovePartEventName, Index);
        // targetGrid.EventPackage.EmitEvent(PartPackUIPanel.OnRemovePartEventName, targetIndex);
        //
        // if (targetData != null)
        // {
        //     Grid.EventPackage.EmitEvent(PartPackUIPanel.OnPutPartEventName, new DropPartData(Index, targetData));
        // }
        //
        // if (Data != null)
        // {
        //     targetGrid.EventPackage.EmitEvent(PartPackUIPanel.OnPutPartEventName, new DropPartData(targetIndex, Data));
        // }
    }

}