using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent(typeof(Flash))]
[RequireComponent(typeof(ThingCollector))]
public abstract class Entity : MonoBehaviour
{
    float lastTakeDamageTime;
    float maxHealth = 3f;
    float curHealth;
    bool IsTakingDamage => Time.time - lastTakeDamageTime <= DeliConfig.takeDamageInterval;
    public float CurHealth
    {
        get
        {
            return curHealth;
        }
        set
        {
            if (value > maxHealth)
            {
                curHealth = maxHealth;
            }
            else if (value <= 0)
            {
                curHealth = 0;
                
            }
            else
                curHealth = value;
            OnHealthSet();
            if (curHealth <= 0)
                OnHealthZero();
        }
    }
    public float HealthPercent => curHealth / maxHealth;
    protected abstract void OnHealthSet();
    protected abstract void OnHealthZero();

    public virtual void TakeDamage(float damage)
    {
        if (IsTakingDamage)
            return;
        lastTakeDamageTime = Time.time;
        CurHealth -= damage;
    }

    protected virtual void OnEnable()
    {
        lastTakeDamageTime = -DeliConfig.takeDamageInterval;
        CurHealth = maxHealth;
    }
    protected virtual void OnDisable() { }
    protected virtual void Update()
    {
        GetComponent<Flash>().enabled = IsTakingDamage;
    }
}
