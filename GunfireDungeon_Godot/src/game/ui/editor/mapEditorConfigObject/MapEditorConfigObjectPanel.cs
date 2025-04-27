using System.Linq;
using Config;
using Godot;

using DsUi;

namespace UI.editor.MapEditorConfigObject;

public partial class MapEditorConfigObjectPanel : MapEditorConfigObject
{
    private UiGrid<CellButton, ExcelConfig.EditorObject> _grid;
    private bool _initData = false;
    private long _gridCoroutineId = -1;
    
    public override void OnCreateUi()
    {
        _grid = CreateUiGrid<CellButton, ExcelConfig.EditorObject, ItemCell>(S_CellButton);
        _grid.SetAutoColumns(true);
        _grid.SetHorizontalExpand(true);
        
        //搜索按钮
        S_SearchButton.Instance.Pressed += OnSearchButtonClicked;
    }

    public override void OnShowUi()
    {
        if (!_initData)
        {
            _initData = true;
            OnSearchButtonClicked();
        }
    }

    public override void OnDestroyUi()
    {
        
    }

    /// <summary>
    /// 获取选中的配置
    /// </summary>
    public ExcelConfig.EditorObject GetSelectConfig()
    {
        return _grid.SelectData;
    }
    
    //搜索按钮点击
    private void OnSearchButtonClicked()
    {
        if (_gridCoroutineId != -1)
        {
            StopCoroutine(_gridCoroutineId);
        }
        
        var text = S_SearchInput.Instance.Text;
        if (string.IsNullOrEmpty(text))
        {
            _gridCoroutineId = StartCoroutine(_grid.SetDataListCoroutine(ExcelConfig.EditorObject_List));
        }
        else
        {
            var enumerable = ExcelConfig.EditorObject_List.Where(item => item.GetRealName().Contains(text));
            _gridCoroutineId = StartCoroutine(_grid.SetDataListCoroutine(enumerable.ToArray()));
        }
    }

}
