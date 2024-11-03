using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            MateManager.Instance.OnOneDead(MateManager.Instance.GetCurMate(Random.Range(0,2)));
        }
    }
    public bool GUA = false;
    static Test instance;
    public static Test Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Test>();
            }
            return instance;
        }
    }
}
