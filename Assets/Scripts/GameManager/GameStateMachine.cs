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

}