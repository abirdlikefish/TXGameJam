using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState 
{
    static protected GameStateMachine gameStateMachine;
    public virtual void Init(GameStateMachine gameStateMachine)
    {
        if(BaseState.gameStateMachine == null)
            BaseState.gameStateMachine = gameStateMachine;
    }
    public virtual void Enter()
    {

    }
    public virtual void Update()
    {

    }
    // public virtual void Exit(int num)
    public virtual void Exit()
    {

    }
}
