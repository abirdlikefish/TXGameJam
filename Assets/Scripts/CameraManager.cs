using System;
using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager instance;
    public static CameraManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Camera.main.gameObject.AddComponent<CameraManager>();
                instance.transform.position = instance.GetCameraDirection() * 100;
            }
            return instance;
        }
    }
    
    Vector3Int[] cameraDirection = new Vector3Int[2]{new Vector3Int(1, 1, 1), new Vector3Int(-1, 1, 1)};
    int cameraDirectionIndex;
    
    // private int levelIndex;
    // public void ChangeCameraDirection(int levelIndex)
    // {
    //     this.levelIndex = levelIndex;
    //     cameraDirectionIndex = 1^cameraDirectionIndex;
    //     Debug.Log("current camera direction = " + cameraDirectionIndex);

    //     instance.transform.position = instance.GetCameraDirection();
    //     // RotateStart();
    // }

    public Vector3Int GetCameraDirection()
    {
        return cameraDirection[cameraDirectionIndex];
    }
    public Vector2 GetCameraSpacePosition(Vector3 position)
    {
        Vector3 mid = position - position.y * (Vector3)GetCameraDirection();
        mid += Vector3.one * 100;
        return new Vector2(mid.x, mid.z);
    }
    public Vector2Int GetCameraSpacePosition(Vector3Int position)
    {
        Vector3Int mid = position - position.y * GetCameraDirection();
        mid += Vector3Int.one * 100;
        return new Vector2Int(mid.x, mid.z);
    }
    public float GetHeight(Vector3 position)
    {
        return Vector3.Dot(position, GetCameraDirection());
    }
    public Vector2Int GetOffsetX()
    {
        if(cameraDirectionIndex == 0)
        {
            return new Vector2Int(1, 0);
        }
        else
        {
            return new Vector2Int(0, 1);
        }
    }
    public Vector2Int GetOffsetY()
    {
        if(cameraDirectionIndex == 0)
        {
            return new Vector2Int(0, 1);
        }
        else
        {
            return new Vector2Int(-1, 0);
        }
    }
    public int GetDirection_WorldDirectionInCamera(Vector3Int direction)
    {
        if(Math.Abs(direction.x) + Math.Abs(direction.y) + Math.Abs(direction.z) != 1)
        {
            Debug.LogWarning("Error direction");
            return -1;
        }
        Vector2Int midDir = new Vector2Int(direction.x, direction.z);
        if(direction.y == 1)
        {
            return 0;
        }
        if(midDir == -GetOffsetX())
        {
            return 1;
        }
        if(midDir == GetOffsetY())
        {
            return 2;
        }
        if(direction.y == -1)
        {
            return 3;
        }
        if(midDir == GetOffsetX())
        {
            return 4;
        }
        if(midDir == -GetOffsetY())
        {
            return 5;
        }
        Debug.LogWarning("Error direction");
        return -1;
    }


    
    // bool isRotating ;
    // public Vector3 center; // 圆弧的中心点
    // public float radius = 5f; // 圆弧的半径
    // public float duration = 2f; // 完成四分之一圆旋转所需的时间

    // private float elapsedTime = 0f;
    // void Update()
    // {
    //     if(isRotating)
    //     {
    //         // RotateOn();
    //     }
    // }
    // private void RotateEnd()
    // {
    //     isRotating = false;

    //     transform.position = new Vector3(center.x + radius, center.y, center.z + radius);
    //     transform.LookAt(Vector3.zero);
    //         EventManager.Instance.EnterTinyLevel_bef(levelIndex);
    // }
    // private void RotateStart()
    // {
    //     isRotating = true;
    //     elapsedTime = 0f;
    // }

    // private void RotateOn()
    // {
        
    //     // 计算当前时间的比例
    //     elapsedTime += Time.deltaTime;
    //     float t = elapsedTime / duration;
    //     if(t > 1)
    //     {
    //         RotateEnd();
    //         elapsedTime = 0f;
    //         return ;
    //     }

    //     // 计算圆弧上的点
    //     // float angle = Mathf.Lerp(0, Mathf.PI / 2, t); // 从0到90度（四分之一圆）
    //     float angle = Mathf.Lerp(-Mathf.PI / 4, Mathf.PI / 4, t); // 从0到90度（四分之一圆）
    //     float x = center.x + radius * Mathf.Cos(angle);
    //     float z = center.z + radius * Mathf.Sin(angle);
    //     float y = center.y; // 保持高度不变

    //     // 设置摄像机的位置
    //     transform.position = new Vector3(x, y, z);

    //     // 让摄像机朝向目标点
    //     transform.LookAt(Vector3.zero);
    // }

}