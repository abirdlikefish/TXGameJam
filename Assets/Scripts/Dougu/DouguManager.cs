using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguManager : Singleton<DouguManager>, IOnGameAwakeInit,IOnLevelEnterInit
{
    public Transform entityP;
    List<Dougu> prefabDougus;
    [SerializeField]
    List<Vector3> blocks;
    [SerializeField]
    List<Vector3> effects;
    public void InitializeOnGameAwake()
    {
        prefabDougus = new();
        for (int i=0;i<transform.childCount;i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            if(go.activeSelf)
            {
                prefabDougus.Add(go.GetComponent<Dougu>());
            }
        }
    }
    public void InitializeOnLevelEnter()
    {
        ClearChild(entityP);
        blocks = new();
        effects = new();
    }


    public void AddBlock(Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        blocks.Add(posY0);
    }
    public void RemoveBlock(Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        blocks.Remove(posY0);
    }
    public void AddEffect(Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        effects.Add(posY0);
    }
    public void RemoveEffect(Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        effects.Remove(posY0);
    }
    void ClearChild(Transform p)
    {
        for (int i = 0; i < p.transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
    }
    public bool HasEntityBlock(Vector3 pos)
    {
        return blocks.Contains(pos);
    }
    public bool HasEffect(Vector3 pos)
    {
        return effects.Contains(pos);
    }
    public T GetDougu<T>() where T : Dougu
    {
        return prefabDougus.Find(d => d is T) as T;
    }

}
