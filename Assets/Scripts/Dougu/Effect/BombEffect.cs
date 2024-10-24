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
    public override void DyeCubeColor()
    {
        BaseCube cube = Test.GetCubeCanTooru(CurCenter);
        if (cube == null)
            return;
        cube.GetComponent<NewMaterial>().Material.color = Color.red;
    }
}
