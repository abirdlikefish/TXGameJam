using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(NewMaterial))]
public class DepthSetterEntity : MonoBehaviour
{
    Vector3 ThisCenter => transform.position;
    public int d1;
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
        GetComponent<NewMaterial>().Material.renderQueue = d1;
    }
    void TryTrap()
    {
        int isPassable = EventManager.Instance.IsPassable(MateInput.MyWorldToScreen(ThisCenter));
        int isEmpty = EventManager.Instance.IsEmpty(MateInput.MyWorldToScreen(ThisCenter));
        if ((isPassable == 0
            ||
            isEmpty != 0)
            && !GetComponent<HammerEffect>()
            )
        {
            Debug.Log($"destroy {ThisCenter} {name} pass{isPassable} mt{isEmpty}");
            Destroy(gameObject);
        }
    }
    int GetLeftCubeD(Vector3 center)
    {
        BaseCube cube = CubeGetter.GetCubeL(center);
        if (cube == null)
            return int.MinValue;
        return cube.Height;
    }
    int GetRightCubeD(Vector3 center)
    {
        BaseCube cube = CubeGetter.GetCubeR(center);
        if (cube == null)
            return int.MinValue;
        return cube.Height;
    }
}
