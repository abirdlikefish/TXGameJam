using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DepthSetterEntity))]
public class Effect : MonoBehaviour
{
    public bool canHurtUser = false;
    public Dougu douguBase;
    public float EffectTime => douguBase.effectTime;
    [HideInInspector]
    public float existTimer = 0f;
    public Vector3Int CurCenter => new (Mathf.RoundToInt(transform.position.x), 0, Mathf.RoundToInt(transform.position.z));
    public virtual void Update()
    {
        existTimer += Time.deltaTime;
        if (existTimer >= EffectTime)
        {
            Destroy(gameObject);
        }

    }
    public virtual void OnTriggerStay(Collider other)
    {
        Mate mate = other.GetComponent<Mate>();
        if(mate)
        {
            if ((canHurtUser && (mate == douguBase.user)) || mate != douguBase.user)
            {
                other.gameObject.GetComponent<Mate>().TakeDamage(douguBase.damage);
            }
        }
           
        if (other.GetComponent<DouguSphere>())
        {
            other.GetComponent<DouguSphere>().TryDestroy();
        }
    }
    public virtual void OnEnable()
    {
        douguBase.busy.Add(gameObject);
        StartCoroutine(nameof(DelayDyeUnderCubeColor));
    }

    public virtual void OnDisable()
    {
        douguBase.busy.Remove(gameObject);
    }
    IEnumerator DelayDyeUnderCubeColor()
    {
        yield return 0;
        DyeUnderCubeColor();
    }
    public virtual void DyeUnderCubeColor()
    {
    }
    
}
