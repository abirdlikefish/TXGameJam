using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSetterEntity : MonoBehaviour
{
    Vector3 ThisCenter => transform.position;
    public int d1;
    private void Start()
    {
        StartCoroutine(SetDepth());
    }
    IEnumerator SetDepth()
    {
        while (true)
        {
            int h1 = GetLeftCubeD(ThisCenter);
            if (h1 == int.MinValue)
            {
                yield return 0;
                continue;
            }
            int h2 = GetRightCubeD(ThisCenter);
            if (h2 == int.MinValue)
            {
                yield return 0;
                continue;
            }
            d1 = 3000 + h1 + h2 + 2;
            GetComponent<NewMaterial>().Material.renderQueue = d1;
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
