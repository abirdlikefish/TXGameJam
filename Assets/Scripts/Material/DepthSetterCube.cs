using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSetterCube : MonoBehaviour
{
    BaseCube baseCube;
    MeshRenderer meshRenderer;
    [SerializeField]
    int d;
    private void Awake()
    {
        baseCube = GetComponent<BaseCube>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        d = 3000 + baseCube.Height * 2;
        meshRenderer.materials[0].renderQueue = d;
    }
}
