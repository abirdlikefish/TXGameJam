using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Mate mate = other.gameObject.GetComponent<Mate>();
        if(mate)
        {
            if ((canHurtUser && (mate == douguBase.user)) || mate != douguBase.user)
            {
                other.gameObject.GetComponent<Mate>().TakeDamage(douguBase.damage);
            }
        }
           
        if (other.gameObject.GetComponent<DouguSphere>())
            Destroy(other.gameObject);
    }
    public virtual void OnEnable()
    {
        douguBase.busy.Add(gameObject);
        DouguManager.Instance.AddSth(gameObject);
        DyeUnderCubeColor();
    }

    public virtual void OnDisable()
    {
        douguBase.busy.Remove(gameObject);
        DouguManager.Instance.RemoveSth(gameObject);
    }
    
    public virtual void DyeUnderCubeColor()
    {
    }
    
}
