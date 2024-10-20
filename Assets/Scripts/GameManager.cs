using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<IInit> inits;
    private void Awake()
    {
        inits = new()
        {
            MateInput.Instance,
        };
        // MapManager.Instance.AddCube(new Vector3Int(0,0,0));
        // MapManager.Instance.AddCube(new Vector3Int(1,0,0));
        // MapManager.Instance.AddCube(new Vector3Int(2,0,0));
        // MapManager.Instance.RefreshCameraSpace();
        // Debug.Log("GameManager Start");
    
        foreach (var item in inits)
        {
            item.Initialize();
        }
    }
}
