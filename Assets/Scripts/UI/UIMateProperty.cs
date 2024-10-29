using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMateProperty : MonoBehaviour
{
    public Mate mate;

    public Image douguBG;
    public Image dougu;
    public Image nameBG;
    public Text mateName;
    public Image healthBG;
    public Image health;
    public Image winRndBG;
    public Text winRnd;

    public void RefreshUI()
    {
        douguBG.color = mate.onHeadDougu.Count > 0 ? DeliConfig.Instance.id_color[mate.onHeadDougu[0].cID] : Color.clear;
        dougu.sprite = mate.onHeadDougu.Count > 0 ? DeliConfig.Instance.class_sprite[mate.onHeadDougu[0].GetType().ToString()] : null;

        nameBG.color = mate.mateData.color;
        mateName.text = mate.mateData.name;

        health.color = mate.mateData.color;
        health.fillAmount = mate.HealthPercent;
        winRnd.text = mate.mateData.winCount.ToString();
    }
}
