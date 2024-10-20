using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MateSelectState:MonoBehaviour
{
    void SetState(MateSelectState newState)
    {
        MateSelectManager.Instance.SetState(newState);
    }

    public MateSelect CurMateSelect
    {
        get => MateSelectManager.Instance.CurMateSelect;
        set
        {
            MateSelectManager.Instance.CurMateSelect = value;
        }
    }
    #region Drag
    Camera cameraMain => Camera.main;
    Vector3 dragDelta;
    Vector3 dragDeltaScreen;
    void AlignPlaneToNormal(GameObject plane, Vector3 normal, Vector3 center)
    {
        plane.transform.position = center;
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);
        plane.transform.rotation = rotation;
    }
    void DrawIntersectionPoint(Vector3 hitPoint)
    {
        UIMate.DrawStraightArrow(CurMateSelect.transform.position,hitPoint);
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere.transform.position = hitPoint;
        //sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // 缩小球的大小
    }
    #endregion
    public virtual void OnEnterState() { }
    public virtual void OnExitState() { }
    public virtual void MyOnMouseDown(MateSelect mateSelect ) {}
    public void MyOnMouseDownTT(MateSelect mateSelect)
    {
        CurMateSelect = mateSelect;
        SetState(gameObject.AddComponent<MateSelectState_Selected>());
    }
    public virtual void MyOnMouseDrag(MateSelect mateSelect) { }
    public void MyOnMouseDragTT(MateSelect mateSelect)
    {
        if (CurMateSelect != mateSelect)
            return;
        SetState(gameObject.AddComponent<MateSelectState_Drag>());
        Vector3 mousePosWorld = cameraMain.ScreenToWorldPoint(new(Input.mousePosition.x, Input.mousePosition.y, 0));
        Ray ray = new(mousePosWorld, cameraMain.transform.forward);
        AlignPlaneToNormal(MateSelectManager.Instance.px, Vector3.right, mateSelect.transform.position);
        AlignPlaneToNormal(MateSelectManager.Instance.pz, Vector3.forward, mateSelect.transform.position);
        float enter;
        Plane plane = new(Vector3.right, mateSelect.transform.position);
        if (plane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            DrawIntersectionPoint(hitPoint);
        }
    }
    public virtual void MyOnMouseUp(MateSelect mateSelect) { }
    public virtual void MyOnMouseUpTT(MateSelect mateSelect)
    {
        if (CurMateSelect != mateSelect)
            return;
        SetState(gameObject.AddComponent<MateSelectState_Moving>());
        UIMate.HideStraightArrow();
        mateSelect.GetComponent<Rigidbody>().AddForce(dragDelta * DeliConfig.DragForce);
    }
    public virtual void Update() { }
    public void UpdateTT()
    {
        if (CurMateSelect == null)
            return;
        SetState(gameObject.AddComponent<MateSelectState_Idle>());
        if (CurMateSelect.GetComponent<Rigidbody>().velocity.magnitude <= 0.1f)
        {
            CurMateSelect = null;
        }
    }
}

public class MateSelectState_Idle : MateSelectState
{
    public override void MyOnMouseDown(MateSelect mateSelect)
    {
        MyOnMouseDownTT(mateSelect);
    }

}
public class MateSelectState_Selected : MateSelectState
{
    public override void OnEnterState()
    {
        UIMate.Instance.OnSelect();
    }
    public override void MyOnMouseDown(MateSelect mateSelect)
    {
        MyOnMouseDownTT(mateSelect);
    }
}
public class MateSelectState_ReadyDrag : MateSelectState
{
    public override void OnEnterState()
    {
        UIMate.Instance.OnDrag();
    }
    public override void MyOnMouseDrag(MateSelect mateSelect)
    {
        MyOnMouseDragTT(mateSelect);
    }
}
public class MateSelectState_Drag : MateSelectState
{
    public override void OnEnterState()
    {
        UIMate.Instance.OnDrag();
    }
    public override void MyOnMouseDrag(MateSelect mateSelect)
    {
        MyOnMouseDragTT(mateSelect);
    }
}
public class MateSelectState_Moving : MateSelectState
{
    public override void Update()
    {
        UpdateTT();
    }
}
public class MateSelectManager : Singleton<MateSelectManager>,IInit
{
    private MateSelect curMateSelect;
    public MateSelect CurMateSelect
    {
        get => curMateSelect;
        set
        {
            if (curMateSelect != null)
                curMateSelect.selected.SetActive(false);
            curMateSelect = value;
            if (curMateSelect != null)
                curMateSelect.selected.SetActive(true);
        }
    }
    public MateSelectState state;
    public void SetState(MateSelectState newState)
    {
        if(state != null)
        {
            DestroyImmediate(state);
            state.OnExitState();
        }
        if(state )
        state = newState;
        state.OnEnterState();
    }
    #region Select
    public void BtSetStateDrag()
    {
        SetState(gameObject.AddComponent<MateSelectState_Drag>());
    }
    #endregion
    #region Drag


    public void BtSetCurPlane(bool isX)
    {
        if(curPlane != null)
            curPlane.SetActive(false);
        curPlane = isX ? px:pz;
        curPlane.SetActive(true);
    }
    public static Vector3 MoveX = new (1f, 0f, 0f);
    public GameObject px;
    public static Vector3 MoveZ = new (0f, 0f, 1f);
    public GameObject pz;
    public GameObject curPlane;
    #endregion
    public void Initialize()
    {
        SetState(gameObject.AddComponent<MateSelectState_Idle>());
        state.CurMateSelect = null;
    }
}
