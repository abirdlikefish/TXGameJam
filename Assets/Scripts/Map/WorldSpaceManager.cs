using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class WorldSpaceManager : IWorldSpaceManager
{
    static WorldSpaceManager instance;
    static readonly Vector3Int maxWorldSpaceSize = new Vector3Int(200,200,200);
    public static IWorldSpaceManager Init(MapManager mapManager)
    {
        if(instance == null)
        {
            instance = new WorldSpaceManager();
            // instance.maxGroupID = 0;
            instance.mapManager = mapManager;
            instance.worldMap = new BaseCube[maxWorldSpaceSize.x,maxWorldSpaceSize.y,maxWorldSpaceSize.z];
            instance.cubeList = new List<BaseCube>();
            return instance;
        }
        else
        {
            Debug.LogError("WorldSpaceManager is already initialized");
            return null;
        }
    }
    MapManager mapManager;
    // int maxGroupID;
    BaseCube[,,] worldMap;
    List<BaseCube> cubeList;
    // List<List<BaseCube>> cubeGroupList;
    private Vector3Int PositionOffset(Vector3Int position)
    {
        return position + maxWorldSpaceSize / 2;
    }
    public BaseCube SearchWorldMap(Vector3Int position)
    {
        position = PositionOffset(position);
        return worldMap[position.x, position.y, position.z];
    }
    public void SetWorldMap(Vector3Int position , BaseCube cube)
    {
        position = PositionOffset(position);
        worldMap[position.x, position.y, position.z] = cube;
    }
    // public int GetNewID()
    // {

    //     cubeGroupList.Add(new List<BaseCube>());
    //     return maxGroupID++;
    // }
    // private int cubeCnt = 0;
    public bool AddCube(BaseCube cube)
    {
        if(SearchWorldMap(cube.Position) == null)
        {
            // cube.gameObject.name = "Cube" + cubeCnt++;
            // if(cube.groupID == -1)
            // {
            //     // cube.groupID = maxGroupID;
            //     // cubeGroupList.Add(new List<BaseCube>());
            //     // maxGroupID++;
            //     Debug.LogWarning("Cube.groupID is -1");
            //     return false;
            // }
            SetWorldMap(cube.Position , cube);
            cubeList.Add(cube);
            // cubeGroupList[cube.groupID].Add(cube);
            return true;
        }
        else
        {
            Debug.LogWarning("Cube is already exist");
            return false;
        }
    }
    public bool RemoveCube(BaseCube cube)
    {
        if(cube != null)
        {
            cubeList.Remove(cube);
            CubeFactory.Instance.DestroyCube(cube);
            // cubeGroupList[cube.groupID].Remove(cube);
            SetWorldMap(cube.Position , null);
            // GameObject.Destroy(cube.gameObject);
            return true;
        }
        else
        {
            Debug.LogWarning("Cube is null");
            return false;
        }
    }
    public void RemoveCube_all()
    {
        foreach(BaseCube cube in cubeList)
        {
            // GameObject.Destroy(cube.gameObject);
            CubeFactory.Instance.DestroyCube(cube);
        }
        cubeList.Clear();
        // cubeGroupList.Clear();
        worldMap = new BaseCube[200,200,200];
    }
    // public void MergeGroup(List<int> groupIDList)
    // {
    //     if(groupIDList.Count == 0)
    //     {
    //         return;
    //     }
    //     for(int i = 1 ; i < groupIDList.Count ; i++)
    //     {
    //         if(groupIDList[i] == groupIDList[0])
    //         {
    //             continue;
    //         }
    //         foreach(BaseCube cube in cubeGroupList[groupIDList[i]])
    //         {
    //             cube.groupID = groupIDList[0];
    //         }
    //         cubeGroupList[groupIDList[0]].AddRange(cubeGroupList[groupIDList[i]]);
    //         cubeGroupList[groupIDList[i]].Clear();

    //     }
    // }
    // public List<BaseCube> GetCubesByGroupID(int groupID)
    // {
    //     return cubeGroupList[groupID];
    // }
    // public void CleanGroup(int groupID)
    // {
    //     foreach(BaseCube cube in cubeGroupList[groupID])
    //     {
    //         cube.groupID = -1;
    //     }
    //     cubeGroupList[groupID].Clear();
    // }
    // public void CleanGroup_all()
    // {
    //     maxGroupID = 0;
    //     cubeGroupList.Clear();
    //     foreach(BaseCube cube in cubeList)
    //     {
    //         cube.groupID = -1;
    //     }
    // }
    // public void AddCubeToGroup(BaseCube cube)
    // {
    //     if(cube.groupID == -1)
    //     {
    //         Debug.LogWarning("Cube.groupID is -1");
    //         return;
    //     }
    //     cubeGroupList[cube.groupID].Add(cube);
    // }
    // public void IncreaseDepth(int groupID, int depth)
    // {
    //     depth = ((depth + 2) / 3);
    //     foreach(BaseCube cube in cubeGroupList[groupID])
    //     {
    //         cube.Position += depth * CameraManager.Instance.GetCameraDirection();
    //     }
    // }
    // public void DecreaseDepth(int groupID, int depth)
    // {
    //     depth = ((depth + 2) / 3);
    //     foreach(BaseCube cube in cubeGroupList[groupID])
    //     {
    //         cube.Position -= depth * CameraManager.Instance.GetCameraDirection();
    //     }
    // }
    
    public List<BaseCube> GetCubes()
    {
        // Debug.Log("GetCubes");
        return cubeList;
    }
    public List<Vector3Int> GetCubeListVector3Int()
    {
        List<Vector3Int> cubeList = new List<Vector3Int>();
        foreach(BaseCube cube in GetCubes())
        {
            cubeList.Add(cube.Position);
        }
        return cubeList;
    }
    public BaseCube FindByPosition(Vector3Int position)
    {
        return SearchWorldMap(position);
    }

    public bool IsOutRange(Vector3Int position)
    {
        if(position.x <= -maxWorldSpaceSize.x / 2 || position.x >= maxWorldSpaceSize.x / 2)
        {
            return true;
        }
        if(position.y <= -maxWorldSpaceSize.y / 2 || position.y >= maxWorldSpaceSize.y / 2)
        {
            return true;
        }
        if(position.z <= -maxWorldSpaceSize.z / 2 || position.z >= maxWorldSpaceSize.z / 2)
        {
            return true;
        }
        return false;
    }
    
}
