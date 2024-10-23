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
    }
    public int index;
    [SerializeField]
    public List<s_Cube> cubeList;
}
