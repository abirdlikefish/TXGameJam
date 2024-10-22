using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int materialId;
    public float a;
    public float b;
    public float div = 5;
    public Material Material
    {
        get => meshRenderer.materials[materialId];
        set => meshRenderer.materials[materialId] = value;
    }
    private void Awake()
    {
        //���ɲ���ʵ��
        Material material = Instantiate(Material);
        //��ֵ��meshRenderer
        Material = material;
    }
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
