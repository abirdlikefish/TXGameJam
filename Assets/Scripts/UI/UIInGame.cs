using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInGame : Singleton<UIInGame>
{
    public override void Init()
    {
        EventManager.Instance.EnterTinyLevelEvent += (_) =>
        {
            //��UI�󶨽�ɫ
        };
    }

    public List<UIMateProperty> uIMateProperties = new List<UIMateProperty>();
}
