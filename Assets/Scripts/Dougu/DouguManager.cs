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
    public static Transform entityP;
    void ClearChild(Transform p)
    {
        for (int i = 0; i < p.transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
    }
    static List<Dougu> prefabDougus;
    static DouguSphere prefabDouguSphere;
    [SerializeField]
    List<GameObject> sths = new();
    [SerializeField]
    List<Vector3> emptys = new();
    //BY ²ß»®
    public List<int> douguPossibility;
    int TotalPossibility => douguPossibility.Sum();
    public override void Init()
    {
        entityP = transform.Find("EntityPool");
        prefabDougus = Resources.LoadAll<Dougu>(rPath).ToList();
        prefabDouguSphere = Resources.Load<DouguSphere>("Prefabs/DouguSphere/DouguSphere");
        EventManager.Instance.GenerateDouguSphereEvent += GenerateDouguSphere;
        EventManager.Instance.GenerateDouguSphereMiniCubeEvent += GenerateDouguSphereMiniCube;
        EventManager.Instance.BoomEvent += GenerateInstantBoom;
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
    public static Vector3Int ToY0(Vector3 pos)
    {
        return Vector3Int.RoundToInt(new Vector3(pos.x - pos.y, 0, pos.z - pos.y));
    }
    public bool HasAny(Vector3 pos)
    {
        return sths.Find(it => (ToY0(it.transform.position) == ToY0(pos))) != null;
    }
    public bool HasEither<T1,T2>(Vector3 pos) where T1 : MonoBehaviour where T2 : MonoBehaviour
    {
        Vector3Int posY0 = ToY0(pos);
        return sths.Find(it => (ToY0(it.transform.position) == ToY0(pos)) && (it.GetComponent<T1>() != null || it.GetComponent<T2>() != null)) != null;
    }
    public static Dougu GetDougu(Type type,int cId)
    {
        Dougu d = GetDougu(type);
        d.SetCID(cId);
        return d;
    }
    public static Dougu InsDougu(Type type,int cId)
    {
        Dougu d = Instantiate(GetDougu(type),entityP);
        d.SetCID(cId);
        return d;
    }
    static Dougu GetDougu(Type type)
    {
        foreach (var dougu in prefabDougus)
        {
            if (dougu.GetType() == type)
            {
                return dougu;
            }
        }
        return null;
    }
    void GenerateDouguSphereMiniCube(Vector3Int pos)
    {
        GenerateDouguSphere(typeof(DouguMiniCube), pos, 0);
    }
    void GenerateDouguSphere(Type type, Vector3 pos,int cId)
    {
        Debug.Log($"{type} + {pos} + cid + {cId}");
        GameObject go = Dougu.MyInsBlockOrSphere(prefabDouguSphere.gameObject, pos);
        if (go == null)
            return;
        //Debug.Log(nameof(GenerateDouguSphere) +" " +pos);
        DouguSphere ds = go.GetComponent<DouguSphere>();
        ds.SetDougu(InsDougu(type,cId));
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
        Debug.LogError(nameof(IntToColorId) + " not found");
        return 0;
    }
    Type RanToDouguType(int ran)
    {
        int curSum = 0;
        for (int i = 0; i < douguPossibility.Count; i++)
        {
            int it = douguPossibility[i];
            if (ran < curSum + it)
            {
                return prefabDougus[i].GetType();
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
                if (HasAny(pos))
                    continue;
                if (CubeGetter.GetCubeCanTooru(pos) == null)
                    continue;
                emptys.Add(pos);
            }
        }
        if (emptys.Count <= 3)
            return;
        int emptyId = UnityEngine.Random.Range(0, emptys.Count);
        GenerateDouguSphere(RanToDouguType(UnityEngine.Random.Range(0, TotalPossibility)), emptys[emptyId], IntToColorId(UnityEngine.Random.Range(0, 4)));
        emptys.RemoveAt(emptyId);
    }

    #region color reaction
    public void GenerateInstantBoom(Vector3Int position)
    {
        Dougu.MyInsInstantBoom(position);
    }
    #endregion
}
