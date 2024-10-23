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
                    {
                        Vector3 dir2 = MateInput.CameraDirInWorld(dir);
                        Vector3 nextCenter = transform.position + dir * i;
                        Debug.Log($"{dir2} L{Test.GetNodeL(nextCenter)} R{Test.GetNodeR(nextCenter)}");
                        if( ((dir2 == new Vector3(1,0,0) || dir2 == new Vector3(0,0,-1)) && Test.GetNodeR(nextCenter) == 2)
                            ||
                            ((dir2 == new Vector3(-1, 0, 0) || dir2 == new Vector3(0, 0, 1)) && Test.GetNodeL(nextCenter) == 1))
                        {
                            Debug.Log($"!!!{nextCenter}");
                            douguBase.effect.DyeBesideCudeColor(dir,Vector3Int.RoundToInt(nextCenter));
                        }
                        break;
                    }
                        
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