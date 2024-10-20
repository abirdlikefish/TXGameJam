using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    private static EventManager instance;
    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventManager();
            }
            return instance;
        }
    }

    public event Action<Vector3Int> AddCubeEvent_before;
    public event Func<Vector3Int , bool> AddCubeEvent_on;
    public event Action<bool> AddCubeEvent_after;
    public void AddCube(Vector3Int position)
    {
        AddCubeEvent_before?.Invoke(position);
        bool isSucceed = AddCubeEvent_on?.Invoke(position) ?? false;
        AddCubeEvent_after?.Invoke(isSucceed);
    }

    public event Action<Vector3Int> RemoveCubeEvent_before;
    public event Func<Vector3Int, bool> RemoveCubeEvent_on;
    public event Action<bool> RemoveCubeEvent_after;
    public void RemoveCube(Vector3Int position)
    {
        RemoveCubeEvent_before?.Invoke(position);
        bool isSucceed = RemoveCubeEvent_on?.Invoke(position) ?? false;
        RemoveCubeEvent_after?.Invoke(isSucceed);
// CameraManager.Instance.GetCameraSpacePosition
    }



    public Func<Vector2Int , bool> IsPassive;

    // public delegate void GetMovePositionEvent(Vector3 position, Vector2Int direction, out Vector3 movePosition, out Vector3Int targetPosition);
    // public GetMovePositionEvent GetMovePosition;
    // public Action<Vector3Int , Vector2Int , out Vector3 , out Vector3Int> GetMovePosition;
}
