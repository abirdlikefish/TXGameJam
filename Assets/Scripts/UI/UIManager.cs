using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>, IOnGameAwakeInit,IOnLevelEnterInit
{
    public void InitializeOnGameAwake()
    {
        ShowAllMates();
    }
    public void InitializeOnLevelEnter()
    {
        forceWaits.Clear();
        //throw new System.NotImplementedException();
    }

    #region UIForceWait
    [SerializeField]
    List<UIForceWait> forceWaits;
    public void AddWait(UIForceWait wait)
    {
        if(!forceWaits.Contains(wait))
            forceWaits.Add(wait);
    }
    public void RemoveWait(UIForceWait wait)
    {
        forceWaits.Remove(wait);
    }
    private void Update()
    {
        Time.timeScale = forceWaits.Count == 0 ? 1f : 0.01f;
    }
    #endregion

    #region UIMateEdit
    public List<UIMateEdit> uiMates;
    
    public void ShowAllMates()
    {
        for (int i = 0; i < 2; i++)
        {
            ShowMate(MateManager.Instance.mateDatas[i], uiMates[i]);
        }
    }
    public void ShowMate(MateData mateData,UIMateEdit uiMateEdit)
    {
        uiMateEdit.mateName.text = mateData.name;
        uiMateEdit.mateWinCount.text = mateData.winCount.ToString();
        ChangeColor(mateData, uiMateEdit);
    }
    public void ChangeColor(MateData mateData, UIMateEdit uiMate)
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

    #region UIMateInLevel
    public List<UIMateInLevel> uiMatesInLevels;
    #endregion
}
