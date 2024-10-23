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
        return 1;
    }
}
