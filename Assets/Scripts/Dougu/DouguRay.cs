using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguRay : Dougu
{
    [Header("DouguRay")]
    public int rayRange = 5;
    public RayEffect rayEffect;
    public float effectTime;
    public override bool OnUse()
    {
        base.OnUse();
        Vector3 delta = user.Target - user.CurCenter;
        //MyInsEffect(rayEffect, user.CurCenter);
        for(int i=1;i<=rayRange;i++)
        {
            MyInsEffect(rayEffect, user.CurCenter + delta * (i - 1), user.CurCenter + delta * i);
        }
        OnUseEnd();
        return true;
    }
    public override void OnUseEnd()
    {
        base.OnUseEnd();
    }
}
