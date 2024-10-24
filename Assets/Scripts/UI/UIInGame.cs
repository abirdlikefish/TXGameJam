using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInGame : Singleton<UIInGame>
{
    public override void Init()
    {
        EventManager.Instance.EnterTinyLevelEvent += (_) =>
        {
            //½«UI°ó¶¨½ÇÉ«
        };
    }

    public List<UIMateProperty> uIMateProperties = new List<UIMateProperty>();
}
