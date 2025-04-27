using DsUi;

namespace UI.game.Victory;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Victory : UiBase
{
    /// <summary>
    /// 节点路径: Victory.Label
    /// </summary>
    public Label L_Label
    {
        get
        {
            if (_L_Label == null) _L_Label = new Label((VictoryPanel)this, GetNode<Godot.Label>("Label"));
            return _L_Label;
        }
    }
    private Label _L_Label;

    /// <summary>
    /// 节点路径: Victory.Button
    /// </summary>
    public Button L_Button
    {
        get
        {
            if (_L_Button == null) _L_Button = new Button((VictoryPanel)this, GetNode<Godot.Button>("Button"));
            return _L_Button;
        }
    }
    private Button _L_Button;


    public Victory() : base(UiManager.UiName.Game_Victory)
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 路径: Victory.Label
    /// </summary>
    public class Label : UiNode<VictoryPanel, Godot.Label, Label>
    {
        public Label(VictoryPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 路径: Victory.Button
    /// </summary>
    public class Button : UiNode<VictoryPanel, Godot.Button, Button>
    {
        public Button(VictoryPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override Button Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Victory.Label
    /// </summary>
    public Label S_Label => L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点路径: Victory.Button
    /// </summary>
    public Button S_Button => L_Button;

}
