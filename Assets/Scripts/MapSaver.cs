using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSaver : MonoBehaviour
{
    public List<Vector3Int> cubes = new();
    public bool Load = false;
    private void Start()
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
        if(Load)
        {
            Load = false;

        }
    }
}
