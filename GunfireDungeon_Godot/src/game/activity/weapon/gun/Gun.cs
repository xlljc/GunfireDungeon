using Config;
using Godot;

/// <summary>
/// 普通的枪
/// </summary>
public partial class Gun : Weapon
{
    
    public override void OnInit()
    {
        base.OnInit();

        FirePartList.SetLogicBlock(0, PartProp.CreatePropActivity("0001"));
        // FirePartList.SetLogicBlock(0, new FinishPlayBuffPart()
        // {
        //     Mana = 50,
        //     BehindMaxMana = 60,
        //     Occupancy = 2,
        // });
        //
        // FirePartList.SetLogicBlock(1, new BulletPart()
        // {
        //     Mana = 12,
        //     ScatteringAngle = 10,
        //     Bullet = ExcelConfig.BulletBase_Map["0001"]
        // });
        // FirePartList.SetLogicBlock(2, new MergePlayBuffPart()
        // {
        //     Mana = 2,
        //     Occupancy = 2,
        // });
        // FirePartList.SetLogicBlock(3, new BulletPart()
        // {
        //     Mana = 25,
        //     ScatteringAngle = 10,
        //     Bullet = ExcelConfig.BulletBase_Map["0005"]
        // });
        // FirePartList.SetLogicBlock(4, new BulletPart()
        // {
        //     Mana = 25,
        //     ScatteringAngle = 10,
        //     Bullet = ExcelConfig.BulletBase_Map["0005"]
        // });
    }
    
    protected override void OnFire()
    {
        if (Master == World.Player)
        {
            //创建抖动
            GameCamera.Main.DirectionalShake(Vector2.Right.Rotated(GlobalRotation) * Attribute.CameraShake);
        }
        //
        // //创建开火特效
        // if (!string.IsNullOrEmpty(Attribute.FireEffect))
        // {
        //     var effect = ObjectManager.GetPoolItem<IEffect>(Attribute.FireEffect);
        //     var sprite = (Node2D)effect;
        //     sprite.Position = GetLocalFirePosition();
        //     AddChild(sprite);
        //     effect.PlayEffect();
        // }
    }
}