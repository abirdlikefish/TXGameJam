using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SphereRotaterY : MonoBehaviour
{
    public float timeTo360 = 2f;
    private void Awake()
    {
        transform.DORotate(new Vector3(0, 360, 0), timeTo360, RotateMode.WorldAxisAdd)
                 .SetEase(Ease.Linear)
                 .SetLoops(-1); // -1表示无限循环


    }
}
