using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraSpaceManager
{
    void ClearNodeMap();
    void DrawGrid(BaseCube cube);
    bool IsPassable(Vector2Int position);
}
