using System.Text.Json;

namespace Config;

public partial class ExcelConfig
{
    public partial class PartBase
    {
        /// <summary>
        /// 获取参数 Param 字段中配置的参数
        /// </summary>
        public int GetParam(string key, int defaultValue)
        {
            return Param.TryGetValue(key, out var value) ? value.GetInt32() : defaultValue;
        }
        
        /// <summary>
        /// 获取参数 Param 字段中配置的参数
        /// </summary>
        public float GetParam(string key, float defaultValue)
        {
            return Param.TryGetValue(key, out var value) ? value.GetSingle() : defaultValue;
        }
        
        /// <summary>
        /// 获取参数 Param 字段中配置的参数
        /// </summary>
        public string GetParam(string key, string defaultValue)
        {
            return Param.TryGetValue(key, out var value) ? value.GetString() : defaultValue;
        }
        
        /// <summary>
        /// 获取参数 Param 字段中配置的参数
        /// </summary>
        public bool GetParam(string key, bool defaultValue)
        {
            return Param.TryGetValue(key, out var value) ? value.GetBoolean() : defaultValue;
        }

        /// <summary>
        /// 获取参数 Param 字段中配置的参数
        /// </summary>
        public T GetParam<T>(string key, T defaultValue)
        {
            return Param.TryGetValue(key, out var value) ? value.Deserialize<T>() : defaultValue;
        }
    }
}