using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMateEditor : MonoBehaviour
{
    public Button btOnConfirmEdit;
    public GameObject panelEditMate;
    //public override void Init()
    //{
    //    btOnConfirmEdit.onClick.AddListener(delegate () { panelEditMate.gameObject.SetActive(false); });
    //    // btOnConfirmEdit.onClick.AddListener(delegate () { EventManager.Instance.EnterTinyLevel(0); });
    //    btOnConfirmEdit.onClick.AddListener(delegate () { EventManager.Instance.ExitState(1); });
    //    EventManager.Instance.ShowInputNameUIEvent += ShowAllMates;
    //}
    // public void OnEnterBigLevel(int levelId)
    // {
    //     ShowAllMates();
    // }
    #region UIMateEdit
    public List<UIEditMateInfo> uiMates;


    //void ShowAllMates()
    //{
    //    panelEditMate.SetActive(true);
    //    Debug.Log("ShowAllMates");
    //    for (int i = 0; i < 2; i++)
    //    {
    //        uiMates[i].SetMateId(i);
    //        ShowMate(MateManager.Instance.GetMateData(i), i);
    //    }
    //}
    //public void ShowMate(MateData mateData,int ui_mid)
    //{
    //    uiMates[ui_mid].mateName.text = mateData.name;
    //    uiMates[ui_mid].mateWinCount.text = mateData.winCount.ToString();
    //    ChangeColor(mateData, ui_mid);
    //}
    //void ChangeColor(MateData mateData, int ui_mid)
    //{
    //    uiMates[ui_mid].mateBase.color = SetAlpha(mateData.color, 50 / 255f);
    //    uiMates[ui_mid].mateName.color = mateData.color;
    //    uiMates[ui_mid].mateNameInputHolder.color = mateData.color;
    //    uiMates[ui_mid].mateNameInput.color = mateData.color;
    //    uiMates[ui_mid].mateWinCountC.color = mateData.color;
    //    uiMates[ui_mid].mateWinCount.color = mateData.color;
    //}
    //Color SetAlpha(Color c, float a)
    //{
    //    return new Color(c.r, c.g, c.b, a);
    //}
    #endregion
}
