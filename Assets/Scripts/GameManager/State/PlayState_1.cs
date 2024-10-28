using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState_1 : BaseState
{
    int levelIndex;
    public bool isPlaying = false ;
    // public override void Enter()
    public void OtherEnter(int levelIndex)
    {
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
    float maxCD = 7;
    float lastTime;
    public override void Update()
    {
        if(isFirstUpdate)
        {
            isFirstUpdate = false;
            EventManager.Instance.EnterTinyLevel_bef(levelIndex);
            Debug.Log("PlayState Update");
        }
        // EventManager.Instance.EnterTinyLevel(1);
        base.Update();

        if(isPlaying)
        {
            if(Time.time - lastTime > maxCD)
            {
                lastTime = Time.time;
                EventManager.Instance.GenerateRandomDouguSphere();
                // Debug.Log("GenerateDouguSphere");
            }
        }
    }

    public override void Exit(int num)
    {
        isPlaying = false;
        base.Exit(num);
        if(num == 0)
        {
            // CameraManager.Instance.ChangeCameraDirection(levelIndex);
            EventManager.Instance.EnterTinyLevel_bef(levelIndex);
        }
        else if(num == 1)
        {
            Debug.Log("PlayState Exit");
            EventManager.Instance.ExitStateEvent -= Exit;
            gameStateMachine.ChangeState(gameStateMachine.mainState);
        }
        else
        {
            Debug.LogWarning("PlayState Exit Error");
        }

        // if(roundNum == 0)
        // {
        //     EventManager.Instance.ExitStateEvent -= Exit;
        //     EventManager.Instance.ExitLevel(1);
        //     gameStateMachine.ChangeState(gameStateMachine.selectLevelState);
        // }
        // else
        // {
        //     EventManager.Instance.EnterTinyLevel(1);
        // }
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