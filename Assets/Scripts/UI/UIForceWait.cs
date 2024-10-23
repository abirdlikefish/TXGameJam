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

    public void StartWait(UnityEvent onWaitEnd)
    {
        this.onWaitEnd = onWaitEnd;
        gameObject.SetActive(true);
    }
    private void OnEnable()
    {
        timer = time;
        //UIManager.Instance.AddWait(this);
    }
    public void EndWait()
    {
        onWaitEnd.Invoke();
        gameObject.SetActive(false);

    }
    private void OnDisable()
    {
        //UIManager.Instance.RemoveWait(this);
    }
    void Update()
    {
        timer -= Time.unscaledDeltaTime;
        fillImage.fillAmount = timer / time;
        if (timer <= 0)
        {
            EndWait();
        }
    }
}