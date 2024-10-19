using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager
{
    static MapManager instance;
    public static MapManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new MapManager();
                instance.Init();
            }
            return instance;
        }
    }
    GameObject prefab_cube;
    ICameraSpaceManager cameraSpaceManager;
    IWorldSpaceManager worldSpaceManager;
    public void Init()
    {
        cameraSpaceManager = CameraSpaceManager.Init(this);
        worldSpaceManager = WorldSpaceManager.Init(this);
        prefab_cube = Resources.Load<GameObject>("Prefabs/Cube");

        EventManager.Instance.AddCubeEvent_on += AddCube;
        EventManager.Instance.AddCubeEvent_after += RefreshCameraSpace;

        EventManager.Instance.RemoveCubeEvent_on += RemoveCube;
        EventManager.Instance.RemoveCubeEvent_after += RefreshCameraSpace;
    }

    public bool AddCube(Vector3Int position)
    {
        GameObject go = GameObject.Instantiate(prefab_cube);
        go.transform.position = position;
        return worldSpaceManager.AddCube(go.GetComponent<BaseCube>());
    }
    public bool RemoveCube(Vector3Int position)
    {
        BaseCube cube = worldSpaceManager.FindByPosition(position);
        if(cube != null)
        {
            worldSpaceManager.GetCubes().Remove(cube);
            GameObject.Destroy(cube.gameObject);
            return true;
        }
        else
        {
            Debug.LogWarning("Cube is null");
            return false;
        }
    }

    public void RefreshCameraSpace(bool isSucceed)
    {
        if(isSucceed == false)
        {
            Debug.LogWarning("AddCube failed");
            return;
        }
        cameraSpaceManager.ClearNodeMap();
        foreach(BaseCube cube in worldSpaceManager.GetCubes())
        {
            cameraSpaceManager.DrawGrid(cube);
        }
    }


}
