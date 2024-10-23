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
    }

    public event Action<Vector3Int , Vector3Int> AddCube_ChangeDepthEvent_before;
    public event Func<Vector3Int , Vector3Int , bool> AddCube_ChangeDepthEvent_on;
    public event Action<bool> AddCube_ChangeDepthEvent_after;
    public void AddCube_ChangeDepth(Vector3Int parentPosition, Vector3Int position)
    {
        AddCube_ChangeDepthEvent_before?.Invoke(parentPosition, position);
        bool isSucceed = AddCube_ChangeDepthEvent_on?.Invoke(parentPosition , position) ?? false;
        AddCube_ChangeDepthEvent_after?.Invoke(isSucceed);
    }

    //¹Ø¿¨id
    public Action<int> OnEnterBigLevel;

    public Action OnEnterSmallLevel;

    //Íæ¼Òid£¬HPÖµ
    public Action<int,float> OnHPChange;

    public Func<Vector2Int , int> IsPassable;
    public Func<Vector2Int , int> IsEmpty;
}
