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
   

    float trapTimer = 0;
    bool trapped;
    private void OnEnable()
    {
        trapped = false;
    }
    void Update()
    {
        int h1 = GetLeftCubeD(ThisCenter);
        if(h1 == int.MinValue)
        {
            return;
        }
        int h2 = GetRightCubeD(ThisCenter);
        if(h2 == int.MinValue)
        {
            return;
        }
        d1 = 3000 + h1 + h2;
        h1 = GetLeftCubeD(NextCenter);
        h2 = GetRightCubeD(NextCenter);
        d2 = 3000 + h1 + h2;
        if (!MateInput.CanTooru(ThisCenter,NextCenter))
            d2 = 0;
        d3 = Mathf.Max(d1, d2) + 1;
        Vector3Int curCenter = Vector3Int.RoundToInt(GetComponent<MateMover>().CurCenter);
        int leftType = CubeGetter.GetNodeL(curCenter);
        int rightType = CubeGetter.GetNodeR(curCenter);
        if(leftType == 1 && rightType == 2)
        {
            EventManager.Instance.RemoveCube(curCenter+Vector3Int.up);
        }
        else if(leftType == 2 && rightType == 1)
        {
            trapTimer += Time.deltaTime;
            d3 = 2000;
            if (trapTimer >= 3f && !trapped)
            {
                trapped = true;
                EventManager.Instance.StartTrap(GetComponent<Mate>());
            }
        }
        else
        {
            trapTimer = 0f;
            trapped = false;
        }
        GetComponent<NewMaterial>().Material.renderQueue = d3;
        
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
