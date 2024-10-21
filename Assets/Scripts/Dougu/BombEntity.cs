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
        //让c的a值在0-0.5之间变化
        Color c = GetComponent<MeshRenderer>().materials[1].GetColor("_Diffuse");
        c.a = Mathf.PingPong(Time.time, 0.5f);
        GetComponent<MeshRenderer>().materials[1].SetColor("_Diffuse", c);
        existTimer += Time.deltaTime;
        if (existTimer >= existTime)
        {
            Dougu.MyIns(explosion,transform.position);
            foreach(var dir in Dougu.Dirs)
            {
                for(int i=1;i<= crossRange;i++)
                {
                    if (!Dougu.MyIns(explosion, transform.position + dir * i))
                        break;
                }
            }
            Destroy(gameObject);
        }
    }
    
}
