using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
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

}
