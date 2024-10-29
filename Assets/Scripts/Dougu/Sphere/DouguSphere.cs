using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouguSphere : MonoBehaviour
{
    public Dougu douguBase;
    public SpriteRenderer spriteRenderer;
    float existTimer;
    //�޵�ʱ��
    float invincibleTime = 0.2f;
    public Vector3 CurCenter => new Vector3(Mathf.RoundToInt(transform.position.x),0, Mathf.RoundToInt(transform.position.z));
    public void SetDougu(Dougu db)
    {
        douguBase = db;
        spriteRenderer.sprite = DeliConfig.Instance.class_sprite[douguBase.GetType().ToString()];
        spriteRenderer.material.color = DeliConfig.Instance.id_color[db.cID];
    }

    private void OnEnable()
    {
        existTimer = 0f;
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

