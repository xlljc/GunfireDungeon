using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
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
            inst.ExtraAttr = ExtraAttr;
            inst.WeaponCapacity = WeaponCapacity;
            inst.ActivePropsCapacity = ActivePropsCapacity;
            inst.PartPropCapacity = PartPropCapacity;
            inst.Camp = Camp;
            inst.AiAttr = AiAttr;
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