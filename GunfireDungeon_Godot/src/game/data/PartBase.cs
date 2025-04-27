using System.Text.Json;

namespace Config;

public partial class ExcelConfig
{
    public partial class PartBase
    {
        public int GetParam(string key, int defaultValue)
        {
            return Param.TryGetValue(key, out var value) ? value.GetInt32() : defaultValue;
        }
        
        public float GetParam(string key, float defaultValue)
        {
            return Param.TryGetValue(key, out var value) ? value.GetSingle() : defaultValue;
        }
        
        public string GetParam(string key, string defaultValue)
        {
            return Param.TryGetValue(key, out var value) ? value.GetString() : defaultValue;
        }
        
        public bool GetParam(string key, bool defaultValue)
        {
            return Param.TryGetValue(key, out var value) ? value.GetBoolean() : defaultValue;
        }
    }
}