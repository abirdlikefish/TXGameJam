using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MessageS:Singleton<MessageS>
{
    public Func<string,int> RequestSth;
}

public class Requester:MonoBehaviour
{
    private int sthover100;
    private int sthless100;
    void Request()
    {
        sthover100 = MessageS.Instance.RequestSth("大于100！");
        sthless100 = MessageS.Instance.RequestSth("小于100！");
    }
}

public class Teller:MonoBehaviour
{
    void Tell()
    {
        MessageS.Instance.RequestSth += (string condition) => { return 111; };
    }
}
public class MateSelect : MonoBehaviour
{
    public GameObject selected;
    MateSelectManager.STATE State
    {
        get => MateSelectManager.Instance.State;
        set
        {
            MateSelectManager.Instance.State = value;
        }
    }
    MateSelect CurMateSelect
    {
        get => MateSelectManager.Instance.CurMateSelect;
        set
        {
            MateSelectManager.Instance.CurMateSelect = value;
        }
    }
    Vector3 MoveX => MateSelectManager.MoveX;
    Vector3 MoveY => MateSelectManager.MoveY;

    Camera main => Camera.main;
    private void OnMouseDown()
    {
        if (State != MateSelectManager.STATE.IDLE && State != MateSelectManager.STATE.SELECTED)
            return;
        CurMateSelect = this;
        //TODO 依据阵营显示是否能够进行操作
    }
    Vector3 dragDelta;
    Vector3 dragDeltaScreen;
    //鼠标拖拽时绘制UI箭头方向
    private void OnMouseDrag()
    {
        if(CurMateSelect != this)
            return;
        if(State != MateSelectManager.STATE.READYDRAG && State != MateSelectManager.STATE.DRAGING)
            return;
        State = MateSelectManager.STATE.DRAGING;

        

        //Vector3 mateScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        //SetZToZero(ref mateScreenPos);
        //dragDelta = mouseWorld - transform.position;
        //dragDeltaScreen = Camera.main.WorldToScreenPoint(dragDelta);
        //SetZToZero(ref dragDeltaScreen);
        //Vector3[] magnetDir = new[] { MoveX, -MoveX, MoveY, -MoveY };
        ////找到最接近的磁铁方向
        //float minAngle = 360;
        //int minIndex = -1;
        //Vector3 tarDir =Vector3.left;
        //for (int i = 0; i < magnetDir.Length; i++)
        //{
        //    Vector3 tempDirScreen = Camera.main.WorldToScreenPoint(magnetDir[i]) - Camera.main.WorldToScreenPoint(Vector3.zero);
        //    SetZToZero(ref tempDirScreen);
        //    float angle = Vector3.Angle(dragDeltaScreen, tempDirScreen);
        //    if (angle < minAngle)
        //    {
        //        minAngle = angle;
        //        minIndex = i;
        //        tarDir = tempDirScreen;
        //    }
        //}
        ////获取dragDelta在d上的分量
        //if (minIndex != -1)
        //{
        //    dragDelta = Vector3.Project(dragDelta, tarDir);
        //}


        //dragDelta = Vector3.ClampMagnitude(dragDelta, DeliConfig.DragMaxDistance);

        //UIMate.DrawStraightArrow(dragDelta, transform.position + dragDelta);


    }
    //松开时添加力
    private void OnMouseUp()
    {
        if (CurMateSelect != this)
            return;
        if (State != MateSelectManager.STATE.DRAGING)
            return;
        State = MateSelectManager.STATE.MOVING;
        UIMate.HideStraightArrow();
        GetComponent<Rigidbody>().AddForce(dragDelta * DeliConfig.DragForce);
    }
    private void Update()
    {
        if (CurMateSelect != this)
            return;
        if (State != MateSelectManager.STATE.MOVING)
            return;
        if (GetComponent<Rigidbody>().velocity.magnitude <= 0.1f)
        {
            CurMateSelect = null;
        }
    }
    Vector3 SetZToZero(ref Vector3 v)
    {
        return v = new Vector3(v.x, v.y, 0);
    }
}
