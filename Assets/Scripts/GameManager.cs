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
            MateInput.Instance,
        };

        foreach (var item in inits)
        {
            item.Initialize();
        }
    }
}
