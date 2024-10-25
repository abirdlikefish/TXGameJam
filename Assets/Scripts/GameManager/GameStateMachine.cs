using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine 
{
    public MainState mainState;
    public InputNameState inputNameState;
    public SelectLevelState selectLevelState;
    public PlayState_1 playState_1;
    private BaseState currentState;

    public void Init()
    {
        BaseState.Init(this);
        mainState = new MainState();
        inputNameState = new InputNameState();
        selectLevelState = new SelectLevelState();
        playState_1 = new PlayState_1();

        EventManager.Instance.EnterLevelEvent += playState_1.OtherEnter;
        EventManager.Instance.EnterTinyLevelEvent += (x) => playState_1.isPlaying = true ;
        selectLevelState.Init();

        // mainState
        ChangeState(mainState);
        // ChangeState(mainState);
    }

    public void ChangeState(BaseState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        currentState.Update();
    }

    // static GameStateMachine instance;
    // public static GameStateMachine Instance
    // {
    //     get
    //     {
    //         if(instance == null)
    //         {
    //             instance = new GameStateMachine();
    //         }
    //         return instance;
    //     }
    // }

    // public static void AddListener()
    // {
    //     EventManager.Instance.EnterLevelEvent += Instance.playState_1.OtherEnter;
    // }

}