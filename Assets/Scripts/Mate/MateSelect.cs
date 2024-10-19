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
        sthover100 = MessageS.Instance.RequestSth("����100��");
        sthless100 = MessageS.Instance.RequestSth("С��100��");
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
        //TODO ������Ӫ��ʾ�Ƿ��ܹ����в���
    }
    Vector3 dragDelta;
    Vector3 dragDeltaScreen;
    //�����קʱ����UI��ͷ����
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
        ////�ҵ���ӽ��Ĵ�������
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
        ////��ȡdragDelta��d�ϵķ���
        //if (minIndex != -1)
        //{
        //    dragDelta = Vector3.Project(dragDelta, tarDir);
        //}


        //dragDelta = Vector3.ClampMagnitude(dragDelta, DeliConfig.DragMaxDistance);

        //UIMate.DrawStraightArrow(dragDelta, transform.position + dragDelta);


    }
    //�ɿ�ʱ�����
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
