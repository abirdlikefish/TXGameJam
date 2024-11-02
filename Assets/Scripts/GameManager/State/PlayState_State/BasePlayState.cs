using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayState
{
    protected static PlayState playState;
    public virtual void Init(PlayState playState)
    {
        if(BasePlayState.playState == null)
            BasePlayState.playState = playState;
    }

    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }

}
