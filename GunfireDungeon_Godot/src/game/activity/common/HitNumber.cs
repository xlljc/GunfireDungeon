
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

    public void SetNumber(int number)
    {
        NumberSprite.SetNumber(number);
    }
    

    public void OnReclaim()
    {
        GetParent().CallDeferred(Node.MethodName.RemoveChild, this);
    }

    public void OnLeavePool()
    {
        Modulate = new Color(1, 1, 1, 1);
    }

    protected override void OnThrowOver()
    {
        var tween = CreateTween();
        tween.TweenProperty(this, new NodePath(CanvasItem.PropertyName.Modulate), new Color(1, 1, 1, 0), 1);
        tween.TweenCallback(Callable.From(() =>
        {
            ObjectPool.Reclaim(this);
        }));
        tween.Play();
    }

    protected override void OnDestroy()
    {
        NumberSprite.Destroy();
    }
}