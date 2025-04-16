
using System;
using Config;
using DsUi;
using Godot;

public interface IBullet : ICoroutine, IPoolItem
{
    /// <summary>
    /// 当子弹运行逻辑执行完成时触发
    /// </summary>
    event Action OnLogicalFinishEvent;

    /// <summary>
    /// 子弹所在阵营
    /// </summary>
    CampEnum Camp { get; set; }
    
    /// <summary>
    /// 子弹数据
    /// </summary>
    BulletData BulletData { get; }
    
    /// <summary>
    /// 子弹状态
    /// </summary>
    BulletStateEnum State { get; }
    
    /// <summary>
    /// 子弹离地面高度
    /// </summary>
    float Altitude { get; set; }

    /// <summary>
    /// 初始化子弹数据
    /// </summary>
    void InitData(BulletData data, CampEnum camp);
    
    /// <summary>
    /// 子弹运行逻辑执行完成
    /// </summary>
    void LogicalFinish();

    /// <summary>
    /// 绑定子弹运行逻辑执行完成事件，仅执行一次，自动解绑
    /// </summary>
    void BindSingleLogicalFinishEvent(Action callback);

    /// <summary>
    /// 获取子弹结束点的位置
    /// </summary>
    Vector2 GetEndPosition();
}