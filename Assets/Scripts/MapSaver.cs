using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSaver : Singleton<MapSaver>
{
    public List<Vector3Int> cubes = new();
    public List<Vector3Int> temp_cubes = new();
    public bool load = false;
    public override void Init()
    {
        EventManager.Instance.AddCubeEvent_before += (Vector3Int pos,int midNum) =>
        {
            cubes.Add(pos);
        };
        EventManager.Instance.RemoveCubeEvent_before += (Vector3Int pos) =>
        {
            cubes.Remove(pos);
        };
    }
    //void Update()
    //{
    //    if (load || Input.GetKeyDown(KeyCode.R))
    //    {
    //        load = false;
    //        for (int i = cubes.Count - 1; i >= 0; i--)
    //        {
    //            EventManager.Instance.RemoveCube(cubes[i]);
    //        }
    //        cubes.Clear();
    //        Debug.Log("a" + cubes.Count);
    //        for (int i = temp_cubes.Count - 1; i >= 0; i--)
    //        {
    //            EventManager.Instance.AddCube(temp_cubes[i]);
    //        }
    //        Debug.Log("b" + cubes.Count);
    //    }


    //}
}
