using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguRay : Dougu
{
    [Header("DouguRay")]
    public int rayRange = 5;
    public RayEffect rayEffect;
    public float effectTime;
    public override int OnUse()
    {
        //MyInsEffect(rayEffect, user.CurCenter);
        for(int i=1;i<=rayRange;i++)
        {
            GameObject go = MyInsEffectRay(rayEffect, user.transform.position + user.FlipDir * (i - 1), user.transform.position + user.FlipDir * i);

            if (go == null)
            {
                if (i > 1)
                {
                    remainUseCount--;
                    break;
                }
                else
                    return 0;
            }    
            go.transform.rotation = user.transform.rotation;
        }
        OnUseEnd();
        return 1;
    }
    public override void OnUseEnd()
    {
        base.OnUseEnd();
    }
}
