
using System;
using Config;
using Godot;

/// <summary>
/// 垂直往填上飞, 落在地上爆炸产生一个子弹圈
/// </summary>
[Tool]
public partial class SpecialBullet0001 : ActivityObject, IPoolItem
{
    /// <summary>
    /// 创建子分裂子弹时的回调
    /// </summary>
    public event Action<IBullet> OnCreateSplitBulletEvent; 
    
    public bool IsRecycled { get; set; }
    public string Logotype { get; set; }
    
    private string _bulletId;
    private int _bulletCount;
    private Role _role;
    private Vector2 _targetPosition;
    
    public void InitBullet(string bulletId, int bulletCount, Role role, Vector2 targetPosition)
    {
        _bulletId = bulletId;
        _bulletCount = bulletCount;
        _role = role;
        _targetPosition = targetPosition;
    }

    protected override void OnThrowMaxHeight(float height)
    {
        Position = _targetPosition;
        VerticalSpeed = -50;
        ShowShadowSprite();
    }

    protected override void OnFallToGround()
    {
        if (!string.IsNullOrEmpty(_bulletId) && (_role != null && !_role.IsDestroyed))
        {
            var bulletBase = ExcelConfig.BulletBase_Map[_bulletId];
            var bulletData = FireManager.GetBulletData(_role, 0, bulletBase);
            
            //创建分裂子弹
            var a = Mathf.Pi * 2 / _bulletCount;
            for (var i = 0; i < _bulletCount; i++)
            {
                var clone = bulletData.Clone();
                clone.Rotation = a * i;
                clone.Position = Position + new Vector2(5, 0).Rotated(clone.Rotation);
                var shootBullet = FireManager.ShootBullet(clone, clone.TriggerRole.Camp);
                if (OnCreateSplitBulletEvent != null)
                {
                    OnCreateSplitBulletEvent(shootBullet);
                }
            }
        }
        
        //执行回收
        ObjectPool.Reclaim(this);
    }
    
    public void OnReclaim()
    {
        Visible = false;
        GetParent().CallDeferred(Node.MethodName.RemoveChild, this);
    }

    public void OnLeavePool()
    {
        OnCreateSplitBulletEvent = null;
        Visible = true;
        _role = null;
        Altitude = 0;
        VerticalSpeed = 0;
        MoveController.ClearForce();
        MoveController.BasisVelocity = Vector2.Zero;
        Velocity = Vector2.Zero;
        _bulletId = null;
    }
}