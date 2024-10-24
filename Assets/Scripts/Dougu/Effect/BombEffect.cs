using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : Effect
{
    
    public override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
        if (other.gameObject.GetComponent<BombBlock>())
            other.gameObject.GetComponent<BombBlock>().Explode();
    }
    public override void DyeUnderCubeColor()
    {
        BaseCube cube = CubeGetter.GetCubeCanTooru(CurCenter);
        if (cube == null)
            return;
        douguBase.DyeBase(cube);
    }
}
