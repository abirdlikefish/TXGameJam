using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGetter
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
    public static BaseCube GetCubeUpperFloor(Vector3 dirInWorld, Vector3 thisCenter)
    {
        //Debug.Log(nameof(GetCubeUpperFloor) + " " + dirInWorld + " " + thisCenter);
        bool isUp = dirInWorld == new Vector3(-1, 0, 0) || dirInWorld == new Vector3(0, 0, -1);
        //bool isDown = dirInWorld == new Vector3(1, 0, 0) || dirInWorld == new Vector3(0, 0, 1);
        bool isX = dirInWorld.x != 0;
        int thisHalfType;
        int nextHalfType;
        if (isUp)
        {
            thisHalfType = isX ? GetNodeR(thisCenter) : GetNodeL(thisCenter);
            nextHalfType = isX ? GetNodeL(thisCenter + dirInWorld) : GetNodeR(thisCenter + dirInWorld);
            if (thisHalfType == nextHalfType)
                return null;
            int topType = isX ? GetNodeR(thisCenter + new Vector3(-1, 0, -1)) : GetNodeL(thisCenter + new Vector3(-1, 0, -1));
            if(isX && topType == 1 || !isX && topType == 2)
                return isX ? GetCubeR(thisCenter + new Vector3(-1, 0, -1)) : GetCubeL(thisCenter + new Vector3(-1, 0, -1));
            return null;
        }
        //thisHalfType = isX ? GetNodeL(thisCenter) : GetNodeR(thisCenter);
        //isDown
        if(isX && GetNodeL(thisCenter) == 2 || !isX && GetNodeR(thisCenter) == 1)
            return isX ? GetCubeL(thisCenter) : GetCubeR(thisCenter);
        return null;
    }
    //public static BaseCube GetCubeLowerFloor(Vector3 dirInWorld, Vector3 center)
    //{
    //    if (((dirInWorld == new Vector3(1, 0, 0) || dirInWorld == new Vector3(0, 0, -1)) && GetNodeR(center) == 1)
    //        ||
    //        ((dirInWorld == new Vector3(-1, 0, 0) || dirInWorld == new Vector3(0, 0, 1)) && GetNodeL(center) == 2))
    //    {
    //        if (dirInWorld == new Vector3(1, 0, 0) || dirInWorld == new Vector3(0, 0, -1))
    //        {
    //            BaseCube cube = GetCubeR(center);
    //            if (cube == null)
    //            {
    //                Debug.LogError($"WTF!! dir {dirInWorld},center {center}");
    //                return null;
    //            }
    //        }
    //        else
    //        {
    //            BaseCube cube = GetCubeL(center);
    //            if (cube == null)
    //            {
    //                Debug.LogError($"WTF!! dir {dirInWorld},center {center}");
    //                return null;
    //            }
    //        }
    //    }
    //    return null;
    //}
}
