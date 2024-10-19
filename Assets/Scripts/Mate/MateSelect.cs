using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateSelect : MonoBehaviour
{
    
    public GameObject selected;
    private void OnMouseDown()
    {
        if (MateSelectManager.Instance.State != MateSelectManager.STATE.IDLE)
            return;
        MateSelectManager.Instance.CurMateSelect = this;
        //TODO ������Ӫ��ʾ�Ƿ��ܹ����в���
    }
    Vector3 dragDelta;
    //�����קʱ����UI��ͷ����
    private void OnMouseDrag()
    {
        if(MateSelectManager.Instance.CurMateSelect != this)
            return;
        if(MateSelectManager.Instance.State != MateSelectManager.STATE.READYDRAG && MateSelectManager.Instance.State != MateSelectManager.STATE.DRAGING)
            return;
        MateSelectManager.Instance.State = MateSelectManager.STATE.DRAGING;
        dragDelta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dragDelta = new(dragDelta.x, dragDelta.y, 0);
        dragDelta = Vector3.ClampMagnitude(dragDelta, DeliConfig.DragMaxDistance);

        UIMate.DrawStraightArrow(transform.position, transform.position + dragDelta);
    }
    //�ɿ�ʱ�����
    private void OnMouseUp()
    {
        if (MateSelectManager.Instance.CurMateSelect != this)
            return;
        if (MateSelectManager.Instance.State != MateSelectManager.STATE.DRAGING)
            return;
        MateSelectManager.Instance.State = MateSelectManager.STATE.MOVING;
        UIMate.HideStraightArrow();
        GetComponent<Rigidbody>().AddForce(dragDelta * DeliConfig.DragForce);
    }
    private void Update()
    {
        if (MateSelectManager.Instance.CurMateSelect != this)
            return;
        if (MateSelectManager.Instance.State != MateSelectManager.STATE.MOVING)
            return;
        if (GetComponent<Rigidbody>().velocity.magnitude <= 0.1f)
        {
            MateSelectManager.Instance.CurMateSelect = null;
        }
    }
}
