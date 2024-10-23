using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraSpaceManager
{
    void ClearNodeMap();
    void DrawGrid(BaseCube cube);
    int IsPassable(Vector2Int position);
    int IsEmpty(Vector2Int position);
    public List<BaseCube> GetCubes(Vector2Int position);
    public bool IsCubeExposed(Vector2Int position);
}
