using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//public class MessageS:Singleton<MessageS>
//{
//    public Func<string,int> RequestSth;
//}

//public class Requester:MonoBehaviour
//{
//    private int sthover100;
//    private int sthless100;
//    void Request()
//    {
//        sthover100 = MessageS.Instance.RequestSth("大于100！");
//        sthless100 = MessageS.Instance.RequestSth("小于100！");
//    }
//}

//public class Teller:MonoBehaviour
//{
//    void Tell()
//    {
//        MessageS.Instance.RequestSth += (string condition) => { return 111; };
//    }
//}
public class MateSelect : MonoBehaviour
{
    public GameObject selected;

    MateSelectState state => MateSelectManager.Instance.state;
    private void OnMouseDown()
    {
        state.MyOnMouseDown(this);
    }
    private void OnMouseDrag()
    {
        state.MyOnMouseDrag(this);
    }
    private void OnMouseUp()
    {
        state.MyOnMouseUp(this);
    }

    private void Update()
    {
        state.Update();
    }

}
