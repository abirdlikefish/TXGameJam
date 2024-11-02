using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GameStateMachine gameStateMachine;
    private void Awake()
    {
        InitTotal();
        Debug.Log("GameManager Awake");
    }
    void Update()
    {
        // gameStateMachine.Update();
        GameStateMachine.Instance.Update();

        // if(Input.GetKeyDown(KeyCode.LeftControl))
        // {
        //     MapManager.Instance.RemoveCube(new Vector3Int(2,2,1));
        // }
    }
    void InitTotal()
    {
        // UIMateEditor.Instance.Init();
        UIManager.Instance.Init();
        // UIMainMenu.Instance.Init();
    }
}
