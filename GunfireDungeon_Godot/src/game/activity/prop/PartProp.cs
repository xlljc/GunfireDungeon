
using Config;
using Godot;

/// <summary>
/// 通用编程零件实体类
/// </summary>
public partial class PartProp : PropActivity
{
    //前置id
    private const string _prefixId = "partProp";
    private static bool _isInit = false;
    
    /// <summary>
    /// 初始化零件属性
    /// </summary>
    public static void InitPartAttribute()
    {
        if (_isInit)
        {
            return;
        }

        _isInit = true;
        
        // 动态创建 ActivityBase
        foreach (var partBase in ExcelConfig.PartBase_List)
        {
            var id = _prefixId + partBase.Id;
            var activityBase = partBase.ActivityTemplate.Clone();
            activityBase.Id = id;
            activityBase.Name = partBase.Name;
            activityBase.Type = ActivityType.Prop;
            activityBase.Quality = partBase.Quality;
            activityBase.Price = partBase.Price;
            activityBase.Intro = partBase.Intro;
            activityBase.Details = partBase.Details;
            activityBase.Icon = partBase.Icon;
            activityBase.ShowInMapEditor = true;
            
            ExcelConfig.ActivityBase_Map.Add(id, activityBase);
            ExcelConfig.ActivityBase_List.Add(activityBase);
        }
    }

    public static PartProp CreatePropActivity(string partPropBaseId)
    {
        return Create<PartProp>(_prefixId + partPropBaseId);
    }

    public override void OnInit()
    {
        base.OnInit();
        var spriteFrames = AnimatedSprite.SpriteFrames;
        var texture = ResourceManager.LoadTexture2D(ActivityBase.Icon);
        spriteFrames.SetFrame(AnimatorNames.Default, 0, texture);
    }

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
        if (master is Role role && role.PartPropPack.FindEmptyIndex() >= 0)
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