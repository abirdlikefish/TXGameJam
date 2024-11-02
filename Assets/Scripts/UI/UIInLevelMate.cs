using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInLevelMate : MonoBehaviour
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

    public void Refresh()
    {
        douguBG.color = DeliConfig.id_color[mate.GetDougu().CID];
        dougu.sprite = DeliConfig.GetSpriteByDonguType(mate.GetDougu());

        nameBG.color = mate.mateData.color;
        mateName.text = mate.mateData.name;

        health.color = mate.mateData.color;
        health.fillAmount = mate.HealthPercent;
        winRnd.text = mate.mateData.winCount.ToString();
    }
}
