using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIForceWait : MonoBehaviour
{
    public Image fillImage;
    public float time = 10;
    float timer;
    public UnityEvent onWaitEnd;

    private void OnEnable()
    {
        timer = time;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        fillImage.fillAmount = timer / time;
        if (timer <= 0)
        {
            onWaitEnd.Invoke();
            gameObject.SetActive(false);
        }
    }
}