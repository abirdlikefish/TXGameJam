using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguRay : Dougu
{
    [Header("DouguRay")]
    public int rayRange = 5;
    public RayEffect rayEffect0;
    public override int OnUse()
    {
        base.OnUse();
        GameObject go = MyInsEffect(rayEffect0, user.transform.position);
        go.transform.rotation = user.transform.rotation;
        for (int i=1;i<=rayRange;i++)
        {
            go = MyInsEffect(effect, user.transform.position + user.FlipDir * (i - 1), user.transform.position + user.FlipDir * i);

            if (go == null)
            {
                break;
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
