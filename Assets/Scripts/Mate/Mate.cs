using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mate : Entity
{
    public Vector3 CurCenter => GetComponent<MateMover>().CurCenter;
    public Vector3 FlipDir => GetComponent<MateMover>().flipDir;
    public MateData mateData;
    [SerializeField]
    List<Dougu> onHeadDougu = new();
    

    public void ResetDougu()
    {
        AddDougu(DouguManager.Instance.GetDougu<DouguBomb>());
    }
    public void AddDougu(Dougu dougu)
    {
        dougu.user = this;
        onHeadDougu = new() { Instantiate(dougu, transform) };
    }
    public void OnUseDougu()
    {
        if (onHeadDougu.Count == 0)
        {
            Debug.LogError("use dougu fail");
            ResetDougu();
        }
        onHeadDougu[0].OnUse();
    }
}
