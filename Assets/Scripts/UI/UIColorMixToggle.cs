using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIColorMixToggle : MonoBehaviour
{
    Toggle toggle;
    public int mixColorId;
    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate(bool b)
        {
            UIInGame.Instance.mixPanel.SetActive(false);
            UIInGame.Instance.blockMixPanel.SetActive(true);
            toggle.interactable = false;
            EventManager.Instance.AddNewColorReaction(mixColorId, transform.GetSiblingIndex());
        });
    }
}
