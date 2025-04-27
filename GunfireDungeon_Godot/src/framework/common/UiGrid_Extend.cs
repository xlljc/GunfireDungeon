namespace DsUi;

public partial class UiGrid<TUiCellNode, TData> : IUiGrid where TUiCellNode : IUiCellNode
{
    /// <summary>
    /// 绑定在当前 UiGrid 上的事件系统，在 UiGrid 销毁时会自动释放
    /// </summary>
    public EventPackage<string> EventPackage
    {
        get
        {
            if (_eventPackage == null)
            {
                _eventPackage = new EventPackage<string>();
                AddDestroyObject(_eventPackage);
            }

            return _eventPackage;
        }
    }

    private EventPackage<string> _eventPackage;
}