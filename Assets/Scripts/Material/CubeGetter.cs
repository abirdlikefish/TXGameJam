using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGetter : MonoBehaviour
{
    public static int GetNodeL(Vector3 worldPosY0)
    {
        Vector2Int screenPos = MateInput.MyWorldToScreen(worldPosY0);
        return MapManager.Instance.MyCameraSpaceManager.GetNode_L(screenPos);
    }
    public static int GetNodeR(Vector3 worldPosY0)
    {
        Vector2Int screenPos = MateInput.MyWorldToScreen(worldPosY0);
        return MapManager.Instance.MyCameraSpaceManager.GetNode_R(screenPos);
    }
    public static BaseCube GetCubeL(Vector3 worldPosY0)
    {
        Vector2Int screenPos = MateInput.MyWorldToScreen(worldPosY0);
        return MapManager.Instance.MyCameraSpaceManager.GetCube_L(screenPos);
    }
    public static BaseCube GetCubeR(Vector3 worldPosY0)
    {
        Vector2Int screenPos = MateInput.MyWorldToScreen(worldPosY0);
        return MapManager.Instance.MyCameraSpaceManager.GetCube_R(screenPos);
    }
    public static BaseCube GetCubeCanTooru(Vector3 worldPosY0)
    {
        Vector2Int pos = MateInput.MyWorldToScreen(worldPosY0);
        int ret = EventManager.Instance.IsPassable(pos);
        if (ret == 0)
            return null;
        if(ret == 2 || ret == 3)
            return GetCubeL(worldPosY0);
        return GetCubeR(worldPosY0);
    }
    public static BaseCube GetCubeUpperFloor(Vector3 dirInWorld, Vector3 center)
    {
        if (((dirInWorld == new Vector3(1, 0, 0) || dirInWorld == new Vector3(0, 0, -1)) && GetNodeR(center) == 2)
            ||
            ((dirInWorld == new Vector3(-1, 0, 0) || dirInWorld == new Vector3(0, 0, 1)) && GetNodeL(center) == 1))
        {
            if (dirInWorld == new Vector3(1, 0, 0) || dirInWorld == new Vector3(0, 0, -1))
            {
                BaseCube cube = GetCubeR(center);
                if (cube == null)
                {
                    Debug.LogError($"WTF!! dir {dirInWorld},center {center}");
                    return null;
                }
                return cube;
            }
            else
            {
                BaseCube cube = GetCubeL(center);
                if (cube == null)
                {
                    Debug.LogError($"WTF!! dir {dirInWorld},center {center}");
                    return null;
                }
                return cube;
            }
        }
        return null;
    }
    public static BaseCube GetCubeLowerFloor(Vector3 dirInWorld, Vector3 center)
    {
        if (((dirInWorld == new Vector3(1, 0, 0) || dirInWorld == new Vector3(0, 0, -1)) && GetNodeR(center) == 1)
            ||
            ((dirInWorld == new Vector3(-1, 0, 0) || dirInWorld == new Vector3(0, 0, 1)) && GetNodeL(center) == 2))
        {
            if (dirInWorld == new Vector3(1, 0, 0) || dirInWorld == new Vector3(0, 0, -1))
            {
                BaseCube cube = GetCubeR(center);
                if (cube == null)
                {
                    Debug.LogError($"WTF!! dir {dirInWorld},center {center}");
                    return null;
                }
            }
            else
            {
                BaseCube cube = GetCubeL(center);
                if (cube == null)
                {
                    Debug.LogError($"WTF!! dir {dirInWorld},center {center}");
                    return null;
                }
            }
        }
        return null;
    }
}
