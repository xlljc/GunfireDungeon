
public class PlanningResult
{
    public enum ErrorType
    {
        /// <summary>
        /// 执行成功
        /// </summary>
        None,
        /// <summary>
        /// 法力值不够，因为为法力值不够导致的部分法术执行失败，Data 返回导致失败的法术索引
        /// </summary>
        NoMana,
        /// <summary>
        /// 没有弹丸零件
        /// </summary>
        NoBullet,
    }

    /// <summary>
    /// 执行结果
    /// </summary>
    public ErrorType Error;
    
    public object Data;
}