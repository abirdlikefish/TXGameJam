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
    public CameraSpaceManager MyCameraSpaceManager => (CameraSpaceManager)cameraSpaceManager;
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
        // EventManager.Instance.RemoveCubeEvent_after += Instance.RefreshCameraSpace;

        EventManager.Instance.AddCube_ChangeDepthEvent_on += Instance.AddCube_ChangeDepth;
        EventManager.Instance.AddCube_ChangeDepthEvent_after += Instance.RefreshCameraSpace;

        EventManager.Instance.IsPassable += Instance.IsPassive;
        EventManager.Instance.IsEmpty += Instance.IsEmpty;

        EventManager.Instance.ExitLevelEvent += (x) => Instance.RemoveCube_all();

    }

    public bool AddCube(Vector3Int position)
    {
        if(worldSpaceManager.FindByPosition(position) != null)
        {
            Debug.LogWarning("Error Cube Exit in worldSpace");
            return false;
        }
        BaseCube cube = GameObject.Instantiate(prefab_cube).GetComponent<BaseCube>();
        cube.Position = position;
        List<BaseCube> cubes = cameraSpaceManager.GetCubes(cube.GetCameraSpacePosition());
        List<int> mergeID = new List<int>();
        for(int i = 0 ; i < 6; i++)
        {
            if(cubes[i] != null)
            {
                mergeID.Add(cubes[i].groupID);
            }
        }
        if(mergeID.Count == 0)
            cube.groupID = worldSpaceManager.GetNewID();
        else
            cube.groupID = mergeID[0];
        worldSpaceManager.AddCube(cube);
        worldSpaceManager.MergeGroup(mergeID);
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
        RefreshCameraSpace(true);
        RefreshGroup(new List<int>(){cube.groupID});
        return true;
    }
    public void RemoveCube_all()
    {
        worldSpaceManager.RemoveCube_all();
        RefreshCameraSpace(true);
    }
    public bool AddCube_ChangeDepth(Vector3Int parentPosition , Vector3Int position)
    {
        if(worldSpaceManager.FindByPosition(position) != null)
        {
            Debug.LogWarning("Error Cube Exit in worldSpace");
            return false;
        }
        BaseCube parentCube = worldSpaceManager.FindByPosition(parentPosition);
        if(parentCube == null)
        {
            Debug.LogWarning("Error parentCube is not exist");
            return false;
        }
        int direction = CameraManager.Instance.GetDirection_WorldDirectionInCamera(parentPosition - position);
        if(direction == -1)
        {
            Debug.LogWarning("Error direction");
            return false;
        }
        if(cameraSpaceManager.IsCubeExposed(CameraManager.Instance.GetCameraSpacePosition(position)))
        {
            Debug.LogWarning("Error Cube Exit in cameraSpace");
            return false;
        }


        BaseCube cube = GameObject.Instantiate(prefab_cube).GetComponent<BaseCube>();
        cube.Position = position;
        cube.groupID = parentCube.groupID;
        Debug.Log("AddCube_ChangeDepth : " + cube.Position + " direction : " + direction + "GroupID : " + cube.groupID);
        worldSpaceManager.AddCube(cube);
        
        List<BaseCube> cubes = cameraSpaceManager.GetCubes(cube.GetCameraSpacePosition());
        Debug.Log("parentCube : " + parentCube.gameObject.name + "position:" + parentCube.Position);
        direction = (direction + 1 ) % 6;

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
        List<int> mergeID = new List<int>();
        for(int i = 0 ; i < 6; i++)
        {
            if(cubes[i] != null)
            {
                mergeID.Add(cubes[i].groupID);
            }
        }
        worldSpaceManager.MergeGroup(mergeID);
        // worldSpaceManager.MergeGroup(connectedCube.groupID , cube.groupID);

        return true;
    }

    public void RefreshGroup(List<int> groupIDList)
    {
        List<BaseCube> cubeList = new List<BaseCube>();
        for(int i = 0 ; i < groupIDList.Count; i++)
        {
            cubeList.AddRange(worldSpaceManager.GetCubesByGroupID(groupIDList[i]));
            worldSpaceManager.CleanGroup(groupIDList[i]);
        }
        ResetGroupID(cubeList);
    }
    public void RefreshGroup_all()
    {
        List<BaseCube> cubeList = worldSpaceManager.GetCubes();
        worldSpaceManager.CleanGroup_all();
        ResetGroupID(cubeList);
    }

    private void ResetGroupID(List<BaseCube> cubeList)
    {
        Queue<BaseCube> unSearchedCube = new Queue<BaseCube>();
        foreach(BaseCube cube in cubeList)
        {
            // return ;
            if(cube.groupID != -1)
                continue;
            List<BaseCube> connectedCubes = cameraSpaceManager.GetCubes(cube.GetCameraSpacePosition());
            for(int i = 0 ; i < 6; i++)
            {
                if(connectedCubes[i] != null && connectedCubes[i].groupID != -1)
                {
                    cube.groupID = connectedCubes[i].groupID;
                    break;
                }
                // if(connectedCubes[i] != null && connectedCubes[i].groupID == -1)
                // {
                //     if(cube.groupID != -1)
                //     {
                //         Debug.LogWarning("Error groupID");
                //     }
                // }
            }
            if(cube.groupID == -1)
                cube.groupID = worldSpaceManager.GetNewID();
            for(int i = 0 ; i < 6; i++)
            {
                if(connectedCubes[i] != null && connectedCubes[i].groupID == -1)
                {
                    connectedCubes[i].groupID = cube.groupID;
                    unSearchedCube.Enqueue(connectedCubes[i]);
                }
            }
            while(unSearchedCube.Count != 0)
            {
                foreach(BaseCube midCube in cameraSpaceManager.GetCubes(unSearchedCube.Peek().GetCameraSpacePosition()))
                {
                    if(midCube != null && midCube.groupID == -1)
                    {
                        midCube.groupID = unSearchedCube.Peek().groupID;
                        unSearchedCube.Enqueue(midCube);
                    }
                }
                unSearchedCube.Dequeue();
            }
        }
        foreach(BaseCube cube in cubeList)
        {
            worldSpaceManager.AddCubeToGroup(cube);
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


    // public void SetCubeColor(Vector2Int position , int color)
    // {
    //     int isPassable = cameraSpaceManager.IsPassable(position);
    //     if(isPassable == 0)
    //     {
    //         cameraSpaceManager.GetCube_L(position).Color = color;
    //     }
    //     else if(isPassable == 1)
    //     {
    //         cameraSpaceManager.GetCube_R(position).Color = color;
    //     }
    //     else if(isPassable == 2)
    //     {
    //         cameraSpaceManager.GetCube_L(position).Color = color;
    //     }
    //     else
    //     {
    //         Debug.LogWarning("Error SetCubeColor");
    //     }
    // }
    // public void SetCubeColor_L(Vector2Int position , int color)
    // {
    //     cameraSpaceManager.GetCube_L(position).Color = color;
    // }
    // public void SetCubeColor_R(Vector2Int position , int color)
    // {
    //     cameraSpaceManager.GetCube_R(position).Color = color;
    // }

    public int IsPassive(Vector2Int position)
    {
        return cameraSpaceManager.IsPassable(position);
    }
    public int IsEmpty(Vector2Int position)
    {
        return cameraSpaceManager.IsEmpty(position);
    }



}
