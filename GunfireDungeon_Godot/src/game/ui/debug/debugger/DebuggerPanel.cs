using Godot;

using DsUi;

namespace UI.debug.Debugger;

public partial class DebuggerPanel : Debugger
{
    /// <summary>
    /// 是否打开了Ui
    /// </summary>
    public bool ShowPanel = false;
    
    private bool _moveFalg = false;
    private GameSave _save;
    
    public override void OnCreateUi()
    {
        S_Bg.Instance.Visible = false;

        _save = GameApplication.Instance.GameSave;
        S_HoverButton.Instance.Position = new Vector2(_save.Debug.X, _save.Debug.Y);
        S_HoverButton.Instance.AddDragListener(OnDragHoverButton);
        
        S_Close.Instance.Pressed += OnClose;
        
        S_Tab.Instance.SetTabTitle(0, "日志");
        S_Tab.Instance.SetTabTitle(1, "工具");
    }

    public override void OnDestroyUi()
    {
        
    }

    public override void Process(float delta)
    {
        S_Fps.Instance.Text = "FPS:" + Mathf.RoundToInt(Engine.GetFramesPerSecond());
    }
    
    private void OnDragHoverButton(DragState state, Vector2 pos)
    {
        if (state == DragState.DragStart)
        {
            GameApplication.Instance.Cursor.AddBlockageMarking(GetInstanceId());
            _moveFalg = false;
        }
        else if (state == DragState.DragMove)
        {
            _moveFalg = true;
            var button = S_HoverButton.Instance;
            var position = button.Position;
            position += pos;

            if (Utils.IsRectContain(Vector2.Zero, GameApplication.Instance.GetWindow().Size, position, button.Size))
            {
                button.Position = position;
            }
        }
        else if (state == DragState.DragEnd)
        {
            if (_moveFalg)
            {
                var position = S_HoverButton.Instance.Position;
                _save.Debug.X = position.X;
                _save.Debug.Y = position.Y;
                _save.LateSave();
                GameApplication.Instance.Cursor.RemoveBlockageMarking(GetInstanceId());
            }
            else
            {
                OnClickHoverButton();
            }

            _moveFalg = false;
        }
    }
    
    private void OnClickHoverButton()
    {
        ShowPanel = true;
        S_Bg.Instance.Visible = ShowPanel;
        S_HoverButton.Instance.Visible = false;
    }

    /// <summary>
    /// 关闭面板
    /// </summary>
    public void OnClose()
    {
        if (!ShowPanel)
        {
            return;
        }
        ShowPanel = false;
        S_Bg.Instance.Visible = ShowPanel;
        S_HoverButton.Instance.Visible = true;
        GameApplication.Instance.Cursor.RemoveBlockageMarking(GetInstanceId());
    }
}
