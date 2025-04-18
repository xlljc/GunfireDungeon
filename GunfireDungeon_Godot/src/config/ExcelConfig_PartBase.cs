using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    public partial class PartBase
    {
        /// <summary>
        /// 零件id
        /// </summary>
        [JsonInclude]
        public string Id;

        /// <summary>
        /// 零件名称
        /// </summary>
        [JsonInclude]
        public string Name;

        /// <summary>
        /// 绑定的物体模板
        /// </summary>
        public ActivityBase ActivityTemplate;

        /// <summary>
        /// 物体简介 <br/>
        /// 一句对物体简短的介绍, 比如拾起物体时弹出的描述
        /// </summary>
        [JsonInclude]
        public string Intro;

        /// <summary>
        /// 物体详情 <br/>
        /// 在图鉴中的描述
        /// </summary>
        [JsonInclude]
        public string Details;

        /// <summary>
        /// 物体品质, 用于武器和道具 <br/>
        /// 通用物品: 1 <br/>
        /// 基础: 2 <br/>
        /// 普通: 3 <br/>
        /// 稀有: 4 <br/>
        /// 史诗: 5 <br/>
        /// 传说: 6 <br/>
        /// 独一无二: 7
        /// </summary>
        [JsonInclude]
        public ActivityQuality Quality;

        /// <summary>
        /// 商店售价
        /// </summary>
        [JsonInclude]
        public uint Price;

        /// <summary>
        /// 图标
        /// </summary>
        [JsonInclude]
        public string Icon;

        /// <summary>
        /// 零件类型 <br/>
        /// Bullet(弹丸):0 <br/>
        /// Buff(弹丸增益效果):1 <br/>
        /// Passive(被动效果):2
        /// </summary>
        [JsonInclude]
        public PartType Type;

        /// <summary>
        /// 消耗法力值
        /// </summary>
        [JsonInclude]
        public int Mana;

        /// <summary>
        /// 备注
        /// </summary>
        [JsonInclude]
        public string Remark;

        /// <summary>
        /// 返回浅拷贝出的新对象
        /// </summary>
        public PartBase Clone()
        {
            var inst = new PartBase();
            inst.Id = Id;
            inst.Name = Name;
            inst.ActivityTemplate = ActivityTemplate;
            inst.Intro = Intro;
            inst.Details = Details;
            inst.Quality = Quality;
            inst.Price = Price;
            inst.Icon = Icon;
            inst.Type = Type;
            inst.Mana = Mana;
            inst.Remark = Remark;
            return inst;
        }
    }
    private class Ref_PartBase : PartBase
    {
        [JsonInclude]
        public string __ActivityTemplate;

    }
}