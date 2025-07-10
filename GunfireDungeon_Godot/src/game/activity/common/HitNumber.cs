
using Config;
using Godot;

/// <summary>
/// 用于显示伤害数字
/// </summary>
public partial class HitNumber : ActivityObject, IPoolItem
{
    /// <summary>
    /// 绑定的纹理数字组件
    /// </summary>
    [Export]
    public NumberSprite NumberSprite;

    public bool IsRecycled { get; set; }
    public string Logotype { get; set; }

    /// <summary>
    /// 设置显示的伤害数字
    /// </summary>
    public void SetNumber(uint number, DamageType damageType)
    {
        var damageConfig = ExcelConfig.DamageConfig_Map[((int)damageType).ToString()];
        NumberSprite.SetNumber(number);
        NumberSprite.SetColor(damageConfig.Color.AsColor());
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