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
        FireBlockList.SetLogicBlock(0, new MultipleLogicBlock()
        {
            Occupancy = 2,
            UseMana = 3,
        });
        
        FireBlockList.SetLogicBlock(2, new MultipleLogicBlock()
        {
            Occupancy = 3,
            UseMana = 3,
        });
        FireBlockList.SetLogicBlock(1, new BulletLogicBlock()
        {
            UseMana = 12,
            ScatteringAngle = 10,
            Bullet = ExcelConfig.BulletBase_Map["0001"]
        });
        FireBlockList.SetLogicBlock(3, new BulletLogicBlock()
        {
            UseMana = 40,
            ScatteringAngle = 10,
            Bullet = ExcelConfig.BulletBase_Map["0005"]
        });
        
        FireBlockList.SetLogicBlock(4, new MultipleLogicBlock()
        {
            Occupancy = 2,
            UseMana = 3,
        });
        FireBlockList.SetLogicBlock(5, new BulletLogicBlock()
        {
            UseMana = 23,
            ScatteringAngle = 10,
            Bullet = ExcelConfig.BulletBase_Map["0007"]
        });
        FireBlockList.SetLogicBlock(8, new BulletLogicBlock()
        {
            UseMana = 23,
            ScatteringAngle = 10,
            Bullet = ExcelConfig.BulletBase_Map["0007"]
        });
        
        FireBlockList.RefreshLogicTree();
        GD.Print(FireBlockList.GetFirstLogicBlock().GetTreeString());
    }
    
    protected override void OnFire()
    {
        // if (Master == World.Player)
        // {
        //     //创建抖动
        //     GameCamera.Main.DirectionalShake(Vector2.Right.Rotated(GlobalRotation) * Attribute.CameraShake);
        // }
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