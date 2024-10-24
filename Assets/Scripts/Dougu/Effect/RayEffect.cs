using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayEffect : Effect
{
    public override void DyeUnderCubeColor()
    {
        BaseCube cube = CubeGetter.GetCubeCanTooru(CurCenter);
        if (cube == null)
            return;
        douguBase.DyeBase(cube);
    }
}
