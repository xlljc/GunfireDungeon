
using Godot;

/// <summary>
/// 通用编程零件实体类
/// </summary>
public partial class PartProp : PropActivity
{
    public override void Interactive(ActivityObject master)
    {
        if (master is Role role)
        {
            Pickup();
            role.PickUpPartProp(this);
        }
    }

    public override CheckInteractiveResult CheckInteractive(ActivityObject master)
    {
        if (master is Role)
        {
            return new CheckInteractiveResult(this, true, CheckInteractiveResult.InteractiveType.PickUp);
        }
        return base.CheckInteractive(master);
    }

    /// <summary>
    /// 当道具溢出时调用, 也就是修改了背包大小后背包容不下这个道具时调用, 用于处理扔下道具
    /// </summary>
    public void OnOverflowItem()
    {
        
    }

    public override void OnPickUpItem()
    {
        
    }

    public override void OnRemoveItem()
    {
        
    }
}