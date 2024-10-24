using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : BaseState
{
    public override void Enter()
    {
        Debug.Log("PlayState Enter");
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
    }
}