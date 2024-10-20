using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    }
    public static void AddListener()
    {

        EventManager.Instance.AddCubeEvent_on += Instance.AddCube;
        EventManager.Instance.AddCubeEvent_after += Instance.RefreshCameraSpace;

        EventManager.Instance.RemoveCubeEvent_on += Instance.RemoveCube;
        EventManager.Instance.RemoveCubeEvent_after += Instance.RefreshCameraSpace;

        EventManager.Instance.AddCube_ChangeDepthEvent_on += Instance.AddCube_ChangeDepth;
        EventManager.Instance.AddCube_ChangeDepthEvent_after += Instance.RefreshCameraSpace;

        EventManager.Instance.IsPassable += Instance.IsPassive;

    }

    public bool AddCube(Vector3Int position)
    {
        BaseCube cube = GameObject.Instantiate(prefab_cube).GetComponent<BaseCube>();
        cube.Position = position;
        return AddCube(cube);
    }
    public bool AddCube(BaseCube cube)
    {
        return worldSpaceManager.AddCube(cube);
    }
    public bool RemoveCube(Vector3Int position)
    {
        BaseCube cube = worldSpaceManager.FindByPosition(position);
        return RemoveCube(cube);
    }
    public bool RemoveCube(BaseCube cube)
    {
        return worldSpaceManager.RemoveCube(cube);
    }

    public bool AddCube_ChangeDepth(Vector3Int position , int direction)
    {
        BaseCube cube = GameObject.Instantiate(prefab_cube).GetComponent<BaseCube>();
        cube.Position = position;
        cube.gameObject.name = "Cube_";
        Debug.Log("AddCube_ChangeDepth : " + cube.Position);
        List<BaseCube> cubes = cameraSpaceManager.GetCubes(cube.GetCameraSpacePosition());
        BaseCube parentCube = cubes[direction];
        Debug.Log("parentCube : " + parentCube.gameObject.name + "position:" + parentCube.Position);
        cube.groupID = parentCube.groupID;
        direction = (direction + 1 ) % 6;
        if(AddCube(cube) == false)
        {
            Debug.LogWarning("Error Cube Exit in worldSpace");
            return false;
        }
        if(parentCube == null || parentCube != cubes[direction])
        {
            RemoveCube(cube);
            Debug.LogWarning("Error parentCube");
            return false;
        }
        if(cameraSpaceManager.IsCubeExposed(cube.GetCameraSpacePosition()) )
        {
            RemoveCube(cube);
            Debug.LogWarning("Error Cube Exit in cameraSpace");
            return false;
        }
        BaseCube connectedCube = null;
        for(int i = 0 ; i < 5; i++)
        {
            int nextDirection = (direction + 1) % 6;
            if(cubes[nextDirection] != null && cubes[direction] == cubes[nextDirection] && cubes[direction].groupID != parentCube.groupID)
            {
                connectedCube = cubes[nextDirection];
                break;
            }
            direction = nextDirection;
        }
        if(connectedCube == null)
        {
            // don't need to change depth
            return true;
        }
        else
        {
            Debug.Log("connectedCube : " + connectedCube.gameObject.name + "position:" + connectedCube.Position);
        }
        if(direction % 2 == 0)
        {
            if(connectedCube.Height > cube.Height)
                return true;
            Debug.Log("IncreaseDepth");
            worldSpaceManager.IncreaseDepth(connectedCube.groupID , cube.Height - connectedCube.Height + 1);
        }
        else
        {
            if(connectedCube.Height < cube.Height)
                return true;
            Debug.Log("DecreaseDepth");
            worldSpaceManager.DecreaseDepth(connectedCube.groupID , connectedCube.Height - cube.Height + 1);
        }
        worldSpaceManager.MergeGroup(connectedCube.groupID , cube.groupID);

        return true;
        // direction = (direction + 1 ) % 6;

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

    // public void RefreshGroup()
    // {
    //     foreach(BaseCube cube in worldSpaceManager.GetCubes())
    //     {
    //         cube.groupID = -1;
    //     }
    //     List<BaseCube> cube
    // }

    public int IsPassive(Vector2Int position)
    {
        return cameraSpaceManager.IsPassable(position);
    }

    // public void GetMovePosition(Vector3 position, Vector2Int direction, out Vector3 movePosition, out Vector3Int targetPosition)
    // {
    //     if(Math.Abs(direction.x) + Math.Abs(direction.y) != 1)
    //     {
    //         Debug.LogWarning("Error direction");
    //     }
    //     position -= Vector3.down;
    //     Vector2Int currentPosition = CameraManager.Instance.GetCameraSpacePosition(position);
    // }


}
