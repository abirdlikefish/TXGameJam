using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    float lastTakeDamageTime;
    public float maxHealth = 3f;
    [SerializeField]
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
            //TODO: Send to HealthBar
            UIInGame.Instance.RefreshUI(this as Mate);
            if (curHealth <= 0)
                OnHealthZero();
        }
    }
    public virtual void OnHealthZero()
    {
        //TODO Send to HP 0
    }
    public virtual void TakeDamage(float damage)
    {
        if (Time.time - lastTakeDamageTime <= DeliConfig.Instance.takeDamageInterval)
            return;
        lastTakeDamageTime = Time.time;
        CurHealth -= damage;
    }

    public virtual void OnEnable()
    {
        lastTakeDamageTime = -DeliConfig.Instance.takeDamageInterval;
        CurHealth = maxHealth;
    }

    public virtual void Update()
    {
        GetComponent<Flash>().enabled = Time.time - lastTakeDamageTime <= DeliConfig.Instance.takeDamageInterval;
    }
}
