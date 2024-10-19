using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateSelectManager : Singleton<MateSelectManager>,IInit
{
    public enum STATE
    {
        IDLE,
        SELECTED,
        READYDRAG,
        DRAGING,
        MOVING,
    }
    public STATE state;
    public STATE State
    {
        get => state;
        set
        {
            state = value;
        }
    }
    MateSelect curMateSelect;
    public MateSelect CurMateSelect
    {
        get => curMateSelect;
        set
        {
            if (curMateSelect == value)
                return;
            if(curMateSelect != null)
            {
                curMateSelect.selected.SetActive(false);
                State = STATE.IDLE;
            }
            curMateSelect = value;
            if(curMateSelect != null)
            {
                curMateSelect.selected.SetActive(true);
                State = STATE.SELECTED;
            }
        }
    }


    public void Initialize()
    {
        curMateSelect = null;
        state = STATE.IDLE;
    }
    public void ButtonSetReadyDrag()
    {
        if(State != STATE.SELECTED)
        {
            Debug.LogError("SetReadyDrag without selected");
            return;
        }
        State = STATE.READYDRAG;
    }
}
