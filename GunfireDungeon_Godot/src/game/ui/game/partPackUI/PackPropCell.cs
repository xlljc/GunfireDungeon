using System;
using DsUi;
using Godot;
using Godot.Collections;

namespace UI.game.PartPackUI;

/// <summary>
/// 零件Cell
/// </summary>
public class PartPackCell : UiCell<PartPackUI.PartPackItem, PartPropCellData>
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
    
    public override void OnSetData(PartPropCellData data)
    {
        if (data != null && data.OriginPartProp != null)
        {
            CellNode.L_PartIcon.Instance.Visible = true;
            CellNode.L_PartIcon.Instance.Texture = data.OriginPartProp.Icon;
        }
        else
        {
            CellNode.L_PartIcon.Instance.Visible = false;
        }
    }

    public void OnFocusEntered()
    {
        if (Data == null || Data.OriginPartProp == null)
        {
            CellNode.UiPanel.SetCurrentSelectPart(null);
        }
        else
        {
            CellNode.UiPanel.SetCurrentSelectPart(this);
        }
    }

    public void OnFocusExited()
    {
        CellNode.UiPanel.SetCurrentSelectPart(null);
    }
    
    private Variant _GetDragData(Vector2 atPosition)
    {
        if (Data != null && Data.OriginPartProp != null)
        {
            var sprite = new TextureRect();
            sprite.Scale = Vector2.One * GameApplication.Instance.PixelScale;
            sprite.Texture = Data.OriginPartProp.Icon;
            CellNode.Instance.SetDragPreview(sprite);
        }
        else
        {
            return new Variant();
        }
        
        return new GodotRefValue<PartPropCellData>(Data);
    }
    
    
    private bool _CanDropData(Vector2 atPosition, Variant data)
    {
        if (Data == null)
        {
            return false;
        }

        if (data.Obj == null)
        {
            return false;
        }
        // 判断是否可以放置
        if (data.Obj is GodotRefValue<PartPropCellData> dropDataValue)
        {
            var dropData = dropDataValue.Value;
            return dropData != Data;
            // return dropData.Slot.Index != Index || dropData != Data;
        }

        return false;
    }

    private void _DropData(Vector2 atPosition, Variant data)
    {
        if (Data == null)
        {
            return;
        }
        if (data.Obj is GodotRefValue<PartPropCellData> dropDataValue)  
        {
            // 被拖拽的对象从原位置移除
            var fromPropData = dropDataValue.Value;
            var fromSlot = fromPropData.Slot;
            fromSlot.Remove();

            if (Data.OriginPartProp != null)
            {
                Data.Slot.Remove();
                // 当前位置的对象放入被拖拽对象的原位置
                fromSlot.Set(Data.OriginPartProp);
            }
            
            Data.Slot.Set(fromPropData.OriginPartProp);
        }
    }

}