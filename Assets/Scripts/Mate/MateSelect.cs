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
        //TODO 依据阵营显示是否能够进行操作
    }
    Vector3 dragDelta;
    //鼠标拖拽时绘制UI箭头方向
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
    //松开时添加力
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
