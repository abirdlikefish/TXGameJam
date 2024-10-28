using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            MateManager.Instance.OnOneDead(MateManager.Instance.curMates[0]);
        }
    }
}
