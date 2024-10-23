using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public Dougu douguBase;
    public float EffectTime => douguBase.effectTime;
    public float existTimer = 0f;
    Vector3Int curCenter;
    public Vector3Int CurCenter => new(Mathf.RoundToInt(transform.position.x), 0, Mathf.RoundToInt(transform.position.z));
    private void Update()
    {
        existTimer += Time.deltaTime;
        if (existTimer >= EffectTime)
        {
            Destroy(gameObject);
        }

    }
    public virtual void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Mate>())
            other.gameObject.GetComponent<Mate>().TakeDamage(douguBase.damage);
    }
    public void OnEnable()
    {
        douguBase.busy.Add(gameObject);
        DouguManager.Instance.AddEffect(this);
        DyeBelowCubeColor();
    }

    public void OnDisable()
    {
        douguBase.busy.Remove(gameObject);
        DouguManager.Instance.RemoveEffect(this);
    }
    public virtual void DyeBelowCubeColor()
    {
        BaseCube cube = Test.GetCubeCanTooru(CurCenter);
        if (cube == null)
            return;
        DyeBase(cube);
    }
    public void DyeBase(BaseCube cube)
    {
        cube.GetComponent<NewMaterial>().Material.color = Color.red;
        EventManager.Instance.SetCubeColor(new(CurCenter.x, CurCenter.z), douguBase.colorId);
    }
    public void DyeBesideCudeColor(Vector3 dirInWorld, Vector3 center)
    {
        if(dirInWorld == new Vector3(1,0,0) || dirInWorld == new Vector3(0,0,-1))
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
