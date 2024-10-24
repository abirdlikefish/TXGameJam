using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class DouguManager : Singleton<DouguManager>
{
    string rPath = "Prefabs/Dougu";
    public Transform entityP;
    public List<Dougu> prefabDougus;
    [HideInInspector]
    public DouguSphere prefabDouguSphere;
    [SerializeField]
    List<GameObject> sths = new();
    //[SerializeField]
    //List<Effect> effects;

    public override void Init()
    {
        prefabDougus = Resources.LoadAll<Dougu>(rPath).ToList();
        EventManager.Instance.GenerateDouguSphereEvent += GenerateDougu;
        prefabDouguSphere = Resources.Load<DouguSphere>("Prefabs/DouguSphere/DouguSphere");
        EventManager.Instance.EnterLevelEvent += EnterLevel;
    }

    

    public void EnterLevel(int id)
    {
        ClearChild(entityP);
        sths = new();
        //effects = new();
    }


    public void AddSth(GameObject go)
    {
        sths.Add(go);
    }
    public void RemoveSth(GameObject go)
    {
        sths.Remove(go);
    }

    void ClearChild(Transform p)
    {
        for (int i = 0; i < p.transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
    }
    public bool Has<T>(Vector3 posY0) where T : MonoBehaviour
    {
        return sths.Find(it => it.transform.position == posY0 && (it.GetComponent<T>() != null)) != null;
    }
    public bool HasEither<T1,T2>(Vector3 posY0) where T1 : MonoBehaviour where T2 : MonoBehaviour
    {
        return Has<T1>(posY0) || Has<T2>(posY0);
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
    public Dougu GetDougu(Type type)
    {
        if (!typeof(Dougu).IsAssignableFrom(type))
        {
            Debug.LogError("Type must be derived from Dougu.");
            return null;
        }

        foreach (var dougu in prefabDougus)
        {
            if (dougu.GetType() == type)
            {
                return dougu;
            }
        }
        return null;
    }

    public void GenerateDougu(Type type, Vector3 posY0,int cId)
    {
        DouguSphere ds = Dougu.MyInsSphere(prefabDouguSphere.gameObject, posY0).GetComponent<DouguSphere>();
        Dougu d = GetDougu(type);
        ds.Init(d, cId);
    }
}
