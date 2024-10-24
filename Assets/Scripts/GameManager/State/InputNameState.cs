using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNameState : BaseState
{
    public override void Enter()
    {
        Debug.Log("InputNameState Enter");
        base.Enter();
        EventManager.Instance.ExitStateEvent += Exit;
        
        EventManager.Instance.ShowInputNameUI();
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
            gameStateMachine.ChangeState(gameStateMachine.mainState);
        }
        else if(num == 1)
        {
            gameStateMachine.ChangeState(gameStateMachine.playState);
        }
        else
        {
            Debug.LogWarning("InputNameState Exit Error");
        }
        
    }
}