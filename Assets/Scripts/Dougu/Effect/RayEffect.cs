using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayEffect : Effect
{
    public DouguRay douguBase => DouguManager.Instance.GetDougu<DouguRay>();
    public float EffectTime => douguBase.effectTime;
    public float effectTimer = 0f;

    private void Update()
    {
        effectTimer += Time.deltaTime;
        if (effectTimer >= EffectTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<Mate>())
            other.gameObject.GetComponent<Mate>().TakeDamage(douguBase.damage);
    }
}
