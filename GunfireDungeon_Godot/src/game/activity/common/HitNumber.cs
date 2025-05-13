
using Godot;

/// <summary>
/// 伤害数字
/// </summary>
public partial class HitNumber : ActivityObject, IPoolItem
{
    [Export]
    public NumberSprite NumberSprite;
    
    public bool IsRecycled { get; set; }
    public string Logotype { get; set; }

    public void OnReclaim()
    {
        GetParent().CallDeferred(Node.MethodName.RemoveChild, this);
    }

    public void OnLeavePool()
    {
        
    }

    protected override void OnThrowOver()
    {
        this.CallDelay(1f, () =>
        {
            ObjectPool.Reclaim(this);
        });
    }

    protected override void OnDestroy()
    {
        NumberSprite.Destroy();
    }
}