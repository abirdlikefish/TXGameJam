using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BombBlock : Block
{
    
    public int crossRange = 2;
    bool exploded = false;
    private void Update()
    {
        existTimer += Time.deltaTime;
        if (existTimer >= ExistTime)
        {
            Explode();
        }
    }
    public void Explode()
    {
        if(exploded)
            return;
        exploded = true;
        Dougu.MyInsEffect(Effect, transform.position);
        foreach (var dir in Dougu.Dirs)
        {
            for (int i = 1; i <= crossRange; i++)
            {
                if (DeliConfig.tooruTest)
                {
                    if (!Dougu.MyInsEffect(Effect, transform.position + dir * (i - 1), transform.position + dir * i))
                        break;
                }
                else
                {
                    if (!Dougu.MyInsEffect(Effect, transform.position + dir * i))
                        break;
                }
            }
        }
        Destroy(gameObject);
    }
    
}
