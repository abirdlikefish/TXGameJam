using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
public class Mate : Entity
{
    MateMover mateMover;

    public MateData mateData;

    int mateId => transform.GetSiblingIndex();
    public Vector3Int thisCenter => mateMover.thisCenter;
    public Vector3Int FlipDir => mateMover.flipDir;
    [SerializeField]
    List<Dougu> onHeadDougu = new();
    float lastDouguTime;

    protected override void OnHealthSet()
    {
        UIManager.Instance.RefreshMateInLevel(this);
    }
    protected override void OnHealthZero()
    {
        MateManager.Instance.OnOneDead(this);
    }
    private void Awake()
    {
        mateMover = GetComponent<MateMover>();
    }
    protected override void Update()
    {
        base.Update();
        HandleInput();
    }
    public void OnEnterLevel()
    {
        GetComponent<NewMaterial>().Material.color = mateData.color;
    }
    public void OnEnterTinyLevel()
    {
        ResetDougu();
        lastDouguTime = -DeliConfig.douguUseInterval;
    }
    void HandleInput()
    {
        if(Time.time - lastDouguTime < DeliConfig.douguUseInterval)
        {
            return;
        }
        
        

        // foreach (var key in MateInput.mate_key_dirs[mateId].Keys)
        // {
        //     if (Input.GetKey(key))
        //     {
        //         // Vector3 ultiDelta = MateInput.Instance.InputKeyToDir(mateId,key);
        //         Vector3Int ultiDelta = InputManager.Instance.GetInput_move_vector3(mateId);
        //         mateMover.SetNextMove(ultiDelta);
        //         break;
        //     }
        // }
        mateMover.SetNextMove(InputManager.Instance.GetInput_move_vector3(mateId));
        mateMover.Move();
        // InputManager.Instance.GetInput_use(mateId);
        // foreach(var key in MateInput.Instance.Get_mate_dougu_keys(mateId))
        // {
            if (InputManager.Instance.GetInput_use(mateId))
            {
                if(OnUseDougu() == Dougu.USED_CD)
                {
                    lastDouguTime = Time.time;
                }
                // break;
            }
        // }
    }
    public Dougu GetDougu()
    {
        return onHeadDougu[0];
    }
    public void AddDougu(Dougu dougu)
    {
        if (onHeadDougu.Count > 0)
            Destroy(onHeadDougu[0].gameObject);
        dougu.user = this;
        onHeadDougu = new() { dougu };
        UIManager.Instance.RefreshMateInLevel(this);
    }
    void RemoveDougu(Dougu dougu)
    {
        onHeadDougu.Remove(dougu);
        if(onHeadDougu.Count == 0)
        {
            ResetDougu();
        }
    }
    void ResetDougu()
    {
        AddDougu(DouguManager.InsDougu(typeof(DouguBomb),0));
    }
    
    int OnUseDougu()
    {
        int ret = onHeadDougu[0].OnUse();
        if (onHeadDougu[0].remainUseCount <= 0)
            RemoveDougu(onHeadDougu[0]);
        return ret;
    }
}
