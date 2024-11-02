using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(NewMaterial))]
public class DepthSetterEntity : MonoBehaviour
{
    NewMaterial newMaterial;
    HammerEffect hammerEffect;
    Vector3Int ThisCenter => Vector3Int.RoundToInt(transform.position);
    public int d1;
    private void Awake()
    {
        newMaterial = GetComponent<NewMaterial>();
        hammerEffect = GetComponent<HammerEffect>();
    }
    void Update()
    {
        TryTrap();
        int h1 = GetLeftCubeD(ThisCenter);
        if (h1 == int.MinValue)
        {
        return;
        }
        int h2 = GetRightCubeD(ThisCenter);
        if (h2 == int.MinValue)
        {
            return;
        }
        d1 = 3000 + h1 + h2 + 2;
        newMaterial.Material.renderQueue = d1;
    }
    void TryTrap()
    {
        int isPassable = EventManager.Instance.IsPassable(MateInput.MyWorldToScreen(ThisCenter));
        int isEmpty = EventManager.Instance.IsEmpty(MateInput.MyWorldToScreen(ThisCenter));
        if ((isPassable == 0
            ||
            isEmpty != 0)
            && hammerEffect == null
            )
        {
            Debug.Log($"destroy {ThisCenter} {name} pass{isPassable} mt{isEmpty}");
            Destroy(gameObject);
        }
    }
    int GetLeftCubeD(Vector3Int center)
    {
        if(MapManager.Instance.GetCubeL(center) == null)
        {
            return int.MinValue;
        }
        else
        {
            return Mathf.RoundToInt(CameraManager.Instance.GetHeight(center));
        }
    }
    int GetRightCubeD(Vector3Int center)
    {        
        if(MapManager.Instance.GetCubeR(center) == null)
        {
            return int.MinValue;
        }
        else
        {
            return Mathf.RoundToInt(CameraManager.Instance.GetHeight(center));
        }
    }
}
