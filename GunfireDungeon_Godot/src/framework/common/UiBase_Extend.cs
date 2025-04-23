
using System;

namespace DsUi;

public partial class UiBase
{
    //存放事件集合的对象
    private EventFactory<EventEnum> _eventFactory;
    
    /// <summary>
    /// 添加监听事件, 所有事件会在当前 ui 销毁时自动销毁
    /// </summary>
    /// <param name="eventType">事件类型</param>
    /// <param name="callback">回调函数</param>
    public void AddEventListener(EventEnum eventType, Action<object> callback)
    {
        if (_eventFactory == null)
        {
            _eventFactory = EventManager.CreateEventFactory();
        }
        _eventFactory.AddEventListener(eventType, callback);
    }
    
    /// <summary>
    /// 移除所有的监听事件
    /// </summary>
    public void RemoveAllEventListener()
    {
        if (_eventFactory != null)
        {
            _eventFactory.RemoveAllEventListener();
        }
    }
}