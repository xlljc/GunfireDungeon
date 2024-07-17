using System;
using Godot;

namespace UI.Victory;

public partial class VictoryPanel : Victory
{
    public Action Callback;
    
    public override void OnCreateUi()
    {
        S_Button.Instance.Pressed += () =>
        {
            if (Callback != null)
            {
                Destroy();
                Callback();
            }
        };
    }

    public override void OnDestroyUi()
    {
        
    }

}
