using System.Collections.Generic;
using Godot;

using DsUi;

namespace UI.game.RoomUI;

public partial class LifeBarHandler : Control, IUiNodeScript
{

    private RoomUI.LifeBar _bar;
    private UiGrid<RoomUI.Life, LifeIconEnum> _grid;
    private EventFactory<EventEnum> _eventFactory;
    private bool _refreshHpFlag = false;
    private bool _refreshGoldFlag = false;

    private Role _player;

    public void SetUiNode(IUiNode uiNode)
    {
        _bar = (RoomUI.LifeBar)uiNode;
        var uiNodeLife = _bar.L_Life;

        _grid = _bar.UiPanel.CreateUiGrid<RoomUI.Life, LifeIconEnum, LifeCell>(uiNodeLife);
        _grid.SetAutoColumns(true);
        _grid.SetHorizontalExpand(true);
        _grid.SetCellOffset(new Vector2I(1, 2));

        _bar.UiPanel.OnShowUiEvent += OnShow;
        _bar.UiPanel.OnHideUiEvent += OnHide;
    }
    
    public void OnShow()
    {
        _eventFactory = EventManager.CreateEventFactory();
        _eventFactory.AddEventListener(EventEnum.OnPlayerHpChange, o => RefreshLife());
        _eventFactory.AddEventListener(EventEnum.OnPlayerMaxHpChange, o => RefreshLife());
        _eventFactory.AddEventListener(EventEnum.OnPlayerShieldChange, o => RefreshLife());
        _eventFactory.AddEventListener(EventEnum.OnPlayerMaxShieldChange, o => RefreshLife());
        _eventFactory.AddEventListener(EventEnum.OnPlayerGoldChange, o => RefreshGold());
        RefreshLife();
        RefreshGold();
    }

    public void OnHide()
    {
        _eventFactory.RemoveAllEventListener();
    }

    public override void _Process(double delta)
    {
        if (_bar == null || !_bar.UiPanel.IsOpen)
        {
            return;
        }
        if (!_refreshGoldFlag && World.Current != null && _player != World.Current.Player)
        {
            _player = World.Current.Player;
            _refreshHpFlag = true;
        }
        
        if (_refreshHpFlag)
        {
            _refreshHpFlag = false;
            HandlerRefreshLife();
        }

        if (_refreshGoldFlag)
        {
            _refreshGoldFlag = false;
            HandlerRefreshGold();
        }
    }

    public void RefreshGold()
    {
        _refreshGoldFlag = true;
    }
    
    public void RefreshLife()
    {
        _refreshHpFlag = true;
    }

    private void HandlerRefreshLife()
    {
        var player = World.Current.Player;
        if (player == null)
        {
            return;
        }
        if (player.MaxHp % 2 != 0)
        {
            Debug.LogError("玩家血量不是偶数!");
        }
        
        var list = new List<LifeIconEnum>();
        for (var i = 0; i < player.MaxHp / 2; i++)
        {
            if (player.Hp >= i * 2 + 2)
            {
                list.Add(LifeIconEnum.FullHeart);
            }
            else if (player.Hp >= i * 2 + 1)
            {
                list.Add(LifeIconEnum.HalfHeart);
            }
            else
            {
                list.Add(LifeIconEnum.EmptyHeart);
            }
        }

        for (var i = 0; i < player.MaxShield; i++)
        {
            if (player.Shield >= i + 1)
            {
                list.Add(LifeIconEnum.FullShield);
            }
            else
            {
                list.Add(LifeIconEnum.EmptyShield);
            }
        }
        
        //var maxHp
        _grid.SetDataList(list.ToArray());
    }
    
    private void HandlerRefreshGold()
    {
        var player = World.Current.Player;
        if (player == null)
        {
            return;
        }

        _bar.L_Gold.L_GoldText.Instance.Text = player.RoleState.Gold.ToString();
    }

    public void OnDestroy()
    {
        
    }
}