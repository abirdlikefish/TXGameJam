using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PSelected : MonoBehaviour
{
    void OnEnable()
    {
        transform.GetChild(0).localPosition = Vector3.zero;
        transform.GetChild(0).DOLocalMove(Vector3.up/10f,1f).SetRelative().SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
    private void Update()
    {
        transform.position = transform.parent.position + new Vector3(0, 0.85f, 0);
        transform.rotation = Quaternion.identity;
    }
    private void OnDisable()
    {
        transform.GetChild(0).DOKill();
    }
}
