
using System.Collections.Generic;
using DsUi;
using Godot;
using UI.editor.MapEditor;
using UI.editor.MapEditor;
using UI.editor.MapEditorObject;
using UI.editor.MapEditorTools;

public class EditorObjectTool : EditorToolBase
{
    private bool _isPressed;
    private int _flag = 0;
    //private Vector2 _offset;
    
    private UiGrid<MapEditorObject.Item, RoomObjectInfo> _objectGrid;
    private Dictionary<RoomObjectInfo, MapEditorToolsPanel.CustonObjectData> _customObjecMapping;

    
    public EditorObjectTool(EditorTileMap editorTileMap) : base(
        ResourcePath.resource_sprite_ui_commonIcon_DoorTool_png, "编辑物体", true, editorTileMap, EditorToolEnum.ObjectTool)
    {
    }

    public override void OnSetSelected(bool selected)
    {
        _objectGrid = EditorTileMap.MapEditorPanel.S_MapEditorObject.Instance.ObjectGrid;
        _customObjecMapping = EditorTileMap.MapEditorToolsPanel.CustomObjecMapping;
    }

    public override void OnMapInputEvent(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton)
        {
            if (mouseButton.ButtonIndex == MouseButton.Left)
            {
                _isPressed = mouseButton.Pressed;
                if (_isPressed)
                {
                    DoSelectObject();
                }
                else
                {
                    _flag = 0;
                }
            }
        }
        else if (_isPressed && _flag > 0 && _objectGrid.SelectData != null && @event is InputEventMouseMotion)
        {
            DoMoveObject();
        }
    }

    private void DoSelectObject()
    {
        var result = DoCollision();
        if (result != null)
        {
            if (_objectGrid.SelectData != result.Info)
            {
                //_offset = result.Position - EditorTileMap.GetLocalMousePosition();
                EventManager.EmitEvent(EventEnum.OnSelectObject, result.Info);
            }
            else
            {
                _flag++;
            }
        }
        else
        {
            _flag = 0;
        }
    }

    private void DoMoveObject()
    {
        if (_objectGrid.SelectData != null && _customObjecMapping.TryGetValue(_objectGrid.SelectData, out var objectData))
        {
            var position = EditorTileMap.GetLocalMousePosition();// - _offset;
            var nodeInstance = objectData.Node.Instance;
            nodeInstance.Position = position;
            nodeInstance.Info.X = (int)position.X;
            nodeInstance.Info.Y = (int)position.Y;
            
            EventManager.EmitEvent(EventEnum.OnTileMapDirty);
        }
    }

    private CustomObject DoCollision()
    {
        var param = new PhysicsPointQueryParameters2D();
        param.Position = EditorTileMap.GetGlobalMousePosition();
        param.CollisionMask = PhysicsLayer.UiMouse;
        param.CollideWithAreas = true;
        var result = EditorTileMap.GetWorld2D().DirectSpaceState.IntersectPoint(param);

        if (result.Count > 0)
        {
            foreach (var dictionary in result)
            {
                if (dictionary.TryGetValue("collider", out var collider))
                {
                    if ((Node2D)collider is CustomObject customObject)
                    {
                        return customObject;
                    }
                }
            }
        }

        return null;
    }
}