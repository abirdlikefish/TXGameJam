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

    public void ChangeState(BaseState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

}