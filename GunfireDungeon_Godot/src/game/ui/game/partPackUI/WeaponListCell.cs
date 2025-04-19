using DsUi;

namespace UI.game.PartPackUI;

public class WeaponListCell : UiCell<PartPackUI.WeaponItem, Weapon>
{
    public override void OnSetData(Weapon data)
    {
        //图标
        CellNode.L_Control.L_WeaponIcon.Instance.Texture = data.GetDefaultTexture();
        
        RefreshBaseInfo();
    }

    public override void Process(float delta)
    {
        RefreshBaseInfo();
    }

    private void RefreshBaseInfo()
    {
        if (Data == null)
        {
            return;
        }
        //法力值：99/99
        CellNode.L_VBoxContainer.L_WeaponMana.Instance.Text = "法力值：" + Data.CurrMana + "/" + Data.Attribute.MaxMana;
        //缓冲区：99/99
        CellNode.L_VBoxContainer.L_WeaponBuffMana.Instance.Text = "缓冲区：" + Data.CurrBufferMana + "/" + Data.Attribute.MaxBufferMana;
    }
}