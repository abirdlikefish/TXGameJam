using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState_1 : BaseState
{
    int roundNum = 3;
    public override void Enter()
    {
        roundNum = 3;
        Debug.Log("PlayState Enter");
        base.Enter();
        EventManager.Instance.ExitStateEvent += Exit;
        // EventManager.Instance.ExitTinyLevelEvent += TinyLevelEnd;
        EventManager.Instance.EnterLevel(1);
        EventManager.Instance.EnterTinyLevel(1);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit(int num)
    {
        base.Exit(num);
        
        roundNum--;
        if(roundNum == 0)
        {
            EventManager.Instance.ExitStateEvent -= Exit;
            EventManager.Instance.ExitLevel(1);
            gameStateMachine.ChangeState(gameStateMachine.selectLevelState);
        }
        else
        {
            EventManager.Instance.EnterTinyLevel(1);
        }
    }
    public void TinyLevelEnd()
    {
        // roundNum--;
        // if(roundNum == 0)
        // {
        //     EventManager.Instance.ExitStateEvent -= Exit;
        //     EventManager.Instance.ExitLevel(1);
        //     gameStateMachine.ChangeState(gameStateMachine.selectLevelState);
        // }
        // else
        // {
        //     EventManager.Instance.EnterTinyLevel();
        // }
    }
}