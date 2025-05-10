

using DsUi;
using UI.game.BottomTips;
using UI.game.PartPackUI;
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
    
    /// <summary>
    /// 武器零件Ui
    /// </summary>
    public PartPackUIPanel PartPack { get; private set; }

    /// <summary>
    /// 遮挡Ui数量
    /// </summary>
    public int OcclusionCount { get; set; }
    
    private EventFactory<EventEnum> _factory;
    
    public override void OnCreateUi()
    {
        RoomMap = OpenNestedUi<RoomMapPanel>(UiManager.UiName.Game_RoomMap);
        PartPack = OpenNestedUi<PartPackUIPanel>(UiManager.UiName.Game_PartPackUI);
        PartPack.HideUi();
    }

    public override void OnShowUi()
    {
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
        _factory.RemoveAllEventListener();
        _factory = null;
    }

    public override void Process(float delta)
    {
        if (InputManager.PartPackage)
        {
            if (PartPack.IsOpen)
            {
                PartPack.HideUi();
            }
            else
            {
                PartPack.ShowUi();
            }
        }
    }

    //玩家拾起道具, 弹出提示
    private void OnPlayerPickUpProp(object propObj)
    {
        var prop = (PropActivity)propObj;
        var message = $"{prop.ActivityBase.Name}\n{prop.ActivityBase.Intro}";
        BottomTipsPanel.ShowTips(prop.GetDefaultTexture(), message);
    }
}