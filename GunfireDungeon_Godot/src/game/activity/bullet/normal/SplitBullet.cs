
using System;
using Config;
using Godot;

/// <summary>
/// 分裂子弹
/// </summary>
public partial class SplitBullet : Bullet
{
    /// <summary>
    /// 创建子分裂子弹时的回调
    /// </summary>
    public event Action<IBullet> OnCreateSplitBulletEvent; 
    
    private BulletData _bulletData;
    private int _count = 0;

    /// <summary>
    /// 设置分裂的子弹
    /// </summary>
    /// <param name="data">子弹数据</param>
    /// <param name="count">子弹数量</param>
    public void SetSplitBullet(BulletData data, int count)
    {
        _bulletData = data;
        _count = count;
    }

    public override void LogicalFinish()
    {
        base.LogicalFinish();

        //创建分裂子弹
        if (_count > 0 && _bulletData != null)
        {
            var a = Mathf.Pi * 2 / _count;
            for (var i = 0; i < _count; i++)
            {
                var clone = _bulletData.Clone();
                clone.Rotation = a * i;
                clone.Position = Position + new Vector2(5, 0).Rotated(clone.Rotation);
                var shootBullet = FireManager.ShootBullet(clone, clone.TriggerRole.Camp);
                if (OnCreateSplitBulletEvent != null)
                {
                    OnCreateSplitBulletEvent(shootBullet);
                }
            }
        }
    }

    public override void OnLeavePool()
    {
        base.OnLeavePool();
        OnCreateSplitBulletEvent = null;
        _bulletData = null;
        _count = 0;
    }
}