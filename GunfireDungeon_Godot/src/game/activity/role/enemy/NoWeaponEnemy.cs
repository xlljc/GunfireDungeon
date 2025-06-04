﻿
using Config;
using Godot;

/// <summary>
/// 没有武器的敌人
/// </summary>
public partial class NoWeaponEnemy : Enemy
{
    private BrushImageData _brushData;
    
    public override void OnInit()
    {
        base.OnInit();
        NoWeaponAttack = true;
        FiringStand = true;
        WeaponPack.SetCapacity(0);
        AnimationPlayer.AnimationFinished += OnAnimationFinished;

        _brushData = LiquidBrushManager.GetBrush("0001");
    }

    protected override void Process(float delta)
    {
        base.Process(delta);
    
        //测试笔刷
        DrawLiquid(_brushData, ExcelConfig.LiquidLayer_List[1]);
    }

    public override void Attack()
    {
        if (AnimationPlayer.CurrentAnimation != AnimatorNames.Attack)
        {
            AnimationPlayer.Play(AnimatorNames.Attack);
        }
    }
    
    /// <summary>
    /// 开始执行攻击逻辑
    /// </summary>
    public virtual void OnAttack()
    {
        if (LookTarget == null)
        {
            return;
        }
        //攻击特效
        var effect = ObjectManager.GetPoolItem<IEffect>(ResourcePath.prefab_effect_weapon_ShotFire0003_tscn);
        var node = (Node2D)effect;
        node.GlobalPosition = FirePoint.GlobalPosition;
        node.Rotation = MountPoint.Rotation;
        node.AddToActivityRoot(RoomLayerEnum.YSortLayer);
        effect.PlayEffect();
        
        var param = new FireBulletParam(ExcelConfig.BulletBase_Map["0006"]);
        param.Position = GetFirePoint();
        param.FireRotation = 0;
        
        var targetPosition = LookTarget.GetCenterPosition();
        var bulletData = FireManager.GetBulletData(this, param);
        for (var i = 0; i < 8; i++)
        {
            var data = bulletData.Clone();
            var tempPos = new Vector2(targetPosition.X + Utils.Random.RandomRangeInt(-30, 30), targetPosition.Y + Utils.Random.RandomRangeInt(-30, 30));
            FireManager.SetParabolaTarget(data, tempPos);
            FireManager.ShootBullet(data, Camp);
        }
    }

    protected override void OnDie()
    {
        var realVelocity = GetRealVelocity();
        var effPos = Position;
        var debris = Create<AutoFreezeObject>(Ids.Id_enemy_dead0002);
        debris.PutDown(effPos, RoomLayerEnum.NormalLayer);
        debris.MoveController.AddForce(Velocity + realVelocity);
        debris.SetForwardDirection(Face);
        debris.BrushPrevPosition =  BrushPrevPosition;
        
        //创建金币
        Gold.CreateGold(Position, RoleState.Gold);
        
        //派发敌人死亡信号
        EventManager.EmitEvent(EventEnum.OnEnemyDie, this);
        //移出场景，但是不销毁
        GetParent().RemoveChild(this);
    }

    private void OnAnimationFinished(StringName name)
    {
        if (name == AnimatorNames.Attack)
        {
            AttackTimer = AttackInterval;
        }
    }
}
