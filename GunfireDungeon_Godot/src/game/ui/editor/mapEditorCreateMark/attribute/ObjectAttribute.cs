using Config;

using DsUi;

namespace UI.editor.MapEditorCreateMark;

public partial class ObjectAttribute : AttributeBase
{
    /// <summary>
    /// 可选择的物体类型
    /// </summary>
    public ActivityType ActivityType { get; set; }
    private MapEditorCreateMark.ObjectBar _objectBar;
    //选择的武器数据
    private ExcelConfig.WeaponBase _selectWeapon;
    //关联属性
    private MapEditorCreateMark.NumberBar _currAmmonAttr;
    private MapEditorCreateMark.NumberBar _residueManaAttr;

    public override void SetUiNode(IUiNode uiNode)
    {
        _objectBar = (MapEditorCreateMark.ObjectBar)uiNode;
        _objectBar.L_HBoxContainer.L_SelectButton.Instance.Pressed += OnClickEdit;
        _objectBar.L_HBoxContainer.L_DeleteButton.Instance.Pressed += OnClickDelete;
    }

    public override void OnDestroy()
    {
        
    }

    public override string GetAttributeValue()
    {
        if (_selectWeapon == null)
        {
            return null;
        }
        return _selectWeapon.Activity.Id;
    }

    //点击编辑按钮
    private void OnClickEdit()
    {
        EditorWindowManager.ShowSelectObject(ActivityType.Weapon, OnSelectObject, _objectBar.UiPanel);
    }

    //点击删除按钮
    private void OnClickDelete()
    {
        SelectWeapon(null);
    }

    private void OnSelectObject(ExcelConfig.ActivityBase activityObject)
    {
        var weapon = Weapon.GetWeaponAttribute(activityObject.Id);
        if (weapon != null)
        {
            SelectWeapon(weapon);
        }
    }

    /// <summary>
    /// 设置选择的武器物体
    /// </summary>
    public void SelectWeapon(ExcelConfig.WeaponBase weapon)
    {
        if (weapon == null)
        {
            _objectBar.L_HBoxContainer.L_DeleteButton.Instance.Visible = false;
            _selectWeapon = null;
            //隐藏关联属性
            _currAmmonAttr.Instance.Visible = false;
            _residueManaAttr.Instance.Visible = false;
            _objectBar.L_HBoxContainer.L_ObjectIcon.Instance.Visible = false;
            _objectBar.L_HBoxContainer.L_ObjectName.Instance.Text = "<未选择>";
        }
        else
        {
            _objectBar.L_HBoxContainer.L_DeleteButton.Instance.Visible = true;
            _selectWeapon = weapon;
            var o = weapon.Activity;
            //显示关联属性
            _currAmmonAttr.Instance.Visible = true;
            _residueManaAttr.Instance.Visible = true;
            //显示数据
            _objectBar.L_HBoxContainer.L_ObjectName.Instance.Text = o.Name;
            _objectBar.L_HBoxContainer.L_ObjectIcon.Instance.Visible = true;
            _objectBar.L_HBoxContainer.L_ObjectIcon.Instance.Texture = ResourceManager.LoadTexture2D(o.Icon);
            //弹药
            _currAmmonAttr.L_NumInput.Instance.MaxValue = weapon.AmmoCapacity;
            _currAmmonAttr.L_NumInput.Instance.Value = weapon.AmmoCapacity;
            _residueManaAttr.L_NumInput.Instance.MaxValue = weapon.MaxMana;
            _residueManaAttr.L_NumInput.Instance.Value = weapon.MaxMana;
        }
    }

    /// <summary>
    /// 设置关联的属性
    /// </summary>
    public void SetRelevancyAttr(MapEditorCreateMark.NumberBar currAmmonAttr, MapEditorCreateMark.NumberBar residueManaAttr)
    {
        _currAmmonAttr = currAmmonAttr;
        _residueManaAttr = residueManaAttr;
        currAmmonAttr.Instance.Visible = false;
        residueManaAttr.Instance.Visible = false;
    }
}