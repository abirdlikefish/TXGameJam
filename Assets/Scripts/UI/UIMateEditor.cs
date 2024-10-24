using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMateEditor : Singleton<UIMateEditor>
{

    public override void Init()
    {
        EventManager.Instance.EnterLevelEvent += OnEnterBigLevel;
    }
    public void OnEnterBigLevel(int levelId)
    {
        ShowAllMates();
        //btOnConfirmEdit.onClick.AddListener(delegate () { panelEditMate.gameObject.SetActive(false); });
        //btOnConfirmEdit.onClick.AddListener(delegate () { EventManager.Instance.EnterTinyLevel(0); });
        //EventManager.Instance.ShowInputNameUIEvent += ShowAllMates;

    }
    #region UIMateEdit
    public List<UIMateEditInfo> uiMates;


    public void ShowAllMates()
    {
        Debug.Log("ShowAllMates");
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
        EventManager.Instance.SetMateMaterialColor(uiMateEdit.Id, mateData.color);
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
