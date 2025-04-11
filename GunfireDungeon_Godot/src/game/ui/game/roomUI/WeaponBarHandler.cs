using Godot;

using DsUi;

namespace UI.game.RoomUI;

public class WeaponBarHandler
{
    private RoomUI.WeaponBar _weaponBar;

    private int _prevAmmo = -1;
    
    public WeaponBarHandler(RoomUI.WeaponBar weaponBar)
    {
        _weaponBar = weaponBar;
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
            SetWeaponAmmunition(weapon.CurrAmmo, weapon.CurrManaBuffer, weapon.MaxManaBuffer, weapon.CurrMana, weapon.MaxMana);
        }
        else
        {
            SetWeaponTexture(null);
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
        _weaponBar.L_ManaCount.Instance.Text = currMana + "/" + maxMana;
        _weaponBar.L_CurrAmmoCount.Instance.Text = currAmmo.ToString();
        _weaponBar.L_ManaBuffCount.Instance.Text = currManaBuffer + "/" + maxManaBuffer;
    }
}