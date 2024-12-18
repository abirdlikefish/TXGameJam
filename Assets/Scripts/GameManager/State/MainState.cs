using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState : BaseState
{
    public override void Enter()
    {
        Debug.Log("MainState Enter");
        base.Enter();
        EventManager.Instance.ShowMainMenu();
        UIManager.Instance.OnEnterMain();
// SaveManager.Instance.LoadLevelData();
// Debug.Log("Load LevelData");
// return;
        SaveManager.Instance.LoadMap(0);
    }

    public override void Update()
    {
        base.Update();
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    EventManager.Instance.ExitState(0);
        //}
    }

    // public override void Exit(int num)
    public override void Exit()
    {
        UIManager.Instance.OnExitMain();
        // UIManager.Instance.CloseMainMenu();
        MapManager.Instance.RemoveCube_all();
        // EventManager.Instance.HideHeadLineMap();
        Debug.Log("MainState Exit");
        base.Exit();
    }
}
