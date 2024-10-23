using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block:MonoBehaviour
{
    public void OnEnable()
    {
        DouguManager.Instance.AddBlock(transform.position);
    }

    public void OnDisable()
    {
        DouguManager.Instance.RemoveBlock(transform.position);
    }
}
