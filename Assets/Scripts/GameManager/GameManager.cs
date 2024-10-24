using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        MapManager.AddListener();
        InitTotal();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SaveManager.Instance.LoadLevelData();
        }
    }
    void InitTotal()
    {
        DeliConfig.Instance.Init();
        MateManager.Instance.Init();
        DouguManager.Instance.Init();
        UIMateEditor.Instance.Init();
        MapSaver.Instance.Init();
        EventManager.Instance.EnterLevel(0);
        EventManager.Instance.EnterTinyLevel(0);
    }
}
