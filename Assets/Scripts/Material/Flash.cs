using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : NewMaterial
{
    public float a;
    public float b;
    public float div = 5;
    void Update()
    {
        //��c��aֵ��a,b֮��仯
        Color c = Material.GetColor("_Diffuse");
        c.a = Mathf.PingPong(Time.time / div, b - a) + a;
        Material.SetColor("_Diffuse", c);
    }
    private void OnDisable()
    {
        Color c = Material.GetColor("_Diffuse");
        c.a = 1;
        Material.SetColor("_Diffuse", c);
    }
}
