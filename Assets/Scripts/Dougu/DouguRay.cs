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
        GameObject go = MyInsEffect(rayEffect0, user.transform.position);
        go.transform.rotation = user.transform.rotation;
        for (int i=1;i<=rayRange;i++)
        {
            go = MyInsEffect(effect, user.transform.position + user.FlipDir * (i - 1), user.transform.position + user.FlipDir * i);

            if (go == null)
            {
                Vector3 dir2 = MateInput.CameraDirInWorld(user.FlipDir);
                Vector3 thisCenter = user.thisCenter + user.FlipDir * (i-1);
                DyeBesideCubeColor(dir2, thisCenter);

                break;
            }    
            go.transform.rotation = user.transform.rotation;
        }
        remainUseCount--;
        return USED_CD;
    }
}
