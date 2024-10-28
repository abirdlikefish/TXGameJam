using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerEffect : Effect
{
    public override void DyeUnderCubeColor()
    {
        Vector3 dir = douguBase.user.FlipDir;
        Vector3 dir2 = MateInput.CameraDirInWorld(dir);
        Vector3 thisCenter = douguBase.user.CurCenter;
        BaseCube cube = CubeGetter.GetCubeUpperFloor(dir2,thisCenter);
        if (cube != null)
            douguBase.DyeBase(cube);
    }
}
