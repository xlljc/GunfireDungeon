
using System.Collections.Generic;
using Config;
using Godot;

public static class FireManager
{
    
    /// <summary>
    /// 投抛弹壳的默认实现方式, shellId为弹壳id
    /// </summary>
    public static ActivityObject ThrowShell(Weapon weapon, ExcelConfig.ActivityBase shell, float speedScale = 1)
    {
        var startPos = weapon.ShellPoint.GlobalPosition;
        float startHeight;
        var master = weapon.Master;
        if (master != null)
        {
            var shellPosition = master.MountPoint.Position + weapon.ShellPoint.Position;
            startHeight = -shellPosition.Y;
            startPos.Y += startHeight;
        }
        else
        {
            startHeight = weapon.Altitude;
        }

        var direction = weapon.GlobalRotationDegrees + Utils.Random.RandomRangeInt(-30, 30) + 180;
        var verticalSpeed = Utils.Random.RandomRangeInt((int)(60 * speedScale), (int)(120 * speedScale));
        var velocity = new Vector2(Utils.Random.RandomRangeInt((int)(20 * speedScale), (int)(60 * speedScale)), 0).Rotated(direction * Mathf.Pi / 180);
        var rotate = Utils.Random.RandomRangeInt((int)(-720 * speedScale), (int)(720 * speedScale));
        var shellInstance = ActivityObject.Create(shell);
        shellInstance.Rotation = (master != null ? master.MountPoint.RealRotation : weapon.Rotation);
        shellInstance.Throw(startPos, startHeight, verticalSpeed, velocity, rotate);
        shellInstance.InheritVelocity(master != null ? master : weapon);
        if (master == null)
        {
            weapon.AffiliationArea.InsertItem(shellInstance);
        }
        else
        {
            master.AffiliationArea.InsertItem(shellInstance);
        }
        
        return shellInstance;
    }

    /// <summary>
    /// 根据武器创建 BulletData
    /// </summary>
    public static BulletData GetBulletData(Weapon weapon, FireBulletParam param)
    {
        if (param.Bullet.Type == 1) //实体子弹
        {
            return CreateSolidBulletData(weapon, param);
        }
        else if (param.Bullet.Type == 2) //激光子弹
        {
            return CreateLaserData(weapon, param);
        }
        else
        {
            Debug.LogError("暂未支持的子弹类型: " + param.Bullet.Type);
        }

        return null;
    }
    
    /// <summary>
    /// 根据角色创建 BulletData
    /// </summary>
    public static BulletData GetBulletData(Role trigger, FireBulletParam param)
    {
        if (param.Bullet.Type == 1) //实体子弹
        {
            return CreateSolidBulletData(trigger, param);
        }

        return null;
    }

    /// <summary>
    /// 计算进行抛物线运动的子弹击中目标所需要的速度等数据, 并设置
    /// </summary>
    public static void SetParabolaTarget(BulletData bulletData, Vector2 targetPosition)
    {
        var distance = bulletData.Position.DistanceTo(targetPosition);
        var height = bulletData.Altitude;
        var time = distance / bulletData.FlySpeed;
        bulletData.VerticalSpeed = -(height - 0.5f * GameConfig.G * time * time) / time;
        bulletData.Rotation = bulletData.Position.AngleToPoint(targetPosition);
    }

    /// <summary>
    /// 通过武器发射子弹
    /// </summary>
    public static IBullet ShootBullet(Weapon weapon, FireBulletParam param)
    {
        if (param.Bullet.Type == 1) //实体子弹
        {
            return ShootSolidBullet(CreateSolidBulletData(weapon, param), param.Camp);
        }
        else if (param.Bullet.Type == 2) //激光子弹
        {
            return ShootLaser(CreateLaserData(weapon, param), param.Camp);
        }
        else
        {
            Debug.LogError("暂未支持的子弹类型: " + param.Bullet.Type);
        }

        return null;
    }

    /// <summary>
    /// 通 Role 对象直接发射子弹
    /// </summary>
    public static IBullet ShootBullet(Role trigger, FireBulletParam param)
    {
        if (param.Bullet.Type == 1) //实体子弹
        {
            return ShootSolidBullet(CreateSolidBulletData(trigger, param), trigger.Camp);
        }

        return null;
    }

    /// <summary>
    /// 通过 BulletData 直接发射子弹
    /// </summary>
    public static IBullet ShootBullet(BulletData bulletData, CampEnum camp)
    {
        if (bulletData.BulletBase.Type == 1) //实体子弹
        {
            return ShootSolidBullet(bulletData, camp);
        }
        else if (bulletData.BulletBase.Type == 2) //激光子弹
        {
            return ShootLaser(bulletData, camp);
        }
        else
        {
            Debug.LogError("暂未支持的子弹类型: " + bulletData.BulletBase.Type);
        }

        return null;
    }

    /// <summary>
    /// 发射子弹的默认实现方式
    /// </summary>
    private static Bullet ShootSolidBullet(BulletData bulletData, CampEnum camp)
    {
        //创建子弹
        var bulletInstance = ObjectManager.GetBullet(bulletData.BulletBase.Prefab);
        bulletInstance.InitData(bulletData, camp);
        return bulletInstance;
    }

    /// <summary>
    /// 发射射线的默认实现方式
    /// </summary>
    private static Laser ShootLaser(BulletData bulletData, CampEnum camp)
    {
        //创建激光
        var laser = ObjectManager.GetLaser(bulletData.BulletBase.Prefab);
        laser.AddToActivityRoot(RoomLayerEnum.YSortLayer);
        laser.InitData(bulletData, camp, Laser.LaserDefaultWidth);
        return laser;
    }
    
    //-----------------------------------------------------------------------------------

    private static BulletData CreateSolidBulletData(Weapon weapon, FireBulletParam param)
    {
        var hasRole = weapon.TriggerRole != null && !weapon.TriggerRole.IsDestroyed;
        var data = new BulletData(weapon.World)
        {
            Weapon = weapon,
            BulletBase = param.Bullet,
            TriggerRole = hasRole ? weapon.TriggerRole : null,
            HarmDic = GetDamageDict(param.Bullet),
            AbnormalStateDict = GetAbnormalStateDict(param.Bullet),
            Repel = Utils.Random.RandomConfigRange(param.Bullet.RepelRange),
            MaxDistance = Utils.Random.RandomConfigRange(param.Bullet.DistanceRange),
            FlySpeed = Utils.Random.RandomConfigRange(param.Bullet.SpeedRange),
            VerticalSpeed = Utils.Random.RandomConfigRange(param.Bullet.VerticalSpeed),
            BounceCount = Utils.Random.RandomConfigRange(param.Bullet.BounceCount),
            Penetration = Utils.Random.RandomConfigRange(param.Bullet.Penetration),
            Position = param.Position,
        };
        
        var deviationAngle = Utils.Random.RandomConfigRange(param.Bullet.DeviationAngleRange);
        if (hasRole)
        {
            //data.Altitude = weapon.TriggerRole.GetFirePointAltitude();
            var roleState = weapon.TriggerRole.RoleState;
            
            foreach (var item in param.Bullet.Harm)
            {
                data.HarmDic[item.Key] = roleState.CalcDamage(data.HarmDic[item.Key], item.Key);
            }
            
            data.Repel = roleState.CalcBulletRepel(data.Repel);
            data.FlySpeed = roleState.CalcBulletSpeed(data.FlySpeed);
            data.MaxDistance = roleState.CalcBulletDistance(data.MaxDistance);
            data.BounceCount = roleState.CalcBulletBounceCount(data.BounceCount);
            data.Penetration = roleState.CalcBulletPenetration(data.Penetration);
            deviationAngle = roleState.CalcBulletDeviationAngle(deviationAngle);
            
            if (weapon.TriggerRole.IsAi) //只有玩家使用该武器才能获得正常速度的子弹
            {
                data.FlySpeed *= weapon.AiUseAttribute.AiAttackAttr.BulletSpeedScale;
            }
        }

        data.Altitude = param.Altitude;
        data.Rotation = param.FireRotation + Mathf.DegToRad(deviationAngle);
        return data;
    }
    
    private static BulletData CreateSolidBulletData(Role role, FireBulletParam param)
    {
        var data = new BulletData(role.World)
        {
            Weapon = null,
            BulletBase = param.Bullet,
            TriggerRole = role,
            HarmDic = GetDamageDict(param.Bullet),
            AbnormalStateDict = GetAbnormalStateDict(param.Bullet),
            Repel = Utils.Random.RandomConfigRange(param.Bullet.RepelRange),
            MaxDistance = Utils.Random.RandomConfigRange(param.Bullet.DistanceRange),
            FlySpeed = Utils.Random.RandomConfigRange(param.Bullet.SpeedRange),
            VerticalSpeed = Utils.Random.RandomConfigRange(param.Bullet.VerticalSpeed),
            BounceCount = Utils.Random.RandomConfigRange(param.Bullet.BounceCount),
            Penetration = Utils.Random.RandomConfigRange(param.Bullet.Penetration),
            Position = param.Position,
            Altitude = param.Altitude
        };
        
        // if (role is Enemy enemy)
        // {
        //     data.Position = enemy.FirePoint.GlobalPosition;
        // }
        // else
        // {
        //     data.Position = role.MountPoint.GlobalPosition;
        // }

        var deviationAngle = Utils.Random.RandomConfigRange(param.Bullet.DeviationAngleRange);
        data.Altitude = role.GetFirePointAltitude();
        var roleState = role.RoleState;
        foreach (var item in param.Bullet.Harm)
        {
            data.HarmDic[item.Key] = roleState.CalcDamage(data.HarmDic[item.Key], item.Key);
        }
        data.Repel = roleState.CalcBulletRepel(data.Repel);
        data.FlySpeed = roleState.CalcBulletSpeed(data.FlySpeed);
        data.MaxDistance = roleState.CalcBulletDistance(data.MaxDistance);
        data.BounceCount = roleState.CalcBulletBounceCount(data.BounceCount);
        data.Penetration = roleState.CalcBulletPenetration(data.Penetration);
        deviationAngle = roleState.CalcBulletDeviationAngle(deviationAngle);
        
        // if (role.IsAi) //只有玩家使用该武器才能获得正常速度的子弹
        // {
        //     data.FlySpeed *= weapon.AiUseAttribute.AiAttackAttr.BulletSpeedScale;
        // }

        data.Rotation = param.FireRotation + Mathf.DegToRad(deviationAngle);
        return data;
    }

    private static BulletData CreateLaserData(Weapon weapon, FireBulletParam param)
    {
        var hasRole = weapon.TriggerRole != null && !weapon.TriggerRole.IsDestroyed;
        var data = new BulletData(weapon.World)
        {
            Weapon = weapon,
            BulletBase = param.Bullet,
            TriggerRole = hasRole ? weapon.TriggerRole : null,
            HarmDic = GetDamageDict(param.Bullet),
            AbnormalStateDict = GetAbnormalStateDict(param.Bullet),
            Repel = Utils.Random.RandomConfigRange(param.Bullet.RepelRange),
            MaxDistance = Utils.Random.RandomConfigRange(param.Bullet.DistanceRange),
            BounceCount = Utils.Random.RandomConfigRange(param.Bullet.BounceCount),
            LifeTime = Utils.Random.RandomConfigRange(param.Bullet.LifeTimeRange),
            Position = param.Position,
            FlySpeed = Utils.Random.RandomConfigRange(param.Bullet.SpeedRange),
        };

        var deviationAngle = Utils.Random.RandomConfigRange(param.Bullet.DeviationAngleRange);
        if (weapon.TriggerRole != null)
        {
            var roleState = weapon.TriggerRole.RoleState;
            foreach (var item in param.Bullet.Harm)
            {
                data.HarmDic[item.Key] = roleState.CalcDamage(data.HarmDic[item.Key], item.Key);
            }
            data.Repel = roleState.CalcBulletRepel(data.Repel);
            data.BounceCount = roleState.CalcBulletBounceCount(data.BounceCount);
            deviationAngle = roleState.CalcBulletDeviationAngle(deviationAngle);
        }

        data.Altitude = param.Altitude;
        data.Rotation = param.FireRotation + Mathf.DegToRad(deviationAngle);
        return data;
    }

    private static Dictionary<DamageType, int> GetDamageDict(ExcelConfig.BulletBase bullet)
    {
        if (bullet.Harm == null || bullet.Harm.Count == 0)
        {
            return null;
        }
        
        var harmDic = new Dictionary<DamageType, int>();
        foreach (var item in bullet.Harm)
        {
            harmDic.Add(item.Key, Utils.Random.RandomConfigRange(item.Value));
        }
        return harmDic;
    }
    
    
    private static Dictionary<AbnormalStateType, int> GetAbnormalStateDict(ExcelConfig.BulletBase bullet)
    {
        if (bullet.AbnormalState == null || bullet.AbnormalState.Count == 0)
        {
            return null;
        }

        var result = new Dictionary<AbnormalStateType, int>();
        foreach (var item in bullet.AbnormalState)
        {
            result.Add(item.Key, item.Value);
        }
        return result;
    }
}