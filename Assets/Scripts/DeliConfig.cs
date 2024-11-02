using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeliConfig
{
    public static float maxDistanceToCenterWhenBlocked = 0.4f;
    public static float moveSpeed;
    public static float takeDamageInterval = 1f;

    public static float douguUseInterval = 1f;
    public static float dougeSphereInsCD = 7f;

    public static bool goldFinger = true;

    static SerializableDictionary<Type, Sprite> class_sprite = new()
    {
        {typeof(DouguBomb), Resources.Load<Sprite>("Sprite/UIDougu/d0")},
        {typeof(DouguRay), Resources.Load<Sprite>("Sprite/UIDougu/d1")},
        {typeof(DouguHammer), Resources.Load<Sprite>("Sprite/UIDougu/d2")},
        {typeof(DouguMiniCube), Resources.Load<Sprite>("Sprite/UIDougu/d3")},
    };
    public static Sprite GetSpriteByDonguType(Dougu dougu)
    {
        return class_sprite[dougu.GetType()];
    }
    public static SerializableDictionary<int, Color> id_color;

}
