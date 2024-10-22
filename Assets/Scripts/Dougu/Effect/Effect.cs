using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public void OnEnable()
    {
        DouguManager.Instance.AddEffect(transform.position);
    }

    public void OnDisable()
    {
        DouguManager.Instance.RemoveEffect(transform.position);
    }
}
