using Godot;

namespace DsUi;

public partial class InitUiManager : Node
{
    public override void _EnterTree()
    {
        //初始化Ui管理器
        UiManager.Init(GetParent());
    }
}