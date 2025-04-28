
using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Godot;

using DsUi;

namespace UI.editor.MapEditorSelectObject;

public partial class MapEditorSelectObjectPanel : MapEditorSelectObject
{
    /// <summary>
    /// 双击选中物体事件
    /// </summary>
    public event Action<ExcelConfig.ActivityBase> SelectObjectEvent;
    
    public class TypeButtonData
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        public string Name;
        /// <summary>
        /// 类型值
        /// </summary>
        public ActivityType Type;

        public TypeButtonData(string name, ActivityType type)
        {
            Name = name;
            Type = type;
        }
    }
    //类型网格组件
    private UiGrid<TypeButton, TypeButtonData> _typeGrid;
    //物体网格组件
    private UiGrid<ObjectButton, ExcelConfig.ActivityBase> _objectGrid;
    //允许出现在该面板中的物体类型
    private List<ActivityType> _typeList = new List<ActivityType>();
    
    public override void OnCreateUi()
    {
        S_Search.Instance.Pressed += OnSearch;
        
        _typeGrid = new UiGrid<TypeButton, TypeButtonData>(S_TypeButton, typeof(TypeButtonCell));
        _typeGrid.SetColumns(1);
        _typeGrid.SetHorizontalExpand(true);
        _typeGrid.SetCellOffset(new Vector2I(0, 5));
        
        _objectGrid = new UiGrid<ObjectButton, ExcelConfig.ActivityBase>(S_ObjectButton, typeof(ObjectButtonCell));
        _objectGrid.SetAutoColumns(true);
        _objectGrid.SetHorizontalExpand(true);
        _objectGrid.SetCellOffset(new Vector2I(2, 2));
    }

    public override void OnDestroyUi()
    {
        _typeGrid.Destroy();
        _objectGrid.Destroy();
    }

    /// <summary>
    /// 设置显示的物体类型
    /// </summary>
    public void SetShowType(params ActivityType[] activityTypes)
    {
        _typeGrid.RemoveAll();

        var list = new List<ActivityType>();
        for (var i = 0; i < activityTypes.Length; i++)
        {
            var item = activityTypes[i];
            if (item != ActivityType.None)
            {
                list.Add(item);
            }
        }

        _typeList.AddRange(list.Distinct());
        
        _typeGrid.Add(new TypeButtonData("所有", ActivityType.None));
        foreach (var activityType in _typeList)
        {
            _typeGrid.Add(new TypeButtonData(ActivityId.GetTypeName(activityType), activityType));
        }

        
        _typeGrid.SelectIndex = 0;
    }

    /// <summary>
    /// 搜索对象
    /// </summary>
    public void OnSearch()
    {
        //类型
        ActivityType type;
        //名称
        var name = S_LineEdit.Instance.Text;
        var buttonData = _typeGrid.GetData(_typeGrid.SelectIndex);
        if (buttonData != null)
        {
            type = buttonData.Type;
        }
        else
        {
            type = ActivityType.None;
        }

        //搜索结果
        var arr = new List<ExcelConfig.ActivityBase>();
        if (type == ActivityType.None)
        {
            if (_typeList.Contains(ActivityType.Weapon)) //随机武器
            {
                arr.Add(PreinstallMarkManager.RandomWeapon);
            }
            if (_typeList.Contains(ActivityType.Prop)) //随机道具
            {
                arr.Add(PreinstallMarkManager.RandomProp);
            }
            if (_typeList.Contains(ActivityType.Enemy)) //随机敌人
            {
                arr.Add(PreinstallMarkManager.RandomEnemy);
            }
        }
        else if (type == ActivityType.Weapon)
        {
            arr.Add(PreinstallMarkManager.RandomWeapon);
        }
        else if (type == ActivityType.Prop)
        {
            arr.Add(PreinstallMarkManager.RandomProp);
        }
        else if (type == ActivityType.Enemy)
        {
            arr.Add(PreinstallMarkManager.RandomEnemy);
        }
        
        foreach (var o in ExcelConfig.ActivityBase_List)
        {
            if (//在编辑器中显示
                o.ShowInMapEditor &&
                // 模糊匹配
                (string.IsNullOrEmpty(name) || o.Name.Contains(name) || o.Id.Contains(name)) &&
                // 类型匹配
                (type == ActivityType.None ? _typeList.Contains(o.Type) : o.Type == type)
               )
            {
                arr.Add(o);
            }
        }
        
        _objectGrid.SetDataList(arr.ToArray());
    }

    /// <summary>
    /// 选中对象
    /// </summary>
    public void SelectCell(ExcelConfig.ActivityBase activityObject)
    {
        if (SelectObjectEvent != null)
        {
            SelectObjectEvent(activityObject);
        }
    }

    /// <summary>
    /// 获取选中的数据
    /// </summary>
    public ExcelConfig.ActivityBase GetSelectData()
    {
        return _objectGrid.SelectData;
    }
}
