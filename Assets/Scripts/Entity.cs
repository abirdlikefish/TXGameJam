using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent(typeof(Flash))]
public abstract class Entity : MonoBehaviour
{
    float lastTakeDamageTime;
    float maxHealth = 3f;
    float curHealth;
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
        if (Time.time - lastTakeDamageTime <= DeliConfig.Instance.takeDamageInterval)
            return;
        lastTakeDamageTime = Time.time;
        CurHealth -= damage;
    }

    protected virtual void OnEnable()
    {
        lastTakeDamageTime = -DeliConfig.Instance.takeDamageInterval;
        CurHealth = maxHealth;
    }
    protected virtual void OnDisable() { }
    protected virtual void Update()
    {
        GetComponent<Flash>().enabled = Time.time - lastTakeDamageTime <= DeliConfig.Instance.takeDamageInterval;
    }
}
