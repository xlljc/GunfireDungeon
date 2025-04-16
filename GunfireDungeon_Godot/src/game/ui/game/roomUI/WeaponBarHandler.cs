using System.Collections.Generic;
using Godot;

using DsUi;

namespace UI.game.RoomUI;

public class WeaponBarHandler
{
    private RoomUI.WeaponBar _weaponBar;

    private int _prevAmmo = -1;
    private UiGrid<RoomUI.BulletItem, bool> _bulletGrid;


    private Weapon _prevWeapon;
    private int _prevBullet;
    
    public WeaponBarHandler(RoomUI.WeaponBar weaponBar)
    {
        _weaponBar = weaponBar;
        _bulletGrid =
            weaponBar.UiPanel.CreateUiGrid<RoomUI.BulletItem, bool, GunBulletCell>(weaponBar.UiPanel.S_BulletItem);
        SetWeaponTexture(null);
    }

    public void OnShow()
    {
    }

    public void OnHide()
    {
    }

    public void Process(float delta)
    {
        var weapon = World.Current.Player?.WeaponPack.ActiveItem;
        if (weapon != null)
        {
            SetWeaponTexture(weapon.GetCurrentTexture());
            SetWeaponAmmunition(weapon.CurrAmmo, weapon.CurrManaBuffer, weapon.Attribute.MaxManaBuffer, weapon.CurrMana, weapon.Attribute.MaxMana);
        }
        else
        {
            SetWeaponTexture(null);
        }

        //武器有变化
        if (_prevWeapon != weapon)
        {
            _prevWeapon = weapon;
            if (weapon != null)
            {
                var list = new bool[weapon.Attribute.AmmoCapacity];
                for (var i = 0; i < weapon.Attribute.AmmoCapacity; i++)
                {
                    list[weapon.Attribute.AmmoCapacity - i - 1] = i < weapon.CurrAmmo;
                }
                _bulletGrid.SetDataList(list);
            }
        }
        else if (weapon != null && _prevAmmo != weapon.CurrAmmo) //子弹有变化
        {
            int max, min;
            if (weapon.CurrAmmo > _prevAmmo)
            {
                max = weapon.CurrAmmo;
                min = _prevAmmo;
            }
            else
            {
                max = _prevAmmo;
                min = weapon.CurrAmmo;
            }
            for (var i = min; i < max; i++)
            {
                _bulletGrid.UpdateByIndex(weapon.Attribute.AmmoCapacity - i - 1, i < weapon.CurrAmmo);
            }
            _prevAmmo = weapon.CurrAmmo;
        }
    }

    /// <summary>
    /// 设置显示在 ui 上武器的纹理
    /// </summary>
    /// <param name="texture">纹理</param>
    public void SetWeaponTexture(Texture2D texture)
    {
        if (texture != null)
        {
            _weaponBar.L_WeaponPanel.L_WeaponSprite.Instance.Texture = texture;
            _weaponBar.Instance.Visible = true;
        }
        else
        {
            _weaponBar.Instance.Visible = false;
        }
    }
    
    /// <summary>
    /// 设置弹药数据
    /// </summary>
    public void SetWeaponAmmunition(int currAmmo, int currManaBuffer, int maxManaBuffer, int currMana, int maxMana)
    {
        _weaponBar.L_ManaProgress.Instance.MaxValue = maxMana;
        _weaponBar.L_ManaProgress.Instance.Value = currMana;
        _weaponBar.L_ManaBuffProgress.Instance.MaxValue = maxManaBuffer;
        _weaponBar.L_ManaBuffProgress.Instance.Value = currManaBuffer;
    }
}