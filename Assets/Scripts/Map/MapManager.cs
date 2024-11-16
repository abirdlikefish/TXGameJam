using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapManager : IMapManager
{
    static MapManager _instance;
    public static IMapManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new MapManager();
                _instance.Init();
            }
            return _instance;
        }
    }
    // GameObject prefab_cube;
    ICameraSpaceManager cameraSpaceManager;
    IWorldSpaceManager worldSpaceManager;
    // public CameraSpaceManager MyCameraSpaceManager => (CameraSpaceManager)cameraSpaceManager;
    // public void Init()
    private void Init()
    {
        cameraSpaceManager = CameraSpaceManager.Init(this);
        worldSpaceManager = WorldSpaceManager.Init(this);
        // prefab_cube = Resources.Load<GameObject>("Prefabs/Cube");
    }
    // public static void AddListener()
    // {

    //     EventManager.Instance.AddCubeEvent_on += Instance.AddCube;
    //     EventManager.Instance.AddCubeEvent_after += Instance.RefreshCameraSpace;

    //     EventManager.Instance.RemoveCubeEvent_on += Instance.RemoveCube;
    //     // EventManager.Instance.RemoveCubeEvent_after += Instance.RefreshCameraSpace;

    //     EventManager.Instance.AddCube_ChangeDepthEvent_on += Instance.AddCube_ChangeDepth;
    //     EventManager.Instance.AddCube_ChangeDepthEvent_after += Instance.RefreshCameraSpace;

    //     EventManager.Instance.IsPassable += Instance.IsPassive;
    //     EventManager.Instance.IsEmpty += Instance.IsEmpty;

    //     EventManager.Instance.ExitLevelEvent += (x) => Instance.RemoveCube_all();

    //     EventManager.Instance.SaveCurrentMapEvent_beg += () => EventManager.Instance.SaveCurrentMap(Instance.worldSpaceManager.GetCubeListVector3Int());

    //     EventManager.Instance.HideHeadLineMapEvent += Instance.RemoveCube_all;
    // }

    public bool AddCube(Vector3Int position , int color)
    {
        if(worldSpaceManager.FindByPosition(position) != null)
        {
            Debug.LogWarning("Error Cube Exit in worldSpace");
            return false;
        }
        BaseCube cube = CubeFactory.Instance.CreateCube(position , color);
        worldSpaceManager.AddCube(cube);
        RefreshCameraSpace();
        // RefreshCameraSpace(cube);
        return true;
    }
    public bool RemoveCube(Vector3Int position)
    {
        BaseCube cube = worldSpaceManager.FindByPosition(position);
        if(cube == null)
        {
            Debug.LogWarning("Error Cube is not exist");
            return false;
        }
        worldSpaceManager.RemoveCube(cube);
        // RefreshCameraSpace(true);
        RefreshCameraSpace();
        // RefreshGroup(new List<int>(){cube.groupID});
        return true;
    }
    public void RemoveCube_all()
    {
        worldSpaceManager.RemoveCube_all();
        RefreshCameraSpace();
        // RefreshCameraSpace(true);
        // RefreshGroup_all();
    }

    public void RefreshCameraSpace()
    {
        cameraSpaceManager.ClearNodeMap();
        foreach(BaseCube cube in worldSpaceManager.GetCubes())
        {
            cameraSpaceManager.DrawGrid(cube);
        }
    }

    public int IsPassable(Vector2Int position)
    {
        return cameraSpaceManager.IsPassable(position);
    }
    public int IsPassable(Vector3Int position)
    {
        return IsPassable(CameraManager.Instance.GetCameraSpacePosition(position));
    }
    public int IsEmpty(Vector2Int position)
    {
        return cameraSpaceManager.IsEmpty(position);
    }
    public BaseCube GetCube(Vector3Int position)
    {
        return worldSpaceManager.FindByPosition(position);
    }
    // public BaseCube GetExposedCube(Vector3Int position)
    // {
    //     BaseCube targetCube = null;
    //     Vector3Int midPosition = position;
    //     while(worldSpaceManager.IsOutRange(midPosition) == false)
    //     {
    //         midPosition += CameraManager.Instance.GetCameraDirection();
    //     }
    //     while(worldSpaceManager.IsOutRange(midPosition) == true)
    //     {
    //         midPosition -= CameraManager.Instance.GetCameraDirection();
    //     }
    //     while(worldSpaceManager.IsOutRange(midPosition) == false)
    //     {
    //         targetCube = worldSpaceManager.FindByPosition(midPosition);
    //         if(targetCube != null)
    //             return targetCube;
    //         else
    //             midPosition -= CameraManager.Instance.GetCameraDirection();
    //     }
    //     Debug.LogWarning("Error GetExposedCube");
    //     return targetCube;
    // }
    public Vector3 ModifyPosition_lowerBound(Vector3 position , int depth)
    {
        position += Mathf.Ceil(((float)depth - CameraManager.Instance.GetHeight(position)) / 3.0f) * (Vector3)CameraManager.Instance.GetCameraDirection();
        return position;
    }
    int IMapManager.GetNode_L(Vector3Int position) => cameraSpaceManager.GetNode_L(CameraManager.Instance.GetCameraSpacePosition(position));
    int IMapManager.GetNode_R(Vector3Int position) => cameraSpaceManager.GetNode_R(CameraManager.Instance.GetCameraSpacePosition(position));
    BaseCube IMapManager.GetCubeL(Vector3Int position) => cameraSpaceManager.GetCube_L(CameraManager.Instance.GetCameraSpacePosition(position));
    BaseCube IMapManager.GetCubeR(Vector3Int position) => cameraSpaceManager.GetCube_R(CameraManager.Instance.GetCameraSpacePosition(position));

    void IMapManager.SaveMap()
    {
        LevelData midLevelData = new LevelData();
        midLevelData.cubeList = new List<LevelData.s_Cube>();
        foreach(BaseCube cube in worldSpaceManager.GetCubes())
        {
            midLevelData.cubeList.Add(new LevelData.s_Cube(){position = cube.Position , color = cube.Color});
        }
        // Debug.LogWarning("SaveMap " + midLevelData.cubeList.Count);
        SaveManager.Instance.AddLevelData(midLevelData);
    }

}
