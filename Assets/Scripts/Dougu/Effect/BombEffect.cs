using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BombEffect : Effect
{
    
    public override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
        if (other.gameObject.GetComponent<BombBlock>())
            other.gameObject.GetComponent<BombBlock>().Explode();
    }

}
