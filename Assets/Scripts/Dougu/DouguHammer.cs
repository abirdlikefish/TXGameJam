using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguHammer : Dougu
{
    public override int OnUse()
    {
        base.OnUse();
        GameObject go = MyInsEffectHammer(effect,user.CurCenter + user.FlipDir);
        go.transform.rotation = user.transform.rotation;
        Vector3 dir2 = MateInput.CameraDirInWorld(user.FlipDir);
        Vector3 nextCenter = user.CurCenter + user.FlipDir;
        DyeBesideCudeColor(dir2, nextCenter);
        return 1;
    }
}
