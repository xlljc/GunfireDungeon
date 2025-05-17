using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    public partial class LiquidBrush
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
        /// 笔刷贴图
        /// </summary>
        [JsonInclude]
        public string BrushTexture;

        /// <summary>
        /// 绘制的层级
        /// </summary>
        public LiquidLayer Layer;

        /// <summary>
        /// 补帧间距倍率(0-1)
        /// </summary>
        [JsonInclude]
        public float Ffm;

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
        public LiquidBrush Clone()
        {
            var inst = new LiquidBrush();
            inst.Id = Id;
            inst.Remark = Remark;
            inst.BrushTexture = BrushTexture;
            inst.Layer = Layer;
            inst.Ffm = Ffm;
            inst.Duration = Duration;
            inst.WriteOffSpeed = WriteOffSpeed;
            return inst;
        }
    }
    private class Ref_LiquidBrush : LiquidBrush
    {
        [JsonInclude]
        public string __Layer;

    }
}