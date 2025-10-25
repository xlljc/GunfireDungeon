using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    /// <summary>
    /// 伤害类型属性
    /// </summary>
    public partial class DamageConfig
    {
        /// <summary>
        /// 伤害类型id
        /// </summary>
        [JsonInclude]
        public string Id;

        /// <summary>
        /// 名称
        /// </summary>
        [JsonInclude]
        public string Name;

        /// <summary>
        /// 颜色
        /// </summary>
        [JsonInclude]
        public SerializeColor Color;

        /// <summary>
        /// 护盾减免
        /// </summary>
        [JsonInclude]
        public float ShieldReduce;

        /// <summary>
        /// 装甲减免
        /// </summary>
        [JsonInclude]
        public float ArmorReduce;

        /// <summary>
        /// 生命减免
        /// </summary>
        [JsonInclude]
        public float HealthReduce;

        /// <summary>
        /// 可否暴击
        /// </summary>
        [JsonInclude]
        public bool Critable;

        /// <summary>
        /// 额外效果
        /// </summary>
        [JsonInclude]
        public System.Text.Json.JsonElement Effect;

        /// <summary>
        /// 减免类型 <br/>
        /// Physical（物理减免）：0 <br/>
        /// Fire（火焰减免）：1 <br/>
        /// Electric（电击减免）：2 <br/>
        /// Chemical（化学减免）：3 <br/>
        /// Optical（光学减免）：4 <br/>
        /// DarkMatter（暗物质减免）：5 <br/>
        /// Explosive（爆破减免）：6
        /// </summary>
        [JsonInclude]
        public ReduceEnum ReduceType;

        /// <summary>
        /// 默认减免上限
        /// </summary>
        [JsonInclude]
        public float MinReduce;

        /// <summary>
        /// 默认减免下限
        /// </summary>
        [JsonInclude]
        public float MaxReduce;

        /// <summary>
        /// 返回浅拷贝出的新对象
        /// </summary>
        public DamageConfig Clone()
        {
            var inst = new DamageConfig();
            inst.Id = Id;
            inst.Name = Name;
            inst.Color = Color;
            inst.ShieldReduce = ShieldReduce;
            inst.ArmorReduce = ArmorReduce;
            inst.HealthReduce = HealthReduce;
            inst.Critable = Critable;
            inst.Effect = Effect;
            inst.ReduceType = ReduceType;
            inst.MinReduce = MinReduce;
            inst.MaxReduce = MaxReduce;
            return inst;
        }
    }
}