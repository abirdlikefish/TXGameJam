using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<IInit> inits;
    private void Awake()
    {
        inits = new()
        {
            MateSelectManager.Instance,
            UIMate.Instance
        };

        foreach (var item in inits)
        {
            item.Initialize();
        }
    }
}
