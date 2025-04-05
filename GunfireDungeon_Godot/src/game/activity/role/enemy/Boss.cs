
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Config;
using DsUi;
using Godot;

/// <summary>
/// Boss逻辑类
/// </summary>
[Tool]
public partial class Boss : AiRole
{
    private long _attaclCoroutine = -1;
    private List<Vector2> _vertices;
    private float _targetRotation;

    private int state = 0;

    public override void OnInit()
    {
        base.OnInit();
        WeaponPack.SetCapacity(0);
        Camp = CampEnum.Camp2;
        NoWeaponAttack = true;
        MountLookTarget = true;
        
        FiringStand = true;

        MaxHp = 2000;
        Hp = MaxHp;

        AnimatedSprite.Visible = false;
        StateController.Enable = false;
    }

    protected override RoleState OnCreateRoleState()
    {
        var roleState = base.OnCreateRoleState();
        roleState.MoveSpeed = 45;
        return roleState;
    }

    protected override void Process(float delta)
    {
        if (Hp <= 0)
        {
            return;
        }
        base.Process(delta);
        LookTarget = World.Player;
        ViewArea.LookAt(LookTarget.Position);
        //UpdateFace();

        var velocity = BasisVelocity;
        if ((Face == FaceDirection.Right && velocity.X > 0) || (Face == FaceDirection.Left && velocity.X < 0))
        {
            _targetRotation = 10;
        }
        else if ((Face == FaceDirection.Right && velocity.X < 0) || (Face == FaceDirection.Left && velocity.X > 0))
        {
            _targetRotation = -10;
        }
        else
        {
            _targetRotation = 0;
        }

        AnimatedSprite.RotationDegrees = Mathf.MoveToward(AnimatedSprite.RotationDegrees, _targetRotation, 25 * delta);
    }

    public override void HurtHandler(ActivityObject target, int damage, float angle)
    {
        base.HurtHandler(target, damage, angle);

        if (Hp <= 0) //死亡
        {
            StateController.Enable = false;
            MoveController.Enable = false;
            MoveController.ClearForce();
            Velocity = Vector2.Zero;
            AnimatedSprite.RotationDegrees = 0;
            StopCoroutine(_attaclCoroutine);
        }
    }

    public override void Attack()
    {
        if (_attaclCoroutine < 0)
        {
            if (World.Current.Player != null) //玩家快没有子弹了, 就生成小兵
            {
                var total = 0;
                var itemSlot = World.Current.Player.WeaponPack.ItemSlot;
                for (var i = 0; i < itemSlot.Length; i++)
                {
                    var item = itemSlot[i];
                    if (item != null)
                    {
                        total += item.TotalAmmon;
                        break;
                    }
                }

                if (total < 30)
                {
                    var count = AffiliationArea.FindEnterItemsCount(o => o != this && o is AiRole aiRole && aiRole.IsEnemyWithPlayer());
                    if (count == 0)
                    {
                        _attaclCoroutine = StartCoroutine(RunAttack4());
                        return;
                    }
                }
            }
            if (Hp / (float)MaxHp > 0.5f) //第一阶段
            {
                switch (Utils.Random.RandomRangeInt(0, 4))
                {
                    case 0:
                        _attaclCoroutine = StartCoroutine(RunAttack1());
                        break;
                    case 1:
                        _attaclCoroutine = StartCoroutine(RunAttack3());
                        break;
                    case 2:
                        _attaclCoroutine = StartCoroutine(RunAttack4());
                        break;
                    case 3:
                        _attaclCoroutine = StartCoroutine(RunAttack5());
                        break;
                    case 4:
                        _attaclCoroutine = StartCoroutine(RunAttack6());
                        break;
                }
            }
            else //第二阶段
            {
                if (state == 0) //
                {
                    state++;
                    _attaclCoroutine = StartCoroutine(RunAttack2());
                }
                else if (state == 1)
                {
                    state++;
                    _attaclCoroutine = StartCoroutine(RunAttack7());
                }
                else
                {
                    switch (Utils.Random.RandomRangeInt(0, 6))
                    {
                        case 0:
                            _attaclCoroutine = StartCoroutine(RunAttack1());
                            break;
                        case 1:
                            _attaclCoroutine = StartCoroutine(RunAttack2());
                            break;
                        case 2:
                            _attaclCoroutine = StartCoroutine(RunAttack3());
                            break;
                        case 3:
                            _attaclCoroutine = StartCoroutine(RunAttack4());
                            break;
                        case 4:
                            _attaclCoroutine = StartCoroutine(RunAttack5());
                            break;
                        case 5:
                            _attaclCoroutine = StartCoroutine(RunAttack6());
                            break;
                        case 6:
                            _attaclCoroutine = StartCoroutine(RunAttack7());
                            break;
                    }
                }
            }
        }
    }

    //发射两个子弹圈
    private IEnumerator RunAttack1()
    {
        var bulletData = FireManager.GetBulletData(this, 0, ExcelConfig.BulletBase_Map["0030"]);
        bulletData.Altitude = 1;
        
        AnimatedSprite.Play("readyAttack1");
        yield return ToSignal(AnimatedSprite, AnimatedSprite2D.SignalName.AnimationFinished);
        AnimatedSprite.Play("attack2");
        yield return  new WaitForSeconds(0.4f);
        
        CreateBulletCircle(15, 0, bulletData, (shootBullet) =>
        {
            if (shootBullet is Bullet bullet)
            {
                var twistMovement = bullet.MoveController.AddForce(new TwistForce());
                twistMovement.MoveRotation = shootBullet.BulletData.Rotation;
                twistMovement.TimeOffset = Utils.Random.RandomRangeFloat(0, Mathf.Pi);
            }
        });
        yield return new WaitForSeconds(0.2f);
        CreateBulletCircle(60, 0, bulletData);
        yield return new WaitForSeconds(0.1f);
        CreateBulletCircle(60, 0, bulletData);
        yield return new WaitForSeconds(0.2f);
        CreateBulletCircle(15, Mathf.DegToRad(360 / 15f * 0.5f) , bulletData, (shootBullet) =>
        {
            if (shootBullet is Bullet bullet)
            {
                var twistMovement = bullet.MoveController.AddForce(new TwistForce());
                twistMovement.MoveRotation = shootBullet.BulletData.Rotation;
                twistMovement.TimeOffset = Utils.Random.RandomRangeFloat(0, Mathf.Pi);
            }
        });
        
        yield return  new WaitForSeconds(0.5f);
        

        AttackTimer = 1.5f;
        _attaclCoroutine = -1;
    }

    //全屏发射子弹
    private IEnumerator RunAttack2()
    {
        var bulletData = FireManager.GetBulletData(this, 0, ExcelConfig.BulletBase_Map["0030"]);
        bulletData.Altitude = 1;
        AnimatedSprite.Play("readyAttack6");
        yield return ToSignal(AnimatedSprite, AnimatedSprite2D.SignalName.AnimationFinished);
        AnimatedSprite.Play("attack6");
        
        var count = 18;
        var angle = Mathf.DegToRad(360f / count * 0.5f);
        for (int i = 0; i < 15; i++)
        {
            if (i == 13)
            {
                CreateBulletCircle(60, 0, bulletData);
            }
            CreateBulletCircle(count, angle * i, bulletData);
            yield return new WaitForSeconds(0.4f);
        }
        
        AnimatedSprite.Play("endAttack6");
        yield return ToSignal(AnimatedSprite, AnimatedSprite2D.SignalName.AnimationFinished);
        
        AnimatedSprite.Play(AnimatorNames.Idle);
        
        AttackTimer = 2.5f;
        _attaclCoroutine = -1;
    }

    //玩家方向发射扇形子弹
    private IEnumerator RunAttack3()
    {
        var count = 100;
        var r = Mathf.Pi;
        var d = r / count;
        AnimatedSprite.Play("readyAttack5");
        yield return ToSignal(AnimatedSprite, AnimatedSprite2D.SignalName.AnimationFinished);
        AnimatedSprite.Play("attack5");
        
        for (var j = 0; j < 3; j++)
        {
            var angle = Position.AngleToPoint(LookTarget.Position);
            var bulletData = FireManager.GetBulletData(this, angle - r * 0.5f, ExcelConfig.BulletBase_Map["0030"]);
            bulletData.Altitude = 1;
        
            for (var i = 0; i < 100; i++)
            {
                var clone = bulletData.Clone();
                clone.Position = FirePoint.GlobalPosition;
                clone.Rotation += i * d;
                clone.FlySpeed *= Utils.Random.RandomRangeFloat(1, 1.5f);
                var shootBullet = FireManager.ShootBullet(clone, Camp);
                if (shootBullet is Bullet bullet)
                {
                    bullet.HideShadowSprite();
                    var twistMovement = bullet.MoveController.AddForce(new TwistForce());
                    twistMovement.MoveRotation = clone.Rotation;
                    twistMovement.TimeOffset = Utils.Random.RandomRangeFloat(0, Mathf.Pi);
                }

                if (i % 2 == 0)
                {
                    yield return null;
                }
            }
            
            yield return new WaitForSeconds(1.5f);
        }
        AnimatedSprite.Play(AnimatorNames.Idle);
        
        AttackTimer = 2.5f;
        _attaclCoroutine = -1;
    }

    //随机生成敌人
    private IEnumerator RunAttack4()
    {
        AnimatedSprite.Play("readyGenerate");
        yield return ToSignal(AnimatedSprite, AnimatedSprite2D.SignalName.AnimationFinished);
        AnimatedSprite.Play("generate");
        yield return new WaitForSeconds(0.3f);
        
        var count = (Hp / (float)MaxHp) < 0.5f ? Utils.Random.RandomRangeInt(2, 3) : 1;
        var positionArray = GetRandomPoint(count);
        for (var i = 0; i < count; i++)
        {
            var summons = Create<Summons>(Ids.Id_summons0001);
            summons.InitTarget(World.Player);
            summons.ThrowToPosition(Position, 40, 0, AffiliationArea.RoomInfo.ToGlobalPosition(positionArray[i]), 150);
            summons.PutDown(RoomLayerEnum.YSortLayer);
            yield return new WaitForSeconds(0.5f);
        }
        
        yield return new WaitForSeconds(1f);

        AnimatedSprite.Play(AnimatorNames.Idle);
        
        AttackTimer = 2f;
        _attaclCoroutine = -1;
    }

    //发射分裂子弹
    private IEnumerator RunAttack5()
    {
        AnimatedSprite.Play("readyAttack1");
        yield return ToSignal(AnimatedSprite, AnimatedSprite2D.SignalName.AnimationFinished);
        AnimatedSprite.Play("attack1");
        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < 5; i++)
        {
            var bulletData = FireManager.GetBulletData(this, Utils.Random.RandomRangeFloat(0, Mathf.Pi * 2), ExcelConfig.BulletBase_Map["0034"]);
            bulletData.Altitude = 1;
            
            var shootBullet = FireManager.ShootBullet(bulletData, Camp);
            if (shootBullet is Bullet bullet)
            {
                bullet.HideShadowSprite();
                if (bullet is SplitBullet splitBullet)
                {
                    var childBullet = FireManager.GetBulletData(this, 0, ExcelConfig.BulletBase_Map["0030"]);
                    childBullet.Altitude = 1;
                    splitBullet.SetSplitBullet(childBullet, 20);
                    splitBullet.OnCreateSplitBulletEvent += iBullet =>
                    {
                        if (iBullet is Bullet bullet1)
                        {
                            bullet1.HideShadowSprite();
                        }
                    };
                }
            }
            
            yield return new WaitForSeconds(0.5f);
        }
        
        yield return new WaitForSeconds(1f);
        
        AnimatedSprite.Play(AnimatorNames.Idle);
        
        AttackTimer = 1.5f;
        _attaclCoroutine = -1;
    }

    //发射一堆低速子弹
    private IEnumerator RunAttack6()
    {
        AnimatedSprite.Play("readyAttack1");
        yield return ToSignal(AnimatedSprite, AnimatedSprite2D.SignalName.AnimationFinished);
        AnimatedSprite.Play("attack1");
        yield return new WaitForSeconds(0.2f);

        var bulletData = FireManager.GetBulletData(this, 0, ExcelConfig.BulletBase_Map["0030"]);
        bulletData.Altitude = 1;
        var count = 50;
        for (var i = 0; i < count; i++)
        {
            var clone = bulletData.Clone();
            clone.Position = Position;
            clone.Rotation = Utils.Random.RandomRangeFloat(0, Mathf.Pi * 2);
            clone.FlySpeed *= Utils.Random.RandomRangeFloat(0.2f, 0.9f);
            var shootBullet = FireManager.ShootBullet(clone, Camp);
            if (shootBullet is Bullet bullet)
            {
                bullet.HideShadowSprite();
            }
            
            if (count % 5 == 0)
            {
                yield return null;
            }
        }
        
        yield return new WaitForSeconds(1f);
        AnimatedSprite.Play(AnimatorNames.Idle);

        AttackTimer = 1f;
        _attaclCoroutine = -1;
    }

    //向上发射火箭炮(非常难躲避)
    private IEnumerator RunAttack7()
    {
        AnimatedSprite.Play("readyAttack4");
        yield return ToSignal(AnimatedSprite, AnimatedSprite2D.SignalName.AnimationFinished);

        var count = 3;
        _randomPosList = GetRandomPoint(count * 4).ToList();
        for (int i = 0; i < count; i++)
        {
            AnimationPlayer.Play("attack4");
            yield return ToSignal(AnimationPlayer, AnimationMixer.SignalName.AnimationFinished);
        }
        
        AnimatedSprite.Play(AnimatorNames.Idle);

        AttackTimer = 6f;
        _attaclCoroutine = -1;
    }

    private List<Vector2> _randomPosList;
    private void CreateMissileBullet(NodePath node)
    {
        if (_randomPosList == null || _randomPosList.Count == 0)
        {
            return;
        }
        var node2D = GetNode<Node2D>(node);
        var bullet = ObjectManager.GetActivityObject<SpecialBullet0001>(Ids.Id_special0001);
        bullet.InitBullet("0030", 10, this, AffiliationArea.RoomInfo.ToGlobalPosition(_randomPosList[_randomPosList.Count - 1]));
        _randomPosList.RemoveAt(_randomPosList.Count - 1);
        var localPos = node2D.Position;
        bullet.Position = Position + new Vector2(localPos.X, 0);
        bullet.Altitude = -localPos.Y;
        bullet.VerticalSpeed = 800;
        bullet.OnCreateSplitBulletEvent += b =>
        {
            if (b is Bullet blt)
            {
                blt.Altitude = 1;
                blt.HideShadowSprite();
            }
        };
        bullet.PutDown(RoomLayerEnum.YSortLayer, false);
        bullet.UpdateFall((float)GetProcessDeltaTime());
        bullet.HideShadowSprite();
    }

    private Vector2[] GetRandomPoint(int count)
    {
        var tileInfo = AffiliationArea.RoomInfo.RoomSplit.TileInfo;
        if (_vertices == null)
        {
            var serializeVector2s = tileInfo.NavigationVertices;
            _vertices = new List<Vector2>();
            foreach (var sv2 in serializeVector2s)
            {
                _vertices.Add(sv2.AsVector2());
            }
        }

        var positionArray = World.Random.GetRandomPositionInPolygon(_vertices, tileInfo.NavigationPolygon, count);
        return positionArray;
    }

    private void CreateBulletCircle(int count, float offsetAngle, BulletData bulletData, Action<IBullet> callback = null)
    {
        var pos = FirePoint.GlobalPosition;
        for (var i = 0; i < count; i++)
        {
            var clone = bulletData.Clone();
            clone.Position = pos;
            clone.Rotation = Mathf.Pi * 2 / count * i + offsetAngle;
            var shootBullet = FireManager.ShootBullet(clone, Camp);
            if (shootBullet is Bullet bullet)
            {
                bullet.HideShadowSprite();
            }

            if (callback != null)
            {
                callback(shootBullet);
            }
        }
    }
}