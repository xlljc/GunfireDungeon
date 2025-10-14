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
    
    /// <summary>
    /// 是否是手柄输入
    /// </summary>
    public static bool IsJoystickInput { get; private set; } = false;
    
    /// <summary>
    /// 移动方向, 已经归一化, 键鼠: 键盘WASD，手柄：左摇杆
    /// </summary>
    public static Vector2 MoveAxis { get; private set; }
    
    /// <summary>
    /// 鼠标在SubViewport节点下的坐标, 键鼠: 鼠标移动，手柄：右摇杆
    /// </summary>
    public static Vector2 CursorPosition { get; private set; }
    
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

    /// <summary>
    /// 更新输入管理器
    /// </summary>
    public static void Update(float delta)
    {
        MoveAxis = Input.GetVector(InputAction.MoveLeft, InputAction.MoveRight, InputAction.MoveUp, InputAction.MoveDown);

        if (IsJoystickInput)
        {
            var joyRAxis = Input.GetVector(InputAction.JoyRLeft, InputAction.JoyRRight, InputAction.JoyRUp, InputAction.JoyRDown);
            var application = GameApplication.Instance;
            if (application != null)
            {
                var center = application.UiToWorldPosition(application.GetViewportRect().Size / 2);
                if (joyRAxis.LengthSquared() > 0.001f)
                {
                    var direction = joyRAxis.Normalized();
                    var strength = Mathf.Min(joyRAxis.Length(), 1.0f);
                    CursorPosition = center + direction * strength * 500.0f;
                }
                else
                {
                    CursorPosition = center;
                }
            }
        }
        else
        {
            var application = GameApplication.Instance;
            if (application != null)
            {
                CursorPosition = application.SceneRoot.GetGlobalMousePosition();
                //CursorPosition = application.UiToWorldPosition(application.GetGlobalMousePosition());
            }
        }

        ExchangeWeapon = Input.IsActionJustPressed(InputAction.ExchangeWeapon);
        ThrowWeapon = Input.IsActionJustPressed(InputAction.ThrowWeapon);
        Interactive = Input.IsActionJustPressed(InputAction.Interactive);
        Reload = Input.IsActionJustPressed(InputAction.Reload);
        Fire = Input.IsActionPressed(InputAction.Fire) && GameApplication.Instance.Cursor.BlockageMarkingCount <= 0;
        MeleeAttack = Input.IsActionJustPressed(InputAction.MeleeAttack);
        Roll = Input.IsActionJustPressed(InputAction.Roll);
        UseActiveProp = Input.IsActionJustPressed(InputAction.UseActiveProp);
        RemoveProp = Input.IsActionJustPressed(InputAction.RemoveProp);
        ExchangeProp = Input.IsActionJustPressed(InputAction.ExchangeProp);
        Map = Input.IsActionPressed(InputAction.Map);
        Menu = Input.IsActionJustPressed(InputAction.Menu);
        PartPackage = Input.IsActionJustPressed(InputAction.PartPackage);
    }

    /// <summary>
    /// 输入事件处理
    /// </summary>
    public static void InputHandler(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            // 只有当相对移动超过阈值才认为是鼠标输入
            if (mouseMotion.Relative.Length() > MOUSE_MOVE_THRESHOLD)
                IsJoystickInput = false;
        }
        else if (@event is InputEventMouseButton)
        {
            // 鼠标按键明确认为是鼠标输入
            IsJoystickInput = false;
        }
        else if (@event is InputEventJoypadMotion joyMotion)
        {
            // 只有当轴值绝对值超过死区才认为是手柄输入
            if (Mathf.Abs(joyMotion.AxisValue) > JOYPAD_DEADZONE)
                IsJoystickInput = true;
        }
        else if (@event is InputEventJoypadButton)
        {
            // 手柄按键明确认为是手柄输入
            IsJoystickInput = true;
        }
    }
}