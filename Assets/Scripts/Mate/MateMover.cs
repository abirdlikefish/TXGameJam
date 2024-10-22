using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateMover : MonoBehaviour
{
    public Vector3 flipDir;
    public Vector3 Target => SpecialLerp();
    public Vector3 CurCenter => new(Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt(transform.position.y),
            Mathf.RoundToInt(transform.position.z));
    Vector3 nextCenter;
    Vector3 moveDir;
    bool CanTooru => (DeliConfig.tooruTest  ? MateInput.CanTooruY0(CurCenter,nextCenter) : MateInput.CanTooruY0(nextCenter) )&& !DouguManager.Instance.HasEntityBlock(nextCenter);
    //public void SetNextMove
    public void SetNextMove(Vector3 moveDir)
    {
        this.moveDir = moveDir;
        nextCenter = CurCenter + moveDir;
    }

    Vector3 SpecialLerp()
    {
        if (moveDir == Vector3.zero)
            return transform.position;
        if (moveDir.x != 0)
        {
            float restrictX = CanTooru ? nextCenter.x : Mathf.Lerp(CurCenter.x, nextCenter.x, DeliConfig.Instance.maxDistanceToCenterWhenBlocked);
            return new Vector3(restrictX,transform.position.y, transform.position.z);
        }
        float restrictZ = CanTooru ? nextCenter.z : Mathf.Lerp(CurCenter.z, nextCenter.z, DeliConfig.Instance.maxDistanceToCenterWhenBlocked);
        return new Vector3(transform.position.x, transform.position.y, restrictZ);
    }
    
    public void Move()
    {
        MoveByCurKey();
        #region ResetDeadZone
        foreach(var it in MateInput.dir_vec.Values)
        {
            SetNextMove(it);
            if (IsInDeadZone())
                MoveByCurKey();
        }
        SetNextMove(Vector3.zero);
        #endregion
    }

    bool IsInDeadZone()
    {
        if (CanTooru)
            return false;
        if(moveDir.x != 0)
        {
            return Mathf.Abs(transform.position.x - (CurCenter.x + nextCenter.x) / 2f) <= 0.5 - DeliConfig.Instance.maxDistanceToCenterWhenBlocked;
        }
        return Mathf.Abs(transform.position.z - (CurCenter.z + nextCenter.z) / 2f) <= 0.5 - DeliConfig.Instance.maxDistanceToCenterWhenBlocked;
    }
    void MoveByCurKey()
    {
        if(Target != transform.position)
        {
            transform.LookAt(Target);
            flipDir = moveDir;
        }
        transform.position = Vector3.MoveTowards(transform.position, Target, DeliConfig.Instance.moveSpeed * Time.deltaTime);
    }
}
