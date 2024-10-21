using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
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
            if (value > MaxHealth)
            {
                curHealth = MaxHealth;
            }
            else if (value <= 0)
            {
                curHealth = 0f;
                OnHealthZero();
            }
            else
                curHealth = value;
            healthBar.fillAmount = curHealth / MaxHealth;
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
}
