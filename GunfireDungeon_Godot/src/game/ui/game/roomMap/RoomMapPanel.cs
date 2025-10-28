using System.Collections.Generic;
using System.Linq;
using Godot;

using DsUi;
using UI.game.RoomUI;

namespace UI.game.RoomMap;

/// <summary>
/// 房间的小地图
/// </summary>
public partial class RoomMapPanel : RoomMap
{
    //需要刷新的问号的房间队列
    private List<RoomDoorInfo> _needRefresh = new List<RoomDoorInfo>();
    //正在使用的敌人标记列表
    private List<Sprite2D> _aiSpriteList = new List<Sprite2D>();
    //已经回收的敌人标记
    private Stack<Sprite2D> _spriteStack = new Stack<Sprite2D>();
    //是否放大地图
    private bool _isMagnifyMap = false;

    private UiEventBinder _dragBinder;
    //放大地图后拖拽的偏移
    private Vector2 _mapOffset;
    //放大地图后悬停的房间
    private RoomInfo _hoverRoom;
    private Color _originOutlineColor;
    //是否展开地图
    private bool _pressMapFlag = false;
    private Tween _transmissionTween;

    private bool _isMousePressed = false;
    private bool _isMoveDragFlag = false;
    
    public override void OnCreateUi()
    {
        _ = S_Mark;
        S_Bg.Instance.Visible = false;
        S_MagnifyMapBar.Instance.Visible = false;
        InitMap();
        AddEventListener(EventEnum.OnPlayerFirstEnterRoom, OnPlayerFirstEnterRoom);
        AddEventListener(EventEnum.OnPlayerFirstEnterAisle, OnPlayerFirstEnterAisle);
        AddEventListener(EventEnum.OnChangeJoypadInputMode, OnChangeJoypadInputMode);

        S_JoystickMark.Instance.Visible = InputManager.IsJoystickInput;
        S_DrawContainer.Instance.Resized += OnDrawContainerResized;
    }

    public override void OnDestroyUi()
    {
        if (_transmissionTween != null)
        {
            _transmissionTween.Dispose();
        }
    }

    public override void Process(float delta)
    {
        var player = World.Current.Player;
        
        if (_transmissionTween == null) //不在传送过程中
        {
            if (!InputManager.Map)
            {
                _pressMapFlag = false;
            }
            //按下地图按键
            if (InputManager.Map && !_isMagnifyMap && !_pressMapFlag) //展开小地图
            {
                if (UiManager.GetUiInstanceCount(UiManager.UiName.Game_PauseMenu) == 0 && !InputManager.PartPackage)
                {
                    ExpandMap();
                    if (InputManager.IsJoystickInput)
                    {
                        this.CallDelay(0f, DoCheckMarkPosInRoom);
                    }
                }
            }
            else if (!InputManager.Map && _isMagnifyMap) //还原小地图
            {
                ShrinkMap();
            }
        }
        
        //更新敌人位置
        {
            var aiList = World.Current.Role_InstanceList.Where(role => role != player).ToArray();
            if (aiList.Length == 0) //没有敌人
            {
                foreach (var sprite in _aiSpriteList)
                {
                    S_Root.RemoveChild(sprite);
                    _spriteStack.Push(sprite);
                }
                _aiSpriteList.Clear();
            }
            else //更新位置
            {
                var count = 0; //绘制数量
                for (var i = 0; i < aiList.Length; i++)
                {
                    var role = aiList[i];
                    if (role is AiRole aiRole && !aiRole.IsDestroyed && !aiRole.IsDie && aiRole.AffiliationArea != null && aiRole.AffiliationArea.RoomInfo.RoomFogMask.IsExplored)
                    {
                        count++;
                        Sprite2D sprite;
                        if (i >= _aiSpriteList.Count)
                        {
                            if (_spriteStack.Count > 0)
                            {
                                sprite = _spriteStack.Pop();
                            }
                            else
                            {
                                sprite = new Sprite2D();
                                sprite.Texture = ResourceManager.LoadTexture2D(ResourcePath.resource_sprite_ui_commonIcon_Block_png);
                                sprite.Modulate = new Color(1, 0, 0);
                            }
                            _aiSpriteList.Add(sprite);
                            S_Root.AddChild(sprite);
                        }
                        else
                        {
                            sprite = _aiSpriteList[i];
                        }
                        //更新标记位置
                        sprite.Position = aiRole.GetCenterPosition() / GameConfig.TileCellSize;
                    }
                }
                
                //回收多余的标记
                while (_aiSpriteList.Count > count)
                {
                    var index = _aiSpriteList.Count - 1;
                    var sprite = _aiSpriteList[index];
                    S_Root.RemoveChild(sprite);
                    _spriteStack.Push(sprite);
                    _aiSpriteList.RemoveAt(index);
                }
            }
        }
        
        //更新预览图标
        if (_needRefresh.Count > 0)
        {
            foreach (var roomDoorInfo in _needRefresh)
            {
                HandlerRefreshUnknownSprite(roomDoorInfo);
            }
            _needRefresh.Clear();
        }
        
        //手柄模式下移动/传送小地图
        if (InputManager.IsJoystickInput && _isMagnifyMap)
        {
            if (InputManager.IsJoystickRInput) // 移动地图
            {
                _mapOffset -= InputManager.JoystickRAxis.Normalized() * 400 * delta;
                _isMoveDragFlag = true;
                
                // 检测中心点是否在房间内
                DoCheckMarkPosInRoom();
            }
        }

        if (player != null)
        {
            //更新地图中心点位置
            var playPosition = player.GetCenterPosition();
            if (!_isMagnifyMap)
            {
                S_Root.Instance.Position = CalcRootPosition(playPosition);
            }
            else
            {
                S_Root.Instance.Position = CalcRootPosition(playPosition) + _mapOffset;
                S_Mark.Instance.Position = S_DrawContainer.Instance.Size / 2 + _mapOffset;
            }
            
            var area = player.AffiliationArea;
            //传送
            if (_pressMapFlag && _hoverRoom != null &&
                area != null && !area.RoomInfo.IsSeclusion)
            {
                if (InputManager.IsJoystickInput) // 手柄操作
                {
                    if (Input.IsActionJustPressed(InputAction.UiAccept)) // 传送
                    {
                        DoTransmission(_hoverRoom);
                        ResetMap();
                        _isMagnifyMap = false;
                        World.Current.Pause = false;
                    }
                }
                else
                {
                    var pressed = Input.IsMouseButtonPressed(MouseButton.Left);
                    // GD.Print("pressed:", pressed, " _isMousePressed:", _isMousePressed, " _isMoveDragFlag:", _isMoveDragFlag);
                    if (!_isMousePressed && pressed)
                    {
                        _isMousePressed = true;
                        _isMoveDragFlag = false;
                    }
                    else if (!pressed) // 松开手
                    {
                        if (_isMousePressed && !_isMoveDragFlag)
                        {
                            //执行传送操作
                            DoTransmission(_hoverRoom);
                            ResetMap();
                            _isMagnifyMap = false;
                            World.Current.Pause = false;
                        }
                        _isMousePressed = false;
                        _isMoveDragFlag = false;
                    }
                }
            }
            else
            {
                _isMousePressed = false;
                _isMoveDragFlag = false;
            }
        }
    }

    private void DoCheckMarkPosInRoom()
    {
        var startRoom = GameApplication.Instance.DungeonManager.StartRoomInfo;
        var result = startRoom.FindRoom(FindMarkPosRoom);
        if (result == null)
        {
            ResetOutlineColor();
        }
    }

    private bool FindMarkPosRoom(RoomInfo info)
    {
        var mark = S_JoystickMark.Instance;
        var sprite = info.PreviewSprite;
        
        // 判断mark的坐标是否在sprite内
        if (sprite.GetGlobalRect().HasPoint(mark.GetGlobalRect().Position))
        {
            SetHoverRoom(info);
            return true;
        }

        return false;
    }

    /// <summary>
    /// 执行展开地图
    /// </summary>
    public void ExpandMap()
    {
        World.Current.Pause = true;
        _pressMapFlag = true;
        _isMagnifyMap = true;
        MagnifyMap();
    }
    
    /// <summary>
    /// 执行收起地图
    /// </summary>
    public void ShrinkMap()
    {
        ResetMap();
        _isMagnifyMap = false;
        World.Current.Pause = false;
    }
    
    private void OnDrawContainerResized()
    {
        S_Mark.Instance.Position = S_DrawContainer.Instance.Size / 2;
    }

    //放大小地图
    private void MagnifyMap()
    {
        InputManager.AddBlockageMarking(GetInstanceId());
        S_DrawContainer.Reparent(S_MagnifyMapBar);
        S_DrawContainer.Instance.MouseFilter = MouseFilterEnum.Stop;
        S_DrawContainer.Instance.Position = new Vector2(1, 1);
        S_Bg.Instance.Visible = true;
        S_MagnifyMapBar.Instance.Visible = true;
        S_MapBar.Instance.Visible = false;
        _mapOffset = Vector2.Zero;
        GameCamera.Main.LockCamera();

        _dragBinder = S_DrawContainer.Instance.AddDragListener(OnDragMap);
    }

    private void OnDragMap(DragState state, Vector2 delta)
    {
        if (state == DragState.DragMove)
        {
            _mapOffset += delta;
            _isMoveDragFlag = true;
        }
    }

    //还原小地图
    private void ResetMap()
    {
        InputManager.RemoveBlockageMarking(GetInstanceId());
        S_DrawContainer.Reparent(S_MapBar);
        S_DrawContainer.Instance.MouseFilter = MouseFilterEnum.Ignore;
        S_DrawContainer.Instance.Position = new Vector2(1, 1);
        S_Bg.Instance.Visible = false;
        S_MagnifyMapBar.Instance.Visible = false;
        S_MapBar.Instance.Visible = true;
        ResetOutlineColor();
        
        GameCamera.Main.UnLockCamera();

        if (_dragBinder != null)
        {
            _dragBinder.UnBind();
            _dragBinder = null;
        }
    }

    private void ResetOutlineColor()
    {
        if (_hoverRoom != null)
        {
            ((ShaderMaterial)_hoverRoom.PreviewSprite.Material).SetShaderParameter("outline_color", _originOutlineColor);
            _hoverRoom = null;
        }
    }
    
    //初始化小地图
    private void InitMap()
    {
        var startRoom = GameApplication.Instance.DungeonManager.StartRoomInfo;
        if (startRoom == null)
        {
            HideUi();
            return;
        }
        startRoom.EachRoom(roomInfo =>
        {
            //房间
            roomInfo.PreviewSprite.Visible = false;
            S_Root.AddChild(roomInfo.PreviewSprite);

            roomInfo.PreviewSprite.MouseEntered += () =>
            {
                if (!_pressMapFlag)
                {
                    return;
                }
                SetHoverRoom(roomInfo);
            };
            roomInfo.PreviewSprite.MouseExited += () =>
            {
                if (!_pressMapFlag)
                {
                    return;
                }
                ResetOutlineColor();
            };
            
            //过道
            if (roomInfo.Doors != null)
            {
                foreach (var roomInfoDoor in roomInfo.Doors)
                {
                    if (roomInfoDoor.IsForward)
                    {
                        roomInfoDoor.AislePreviewSprite.Visible = false;
                        S_Root.AddChild(roomInfoDoor.AislePreviewSprite);
                    }
                }
            }
        });
    }

    private void SetHoverRoom(RoomInfo roomInfo)
    {
        if (_hoverRoom == roomInfo)
        {
            return;
        }
        ResetOutlineColor();
        _hoverRoom = roomInfo;
        var shaderMaterial = (ShaderMaterial)roomInfo.PreviewSprite.Material;
        _originOutlineColor = shaderMaterial.GetShaderParameter("outline_color").AsColor();
        //玩家所在的房间门是否打开
        var area = World.Current.Player.AffiliationArea;
        if (area != null)
        {
            var isOpen = !area.RoomInfo.IsSeclusion;
            if (isOpen)
            {
                shaderMaterial.SetShaderParameter("outline_color", new Color(0, 1, 0, 0.9f));
            }
            else
            {
                shaderMaterial.SetShaderParameter("outline_color", new Color(1, 0, 0, 0.9f));
            }
        }
    }
    
    private void OnPlayerFirstEnterRoom(object data)
    {
        var roomInfo = (RoomInfo)data;
        if (roomInfo.PreviewSprite != null)
        {
            roomInfo.PreviewSprite.Visible = true;
        }

        if (roomInfo.Doors!= null)
        {
            foreach (var roomDoor in roomInfo.Doors)
            {
                RefreshUnknownSprite(roomDoor);
            }
        }
    }
    
    private void OnPlayerFirstEnterAisle(object data)
    {
        var roomDoorInfo = (RoomDoorInfo)data;
        roomDoorInfo.AislePreviewSprite.Visible = true;

        RefreshUnknownSprite(roomDoorInfo);
        RefreshUnknownSprite(roomDoorInfo.ConnectDoor);
    }

    private void OnChangeJoypadInputMode(object data)
    {
        S_JoystickMark.Instance.Visible = data is bool flag && flag;
    }

    //进入刷新问号队列
    private void RefreshUnknownSprite(RoomDoorInfo roomDoorInfo)
    {
        if (!_needRefresh.Contains(roomDoorInfo))
        {
            _needRefresh.Add(roomDoorInfo);
        }
    }

    //刷新问号
    private void HandlerRefreshUnknownSprite(RoomDoorInfo roomDoorInfo)
    {
        //是否探索房间
        var flag1 = roomDoorInfo.RoomInfo.RoomFogMask.IsExplored;
        //是否探索过道
        var flag2 = roomDoorInfo.AisleFogMask.IsExplored;
        if (flag1 == flag2) //不显示问号
        {
            if (roomDoorInfo.UnknownSprite != null)
            {
                roomDoorInfo.UnknownSprite.QueueFree();
                roomDoorInfo.UnknownSprite = null;
            }
        }
        else
        {
            var unknownSprite = roomDoorInfo.UnknownSprite ?? CreateUnknownSprite(roomDoorInfo);
            var pos = (roomDoorInfo.OriginPosition + roomDoorInfo.GetEndPosition()) / 2;
            if (!flag2) //偏向过道
            {
                if (roomDoorInfo.Direction == DoorDirection.N)
                    pos += new Vector2I(0, -1);
                else if (roomDoorInfo.Direction == DoorDirection.S)
                    pos += new Vector2I(0, 3);
                else if (roomDoorInfo.Direction == DoorDirection.E)
                    pos += new Vector2I(2, 1);
                else if (roomDoorInfo.Direction == DoorDirection.W)
                    pos += new Vector2I(-2, 1);
            }
            else //偏向房间
            {
                if (roomDoorInfo.Direction == DoorDirection.N)
                    pos -= new Vector2I(0, -4);
                else if (roomDoorInfo.Direction == DoorDirection.S)
                    pos -= new Vector2I(0, 1);
                else if (roomDoorInfo.Direction == DoorDirection.E)
                    pos -= new Vector2I(3, -1);
                else if (roomDoorInfo.Direction == DoorDirection.W)
                    pos -= new Vector2I(-3, -1);
            }
            unknownSprite.Position = pos;
        }
    }

    private Sprite2D CreateUnknownSprite(RoomDoorInfo roomInfoDoor)
    {
        var unknownSprite = new Sprite2D();
        unknownSprite.Texture = ResourceManager.LoadTexture2D(ResourcePath.resource_sprite_ui_commonIcon_Unknown_png);
        unknownSprite.Scale = new Vector2(0.25f, 0.25f);
        roomInfoDoor.UnknownSprite = unknownSprite;
        S_Root.AddChild(unknownSprite);
        return unknownSprite;
    }

    private Vector2 CalcRootPosition(Vector2 pos)
    {
        return S_DrawContainer.Instance.Size / 2 - pos / GameConfig.TileCellSize * S_Root.Instance.Scale;
    }
    
    // 传送
    private void DoTransmission(RoomInfo roomInfo)
    {
        var position = (roomInfo.Waypoints + new Vector2(0.5f, 0.5f)) * GameConfig.TileCellSize;
        
        var roomUi = (RoomUIPanel)ParentUi;
        roomUi.S_Mask.Instance.Visible = true;
        roomUi.S_Mask.Instance.Color = new Color(0, 0, 0, 0);
        _transmissionTween = CreateTween();
        _transmissionTween.TweenProperty(roomUi.S_Mask.Instance, "color", new Color(0, 0, 0), 0.3f);
        _transmissionTween.TweenCallback(Callable.From(() =>
        {
            World.Current.Player.Position = position;
        }));
        _transmissionTween.TweenInterval(0.2f);
        _transmissionTween.TweenProperty(roomUi.S_Mask.Instance, "color", new Color(0, 0, 0, 0), 0.3f);
        _transmissionTween.TweenCallback(Callable.From(() =>
        {
            _transmissionTween = null;
        }));
        _transmissionTween.Play();
    }
}
