using DsUi;

namespace UI.game.PartPackUI;

/// <summary>
/// 拖拽放置零件物体数据
/// </summary>
public class DropPartData
{
    /// <summary>
    /// 在 UiGrid 中的索引
    /// </summary>
    public int Index;
    /// <summary>
    /// 修改的后的数据
    /// </summary>
    public PartItemData Data;
    
    public DropPartData(int index, PartItemData data)
    {
        Index = index;
        Data = data;
    }
}