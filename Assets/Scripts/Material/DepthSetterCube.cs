using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSetterCube : MonoBehaviour
{
    public static float setInterval = 0.1f;
    [SerializeField]
    private int d;

    void Update()
    {
        d = 3000 + GetComponent<BaseCube>().Height * 2;
        // Debug.Log("SetDepth d = " + d);
        // GetComponent<NewMaterial>().Material.renderQueue = d;
        // GetComponent<MeshRenderer>().material.renderQueue = d;
        GetComponent<MeshRenderer>().materials[0].renderQueue = d;

        //yield return new WaitForSeconds(setInterval);
    }

    //public void SetDepth()
    //{
    //    Debug.Log($"{name}" + nameof(SetDepth) + " " +d);
    //    d = 3000 + GetComponent<BaseCube>().Height * 2;
    //    GetComponent<MeshRenderer>().material.renderQueue = d;
    //}
}
