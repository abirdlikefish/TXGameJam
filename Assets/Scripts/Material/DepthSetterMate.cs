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

    float trapTimer = 0;
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
            Vector3Int curCenter = Vector3Int.RoundToInt(GetComponent<MateMover>().CurCenter);
            int leftType = CubeGetter.GetNodeL(curCenter);
            int rightType = CubeGetter.GetNodeR(curCenter);
            if(leftType == 1 && rightType == 2)
            {
                EventManager.Instance.RemoveCube(curCenter);
            }
            else if(leftType == 2 && rightType == 1)
            {
                trapTimer += Time.deltaTime;
                EventManager.Instance.StartTrap(GetComponent<Mate>(),transform.position, trapTimer);
                d3 = 2000;
            }
            else
            {
                trapTimer = 0f;
            }

            if(trapTimer >= 3f)
            {
                EventManager.Instance.ExitTinyLevel();
            }
            GetComponent<NewMaterial>().Material.renderQueue = d3;
            yield return 0;
        }
    }

    int GetLeftCubeD(Vector3 center)
    {
        BaseCube cube = CubeGetter.GetCubeL(center);
        if (cube == null)
            return int.MinValue;
        return cube.Height;
    }
    int GetRightCubeD(Vector3 center)
    {
        BaseCube cube = CubeGetter.GetCubeR(center);
        if (cube == null)
            return int.MinValue;
        return cube.Height;
    }
}
