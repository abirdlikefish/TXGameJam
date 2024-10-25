using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    public List<int> douguPossibility;
    int TotalPossibility => douguPossibility.Sum();
    //[SerializeField]
    //List<Effect> effects;

    public override void Init()
    {
        prefabDougus = Resources.LoadAll<Dougu>(rPath).ToList();
        EventManager.Instance.GenerateDouguSphereEvent += GenerateDouguSphere;
        EventManager.Instance.GenerateDouguSphereMiniCubeEvent += GenerateDouguSphereMiniCube;
        EventManager.Instance.BoomEvent += GenerateInstantBoom;
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
    public static Vector3Int ToY0(Vector3 pos)
    {
        return Vector3Int.RoundToInt(new Vector3(pos.x - pos.y, 0, pos.z - pos.y));
    }
    public bool Has(Vector3 pos)
    {
        return sths.Find(it => (ToY0(it.transform.position) == ToY0(pos))) != null;
    }

    public bool Has<T>(Vector3 pos) where T : MonoBehaviour
    {
        Vector3Int posY0 = ToY0(pos);
        return sths.Find(it => (ToY0(it.transform.position) == ToY0(pos)) && (it.GetComponent<T>() != null)) != null;
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
    public Dougu GetDougu(Type type,int cId)
    {
        Dougu d = GetDougu(type);
        d.SetCID(cId);
        return d;
    }
    public Dougu GetDougu(int dId)
    {
        return prefabDougus[dId];
    }
    //public T GetDougu<T>() where T : Dougu
    //{
    //    return prefabDougus.Find(d => d is T) as T;
    //}
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
    public void GenerateDouguSphere(Type type, Vector3 pos, int colorId)
    {
        GenerateDouguSphere(GetDougu(type), pos, colorId);
    }
    public void GenerateDouguSphere(Dougu douguPrefab, Vector3 pos)
    {
        GenerateDouguSphere(douguPrefab, pos,IntToColorId(UnityEngine.Random.Range(0, 4)));
    }
    public void GenerateDouguSphere(Dougu douguPrefab, Vector3 pos,int cId)
    {
        Debug.Log("Try GenerateDouguSphere" + " pos ");
        GameObject go = Dougu.MyInsSphere(prefabDouguSphere.gameObject, pos);
        if (go == null)
            return;
        Debug.Log(nameof(GenerateDouguSphere) +" " +pos);
        DouguSphere ds = go.GetComponent<DouguSphere>();
        douguPrefab.SetCID(cId);
        ds.Init(douguPrefab, cId);
    }
    public void GenerateDouguSphereMiniCube(Vector3Int pos)
    {
        GenerateDouguSphere(typeof(DouguMiniCube), pos, 0);
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
        Debug.LogError(IntToDougu(ran) + " not found");
        return 0;
    }
    Dougu IntToDougu(int ran)
    {
        int curSum = 0;
        for(int i=0;i<douguPossibility.Count;i++)
        {
            int it = douguPossibility[i];
            if (ran < curSum + it)
            {
                return GetDougu(i);
            }
            curSum += it;
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
                if (Has(pos))
                    continue;
                if (CubeGetter.GetCubeCanTooru(pos) == null)
                    continue;
                emptys.Add(pos);
            }
        }
        if (emptys.Count == 0)
            return;
        int emptyId = UnityEngine.Random.Range(0, emptys.Count);
        GenerateDouguSphere(GetDougu(UnityEngine.Random.Range(0, TotalPossibility)), emptys[emptyId]);
        emptys.RemoveAt(emptyId);
    }

    #region color reaction
    public void GenerateInstantBoom(Vector3Int position)
    {
        Dougu.MyInsInstantBoom(position);
    }
    #endregion
}
