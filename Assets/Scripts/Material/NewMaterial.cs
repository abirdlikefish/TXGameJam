using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMaterial : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int materialId;
    public SpriteRenderer spriteRenderer;
    public Material Material
    {
        get => meshRenderer == null ? spriteRenderer.material : meshRenderer.materials[materialId];
        set
        {
            if(meshRenderer == null)
            {
                spriteRenderer.material = value;
            }
            else
            {
                meshRenderer.materials[materialId] = value;
            }
        }
    }
    private void Awake()
    {
        
        //生成材质实例
        Material material = Instantiate(Material);
        //赋值给meshRenderer
        Material = material;
    }
}
