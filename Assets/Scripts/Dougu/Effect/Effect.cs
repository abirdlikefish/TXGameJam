using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public void OnEnable()
    {
        DouguManager.Instance.AddEffect(this);
    }

    public void OnDisable()
    {
        DouguManager.Instance.RemoveEffect(this);
    }
}
