
using System;

/// <summary>
/// 事件绑定对象
/// </summary>
public class EventBinder<T>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public readonly T EventType;
    /// <summary>
    /// 事件回调函数
    /// </summary>
    public readonly Action<object> Callback;
    /// <summary>
    /// 事件包裹对象
    /// </summary>
    public readonly EventPackage<T> EventPackage;
    /// <summary>
    /// 该监听事件是否被移除
    /// </summary>
    public bool IsDiscard;

    
    public EventBinder(EventPackage<T> eventPackage, T eventType, Action<object> callback)
    {
        EventPackage = eventPackage;
        EventType = eventType;
        Callback = callback;
    }

    /// <summary>
    /// 移除当前监听事件
    /// </summary>
    public void RemoveEventListener()
    {
        EventPackage.RemoveEventListener(this);
    }
}