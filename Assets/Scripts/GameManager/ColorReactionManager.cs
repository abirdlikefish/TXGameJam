using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorReactionManager : IColorReactionManager
{
    private static ColorReactionManager instance;
    public static IColorReactionManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new ColorReactionManager();
                instance.Init();
            }
            return instance;
        }
    }
    private void Init()
    {
        instance.ColorReactionList = new List<Action<Vector3Int>>(){instance.ColorReaction_0 , instance.ColorReaction_1 , instance.ColorReaction_2};
        instance.ColorReaction = new List<Action<Vector3Int>>(8);
    }

    private List<Action<Vector3Int>> ColorReactionList ;
    private void ColorReaction_0(Vector3Int position)
    {
        MapManager.Instance.RemoveCube(position);
    }

    private void ColorReaction_1(Vector3Int position)
    {
        EventManager.Instance.GenerateDouguSphereMiniCube(position);
    }

    private void ColorReaction_2(Vector3Int position)
    {
        EventManager.Instance.GenerateBoom(position);
    }


    private List<Action<Vector3Int>> ColorReaction ;
    public void InvokeColorReaction(int color , Vector3Int position)
    {
        ColorReaction[color].Invoke(position);
    }

    // public static void AddListener()
    // {
    //     EventManager.Instance.AddNewColorReactionEvent += Instance.AddNewColorReaction;
    //     EventManager.Instance.EnterLevelEvent += (x) => Instance.RemoveColorReaction();
    //     Instance.ColorReactionList = new List<Action<Vector3Int>>(){Instance.ColorReaction_0 , Instance.ColorReaction_1 , Instance.ColorReaction_2};
    // }

    public void AddNewColorReaction(int color , int reactionID)
    {
        ColorReaction[color] += ColorReactionList[reactionID];
        // switch (color)
        // {
        //     case 3:
        //         EventManager.Instance.ColorReactionEvent_1 += ColorReactionList[reactionID];
        //         break;
        //     case 5:
        //         EventManager.Instance.ColorReactionEvent_2 += ColorReactionList[reactionID];
        //         break;
        //     case 6:
        //         EventManager.Instance.ColorReactionEvent_4 += ColorReactionList[reactionID];
        //         break;
        // }
    }
    public void CleanColorReaction()
    {
        // EventManager.Instance.RemoveColorReaction_all();
        ColorReaction.Clear();
    }
}