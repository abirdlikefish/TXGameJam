using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGetter
{
    public static BaseCube GetCubeCanTooru(Vector3Int worldPosY0)
    {
        Vector2Int pos = MateInput.MyWorldToScreen(worldPosY0);
        int ret = EventManager.Instance.IsPassable(pos);
        if (ret == 0)
            return null;
        if(ret == 2 || ret == 3)
            return MapManager.Instance.GetCubeL(worldPosY0);
        return MapManager.Instance.GetCubeR(worldPosY0);
    }
    public static BaseCube GetCubeUpperFloor(Vector3Int dirInWorld, Vector3Int thisCenter)
    {
        //Debug.Log(nameof(GetCubeUpperFloor) + " " + dirInWorld + " " + thisCenter);+
        bool isUp = dirInWorld == new Vector3(-1, 0, 0) || dirInWorld == new Vector3(0, 0, -1);
        //bool isDown = dirInWorld == new Vector3(1, 0, 0) || dirInWorld == new Vector3(0, 0, 1);
        bool isX = dirInWorld.x != 0;
        int thisHalfType;
        int nextHalfType;
        if (isUp)
        {
            thisHalfType = isX ? MapManager.Instance.GetNode_R(thisCenter) : MapManager.Instance.GetNode_L(thisCenter);
            nextHalfType = isX ? MapManager.Instance.GetNode_L(thisCenter + dirInWorld) : MapManager.Instance.GetNode_R(thisCenter + dirInWorld);
            if (thisHalfType == nextHalfType)
                return null;
            Vector3Int midPos = thisCenter - CameraManager.Instance.GetOffsetX_vector3() - CameraManager.Instance.GetOffsetY_vector3();
            int topType = isX ? MapManager.Instance.GetNode_R(midPos) : MapManager.Instance.GetNode_L(midPos);
            if(isX && topType == 1 || !isX && topType == 2)
                return isX ? MapManager.Instance.GetCubeR(midPos) : MapManager.Instance.GetCubeL(midPos);
            return null;
        }
        //thisHalfType = isX ? GetNodeL(thisCenter) : GetNodeR(thisCenter);
        //isDown
        if(isX && MapManager.Instance.GetNode_L(thisCenter) == 2 || !isX && MapManager.Instance.GetNode_R(thisCenter) == 1)
            return isX ? MapManager.Instance.GetCubeL(thisCenter) : MapManager.Instance.GetCubeR(thisCenter);
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
