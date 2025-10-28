
using System;
using System.Collections.Generic;

public class PlanningParam
{
    // public enum ErrorType
    // {
    //     /// <summary>
    //     /// 执行成功，Data 参数为 ExcelConfig.BulletBase，也就是第一个发射出去的子弹
    //     /// </summary>
    //     None,
    //     /// <summary>
    //     /// 法力值不够，因为为法力值不够导致的部分法术执行失败，Data 返回导致失败的法术索引
    //     /// </summary>
    //     NoMana,
    //     /// <summary>
    //     /// 没有弹丸零件，Data 没有值
    //     /// </summary>
    //     NoBullet,
    // }

    public delegate bool UseManaCallback(int mana);
    
    /// <summary>
    /// 没有足够的法力值的零件索引
    /// <see cref="int"/>
    /// </summary>
    public const string NoManaIndex = "NoManaIndex";
    /// <summary>
    /// 第一个发射出去的子弹
    /// <see cref="Config.ExcelConfig.BulletBase"/>
    /// </summary>
    public const string FirstBullet = "FirstBullet";
    /// <summary>
    /// 上一个发射出去的子弹
    /// <see cref="IBullet"/>
    /// </summary>
    public const string PrevBullet = "PrevBullet";

    /// <summary>
    /// 法力值是否够
    /// </summary>
    public bool SufficientMana = true;

    /// <summary>
    /// 是否发射子弹
    /// </summary>
    public bool HasBullet = false;
    
    /// <summary>
    /// 开火角度
    /// </summary>
    public float FireRotation;

    // /// <summary>
    // /// 执行结果
    // /// </summary>
    // public ErrorType Error = ErrorType.NoBullet;
    
    private Dictionary<string, object> _data;
    private readonly UseManaCallback _useManaFunc;
    
    public PlanningParam(float fireRotation, UseManaCallback callback)
    {
        FireRotation = fireRotation;
        _useManaFunc = callback;
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

    /// <summary>
    /// 使用法力值，返回是否执行成功
    /// </summary>
    public bool UseManaBuff(int mana)
    {
        if (_useManaFunc != null)
        {
            return _useManaFunc(mana);
        }

        return false;
    }
}