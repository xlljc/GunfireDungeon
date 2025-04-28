using System.Collections.Generic;
using Config;
using Godot;

using DsUi;

namespace UI.editor.MapEditorCreateMark;

public partial class MapEditorCreateMarkPanel : MapEditorCreateMark
{
    /// <summary>
    /// 标记数据
    /// </summary>
    public MarkInfo MarkInfo { get; private set; }
    
    private UiGrid<MarkObject, MarkInfoItem> _grid;
    private bool _preloading;
    
    public override void OnCreateUi()
    {
        //隐藏模板对象
        S_ExpandPanel.Instance.Visible = false;
        S_NumberBar.Instance.Visible = false;
        S_ObjectBar.Instance.Visible = false;
        S_OptionBar.Instance.Visible = false;
        
        //添加标记按钮
        S_AddMark.Instance.Pressed += OnAddMark;

        _grid = new UiGrid<MarkObject, MarkInfoItem>(S_MarkObject, typeof(MarkObjectCell));
        _grid.SetColumns(1);
        _grid.SetHorizontalExpand(true);
        _grid.SetCellOffset(new Vector2I(0, 8));

    }

    public override void OnDestroyUi()
    {
        _grid.Destroy();
    }

    /// <summary>
    /// 初始化面板数据, 用于创建数据
    /// </summary>
    /// <param name="position">初始坐标</param>
    /// <param name="preloading">是否提前加载</param>
    public void InitData(Vector2I position, bool preloading)
    {
        _preloading = preloading;
        if (preloading)
        {
            S_DelayContainer.Instance.Visible = false;
        }
        else
        {
            S_DelayContainer.Instance.Visible = true;
        }

        S_PosX.Instance.Value = position.X;
        S_PosY.Instance.Value = position.Y;
    }
    
    /// <summary>
    /// 初始化面板数据, 用于编辑数据
    /// </summary>
    /// <param name="data">标记数据</param>
    /// <param name="preloading">是否提前加载</param>
    public void InitData(MarkInfo data, bool preloading)
    {
        MarkInfo = data;
        _preloading = preloading;
        S_SizeX.Instance.Value = data.Size.X;
        S_SizeY.Instance.Value = data.Size.Y;
        S_PosX.Instance.Value = data.Position.X;
        S_PosY.Instance.Value = data.Position.Y;
        if (preloading)
        {
            S_DelayContainer.Instance.Visible = false;
        }
        else
        {
            S_DelayContainer.Instance.Visible = true;
            S_DelayInput.Instance.Value = data.DelayTime;
        }

        if (MarkInfo.SpecialMarkType != SpecialMarkType.Normal) //特殊标记
        {
            var markInfoItem = new MarkInfoItem();
            markInfoItem.SpecialMarkType = MarkInfo.SpecialMarkType;
            _grid.Add(markInfoItem);
            //隐藏选项
            S_AddMark.Instance.Visible = false;
            S_DelayContainer.Instance.Visible = false;
        }
        else //普通标记
        {
            _grid.SetDataList(data.MarkList.ToArray());
            S_AddMark.Instance.Visible = true;
            S_DelayContainer.Instance.Visible = true;
        }
    }

    /// <summary>
    /// 获取填写的标记数据
    /// </summary>
    public MarkInfo GetMarkInfo()
    {
        if (_grid.Count == 0)
        {
            EditorWindowManager.ShowTips("警告", "必须添加一个物体!");
            return null;
        }
        
        var data = new MarkInfo();
        data.Position = new SerializeVector2();
        data.MarkList = new List<MarkInfoItem>();
        if (!_preloading)
        {
            data.DelayTime = (float)S_DelayInput.Instance.Value;
        }
        else
        {
            data.DelayTime = 0;
        }
        data.Position = new SerializeVector2((float)S_PosX.Instance.Value, (float)S_PosY.Instance.Value);
        data.Size = new SerializeVector2((float)S_SizeX.Instance.Value, (float)S_SizeY.Instance.Value);
        
        if (MarkInfo != null)
        {
            data.SpecialMarkType = MarkInfo.SpecialMarkType;
        }
        else
        {
            data.SpecialMarkType = SpecialMarkType.Normal;
        }
        
        //标记物体数据
        if (data.SpecialMarkType == SpecialMarkType.BirthPoint) //出生标记
        {
            
        }
        else if (data.SpecialMarkType == SpecialMarkType.OutPoint) //出口标记
        {
            
        }
        else //普通标记
        {
            var gridCount = _grid.Count;
            for (var i = 0; i < gridCount; i++)
            {
                var uiCell = (MarkObjectCell)_grid.GetCell(i);
                var markInfoItem = uiCell.GetMarkInfoItem();
                data.MarkList.Add(markInfoItem);
            }
        }

        return data;
    }

    /// <summary>
    /// 创建数值属性数据
    /// </summary>
    /// <param name="attrName">属性字符串名称</param>
    /// <param name="attrLabel">属性显示名称</param>
    public NumberBar CreateNumberBar(string attrName, string attrLabel)
    {
        var numberBar = S_NumberBar.Clone();
        numberBar.Instance.AttrName = attrName;
        numberBar.L_AttrName.Instance.Text = attrLabel;
        numberBar.Instance.Visible = true;
        return numberBar;
    }

    /// <summary>
    /// 创建选择物体属性数据
    /// </summary>
    /// <param name="attrName">属性字符串名称</param>
    /// <param name="attrLabel">属性显示名称</param>
    /// <param name="activityType">可选择的物体类型</param>
    public ObjectBar CreateObjectBar(string attrName, string attrLabel, ActivityType activityType)
    {
        var objectBar = S_ObjectBar.Clone();
        objectBar.Instance.AttrName = attrName;
        objectBar.Instance.ActivityType = activityType;
        objectBar.L_AttrName.Instance.Text = attrLabel;
        objectBar.Instance.Visible = true;
        return objectBar;
    }

    /// <summary>
    /// 创建选项属性数据
    /// </summary>
    /// <param name="attrName">属性字符串名称</param>
    /// <param name="attrLabel">属性显示名称</param>
    /// <returns></returns>
    public OptionBar CreateOptionBar(string attrName, string attrLabel)
    {
        var optionBar = S_OptionBar.Clone();
        optionBar.Instance.AttrName = attrName;
        optionBar.L_AttrName.Instance.Text = attrLabel;
        optionBar.Instance.Visible = true;
        return optionBar;
    }

    //点击添加标记按钮
    private void OnAddMark()
    {
        EditorWindowManager.ShowSelectObject([ActivityType.Enemy, ActivityType.Weapon, ActivityType.Prop], OnSelectObject, this);
    }

    //选中物体回调, 创建标记数据
    private void OnSelectObject(ExcelConfig.ActivityBase activityObject)
    {
        var markInfoItem = new MarkInfoItem()
        {
            Id = activityObject.Id,
            Weight = 100,
        };
        
        //初始高度
        if (activityObject.Type == ActivityType.Weapon || activityObject.Type == ActivityType.Prop)
        {
            markInfoItem.Altitude = 8;
        }
        else if (activityObject.Type == ActivityType.Other)
        {
            //随机道具或者随机武器
            if (activityObject.Id == PreinstallMarkManager.RandomWeapon.Id || activityObject.Id == PreinstallMarkManager.RandomProp.Id)
            {
                markInfoItem.Altitude = 8;
            }
        }
        _grid.Add(markInfoItem);
    }
}
