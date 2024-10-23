using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSetterCube : MonoBehaviour
{
    public static float setInterval = 1f;
    public int d;
    private void Start()
    {
        StartCoroutine(SetDepth());
    }
    IEnumerator SetDepth()
    {
        while(true)
        {
            d = 3000 + GetComponent<BaseCube>().Height * 2;
            GetComponent<NewMaterial>().Material.renderQueue = d;
            yield return new WaitForSeconds(setInterval);
        }
    }
}
