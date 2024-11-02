using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguSphere : MonoBehaviour
{
    public Dougu douguBase;
    public SpriteRenderer spriteRenderer;
    float existTimer;
    //ÎÞµÐÊ±¼ä
    float invincibleTime = 0.2f;
    public Vector3 CurCenter => new Vector3(Mathf.RoundToInt(transform.position.x),0, Mathf.RoundToInt(transform.position.z));
    public void SetDougu(Dougu db)
    {
        douguBase = db;
        spriteRenderer.sprite = DeliConfig.GetSpriteByDonguType(douguBase);
        spriteRenderer.material.color = DeliConfig.id_color[db.CID];
    }
    private void OnEnable()
    {
        existTimer = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Mate>(out var mate))
        {
            mate.AddDougu(douguBase);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        existTimer += Time.deltaTime;
    }
    public void TryDestroy()
    {
        if (existTimer <= invincibleTime)
            return;
        Destroy(douguBase.gameObject);
        Destroy(gameObject);
    }
}

