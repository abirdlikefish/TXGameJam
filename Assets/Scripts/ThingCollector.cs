using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingCollector : MonoBehaviour
{
    private void OnEnable()
    {
        DouguManager.Instance.AddSth(gameObject);
    }
    private void OnDisable()
    {
        DouguManager.Instance.RemoveSth(gameObject);
    }
}
