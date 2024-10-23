using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : Effect
{
    public DouguBomb douguBase => DouguManager.Instance.GetDougu<DouguBomb>();
    public float EffectTime => douguBase.effectTime;
    public float existTimer = 0f;

    private void Update()
    {
        existTimer += Time.deltaTime;
        if (existTimer >= EffectTime)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<BombEntity>())
            other.gameObject.GetComponent<BombEntity>().Explode();
        if (other.gameObject.GetComponent<Mate>())
            other.gameObject.GetComponent<Mate>().TakeDamage(douguBase.damage);
    }
}
