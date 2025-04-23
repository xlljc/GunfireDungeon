
using DsUi;

/// <summary>
/// 可互动物体接口
/// </summary>
public interface IInteractive : IDestroy
{
    /// <summary>
    /// 返回是否能与其他ActivityObject互动
    /// </summary>
    /// <param name="master">触发互动的物体</param>
    CheckInteractiveResult CheckInteractive(ActivityObject master);

    /// <summary>
    /// 与其它ActivityObject互动时调用, 如果要检测是否能互动请 CheckInteractive() 函数, 如果直接调用该函数那么属于强制互动行为
    /// </summary>
    /// <param name="master">触发互动的物体</param>
    void Interactive(ActivityObject master);

    /// <summary>
    /// 当目标进入互动区域时调用
    /// </summary>
    /// <param name="target">触发互动的物体</param>
    void OnTargetEnterd(ActivityObject target);

    /// <summary>
    /// 当目标离开互动区域时调用
    /// </summary>
    /// <param name="target">触发互动的物体</param>
    void OnTargetExitd(ActivityObject target);
}