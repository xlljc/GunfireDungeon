using System.Collections.Generic;
using Godot;

using DsUi;

namespace UI.game.RoomUI;

public partial class LifeBarHandler : Control, IUiNodeScript
{

    private RoomUI.LifeBar _bar;
    private EventFactory<EventEnum> _eventFactory;
    private bool _refreshHpFlag = false;
    private bool _refreshGoldFlag = false;

    private Role _player;

    public void SetUiNode(IUiNode uiNode)
    {
        _bar = (RoomUI.LifeBar)uiNode;
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

        var container = _bar.L_Life.L_HBoxContainer;
        container.L_LifeProgressBar.Instance.MaxValue = player.MaxHp;
        container.L_LifeProgressBar.Instance.Value = player.Hp;
        container.L_ShieldProgressBar.Instance.MaxValue = player.MaxShield;
        container.L_ShieldProgressBar.Instance.Value = player.Shield;
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