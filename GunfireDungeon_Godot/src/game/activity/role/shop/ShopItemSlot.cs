
using System;
using Config;
using Godot;

public partial class ShopItemSlot : Area2D, IInteractive, IOutline
{
    private Label _name;
    private Label _price;
    private Sprite2D _icon;
    private ExcelConfig.ActivityBase _config;

    private uint _finalPrice;
    //是否买得起
    private bool _flag = true;

    public bool ShowOutline { get; set; } = true;
    public Color OutlineColor
    {
        get => _blendShaderMaterial == null ? Colors.Black : _blendShaderMaterial.GetShaderParameter(ShaderParamNames.OutlineColor).AsColor();
        set => _blendShaderMaterial?.SetShaderParameter(ShaderParamNames.OutlineColor, value);
    }

    
    public bool IsDestroyed { get; private set; }

    private ShaderMaterial _blendShaderMaterial;

    public void InitItem(ExcelConfig.ActivityBase config)
    {
        _price = GetNode<Label>("Price");
        _name = GetNode<Label>("NameLabel");
        _icon = GetNode<Sprite2D>("Icon");
        _name.Visible = false;
        _blendShaderMaterial = _icon.Material as ShaderMaterial;
        
        _config = config;
        _name.Text = config.Name;
        _finalPrice = config.Price;
        _price.Text = _finalPrice.ToString();
        _icon.Texture = ResourceManager.LoadTexture2D(config.Icon);
    }

    public override void _Process(double delta)
    {
        var player = World.Current.Player;
        if (player != null)
        {
            if (_flag && player.RoleState.Gold < _finalPrice) //买不起
            {
                _flag = false;
                _price.Modulate = Colors.Red;
            }
            else if (!_flag && player.RoleState.Gold >= _finalPrice) //买得起
            {
                _flag = true;
                _price.Modulate = Colors.White;
            }
        }
    }

    public CheckInteractiveResult CheckInteractive(ActivityObject master)
    {
        return new CheckInteractiveResult(this, _config != null && master is Role);
    }

    public void Interactive(ActivityObject master)
    {
        var role = (Role)master;
        if (role.RoleState.Gold < _finalPrice)
        {
            return;
        }
        
        Monitorable = false;
        Visible = false;
        role.UseGold((int)_finalPrice);

        var item = ActivityObject.Create(_config);
        if (item is Weapon weapon)
        {
            if (!role.PickUpWeapon(weapon))
            {
                role.ThrowWeapon();
                role.PickUpWeapon(weapon);
            }
        }
        else if (item is ActiveProp activeProp)
        {
            if (!role.PickUpActiveProp(activeProp))
            {
                role.ThrowActiveProp();
                role.PickUpActiveProp(activeProp);
            }
        }
        else if (item is BuffProp buffProp)
        {
            role.PickUpBuffProp(buffProp);
        }
        else
        {
            throw new Exception("商店中购买到不支持的物体: " + _config.Id);
        }

        _config = null;
    }
    
    public virtual void OnTargetEnterd(ActivityObject target)
    {
        _name.Visible = true;
        OutlineColor = Colors.White;
    }

    public virtual void OnTargetExitd(ActivityObject target)
    {
        _name.Visible = false;
        OutlineColor = Colors.Black;
    }
    
    public void Destroy()
    {
        if (IsDestroyed) return;
        IsDestroyed = true;
        
        QueueFree();
    }
}