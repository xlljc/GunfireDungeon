using Godot;

using DsUi;
using UI.editor.MapEditorObject;

namespace UI.editor.MapEditorTools;

public partial class CustomObject : Area2D, IUiNodeScript
{
    public RoomObjectInfo Info;
    public Node2D Node;
    
    private MapEditorObjectPanel _objectPanel;
    
    private MapEditorTools.ObjectTemplate _uiNode;
    private static Rect2 _rect = new Rect2(-GameConfig.TileCellSizeVector2I / 2, GameConfig.TileCellSizeVector2I);
    
    public void SetUiNode(IUiNode uiNode)
    {
        _uiNode = (MapEditorTools.ObjectTemplate) uiNode;
        _uiNode.L_RectBrush.Instance.Draw += OnDraw;
        _objectPanel = _uiNode.UiPanel.MapEditorPanel.S_MapEditorObject.Instance;
    }

    public void OnDestroy()
    {
        
    }
    
    public void Init(RoomObjectInfo info, Node2D node)
    {
        Info = info;
        Node = node;
        
        _uiNode.L_Bar.AddChild(node);
    }

    public override void _Process(double delta)
    {
        _uiNode.L_RectBrush.Instance.QueueRedraw();
    }

    private void OnDraw()
    {
        if (_objectPanel.IsActiveTab) //选中页签才能绘制
        {
            if (_objectPanel.ObjectGrid.SelectData == Info) //判断是否选中
            {
                _uiNode.L_RectBrush.Instance.DrawRect(_rect, Colors.Green, false, 1f);
            }
            else
            {
                _uiNode.L_RectBrush.Instance.DrawRect(_rect, Colors.White, false, 1f);
            }
        }
    }
}