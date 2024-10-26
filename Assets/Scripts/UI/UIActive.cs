using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActive : MonoBehaviour
{
    public void AAA()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
