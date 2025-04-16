
using System.Collections.Generic;

public class PlanningParam
{
    public enum ErrorType
    {
        /// <summary>
        /// 执行成功，Data 参数为 ExcelConfig.BulletBase，也就是第一个发射出去的子弹
        /// </summary>
        None,
        /// <summary>
        /// 法力值不够，因为为法力值不够导致的部分法术执行失败，Data 返回导致失败的法术索引
        /// </summary>
        NoMana,
        /// <summary>
        /// 没有弹丸零件，Data 没有值
        /// </summary>
        NoBullet,
    }

    /// <summary>
    /// <see cref="int"/>
    /// </summary>
    public const string Index = "Index";
    /// <summary>
    /// <see cref="Config.ExcelConfig.BulletBase"/>
    /// </summary>
    public const string FirstBullet = "FirstBullet";
    /// <summary>
    /// <see cref="IBullet"/>
    /// </summary>
    public const string PrevBullet = "PrevBullet";

    /// <summary>
    /// 开火角度
    /// </summary>
    public float FireRotation;

    /// <summary>
    /// 执行结果
    /// </summary>
    public ErrorType Error = ErrorType.NoBullet;
    
    private Dictionary<string, object> _data;
    
    public PlanningParam(float fireRotation)
    {
        FireRotation = fireRotation;
    }

    public void SetValue(string key, object value)
    {
        if (_data == null)
        {
            _data = new Dictionary<string, object>();
        }
        _data[key] = value;
    }
    
    public object GetValue(string key)
    {
        if (_data == null)
        {
            return null;
        }
        return _data[key];
    }
    
    public T GetValue<T>(string key)
    {
        if (_data == null)
        {
            return default;
        }
        return (T)_data[key];
    }
    
    public bool HasValue(string key)
    {
        if (_data == null)
        {
            return false;
        }
        return _data.ContainsKey(key);
    }
}