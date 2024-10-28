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
        DeliConfig.Instance.Init();
        MateManager.Instance.Init();
        DouguManager.Instance.Init();
        UIMateEditor.Instance.Init();
        UIInGame.Instance.Init();   
        // MapSaver.Instance.Init();
        UIMainMenu.Instance.Init();
    }
}
