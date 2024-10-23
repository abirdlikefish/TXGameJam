using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguHammer : Dougu
{
    [Header("DouguHammer")]
    public HammerEffect hammerEffect;
    public float effectTime = 0.1f;
    public override int OnUse()
    {
        base.OnUse();
        return 1;
    }
}
