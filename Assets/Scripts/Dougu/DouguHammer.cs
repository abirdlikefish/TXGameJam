using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguHammer : Dougu
{
    public override int OnUse()
    {
        GameObject go = MyInsEffectHammer(effect,user.thisCenter + user.FlipDir);
        go.transform.rotation = user.transform.rotation;
        remainUseCount--;
        return 1;
    }
}
