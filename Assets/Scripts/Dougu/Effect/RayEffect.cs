using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayEffect : Effect
{
    public DouguRay douguBase => DouguManager.Instance.GetDougu<DouguRay>();
    public Collider mycollider;
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
        other.gameObject.GetComponent<Mate>().TakeDamage(douguBase.damage);
    }
    //ÈçºÎ¼ì²âmycolliderµÄOnTriggerStay

}
