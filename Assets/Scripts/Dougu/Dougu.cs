using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public abstract class Dougu : MonoBehaviour
{
    public Mate user;
    public int cID;
    public int remainUseCount = 3;
    public float damage = 1f;
    public Block block;
    public float blockExistTime = 2f;
    public Effect effect;
    public float effectTime = 0.5f;
    public static List<Vector3> Dirs => MateInput.dir_vec.Values.ToList();
    public void SetCID(int cID)
    {
        this.cID = cID;
        
    }
    private void OnEnable()
    {
        StartCoroutine(nameof(TryDestroy));
    }
    void SetColor()
    {
        if (block)
        {
            block.GetComponent<NewMaterial>().spriteRenderer.color = DeliConfig.Instance.id_color[cID];
        }
        else if (effect)
        {
            effect.GetComponent<NewMaterial>().Material.color = DeliConfig.Instance.id_color[cID];
        }
    }
    public virtual int OnUse() { SetColor(); remainUseCount--;return 1; }
    public virtual void OnUseEnd()
    {
        if(remainUseCount <= 0)
        {
            user.ResetDougu();
        }
    }
    public List<GameObject> busy = new();
    IEnumerator TryDestroy()
    {
        while(true)
        {
            if(remainUseCount > 0)
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
    public static void MyInsInstantBoom(Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        GameObject go = MyIns(DouguManager.Instance.GetDougu(typeof(DouguBomb),0).gameObject, posY0);
        DouguBomb db = go.GetComponent<DouguBomb>();
        db.blockExistTime = 0f;
        db.block.gameObject.SetActive(true);
    }
    public static GameObject MyInsBlockOrSphere(GameObject go,Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        if (!MateInput.CanTooruY0(posY0) || DouguManager.Instance.HasEither<Block,DouguSphere>(posY0))
            return null;
        return MyIns(go, posY0);
    }
    //public static GameObject MyInsEffectRay(RayEffect rayEffect,Vector3 lastPos, Vector3 thisPos)
    //{
    //    Vector3 lastPosY0 = new(lastPos.x, 0, lastPos.z);
    //    Vector3 thisPosY0 = new(thisPos.x, 0, thisPos.z);
    //    int thisEmpty = EventManager.Instance.IsEmpty(MateInput.MyWorldToScreen(thisPosY0));
    //    Debug.Log("MyInsEffectRay + thisPosEmpty = " + thisEmpty);
    //    if (MateInput.CanTooruY0(lastPosY0, thisPosY0))
    //        return MyIns(rayEffect.gameObject, thisPosY0);
    //    return null;
    //}
    public static GameObject MyInsEffectHammer(Effect effect,Vector3 thisPos)
    {
        Vector3 thisPosY0 = new(thisPos.x, 0, thisPos.z);
        return MyIns(effect.gameObject, thisPosY0);
    }
    public static GameObject MyInsEffect(Effect effect, Vector3 lastPos, Vector3 thisPos)
    {
        Vector3 lastPosY0 = new(lastPos.x, 0, lastPos.z);
        Vector3 thisPosY0 = new(thisPos.x, 0, thisPos.z);
        if (!MateInput.CanTooruY0(lastPosY0, thisPosY0))
            return null;
        return MyIns(effect.gameObject, thisPosY0);
    }
    public static GameObject MyInsEffect(Effect effect,Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        if (!MateInput.CanTooruY0(posY0))
            return null;
        return MyIns(effect.gameObject, posY0);
    }
    public static GameObject MyInsSphere(GameObject sphere,Vector3 pos)
    {
        return MyInsBlockOrSphere(sphere,pos);
    }
    static GameObject MyIns(GameObject go, Vector3 posY0)
    {
        GameObject g = Instantiate(go, posY0, Quaternion.identity, DouguManager.Instance.entityP);
        g.SetActive(true);
        return g;
    }
    public void DyeBase(BaseCube cube)
    {
        cube.Color = cID;
        //Debug.Log($"dye{cube.Position}");
        //cube.Color += 
    }
    public void DyeBesideCubeColor(Vector3 dirInWorld, Vector3 center)
    {
        BaseCube upperCube = CubeGetter.GetCubeUpperFloor(dirInWorld, center);
        if (upperCube != null)
            DyeBase(upperCube);
    }
}
