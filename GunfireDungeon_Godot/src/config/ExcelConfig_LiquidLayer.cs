using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    /// <summary>
    /// 液体画布层
    /// </summary>
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
        /// 开始消退时间,单位秒 <br/>
        /// 小于0则永远不会消退
        /// </summary>
        [JsonInclude]
        public float Duration;

        /// <summary>
        /// 消退速度, 也就是 Alpha 值每秒变化的速度
        /// </summary>
        [JsonInclude]
        public float WriteOffSpeed;

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
            inst.Duration = Duration;
            inst.WriteOffSpeed = WriteOffSpeed;
            return inst;
        }
    }
}