using System.Collections.Generic;
using DsUi;
using Godot;
using UI.game.RoomUI;

namespace UI.game.PartPackUI;

/// <summary>
/// 零件背包面板
/// </summary>
public partial class PartPackUIPanel : PartPackUI
{
    /// <summary>
    /// 放置零件事件，参数类型：<see cref="DropPartData"/>
    /// </summary>
    public const string OnPutPartEventName = "OnPutPart";
    
    /// <summary>
    /// 移除零件事件，参数类型：<see cref="int"/>
    /// </summary>
    public const string OnRemovePartEventName = "OnRemovePart";

    private class PartPropData
    {
        public PartPackSlot Slot;
        public PartProp Data;
    }
    
    public RoomUIPanel RoomUiPanel;
    
    /// <summary>
    /// 上方零件背包网格
    /// </summary>
    public UiGrid<PartPackItem, PartProp> PartPackGrid;
    
    /// <summary>
    /// 武器列表
    /// </summary>
    public UiGrid<WeaponItem, Weapon> WeaponListGrid;
    
    public float PartListCellHeight { get; private set; } = 106;
    public Vector2 WeaponCellOriginSize { get; private set; } = new Vector2(560, 124f);
    public Vector2 WeaponCellPartPosition { get; } = new Vector2(107, 11);
    public Vector2I CellOffset { get; } = new Vector2I(8, 8);
    
    private List<Weapon> _cahceWeapons = new List<Weapon>();
    
    // -------- 手柄操作相关 --------

    private PartPropData _prevSelectPart;
    private PartPropData _currSelectPart;
    
    // ----------------------------

    public override void OnCreateUi()
    {
        if (ParentUi is RoomUIPanel uiPanel)
        {
            RoomUiPanel = uiPanel;
        }

        WeaponCellOriginSize = S_WeaponItem.Instance.CustomMinimumSize;
        PartListCellHeight = S_PartListItem.Instance.CustomMinimumSize.Y;
        
        PartPackGrid = CreateUiGrid<PartPackItem, PartProp, PartPackCell>(S_PartPackItem);
        PartPackGrid.SetAutoColumns(true);
        PartPackGrid.SetCellOffset(CellOffset);
        PartPackGrid.EventPackage.AddEventListener(OnPutPartEventName, OnPutPart);
        PartPackGrid.EventPackage.AddEventListener(OnRemovePartEventName, OnRemovePart);

        WeaponListGrid = CreateUiGrid<WeaponItem, Weapon, WeaponListCell>(S_WeaponItem);
        WeaponListGrid.SetColumns(1);
        WeaponListGrid.SetCellOffset(new Vector2I(0, 16));
        
        AddEventListener(EventEnum.OnChangeJoypadInputMode, (data) => OnChangeJoypadInputMode(data is bool flag && flag));
        OnChangeJoypadInputMode(InputManager.IsJoystickInput);
    }


    public override void OnShowUi()
    {
        InputManager.AddBlockageMarking(GetInstanceId());
        if (RoomUiPanel != null)
        {
            RoomUiPanel.OcclusionCount++;
        }
    }

    public override void OnHideUi()
    {
        InputManager.RemoveBlockageMarking(GetInstanceId());
        if (RoomUiPanel != null)
        {
            RoomUiPanel.OcclusionCount--;
        }
    }
    
    
    // 切换手柄输入模式
    private void OnChangeJoypadInputMode(bool flag)
    {
        if (flag) // 切换到手柄
        {
            FindFirstSelectPart();
        }
        else // 取消手柄
        {
            _prevSelectPart?.Slot.SetSelect(false);
            _currSelectPart?.Slot.SetSelect(false);
            _prevSelectPart = null;
            _currSelectPart = null;
        }
    }
    
    private void OnPutPart(object obj)
    {
        var player = GameApplication.Instance.DungeonManager.CurrWorld?.Player;
        if (player == null)
        {
            return;
        }

        var param = (DropPartData)obj;
        player.PartPropPack.Set(param.Index, param.Data);
    }
    
    private void OnRemovePart(object obj)
    {
        var player = GameApplication.Instance.DungeonManager.CurrWorld?.Player;
        player?.PartPropPack.Remove((int)obj);
    }

    public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
        return data.VariantType == Variant.Type.Dictionary && data.AsGodotDictionary().ContainsKey("Index");
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        // 触发丢弃
        var dic = data.AsGodotDictionary();
        var targetIndex = dic["Index"].AsInt32();
        var targetGrid = (UiGrid<PartPackUI.PartPackItem, PartProp>)dic["UiGrid"].As<GodotRefValue>().Value;
        targetGrid.EventPackage.EmitEvent(OnRemovePartEventName, targetIndex);
        
        var targetData = targetGrid.GetData(targetIndex);
        var player = GameApplication.Instance.DungeonManager.CurrWorld?.Player;
        if (player != null)
        {
            targetData.ThrowProp(player);
        }
        else
        {
            targetData.Throw(8, 0, Vector2.Zero, 0);
        }
    }

    public override void Process(float delta)
    {
        var player = GameApplication.Instance.DungeonManager.CurrWorld?.Player;
        if (player != null)
        {
            //检测零件是否变化
            var count = player.PartPropPack.Count;
            if (count != PartPackGrid.Count) //长度变化
            {
                RefreshPartPack(player.PartPropPack);
            }
            else //内容变化
            {
                for (int i = 0; i < count; i++)
                {
                    if (player.PartPropPack.Get(i) != PartPackGrid.GetData(i))
                    {
                        RefreshPartPack(player.PartPropPack);
                        break;
                    }
                }
            }
            
            //检测武器是否变化
            _cahceWeapons.Clear();
            foreach (Weapon weapon in player.WeaponPack)
            {
                if (weapon != null)
                {
                    _cahceWeapons.Add(weapon);
                }
            }

            if (_cahceWeapons.Count != WeaponListGrid.Count) //长度变化
            {
                RefreshWeaponList(_cahceWeapons);
            }
            else
            {
                for (var i = 0; i < _cahceWeapons.Count; i++)
                {
                    var weapon = _cahceWeapons[i];
                    if (WeaponListGrid.GetData(i) != weapon) //内容变化
                    {
                        RefreshWeaponList(_cahceWeapons);
                        break;
                    }
                }
            }

            if (InputManager.IsJoystickInput) //手柄操作处理
            {
                if (Input.IsActionJustPressed(InputAction.UiLeft))
                {
                    DoJoypadLeft();
                }
                else if (Input.IsActionJustPressed(InputAction.UiRight))
                {
                    DoJoypadRight();
                }
                else if (Input.IsActionJustPressed(InputAction.UiUp))
                {
                    DoJoypadUp();
                }
                else if (Input.IsActionJustPressed(InputAction.UiDown))
                {
                    DoJoypadDown();
                }
            }
        }
    }
    
    private void RefreshWeaponList(List<Weapon> list)
    {
        WeaponListGrid.SetDataList(list);
    }

    public void RefreshPartPack(PartPackage package)
    {
        PartPackGrid.SetDataList(package.ToList());
    }

    private void FindFirstSelectPart()
    {
        // 先找 PartPackGrid
        var uiCell = PartPackGrid.Find(cell => cell.Data != null);
        if (uiCell == null)
        {
            // 再遍历寻找武器上的插槽
            var weapons = WeaponListGrid.GetAllCell();
            foreach (var weapon in weapons)
            {
                var partListCell = weapon as WeaponListCell;
                if (partListCell != null)
                {
                    // var temp = partListCell.PartListGrid.get
                    
                }
            }
        }
    }
    
    private void DoJoypadLeft()
    {
        
    }
    
    private void DoJoypadRight()
    {
        
    }
    
    private void DoJoypadUp()
    {
        
    }
    
    private void DoJoypadDown()
    {
        
    }
}
