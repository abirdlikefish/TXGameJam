using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeliConfig : Singleton<DeliConfig>
{
    public float maxDistanceToCenterWhenBlocked = 0.4f;
    public float moveSpeed;
    public float takeDamageInterval = 1f;

    public float douguInterval = 1f;

    public SerializableDictionary<Material, int> colorMar_id;

    public static bool tooruTest = true;
}
