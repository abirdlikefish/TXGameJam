using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceManager : IWorldSpaceManager
{
    static WorldSpaceManager instance;
    public static IWorldSpaceManager Init(MapManager mapManager)
    {
        if(instance == null)
        {
            instance = new WorldSpaceManager();
            instance.mapManager = mapManager;
            instance.worldMap = new BaseCube[100,100,100];
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

    BaseCube[,,] worldMap;
    List<BaseCube> cubeList;

    public bool AddCube(BaseCube cube)
    {
        if(worldMap[cube.Position.x, cube.Position.y, cube.Position.z] == null)
        {
            worldMap[cube.Position.x, cube.Position.y, cube.Position.z] = cube;
            cubeList.Add(cube);
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
            worldMap[cube.Position.x, cube.Position.y, cube.Position.z] = null;
            GameObject.Destroy(cube.gameObject);
            return true;
        }
        else
        {
            Debug.LogWarning("Cube is null");
            return false;
        }
    }
    public List<BaseCube> GetCubes()
    {
        Debug.Log("GetCubes");
        return cubeList;
    }
    public BaseCube FindByPosition(Vector3Int position)
    {
        return worldMap[position.x, position.y, position.z];
    }
    
}
