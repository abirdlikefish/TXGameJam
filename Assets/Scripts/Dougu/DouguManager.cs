using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
// using static UnityEditor.PlayerSettings;

public class DouguManager : Singleton<DouguManager,IDouguManager>,IDouguManager
{
    protected override void Init()
    {
        base.Init();
        douguPossibility = new()
        {
            1,1,1,1
        };

        entityP = transform;
        prefabDougus = Resources.LoadAll<Dougu>(rPath).ToList();
        prefabDouguSphere = Resources.Load<DouguSphere>("Prefabs/DouguSphere/DouguSphere");
        // EventManager.Instance.BoomEvent += GenerateInstantBoom;
    }
    IEnumerator Co_GenerateRandomDouguSphere()
    {
        while(true)
        {
            GenerateRandomDouguSphere();
            yield return new WaitForSeconds(DeliConfig.dougeSphereInsCD);
        }
    }
    public void GenerateRandomDouguSphere()
    {
        emptys = new();
        int d1 = (int)MateManager.Instance.GetCurMate(UnityEngine.Random.Range(0, 2)).thisCenter.x;
        int d2 = 10;
        for (int i = d1 - d2; i <= d1 + d2; i++)
        {
            for (int j = d1 - d2; j <= d1 + d2; j++)
            {
                Vector3Int pos = new(i, 0, j);
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
    [SerializeField]
    List<GameObject> sths = new();
    public bool AddSth(GameObject go)
    {
        sths.Add(go);
        return true;
    }

    public bool RemoveSth(GameObject go)
    {
        sths.Remove(go);
        return true;
    }
    public bool HasAny(Vector3 pos)
    {
        return sths.Find(it => (ToY0(it.transform.position) == ToY0(pos))) != null;
    }
    public bool Has<T1>(Vector3 pos) where T1 : MonoBehaviour
    {
        Vector3Int posY0 = ToY0(pos);
        return sths.Find(it => (ToY0(it.transform.position) == posY0) && (it.GetComponent<T1>() != null)) != null;
    }
    public bool HasEither<T1, T2>(Vector3 pos) where T1 : MonoBehaviour where T2 : MonoBehaviour
    {
        Vector3Int posY0 = ToY0(pos);
        return sths.Find(it => (ToY0(it.transform.position) == posY0) && (it.GetComponent<T1>() != null || it.GetComponent<T2>() != null)) != null;
    }
    
    public void OnEnterLevel()
    {
        ClearChild(entityP);
        sths = new();
    }
    public void OnExitLevel()
    {
        ClearChild(entityP);
    }
    public void OnEnterTinyLevel()
    {
        StartCoroutine(nameof(Co_GenerateRandomDouguSphere));
    }
    public void OnExitTinyLevel()
    {
        StopCoroutine(nameof(Co_GenerateRandomDouguSphere));
    }

    public static Vector3Int ToY0(Vector3 pos)
    {
        return Vector3Int.RoundToInt(new Vector3(pos.x - pos.y, 0, pos.z - pos.y));
    }



    string rPath = "Prefabs/Dougu";
    public static Transform entityP;
    void ClearChild(Transform p)
    {
        for (int i = 0; i < p.childCount; i++)
            Destroy(p.GetChild(i).gameObject);
    }
    static List<Dougu> prefabDougus;
    static DouguSphere prefabDouguSphere;
    List<int> douguPossibility;
    int TotalPossibility => douguPossibility.Sum();
    [SerializeField]
    List<Vector3> emptys = new();
    public static Dougu GetDougu(Type type,int cID)
    {
        Dougu d = GetDougu(type);
        d.CID = cID;
        return d;
    }
    public static Dougu InsDougu(Type type,int cID)
    {
        Dougu d = Instantiate(GetDougu(type),entityP);
        d.CID = cID;
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
    public void GenerateDouguSphere(Type type, Vector3 pos,int cId)
    {
        //Debug.Log($"{type} + {pos} + cid + {cId}");
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
    

    #region color reaction
    public static void GenerateInstantBoom(Vector3Int position)
    {
        GameObject go = Dougu.MyIns(GetDougu(typeof(DouguBomb), 0).gameObject, position);
        DouguBomb db = go.GetComponent<DouguBomb>();
        db.blockExistTime = 0f;
        db.remainUseCount = 0;
        Debug.Log(nameof(GenerateInstantBoom) + " " + position);
        db.block.gameObject.SetActive(true);
    }
    #endregion
}
