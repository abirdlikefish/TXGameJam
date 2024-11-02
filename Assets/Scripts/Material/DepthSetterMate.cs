using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSetterMate : MonoBehaviour
{
    public int d1;
    public int d2;
    public int d3;
    MateMover mateMover;
    NewMaterial newMaterial;
    Vector3Int ThisCenter => Vector3Int.RoundToInt(mateMover.thisCenter);
    Vector3Int NextCenter => Vector3Int.RoundToInt(mateMover.thisCenter + mateMover.flipDir);
   

    float trapTimer = 0;
    bool trapped;
    private void OnEnable()
    {
        mateMover = GetComponent<MateMover>();
        newMaterial = GetComponent<NewMaterial>();
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
        newMaterial.Material.renderQueue = d3;
        
    }
    void TryTrap()
    {
        Vector3Int curCenter = Vector3Int.RoundToInt(ThisCenter);
        int leftType = MapManager.Instance.GetNode_L(curCenter);
        int rightType = MapManager.Instance.GetNode_R(curCenter);
        // int leftType = CubeGetter.GetNodeL(curCenter);
        // int rightType = CubeGetter.GetNodeR(curCenter);
        if (leftType == 1 && rightType == 2)
        {
            Debug.Log($"RemoveCube Pos{curCenter}");
            EventManager.Instance.RemoveCube(MapManager.Instance.GetCubeL(curCenter).Position);
        }
        if (EventManager.Instance.IsPassable(MateInput.MyWorldToScreen(ThisCenter)) == 0)
        {
            trapTimer += Time.deltaTime;
            if (trapTimer >= 3f && !trapped)
            {
                trapped = true;
                MateManager.Instance.OnOneDead(GetComponent<Mate>());
            }
        }
        else
        {
            trapTimer = 0f;
            trapped = false;
        }
    }
    // int GetLeftCubeD(Vector3 center)
    // {
    //     BaseCube cube = CubeGetter.GetCubeL(center);
    //     if (cube == null)
    //         return int.MinValue;
    //     return cube.Height;
    // }
    // int GetRightCubeD(Vector3 center)
    // {
    //     BaseCube cube = CubeGetter.GetCubeR(center);
    //     if (cube == null)
    //         return int.MinValue;
    //     return cube.Height;
    // }
    
    int GetLeftCubeD(Vector3Int center)
    {
        if(MapManager.Instance.GetCubeL(center) == null)
        {
            return int.MinValue;
        }
        else
        {
            return Mathf.RoundToInt(CameraManager.Instance.GetHeight(center));
        }
    }
    int GetRightCubeD(Vector3Int center)
    {        
        if(MapManager.Instance.GetCubeR(center) == null)
        {
            return int.MinValue;
        }
        else
        {
            return Mathf.RoundToInt(CameraManager.Instance.GetHeight(center));
        }
    }
}
