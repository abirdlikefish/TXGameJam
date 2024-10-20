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

    Camera cameraMain => Camera.main;

    void AlignPlaneToNormal(GameObject plane, Vector3 normal, Vector3 center)
    {
        plane.transform.position = center;
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);
        plane.transform.rotation = rotation;
    }
    void DrawIntersectionPoint(Vector3 hitPoint)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = hitPoint;
        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // 缩小球的大小
    }
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


        Vector3 mousePosWorld = cameraMain.ScreenToWorldPoint(new(Input.mousePosition.x, Input.mousePosition.y,0));
        Ray ray = new (mousePosWorld, cameraMain.transform.forward);
        AlignPlaneToNormal(MateSelectManager.Instance.px, Vector3.right, transform.position);
        AlignPlaneToNormal(MateSelectManager.Instance.pz, Vector3.forward, transform.position);
        float enter;
        Plane plane = new (Vector3.right, transform.position);
        if (plane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            DrawIntersectionPoint(hitPoint);
        }

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
