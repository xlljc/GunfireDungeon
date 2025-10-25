using Config;

// 根据配置表注册物体, 该类是自动生成的, 请不要手动编辑!
public partial class ActivityObject
{
    /// <summary>
    /// 存放所有在表中注册的物体的id
    /// </summary>
    public static class Ids
    {
        /// <summary>
        /// 名称: 玩家 <br/>
        /// </summary>
        public const string Id_role0001 = "role0001";
        /// <summary>
        /// 名称: 敌人 <br/>
        /// </summary>
        public const string Id_enemy0001 = "enemy0001";
        /// <summary>
        /// 名称: Boss <br/>
        /// </summary>
        public const string Id_boss0001 = "boss0001";
        /// <summary>
        /// 名称: 商店老板 <br/>
        /// </summary>
        public const string Id_shopBoss0001 = "shopBoss0001";
        /// <summary>
        /// 名称: 步枪 <br/>
        /// </summary>
        public const string Id_weapon0001 = "weapon0001";
        /// <summary>
        /// 名称: 霰弹枪 <br/>
        /// </summary>
        public const string Id_weapon0002 = "weapon0002";
        /// <summary>
        /// 名称: 手枪 <br/>
        /// </summary>
        public const string Id_weapon0003 = "weapon0003";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_bullet0001 = "bullet0001";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_bullet0002 = "bullet0002";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_bullet0003 = "bullet0003";
        /// <summary>
        /// 名称: 榴弹炮 <br/>
        /// </summary>
        public const string Id_bullet0004 = "bullet0004";
        /// <summary>
        /// 名称: 抛物线粘液子弹 <br/>
        /// </summary>
        public const string Id_bullet0005 = "bullet0005";
        /// <summary>
        /// 名称: 拖尾子弹 <br/>
        /// </summary>
        public const string Id_bullet0006 = "bullet0006";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_bullet0007 = "bullet0007";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_bullet0008 = "bullet0008";
        /// <summary>
        /// 名称: 弓箭 <br/>
        /// </summary>
        public const string Id_bullet0009 = "bullet0009";
        /// <summary>
        /// 名称: boss召唤物子弹 <br/>
        /// </summary>
        public const string Id_summons0001 = "summons0001";
        /// <summary>
        /// 名称: boss特殊子弹 <br/>
        /// </summary>
        public const string Id_special0001 = "special0001";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_shell0001 = "shell0001";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_shell0002 = "shell0002";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_shell0003 = "shell0003";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_shell0004 = "shell0004";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_enemy_dead0001 = "enemy_dead0001";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_enemy_dead0002 = "enemy_dead0002";
        /// <summary>
        /// 名称: 通用零件物体 <br/>
        /// </summary>
        public const string Id_part_comm0001 = "part_comm0001";
        /// <summary>
        /// 名称: 鞋子 <br/>
        /// </summary>
        public const string Id_prop0001 = "prop0001";
        /// <summary>
        /// 名称: 心之容器 <br/>
        /// </summary>
        public const string Id_prop0002 = "prop0002";
        /// <summary>
        /// 名称: 护盾 <br/>
        /// </summary>
        public const string Id_prop0003 = "prop0003";
        /// <summary>
        /// 名称: 护盾计时器 <br/>
        /// </summary>
        public const string Id_prop0004 = "prop0004";
        /// <summary>
        /// 名称: 杀伤弹 <br/>
        /// </summary>
        public const string Id_prop0005 = "prop0005";
        /// <summary>
        /// 名称: 红宝石戒指 <br/>
        /// </summary>
        public const string Id_prop0006 = "prop0006";
        /// <summary>
        /// 名称: 备用护盾 <br/>
        /// </summary>
        public const string Id_prop0007 = "prop0007";
        /// <summary>
        /// 名称: 眼镜 <br/>
        /// </summary>
        public const string Id_prop0008 = "prop0008";
        /// <summary>
        /// 名称: 高速子弹 <br/>
        /// </summary>
        public const string Id_prop0009 = "prop0009";
        /// <summary>
        /// 名称: 分裂子弹 <br/>
        /// </summary>
        public const string Id_prop0010 = "prop0010";
        /// <summary>
        /// 名称: 弹射子弹 <br/>
        /// </summary>
        public const string Id_prop0011 = "prop0011";
        /// <summary>
        /// 名称: 穿透子弹 <br/>
        /// </summary>
        public const string Id_prop0012 = "prop0012";
        /// <summary>
        /// 名称: 武器背包 <br/>
        /// </summary>
        public const string Id_prop0013 = "prop0013";
        /// <summary>
        /// 名称: 道具背包 <br/>
        /// </summary>
        public const string Id_prop0014 = "prop0014";
        /// <summary>
        /// 名称: 医药箱 <br/>
        /// </summary>
        public const string Id_prop5000 = "prop5000";
        /// <summary>
        /// 名称: 弹药箱 <br/>
        /// </summary>
        public const string Id_prop5001 = "prop5001";
        /// <summary>
        /// 名称: 猪猪存钱罐 <br/>
        /// </summary>
        public const string Id_prop5002 = "prop5002";
        /// <summary>
        /// 名称: 红外遥控器 <br/>
        /// </summary>
        public const string Id_prop5003 = "prop5003";
        /// <summary>
        /// 名称: 魔术棒 <br/>
        /// </summary>
        public const string Id_prop5004 = "prop5004";
        /// <summary>
        /// 名称: 便携式供血器 <br/>
        /// </summary>
        public const string Id_prop5005 = "prop5005";
        /// <summary>
        /// 名称: 便携式献血器 <br/>
        /// </summary>
        public const string Id_prop5006 = "prop5006";
        /// <summary>
        /// 名称: 木质宝箱 <br/>
        /// </summary>
        public const string Id_treasure_box0001 = "treasure_box0001";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_other_door_e = "other_door_e";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_other_door_w = "other_door_w";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_other_door_s = "other_door_s";
        /// <summary>
        /// 名称:  <br/>
        /// </summary>
        public const string Id_other_door_n = "other_door_n";
        /// <summary>
        /// 名称: 金币 <br/>
        /// </summary>
        public const string Id_gold_10 = "gold_10";
        /// <summary>
        /// 名称: 银币 <br/>
        /// </summary>
        public const string Id_gold_5 = "gold_5";
        /// <summary>
        /// 名称: 铜币 <br/>
        /// </summary>
        public const string Id_gold_1 = "gold_1";
        /// <summary>
        /// 名称: 伤害数字 <br/>
        /// </summary>
        public const string Id_hit_number = "hit_number";
    }
}
