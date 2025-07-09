
using System.Text.Json;
using Config;

/// <summary>
/// 异常状态处理接口
/// </summary>
public interface IAbnormalStateComp
{
    /// <summary>
    /// 初始化参数
    /// </summary>
    void InitConfig(ExcelConfig.AbnormalStateConfig config, JsonElement[] param);

    /// <summary>
    /// 激活异常状态
    /// </summary>
    void OnActivate(int level);
    
    /// <summary>
    /// 取消异常状态
    /// </summary>
    void OnDeactivate(int level);

    /// <summary>
    /// 升级异常状态层级
    /// </summary>
    void OnLevelUp(int level);
    
    /// <summary>
    /// 降级异常状态层级
    /// </summary>
    void OnLevelDown(int level);
}