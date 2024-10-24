using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public Dougu douguBase;
    public float EffectTime => douguBase.effectTime;
    public float existTimer = 0f;
    Vector3Int curCenter;
    public Vector3Int CurCenter => new(Mathf.RoundToInt(transform.position.x), 0, Mathf.RoundToInt(transform.position.z));
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
        DyeBelowCubeColor();
    }

    public void OnDisable()
    {
        douguBase.busy.Remove(gameObject);
        DouguManager.Instance.RemoveEffect(this);
    }
    public virtual void DyeBelowCubeColor()
    {
        BaseCube cube = Test.GetCubeCanTooru(CurCenter);
        if (cube == null)
            return;
        douguBase.DyeBase(cube);
    }
    
}
