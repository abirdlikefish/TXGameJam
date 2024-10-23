using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguBomb : Dougu
{
    [Header("DouguBomb")]
    public int crossRange = 2;
    
    public override int OnUse()
    {
        base.OnUse();
        GameObject go = MyInsBlock(block, user.CurCenter);
        if (go == null)
            return 0;
        go.SetActive(true);
        OnUseEnd();
        return 0;
    }
    public override void OnUseEnd()
    {
        base.OnUseEnd();
    }
}
