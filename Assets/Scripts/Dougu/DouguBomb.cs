using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguBomb : Dougu
{
    [Header("DouguBomb")]
    public int crossRange = 2;
    public GameObject bombEntity;
    public float entityExistTime = 2f;
    public GameObject explosion;
    public float explosionExistTime = 0.5f;
    public override bool OnUse()
    {
        if (!MyIns(bombEntity, user.CurCenter))
            return false;
        GameObject go = MyIns(bombEntity, user.CurCenter);
        go.SetActive(true);
        OnUseEnd();
        return true;
    }
    public override void OnUseEnd()
    {
        base.OnUseEnd();
    }
}
