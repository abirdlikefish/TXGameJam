using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguBomb : Dougu
{
    [Header("DouguBomb")]
    public int crossRange = 2;
    public Block bombEntity;
    public float entityExistTime = 2f;
    public BombEffect explosion;
    public float effectTime = 0.5f;
    public override bool OnUse()
    {
        base.OnUse();
        GameObject go = MyInsBlock(bombEntity, user.CurCenter);
        if (go == null)
            return false;
        go.SetActive(true);
        OnUseEnd();
        return true;
    }
    public override void OnUseEnd()
    {
        base.OnUseEnd();
    }
}
