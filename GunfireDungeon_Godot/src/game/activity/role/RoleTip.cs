using Godot;
using System;
using System.Collections.Generic;
using Config;

public partial class RoleTip : Node2D
{
    /// <summary>
    /// 使用的状态模板
    /// </summary>
    [Export] public PackedScene TipStateScene;

    /// <summary>
    /// 所属角色对象
    /// </summary>
    public Role Role { get; set; }

    private List<TipState> _useStateDir = new List<TipState>();


    public TipState CreateTipState(ExcelConfig.AbnormalStateConfig config)
    {
        var tipState = TipStateScene.Instantiate<TipState>();
        tipState.Init(this, config);
        _useStateDir.Add(tipState);
        AddChild(tipState);
        return tipState;
    }

    public void RefreshTipSpritePosition()
    {
        var originPosition = new Vector2(0, -Role.RoleState.RoleBase.Height - 16);

        //刷新位置，居中排列，每个 TipState 宽度 12， 间距 2
        var width = 12 * _useStateDir.Count + 2 * (_useStateDir.Count - 1);
        for (var i = 0; i < _useStateDir.Count; i++)
        {
            var item = _useStateDir[i];
            item.Position = originPosition + new Vector2(i * 14 - width / 2f, 0);
        }

        //tipState.Position = originPosition;
    }
}
