using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateMover : MonoBehaviour
{
    public Vector3Int flipDir;
    public Vector3 Target => SpecialLerp();
    public Vector3Int thisCenter => new(Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt(transform.position.y),
            Mathf.RoundToInt(transform.position.z));
    Vector3Int nextCenter;
    Vector3Int moveDir;
    //bool CanTooru => (DeliConfig.tooruTest  ? MateInput.CanTooruY0(CurCenter,nextCenter) : MateInput.CanTooru(nextCenter) )&& !DouguManager.Instance.Has<Block>(nextCenter);
    bool CanTooru => MateInput.CanTooru(thisCenter, nextCenter) && !DouguManager.Instance.Has<Block>(nextCenter);
    //public void SetNextMove
    public void SetNextMove(Vector3Int moveDir)
    {
        this.moveDir = moveDir;
        nextCenter = thisCenter + moveDir;
    }

    Vector3 SpecialLerp()
    {
        if (moveDir == Vector3Int.zero)
            return transform.position;
        if (moveDir.x != 0)
        {
            float restrictX = CanTooru ? nextCenter.x : Mathf.Lerp(thisCenter.x, nextCenter.x, DeliConfig.maxDistanceToCenterWhenBlocked);
            return new Vector3(restrictX,transform.position.y, transform.position.z);
        }
        float restrictZ = CanTooru ? nextCenter.z : Mathf.Lerp(thisCenter.z, nextCenter.z, DeliConfig.maxDistanceToCenterWhenBlocked);
        return new Vector3(transform.position.x, transform.position.y, restrictZ);
    }
    
    public void Move()
    {
        MoveByCurKey(isInput:true);
        #region ResetDeadZone
        foreach(var it in MateInput.dir_vec.Values)
        {
            SetNextMove(it);
            if (IsInDeadZone())
                MoveByCurKey(isInput:false);
        }
        SetNextMove(Vector3Int.zero);
        #endregion
    }

    bool IsInDeadZone()
    {
        if (CanTooru)
            return false;
        if(moveDir.x != 0)
        {
            return Mathf.Abs(transform.position.x - (thisCenter.x + nextCenter.x) / 2f) <= 0.5 - DeliConfig.maxDistanceToCenterWhenBlocked;
        }
        return Mathf.Abs(transform.position.z - (thisCenter.z + nextCenter.z) / 2f) <= 0.5 - DeliConfig.maxDistanceToCenterWhenBlocked;
    }
    void MoveByCurKey(bool isInput)
    {
        if(isInput)
        {
            transform.LookAt(transform.position + moveDir);
            if(moveDir != Vector3.zero)
                flipDir = moveDir;
        }
        transform.position = Vector3.MoveTowards(transform.position, Target, DeliConfig.moveSpeed * Time.deltaTime);
    }
}
