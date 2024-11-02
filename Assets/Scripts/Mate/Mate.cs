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
    public Vector3 thisCenter => mateMover.thisCenter;
    public Vector3 FlipDir => mateMover.flipDir;
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
        gameObject.SetActive(true);
        ResetDougu();
        lastDouguTime = -DeliConfig.douguUseInterval;
        GetComponent<NewMaterial>().Material.color = mateData.color;
    }
    void HandleInput()
    {
        if(Time.time - lastDouguTime < DeliConfig.douguUseInterval)
        {
            return;
        }
        foreach (var key in MateInput.mate_key_dirs[mateId].Keys)
        {
            if (Input.GetKey(key))
            {
                Vector3 ultiDelta = MateInput.Instance.InputKeyToDir(mateId,key);
                mateMover.SetNextMove(ultiDelta);
                break;
            }
        }
        mateMover.Move();
        foreach(var key in MateInput.Instance.Get_mate_dougu_keys(mateId))
        {
            if (Input.GetKeyDown(key))
            {
                if(OnUseDougu() == Dougu.USED_CD)
                {
                    lastDouguTime = Time.time;
                }
                break;
            }
        }
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
        EventManager.Instance.RefreshUI(this);
    }
    
    int OnUseDougu()
    {
        int ret = onHeadDougu[0].OnUse();
        if (onHeadDougu[0].remainUseCount <= 0)
            RemoveDougu(onHeadDougu[0]);
        return ret;
    }
}
