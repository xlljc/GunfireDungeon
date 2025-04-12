
/// <summary>
/// 编辑器页签
/// </summary>
public interface IEditorTab
{
    /// <summary>
    /// 选中页签
    /// </summary>
    void OnSelectTab();
    
    /// <summary>
    /// 取消选中页签
    /// </summary>
    void OnUnSelectTab();
}