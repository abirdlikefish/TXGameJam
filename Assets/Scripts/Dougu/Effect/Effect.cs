using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public Dougu douguBase;
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
    public virtual void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Mate>())
            other.gameObject.GetComponent<Mate>().TakeDamage(douguBase.damage);
    }
    public void OnEnable()
    {
        douguBase.busy.Add(gameObject);
        DouguManager.Instance.AddEffect(this);
    }

    public void OnDisable()
    {
        douguBase.busy.Remove(gameObject);
        DouguManager.Instance.RemoveEffect(this);
    }

}
