using Godot;

namespace AiState;

/// <summary>
/// 发现目标时的惊讶状态
/// </summary>
public class AiAstonishedState : StateBase<AiRole, AIStateEnum>
{
    /// <summary>
    /// 用于判断是否进入过惊讶状态
    /// </summary>
    public bool IsEntred = false;
    
    private float _timer;
    private object[] _args;
    
    public AiAstonishedState() : base(AIStateEnum.AiAstonished)
    {
    }

    public override void Enter(AIStateEnum prev, params object[] args)
    {
        if (args.Length == 0)
        {
            Debug.Log("进入 AINormalStateEnum.AiAstonished 状态必传入下一个状态做完参数!");
            ChangeState(prev);
            return;
        }

        if (IsEntred || !Master.AnimationPlayer.HasAnimation(AnimatorNames.Astonished))
        {
            ChangeNextState(args);
            return;
        }

        IsEntred = true;
        _args = args;

        _timer = 0.6f;

        //播放惊讶表情
        Master.AnimationPlayer.Play(AnimatorNames.Astonished);
    }

    public override void Process(float delta)
    {
        Master.DoIdle();
        _timer -= delta;
        if (_timer <= 0)
        {
            ChangeNextState(_args);
        }
    }

    private void ChangeNextState(object[] args)
    {
        if (args.Length == 1)
        {
            ChangeState((AIStateEnum)args[0]);
        }
        else if (args.Length == 2)
        {
            ChangeState((AIStateEnum)args[0], args[1]);
        }
    }
}