using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameStateMachine : IGameStateMachine
{
    private static GameStateMachine instance;
    public static IGameStateMachine Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameStateMachine();
                instance.Init();
            }
            return instance;
        }
    }
    private MainState mainState;
    private InputNameState inputNameState;
    private LevelSelectState levelSelectState;
    private PlayState playState;
    private BaseState currentState;

    private int levelIndex;
    public int LevelIndex {get => levelIndex ; set => levelIndex = value;}

    Mate victoryMate;
    // public Mate VictoryMate { get => victoryMate; set => victoryMate = value; }
    public Mate VictoryMate 
    { 
        get => victoryMate; 
        set
        {
            if(currentState is PlayState)
            {
                ((PlayState)currentState).VictoryMate = value;
            }
            else
            {
                Debug.LogError("GameStateMachine VictoryMate Error , not in playState");
            }
            victoryMate = value;
        }
    }

    void IGameStateMachine.ContinuePlay()
    {
        if(currentState is PlayState)
        {
            ((PlayState)currentState).ContinuePlay();
        }
        else
        {
            Debug.LogError("GameStateMachine ContinuePlay Error , not in playState");
        }
    }

    private void Init()
    {
        mainState = new MainState();
        inputNameState = new InputNameState();
        levelSelectState = new LevelSelectState();
        playState = new PlayState();

        mainState.Init(this);
        inputNameState.Init(this);
        levelSelectState.Init(this);
        playState.Init(this);
        ChangeState(mainState);
    }

    public void ChangeState(BaseState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    void IGameStateMachine.Update()
    {
        currentState.Update();
    }

    void IGameStateMachine.ChangeStateToMainState()
    {
        ChangeState(mainState);
    }
    void IGameStateMachine.ChangeStateToInputNameState()
    {
        ChangeState(inputNameState);
    }
    void IGameStateMachine.ChangeStateToLevelSelectState()
    {
        ChangeState(levelSelectState);
    }
    void IGameStateMachine.ChangeStateToPlayState()
    {
        ChangeState(playState);
    }
    

}