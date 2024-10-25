using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguSphere : MonoBehaviour
{
    public Dougu douguBase;
    public int color;
    public SpriteRenderer spriteRenderer;

    public Vector3 CurCenter => new Vector3(Mathf.RoundToInt(transform.position.x),0, Mathf.RoundToInt(transform.position.z));
    public void Init(Dougu db,int cl)
    {
        douguBase = db;
        color = cl;
        spriteRenderer.sprite = DeliConfig.Instance.class_sprite[douguBase.GetType().ToString()];
        spriteRenderer.material.color = DeliConfig.Instance.id_color[douguBase.cID];
    }

    private void OnEnable()
    {
        DouguManager.Instance.AddSth(gameObject);
    }
    private void OnDisable()
    {
        DouguManager.Instance.RemoveSth(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Mate>(out var mate))
        {
            mate.AddDougu(douguBase);
            EventManager.Instance.RefreshUI(mate);
            Destroy(gameObject);
        }
    }
}

