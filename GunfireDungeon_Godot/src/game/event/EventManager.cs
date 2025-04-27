
using System;

/// <summary>
/// 全局事件管理器
/// </summary>
public static class EventManager
{
    private static EventPackage<EventEnum> _eventPackage = new EventPackage<EventEnum>();

    /// <summary>
    /// 添加监听事件, 并返回事件绑定对象
    /// </summary>
    /// <param name="eventType">监听事件类型</param>
    /// <param name="callback">回调函数</param>
    public static EventBinder<EventEnum> AddEventListener(EventEnum eventType, Action<object> callback)
    {
        return _eventPackage.AddEventListener(eventType, callback);
    }

    /// <summary>
    /// 派发事件
    /// </summary>
    /// <param name="eventType">事件类型</param>
    /// <param name="arg">传递参数</param>
    public static void EmitEvent(EventEnum eventType, object arg = null)
    {
        _eventPackage.EmitEvent(eventType, arg);
    }

    /// <summary>
    /// 根据事件绑定对象移除一个监听事件
    /// </summary>
    public static void RemoveEventListener(EventBinder<EventEnum> binder)
    {
        _eventPackage.RemoveEventListener(binder);
    }

    /// <summary>
    /// 移除指定类型的所有事件
    /// </summary>
    public static void RemoveAllEventListener(EventEnum eventType)
    {
        _eventPackage.RemoveAllEventListener(eventType);
    }

    /// <summary>
    /// 移除所有监听事件
    /// </summary>
    public static void ClearAllEventListener()
    {
        _eventPackage.ClearAllEventListener();
    }

    /// <summary>
    /// 创建一个事件工厂
    /// </summary>
    public static EventFactory<EventEnum> CreateEventFactory()
    {
        return new EventFactory<EventEnum>(_eventPackage);
    }
}