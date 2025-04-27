
using System;
using System.Collections.Generic;
using System.Reflection;
using Config;
using Godot;

/// <summary>
/// 通用编程零件实体类
/// </summary>
public partial class PartProp : PropActivity
{
    /// <summary>
    /// 图标
    /// </summary>
    public Texture2D Icon { get; private set; }

    /// <summary>
    /// 所挂载的武器，没有装备到武器上时该值为 null
    /// </summary>
    public Weapon Weapon { get; set; }
    
    /// <summary>
    /// 零件配置
    /// </summary>
    public ExcelConfig.PartBase PartBase { get; private set; }
    
    /// <summary>
    /// 零件处理逻辑
    /// </summary>
    public PartLogicBase PartLogicBase { get; private set; }
    
    //前置id
    private const string _prefixId = "partProp";
    private static bool _isInit = false;
    
    private static Dictionary<string, ExcelConfig.PartBase> _partBaseMap = new Dictionary<string, ExcelConfig.PartBase>();
    private static Dictionary<string, Type> _parTypes  = new Dictionary<string, Type>();
    
    /// <summary>
    /// 初始化零件属性，并注册零件
    /// </summary>
    public static void InitPartAttribute()
    {
        if (_isInit)
        {
            return;
        }

        _isInit = true;

        var targetType = typeof(PartLogicBase);
        foreach (var type in targetType.Assembly.GetTypes())
        {
            if (type.IsAssignableTo(targetType))
            {
                var pa = type.GetCustomAttribute<PartAttribute>();
                if (pa != null)
                {
                    _parTypes.TryAdd(pa.Name, type);
                }
            }
        }
        
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
            
            _partBaseMap.Add(id, partBase);
        }
    }

    /// <summary>
    /// 创建零件对象
    /// </summary>
    /// <param name="partPropBaseId">零件在 PartBase 表中的 Id</param>
    public static PartProp CreatePropActivity(string partPropBaseId)
    {
        return Create<PartProp>(_prefixId + partPropBaseId);
    }
    
    public override void OnInit()
    {
        base.OnInit();
        var spriteFrames = AnimatedSprite.SpriteFrames;
        Icon = ResourceManager.LoadTexture2D(ActivityBase.Icon);
        spriteFrames.SetFrame(AnimatorNames.Default, 0, Icon);
        
        PartBase = _partBaseMap[ActivityBase.Id];
        
        if (_parTypes.TryGetValue(PartBase.ClassType, out var type))
        {
            var instance = (PartLogicBase)Activator.CreateInstance(type);
            if (instance == null)
            {
                throw new Exception("创建零件对象失败： " + PartBase.ClassType);
            }

            PartLogicBase = instance;
            instance.PartProp = this;
            instance.InitParam(PartBase);
        }
        else
        {
            throw new Exception("未知零件类型： " + PartBase.ClassType);
        }
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
        Master.ThrowPartProp(this);
    }

    public override void OnPickUpItem()
    {
        
    }

    public override void OnRemoveItem()
    {
        
    }
}