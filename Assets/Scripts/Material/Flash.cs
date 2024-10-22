using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flash : NewMaterial
{
    public float a;
    public float b;
    public float div = 5;
    Color c;
    void Update()
    { 
        //让c的a值在a,b之间变化
        if (meshRenderer == null)
        {
            c = spriteRenderer.color;
            c.a = Mathf.PingPong(Time.time / div, b - a) + a;
            spriteRenderer.color = c;
            return;
        }
        c = Material.GetColor("_Diffuse");
        c.a = Mathf.PingPong(Time.time / div, b - a) + a;
        Material.SetColor("_Diffuse", c);
    }
    private void OnDisable()
    {
        if (meshRenderer == null)
        {
            c = spriteRenderer.color;
            c.a = 1;
            spriteRenderer.color = c;
            return;
        }
        c = Material.GetColor("_Diffuse");
        c.a = 1;
        Material.SetColor("_Diffuse", c);
    }
}
