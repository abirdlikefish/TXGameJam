using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mate : Entity
{
    public Vector3 CurCenter => new(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
    public Vector3 InputDir => GetComponent<MateMover>().InputDir;

    public MateData mateData;
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
