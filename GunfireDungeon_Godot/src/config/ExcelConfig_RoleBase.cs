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
        /// 判断角色以生命值、护盾值、装甲值的其中一种作为存活判定。 <br/>
        /// Hp（生命值）：0 <br/>
        /// Shield（护甲值）：1 <br/>
        /// Armor（装甲值）：2 <br/>
        /// 
        /// </summary>
        [JsonInclude]
        public LifeTypeEnum LiftType;

        /// <summary>
        /// 血量
        /// </summary>
        [JsonInclude]
        public int Hp;

        /// <summary>
        /// 护盾值
        /// </summary>
        [JsonInclude]
        public int Shield;

        /// <summary>
        /// 装甲值
        /// </summary>
        [JsonInclude]
        public int Armor;

        /// <summary>
        /// 护盾恢复延迟（秒）
        /// </summary>
        [JsonInclude]
        public float ShieldDelay;

        /// <summary>
        /// 护盾恢复速度，每秒恢复量，为0则不恢复
        /// </summary>
        [JsonInclude]
        public float ShieldRate;

        /// <summary>
        /// 破盾后的无敌时间, 单位: 秒，为0则不触发无敌
        /// </summary>
        [JsonInclude]
        public float ShieldInv;

        /// <summary>
        /// 每秒受到多少百分比伤害后触发无敌
        /// </summary>
        [JsonInclude]
        public float WoundInvPct;

        /// <summary>
        /// 受伤后的无敌时间, 单位: 秒，为0则不触发无敌
        /// </summary>
        [JsonInclude]
        public float WoundInv;

        /// <summary>
        /// 单次能受到最大的百分比伤害，也就是保护机制
        /// </summary>
        [JsonInclude]
        public float WoundMaxPct;

        /// <summary>
        /// 触发保护机制后的无敌时间, 单位: 秒，为0则不触发无敌
        /// </summary>
        [JsonInclude]
        public float WoundMaxInv;

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
        /// 角色强度，作为非玩家角色，标识该敌人或NPC是 普通、稀有、精英等，不同类型的敌人生命血条会有特殊表现。其强度也不相同。 <br/>
        /// Normal（普通）：0 <br/>
        /// Rare（稀有）：1 <br/>
        /// Elite（精英）：2 <br/>
        /// Boss（头目）：3 <br/>
        /// 
        /// </summary>
        [JsonInclude]
        public RoleStrengthEnum RoleStrength;

        /// <summary>
        /// 绑定的Ai属性
        /// </summary>
        public AiRoleAttr AiAttr;

        /// <summary>
        /// 抗暴击率
        /// </summary>
        [JsonInclude]
        public float CritResist;

        /// <summary>
        /// 物理减免
        /// </summary>
        [JsonInclude]
        public float PhysicalResist;

        /// <summary>
        /// 火焰减免
        /// </summary>
        [JsonInclude]
        public float FireResist;

        /// <summary>
        /// 电击减免
        /// </summary>
        [JsonInclude]
        public float ElectricResist;

        /// <summary>
        /// 化学减免
        /// </summary>
        [JsonInclude]
        public float ChemicalResist;

        /// <summary>
        /// 光学减免
        /// </summary>
        [JsonInclude]
        public float OpticalResist;

        /// <summary>
        /// 暗物质减免
        /// </summary>
        [JsonInclude]
        public float DarkMatterResist;

        /// <summary>
        /// 爆破减免
        /// </summary>
        [JsonInclude]
        public float ExplosiveResist;

        /// <summary>
        /// 流血异常状态抗性
        /// </summary>
        [JsonInclude]
        public int AsBleedingResist;

        /// <summary>
        /// 点燃异常状态抗性
        /// </summary>
        [JsonInclude]
        public int AsIgniteResist;

        /// <summary>
        /// 短路异常状态抗性
        /// </summary>
        [JsonInclude]
        public int AsShortCircuitResist;

        /// <summary>
        /// 干扰异常状态抗性
        /// </summary>
        [JsonInclude]
        public int AsInterferenceResist;

        /// <summary>
        /// 触电异常状态抗性
        /// </summary>
        [JsonInclude]
        public int AsElectricShockResist;

        /// <summary>
        /// 腐蚀异常状态抗性
        /// </summary>
        [JsonInclude]
        public int AsCorrosionResist;

        /// <summary>
        /// 脆弱异常状态抗性
        /// </summary>
        [JsonInclude]
        public int AsFragileResist;

        /// <summary>
        /// 致盲异常状态抗性
        /// </summary>
        [JsonInclude]
        public int AsBlindResist;

        /// <summary>
        /// 混沌异常状态抗性
        /// </summary>
        [JsonInclude]
        public int AsChaosResist;

        /// <summary>
        /// 破甲异常状态抗性
        /// </summary>
        [JsonInclude]
        public int AsArmorBreakResist;

        /// <summary>
        /// 返回浅拷贝出的新对象
        /// </summary>
        public RoleBase Clone()
        {
            var inst = new RoleBase();
            inst.Id = Id;
            inst.Activity = Activity;
            inst.Remark = Remark;
            inst.LiftType = LiftType;
            inst.Hp = Hp;
            inst.Shield = Shield;
            inst.Armor = Armor;
            inst.ShieldDelay = ShieldDelay;
            inst.ShieldRate = ShieldRate;
            inst.ShieldInv = ShieldInv;
            inst.WoundInvPct = WoundInvPct;
            inst.WoundInv = WoundInv;
            inst.WoundMaxPct = WoundMaxPct;
            inst.WoundMaxInv = WoundMaxInv;
            inst.MoveSpeed = MoveSpeed;
            inst.Acceleration = Acceleration;
            inst.Friction = Friction;
            inst.Height = Height;
            inst.ExtraAttr = ExtraAttr;
            inst.WeaponCapacity = WeaponCapacity;
            inst.ActivePropsCapacity = ActivePropsCapacity;
            inst.PartPropCapacity = PartPropCapacity;
            inst.Camp = Camp;
            inst.RoleStrength = RoleStrength;
            inst.AiAttr = AiAttr;
            inst.CritResist = CritResist;
            inst.PhysicalResist = PhysicalResist;
            inst.FireResist = FireResist;
            inst.ElectricResist = ElectricResist;
            inst.ChemicalResist = ChemicalResist;
            inst.OpticalResist = OpticalResist;
            inst.DarkMatterResist = DarkMatterResist;
            inst.ExplosiveResist = ExplosiveResist;
            inst.AsBleedingResist = AsBleedingResist;
            inst.AsIgniteResist = AsIgniteResist;
            inst.AsShortCircuitResist = AsShortCircuitResist;
            inst.AsInterferenceResist = AsInterferenceResist;
            inst.AsElectricShockResist = AsElectricShockResist;
            inst.AsCorrosionResist = AsCorrosionResist;
            inst.AsFragileResist = AsFragileResist;
            inst.AsBlindResist = AsBlindResist;
            inst.AsChaosResist = AsChaosResist;
            inst.AsArmorBreakResist = AsArmorBreakResist;
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