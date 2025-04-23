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
    /// 拖拽零件事件，参数类型：<see cref="DropPartData"/>
    /// </summary>
    public const string OnDropPartEventName = "OnDropPart";
    
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
        PartPackGrid.EventPackage.AddEventListener(OnDropPartEventName, OnDropPart);

        WeaponListGrid = CreateUiGrid<WeaponItem, Weapon, WeaponListCell>(S_WeaponItem);
        WeaponListGrid.SetColumns(1);
        WeaponListGrid.SetCellOffset(new Vector2I(0, 16));
    }

    private void OnDropPart(object obj)
    {
        var player = GameApplication.Instance.DungeonManager.CurrWorld?.Player;
        if (player == null)
        {
            return;
        }

        var param = (DropPartData)obj;
        if (param.Data == null)
        {
            player.PartPropPack.Remove(param.Index);
        }
        else
        {
            player.PartPropPack.Set(param.Index, param.Data);
        }
    }

    public override void OnShowUi()
    {
        GameApplication.Instance.Cursor.AddUiLayer(GetInstanceId());
        if (RoomUiPanel != null)
        {
            RoomUiPanel.OcclusionCount++;
        }
    }

    public override void OnHideUi()
    {
        GameApplication.Instance.Cursor.RemoveUiLayer(GetInstanceId());
        if (RoomUiPanel != null)
        {
            RoomUiPanel.OcclusionCount--;
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
}
