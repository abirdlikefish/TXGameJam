using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public DouguBomb douguBase => DouguManager.Instance.GetDougu<DouguBomb>();
    public float existTime => douguBase.explosionExistTime;
    public float existTimer = 0f;

    private void Update()
    {
        existTimer += Time.deltaTime;
        if (existTimer >= existTime)
        {
            Destroy(gameObject);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Mate>())
            other.gameObject.GetComponent<Mate>().TakeDamage(douguBase.damage);
        
    }
}
