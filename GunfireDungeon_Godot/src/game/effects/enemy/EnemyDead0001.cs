
using System.Collections;
using DsUi;
using Godot;

/// <summary>
/// 敌人死亡碎片
/// </summary>
public partial class EnemyDead0001 : ActivityObject, ICorpsesFragment
{
    /// <summary>
    /// 粒子播放器
    /// </summary>
    [Export, ExportFillNode]
    public GpuParticles2D GPUParticles { get; private set; }
    
    /// <summary>
    /// 上一帧笔刷坐标
    /// </summary>
    public Vector2I? PrevPosition = null;
    //private BrushImageData _brushData;
    
    private GpuParticles2D _gpuParticles2D;
    private bool _playOver = false;
    private bool _runBrush = true;
    
    public override void OnInit()
    {
        var frameCount = AnimatedSprite.SpriteFrames.GetFrameCount(AnimatorNames.Default);
        AnimatedSprite.Frame = Utils.Random.RandomRangeInt(0, frameCount - 1);
        
        Throw(
            Utils.Random.RandomRangeInt(0, 16),
            Utils.Random.RandomRangeInt(10, 60),
            new Vector2(Utils.Random.RandomRangeInt(-25, 25), Utils.Random.RandomRangeInt(-25, 25)),
            Utils.Random.RandomRangeInt(-360, 360)
        );
        
        //_brushData = LiquidBrushManager.GetBrush("0003");
    }
    
    public void SetBloodColor(Color color)
    {
        //_brushData = _brushData.Modulate(color);
        GPUParticles.Modulate = color;
        StartCoroutine(EmitParticles());
    }

    protected override void Process(float delta)
    {
        if (_playOver && !IsThrowing && Altitude <= 0 && MoveController.IsMotionless())
        {
            MoveController.SetAllVelocity(Vector2.Zero);
            Freeze();
            _runBrush = false;
        }
        else if (_runBrush && AffiliationArea != null) //测试笔刷
        {
            var pos = Position.AsVector2I();
            if (Altitude <= 0.25f)
            {
                //World.LiquidCanvas.DrawBrush(_brushData, PrevPosition, pos, 0);
            }

            PrevPosition = pos;
        }
    }

    public IEnumerator EmitParticles()
    {
        GPUParticles.Emitting = true;
        yield return new WaitForSeconds(Utils.Random.RandomRangeFloat(1f, 2.5f));
        GPUParticles.Emitting = false;
        yield return new WaitForSeconds(1);
        _playOver = true;
    }
}