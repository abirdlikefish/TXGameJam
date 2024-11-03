using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapManager
{
    public bool AddCube(Vector3Int position , int color);
    public bool RemoveCube(Vector3Int position);
    public void RemoveCube_all();
    public int IsPassable(Vector2Int position);
    public int IsPassable(Vector3Int position);
    public int IsEmpty(Vector2Int position);
    public BaseCube GetCube(Vector3Int position);
    public BaseCube GetExposedCube(Vector3Int position);
    public Vector3 ModifyPosition_lowerBound(Vector3 position , int depth);

    public int GetNode_L(Vector3Int position);
    public int GetNode_R(Vector3Int position);
    public BaseCube GetCubeL(Vector3Int position);
    public BaseCube GetCubeR(Vector3Int position);
    public void SaveMap();
}
