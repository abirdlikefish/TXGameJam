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
    public static GameObject MyInsBlock(GameObject go,Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        if (!MateInput.CanTooru(posY0) || !DouguManager.Instance.CanTooru(posY0))
            return null;
        return MyIns(go, pos);
    }
    public static GameObject MyInsEffect(GameObject go,Vector3 pos)
    {
        Vector3 posY0 = new(pos.x, 0, pos.z);
        if (!MateInput.CanTooru(posY0))
            return null;
        return MyIns(go, pos);
    }
    static GameObject MyIns(GameObject go, Vector3 pos)
    {
        GameObject g = Instantiate(go, pos, Quaternion.identity, DouguManager.Instance.entityP);
        g.SetActive(true);
        return g;
    }
}
