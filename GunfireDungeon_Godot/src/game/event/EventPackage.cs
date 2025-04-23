using System;
using System.Collections.Generic;
using DsUi;

/// <summary>
/// 事件管理包裹
/// </summary>
public class EventPackage<T> : IDestroy
{
    public bool IsDestroyed { get; private set; }
    
    private Dictionary<T, List<EventBinder<T>>> _eventMap = new Dictionary<T, List<EventBinder<T>>>();

    /// <summary>
    /// 添加监听事件, 并返回事件绑定对象
    /// </summary>
    /// <param name="eventType">监听事件类型</param>
    /// <param name="callback">回调函数</param>
    public EventBinder<T> AddEventListener(T eventType, Action<object> callback)
    {
        if (_eventMap == null)
        {
            return null;
        }
        EventBinder<T> binder;
        if (!_eventMap.TryGetValue(eventType, out var list))
        {
            list = new List<EventBinder<T>>();
            _eventMap.Add(eventType, list);
            binder = new EventBinder<T>(this, eventType, callback);
            list.Add(binder);
            return binder;
        }

        for (var i = 0; i < list.Count; i++)
        {
            var item = list[i];
            if (item.Callback == callback)
            {
                return item;
            }
        }

        binder = new EventBinder<T>(this, eventType, callback);
        list.Add(binder);
        return binder;
    }

    /// <summary>
    /// 派发事件
    /// </summary>
    /// <param name="eventType">事件类型</param>
    /// <param name="arg">传递参数</param>
    public void EmitEvent(T eventType, object arg = null)
    {
        if (_eventMap == null)
        {
            return;
        }
        if (_eventMap.TryGetValue(eventType, out var list))
        {
            var binders = list.ToArray();
            for (var i = 0; i < binders.Length; i++)
            {
                var binder = binders[i];
                if (!binder.IsDiscard)
                {
                    try
                    {
                        binder.Callback(arg);
                    }
                    catch (Exception e)
                    {
                        Debug.LogError($"EventManager 派发事件: '{eventType}' 发生异常: \n" + e.Message + "\n" + e.StackTrace);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 根据事件绑定对象移除一个监听事件
    /// </summary>
    public void RemoveEventListener(EventBinder<T> binder)
    {
        if (_eventMap == null)
        {
            return;
        }
        if (_eventMap.TryGetValue(binder.EventType, out var list))
        {
            if (list.Remove(binder))
            {
                binder.IsDiscard = true;
                if (list.Count == 0)
                {
                    _eventMap.Remove(binder.EventType);
                }
            }
        }
    }

    /// <summary>
    /// 移除指定类型的所有事件
    /// </summary>
    public void RemoveAllEventListener(T eventType)
    {
        if (_eventMap == null)
        {
            return;
        }
        if (_eventMap.TryGetValue(eventType, out var list))
        {
            foreach (var binder in list)
            {
                binder.IsDiscard = true;
            }

            _eventMap.Remove(eventType);
        }
    }

    /// <summary>
    /// 移除所有监听事件
    /// </summary>
    public void ClearAllEventListener()
    {
        if (_eventMap == null)
        {
            return;
        }
        foreach (var kv in _eventMap)
        {
            foreach (var binder in kv.Value)
            {
                binder.IsDiscard = true;
            }
        }

        _eventMap.Clear();
    }

    /// <summary>
    /// 创建一个事件工厂
    /// </summary>
    public EventFactory<T> CreateEventFactory()
    {
        return new EventFactory<T>(this);
    }

    public void Destroy()
    {
        if (IsDestroyed)
        {
            return;
        }
        IsDestroyed = true;
        ClearAllEventListener();
        _eventMap = null;
    }
}