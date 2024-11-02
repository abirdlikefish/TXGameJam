using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playing : BasePlayState
{

    public override void Enter()
    {
        base.Enter();
        MateManager.Instance.ShowMate();
        UIManager.Instance.ShowPlayingUI();
        DouguManager.Instance.Begin();
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.Instance.ClosePlayingUI();
        MateManager.Instance.HideMate();
        DouguManager.Instance.End();
    }

}
