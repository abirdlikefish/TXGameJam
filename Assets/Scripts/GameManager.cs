using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<IOnGameAwakeInit> OnGameAwakes;
    private void Awake()
    {

        // Debug.Log("GameManager Start");
        OnGameAwakes = new()
        {
            MateManager.Instance,
            UIManager.Instance,
        };
        foreach (var it in OnGameAwakes)
        {
            it.InitializeOnGameAwake();
        }
        MapManager.AddListener();
        EventManager.Instance.AddCube(new Vector3Int(0,0,0));
        EventManager.Instance.AddCube(new Vector3Int(0,-2,-2));
        // EventManager.Instance.AddCube(new Vector3Int(0,0,0));
        // Debug.Log("GameManager Start");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
            EventManager.Instance.AddCube_ChangeDepth(new Vector3Int(0 , 0 , 0) , new Vector3Int(1,0,0));
            // EventManager.Instance.AddCube(new Vector3Int(1,0,0));
            // EventManager.Instance.RemoveCube(new Vector3Int(0,-1,-1));
        //     EventManager.Instance.AddCube_ChangeDepth(new Vector3Int(1,0,0), 1);
        // if(Input.GetKeyDown(KeyCode.Alpha1))
        //     EventManager.Instance.AddCube_ChangeDepth(new Vector3Int(1,1,0), 0);
    }
}
