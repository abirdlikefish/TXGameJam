using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Dougu : MonoBehaviour
{
    public static int USED_CD = 1;
    public static int NOT_USED_CD = 0;

    public Mate user;
    private int cID;
    public int CID { get {  return cID; } set { cID = value; SetBlockAndEffectColor(cID); } }
    void SetBlockAndEffectColor(int cID)
    {
        if (block)
        {
            block.GetComponent<NewMaterial>().spriteRenderer.color = DeliConfig.id_color[cID];
        }
        else if (effect)
        {
            effect.GetComponent<NewMaterial>().Material.color = DeliConfig.id_color[cID];
        }
    }
    public int remainUseCount = 3;
    public float damage = 1f;
    public Block block;
    public float blockExistTime = 2f;
    public Effect effect;
    public float effectTime = 0.5f;
    public static List<Vector3Int> Dirs => MateInput.dir_vec.Values.ToList();
    private void OnEnable()
    {
        StartCoroutine(nameof(TryDestroy));
    }
    public virtual void OnDisable()
    {
        StopAllCoroutines();
    }
    IEnumerator TryDestroy()
    {
        while (true)
        {
            if (remainUseCount > 0)
            {
                yield return new WaitForSeconds(0.2f);
                continue;
            }
            if (busy.Count == 0)
            {
                Destroy(gameObject);
                break;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    //return 1 ��ʾʹ����Ҫ��CD
    public abstract int OnUse();
    
    public List<GameObject> busy = new();

    public static void MyInsInstantBoom(Vector3 pos)
    {
        GameObject go = MyIns(DouguManager.GetDougu(typeof(DouguBomb), 0).gameObject, pos);
        DouguBomb db = go.GetComponent<DouguBomb>();
        db.blockExistTime = 0f;
        db.remainUseCount = 0;
        Debug.Log(nameof(MyInsInstantBoom) + " " + pos);
        db.block.gameObject.SetActive(true);
    }
    public static GameObject MyInsBlockOrSphere(GameObject go,Vector3 pos)
    {
        if (!MateInput.CanTooru(pos) || DouguManager.Instance.HasEither<Block,DouguSphere>(pos))
            return null;
        return MyIns(go, pos);
    }
    public static GameObject MyInsEffectHammer(Effect effect,Vector3 thisPos)
    {
        return MyIns(effect.gameObject, thisPos);
    }
    public static GameObject MyInsEffect(Effect effect, Vector3 lastPos, Vector3 thisPos)
    {
        if (!MateInput.CanTooru(lastPos, thisPos))
            return null;
        return MyIns(effect.gameObject, thisPos);
    }
    public static GameObject MyInsEffect(Effect effect,Vector3 pos)
    {
        if (!MateInput.CanTooru(pos))
            return null;
        return MyIns(effect.gameObject, pos);
    }
    static GameObject MyIns(GameObject go, Vector3 pos)
    {
        Vector3Int posY0 = DouguManager.ToY0(pos);
        GameObject g = Instantiate(go, posY0, Quaternion.identity, DouguManager.entityP);
        g.SetActive(true);
        return g;
    }
    public void DyeBase(BaseCube cube)
    {
        cube.Color = CID;
        //Debug.Log($"dye{cube.Position}");
        //cube.Color += 
    }
    public void DyeBesideCubeColor(Vector3Int dirInWorld, Vector3Int thisCenter)
    {
        BaseCube upperCube = CubeGetter.GetCubeUpperFloor(dirInWorld, thisCenter);
        if (upperCube != null)
            DyeBase(upperCube);
    }
}
