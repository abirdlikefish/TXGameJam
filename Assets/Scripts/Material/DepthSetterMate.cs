using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSetterMate : MonoBehaviour
{
    public int d1;
    public int d2;
    public int d3;
    Vector3 ThisCenter => GetComponent<MateMover>().CurCenter;
    Vector3 NextCenter => GetComponent<MateMover>().CurCenter + GetComponent<MateMover>().flipDir;
    private void Start()
    {
        StartCoroutine(SetDepth());
    }
    IEnumerator SetDepth()
    {
        while (true)
        {
            int h1 = GetLeftCubeD(ThisCenter);
            if(h1 == int.MinValue)
            {
                yield return 0;
                continue;
            }
            int h2 = GetRightCubeD(ThisCenter);
            if(h2 == int.MinValue)
            {
                yield return 0;
                continue;
            }
            d1 = 3000 + h1 + h2;
            h1 = GetLeftCubeD(NextCenter);
            h2 = GetRightCubeD(NextCenter);
            d2 = 3000 + h1 + h2;
            if (!MateInput.CanTooruY0(ThisCenter,NextCenter))
                d2 = 0;
            d3 = Mathf.Max(d1, d2) + 1;
            GetComponent<NewMaterial>().Material.renderQueue = d3;
            yield return 0;
        }
    }

    int GetLeftCubeD(Vector3 center)
    {
        BaseCube cube = Test.GetCubeL(center);
        if (cube == null)
            return int.MinValue;
        return cube.Height;
    }
    int GetRightCubeD(Vector3 center)
    {
        BaseCube cube = Test.GetCubeR(center);
        if (cube == null)
            return int.MinValue;
        return cube.Height;
    }
}
