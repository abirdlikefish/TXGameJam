using System;
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

    public event Action<Vector3Int , int> AddCubeEvent_before;
    public event Func<Vector3Int ,  int, bool> AddCubeEvent_on;
    public event Action<bool> AddCubeEvent_after;
    public void AddCube(Vector3Int position , int color)
    {
        AddCubeEvent_before?.Invoke(position , color);
        bool isSucceed = AddCubeEvent_on?.Invoke(position,color) ?? false;
        AddCubeEvent_after?.Invoke(isSucceed);
    }
    public void AddCube(Vector3Int position)
    {
        AddCube(position , 0);
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
            case 3:
                ColorReactionEvent_1?.Invoke(position);
                break;
            case 5:
                ColorReactionEvent_2?.Invoke(position);
                break;
            case 6:
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
        ExitState(1);
    }


    public event Action<int> EnterTinyLevelEvent_bef;
    public event Action<int> EnterTinyLevelEvent;
    public event Action ExitTinyLevelEvent;
    // public void EnterTinyLevel()
    public void EnterTinyLevel_bef(int level)
    {
        EnterTinyLevelEvent_bef?.Invoke(level);
        // EnterTinyLevelEvent?.Invoke(level);
    }
    // public void EnterTinyLevel(int level)
    public void EnterTinyLevel(int level)
    {
        Debug.Log($"{nameof(EnterTinyLevel)} {level}");
        EnterTinyLevelEvent?.Invoke(level);
    }
    public void ExitTinyLevel()
    {
        Debug.Log(nameof(ExitTinyLevel));
        ExitTinyLevelEvent?.Invoke();
        ExitState(0);
    }

    public event Action<int> ExitStateEvent;
    public void ExitState(int num)
    {
        ExitStateEvent?.Invoke(num);
    }

    public event Action ShowInputNameUIEvent;
    public void ShowInputNameUI()
    {
        ShowInputNameUIEvent?.Invoke();
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

    public event Action<Vector3Int>  GenerateDouguSphereMiniCubeEvent;
    public void GenerateDouguSphereMiniCube(Vector3Int position)
    {
        GenerateDouguSphereMiniCubeEvent?.Invoke(position);
    }
    public void GenerateRandomDouguSphere()
    {
        DouguManager.Instance.GenerateRandomDouguSphere();
    }
    public event Action<Vector3Int> BoomEvent;
    public void GenerateBoom(Vector3Int position)
    {
        BoomEvent?.Invoke(position);
    }
    #endregion


    //���id��HPֵ
    public Action<int,float> OnHPChange;

    public Func<Vector2Int , int> IsPassable;
    public Func<Vector2Int , int> IsEmpty;

    public event Action<Type, Vector3,int> GenerateDouguSphereEvent;
    public void GenerateDouguSphere(Type type, Vector3 pos, int colorId)
    {
        GenerateDouguSphereEvent?.Invoke(type, pos, colorId);
    }

    //TODO 困住3s后结束本局
    public event Action<Mate> StartTrapEvent;
    public void StartTrap(Mate mate)
    {
        StartTrapEvent?.Invoke(mate);
    }

    public event Action<Mate> refreshUIEvent;

    public void RefreshUI(Mate mate)
    {
        refreshUIEvent?.Invoke(mate);
    }

    /// <summary>
    /// 胜利时执行的事件
    /// </summary>
    public event Action<Mate> winningEvent;

    public void Winning(Mate mate)
    {
        winningEvent?.Invoke(mate);
    }
    public event Action<int, Vector3> SetMatePosEvent;
    public void SetMatePos(int id, Vector3 position)
    {
        SetMatePosEvent?.Invoke(id, position);
    }

    public event Action ShowMainMenuEvent;
    public void ShowMainMenu()
    {
        ShowMainMenuEvent?.Invoke();
        // Debug.Log("ShowMainMenu Event");
    }

    public event Action SaveCurrentMapEvent_beg;
    public event Action<List<Vector3Int>> SaveCurrentMapEvent;
    public void SaveCurrentMap_beg()
    {
        SaveCurrentMapEvent_beg?.Invoke();
    }
    public void SaveCurrentMap(List<Vector3Int> cubeList)
    {
        SaveCurrentMapEvent?.Invoke(cubeList);
    }


    public event Action ShowHeadLineMapEvent;
    public void ShowHeadLineMap()
    {
        ShowHeadLineMapEvent?.Invoke();
    }

    public event Action HideHeadLineMapEvent;
    public void HideHeadLineMap()
    {
        HideHeadLineMapEvent?.Invoke();
    }

}
