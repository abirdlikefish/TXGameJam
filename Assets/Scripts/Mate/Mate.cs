using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mate : MonoBehaviour
{
    [SerializeField]
    Vector3 target;
    Vector3 Target
    {
        get => target = SpecialLerp();
    }
    Vector3 thisCenter =>
        new(Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt(transform.position.y),
            Mathf.RoundToInt(transform.position.z));
    Vector3 nextCenter;


    Vector3 moveDir;
    bool canTooru;//ͨ�롡
    public void SetMove(Vector3 moveDir,bool canTooru)
    {
        this.moveDir = moveDir;
        this.canTooru = canTooru;
        nextCenter = thisCenter + moveDir;
    }

    Vector3 SpecialLerp()
    {
        if (moveDir == Vector3.zero)
            return transform.position;
        if (moveDir.x != 0)
        {
            float restrictX = canTooru ? nextCenter.x : Mathf.Lerp(thisCenter.x, nextCenter.x, DeliConfig.Instance.maxDistanceToCenterWhenBlocked);
            return new Vector3(restrictX,transform.position.y, transform.position.z);
        }
        float restrictZ = canTooru ? nextCenter.z : Mathf.Lerp(thisCenter.z, nextCenter.z, DeliConfig.Instance.maxDistanceToCenterWhenBlocked);
        return new Vector3(transform.position.x, transform.position.y, restrictZ);
    }

    public void Move1()
    {
        Move();
        #region ResetDeadZone
        foreach(var it in MateInput.Instance.dir_vec.Values)
        {
            SetMove(it, false);
            if (IsInDeadZone())
                Move();
        }
        SetMove(Vector3.zero, false);
        #endregion
    }

    bool IsInDeadZone()
    {
        if(moveDir.x != 0)
        {
            return Mathf.Abs(transform.position.x - (thisCenter.x + nextCenter.x)/2f) <= 0.5 - DeliConfig.Instance.maxDistanceToCenterWhenBlocked;
        }
        return Mathf.Abs(transform.position.z - (thisCenter.z + nextCenter.z) / 2f) <= 0.5 - DeliConfig.Instance.maxDistanceToCenterWhenBlocked;
    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, DeliConfig.Instance.moveSpeed);
    }
}
