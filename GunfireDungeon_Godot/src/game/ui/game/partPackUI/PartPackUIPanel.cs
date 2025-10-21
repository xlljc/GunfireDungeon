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
    public RoomUIPanel RoomUiPanel;
    
    /// <summary>
    /// 上方零件背包网格
    /// </summary>
    public UiGrid<PartPackItem, PartPropCellData> PartPackGrid;
    
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

    private PartPackCell _prevSelectPart;
    private PartPackCell _currSelectPart;
    
    // ----------------------------

    public override void OnCreateUi()
    {
        if (ParentUi is RoomUIPanel uiPanel)
        {
            RoomUiPanel = uiPanel;
        }

        WeaponCellOriginSize = S_WeaponItem.Instance.CustomMinimumSize;
        PartListCellHeight = S_PartListItem.Instance.CustomMinimumSize.Y;
        
        PartPackGrid = CreateUiGrid<PartPackItem, PartPropCellData, PartPackCell>(S_PartPackItem);
        PartPackGrid.SetAutoColumns(true);
        PartPackGrid.SetCellOffset(CellOffset);

        WeaponListGrid = CreateUiGrid<WeaponItem, Weapon, WeaponListCell>(S_WeaponItem);
        WeaponListGrid.SetColumns(1);
        WeaponListGrid.SetCellOffset(new Vector2I(0, 16));
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

    public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
        if (data.Obj == null)
        {
            return false;
        }
        // 判断是否可以放置
        if (data.Obj is GodotRefValue<PartPropCellData> dropDataValue)
        {
            return dropDataValue.Value.OriginPartProp != null;
            // return dropData.Slot.Index != Index || dropData != Data;
        }

        return false;
    }
    
    public override void _DropData(Vector2 atPosition, Variant data)
    {
        if (data.Obj == null)
        {
            return;
        }
        if (data.Obj is GodotRefValue<PartPropCellData> dropDataValue)
        {
            // 被拖拽的对象从原位置移除
            var fromPropData = dropDataValue.Value;
            var fromSlot = fromPropData.Slot;
            fromSlot.Remove();
            
            var player = GameApplication.Instance.DungeonManager.CurrWorld?.Player;
            if (player != null)
            {
                fromPropData.OriginPartProp.ThrowProp(player);
            }
            else
            {
                fromPropData.OriginPartProp.Throw(8, 0, Vector2.Zero, 0);
            }
        }
    }

    public override void Process(float delta)
    {
        var application = GameApplication.Instance;
        if (application.DungeonManager.CurrWorld.Pause)
        {
            return;
        }

        var player = application.DungeonManager.CurrWorld?.Player;
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
                    if (player.PartPropPack.Get(i) != PartPackGrid.GetData(i).OriginPartProp)
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
            
            
            DoSelectItem();
        }
    }

    private void DoSelectItem()
    {
        // 移动选中逻辑
        if (Input.IsActionJustPressed(InputAction.UiAccept)) // 点击选择/放置
        {

        }
        else //点击移动
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
    
    private void RefreshWeaponList(List<Weapon> list)
    {
        WeaponListGrid.SetDataList(list);
    }

    public void RefreshPartPack(PartPackage package)
    {
        var temp = new List<PartPropCellData>();
        var i = 0;
        foreach (var o in package)
        {
            temp.Add(new PartPropCellData(new PartPropSlot(i++, package), (PartProp)o));
        }

        PartPackGrid.SetDataList(temp);

        // 重新选中第一个零件
        if (_currSelectPart == null)
        {
            DoFindFirstSelectPart();
        }
    }

    private void DoFindFirstSelectPart()
    {
        if (_currSelectPart != null)
        {
            _currSelectPart.CellNode.Instance.SetSelect(false);
        }

        _currSelectPart = FindFirstSelectPart();
        if (_currSelectPart != null)
        {
            _currSelectPart.CellNode.Instance.SetSelect(true);
        }
    }
    
    private PartPackCell FindFirstSelectPart()
    {
        var uiCell = PartPackGrid.Find(cell => cell.Data != null);
        if (uiCell != null)
        {
            return (PartPackCell)uiCell;
        }
        
        // 再遍历寻找武器上的插槽
        var weapons = WeaponListGrid.GetAllCell();
        foreach (var item1 in weapons) //遍历装备的武器
        {
            var weaponListCells = item1 as WeaponListCell;
            if (weaponListCells != null && weaponListCells.Data != null)
            {
                var partListcells = weaponListCells.PartListGrid.GetAllCell();
                foreach (var item2 in partListcells) // 遍历武器上的零件列表
                {
                    var partList = item2 as PartListCell;
                    if (partList != null && partList.Data != null)
                    {
                        var partCells = partList.PartGrid.GetAllCell();
                        foreach (var partCell in partCells)
                        {
                            if (partCell != null && partCell.Data != null)
                            {
                                return (PartPackCell)partCell;
                            }
                        }
                    }
                }
            }
        }

        return null;
    }
    
    private void DoJoypadLeft()
    {
        if (_currSelectPart == null)
        {
            DoFindFirstSelectPart();
        }
        else
        {
            var uiGrid = _currSelectPart.Grid;
            int startIndex = _currSelectPart.Index - 1;
            var nextCell = FindValidCell(uiGrid, startIndex, false);
            if (nextCell != null)
            {
                _currSelectPart.CellNode.Instance.SetSelect(false);
                _currSelectPart = nextCell;
                _currSelectPart.CellNode.Instance.SetSelect(true);
            }
            // 如果没找到，保持当前（什么都不做）
        }
    }
    
    private void DoJoypadRight()
    {
        if (_currSelectPart == null)
        {
            DoFindFirstSelectPart();
        }
        else
        {
            var uiGrid = _currSelectPart.Grid;
            int startIndex = _currSelectPart.Index + 1;
            var nextCell = FindValidCell(uiGrid, startIndex, true);
            if (nextCell != null)
            {
                _currSelectPart.CellNode.Instance.SetSelect(false);
                _currSelectPart = nextCell;
                _currSelectPart.CellNode.Instance.SetSelect(true);
            }
            // 如果没找到，保持当前（什么都不做）
        }
    }
    
    private void DoJoypadUp()
    {
        if (_currSelectPart == null)
        {
            DoFindFirstSelectPart();
        }
        else
        {
            var grids = GetAllGrids();
            var currentGrid = _currSelectPart.Grid;
            int currentGridIndex = grids.IndexOf(currentGrid);
            if (currentGridIndex == -1) return;

            for (int i = currentGridIndex - 1; i >= 0; i--)
            {
                var nextGrid = grids[i];
                var nextCell = FindValidCellInGrid(nextGrid, _currSelectPart.Index, true); // 往后查找
                if (nextCell != null)
                {
                    _currSelectPart.CellNode.Instance.SetSelect(false);
                    _currSelectPart = nextCell;
                    _currSelectPart.CellNode.Instance.SetSelect(true);
                    return;
                }
            }
            // 如果没找到，保持当前
        }
    }
    
    private void DoJoypadDown()
    {
        if (_currSelectPart == null)
        {
            DoFindFirstSelectPart();
        }
        else
        {
            var grids = GetAllGrids();
            var currentGrid = _currSelectPart.Grid;
            int currentGridIndex = grids.IndexOf(currentGrid);
            if (currentGridIndex == -1) return;

            for (int i = currentGridIndex + 1; i < grids.Count; i++)
            {
                var nextGrid = grids[i];
                var nextCell = FindValidCellInGrid(nextGrid, _currSelectPart.Index, false); // 往前查找
                if (nextCell != null)
                {
                    _currSelectPart.CellNode.Instance.SetSelect(false);
                    _currSelectPart = nextCell;
                    _currSelectPart.CellNode.Instance.SetSelect(true);
                    return;
                }
            }
            // 如果没找到，保持当前
        }
    }

    private PartPackCell FindValidCell(UiGrid<PartPackItem, PartPropCellData> uiGrid, int startIndex, bool forward)
    {
        int count = uiGrid.Count;
        PartPackCell result = null;
        if (forward)
        {
            // 从 startIndex 开始往后查找
            for (int i = startIndex; i < count; i++)
            {
                var cell = uiGrid.GetCell(i);
                if (cell != null && cell.Data != null && cell.Data.OriginPartProp != null)
                {
                    result = (PartPackCell)cell;
                    break;
                }
            }
            // 如果没找到，从 0 开始查找
            if (result == null)
            {
                for (int i = 0; i < startIndex; i++)
                {
                    var cell = uiGrid.GetCell(i);
                    if (cell != null && cell.Data != null && cell.Data.OriginPartProp != null)
                    {
                        result = (PartPackCell)cell;
                        break;
                    }
                }
            }
        }
        else
        {
            // 从 startIndex 开始往前查找
            for (int i = startIndex; i >= 0; i--)
            {
                var cell = uiGrid.GetCell(i);
                if (cell != null && cell.Data != null && cell.Data.OriginPartProp != null)
                {
                    result = (PartPackCell)cell;
                    break;
                }
            }
            // 如果没找到，从末尾开始查找
            if (result == null)
            {
                for (int i = count - 1; i > startIndex; i--)
                {
                    var cell = uiGrid.GetCell(i);
                    if (cell != null && cell.Data != null && cell.Data.OriginPartProp != null)
                    {
                        result = (PartPackCell)cell;
                        break;
                    }
                }
            }
        }
        return result;
    }
    
    private List<UiGrid<PartPackItem, PartPropCellData>> GetAllGrids()
    {
        var grids = new List<UiGrid<PartPackItem, PartPropCellData>>();
        grids.Add(PartPackGrid);
        foreach (var weaponCell in WeaponListGrid.GetAllCell())
        {
            var weaponListCell = weaponCell as WeaponListCell;
            if (weaponListCell != null && weaponListCell.Data != null)
            {
                foreach (var partListCell in weaponListCell.PartListGrid.GetAllCell())
                {
                    var partList = partListCell as PartListCell;
                    if (partList != null && partList.Data != null)
                    {
                        grids.Add(partList.PartGrid);
                    }
                }
            }
        }
        return grids;
    }

    private PartPackCell FindValidCellInGrid(UiGrid<PartPackItem, PartPropCellData> grid, int startIndex, bool forward)
    {
        if (forward)
        {
            // 从 startIndex 往后查找
            for (int i = startIndex; i < grid.Count; i++)
            {
                var cell = grid.GetCell(i);
                if (cell != null && cell.Data != null && cell.Data.OriginPartProp != null)
                {
                    return (PartPackCell)cell;
                }
            }
            // 从 0 到 startIndex-1
            for (int i = 0; i < startIndex; i++)
            {
                var cell = grid.GetCell(i);
                if (cell != null && cell.Data != null && cell.Data.OriginPartProp != null)
                {
                    return (PartPackCell)cell;
                }
            }
        }
        else
        {
            // 从 startIndex 往前查找
            for (int i = startIndex; i >= 0; i--)
            {
                var cell = grid.GetCell(i);
                if (cell != null && cell.Data != null && cell.Data.OriginPartProp != null)
                {
                    return (PartPackCell)cell;
                }
            }
            // 从末尾到 startIndex+1
            for (int i = grid.Count - 1; i > startIndex; i--)
            {
                var cell = grid.GetCell(i);
                if (cell != null && cell.Data != null && cell.Data.OriginPartProp != null)
                {
                    return (PartPackCell)cell;
                }
            }
        }
        return null;
    }
}
