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
                if (!Dougu.MyInsEffect(Effect, transform.position + dir * (i - 1), transform.position + dir * i))
                {
                    // Vector3Int dir2 = MateInput.CameraDirInWorld(dir);
                    Vector3Int thisCenter = Vector3Int.RoundToInt(transform.position) + dir * (i-1);
                    // douguBase.DyeBesideCubeColor(dir2, thisCenter);
                    douguBase.DyeBesideCubeColor(dir, thisCenter);
                    break;
                }
            }
        }
        Destroy(gameObject);
    }
    
}
