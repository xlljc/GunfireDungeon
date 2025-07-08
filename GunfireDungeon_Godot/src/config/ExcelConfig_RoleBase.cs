using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    /// <summary>
    /// 角色属性
    /// </summary>
    public partial class RoleBase
    {
        /// <summary>
        /// 表Id
        /// </summary>
        [JsonInclude]
        public string Id;

        /// <summary>
        /// 绑定的ActivityBase表数据
        /// </summary>
        public ActivityBase Activity;

        /// <summary>
        /// 备注
        /// </summary>
        [JsonInclude]
        public string Remark;

        /// <summary>
        /// 血量
        /// </summary>
        [JsonInclude]
        public int Hp;

        /// <summary>
        /// 护盾值 <br/>
        /// 敌人可以不用填写
        /// </summary>
        [JsonInclude]
        public int Shield;

        /// <summary>
        /// 移动速度
        /// </summary>
        [JsonInclude]
        public float MoveSpeed;

        /// <summary>
        /// 移动加速度
        /// </summary>
        [JsonInclude]
        public float Acceleration;

        /// <summary>
        /// 移动摩擦力, 仅用于人物基础移动
        /// </summary>
        [JsonInclude]
        public float Friction;

        /// <summary>
        /// 身高 <br/>
        /// 用于显示头顶状态属性的位置
        /// </summary>
        [JsonInclude]
        public int Height;

        /// <summary>
        /// 额外属性 <br/>
        /// 根据不同类型角色拥有的不同的扩展属性
        /// </summary>
        [JsonInclude]
        public Dictionary<string, System.Text.Json.JsonElement> ExtraAttr;

        /// <summary>
        /// 武器袋初始容量 <br/>
        /// 可用于区分角色是否可以拾起武器
        /// </summary>
        [JsonInclude]
        public int WeaponCapacity;

        /// <summary>
        /// 主动道具袋初始容量
        /// </summary>
        [JsonInclude]
        public int ActivePropsCapacity;

        /// <summary>
        /// 零件道具袋初始容量
        /// </summary>
        [JsonInclude]
        public int PartPropCapacity;

        /// <summary>
        /// 默认所属阵营 <br/>
        /// None（无阵营, 所有角色都视为敌人）：0 <br/>
        /// Peace（和平阵营, 不会被攻击）：1 <br/>
        /// Camp1~5（阵营1, 玩家，其他都是敌人）：2~6
        /// </summary>
        [JsonInclude]
        public CampEnum Camp;

        /// <summary>
        /// 绑定的Ai属性
        /// </summary>
        public AiRoleAttr AiAttr;

        /// <summary>
        /// 物理属性伤害抗性 <br/>
        /// 如果为1，也就是受到的伤害为100%。 <br/>
        /// 如果为0.5，就是受到的伤害为50% <br/>
        /// 后面几个属性抗性意义相同
        /// </summary>
        [JsonInclude]
        public float PhysicalResist;

        /// <summary>
        /// 魔法属性伤害抗性
        /// </summary>
        [JsonInclude]
        public float MagicResist;

        /// <summary>
        /// 火焰属性伤害抗性
        /// </summary>
        [JsonInclude]
        public float FireResist;

        /// <summary>
        /// 冰霜属性伤害抗性
        /// </summary>
        [JsonInclude]
        public float IceResist;

        /// <summary>
        /// 雷电属性伤害抗性
        /// </summary>
        [JsonInclude]
        public float ThunderResist;

        /// <summary>
        /// 光明属性伤害抗性
        /// </summary>
        [JsonInclude]
        public float LightResist;

        /// <summary>
        /// 暗影属性伤害抗性
        /// </summary>
        [JsonInclude]
        public float DarkResist;

        /// <summary>
        /// 魔法属性伤害抗性
        /// </summary>
        [JsonInclude]
        public float RealResist;

        /// <summary>
        /// 燃烧异常状态抗性
        /// </summary>
        [JsonInclude]
        public int AsBurningResist;

        /// <summary>
        /// 中毒异常状态抗性
        /// </summary>
        [JsonInclude]
        public int AsPoisoningResist;

        /// <summary>
        /// 返回浅拷贝出的新对象
        /// </summary>
        public RoleBase Clone()
        {
            var inst = new RoleBase();
            inst.Id = Id;
            inst.Activity = Activity;
            inst.Remark = Remark;
            inst.Hp = Hp;
            inst.Shield = Shield;
            inst.MoveSpeed = MoveSpeed;
            inst.Acceleration = Acceleration;
            inst.Friction = Friction;
            inst.Height = Height;
            inst.ExtraAttr = ExtraAttr;
            inst.WeaponCapacity = WeaponCapacity;
            inst.ActivePropsCapacity = ActivePropsCapacity;
            inst.PartPropCapacity = PartPropCapacity;
            inst.Camp = Camp;
            inst.AiAttr = AiAttr;
            inst.PhysicalResist = PhysicalResist;
            inst.MagicResist = MagicResist;
            inst.FireResist = FireResist;
            inst.IceResist = IceResist;
            inst.ThunderResist = ThunderResist;
            inst.LightResist = LightResist;
            inst.DarkResist = DarkResist;
            inst.RealResist = RealResist;
            inst.AsBurningResist = AsBurningResist;
            inst.AsPoisoningResist = AsPoisoningResist;
            return inst;
        }
    }
    private class Ref_RoleBase : RoleBase
    {
        [JsonInclude]
        public string __Activity;

        [JsonInclude]
        public string __AiAttr;

    }
}