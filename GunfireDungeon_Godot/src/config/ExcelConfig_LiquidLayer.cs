using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    public partial class LiquidLayer
    {
        /// <summary>
        /// 表Id
        /// </summary>
        [JsonInclude]
        public string Id;

        /// <summary>
        /// 备注
        /// </summary>
        [JsonInclude]
        public string Remark;

        /// <summary>
        /// 纹理
        /// </summary>
        [JsonInclude]
        public string Texture;

        /// <summary>
        /// 横向帧数
        /// </summary>
        [JsonInclude]
        public float Hframes;

        /// <summary>
        /// 动画速度
        /// </summary>
        [JsonInclude]
        public float AnimSpeed;

        /// <summary>
        /// 返回浅拷贝出的新对象
        /// </summary>
        public LiquidLayer Clone()
        {
            var inst = new LiquidLayer();
            inst.Id = Id;
            inst.Remark = Remark;
            inst.Texture = Texture;
            inst.Hframes = Hframes;
            inst.AnimSpeed = AnimSpeed;
            return inst;
        }
    }
}