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
    public int GetNewID()
    {

        cubeGroupList.Add(new List<BaseCube>());
        return maxGroupID++;
    }
    private int cubeCnt = 0;
    public bool AddCube(BaseCube cube)
    {
        if(SearchWorldMap(cube.Position) == null)
        {
            cube.gameObject.name = "Cube" + cubeCnt++;
            if(cube.groupID == -1)
            {
                // cube.groupID = maxGroupID;
                // cubeGroupList.Add(new List<BaseCube>());
                // maxGroupID++;
                Debug.LogWarning("Cube.groupID is -1");
                return false;
            }
            SetWorldMap(cube.Position , cube);
            cubeList.Add(cube);
            cubeGroupList[cube.groupID].Add(cube);
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
    public void RemoveCube_all()
    {
        foreach(BaseCube cube in cubeList)
        {
            GameObject.Destroy(cube.gameObject);
        }
        cubeList.Clear();
        cubeGroupList.Clear();
        worldMap = new BaseCube[200,200,200];
    }
    public void MergeGroup(List<int> groupIDList)
    {
        Debug.Log("mergeGroup :" + string.Join("," , groupIDList));
        if(groupIDList.Count == 0)
        {
            // Debug.LogWarning("groupIDList.Count == 0");
            return;
        }
        for(int i = 1 ; i < groupIDList.Count ; i++)
        {
            if(groupIDList[i] == groupIDList[0])
            {
                continue;
            }
            foreach(BaseCube cube in cubeGroupList[groupIDList[i]])
            {
                cube.groupID = groupIDList[0];
            }
            cubeGroupList[groupIDList[0]].AddRange(cubeGroupList[groupIDList[i]]);
            cubeGroupList[groupIDList[i]].Clear();

        }
    }
    public List<BaseCube> GetCubesByGroupID(int groupID)
    {
        return cubeGroupList[groupID];
    }
    public void CleanGroup(int groupID)
    {
        foreach(BaseCube cube in cubeGroupList[groupID])
        {
            cube.groupID = -1;
        }
        cubeGroupList[groupID].Clear();
    }
    public void CleanGroup_all()
    {
        maxGroupID = 0;
        cubeGroupList.Clear();
        foreach(BaseCube cube in cubeList)
        {
            cube.groupID = -1;
        }
    }
    public void AddCubeToGroup(BaseCube cube)
    {
        if(cube.groupID == -1)
        {
            Debug.LogWarning("Cube.groupID is -1");
            return;
        }
        cubeGroupList[cube.groupID].Add(cube);
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
