using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelState : BaseState
{
    public override void Enter()
    {
        Debug.Log("SelectLevelState Enter");
        base.Enter();
        EventManager.Instance.ExitStateEvent += Exit;
        // EventManager.Instance.ShowInputNameUI();
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.Instance.ExitState(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            EventManager.Instance.ExitState(1);
        }
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
            gameStateMachine.ChangeState(gameStateMachine.inputNameState);
        }
        else
        {
            Debug.LogWarning("SelectLevelState Exit Error");
        }
    }
}