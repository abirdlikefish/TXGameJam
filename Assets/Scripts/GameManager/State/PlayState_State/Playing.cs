using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playing : BasePlayState
{

    public override void Enter()
    {
        base.Enter();
        // MateManager.Instance.ShowMate();
        MateManager.Instance.OnEnterTinyLevel();
        UIManager.Instance.OnEnterTinyLevel();
        // UIManager.Instance.ShowPlayingUI();
        // DouguManager.Instance.Begin();
        DouguManager.Instance.OnEnterTinyLevel();

    }

    public override void Exit()
    {
        base.Exit();
        UIManager.Instance.OnExitTinyLevel();
        MateManager.Instance.OnExitTinyLevel();
        // UIManager.Instance.ClosePlayingUI();
        // MateManager.Instance.HideMate();
        DouguManager.Instance.OnExitTinyLevel();
    }

}
