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
        TryTrap();
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
        GetComponent<NewMaterial>().Material.renderQueue = d3;
        
    }
    void TryTrap()
    {
        Vector3Int curCenter = Vector3Int.RoundToInt(GetComponent<MateMover>().CurCenter);
        int leftType = CubeGetter.GetNodeL(curCenter);
        int rightType = CubeGetter.GetNodeR(curCenter);
        if (leftType == 1 && rightType == 2)
        {
            Debug.Log($"RemoveCube Pos{curCenter}");
            EventManager.Instance.RemoveCube(CubeGetter.GetCubeL(curCenter).Position);
        }
        if (EventManager.Instance.IsPassable(MateInput.MyWorldToScreen(ThisCenter)) == 0)
        {
            trapTimer += Time.deltaTime;
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
