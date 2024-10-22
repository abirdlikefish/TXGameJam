using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>, IOnGameAwakeInit,IOnLevelEnterInit
{
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
    public void InitializeOnGameAwake()
    {
        ShowAllMates();
    }

    #region UIMate
    public List<UIMate> uiMates;
    
    public void ShowAllMates()
    {
        for (int i = 0; i < 2; i++)
        {
            ShowMate(MateManager.Instance.mateDatas[i], uiMates[i]);
        }
    }
    public void ShowMate(MateData mateData,UIMate uiMate)
    {
        uiMate.mateName.text = mateData.name;
        uiMate.mateWinCount.text = mateData.winCount.ToString();
        ChangeColor(mateData, uiMate);
    }
    public void ChangeColor(MateData mateData, UIMate uiMate)
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

    public void InitializeOnLevelEnter()
    {
        forceWaits.Clear();
        //throw new System.NotImplementedException();
    }

    private void Update()
    {
        Time.timeScale = forceWaits.Count == 0 ? 1f : 0.01f;
   }
}
