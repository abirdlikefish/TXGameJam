using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNameState : BaseState
{
    public override void Enter()
    {
        Debug.Log("InputNameState Enter");
        base.Enter();
        // EventManager.Instance.ExitStateEvent += Exit;
        // UIManager.Instance.ShowInputNameUI();
        UIManager.Instance.OnEnterEditName();

        // EventManager.Instance.ShowInputNameUI();
    }

    public override void Update()
    {
        base.Update();
    }

    // public override void Exit(int num)
    public override void Exit()
    {
        // base.Exit(num);
        base.Exit();
        // EventManager.Instance.HideInputNameUI();
        UIManager.Instance.OnExitEditName();
        // EventManager.Instance.ExitStateEvent -= Exit;
        // if(num == 0)
        // {
        //     gameStateMachine.ChangeState(gameStateMachine.mainState);
        // }
        // else if(num == 1)
        // {
        //     gameStateMachine.ChangeState(gameStateMachine.selectLevelState);
        // }
        // else
        // {
        //     Debug.LogWarning("InputNameState Exit Error");
        // }
        
    }
}