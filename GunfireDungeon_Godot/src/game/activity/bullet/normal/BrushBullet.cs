using Config;
using Godot;

/// <summary>
/// 带笔刷的子弹
/// </summary>
public partial class BrushBullet : Bullet
{
    /// <summary>
    /// 笔刷 id
    /// </summary>
    [Export]
    public string BrushId { get; private set; }
    
    /// <summary>
    /// 笔刷层 id
    /// </summary>
    [Export]
    public string LayerId { get; private set; }

    /// <summary>
    /// 生效高度, 当物体离地高度小于这个值时生效, 当值小于 0 时一直生效
    /// </summary>
    [Export]
    public float EffectiveAltitude { get; set; } = -1;

    private BrushImageData _brushData;
    private ExcelConfig.LiquidLayer _layer;

    public override void OnInit()
    {
        base.OnInit();
        _brushData = LiquidBrushManager.GetBrush(BrushId);
        _layer = ExcelConfig.LiquidLayer_Map[LayerId];
    }

    protected override void Process(float delta)
    {
        if (IsRecycled)
        {
            return;
        }
        base.Process(delta);
        //测试笔刷
        if (EffectiveAltitude < 0 || Altitude <= EffectiveAltitude)
        {
            DrawLiquid(_brushData, _layer);
        }
        else
        {
            BrushPrevPosition = null;
        }
    }

    /// <summary>
    /// 设置笔刷
    /// </summary>
    public void SetBrush(string brushId)
    {
        BrushId = brushId;
        _brushData = LiquidBrushManager.GetBrush(BrushId);
    }
    
    /// <summary>
    /// 设置笔刷层
    /// </summary>
    public void SetLayer(string layerId)
    {
        LayerId = layerId;
        _layer = ExcelConfig.LiquidLayer_Map[LayerId];
    }

    public override void OnPlayDisappearEffect()
    {
        PlayDisappearEffect(ResourcePath.prefab_effect_bullet_BulletDisappear0002_tscn);
    }

    public override void OnPlayCollisionEffect(KinematicCollision2D collision)
    {
        DrawLiquid(_brushData, _layer);
        PlayCollisionEffect(collision, ResourcePath.prefab_effect_bullet_BulletSmoke0002_tscn);
    }

    public override void OnReclaim()
    {
        base.OnReclaim();
        BrushPrevPosition = null;
    }

    public override void OnLeavePool()
    {
        base.OnLeavePool();
        BrushPrevPosition = null;
    }
}