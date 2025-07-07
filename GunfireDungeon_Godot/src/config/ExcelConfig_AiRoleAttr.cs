using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    /// <summary>
    /// Ai角色属性
    /// </summary>
    public partial class AiRoleAttr
    {
        /// <summary>
        /// 表Id
        /// </summary>
        [JsonInclude]
        public string Id;

        /// <summary>
        /// 备注
        /// </summary>
        [JsonInclude]
        public string Remark;

        /// <summary>
        /// 单次攻击间隔时间, 秒 <br/>
        /// 注意, 敌人攻击后计算间隔时间会使用当前字段值与武器上的TriggerInterval叠加
        /// </summary>
        [JsonInclude]
        public float AttackInterval;

        /// <summary>
        /// 视野半径, 单位像素, 发现玩家后改视野范围可以穿墙
        /// </summary>
        [JsonInclude]
        public float ViewRange;

        /// <summary>
        /// 发现玩家后跟随玩家的视野半径
        /// </summary>
        [JsonInclude]
        public float TailAfterViewRange;

        /// <summary>
        /// 视野角度范围, 角度制
        /// </summary>
        [JsonInclude]
        public float ViewAngleRange;

        /// <summary>
        /// 掉落金币数量区间, 如果为负数或者0则不会掉落金币 <br/>
        /// 格式为[value]或者[min,max]
        /// </summary>
        [JsonInclude]
        public int[] Gold;

        /// <summary>
        /// 敌人死亡爆浆血液颜色, 填十六进制字符串(小写),  <br/>
        /// 例如: ff0000 <br/>
        /// 不填默认白色
        /// </summary>
        [JsonInclude]
        public string BloodColor;

        /// <summary>
        /// 死亡时的尸体碎片
        /// </summary>
        public ActivityBase BodyFragment;

        /// <summary>
        /// 返回浅拷贝出的新对象
        /// </summary>
        public AiRoleAttr Clone()
        {
            var inst = new AiRoleAttr();
            inst.Id = Id;
            inst.Remark = Remark;
            inst.AttackInterval = AttackInterval;
            inst.ViewRange = ViewRange;
            inst.TailAfterViewRange = TailAfterViewRange;
            inst.ViewAngleRange = ViewAngleRange;
            inst.Gold = Gold;
            inst.BloodColor = BloodColor;
            inst.BodyFragment = BodyFragment;
            return inst;
        }
    }
    private class Ref_AiRoleAttr : AiRoleAttr
    {
        [JsonInclude]
        public string __BodyFragment;

    }
}