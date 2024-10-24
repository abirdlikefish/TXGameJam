using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState : BaseState
{
    public override void Enter()
    {
        base.Enter();
        EventManager.Instance.ExitStateEvent += Exit;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit(int num)
    {
        base.Exit(num);
        EventManager.Instance.ExitStateEvent -= Exit;
        if(num == 0)
        {
            gameStateMachine.ChangeState(gameStateMachine.selectLevelState);
        }
        else
        {
            Debug.LogWarning("MainState Exit Error");
        }
    }
}
