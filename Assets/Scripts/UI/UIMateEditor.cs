using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMateEditor : Singleton<UIMateEditor>
{
    public Button btOnConfirmEdit;
    public GameObject panelEditMate;
    public override void Init()
    {
        btOnConfirmEdit.onClick.AddListener(delegate () { panelEditMate.gameObject.SetActive(false); });
        btOnConfirmEdit.onClick.AddListener(delegate () { EventManager.Instance.EnterTinyLevel(0); });
        EventManager.Instance.ShowInputNameUIEvent += ShowAllMates; 
    }
    // public void OnEnterBigLevel(int levelId)
    // {
    //     ShowAllMates();
    // }
    #region UIMateEdit
    public List<UIMateEditInfo> uiMates;


    public void ShowAllMates()
    {
        panelEditMate.SetActive(true);
        Debug.Log("ShowAllMates");
        // Debug.Log(MateManager.Instance.mateDatas.Count);
        for (int i = 0; i < 2; i++)
        {
            ShowMate(MateManager.Instance.mateDatas[i], uiMates[i]);
        }
    }
    public void ShowMate(MateData mateData, UIMateEditInfo uiMateEdit)
    {
        uiMateEdit.mateName.text = mateData.name;
        uiMateEdit.mateWinCount.text = mateData.winCount.ToString();
        ChangeColor(mateData, uiMateEdit);
    }
    public void ChangeColor(MateData mateData, UIMateEditInfo uiMate)
    {
        uiMate.mateBase.color = SetAlpha(mateData.color, 50 / 255f);
        uiMate.mateName.color = mateData.color;
        uiMate.mateNameInputHolder.color = mateData.color;
        uiMate.mateNameInput.color = mateData.color;
        uiMate.mateWinCountC.color = mateData.color;
        uiMate.mateWinCount.color = mateData.color;
    }
    Color SetAlpha(Color c, float a)
    {
        return new Color(c.r, c.g, c.b, a);
    }
    #endregion

    //#region UIMateInLevel
    //public List<UIMateInLevel> uiMatesInLevels;
    //#endregion
}
