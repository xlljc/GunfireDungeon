using System.Collections.Generic;
using DsUi;
using Godot;

/// <summary>
/// 输入管理器
/// </summary>
public static class InputManager
{
    /// <summary>
    /// 鼠标移动最小像素阈值，可按需调整
    /// </summary>
    public const float MOUSE_MOVE_THRESHOLD = 2.0f;
    /// <summary>
    /// 摇杆死区，可按需调整
    /// </summary>
    public const float JOYPAD_DEADZONE = 0.1f;
    
    
    //--------------------------------
    
    
    /// <summary>
    /// 移动方向, 已经归一化, 键鼠: 键盘WASD，手柄：左摇杆
    /// </summary>
    public static Vector2 MoveAxis { get; private set; }
    
    /// <summary>
    /// 射击瞄准坐标，在SubViewport节点下的坐标, 键鼠: 鼠标移动，手柄：右摇杆
    /// </summary>
    public static Vector2 AimingPosition { get; private set; }
    
    /// <summary>
    /// 是否按下打开零件背包按钮, 键鼠: 键盘Tab，手柄：View键
    /// </summary>
    public static bool PartPackage { get; set; }
    
    /// <summary>
    /// 是否按下切换上一把武器, 键鼠: 键盘Q，手柄：Y键
    /// </summary>
    public static bool ExchangeWeapon { get; private set; }

    /// <summary>
    /// 是否按下投抛武器按钮, 键鼠: 键盘G，手柄：方向键下
    /// </summary>
    public static bool ThrowWeapon { get; private set; }
    
    /// <summary>
    /// 是否按下使用道具按钮, 键鼠: 键盘F，手柄：B键
    /// </summary>
    public static bool UseActiveProp { get; private set; }
    
    /// <summary>
    /// 是否按下切换道具按钮, 键鼠: 键盘Z，手柄：方向键左
    /// </summary>
    public static bool ExchangeProp { get; private set; }
    
    /// <summary>
    /// 是否按下丢弃道具按钮, 键鼠: 键盘X，手柄：方向键右
    /// </summary>
    public static bool RemoveProp { get; private set; }
    
    /// <summary>
    /// 是否按钮互动按钮, 键鼠: 键盘E，手柄：A键
    /// </summary>
    public static bool Interactive { get; private set; }
    
    /// <summary>
    /// 是否按钮换弹按钮, 键鼠: 键盘R，手柄：X键
    /// </summary>
    public static bool Reload { get; private set; }
    
    /// <summary>
    /// 是否按钮开火按钮, 键鼠: 鼠标左键，手柄：RB键
    /// </summary>
    public static bool Fire { get; private set; }
    
    /// <summary>
    /// 是否按钮近战攻击按钮 (使用远程武器发起的近战攻击), 键鼠: 键盘Space，手柄：RT键
    /// </summary>
    public static bool MeleeAttack { get; private set; }
    
    /// <summary>
    /// 是否按下翻滚按钮, 键鼠: 鼠标右键，手柄：LB键
    /// </summary>
    public static bool Roll { get; private set; }
    
    /// <summary>
    /// 是否按下打开地图按钮, 键鼠: 键盘Ctrl，手柄：LT键
    /// </summary>
    public static bool Map { get; private set; }
    
    /// <summary>
    /// 菜单键, 键鼠: esc，手柄：菜单键
    /// </summary>
    public static bool Menu { get; private set; }

    //------------------------------- 鼠标相关

    /// <summary>
    /// 鼠标是否在移动
    /// </summary>
    public static bool MouseIsMoving { get; set; } = false;
    private static Vector2 _lastMousePosition = Vector2.Zero;
    
    /// <summary>
    /// Ui下的鼠标位置
    /// </summary>
    public static Vector2 UiMousePosition { get; private set; }
    
    /// <summary>
    /// 鼠标是否有Ui遮挡
    /// </summary>
    public static bool HasMouseUiBlockage => !IsJoystickInput && _hasMouseUiBlockage;
    
    private static bool _hasMouseUiBlockage = false;
    
    // -------------------------------- 手柄相关
    
    /// <summary>
    /// 是否是手柄输入
    /// </summary>
    public static bool IsJoystickInput { get; private set; } = false;

    /// <summary>
    /// 右摇杆是否有输入
    /// </summary>
    public static bool IsJoystickRInput { get; private set; } = false;
    
    /// <summary>
    /// 手柄右摇杆方向，仅在IsJoystickInput为true时有效
    /// </summary>
    public static Vector2 JoystickRAxis;
    
    //------------------------------------------------
    
    /// <summary>
    /// 是否有 Ui 遮挡
    /// </summary>
    public static bool HasUiBlockage => _blockageMarkingTags.Count > 0;
    
    private static HashSet<ulong> _blockageMarkingTags = new HashSet<ulong>();
    
    /// <summary>
    /// 更新输入管理器
    /// </summary>
    public static void Update(float delta)
    {
        var app = GameApplication.Instance;
        if (IsJoystickInput)
        {
            var tempJoyRAxis = Input.GetVector(InputAction.JoyRLeft, InputAction.JoyRRight, InputAction.JoyRUp, InputAction.JoyRDown);
            IsJoystickRInput = tempJoyRAxis.LengthSquared() >= 0.2f * 0.2f;
            if (IsJoystickRInput)
            {
                JoystickRAxis = tempJoyRAxis;
            }
            var center = app.UiToWorldPosition(app.GetViewportRect().Size / 2);
            if (JoystickRAxis.LengthSquared() > 0.001f)
            {
                var direction = JoystickRAxis.Normalized();
                var strength = Mathf.Min(JoystickRAxis.Length(), 1.0f);
                AimingPosition = center + direction * strength * 120.0f;
            }
            else
            {
                AimingPosition = center;
            }
            
            Fire = !HasUiBlockage && Input.IsActionPressed(InputAction.Fire);
        }
        else
        {
            IsJoystickRInput = false;
            JoystickRAxis = Vector2.Zero;
            AimingPosition = app.SceneRoot.GetGlobalMousePosition();
            //CursorPosition = application.UiToWorldPosition(application.GetGlobalMousePosition());
        }

        UiMousePosition = app.GetViewport().GetMousePosition();
        
        MoveAxis = Input.GetVector(InputAction.MoveLeft, InputAction.MoveRight, InputAction.MoveUp, InputAction.MoveDown);
        ExchangeWeapon = Input.IsActionJustPressed(InputAction.ExchangeWeapon);
        ThrowWeapon = Input.IsActionJustPressed(InputAction.ThrowWeapon);
        Interactive = Input.IsActionJustPressed(InputAction.Interactive);
        Reload = Input.IsActionJustPressed(InputAction.Reload);
        MeleeAttack = Input.IsActionJustPressed(InputAction.MeleeAttack);
        Roll = Input.IsActionJustPressed(InputAction.Roll);
        UseActiveProp = Input.IsActionJustPressed(InputAction.UseActiveProp);
        RemoveProp = Input.IsActionJustPressed(InputAction.RemoveProp);
        ExchangeProp = Input.IsActionJustPressed(InputAction.ExchangeProp);

        Map = Input.IsActionPressed(InputAction.Map);
        Menu = Input.IsActionJustPressed(InputAction.Menu);
        PartPackage = Input.IsActionJustPressed(InputAction.PartPackage);
        
        // 更新鼠标移动状态
        var currentMousePosition = UiMousePosition;
        MouseIsMoving = (currentMousePosition - _lastMousePosition).Length() > MOUSE_MOVE_THRESHOLD;
        _lastMousePosition = currentMousePosition;
    }

    /// <summary>
    /// 输入事件处理
    /// </summary>
    public static void GlobalInputHandler(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            // 只有当相对移动超过阈值才认为是鼠标输入
            if (mouseMotion.Relative.Length() > MOUSE_MOVE_THRESHOLD)
                SetJsoystickInput(false);
        }
        else if (@event is InputEventMouseButton)
        {
            // 鼠标按键明确认为是鼠标输入
            SetJsoystickInput(false);
        }
        else if (@event is InputEventJoypadMotion joyMotion)
        {
            // 只有当轴值绝对值超过死区才认为是手柄输入
            if (Mathf.Abs(joyMotion.AxisValue) > JOYPAD_DEADZONE)
                SetJsoystickInput(true);
        }
        else if (@event is InputEventJoypadButton)
        {
            // 手柄按键明确认为是手柄输入
            SetJsoystickInput(true);
        }
    }

    private static void SetJsoystickInput(bool flag)
    {
        if (IsJoystickInput != flag)
        {
            IsJoystickInput = flag;
            GameApplication.Instance.Cursor.RefreshCursor();
            EventManager.EmitEvent(EventEnum.OnChangeJoypadInputMode, flag);
        }
    }
    
    public static void RoomInputHandler(InputEvent @event)
    {
        if (!IsJoystickInput && @event is InputEventMouseButton)
        {
            Fire = !HasUiBlockage && Input.IsActionPressed(InputAction.Fire);
        }
    }
    
    public static void SetMouseUiBlockage(bool flag)
    {
        if (HasMouseUiBlockage != flag)
        {
            _hasMouseUiBlockage = flag;
            GameApplication.Instance.Cursor.RefreshCursor();
        }
    }
    
    public static void AddBlockageMarking(ulong id)
    {
        if (_blockageMarkingTags.Add(id))
        {
            GameApplication.Instance.Cursor.RefreshCursor();
        }
    }
    
    public static void RemoveBlockageMarking(ulong id)
    {
        if (_blockageMarkingTags.Remove(id))
        {
            GameApplication.Instance.Cursor.RefreshCursor();
        }
    }
}