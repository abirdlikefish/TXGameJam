using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSetterMate : MonoBehaviour
{
    public int d1;
    public int d2;
    public int d3;
    Vector3 ThisCenter => GetComponent<MateMover>().CurCenter;
    //Vector3 NextCenter => GetComponent<MateMover>().Target; TODO
    private void Start()
    {
        StartCoroutine(SetDepth());
    }
    IEnumerator SetDepth()
    {
        while (true)
        {
            int h1 = GetLeftCube(ThisCenter);
            if(h1 == int.MinValue)
            {
                yield return 0;
                continue;
            }
            int h2 = GetRightCube(ThisCenter);
            if(h2 == int.MinValue)
            {
                yield return 0;
                continue;
            }
            d1 = 3000 + h1 + h2;
            //h1 = GetLeftCube(NextCenter);
            //h2 = GetRightCube(NextCenter);
            //d2 = 3000 + h1 + h2;
            d3 = Mathf.Max(d1, d1) + 1;
            GetComponent<NewMaterial>().Material.renderQueue = d3;
            yield return 0;
        }
    }

    int GetLeftCube(Vector3 center)
    {
        Vector2Int screenPos = Vector2Int.RoundToInt(CameraManager.Instance.GetCameraSpacePosition(center));
        BaseCube cube = MapManager.Instance.MyCameraSpaceManager.GetCube_L(screenPos);
        if (cube == null)
            return int.MinValue;
        return cube.Height;
    }
    int GetRightCube(Vector3 center)
    {
        Vector2Int screenPos = Vector2Int.RoundToInt(CameraManager.Instance.GetCameraSpacePosition(center));
        BaseCube cube = MapManager.Instance.MyCameraSpaceManager.GetCube_R(screenPos);
        if (cube == null)
            return int.MinValue;
        return cube.Height;
    }
}
