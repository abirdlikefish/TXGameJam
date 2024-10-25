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
    
    public void ChangeCameraDirection()
    {
        cameraDirectionIndex = 1^cameraDirectionIndex;
        instance.transform.position = instance.GetCameraDirection();
        Debug.Log("current camera direction = " + cameraDirectionIndex);
    }

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
    public float GetDepth(Vector3 position)
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
}
