using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguSphere : MonoBehaviour
{
    public SerializableDictionary<string, Sprite> class_sprite;
    public SerializableDictionary<int, Color> id_color;
    public Dougu douguBase;
    public int color;
    public SpriteRenderer spriteRenderer;

    public Vector3 CurCenter => new Vector3(Mathf.RoundToInt(transform.position.x),0, Mathf.RoundToInt(transform.position.z));
    public void Init(Dougu db,int cl)
    {
        douguBase = db;
        color = cl;
        spriteRenderer.sprite = class_sprite[douguBase.GetType().ToString()];
        spriteRenderer.material.color = id_color[douguBase.cID];
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
            Destroy(gameObject);
        }
    }
}

