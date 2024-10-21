using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class WorldSpaceManager : IWorldSpaceManager
{
    static WorldSpaceManager instance;
    public static IWorldSpaceManager Init(MapManager mapManager)
    {
        if(instance == null)
        {
            instance = new WorldSpaceManager();
            instance.maxGroupID = 0;
            instance.mapManager = mapManager;
            instance.worldMap = new BaseCube[200,200,200];
            instance.cubeList = new List<BaseCube>();
            instance.cubeGroupList = new List<List<BaseCube>>();
            return instance;
        }
        else
        {
            Debug.LogError("WorldSpaceManager is already initialized");
            return null;
        }
    }
    MapManager mapManager;
    int maxGroupID;
    BaseCube[,,] worldMap;
    List<BaseCube> cubeList;
    List<List<BaseCube>> cubeGroupList;

    public BaseCube SearchWorldMap(Vector3Int position)
    {
        position += Vector3Int.one * 100;
        return worldMap[position.x, position.y, position.z];
    }
    public void SetWorldMap(Vector3Int position , BaseCube cube)
    {
        position += Vector3Int.one * 100;
        worldMap[position.x, position.y, position.z] = cube;
    }
    private int cubeCnt = 0;
    public bool AddCube(BaseCube cube)
    {
        if(SearchWorldMap(cube.Position) == null)
        {
            cube.gameObject.name = "Cube" + cubeCnt++;
            if(cube.groupID == -1)
            {
                cube.groupID = maxGroupID;
                cubeGroupList.Add(new List<BaseCube>());
                maxGroupID++;
            }
            SetWorldMap(cube.Position , cube);
            // worldMap[cube.Position.x, cube.Position.y, cube.Position.z] = cube;
            cubeList.Add(cube);
            cubeGroupList[cube.groupID].Add(cube);
            // Debug.Log(cube.groupID);
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
            cubeGroupList[cube.groupID].Remove(cube);
            // worldMap[cube.Position.x, cube.Position.y, cube.Position.z] = null;
            SetWorldMap(cube.Position , null);
            GameObject.Destroy(cube.gameObject);
            return true;
        }
        else
        {
            Debug.LogWarning("Cube is null");
            return false;
        }
    }
    public void MergeGroup(int groupID1, int groupID2)
    {
        if(groupID1 == groupID2)
        {
            Debug.LogWarning("groupID1 == groupID2");
            return;
        }
        foreach(BaseCube cube in cubeGroupList[groupID2])
        {
            cube.groupID = groupID1;
        }
        cubeGroupList[groupID1].AddRange(cubeGroupList[groupID2]);
        cubeGroupList[groupID2].Clear();
    }
    public void IncreaseDepth(int groupID, int depth)
    {
        depth = ((depth + 2) / 3);
        foreach(BaseCube cube in cubeGroupList[groupID])
        {
            cube.Position += depth * CameraManager.Instance.GetCameraDirection();
        }
    }
    public void DecreaseDepth(int groupID, int depth)
    {
        depth = ((depth + 2) / 3);
        foreach(BaseCube cube in cubeGroupList[groupID])
        {
            cube.Position -= depth * CameraManager.Instance.GetCameraDirection();
        }
    }
    
    public List<BaseCube> GetCubes()
    {
        // Debug.Log("GetCubes");
        return cubeList;
    }
    public BaseCube FindByPosition(Vector3Int position)
    {
        return SearchWorldMap(position);
        // return worldMap[position.x, position.y, position.z];
    }
    
}
