using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public abstract class Dougu : MonoBehaviour
{
    public Mate user;
    public int remainUseCount = 3;
    public float damage = 1f;
    public Block block;
    public float blockExistTime = 2f;
    public Effect effect;
    public float effectTime = 0.5f;
    public int colorId;
    public static List<Vector3> Dirs => MateInput.dir_vec.Values.ToList();
    public void Init(Mate user)
    {
        this.user = user;
        colorId = 0;
    }
    public virtual int OnUse() { remainUseCount--; return 1; }
    public virtual void OnUseEnd()
    {
        if (remainUseCount <= 0)
        {
            user.ResetDougu();
            StartCoroutine(nameof(TryDestroy));
        }
    }
    public List<GameObject> busy = new();
    IEnumerator TryDestroy()
    {
        while (true)
        {
            if (busy.Count == 0)
            {
                Destroy(gameObject);
                break;
            }
            yield return 0;
        }
    }
    public static GameObject MyInsBlock(Block block, Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        if (!MateInput.CanTooruY0(posY0) || DouguManager.Instance.HasBlock(posY0))
            return null;
        return MyIns(block.gameObject, posY0);
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
    public static GameObject MyInsEffectHammer(Effect effect, Vector3 thisPos)
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
    public static GameObject MyInsEffect(Effect effect, Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        if (!MateInput.CanTooruY0(posY0))
            return null;
        return MyIns(effect.gameObject, posY0);
    }
    static GameObject MyIns(GameObject go, Vector3 posY0)
    {
        GameObject g = Instantiate(go, posY0, Quaternion.identity, DouguManager.Instance.entityP);
        g.SetActive(true);
        return g;
    }
    public void DyeBase(BaseCube cube)
    {
        cube.GetComponent<NewMaterial>().Material.color = Color.red;
        //EventManager.Instance.SetCubeColor(new(CurCenter.x, CurCenter.z), colorId);
    }
    public void DyeBesideCudeColor(Vector3 dirInWorld, Vector3 center)
    {
        if (((dirInWorld == new Vector3(1, 0, 0) || dirInWorld == new Vector3(0, 0, -1)) && Test.GetNodeR(center) == 2)
            ||
            ((dirInWorld == new Vector3(-1, 0, 0) || dirInWorld == new Vector3(0, 0, 1)) && Test.GetNodeL(center) == 1))
        {
            if (dirInWorld == new Vector3(1, 0, 0) || dirInWorld == new Vector3(0, 0, -1))
            {
                BaseCube cube = Test.GetCubeR(center);
                if (cube == null)
                {
                    Debug.LogError($"WTF!! dir {dirInWorld},center {center}");
                    return;
                }
                DyeBase(cube);
            }
            else
            {
                BaseCube cube = Test.GetCubeL(center);
                if (cube == null)
                {
                    Debug.LogError($"WTF!! dir {dirInWorld},center {center}");
                    return;
                }
                DyeBase(cube);
            }
        }
    }
}
