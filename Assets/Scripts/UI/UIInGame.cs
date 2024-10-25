using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : Singleton<UIInGame>
{
    public override void Init()
    {
        EventManager.Instance.EnterTinyLevelEvent += (_) =>
        {
            for (int i = 0; i < uIMateProperties.Count && i < MateManager.Instance.curMates.Count; i++) 
            {
                uIMateProperties[i].mate = MateManager.Instance.curMates[i];

                RefreshUI(MateManager.Instance.curMates[i]);
            }
            for(int i=0;i<transform.childCount;i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        };

        exitButton.onClick.AddListener(() => EventManager.Instance.ExitLevel(1));

        EventManager.Instance.ExitLevelEvent += (_) => Destroy(gameObject);
        EventManager.Instance.refreshUIEvent += (mate) => RefreshUI(mate);
    }

    public List<UIMateProperty> uIMateProperties = new List<UIMateProperty>();

    public Button exitButton;

    public void RefreshUI(Mate mate)
    {
        for(int i=0;i<uIMateProperties.Count;i++)
        {
            if (uIMateProperties[i].mate == mate)
            {
                uIMateProperties[i].RefreshUI();
                break;
            }
        }
    }
}
