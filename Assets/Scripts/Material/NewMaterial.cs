using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMaterial : MonoBehaviour
{
    // private MeshRenderer MeshRenderer;
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
        // if(name.Contains("Cube"))
        // {
        //     return;
        // }
        //���ɲ���ʵ��
        Debug.Log("NewMaterial Awake");
        Material material = Instantiate(Material);
        //��ֵ��meshRenderer
        Material = material;
    }
}
