using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeliConfig : MonoBehaviour
{
    public float dragForce;
    public static float DragForce;

    public float dragMaxDistance;
    public static float DragMaxDistance;

    private void Awake()
    {
        DragForce = dragForce;
        DragMaxDistance = dragMaxDistance;
    }
}
