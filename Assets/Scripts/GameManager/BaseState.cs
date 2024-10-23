using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState 
{
    static protected GameStateMachine gameStateMachine;
    static public void Init(GameStateMachine gameStateMachine)
    {
        BaseState.gameStateMachine = gameStateMachine;
    }
    public virtual void Enter()
    {

    }
    public virtual void Update()
    {

    }
    public virtual void Exit()
    {

    }
}
