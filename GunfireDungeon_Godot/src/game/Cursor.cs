using System.Collections.Generic;
using Godot;

/// <summary>
/// 鼠标指针
/// </summary>
public partial class Cursor : Node2D
{
    /// <summary>
    /// 是否是GUI模式，长度大于0表示Ui模式
    /// </summary>
    private HashSet<ulong> _isGuiLayerIds = new HashSet<ulong>();

    /// <summary>
    /// 非GUI模式下鼠标指针所挂载的角色
    /// </summary>
    private Role _mountRole;

    private Sprite2D center;
    private Sprite2D lt;
    private Sprite2D lb;
    private Sprite2D rt;
    private Sprite2D rb;

    private Texture2D _cursorUi;

    public override void _Ready()
    {
        _cursorUi = ResourceManager.LoadTexture2D(ResourcePath.resource_sprite_ui_sursors_Cursors_Ui_png);
        //Input.SetCustomMouseCursor(_cursorUi, Input.CursorShape.Arrow, new Vector2(6, 6));
        
        center = GetNode<Sprite2D>("Center");
        lt = GetNode<Sprite2D>("LT");
        lb = GetNode<Sprite2D>("LB");
        rt = GetNode<Sprite2D>("RT");
        rb = GetNode<Sprite2D>("RB");
        RefreshCursor();
    }

    public override void _Process(double delta)
    {
        if (_isGuiLayerIds.Count <= 0)
        {
            var targetGun = _mountRole?.WeaponPack.ActiveItem;
            if (targetGun != null)
            {
                SetScope(targetGun.CurrScatteringRange, targetGun);
            }
            else
            {
                SetScope(0, null);
            }
            SetCursorPos();
        }
    }

    public void AddUiLayer(ulong id)
    {
        if (_isGuiLayerIds.Add(id))
        {
            RefreshCursor();
        }
    }
    
    public void RemoveUiLayer(ulong id)
    {
        if (_isGuiLayerIds.Remove(id))
        {
            RefreshCursor();
        }
    }

    /// <summary>
    /// 刷新鼠标指针
    /// </summary>
    public void RefreshCursor()
    {
        var uiFlag = _isGuiLayerIds.Count > 0 || !GameApplication.Instance.DungeonManager.IsInDungeon;
        if (uiFlag) //手指
        {
            lt.Visible = false;
            lb.Visible = false;
            rt.Visible = false;
            rb.Visible = false;
            Input.MouseMode = Input.MouseModeEnum.Visible;
        }
        else //准心
        {
            lt.Visible = true;
            lb.Visible = true;
            rt.Visible = true;
            rb.Visible = true;
            Input.MouseMode = Input.MouseModeEnum.Hidden;
        }
    }
    
    /// <summary>
    /// 设置非GUI模式下鼠标指针所挂载的角色
    /// </summary>
    public void SetMountRole(Role role)
    {
        _mountRole = role;
    }

    /// <summary>
    /// 获取非GUI模式下鼠标指针所挂载的角色
    /// </summary>
    public Role GetMountRole()
    {
        return _mountRole;
    }

    /// <summary>
    /// 设置光标半径范围
    /// </summary>
    private void SetScope(float scope, Weapon targetGun)
    {
        if (targetGun != null)
        {
            var tunPos = GameApplication.Instance.WorldToUiPosition(targetGun.GlobalPosition);
            var len = GlobalPosition.DistanceTo(tunPos);
            if (targetGun.Attribute != null)
            {
                len = Mathf.Max(0, len - targetGun.FirePoint.Position.X);
            }
            scope = len / GameConfig.ScatteringDistance * scope;
        }
        scope = Mathf.Clamp(scope, 0, 192);
        center.Visible = scope > 64;

        lt.Position = new Vector2(-scope, -scope);
        lb.Position = new Vector2(-scope, scope);
        rt.Position = new Vector2(scope, -scope);
        rb.Position = new Vector2(scope, scope);
    }

    private void SetCursorPos()
    {
        GlobalPosition = GetGlobalMousePosition();
    }
}