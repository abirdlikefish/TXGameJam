using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerEffect : Effect
{
    public override void DyeUnderCubeColor()
    {
        Vector3Int dir = douguBase.user.FlipDir;
        // Vector3Int dir2 = MateInput.CameraDirInWorld(dir);
        Vector3Int thisCenter = douguBase.user.thisCenter;
        BaseCube cube = CubeGetter.GetCubeUpperFloor(dir,thisCenter);
        // BaseCube cube = CubeGetter.GetCubeUpperFloor(dir2,thisCenter);
        if (cube != null)
            douguBase.DyeBase(cube);
    }
}
