using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : Effect
{
    int goldFingerFrameTimer;
    int goldFingerFrameTime = 2;

    
    public override void OnEnable()
    {
        base.OnEnable();
        goldFingerFrameTimer = 0;
    }
    public override void Update()
    {
        base.Update();
        goldFingerFrameTimer += 1;
    }
    public override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
        if (DeliConfig.goldFinger || goldFingerFrameTimer < goldFingerFrameTime)
        {
            if (other.gameObject.GetComponent<BombBlock>())
                other.gameObject.GetComponent<BombBlock>().Explode();
        }
            
    }
    public override void DyeUnderCubeColor()
    {
        BaseCube cube = CubeGetter.GetCubeCanTooru(CurCenter);
        if (cube == null)
            return;
        douguBase.DyeBase(cube);
    }
}
