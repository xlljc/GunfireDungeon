
using System;
using System.Collections.Generic;

/// <summary>
/// 事件工厂, 用于统一绑定事件与销毁的情况
/// </summary>
public class EventFactory<T>
{
    /// <summary>
    /// 事件包裹对象
    /// </summary>
    public readonly EventPackage<T> EventPackage;
    
    private readonly List<EventBinder<T>> _binders = new List<EventBinder<T>>();
    
    public EventFactory(EventPackage<T> package)
    {
        EventPackage = package;
    }
    
    /// <summary>
    /// 添加监听事件
    /// </summary>
    public void AddEventListener(T eventType, Action<object> callback)
    {
        _binders.Add(EventPackage.AddEventListener(eventType, callback));
    }

    /// <summary>
    /// 移除所有监听事件
    /// </summary>
    public void RemoveAllEventListener()
    {
        foreach (var eventBinder in _binders)
        {
            EventPackage.RemoveEventListener(eventBinder);
        }
        _binders.Clear();
    }
}