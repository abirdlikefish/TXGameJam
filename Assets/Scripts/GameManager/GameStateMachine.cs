using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine 
{
    public MainState mainState;
    public InputNameState inputNameState;
    public SelectLevelState selectLevelState;
    public PlayState playState;
    private BaseState currentState;

    public void Init()
    {
        BaseState.Init(this);
        mainState = new MainState();
        inputNameState = new InputNameState();
        selectLevelState = new SelectLevelState();
        playState = new PlayState();

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