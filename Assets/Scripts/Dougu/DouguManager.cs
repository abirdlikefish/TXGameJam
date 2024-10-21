using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguManager : Singleton<DouguManager>, IOnGameAwakeInit
{
    List<Dougu> prefabDougus;
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

    public static bool Hit(Vector3 from,Vector3 to)
    {
        return false;
    }
    public T GetDougu<T>() where T : Dougu
    {
        return prefabDougus.Find(d => d is T) as T;
    }
}
