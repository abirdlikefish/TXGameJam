using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LevelData
{
    [System.Serializable]
    public struct s_Cube
    {
        public Vector3Int position;
        public int color;
    }
    public int index;
    [SerializeField]
    public List<s_Cube> cubeList;

    // [SerializeField]
    // public List<Vector3Int> rCubeList;
    // [SerializeField]
    // public List<Vector3Int> gCubeList;
    // [SerializeField]
    // public List<Vector3Int> bCubeList;
}
