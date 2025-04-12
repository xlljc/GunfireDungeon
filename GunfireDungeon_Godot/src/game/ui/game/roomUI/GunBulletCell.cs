using DsUi;
using Godot;

namespace UI.game.RoomUI;

public class GunBulletCell : UiCell<RoomUI.BulletItem, bool>
{
    private Texture2D _none;
    private Texture2D _has;

    public override void OnInit()
    {
        _none = ResourceManager.LoadTexture2D(ResourcePath.resource_sprite_ui_roomUI_GunBullet2_png);
        _has = ResourceManager.LoadTexture2D(ResourcePath.resource_sprite_ui_roomUI_GunBullet1_png);
    }

    public override void OnSetData(bool data)
    {
        if (data)
        {
            CellNode.Instance.Texture = _has;
            RefreshSize(_has);
        }
        else
        {
            CellNode.Instance.Texture = _none;
            RefreshSize(_none);
        }
    }

    private void RefreshSize(Texture2D texture)
    {
        CellNode.Instance.CustomMinimumSize = texture.GetSize() * 4;
    }
}