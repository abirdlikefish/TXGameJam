using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState : BaseState
{
    public override void Enter()
    {
        Debug.Log("MainState Enter");
        base.Enter();
        EventManager.Instance.ExitStateEvent += Exit;
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.Instance.ExitState(0);
        }
    }

    public override void Exit(int num)
    {
        base.Exit(num);
        EventManager.Instance.ExitStateEvent -= Exit;
        if(num == 0)
        {
            // gameStateMachine.ChangeState(gameStateMachine.selectLevelState);
            gameStateMachine.ChangeState(gameStateMachine.inputNameState);
        }
        else
        {
            Debug.LogWarning("MainState Exit Error");
        }
    }
}
