using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    public partial class AbnormalStateConfig
    {
        /// <summary>
        /// 异常状态类型id
        /// </summary>
        [JsonInclude]
        public string Id;

        /// <summary>
        /// 名称
        /// </summary>
        [JsonInclude]
        public string Name;

        /// <summary>
        /// 异常状态每层叠加倍率，这个值将与角色异常状态抗性相乘 <br/>
        /// 如果该异常状态只有一层，填一个值就行了
        /// </summary>
        [JsonInclude]
        public float[] Gradient;

        /// <summary>
        /// 异常属性消退速度 <br/>
        /// 每秒消退量 <br/>
        /// 这个值只用于未进入该异常状态时的消退速度
        /// </summary>
        [JsonInclude]
        public float LostSpeed;

        /// <summary>
        /// 额外配置属性
        /// </summary>
        [JsonInclude]
        public Dictionary<string, System.Text.Json.JsonElement> Config;

        /// <summary>
        /// 描述
        /// </summary>
        [JsonInclude]
        public string Details;

        /// <summary>
        /// 图标
        /// </summary>
        [JsonInclude]
        public string Icon;

        /// <summary>
        /// 返回浅拷贝出的新对象
        /// </summary>
        public AbnormalStateConfig Clone()
        {
            var inst = new AbnormalStateConfig();
            inst.Id = Id;
            inst.Name = Name;
            inst.Gradient = Gradient;
            inst.LostSpeed = LostSpeed;
            inst.Config = Config;
            inst.Details = Details;
            inst.Icon = Icon;
            return inst;
        }
    }
}