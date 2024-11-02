using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameStateMachine gameStateMachine;
    private void Awake()
    {
        InitTotal();
        MapManager.AddListener();
        ColorReactionManager.AddListener();
        SaveManager.AddListener();
        SelectMatePosition.AddListener();
        // GameStateMachine.AddListener();
        gameStateMachine = new GameStateMachine();
        gameStateMachine.Init();
        Debug.Log("GameManager Awake");
    }
    void Update()
    {
        gameStateMachine.Update();

        // if(Input.GetKeyDown(KeyCode.LeftControl))
        // {
        //     EventManager.Instance.RemoveCube(new Vector3Int(2,2,1));
        // }
    }
    void InitTotal()
    {
        UIMateEditor.Instance.Init();
        UIManager.Instance.Init();   
        UIMainMenu.Instance.Init();
    }
}
