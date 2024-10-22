using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Dougu : MonoBehaviour
{
    public Mate user;
    public int remainUseCount = 3;
    public float damage = 1f;
    public static List<Vector3> Dirs => MateInput.dir_vec.Values.ToList();
    public abstract bool OnUse();
    public virtual void OnUseEnd()
    {
        if(remainUseCount <= 0)
        {
            user.ResetDougu();
            Destroy(gameObject);
        }
    }
    public static GameObject MyInsBlock(Block go,Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        if (!MateInput.CanTooruYN0(pos) || DouguManager.Instance.HasEntityBlock(posY0))
            return null;
        return MyIns(go.gameObject, posY0);
    }
    public static GameObject MyInsEffect(Effect effect,Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        if (!MateInput.CanTooruYN0(pos) || DouguManager.Instance.HasSameEffect(posY0, effect.GetType()))
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
