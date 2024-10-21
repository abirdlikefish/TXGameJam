using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<IOnGameAwakeInit> OnGameAwakes;
    private void Awake()
    {
        // MapManager.Instance.AddCube(new Vector3Int(0,0,0));
        // MapManager.Instance.AddCube(new Vector3Int(1,0,0));
        // MapManager.Instance.AddCube(new Vector3Int(2,0,0));
        // MapManager.Instance.RefreshCameraSpace();
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
    }
}
