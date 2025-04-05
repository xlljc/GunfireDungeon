using System;
using System.Collections.Generic;
using Config;
using Godot;
using UI.MapEditor;

using DsUi;

namespace UI.MapEditorTools;

public partial class MapEditorToolsPanel : MapEditorTools
{
    public class CustonObjectData
    {
        public RoomObjectInfo RoomObjectInfo;
        public ObjectTemplate Node;
        public RoomLayerEnum Layer;

        public CustonObjectData(RoomObjectInfo roomObjectInfo, ObjectTemplate node, RoomLayerEnum layer)
        {
            RoomObjectInfo = roomObjectInfo;
            Node = node;
            Layer = layer;
        }
    }
    
    /// <summary>
    /// 鼠标悬停区域
    /// </summary>
    public DoorHoverArea ActiveHoverArea { get; private set; }
    
    /// <summary>
    /// 鼠标选中的标记对象
    /// </summary>
    public MarkTool ActiveMark { get; private set; }

    /// <summary>
    /// 所属编辑器Tile对象
    /// </summary>
    public EditorTileMap EditorMap { get; private set; }
    
    /// <summary>
    /// 所属编辑器面板对象
    /// </summary>
    public MapEditorPanel MapEditorPanel { get; private set; }
    
    /// <summary>
    /// 是否打开弹窗
    /// </summary>
    public bool IsOpenPopUps { get; private set; }

    /// <summary>
    /// 当前选中的工具
    /// </summary>
    public EditorToolEnum ActiveToolType => _toolGrid != null && _toolGrid.SelectData != null ? _toolGrid.SelectData.EditorToolType : EditorToolEnum.None;
    
    /// <summary>
    /// 自定义对象普通层根节点
    /// </summary>
    public Node2D CustomNormalRoot { get; private set; }
    /// <summary>
    /// 自定义对象YSort层根节点
    /// </summary>
    public Node2D CustomYSortRoot { get; private set; }
    
    /// <summary>
    /// 自定义物体映射字典, 负责存储所有自定义物体
    /// </summary>
    public Dictionary<RoomObjectInfo, CustonObjectData> CustomObjecMapping { get; } = new Dictionary<RoomObjectInfo, CustonObjectData>();
    
    private List<DoorToolTemplate> _doorTools = new List<DoorToolTemplate>();
    private Dictionary<EditorToolEnum, EditorToolBase> _toolMapping = new Dictionary<EditorToolEnum, EditorToolBase>();
    private UiGrid<ToolButton, EditorToolBase> _toolGrid;
    //当前预设的所有标记
    private Dictionary<MarkInfo, MarkTemplate> _currMarkToolsMap = new Dictionary<MarkInfo, MarkTemplate>();
    
    //丢失的物体id
    private HashSet<string> _missingSet = new HashSet<string>();
    
    private Color _tempColor1, _tempColor2;

    public override void OnCreateUi()
    {
        MapEditorPanel = (MapEditorPanel)ParentUi;
        EditorMap = MapEditorPanel.S_TileMap.Instance;
        
        S_N_HoverArea.Instance.Init(this, DoorDirection.N);
        S_S_HoverArea.Instance.Init(this, DoorDirection.S);
        S_W_HoverArea.Instance.Init(this, DoorDirection.W);
        S_E_HoverArea.Instance.Init(this, DoorDirection.E);
        S_ToolRoot.Instance.RemoveChild(S_DoorToolTemplate.Instance);
        S_MarkTemplate.Instance.Visible = false;

        S_ObjectTemplate.Instance.Visible = false;

        //工具栏
        AddToolMapping(new EditorMove(EditorMap));
        AddToolMapping(new EditorTilePen(EditorMap));
        AddToolMapping(new EditorTileAreaPen(EditorMap));
        AddToolMapping(new EditorMarkTool(EditorMap));
        AddToolMapping(new EditorFocus(EditorMap));
        AddToolMapping(new EditorObjectPen(EditorMap));
        AddToolMapping(new EditorObjectTool(EditorMap));
        
        //工具栏网格
        _toolGrid = new UiGrid<ToolButton, EditorToolBase>(S_ToolButton, typeof(ToolButtonCell));
        _toolGrid.SetColumns(15);

        CustomNormalRoot = new Node2D();
        CustomNormalRoot.ZIndex = -1;
        EditorMap.AddChild(CustomNormalRoot);
        CustomYSortRoot = new Node2D();
        EditorMap.AddChild(CustomYSortRoot);

        //标记相关
        AddEventListener(EventEnum.OnSelectWave, OnSelectWaveTool);
        AddEventListener(EventEnum.OnCreateMark, OnCreateMarkTool);
        AddEventListener(EventEnum.OnSelectMark, OnSelectMarkTool);
        AddEventListener(EventEnum.OnDeleteMark, OnDeleteMarkTool);
        AddEventListener(EventEnum.OnSetMarkVisible, OnSetMarkVisible);
        AddEventListener(EventEnum.OnEditMark, OnEditMarkTool);
        AddEventListener(EventEnum.OnSelectPreinstall, RefreshMark);
        
        //自定义物体相关
        AddEventListener(EventEnum.OnPutObject, OnPutObject);
        AddEventListener(EventEnum.OnRemoveObject, OnRemoveObject);
        AddEventListener(EventEnum.OnSelectObject, OnSelectObject);
        
        //保存预览图相关
        AddEventListener(EventEnum.OnSavePreviewImageBegin, OnSavePreviewImageBegin);
        AddEventListener(EventEnum.OnSavePreviewImageFinish, OnSavePreviewImageFinish);
    }

    public override void OnDestroyUi()
    {
        S_DoorToolTemplate.Instance.QueueFree();
        _toolGrid.Destroy();
    }

    /// <summary>
    /// 初始化面板数据
    /// </summary>
    public void InitCustomObjectData()
    {
        var objectPanel = MapEditorPanel.S_MapEditorObject.Instance;
        foreach (var objectInfo in objectPanel.NormalLayerObjects)
        {
            OnCreateObject(objectInfo, RoomLayerEnum.NormalLayer);
        }

        foreach (var objectInfo in objectPanel.YSortLayerObjects)
        {
            OnCreateObject(objectInfo, RoomLayerEnum.YSortLayer);
        }

        if (_missingSet.Count > 0)
        {
            var str = "";
            foreach (var item in _missingSet)
            {
                if (str.Length > 0)
                {
                    str += "，";
                }
                str += item;
            }
            EditorWindowManager.ShowTips("警告", $"发现存在丢失的自定义物体，id为：{str}");
        }
    }

    public override void Process(float delta)
    {
        S_HoverPreviewRoot.Instance.Visible = ActiveHoverArea != null && !DoorHoverArea.IsDrag;
        if (EditorMap.ActiveToolType == EditorToolEnum.MarkTool)
        {
            S_ToolRoot.Instance.Modulate = new Color(1, 1, 1, 1);
        }
        else
        {
            S_ToolRoot.Instance.Modulate = new Color(1, 1, 1, 0.4f);
        }

        IsOpenPopUps = UiManager.GetUiInstanceCount(UiManager.UiName.EditorWindow) > 0;
    }

    private void AddToolMapping(EditorToolBase toolBase)
    {
        _toolMapping.Add(toolBase.EditorToolType, toolBase);
    }

    /// <summary>
    /// 设置当前选择的工具
    /// </summary>
    public void SetActiviteTool(EditorToolEnum toolEnum)
    {
        if (IsDestroyed)
        {
            return;
        }

        if (_toolGrid == null)
        {
            this.CallDelay(0, () => { _SetActiviteTool(toolEnum); });
        }
        else
        {
            _SetActiviteTool(toolEnum);
        }
    }
    
    private void _SetActiviteTool(EditorToolEnum toolEnum)
    {
        var uiCell = _toolGrid.Find(tool => tool.Data.EditorToolType == toolEnum);
        if (uiCell != null)
        {
            uiCell.Click();
        }
    }
    
    /// <summary>
    /// 设置工具栏按钮
    /// </summary>
    public void SetToolButton(params EditorToolEnum[] toolEnum)
    {
        if (IsDestroyed)
        {
            return;
        }

        if (_toolGrid == null)
        {
            this.CallDelay(0, () => { _SetToolButton(toolEnum); });
        }
        else
        {
            _SetToolButton(toolEnum);
        }
    }

    public void _SetToolButton(params EditorToolEnum[] toolEnum)
    {
        _toolGrid.RemoveAll();
        foreach (var editorToolEnum in toolEnum)
        {
            if (_toolMapping.TryGetValue(editorToolEnum, out var tool))
            {
                _toolGrid.Add(tool);
            }
        }
    }


    //放置自定义物体
    private void OnPutObject(object obj)
    {
        var info = (RoomObjectInfo)obj;
        var layerType = MapEditorPanel.S_MapEditorObject.Instance.GetCurrentObjectLayerEnum();
        OnCreateObject(info, layerType);
    }

    /// <summary>
    /// 移除物体
    /// </summary>
    private void OnRemoveObject(object obj)
    {
        var info = (RoomObjectInfo)obj;
        if (CustomObjecMapping.TryGetValue(info, out var data))
        {
            CustomObjecMapping.Remove(info);
            data.Node.QueueFree();
        }
    }

    /// <summary>
    /// 选择物体
    /// </summary>
    private void OnSelectObject(object obj)
    {
        SetActiviteTool(EditorToolEnum.ObjectTool);
    }
    
    //创建自定义物体
    private void OnCreateObject(RoomObjectInfo info, RoomLayerEnum layerType)
    {
        if (ExcelConfig.EditorObject_Map.TryGetValue(info.Id, out var config))
        {
            var node = ResourceManager.LoadEditorObject(config);
            
            var template = S_ObjectTemplate.Clone();
            template.Instance.Visible = true;
            template.Instance.Position = new Vector2(info.X, info.Y);
            template.Instance.Init(info, node);
            template.Instance.Monitorable = (int)layerType == MapEditorPanel.S_MapEditorObject.Instance.S_LayerOption.Instance.Selected;
            
            switch (layerType)
            {
                case RoomLayerEnum.NormalLayer:
                    CustomNormalRoot.AddChild(template.Instance);
                    CustomObjecMapping.Add(info, new CustonObjectData(info, template, RoomLayerEnum.NormalLayer));
                    break;
                case RoomLayerEnum.YSortLayer:
                    CustomYSortRoot.AddChild(template.Instance);
                    CustomObjecMapping.Add(info, new CustonObjectData(info, template, RoomLayerEnum.YSortLayer));
                    break;
            }
        }
        else
        {
            Debug.LogError($"创建CustomObject没有找到物体配置: {info.Id}!");
            _missingSet.Add(info.Id);
        }
    }

    //刷新标记
    private void RefreshMark(object arg)
    {
        ActiveMark = null;
        //删除之前的数据
        foreach (var keyValuePair in _currMarkToolsMap)
        {
            keyValuePair.Value.QueueFree();
        }
        _currMarkToolsMap.Clear();
        //添加新的数据
        var selectPreinstall = EditorTileMapManager.SelectPreinstall;
        if (selectPreinstall != null)
        {
            foreach (var markInfos in selectPreinstall.WaveList)
            {
                foreach (var markInfo in markInfos)
                {
                    CreateMarkTool(markInfo);
                }
            }
        }
    }

    //选中波数
    private void OnSelectWaveTool(object arg)
    {
        //选中编辑工具
        SetActiviteTool(EditorToolEnum.MarkTool);

        var selectIndex = EditorTileMapManager.SelectWaveIndex;
        var waveList = EditorTileMapManager.SelectPreinstall.WaveList;
        for (var i = 0; i < waveList.Count; i++)
        {
            var wave = waveList[i];
            foreach (var markInfo in wave)
            {
                if (_currMarkToolsMap.TryGetValue(markInfo, out var markTemplate))
                {
                    if (i == selectIndex) //选中当前波数, 透明度改为1
                    {
                        markTemplate.Instance.SetModulateAlpha(1f);
                    }
                    else //未选中当前波数, 透明度改为0.6
                    {
                        markTemplate.Instance.SetModulateAlpha(0.45f);
                    }
                }
            }
        }
    }
    
    //创建标记
    private void OnCreateMarkTool(object arg)
    {
        var markInfo = (MarkInfo)arg;
        CreateMarkTool(markInfo);
    }

    //创建标记
    private void CreateMarkTool(MarkInfo markInfo)
    {
        var cloneAndPut = S_MarkTemplate.CloneAndPut();
        _currMarkToolsMap.Add(markInfo, cloneAndPut);
        cloneAndPut.Instance.Visible = true;
        cloneAndPut.Instance.InitData(markInfo);
    }

    //选中标记
    private void OnSelectMarkTool(object arg)
    {
        //选中编辑工具
        SetActiviteTool(EditorToolEnum.MarkTool);
        
        if (arg is MarkInfo markInfo)
        {
            if (ActiveMark == null || markInfo != ActiveMark.MarkInfo)
            {
                if (_currMarkToolsMap.TryGetValue(markInfo, out var markTemplate))
                {
                    SetActiveMark(markTemplate.Instance);
                }
            }
        }
        else if (arg == null && ActiveMark != null)
        {
            SetActiveMark(null);
        }
    }

    //删除标记
    private void OnDeleteMarkTool(object arg)
    {
        if (arg is MarkInfo markInfo)
        {
            if (_currMarkToolsMap.TryGetValue(markInfo, out var markTemplate))
            {
                if (ActiveMark == markTemplate.Instance)
                {
                    SetActiveMark(null);
                }
                markTemplate.QueueFree();
                _currMarkToolsMap.Remove(markInfo);
            }
        }
    }

    //设置标记显示状态
    private void OnSetMarkVisible(object arg)
    {
        var data = (MarkInfoVisibleData)arg;
        if (_currMarkToolsMap.TryGetValue(data.MarkInfo, out var markTemplate))
        {
            markTemplate.Instance.Visible = data.Visible;
        }
    }
    
    //编辑标记
    private void OnEditMarkTool(object arg)
    {
        if (arg is MarkInfo markInfo)
        {
            if (_currMarkToolsMap.TryGetValue(markInfo, out var markTemplate))
            {
                //刷新数据
                markTemplate.Instance.RefreshData();
            }
        }
    }
    
    /// <summary>
    /// 获取门区域对象
    /// </summary>
    public DoorHoverArea GetDoorHoverArea(DoorDirection direction)
    {
        switch (direction)
        {
            case DoorDirection.E: return S_E_HoverArea.Instance;
            case DoorDirection.N: return S_N_HoverArea.Instance;
            case DoorDirection.W: return S_W_HoverArea.Instance;
            case DoorDirection.S: return S_S_HoverArea.Instance;
        }
        return null;
    }
    
    /// <summary>
    /// 获取门区域根节点
    /// </summary>
    public Control GetDoorHoverAreaRoot(DoorDirection direction)
    {
        switch (direction)
        {
            case DoorDirection.E: return S_E_HoverRoot.Instance;
            case DoorDirection.N: return S_N_HoverRoot.Instance;
            case DoorDirection.W: return S_W_HoverRoot.Instance;
            case DoorDirection.S: return S_S_HoverRoot.Instance;
        }
        return null;
    }

    /// <summary>
    /// 设置活动的鼠标悬停的区域
    /// </summary>
    public void SetActiveHoverArea(DoorHoverArea hoverArea)
    {
        ActiveHoverArea = hoverArea;
        if (hoverArea != null)
        {
            S_HoverPreviewRoot.Instance.Reparent(hoverArea.GetParent(), false);
        }
        else
        {
            S_HoverPreviewRoot.Instance.Reparent(S_ToolRoot.Instance, false);
        }
    }

    /// <summary>
    /// 设置当前活动的标记
    /// </summary>
    public void SetActiveMark(MarkTool markTool)
    {
        if (ActiveMark == markTool)
        {
            return;
        }

        if (ActiveMark != null) //取消选中上一个
        {
            ActiveMark.OnUnSelect();
        }
        ActiveMark = markTool;
        if (markTool != null) //选中当前
        {
            ActiveMark.OnSelect();
            EditorTileMapManager.SetSelectMark(markTool.MarkInfo);
        }
        else
        {
            EditorTileMapManager.SetSelectMark(null);
        }
    }

    /// <summary>
    /// 创建门区域设置工具
    /// </summary>
    /// <param name="doorAreaInfo">门区域数据</param>
    public DoorToolTemplate CreateDoorTool(DoorAreaInfo doorAreaInfo)
    {
        var doorHoverArea = GetDoorHoverArea(doorAreaInfo.Direction);
        var inst = CreateDoorToolInstance(doorHoverArea);
        inst.Instance.DoorAreaInfo = doorAreaInfo;
        inst.Instance.SetDoorAreaPosition(GetDoorHoverAreaRoot(doorAreaInfo.Direction).Position);
        inst.Instance.SetDoorAreaRange(doorAreaInfo.Start, doorAreaInfo.End);
        return inst;
    }

    /// <summary>
    /// 创建拖拽状态下的门区域工具, 用于创建门区域
    /// </summary>
    /// <param name="doorHoverArea">悬停区域</param>
    /// <param name="start">起始位置, 单位: 像素</param>
    /// <param name="onSubmit">成功提交时回调, 参数1为方向, 参数2为起始点, 参数3为大小</param>
    /// <param name="onCancel">取消提交时调用</param>
    public DoorToolTemplate CreateDragDoorTool(DoorHoverArea doorHoverArea, int start,
        Action<DoorDirection, int, int> onSubmit, Action onCancel)
    {
        var inst = CreateDoorToolInstance(doorHoverArea);
        inst.Instance.SetDoorAreaPosition(GetDoorHoverAreaRoot(doorHoverArea.Direction).Position);
        inst.Instance.SetDoorAreaRange(start, start);
        inst.Instance.MakeDragMode(onSubmit, () =>
        {
            RemoveDoorTool(inst);
            onCancel();
        });
        return inst;
    }

    /// <summary>
    /// 移除门区域设置工具
    /// </summary>
    public void RemoveDoorTool(DoorToolTemplate toolInstance)
    {
        _doorTools.Remove(toolInstance);
        if (toolInstance.Instance.DoorAreaInfo != null)
        {
            EditorMap.RemoveDoorArea(toolInstance.Instance.DoorAreaInfo);
        }
        toolInstance.Instance.QueueFree();
        //派发修改数据修改事件
        EventManager.EmitEvent(EventEnum.OnTileMapDirty);
    }

    /// <summary>
    /// 设置工具根节点的大小和缩放
    /// </summary>
    /// <param name="pos">坐标</param>
    /// <param name="scale">缩放</param>
    public void SetToolTransform(Vector2 pos, Vector2 scale)
    {
        S_ToolRoot.Instance.Position = pos;
        S_ToolRoot.Instance.Scale = scale;
    }

    /// <summary>
    /// 设置鼠标悬停区域位置和大小
    /// </summary>
    /// <param name="position">房间起始点, 单位: 格</param>
    /// <param name="size">房间大小, 单位: 格</param>
    public void SetDoorHoverToolTransform(Vector2I position, Vector2I size)
    {
        position *= GameConfig.TileCellSize;
        size *= GameConfig.TileCellSize;

        var nPos1 = S_N_HoverRoot.Instance.Position;
        var ePos1 = S_E_HoverRoot.Instance.Position;
        var sPos1 = S_S_HoverRoot.Instance.Position;
        var wPos1 = S_W_HoverRoot.Instance.Position;
        var nPos2 = position + new Vector2I(GameConfig.TileCellSize * 2, GameConfig.TileCellSize * 3);
        var ePos2 = new Vector2(position.X + size.X - GameConfig.TileCellSize * 2, position.Y + GameConfig.TileCellSize * 3);
        var sPos2 = new Vector2(position.X + GameConfig.TileCellSize * 2, position.Y + size.Y - GameConfig.TileCellSize * 2);
        var wPos2 = position + new Vector2I(GameConfig.TileCellSize * 2, GameConfig.TileCellSize * 3);

        var nSize2 = new Vector2(size.X - GameConfig.TileCellSize * 4, S_N_HoverArea.Instance.Size.Y);
        var eSize2 = new Vector2(size.Y - GameConfig.TileCellSize * 5, S_E_HoverArea.Instance.Size.Y);
        var sSize2 = new Vector2(size.X - GameConfig.TileCellSize * 4, S_S_HoverArea.Instance.Size.Y);
        var wSize2 = new Vector2(size.Y - GameConfig.TileCellSize * 5, S_W_HoverArea.Instance.Size.Y);
        
        S_N_HoverRoot.Instance.Position = nPos2;
        S_E_HoverRoot.Instance.Position = ePos2;
        S_S_HoverRoot.Instance.Position = sPos2;
        S_W_HoverRoot.Instance.Position = wPos2;
        
        S_N_HoverArea.Instance.Size = nSize2;
        S_E_HoverArea.Instance.Size = eSize2;
        S_S_HoverArea.Instance.Size = sSize2;
        S_W_HoverArea.Instance.Size = wSize2;
        
        //调整门区域
        for (var i = 0; i < _doorTools.Count; i++)
        {
            var doorTool = _doorTools[i];
            var direction = doorTool.Instance.Direction;
            var areaRoot = GetDoorHoverAreaRoot(direction);
            var doorAreaRange = doorTool.Instance.GetDoorAreaRange();
            doorTool.Instance.SetDoorAreaPosition(areaRoot.Position);

            if (direction == DoorDirection.N)
            {
                var hOffset = (int)(nPos2.X - nPos1.X);
                doorAreaRange.X -= hOffset;
                doorAreaRange.Y -= hOffset;

                if (doorAreaRange.X >= 0 && doorAreaRange.Y <= nSize2.X) //允许提交
                {
                    doorTool.Instance.SetDoorAreaRange(doorAreaRange.X, doorAreaRange.Y);
                    if (doorTool.Instance.DoorAreaInfo != null)
                    {
                        doorTool.Instance.DoorAreaInfo.Start = doorAreaRange.X;
                        doorTool.Instance.DoorAreaInfo.End = doorAreaRange.Y;
                    }
                }
                else //如果超出区域, 则删除
                {
                    RemoveDoorTool(doorTool);
                    i--;
                }
            }
            else if (direction == DoorDirection.S)
            {
                var hOffset = (int)(sPos2.X - sPos1.X);
                doorAreaRange.X -= hOffset;
                doorAreaRange.Y -= hOffset;

                if (doorAreaRange.X >= 0 && doorAreaRange.Y <= sSize2.X) //允许提交
                {
                    doorTool.Instance.SetDoorAreaRange(doorAreaRange.X, doorAreaRange.Y);
                    if (doorTool.Instance.DoorAreaInfo != null)
                    {
                        doorTool.Instance.DoorAreaInfo.Start = doorAreaRange.X;
                        doorTool.Instance.DoorAreaInfo.End = doorAreaRange.Y;
                    }
                }
                else //如果超出区域, 则删除
                {
                    RemoveDoorTool(doorTool);
                    i--;
                }
            }
            else if (direction == DoorDirection.E)
            {
                var vOffset = (int)(ePos2.Y - ePos1.Y);
                doorAreaRange.X -= vOffset;
                doorAreaRange.Y -= vOffset;

                if (doorAreaRange.X >= 0 && doorAreaRange.Y <= eSize2.X) //允许提交
                {
                    doorTool.Instance.SetDoorAreaRange(doorAreaRange.X, doorAreaRange.Y);
                    if (doorTool.Instance.DoorAreaInfo != null)
                    {
                        doorTool.Instance.DoorAreaInfo.Start = doorAreaRange.X;
                        doorTool.Instance.DoorAreaInfo.End = doorAreaRange.Y;
                    }
                }
                else //如果超出区域, 则删除
                {
                    RemoveDoorTool(doorTool);
                    i--;
                }
            }
            else if (direction == DoorDirection.W)
            {
                var vOffset = (int)(wPos2.Y - wPos1.Y);
                doorAreaRange.X -= vOffset;
                doorAreaRange.Y -= vOffset;

                if (doorAreaRange.X >= 0 && doorAreaRange.Y <= wSize2.X) //允许提交
                {
                    doorTool.Instance.SetDoorAreaRange(doorAreaRange.X, doorAreaRange.Y);
                    if (doorTool.Instance.DoorAreaInfo != null)
                    {
                        doorTool.Instance.DoorAreaInfo.Start = doorAreaRange.X;
                        doorTool.Instance.DoorAreaInfo.End = doorAreaRange.Y;
                    }
                }
                else //如果超出区域, 则删除
                {
                    RemoveDoorTool(doorTool);
                    i--;
                }
            }
        }
    }
    
    private DoorToolTemplate CreateDoorToolInstance(DoorHoverArea doorHoverArea)
    {
        var doorTool = S_DoorToolTemplate.Clone();
        S_ToolRoot.Instance.AddChild(doorTool.Instance);
        doorTool.Instance.SetDoorDragAreaNode(doorTool);
        doorTool.L_StartBtn.Instance.SetMapEditorToolsPanel(this);
        doorTool.L_EndBtn.Instance.SetMapEditorToolsPanel(this);
        doorTool.Instance.SetDoorHoverArea(doorHoverArea);
        _doorTools.Add(doorTool);
        return doorTool;
    }
    
    private void OnSavePreviewImageBegin(object obj)
    {
        foreach (var custonObjectData in CustomObjecMapping)
        {
            custonObjectData.Value.Node.L_RectBrush.Instance.Visible = false;
        }

        _tempColor1 = CustomNormalRoot.Modulate;
        _tempColor2 = CustomYSortRoot.Modulate;

        CustomNormalRoot.Modulate = Colors.White;
        CustomYSortRoot.Modulate = Colors.White;
    }

    private void OnSavePreviewImageFinish(object obj)
    {
        foreach (var custonObjectData in CustomObjecMapping)
        {
            custonObjectData.Value.Node.L_RectBrush.Instance.Visible = true;
        }
        
        CustomNormalRoot.Modulate = _tempColor1;
        CustomYSortRoot.Modulate = _tempColor2;
    }
}
