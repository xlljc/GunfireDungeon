using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
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
        /// 返回浅拷贝出的新对象
        /// </summary>
        public DamageConfig Clone()
        {
            var inst = new DamageConfig();
            inst.Id = Id;
            inst.Name = Name;
            inst.Color = Color;
            return inst;
        }
    }
}