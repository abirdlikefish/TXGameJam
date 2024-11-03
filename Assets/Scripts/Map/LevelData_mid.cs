using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData_mid
{
    [System.Serializable]
    public struct s_Cube
    {
        // [System.Serializable]
        // [SerializeField]
        public Vector3Int position;
        // public int color;
    }
    [SerializeField]
    public int index;
    // [System.Serializable]
    [SerializeField]
    // public List<Vector3Int> cubeList;
    public List<s_Cube> cubeList;

}







// [System.Serializable]
// public class LevelData
// {
//     public int index;
//     [System.Serializable]
//     struct s_Player
//     {
//         public Vector3Int position;
//         public Vector3Int destination;
//     }
//     [System.Serializable]
//     struct s_ParentChild
//     {
//         public Vector3Int parentPosition;
//         public Vector3Int childPosition;
//     }
//     [System.Serializable]
//     struct s_Cube
//     {
//         public Vector3Int position;
//     }
//     [System.Serializable]
//     struct s_Cube_rotate
//     {
//         public Vector3Int position;
//         public Vector3 rotateCenter;
//         public Vector3Int rotateAxis;
//     }
//     [System.Serializable]
//     struct s_Cube_translate
//     {
//         public Vector3Int position;
//         public Vector3Int translateDirection;
//     }
//     [SerializeField]
//     private s_Player player;
//     [SerializeField]
//     private List<s_ParentChild> parentChildList;
//     [SerializeField]
//     private List<s_Cube> cubeList;
//     [SerializeField]
//     private List<s_Cube_rotate> cubeRotateList;
//     [SerializeField]
//     private List<s_Cube_translate> cubeTranslateList;
// }