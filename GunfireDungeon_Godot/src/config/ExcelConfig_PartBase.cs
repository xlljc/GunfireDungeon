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
        /// 
        /// </summary>
        [JsonInclude]
        public string Name;

        /// <summary>
        /// 备注
        /// </summary>
        [JsonInclude]
        public string Remark;

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
        /// 返回浅拷贝出的新对象
        /// </summary>
        public PartBase Clone()
        {
            var inst = new PartBase();
            inst.Id = Id;
            inst.Name = Name;
            inst.Remark = Remark;
            inst.Icon = Icon;
            inst.Type = Type;
            inst.Mana = Mana;
            return inst;
        }
    }
}