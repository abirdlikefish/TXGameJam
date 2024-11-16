using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapManager
{
    public bool AddCube(Vector3Int position , int color);
    public bool RemoveCube(Vector3Int position);
    public void RemoveCube_all();
    // public int IsPassable(Vector2Int position);
    // public int IsPassable(Vector3Int position);
    // public int IsEmpty(Vector2Int position);
    public BaseCube GetCube(Vector3Int position);
    public BaseCube GetExposedCube(Vector3Int position);
    public BaseCube GetCubeL(Vector3Int position);
    public BaseCube GetCubeR(Vector3Int position);
    public BaseCube GetCubeL_Top(Vector3Int position);
    public BaseCube GetCubeR_Top(Vector3Int position);
    public Vector3 ModifyPosition_lowerBound(Vector3 position , int height);
    public Vector3 ModifyPosition_lowerBound(Vector2 position , int height);

    public NodeType GetNodeType_L(Vector3Int position);
    public NodeType GetNodeType_R(Vector3Int position);

    public NodeType GetNodeType_L(Vector2Int position);
    public NodeType GetNodeType_R(Vector2Int position);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public bool IsSideExposed_Top_L(Vector3Int position);
    public bool isSideExposed_Top_R(Vector3Int position);
    public bool IsSideExposed_L(Vector2Int position);
    public bool isSideExposed_R(Vector2Int position);

    // public int GetNode_L(Vector3Int position);
    // public int GetNode_R(Vector3Int position);

    // public bool IsEmpty_L(Vector2Int position);
    // public bool IsEmpty_L(Vector3Int position);
    // public bool IsEmpty_R(Vector2Int position);
    // public bool IsEmpty_R(Vector3Int position);
    // public bool IsSide_L(Vector2Int position);
    // public bool IsSide_L(Vector3Int position);
    // public bool IsSide_R(Vector2Int position);
    // public bool IsSide_R(Vector3Int position);
    // public bool IsTop_L(Vector2Int position);
    // public bool IsTop_L(Vector3Int position);
    // public bool IsTop_R(Vector2Int position);
    // public bool IsTop_R(Vector3Int position);

    public void SaveMap();
}
