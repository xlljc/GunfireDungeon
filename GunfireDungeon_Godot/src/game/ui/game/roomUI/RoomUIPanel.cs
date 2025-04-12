

using DsUi;
using UI.game.BottomTips;
using UI.game.RoomMap;
using UI.game.WeaponRoulette;

namespace UI.game.RoomUI;

/// <summary>
/// 地牢房间中的ui
/// </summary>
public partial class RoomUIPanel : RoomUI
{
    /// <summary>
    /// 房间小地图
    /// </summary>
    public RoomMapPanel RoomMap { get; private set; }
    
    private ReloadBarHandler _reloadBar;
    private InteractiveTipBarHandler _interactiveTipBar;
    private WeaponBarHandler _weaponBar;
    private ActivePropBarHandler _activePropBar;
    private LifeBarHandler _lifeBar;
    
    private EventFactory _factory;
    
    public override void OnCreateUi()
    {
        _reloadBar = new ReloadBarHandler(L_ReloadBar);
        _interactiveTipBar = new InteractiveTipBarHandler(L_InteractiveTipBar);
        _weaponBar = new WeaponBarHandler(L_Control.L_WeaponBar);
        _activePropBar = new ActivePropBarHandler(L_Control.L_ActivePropBar);
        _lifeBar = new LifeBarHandler(L_Control.L_LifeBar);
        
        RoomMap = OpenNestedUi<RoomMapPanel>(UiManager.UiName.Game_RoomMap);
    }

    public override void OnShowUi()
    {
        _reloadBar.OnShow();
        _interactiveTipBar.OnShow();
        _weaponBar.OnShow();
        _activePropBar.OnShow();
        _lifeBar.OnShow();

        _factory = EventManager.CreateEventFactory();
        _factory.AddEventListener(EventEnum.OnPlayerPickUpProp, OnPlayerPickUpProp);

        //大厅中不显示小地图
        if (World.Current is Hall)
        {
            RoomMap.HideUi();
        }
        else
        {
            RoomMap.ShowUi();
        }
    }

    public override void OnHideUi()
    {
        _reloadBar.OnHide();
        _interactiveTipBar.OnHide();
        _weaponBar.OnHide();
        _activePropBar.OnHide();
        _lifeBar.OnHide();
        
        _factory.RemoveAllEventListener();
        _factory = null;
    }

    public override void Process(float delta)
    {
        _weaponBar.Process(delta);
        _activePropBar.Process(delta);
        _lifeBar.Process(delta);
        
        
    }

    //玩家拾起道具, 弹出提示
    private void OnPlayerPickUpProp(object propObj)
    {
        var prop = (PropActivity)propObj;
        var message = $"{prop.ActivityBase.Name}\n{prop.ActivityBase.Intro}";
        BottomTipsPanel.ShowTips(prop.GetDefaultTexture(), message);
    }
}