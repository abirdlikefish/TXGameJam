using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // List<IOnGameAwakeInit> OnGameAwakes;
    // List<IOnLevelEnterInit> OnLevelEnters;

    private void Awake()
    {
        MapManager.AddListener();

        // OnGameAwakes = new()
        // {
        //     MateManager.Instance,
        //     UIManager.Instance,
            
        // };
        OnGameAwake();
        // OnLevelEnters = new()
        // {
        //     DouguManager.Instance,
        //     LevelManager.Instance,
        //     //MapSaver.Instance,
        // };
        OnLevelEnter();
    }
    
    void OnGameAwake()
    {
        // foreach (var it in OnGameAwakes)
        // {
        //     it.InitializeOnGameAwake();
        // }
        
            MateManager.Instance,
            UIManager.Instance,

    }
    public void OnLevelEnter()
    {
            DouguManager.Instance,
            LevelManager.Instance,
            DouguManager.Instance,
            LevelManager.Instance,
            //MapSaver.Instance,
        // foreach (var it in OnLevelEnters)
        // {
        //     it.InitializeOnLevelEnter();
        // }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
                SaveManager.Instance.LoadLevelData();
                foreach (Vector3Int cube in SaveManager.Instance.GetCubeList(0))
                {
                    EventManager.Instance.AddCube(cube);
                }

        }
    }
}
