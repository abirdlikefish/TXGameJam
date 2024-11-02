using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : BasePlayState
{
    
    public override void Enter()
    {
        base.Enter();
        UIManager.Instance.OnEnterWinning(playState.VictoryMate);

    }

    public override void Exit()
    {
        base.Exit();
        UIManager.Instance.OnExitWinning();
    }
}
