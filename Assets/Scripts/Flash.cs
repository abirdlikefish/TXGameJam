using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public Material material;
    public float a;
    public float b;
    public float div = 5;
    void Update()
    {
        //��c��aֵ��a,b֮��仯
        Color c = material.GetColor("_Diffuse");
        c.a = Mathf.PingPong(Time.time / div, b - a) + a;
        material.SetColor("_Diffuse", c);
    }
    private void OnDisable()
    {
        Color c = material.GetColor("_Diffuse");
        c.a = 1;
        material.SetColor("_Diffuse", c);
    }
}