using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMaterial : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int materialId;
    public Material Material
    {
        get => meshRenderer.materials[materialId];
        set => meshRenderer.materials[materialId] = value;
    }
    private void Awake()
    {
        //生成材质实例
        Material material = Instantiate(Material);
        //赋值给meshRenderer
        meshRenderer.materials[materialId] = material;
    }
}
