using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BombEntity : MonoBehaviour
{
    public DouguBomb douguBase => DouguManager.Instance.GetDougu<DouguBomb>();
    float existTime => douguBase.entityExistTime;
    float existTimer = 0f;
    int crossRange => douguBase.crossRange;
    GameObject explosion => douguBase.explosion;
    
    private void Update()
    {
        existTimer += Time.deltaTime;
        if (existTimer >= existTime)
        {
            Explode();
        }
    }
    public void Explode()
    {
        Dougu.MyInsEffect(explosion, transform.position);
        foreach (var dir in Dougu.Dirs)
        {
            for (int i = 1; i <= crossRange; i++)
            {
                if (!Dougu.MyInsEffect(explosion, transform.position + dir * i))
                    break;
            }
        }
        Destroy(gameObject);
    }
    
}
