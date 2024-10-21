using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mate : MonoBehaviour
{
    public MateData mateData;
    List<Dougu> onHeadDougu;

    public void Init()
    {
        onHeadDougu.Clear();
    }
    public void AddDougu(Dougu dougu)
    {
        onHeadDougu = new() { dougu };
    }
}
