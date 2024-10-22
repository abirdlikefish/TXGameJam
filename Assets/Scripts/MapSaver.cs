using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSaver : Singleton<MapSaver>,IOnGameAwakeInit
{
    public List<Vector3Int> cubes = new();
    public List<Vector3Int> temp_cubes = new();
    public bool clear = false;
    public bool load = false;
    public void InitializeOnGameAwake()
    {
        EventManager.Instance.AddCubeEvent_before += (Vector3Int pos) =>
        {
            cubes.Add(pos);
        };
        EventManager.Instance.RemoveCubeEvent_before += (Vector3Int pos) =>
        {
            cubes.Remove(pos);
        };
    }
    void Update()
    {
        if(clear)
        {
            clear = false;
            for(int i = cubes.Count - 1; i >= 0; i--)
            {
                EventManager.Instance.RemoveCube(cubes[i]);
            }
        }
        if (load)
        {
            load = false;
            for (int i = cubes.Count - 1; i >= 0; i--)
            {
                EventManager.Instance.AddCube(cubes[i]);
            }
        }
    }
}
