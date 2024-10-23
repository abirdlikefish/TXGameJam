using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : Effect
{
    
    public override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
        if (other.gameObject.GetComponent<BombEntity>())
            other.gameObject.GetComponent<BombEntity>().Explode();
    }
    public override void DyeCubeColor()
    {
        BaseCube cube = Test.GetCubeCanTooru(CurCenter);
        if (cube == null)
            return;
        cube.GetComponent<NewMaterial>().Material.color = Color.red;
    }
}
