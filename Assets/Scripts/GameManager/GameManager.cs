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

    }
    
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
