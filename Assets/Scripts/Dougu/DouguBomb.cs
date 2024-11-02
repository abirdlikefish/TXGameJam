using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguBomb : Dougu
{
    [Header("DouguBomb")]
    public int crossRange = 2;
    
    public override int OnUse()
    {
        GameObject go = MyInsBlockOrSphere(block.gameObject, user.thisCenter);
        if (go == null)
        {
            return NOT_USED_CD;
        }
        go.SetActive(true);
        remainUseCount--;
        return NOT_USED_CD;
    }
}
