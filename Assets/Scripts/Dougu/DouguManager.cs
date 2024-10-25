using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
    public List<Vector3> emptys = new();
    public SerializableDictionary<int,string> douguClass_possibility;
    int TotalPossibility => douguClass_possibility.Keys.Sum();
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
    public bool HasEither<T1, T2, T3>(Vector3 posY0) where T1 : MonoBehaviour where T2 : MonoBehaviour where T3 : MonoBehaviour
    {
        return Has<T1>(posY0) || Has<T2>(posY0) || Has<T3>(posY0);
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
    public void GenerateDougu(Type type, Vector3 posY0)
    {
        GenerateDougu(type, posY0,IntToColorId(UnityEngine.Random.Range(0, 4)));
    }
    public void GenerateDougu(Type type, Vector3 posY0,int cId)
    {
        GameObject go = Dougu.MyInsSphere(prefabDouguSphere.gameObject, posY0);
        if (go == null)
            return;
        DouguSphere ds = go.GetComponent<DouguSphere>();
        Dougu d = GetDougu(type);
        d.SetColor(cId);
        ds.Init(d, cId);
    }
    int IntToColorId(int ran)
    {
        if (ran == 0)
            return 0;
        if (ran == 1)
            return 1;
        if (ran == 2)
            return 2;
        if (ran == 3)
            return 4;
        Debug.LogError(IntToDouguClass(ran) + " not found");
        return 0;
    }
    Type IntToDouguClass(int ran)
    {
        int curSum = 0;
        foreach(var key in douguClass_possibility.Keys)
        {
            if(ran < curSum + key)
            {
                return Type.GetType(douguClass_possibility[key]);
            }
            curSum += key;
        }
        Debug.LogError("possibility " + ran + " not found");
        return null;
    }
    public void GenerateRandomDouguSphere()
    {
        emptys = new();
        int d1 = (int)MateManager.Instance.curMates[0].CurCenter.x;
        int d2 = 10;
        for (int i = d1-d2; i <= d1+d2; i++)
        {
            for (int j = d1-d2; j <= d1+d2; j++)
            {
                Vector3 pos = new(i, 0, j);
                if (HasEither<Mate, Block>(pos) || HasEither<Effect, DouguSphere>(pos))
                    continue;
                if (CubeGetter.GetCubeCanTooru(pos) == null)
                    continue;
                emptys.Add(pos);
            }
        }
        if (emptys.Count == 0)
            return;
        GenerateDougu(IntToDouguClass(UnityEngine.Random.Range(0, TotalPossibility)), emptys[UnityEngine.Random.Range(0, emptys.Count)]);
    }
}
