using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block:MonoBehaviour
{
    public Dougu douguBase;
    public Effect Effect => douguBase.effect;
    public float ExistTime => douguBase.blockExistTime;
    public float existTimer = 0f;
    public void OnEnable()
    {
        douguBase.busy.Add(gameObject);
        DouguManager.Instance.AddBlock(transform.position);
    }

    public void OnDisable()
    {
        douguBase.busy.Remove(gameObject);
        DouguManager.Instance.RemoveBlock(transform.position);
    }
    
}
