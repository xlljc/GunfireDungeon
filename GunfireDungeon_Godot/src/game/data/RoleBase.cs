namespace Config;

public partial class ExcelConfig
{
    public partial class RoleBase
    {
        
        /// <summary>
        /// 获取异常状态抗性
        /// </summary>
        public int GetAbnormalStateResist(AbnormalStateType stateType)
        {
            switch (stateType)
            {
                case AbnormalStateType.Burning:
                    return AsBurningResist;
                case AbnormalStateType.Poisoning:
                    return AsPoisoningResist;
            }
            return 0;
        }
    }
}