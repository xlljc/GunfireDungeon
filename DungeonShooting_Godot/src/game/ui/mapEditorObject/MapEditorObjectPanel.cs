using System.Collections.Generic;
using System.Linq;
using Config;
using Godot;
using UI.MapEditor;

namespace UI.MapEditorObject;

public partial class MapEditorObjectPanel : MapEditorObject, IEditorTab
{
    /// <summary>
    /// 编辑器Tile对象
    /// </summary>
    public EditorTileMap EditorTileMap { get; private set; }

    /// <summary>
    /// 临时存储普通层自定义物体数据
    /// </summary>
    public readonly List<RoomObjectInfo> NormalLayerObjects = new List<RoomObjectInfo>();
    
    /// <summary>
    /// 临时存储Y排序层自定义物体数据
    /// </summary>
    public readonly List<RoomObjectInfo> YSortLayerObjects = new List<RoomObjectInfo>();
    
    /// <summary>
    /// 当前页签是否选中
    /// </summary>
    public bool IsActiveTab { get; private set; }

    /// <summary>
    /// 物体网格
    /// </summary>
    public UiGrid<Item, RoomObjectInfo> ObjectGrid { get; private set; }
    
    public override void OnCreateUi()
    {
        var editorPanel = (MapEditorPanel)ParentUi;
        EditorTileMap = editorPanel.S_TileMap.Instance;
        
        ObjectGrid = CreateUiGrid<Item, RoomObjectInfo, ItemCell>(S_Item);
        ObjectGrid.SetHorizontalExpand(true);
        ObjectGrid.SelectEvent += OnSelectEvent;
        
        AddEventListener(EventEnum.OnPutObject, OnPutObject);
        AddEventListener(EventEnum.OnSelectObject, OnSelectObject);
        
        S_SearchButton.Instance.Pressed += OnSearchClick;
        S_LayerOption.Instance.ItemSelected += (index) =>
        {
            OnChangeObjectLayer(index);
            OnSearchClick();
        };

        S_DynamicDeleteButton.Instance.Pressed += OnDelete;
    }

    public override void OnDestroyUi()
    {
        
    }

    /// <summary>
    /// 初始化面板数据
    /// </summary>
    public void InitData()
    {
        var tileInfo = EditorTileMap.CurrRoomSplit.TileInfo;
        if (tileInfo.NormalLayerObjects != null)
        {
            foreach (var temp in tileInfo.NormalLayerObjects)
            {
                if (ExcelConfig.EditorObject_Map.ContainsKey(temp.Id))
                {
                    NormalLayerObjects.Add(temp.Clone());
                }
            }
        }

        if (tileInfo.YSortLayerObjects != null)
        {
            foreach (var temp in tileInfo.YSortLayerObjects)
            {
                if (ExcelConfig.EditorObject_Map.ContainsKey(temp.Id))
                {
                    YSortLayerObjects.Add(temp.Clone());
                }
            }
        }
        
        EditorTileMap.MapEditorPanel.S_MapEditorTools.Instance.InitCustomObjectData();
        //刷新数据
        OnSearchClick();
    }
    
    /// <summary>
    /// 保存配置数据
    /// </summary>
    public void OnSaveData(DungeonTileInfo tileInfo)
    {
        if (tileInfo.NormalLayerObjects == null)
        {
            tileInfo.NormalLayerObjects = new List<RoomObjectInfo>();
        }
        else
        {
            tileInfo.NormalLayerObjects.Clear();
        }

        foreach (var normalLayerObject in NormalLayerObjects)
        {
            tileInfo.NormalLayerObjects.Add(normalLayerObject.Clone());
        }

        if (tileInfo.YSortLayerObjects == null)
        {
            tileInfo.YSortLayerObjects = new List<RoomObjectInfo>();
        }
        else
        {
            tileInfo.YSortLayerObjects.Clear();
        }

        foreach (var ySortLayerObject in YSortLayerObjects)
        {
            tileInfo.YSortLayerObjects.Add(ySortLayerObject.Clone());
        }
    }

    /// <summary>
    /// 聚焦物体
    /// </summary>
    public void FoceSelectObject(RoomObjectInfo info)
    {
        EditorTileMap.SetLookPosition(new Vector2(info.X, info.Y));
    }

    /// <summary>
    /// 获取当前选中的物体层
    /// </summary>
    public List<RoomObjectInfo> GetCurrentObjectLayer()
    {
        return S_LayerOption.Instance.Selected == 0 ? NormalLayerObjects : YSortLayerObjects;
    }

    /// <summary>
    /// 获取当前选中的物体层
    /// </summary>
    public RoomLayerEnum GetCurrentObjectLayerEnum()
    {
        return S_LayerOption.Instance.Selected == 0 ? RoomLayerEnum.NormalLayer : RoomLayerEnum.YSortLayer;
    }

    private void OnChangeObjectLayer(long index)
    {
        var editorToolsPanel = EditorTileMap.MapEditorPanel.S_MapEditorTools.Instance;
        var toolsPanel = editorToolsPanel;

        if (index == 0)
        {
            toolsPanel.CustomNormalRoot.Modulate = Colors.White;
            toolsPanel.CustomYSortRoot.Modulate = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            toolsPanel.CustomNormalRoot.Modulate = new Color(1, 1, 1, 0.5f);
            toolsPanel.CustomYSortRoot.Modulate = Colors.White;
        }
        
        //启用当前层的Area2D物体监视
        foreach (var custonObjectData in editorToolsPanel.CustomObjecMapping)
        {
            var objectData = custonObjectData.Value;
            objectData.Node.Instance.Monitorable = (long)objectData.Layer == index;
        }
    }

    //搜索
    public void OnSearchClick()
    {
        var dataList = GetCurrentObjectLayer();
        var text = S_SearchInput.Instance.Text;
        if (string.IsNullOrEmpty(text))
        {
            ObjectGrid.SetDataList(dataList);
        }
        else
        {
            var result = dataList.Where(data => ExcelConfig.EditorObject_Map[data.Id].Name.Contains(text)).ToArray();
            ObjectGrid.SetDataList(result);
        }
    }
    
    //创建自定义物体
    private void OnPutObject(object obj)
    {
        var temp = (RoomObjectInfo)obj;
        var layer = GetCurrentObjectLayer();
        layer.Add(temp);
        OnSearchClick();
    }
    
    private void OnSelectEvent(int index)
    {
        if (index < 0)
        {
            S_DynamicDeleteButton.Instance.Visible = false;
            S_DynamicDeleteButton.Reparent(this);
        }
        else
        {
            S_DynamicDeleteButton.Instance.Visible = true;
            S_DynamicDeleteButton.Reparent(ObjectGrid.GetCell(index).CellNode.Instance);
        }
    }
    
    //删除
    private void OnDelete()
    {
        if (ObjectGrid.SelectIndex < 0)
        {
            return;
        }

        EditorWindowManager.ShowConfirm("提示", "确定删除该物体吗？", b =>
        {
            if (b)
            {
                var layer = GetCurrentObjectLayer();
                var temp = layer[ObjectGrid.SelectIndex];
                layer.RemoveAt(ObjectGrid.SelectIndex);
                
                //派发删除事件
                EventManager.EmitEvent(EventEnum.OnRemoveObject, temp);
                
                OnSearchClick();

                //标记数据脏了
                EventManager.EmitEvent(EventEnum.OnTileMapDirty);
            }
        });
    }

    public void OnSelectTab()
    {
        IsActiveTab = true;
        var panel = EditorTileMap.MapEditorPanel;
        
        panel.S_LayerPanel.Instance.Visible = true;
        panel.S_LayerPanel.L_MapEditorMapLayer.Instance.HideUi();
        panel.S_LayerPanel.L_MapEditorConfigObject.Instance.ShowUi();
            
        panel.S_MapEditorTools.Instance.SetToolButton(EditorToolEnum.Move, EditorToolEnum.ObjectPen, EditorToolEnum.ObjectTool, EditorToolEnum.Focus);
        OnChangeObjectLayer(S_LayerOption.Instance.Selected);
    }

    public void OnUnSelectTab()
    {
        var panel = EditorTileMap.MapEditorPanel;
        panel.S_MapEditorTools.Instance.CustomNormalRoot.Modulate = Colors.White;
        panel.S_MapEditorTools.Instance.CustomYSortRoot.Modulate = Colors.White;
        IsActiveTab = false;
    }
    
    private void OnSelectObject(object obj)
    {
        var data = (RoomObjectInfo)obj;
        if (ObjectGrid.SelectData != data)
        {
            var uiCell = ObjectGrid.Find(item => item.Data == data);
            if (uiCell != null)
            {
                uiCell.Click();
            }
        }
    }
}
