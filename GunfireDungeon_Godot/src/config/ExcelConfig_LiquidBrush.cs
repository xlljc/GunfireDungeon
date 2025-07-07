using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    /// <summary>
    /// 液体笔刷
    /// </summary>
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
        /// 补帧间距倍率(0-1)
        /// </summary>
        [JsonInclude]
        public float Ffm;

        /// <summary>
        /// 返回浅拷贝出的新对象
        /// </summary>
        public LiquidBrush Clone()
        {
            var inst = new LiquidBrush();
            inst.Id = Id;
            inst.Remark = Remark;
            inst.BrushTexture = BrushTexture;
            inst.Ffm = Ffm;
            return inst;
        }
    }
}