using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorReactionManager
{
    private static ColorReactionManager instance;
    public static ColorReactionManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new ColorReactionManager();
            }
            return instance;
        }
    }
    // List<Action<Vector3Int>> ColorReactionList = new List<Action<Vector3Int>>(){ColorReaction_0 , ColorReaction_1 , ColorReaction_2};
    List<Action<Vector3Int>> ColorReactionList ;
    public void ColorReaction_0(Vector3Int position)
    {
        EventManager.Instance.RemoveCube(position);
    }

    public void ColorReaction_1(Vector3Int position)
    {
        EventManager.Instance.GenerateCubeDougu(position);
    }

    public void ColorReaction_2(Vector3Int position)
    {
        EventManager.Instance.Boom(position);
    }

    public static void AddListener()
    {
        EventManager.Instance.AddNewColorReactionEvent += Instance.AddNewColorReaction;
        EventManager.Instance.EnterLevelEvent += (x) => Instance.RemoveColorReaction();
        Instance.ColorReactionList = new List<Action<Vector3Int>>(){Instance.ColorReaction_0 , Instance.ColorReaction_1 , Instance.ColorReaction_2};
    }

    public void AddNewColorReaction(int color , int reactionID)
    {
        switch (color)
        {
            case 1:
                EventManager.Instance.ColorReactionEvent_1 += ColorReactionList[reactionID];
                break;
            case 2:
                EventManager.Instance.ColorReactionEvent_2 += ColorReactionList[reactionID];
                break;
            case 4:
                EventManager.Instance.ColorReactionEvent_4 += ColorReactionList[reactionID];
                break;
        }
    }
    public void RemoveColorReaction()
    {
        EventManager.Instance.RemoveColorReaction_all();
    }
}