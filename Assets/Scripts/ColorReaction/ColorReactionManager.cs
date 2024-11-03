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
        instance.ColorReaction = new List<Action<Vector3Int>>();
        for(int i = 0 ; i < 8 ; i ++)
        {
            instance.ColorReaction.Add(null);
        }
        // if(ColorReactionList[0] == null);
        // ColorReaction[6] += ColorReactionList[0];
    }

    private List<Action<Vector3Int>> ColorReactionList ;
    private void ColorReaction_0(Vector3Int position)
    {
        MapManager.Instance.RemoveCube(position);
    }

    private void ColorReaction_1(Vector3Int position)
    {
        DouguManager.Instance.GenerateDouguSphere(typeof(DouguMiniCube),position,0);
    }

    private void ColorReaction_2(Vector3Int position)
    {
        DouguManager.GenerateInstantBoom(position);
    }


    private List<Action<Vector3Int>> ColorReaction ;
    public void InvokeColorReaction(int color , Vector3Int position)
    {
        ColorReaction[color]?.Invoke(position);
    }

    public void AddNewColorReaction(int color , int reactionID)
    {
        Debug.Log("AddNewColorReaction" + color + " " + reactionID);
        ColorReaction[color] += ColorReactionList[reactionID];
    }
    public void CleanColorReaction()
    {
        // EventManager.Instance.RemoveColorReaction_all();
        ColorReaction.Clear();
        for(int i = 0 ; i < 8 ; i ++)
        {
            instance.ColorReaction.Add(null);
        }
    }
}