using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    List<IOnGameAwakeInit> OnGameAwakes;
    List<IOnLevelEnterInit> OnLevelEnters;
    private void Awake()
    {

        // Debug.Log("GameManager Start");
        OnGameAwakes = new()
        {
            MateManager.Instance,
            UIManager.Instance,
            DouguManager.Instance,
            MapSaver.Instance,
        };
        OnGameAwake();
        OnLevelEnters = new()
        {
            UIManager.Instance,
            MateManager.Instance.curMates[0],
            MateManager.Instance.curMates[1],
            DouguManager.Instance,
        };
        OnLevelEnter();
        MapManager.AddListener();
        

        EventManager.Instance.AddCube(new Vector3Int(0, 0, 0));
        EventManager.Instance.AddCube(new Vector3Int(1, 0, 0));
        EventManager.Instance.AddCube(new Vector3Int(2, 0, 0));
        EventManager.Instance.AddCube(new Vector3Int(0, 0, 1));
        EventManager.Instance.AddCube(new Vector3Int(1, 0, 1));
        EventManager.Instance.AddCube(new Vector3Int(2, 0, 1));



    }
    
    void OnGameAwake()
    {
        foreach (var it in OnGameAwakes)
        {
            it.InitializeOnGameAwake();
        }

    }
    public void OnLevelEnter()
    {
        foreach (var it in OnLevelEnters)
        {
            it.InitializeOnLevelEnter();
        }
    }
    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Alpha0))
        //     EventManager.Instance.AddCube_ChangeDepth(new Vector3Int(0 , 0 , 0) , new Vector3Int(1,0,0));
            // EventManager.Instance.AddCube(new Vector3Int(1,0,0));
            // EventManager.Instance.RemoveCube(new Vector3Int(0,-1,-1));
        //     EventManager.Instance.AddCube_ChangeDepth(new Vector3Int(1,0,0), 1);
        // if(Input.GetKeyDown(KeyCode.Alpha1))
        //     EventManager.Instance.AddCube_ChangeDepth(new Vector3Int(1,1,0), 0);
    }
}
