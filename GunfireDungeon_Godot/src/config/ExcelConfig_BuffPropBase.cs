using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    /// <summary>
    /// 被动道具
    /// </summary>
    public partial class BuffPropBase
    {
        /// <summary>
        /// Buff Id
        /// </summary>
        [JsonInclude]
        public string Id;

        /// <summary>
        /// 备注
        /// </summary>
        [JsonInclude]
        public string Remark;

        /// <summary>
        /// 属性绑定Buff实体的Id，这个id时ActivityBase表Id
        /// </summary>
        public ActivityBase Activity;

        /// <summary>
        /// 被动Buff效果 <br/>
        /// 也就是当前buff道具所有挂载的被动属性集合, 具体属性名称请参阅buff属性表 <br/>
        /// key为buff属性名称 <br/>
        /// value为buff初始化参数
        /// </summary>
        [JsonInclude]
        public Dictionary<string, System.Text.Json.JsonElement[]> Buff;

        /// <summary>
        /// 返回浅拷贝出的新对象
        /// </summary>
        public BuffPropBase Clone()
        {
            var inst = new BuffPropBase();
            inst.Id = Id;
            inst.Remark = Remark;
            inst.Activity = Activity;
            inst.Buff = Buff;
            return inst;
        }
    }
    private class Ref_BuffPropBase : BuffPropBase
    {
        [JsonInclude]
        public string __Activity;

    }
}