using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DouguManager : Singleton<DouguManager>
{
    string rPath = "Prefabs/Dougu";
    public Transform entityP;
    [SerializeField]
    List<Dougu> prefabDougus;
    [SerializeField]
    List<Vector3> blocks;
    [SerializeField]
    List<Effect> effects;
    public override void Init()
    {
        prefabDougus = Resources.LoadAll<Dougu>(rPath).ToList();
        EventManager.Instance.ExitLevelEvent += OnEnterSmallLevel;
    }
    public void OnEnterSmallLevel()
    {
        ClearChild(entityP);
        blocks = new();
        effects = new();
    }


    public void AddBlock(Vector3 posY0)
    {
        blocks.Add(posY0);
    }
    public void RemoveBlock(Vector3 posY0)
    {
        blocks.Remove(posY0);
    }
    public void AddEffect(Effect effect)
    {
        effects.Add(effect);
    }
    public void RemoveEffect(Effect effect)
    {
        effects.Remove(effect);
    }
    void ClearChild(Transform p)
    {
        for (int i = 0; i < p.transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
    }
    public bool HasBlock(Vector3 posY0)
    {
        return blocks.Contains(posY0);
    }
    //public bool HasEffect(Vector3 posY0, Type type)
    //{
    //    //TOTO ÌØÐ§ÖØµþ
    //    //return effects.Find(it =>it.transform.position == posY0 && it.GetType() == type) != null;
    //}
    public T GetDougu<T>() where T : Dougu
    {
        return prefabDougus.Find(d => d is T) as T;
    }
}
