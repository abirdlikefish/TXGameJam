using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInGame : Singleton<UIInGame>
{
    public override void Init()
    {
        EventManager.Instance.EnterTinyLevelEvent += (_) =>
        {


            for (int i = 0; i < uIMateProperties.Count && i < MateManager.Instance.curMates.Count; i++) 
            {
                uIMateProperties[i].gameObject.SetActive(true);
                uIMateProperties[i].mate = MateManager.Instance.curMates[i];

                RefreshUI(MateManager.Instance.curMates[i]);
            }
        };
    }

    public List<UIMateProperty> uIMateProperties = new List<UIMateProperty>();

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
