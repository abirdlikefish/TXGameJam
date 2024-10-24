using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mate : Entity
{
    public MateData mateData;
    public MateMover MateMover => GetComponent<MateMover>();
    public int mateId => transform.GetSiblingIndex();
    public Vector3 CurCenter => GetComponent<MateMover>().CurCenter;
    // public Vector3 CurCenter => MateMover.CurCenter;
    public Vector3 FlipDir => GetComponent<MateMover>().flipDir;
    [SerializeField]
    List<Dougu> onHeadDougu = new();


    public float lastDouguTime;
    
    public override void OnEnable()
    {
        base.OnEnable();
        lastDouguTime = - DeliConfig.Instance.douguInterval;
    }
    public override void Update()
    {
        base.Update();
        HandleInput();
    }
    public void HandleInput()
    {
        if(Time.time - lastDouguTime < DeliConfig.Instance.douguInterval)
        {
            return;
        }
        foreach (var key in MateInput.Instance.mate_key_dirs[mateId].Keys)
        {
            if (Input.GetKey(key))
            {
                Vector3 ultiDelta = MateInput.Instance.InputKeyToDir(mateId,key);
                MateMover.SetNextMove(ultiDelta);
                break;
            }
        }
        MateMover.Move();
        foreach(var key in MateInput.Instance.Get_mate_dougu_keys(mateId))
        {
            if (Input.GetKeyDown(key))
            {
                if(OnUseDougu() == 1)
                {
                    lastDouguTime = Time.time;
                }
                break;
            }
        }
    }
    public void ResetDougu()
    {
        AddDougu(DouguManager.Instance.GetDougu<DouguHammer>());
    }
    public void AddDougu(Dougu dougu)
    {
        dougu.Init(this);
        onHeadDougu = new() { Instantiate(dougu, transform) };
    }
    public int OnUseDougu()
    {
        if (onHeadDougu.Count == 0)
        {
            ResetDougu();
        }
        return onHeadDougu[0].OnUse();
    }
}
