using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeliConfig : Singleton<DeliConfig>
{
    public float maxDistanceToCenterWhenBlocked = 0.4f;
    public float moveSpeed;
    public float takeDamageInterval = 1f;

    public float douguUseInterval = 1f;
    public float dougeSphereInsCD = 7f;
    public static bool tooruTest = true;


    public SerializableDictionary<string, Sprite> class_sprite;
    public SerializableDictionary<int, Color> id_color;
}
