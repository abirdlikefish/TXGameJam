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
            toggle.interactable = false;
            UIManager.Instance.OnExitSelectMix();

             ColorReactionManager.Instance.AddNewColorReaction(mixColorId, transform.GetSiblingIndex());
        });
    }
}
