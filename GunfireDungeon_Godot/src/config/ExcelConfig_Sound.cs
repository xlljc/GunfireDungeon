using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    /// <summary>
    /// 音效
    /// </summary>
    public partial class Sound
    {
        /// <summary>
        /// 音效id
        /// </summary>
        [JsonInclude]
        public string Id;

        /// <summary>
        /// 文件路径
        /// </summary>
        [JsonInclude]
        public string Path;

        /// <summary>
        /// 音量(范围0 - 1)
        /// </summary>
        [JsonInclude]
        public float Volume;

        /// <summary>
        /// 备注
        /// </summary>
        [JsonInclude]
        public string Remark;

        /// <summary>
        /// 返回浅拷贝出的新对象
        /// </summary>
        public Sound Clone()
        {
            var inst = new Sound();
            inst.Id = Id;
            inst.Path = Path;
            inst.Volume = Volume;
            inst.Remark = Remark;
            return inst;
        }
    }
}