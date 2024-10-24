using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguMiniCube : Dougu
{
    [Header("DouguMiniCube")]
    public MiniCubeEffect miniCubeEffect;
    public override int OnUse()
    {
        base.OnUse();
        Vector3 thisCenter = user.CurCenter;
        Vector3 nextCenter = user.CurCenter + user.FlipDir;
        Vector3Int newPos;
        BaseCube lowerCube = CubeGetter.GetCubeLowerFloor(MateInput.CameraDirInWorld(user.FlipDir), nextCenter);
        
        if (MateInput.CanTooruY0(thisCenter, nextCenter))
        {
            BaseCube besideCube = CubeGetter.GetCubeCanTooru(nextCenter);
            newPos = Vector3Int.RoundToInt(besideCube.Position + Vector3.up);
            EventManager.Instance.AddCube(newPos);
        }
        else
        {
            //if (lowerCube != CubeGetter.GetCubeCanTooru(user.CurCenter))
            {
               newPos = Vector3Int.RoundToInt(CubeGetter.GetCubeCanTooru(thisCenter).Position + user.FlipDir);
               EventManager.Instance.AddCube(newPos);
            }
        }
        return 1;
    }
}
