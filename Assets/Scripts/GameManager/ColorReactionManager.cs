using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorReactionManager : Singleton<ColorReactionManager>
{
    static List<Action<Vector3Int>> ColorReactionList = new List<Action<Vector3Int>>(){ColorReaction_0 , ColorReaction_1 , ColorReaction_2};
    public static void ColorReaction_0(Vector3Int position)
    {
        EventManager.Instance.RemoveCube(position);
    }

    public static void ColorReaction_1(Vector3Int position)
    {
        EventManager.Instance.GenerateCubeDougu(position);
    }

    public static void ColorReaction_2(Vector3Int position)
    {
        EventManager.Instance.Boom(position);
    }

    public static void AddListener()
    {
        EventManager.Instance.AddNewColorReactionEvent += AddNewColorReaction;
        EventManager.Instance.EnterLevelEvent += (x) => RemoveColorReaction();
    }

    public static void AddNewColorReaction(int color , int reactionID)
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
    public static void RemoveColorReaction()
    {
        EventManager.Instance.RemoveColorReaction_all();
    }
}