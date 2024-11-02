using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguMiniCube : Dougu
{
    [Header("DouguMiniCube")]
    public MiniCubeEffect miniCubeEffect;
    public override int OnUse()
    {
        Vector3Int thisCenter = user.thisCenter;
        Vector3Int nextCenter = user.thisCenter + user.FlipDir;
        Vector3Int newPos;
        //BaseCube lowerCube = CubeGetter.GetCubeLowerFloor(MateInput.CameraDirInWorld(user.FlipDir), nextCenter);
        
        if (MateInput.CanTooru(thisCenter, nextCenter))
        {
            BaseCube besideCube = CubeGetter.GetCubeCanTooru(nextCenter);
            newPos = Vector3Int.RoundToInt(besideCube.Position + Vector3.up);
            //TODO EventManager.Instance.AddCube(newPos,CID);
        }
        else
        {
            //if (lowerCube != CubeGetter.GetCubeCanTooru(user.CurCenter))
            {
               newPos = Vector3Int.RoundToInt(CubeGetter.GetCubeCanTooru(thisCenter).Position + user.FlipDir);
                //TODO EventManager.Instance.AddCube(newPos, CID);
            }
        }
        remainUseCount--;
        return NOT_USED_CD;
    }
}
