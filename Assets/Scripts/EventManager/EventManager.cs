using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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


    public event Action<Vector3Int> ColorReactionEvent_1;
    public event Action<Vector3Int> ColorReactionEvent_2;
    public event Action<Vector3Int> ColorReactionEvent_4;
    public void ColorReaction(int color , Vector3Int position)
    {
        switch (color)
        {
            case 1:
                ColorReactionEvent_1?.Invoke(position);
                break;
            case 2:
                ColorReactionEvent_2?.Invoke(position);
                break;
            case 4:
                ColorReactionEvent_4?.Invoke(position);
                break;
        }
    }
#region Level Event
    public event Action<int> EnterLevelEvent;
    public event Action<int> ExitLevelEvent;
    public void EnterLevel(int level)
    {
        EnterLevelEvent?.Invoke(level);
    }
    public void ExitLevel(int level)
    {
        ExitLevelEvent?.Invoke(level);
    }
    public event Action<int> EnterTinyLevelEvent;
    public event Action<int> ExitTinyLevelEvent;
    public void EnterTinyLevel(int level)
    {
        EnterTinyLevelEvent?.Invoke(level);
    }
    public void ExitTinyLevel(int level)
    {
        ExitTinyLevelEvent?.Invoke(level);
    }
#endregion

#region color reaction event
    public event Action<int , int> AddNewColorReactionEvent;
    public void AddNewColorReaction(int color , int reaction)
    {
        AddNewColorReactionEvent?.Invoke(color , reaction);
    }
    public void RemoveColorReaction_all()
    {
        ColorReactionEvent_1 = null;
        ColorReactionEvent_2 = null;
        ColorReactionEvent_4 = null;
    }

    public event Action<Vector2Int , int> SetCubeColorEvent;
    public void SetCubeColor(Vector2Int position , int color)
    {
        SetCubeColorEvent?.Invoke(position , color);
    }

    public event Action<Vector3Int>  GenerateCubeDouguEvent;
    public void GenerateCubeDougu(Vector3Int position)
    {
        GenerateCubeDouguEvent?.Invoke(position);
    }

    public event Action<Vector3Int> BoomEvent;
    public void Boom(Vector3Int position)
    {
        BoomEvent?.Invoke(position);
    }


    //Íæ¼Òid£¬HPÖµ
    public Action<int,float> OnHPChange;

    public Func<Vector2Int , int> IsPassable;
    public Func<Vector2Int , int> IsEmpty;
}
