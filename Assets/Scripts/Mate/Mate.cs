using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Mate : Entity
{
    public MateData mateData;
    MateMover MateMover => GetComponent<MateMover>();
    int mateId => transform.GetSiblingIndex();
    public Vector3 CurCenter => GetComponent<MateMover>().CurCenter;
    public Vector3 FlipDir => GetComponent<MateMover>().flipDir;
    public List<Dougu> onHeadDougu = new();
    float lastDouguTime;

    protected override void OnHealthSet()
    {
        UIInGame.Instance.RefreshUI(this);
    }
    protected override void OnHealthZero()
    {
        MateManager.Instance.OnOneDead(this);
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        ResetDougu();
        lastDouguTime = - DeliConfig.Instance.douguUseInterval;
        GetComponent<NewMaterial>().Material.color = mateData.color;
        DouguManager.Instance.AddSth(gameObject);
    }
    protected override void OnDisable()
    {
        DouguManager.Instance.RemoveSth(gameObject);
    }
    protected override void Update()
    {
        base.Update();
        HandleInput();
    }
    void HandleInput()
    {
        if(Time.time - lastDouguTime < DeliConfig.Instance.douguUseInterval)
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
    public void AddDougu(Dougu dougu)
    {
        if (onHeadDougu.Count > 0)
            onHeadDougu[0].remainUseCount = 0;
        dougu.user = this;
        onHeadDougu = new() { dougu };
    }
    public void RemoveDougu(Dougu dougu)
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
        EventManager.Instance.RefreshUI(this);
    }
    
    int OnUseDougu()
    {
        return onHeadDougu[0].OnUse();
    }
}
