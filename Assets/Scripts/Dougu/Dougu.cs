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
    public static List<Vector3> Dirs => MateInput.dir_vec.Values.ToList();
    public virtual int OnUse() { remainUseCount--;return 0; }
    public virtual void OnUseEnd()
    {
        if(remainUseCount <= 0)
        {
            user.ResetDougu();
            Destroy(gameObject);
        }
    }

    public static GameObject MyInsBlock(Block block,Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        if (!MateInput.CanTooruY0(posY0) || DouguManager.Instance.HasEntityBlock(posY0))
            return null;
        return MyIns(block.gameObject, posY0);
    }
    public static GameObject MyInsEffectRay(RayEffect rayEffect,Vector3 lastPos, Vector3 thisPos)
    {
        Vector3 lastPosY0 = new(lastPos.x, 0, lastPos.z);
        Vector3 thisPosY0 = new(thisPos.x, 0, thisPos.z);
        if (MateInput.CanTooruY0(lastPosY0, thisPosY0) || MateInput.IsEmpty(thisPosY0))
            return MyIns(rayEffect.gameObject, thisPosY0);
        return null;
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
    static GameObject MyIns(GameObject go, Vector3 posY0)
    {
        GameObject g = Instantiate(go, posY0, Quaternion.identity, DouguManager.Instance.entityP);
        g.SetActive(true);
        return g;
    }
}
