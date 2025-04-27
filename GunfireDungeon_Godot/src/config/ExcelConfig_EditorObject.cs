using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    public partial class EditorObject
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonInclude]
        public string Id;

        /// <summary>
        /// 物体名称 <br/>
        /// 如果Prefab填的是ActivityBase数据, 则可以不填, 因为会从ActivityBase表中获取名称
        /// </summary>
        [JsonInclude]
        public string Name;

        /// <summary>
        /// 备注
        /// </summary>
        [JsonInclude]
        public string Remark;

        /// <summary>
        /// 物体预制体路径或者ActivityBase表Id <br/>
        /// 这里区分是否是ActivityBase对象是直接判断字符串开头是否有"res://"
        /// </summary>
        [JsonInclude]
        public string Prefab;

        /// <summary>
        /// 图标 <br/>
        /// 如果Prefab填的是ActivityBase数据, 则可以不填, 因为会从ActivityBase表中获取图标
        /// </summary>
        [JsonInclude]
        public string Icon;

        /// <summary>
        /// 返回浅拷贝出的新对象
        /// </summary>
        public EditorObject Clone()
        {
            var inst = new EditorObject();
            inst.Id = Id;
            inst.Name = Name;
            inst.Remark = Remark;
            inst.Prefab = Prefab;
            inst.Icon = Icon;
            return inst;
        }
    }
}