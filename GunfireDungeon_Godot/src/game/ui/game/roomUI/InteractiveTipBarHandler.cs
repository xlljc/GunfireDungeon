using Godot;

using DsUi;

namespace UI.game.RoomUI;

/// <summary>
/// 互动提示文本
/// </summary>
public partial class InteractiveTipBarHandler : Control, IUiNodeScript
{
    private RoomUI.InteractiveTipBar _interactiveTipBar;
    private EventBinder<EventEnum> _binder;
    private ActivityObject _interactiveTarget;
    
    public void SetUiNode(IUiNode uiNode)
    {
        _interactiveTipBar = (RoomUI.InteractiveTipBar)uiNode;
        _interactiveTipBar.Instance.Visible = false;
        _interactiveTipBar.UiPanel.OnShowUiEvent += OnShow;
        _interactiveTipBar.UiPanel.OnHideUiEvent += OnHide;
    }

    public void OnShow()
    {
        GameCamera.Main.OnPositionUpdateEvent += OnCameraPositionUpdate;
        _binder = EventManager.AddEventListener(EventEnum.OnPlayerChangeInteractiveItem, OnPlayerChangeInteractiveItem);
    }

    public void OnHide()
    {
        GameCamera.Main.OnPositionUpdateEvent -= OnCameraPositionUpdate;
        _binder.RemoveEventListener();
        _binder = null;
    }
    
    /// <summary>
    /// 隐藏互动提示ui
    /// </summary>
    public void HideBar()
    {
        _interactiveTipBar.Instance.Visible = false;
    }

    /// <summary>
    /// 显示互动提示ui
    /// </summary>
    /// <param name="target">所在坐标</param>
    /// <param name="showText">显示文本</param>
    /// <param name="icon">显示图标</param>
    public void ShowBar(ActivityObject target, string showText, Texture2D icon)
    {
        _interactiveTipBar.Instance.GlobalPosition = GameApplication.Instance.WorldToUiPosition(_interactiveTarget.GlobalPosition);
        _interactiveTipBar.L_Icon.Instance.Texture = icon;
        _interactiveTipBar.Instance.Visible = true;
        _interactiveTipBar.L_NameLabel.Instance.Text = showText;
    }

    public void OnPlayerChangeInteractiveItem(object o)
    {
        if (o == null)
        {
            _interactiveTarget = null;
            //隐藏互动提示
            HideBar();
        }
        else
        {
            var result = (CheckInteractiveResult)o;
            if (result.Target is ActivityObject interactiveItem)
            {
                //if (interactiveItem is Weapon)
                var icon = result.GetIcon();
                if (icon != null)
                {
                    _interactiveTarget = interactiveItem;
                    //显示互动提示
                    ShowBar(interactiveItem, interactiveItem.ActivityBase.Name, icon);
                }
                else
                {
                    _interactiveTarget = null;
                }
            }
        }
    }
    
    /// <summary>
    /// 相机更新回调
    /// </summary>
    public void OnCameraPositionUpdate(float delta)
    {
        if (_interactiveTarget != null)
        {
            _interactiveTipBar.Instance.GlobalPosition = GameApplication.Instance.WorldToUiPosition(_interactiveTarget.GlobalPosition);
        }
    }


    public void OnDestroy()
    {
        
    }
}