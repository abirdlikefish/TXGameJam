using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour,IOnLevelEnterInit
{
    float lastTakeDamageTime;
    public float MaxHealth = 3f;
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
            if(value < curHealth)
            {
                if (Time.time - lastTakeDamageTime <= DeliConfig.Instance.takeDamageInterval)
                    return;
                lastTakeDamageTime = Time.time;
            }
            if (value > MaxHealth)
            {
                curHealth = MaxHealth;
            }
            else if (value <= 0)
            {
                curHealth = 0;
                
            }
            else
                curHealth = value;
            //healthBar.fillAmount = curHealth / MaxHealth;
            if (curHealth <= 0)
                OnHealthZero();
        }
    }
    public Image healthBar;
    public virtual void OnHealthZero()
    {
        //TODO: Die
    }
    public void TakeDamage(float damage)
    {
        CurHealth -= damage;
    }
    public void InitializeOnLevelEnter()
    {
        lastTakeDamageTime = -DeliConfig.Instance.takeDamageInterval;
        CurHealth = MaxHealth;
    }

    public virtual void Update()
    {
        GetComponent<Flash>().enabled = Time.time - lastTakeDamageTime <= DeliConfig.Instance.takeDamageInterval;
    }
}
