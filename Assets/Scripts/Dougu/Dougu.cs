using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dougu : MonoBehaviour
{
    public int remainUseCount = 2;
    public virtual void Use()
    {
        remainUseCount--;
    }
}
