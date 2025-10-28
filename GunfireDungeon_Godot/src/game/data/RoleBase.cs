using System;

namespace Config;

public partial class ExcelConfig
{
    public partial class RoleBase
    {
        /// <summary>
        /// 获取伤害抗性
        /// </summary>
        public float GetDamageResist(DamageType damageType)
        {
            switch (damageType)
            {
                case DamageType.Physical:
                    return PhysicalReduce;
                case DamageType.Fire:
                    return FireReduce;
                case DamageType.Electric:
                    return ElectricReduce;
                case DamageType.Chemical:
                    return ChemicalReduce;
                case DamageType.Optical:
                    return OpticalReduce;
                case DamageType.DarkMatter:
                    return DarkMatterReduce;
                case DamageType.Explosive:
                    return ExplosiveReduce;
            }
            return 0;
        }
        
        /// <summary>
        /// 获取异常状态抗性
        /// </summary>
        public int GetAbnormalStateResist(AbnormalStateType stateType)
        {
            switch (stateType)
            {
                case AbnormalStateType.Bleeding:
                    return AsBleedingResist;
                case AbnormalStateType.Ignite:
                    return AsIgniteResist;
                case AbnormalStateType.ShortCircuit:
                    return AsShortCircuitResist;
                case AbnormalStateType.Interference:
                    return AsInterferenceResist;
                case AbnormalStateType.ElectricShock:
                    return AsElectricShockResist;
                case AbnormalStateType.Corrosion:
                    return AsCorrosionResist;
                case AbnormalStateType.Fragile:
                    return AsFragileResist;
                case AbnormalStateType.Blind:
                    return AsBlindResist;
                case AbnormalStateType.Chaos:
                    return AsChaosResist;
                case AbnormalStateType.ArmorBreak:
                    return AsArmorBreakResist;
            }
            return 0;
        }
    }
}