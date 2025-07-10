using System.Collections.Generic;
using Godot;
using Godot.Collections;

/// <summary>
/// 商店老板
/// </summary>
public partial class ShopBoss : AiRole
{
    [Export]
    public PackedScene ShopItemSlot;

    [Export]
    public Array<Marker2D> SlotMarkerList;

    private List<ShopItemSlot> _slot = new List<ShopItemSlot>();
    
    public override void OnInit()
    {
        base.OnInit();
        SetAttackDesire(false); //默认不攻击
        SetMoveDesire(false); //默认不攻击
    }

    public override void OnCreateWithMark(RoomPreinstall roomPreinstall, ActivityMark activityMark)
    {
        if (SlotMarkerList != null)
        {
            var layer = World.GetRoomLayer(RoomLayerEnum.NormalLayer);
            foreach (var marker2D in SlotMarkerList)
            {
                var position = marker2D.GlobalPosition;
                marker2D.Reparent(layer, false);
                marker2D.Position = position;
            
                var activityBase = World.RandomPool.GetRandomProp();
                var itemSlot = ShopItemSlot.Instantiate<ShopItemSlot>();
                _slot.Add(itemSlot);
                marker2D.AddChild(itemSlot);
                itemSlot.InitItem(activityBase);
            }
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        if (_slot != null)
        {
            foreach (var shopItemSlot in _slot)
            {
                shopItemSlot.Destroy();
            }

            _slot = null;
        }
    }
}