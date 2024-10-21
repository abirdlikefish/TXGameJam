using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // MapManager.Instance.AddCube(new Vector3Int(0,0,0));
        // MapManager.Instance.AddCube(new Vector3Int(1,0,0));
        // MapManager.Instance.AddCube(new Vector3Int(2,0,0));
        // MapManager.Instance.RefreshCameraSpace();
        MapManager.AddListener();
        EventManager.Instance.AddCube(new Vector3Int(0,0,0));
        int midAns = EventManager.Instance.IsPassable(CameraManager.Instance.GetCameraSpacePosition(new Vector3Int(1,0,0)));
        Debug.LogError(midAns);
        // EventManager.Instance.AddCube(new Vector3Int(1,0,0));
        // EventManager.Instance.AddCube(new Vector3Int(0,-2,-2));
        // EventManager.Instance.AddCube(new Vector3Int(0,0,0));
        // Debug.Log("GameManager Start");
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
