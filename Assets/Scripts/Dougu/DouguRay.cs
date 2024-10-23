using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguRay : Dougu
{
    [Header("DouguRay")]
    public int rayRange = 5;
    public RayEffect rayEffect0;
    public RayEffect rayEffect;
    public float effectTime;
    public override int OnUse()
    {
        GameObject go = MyInsEffect(rayEffect0, user.transform.position);
        go.transform.rotation = user.transform.rotation;

        for (int i=1;i<=rayRange;i++)
        {
            go = MyInsEffect(rayEffect, user.transform.position + user.FlipDir * (i - 1), user.transform.position + user.FlipDir * i);

            if (go == null)
            {
                break;
            }    
            go.transform.rotation = user.transform.rotation;
        }
        remainUseCount--;
        OnUseEnd();
        return 1;
    }
    public override void OnUseEnd()
    {
        base.OnUseEnd();
    }
}
