using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    /// <summary>
    /// Ai攻击属性
    /// </summary>
    public partial class AiAttackAttr
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonInclude]
        public string Id;

        /// <summary>
        /// 备注
        /// </summary>
        [JsonInclude]
        public string Remark;

        /// <summary>
        /// 锁定目标时是否站立不动
        /// </summary>
        [JsonInclude]
        public bool LockingStand;

        /// <summary>
        /// 开火时是否站立不动
        /// </summary>
        [JsonInclude]
        public bool FiringStand;

        /// <summary>
        /// 是否显示射击辅助线
        /// </summary>
        [JsonInclude]
        public bool ShowSubline;

        /// <summary>
        /// Ai属性 <br/>
        /// 目标锁定时间, 也就是瞄准目标多久才会开火, (单位: 秒)
        /// </summary>
        [JsonInclude]
        public float LockingTime;

        /// <summary>
        /// 从锁定目标到开火前有多少时间不能够改变枪口角度 <br/>
        /// 这个值必须小于LockingTime <br/>
        /// 如果为0, 则不会锁定开火角度 <br/>
        /// (单位: 秒)
        /// </summary>
        [JsonInclude]
        public float LockAngleTime;

        /// <summary>
        /// 开火时是否锁定枪口角度
        /// </summary>
        [JsonInclude]
        public bool AttackLockAngle;

        /// <summary>
        /// Ai属性 <br/>
        /// Ai使用该武器发射的子弹速度缩放比
        /// </summary>
        [JsonInclude]
        public float BulletSpeedScale;

        /// <summary>
        /// Ai属性 <br/>
        /// Ai使用该武器消耗弹药的概率, (0 - 1)
        /// </summary>
        [JsonInclude]
        public float AmmoConsumptionProbability;

        /// <summary>
        /// 返回浅拷贝出的新对象
        /// </summary>
        public AiAttackAttr Clone()
        {
            var inst = new AiAttackAttr();
            inst.Id = Id;
            inst.Remark = Remark;
            inst.LockingStand = LockingStand;
            inst.FiringStand = FiringStand;
            inst.ShowSubline = ShowSubline;
            inst.LockingTime = LockingTime;
            inst.LockAngleTime = LockAngleTime;
            inst.AttackLockAngle = AttackLockAngle;
            inst.BulletSpeedScale = BulletSpeedScale;
            inst.AmmoConsumptionProbability = AmmoConsumptionProbability;
            return inst;
        }
    }
}