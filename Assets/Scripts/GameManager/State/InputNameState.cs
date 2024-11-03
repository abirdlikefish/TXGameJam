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
        MateManager.Instance.OnEnterEditName();
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
        UIManager.Instance.OnExitEditName();
        // MateManager.Instance.OnExitEditName();
        
    }
}