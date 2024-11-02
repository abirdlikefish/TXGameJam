using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : BaseState
{

    BasePlayState currentState;
    public BasePlayState selectPosition;
    public BasePlayState playing;
    public BasePlayState end;

    public override void Init(GameStateMachine gameStateMachine)
    {
        base.Init(gameStateMachine);
        selectPosition = new SelectPosition();
        selectPosition.Init(this);
        playing = new Playing();
        playing.Init(this);
        end = new End();
        end.Init(this);
        ColorReactionManager.Instance.CleanColorReaction();
    }

    public override void Enter()
    {
        Debug.Log("PlayState_1 Enter");
        base.Enter();
        SaveManager.Instance.LoadMap(gameStateMachine.LevelIndex);
        DouguManager.Instance.OnEnterLevel();
        MateManager.Instance.OnEnterLevel();
        UIManager.Instance.OnEnterLevel();
        ChangePlayState(selectPosition);
    }

    public void ChangePlayState(BasePlayState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public override void Update()
    {
        base.Update();
        currentState.Update();
    }

    public override void Exit()
    {
        MateManager.Instance.OnExitLevel();
        MapManager.Instance.RemoveCube_all();
        // UIManager.Instance.ClosePlayUI();
        UIManager.Instance.OnExitLevel();
        // DouguManager.Instance.CleanAll();
        DouguManager.Instance.OnExitLevel();
        ColorReactionManager.Instance.CleanColorReaction();
        currentState.Exit();
        base.Exit();
    }

    private Mate victoryMate;
    public Mate VictoryMate
    {
        get => victoryMate;
        set
        {
            if (currentState is Playing)
            {
                ChangePlayState(end);
            }
            else
            {
                Debug.LogError("PlayState VictoryMate Error , not in playing");
            }
            victoryMate = value;
        }
    }

    public void ContinuePlay()
    {
        if (currentState is End)
        {
            ChangePlayState(selectPosition);
        }
        else
        {
            Debug.LogError("PlayState ContinuePlay Error , not in end");
        }
    }




















    // // int levelIndex;
    // // public bool isPlaying = false ;
    // // public override void Enter()
    // public void OtherEnter(int levelIndex)
    // {
    //     this.levelIndex = levelIndex;
    //     Debug.Log("PlayState Enter");
    //     // base.Enter();
    //     EventManager.Instance.ExitStateEvent += Exit;
    //     EventManager.Instance.ExitTinyLevelEvent += TinyLevelEnd;
    //     // EventManager.Instance.EnterLevel(1);
    //     isFirstUpdate = true;
    //     gameStateMachine.ChangeState(gameStateMachine.playState_1);

    // }
    // bool isFirstUpdate;
    // float lastTime;
    // // public override void Update()
    // {
    //     if(isFirstUpdate)
    //     {
    //         isFirstUpdate = false;
    //         EventManager.Instance.EnterTinyLevel_bef(levelIndex);
    //         Debug.Log("PlayState Update");
    //     }
    //     // EventManager.Instance.EnterTinyLevel(1);
    //     base.Update();

    //     if(isPlaying)
    //     {
    //         if(Time.time - lastTime > DeliConfig.Instance.dougeSphereInsCD)
    //         {
    //             lastTime = Time.time;
    //             EventManager.Instance.GenerateRandomDouguSphere();
    //             // Debug.Log("GenerateDouguSphere");
    //         }
    //     }
    // }

    // // public override void Exit(int num)
    // {
    //     isPlaying = false;
    //     base.Exit(num);
    //     if(num == 0)
    //     {
    //         // CameraManager.Instance.ChangeCameraDirection(levelIndex);
    //         EventManager.Instance.EnterTinyLevel_bef(levelIndex);
    //     }
    //     else if(num == 1)
    //     {
    //         Debug.Log("PlayState Exit");
    //         EventManager.Instance.ExitStateEvent -= Exit;
    //         gameStateMachine.ChangeState(gameStateMachine.mainState);
    //     }
    //     else
    //     {
    //         Debug.LogWarning("PlayState Exit Error");
    //     }

    //     // if(roundNum == 0)
    //     // {
    //     //     EventManager.Instance.ExitStateEvent -= Exit;
    //     //     EventManager.Instance.ExitLevel(1);
    //     //     gameStateMachine.ChangeState(gameStateMachine.selectLevelState);
    //     // }
    //     // else
    //     // {
    //     //     EventManager.Instance.EnterTinyLevel(1);
    //     // }
    // }
    // public void TinyLevelEnd()
    // {
    //     // roundNum--;
    //     // if(roundNum == 0)
    //     // {
    //     //     EventManager.Instance.ExitStateEvent -= Exit;
    //     //     EventManager.Instance.ExitLevel(1);
    //     //     gameStateMachine.ChangeState(gameStateMachine.selectLevelState);
    //     // }
    //     // else
    //     // {
    //     //     EventManager.Instance.EnterTinyLevel();
    //     // }
    // }
}