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
        //���ɲ���ʵ��
        Material material = Instantiate(Material);
        //��ֵ��meshRenderer
        meshRenderer.materials[materialId] = material;
    }
}
