using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState_1 : BaseState
{
    int roundNum = 3;
    int levelIndex;
    
    // public override void Enter()
    public void OtherEnter(int levelIndex)
    {
        roundNum = 3;
        this.levelIndex = levelIndex;
        Debug.Log("PlayState Enter");
        // base.Enter();
        EventManager.Instance.ExitStateEvent += Exit;
        EventManager.Instance.ExitTinyLevelEvent += TinyLevelEnd;
        // EventManager.Instance.EnterLevel(1);
        isFirstUpdate = true;
        gameStateMachine.ChangeState(gameStateMachine.playState_1);
    }
    bool isFirstUpdate;
    public override void Update()
    {
        if(isFirstUpdate)
        {
            isFirstUpdate = false;
            EventManager.Instance.EnterTinyLevel(levelIndex);
            Debug.Log("PlayState Update");
        }
        // EventManager.Instance.EnterTinyLevel(1);
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