using Pec;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton1<UIManager>
{
    #region Singleton1
    public override void Init()
    {
        //Main
        mainBtDuel.OnHighlight += () => duelAnimator.SetTrigger("Highlighted");
        mainBtDuel.OnClick += () => WillEnterEditName();
        mainBtDuel.OnExit += () => duelAnimator.SetTrigger("Normal");

        mainBtExit.OnHighlight += () => exitAnimator.SetTrigger("Highlighted");
        mainBtExit.OnClick += () => { exitAnimator.SetTrigger("Pressed"); Debug.Log("Quit"); WillQuit();};
        mainBtExit.OnExit += () => { exitAnimator.SetTrigger("Normal"); };

        //EditName
        editNameBtConfirm.onClick.AddListener(WillEnterLevel);

        //In Level
        mixBt.onClick.AddListener(ShowMixPanel);
        inLevelBtExit.onClick.AddListener(WillExitLevelFromInLevel);

        //Winning
        winBtContinue.onClick.AddListener(WillContinueTinyLevel);
        winBtExit.onClick.AddListener(WillIfSaveMap);

        //If Save Map
        ifSaveMapBtConfirm.onClick.AddListener(WillMapEdit);
        ifSaveMapBtExit.onClick.AddListener(WillExitLevelFromIfSaveMap);

        //Map Edit
        mapEditBtConfirm.onClick.AddListener(WillConfirmMapEdit);
    }
    #endregion

    #region Func - Main
    public void OnEnterMain()
    {
        Debug.Log("UI" + nameof(OnEnterMain));
        mainPanel.SetActive(true);
    }
    void WillQuit()
    {
        mainPanel.SetActive(false);
        OnQuit();
    }
    void OnQuit()
    {
        Debug.Log("UI" + nameof(OnQuit));
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    void WillEnterEditName()
    {
        Debug.Log("UI" + nameof(WillEnterEditName));
        mainPanel.SetActive(false);
        //TODO 切换状态
    }

    #endregion
    #region Func - EditName
    public void OnEnterEditName()
    {
        Debug.Log("UI" + nameof(OnEnterEditName));
        editNamePanel.SetActive(true);
        ShowAllMates();
    }
    void ShowAllMates()
    {
        for (int i = 0; i < 2; i++)
        {
            uiEditMates[i].SetMateId(i);
            ShowMate(MateManager.Instance.GetMateData(i), i);
        }
    }
    public void ShowMate(MateData mateData, int ui_mid)
    {
        uiEditMates[ui_mid].mateName.text = mateData.name;
        uiEditMates[ui_mid].mateWinCount.text = mateData.winCount.ToString();
        ChangeColor(mateData, ui_mid);
    }
    void ChangeColor(MateData mateData, int ui_mid)
    {
        uiEditMates[ui_mid].mateBase.color = SetAlpha(mateData.color, 50 / 255f);
        uiEditMates[ui_mid].mateName.color = mateData.color;
        uiEditMates[ui_mid].mateNameInputHolder.color = mateData.color;
        uiEditMates[ui_mid].mateNameInput.color = mateData.color;
        uiEditMates[ui_mid].mateWinCountC.color = mateData.color;
        uiEditMates[ui_mid].mateWinCount.color = mateData.color;
        uiEditMates[ui_mid].mateNameBG.color = mateData.color;
        uiEditMates[ui_mid].dropDownScrollBar.color = mateData.color;
    }
    Color SetAlpha(Color c, float a)
    {
        return new Color(c.r, c.g, c.b, a);
    }
    void WillEnterLevel()
    {
        Debug.Log("UI" + nameof(WillEnterLevel));
        editNamePanel.SetActive(false);
        //TODO 切换状态
    }
    #endregion
    #region Func - In Level
    public void OnEnterLevel()
    {
        Debug.Log("UI" + nameof(OnEnterLevel));
        inLevelPanel.SetActive(true);
        ReSetMixToggle();
    }
    public void RefreshMateInLevel(Mate mate)
    {
        for (int i = 0; i < uIMateProperties.Count; i++)
        {
            if (uIMateProperties[i].mate == mate)
            {
                uIMateProperties[i].Refresh();
                break;
            }
        }
    }
    void ReSetMixToggle()
    {
        foreach (var it in mixPanel.transform.GetComponentsInChildren<Toggle>())
        {
            it.isOn = false;
            it.enabled = true;
            it.interactable = true;
        }
    }
    void ShowMixPanel()
    {
        Debug.Log("UI" + nameof(ShowMixPanel));
        mixPanel.SetActive(true);
        blockMixPanel.SetActive(true);
    }
    void HideMixPanel()
    {
        Debug.Log("UI" + nameof(HideMixPanel));
        mixPanel.SetActive(false);
        blockMixPanel.SetActive(false);
    }
    public void OnEnterTinyLevel()
    {
        Debug.Log("UI" + nameof(OnEnterTinyLevel));
        HideMixPanel();
        for (int i = 0; i < uIMateProperties.Count; i++)
        {
            uIMateProperties[i].mate = MateManager.Instance.GetMate(i);
            RefreshMateInLevel(MateManager.Instance.GetMate(i));
        }
    }
    
    void WillExitLevelFromInLevel()
    {
        Debug.Log("UI" + nameof(WillExitLevelFromInLevel));
        inLevelPanel.SetActive(false);
        WillExitLevel();
        //TODO 切换状态
    }
    void WillExitLevel()
    {
        Debug.Log("UI" + nameof(WillExitLevel));
        //TODO 切换状态
    }
    #endregion
    #region Func - Winning
    public void OnWinning(Mate mate)
    {
        Debug.Log("UI" + nameof(OnWinning));
        StartCoroutine(ShowWinPanelCor(mate));
    }
    IEnumerator ShowWinPanelCor(Mate mate)
    {
        winPanel.SetActive(true);
        winText.text = mate.mateData.name + " Win!!";
        RefreshMateInLevel(mate);
        yield return new WaitForSeconds(2f);
        WillIfContinueTinyLevel();
    }
    void WillIfContinueTinyLevel()
    {
        Debug.Log("UI" + nameof(WillIfContinueTinyLevel));
        winPanel.SetActive(false);
        OnIfContinueTinyLevel();
    }
    void OnIfContinueTinyLevel()
    {
        Debug.Log("UI" + nameof(OnIfContinueTinyLevel));
        ContinueGamePanel.SetActive(true);
    }
    void WillContinueTinyLevel()
    {
        Debug.Log("UI" + nameof(WillContinueTinyLevel));
        ContinueGamePanel.SetActive(false);
        //TODO 切换状态
    }
    void WillIfSaveMap()
    {
        Debug.Log("UI" + nameof(WillIfSaveMap));
        ContinueGamePanel.SetActive(false);
        OnIfSaveMap();
    }
    #endregion
    #region Func - IfSaveMap
    void OnIfSaveMap()
    {
        Debug.Log("UI" + nameof(OnIfSaveMap));
        ifSaveMapPanel.SetActive(true);
    }
    void WillMapEdit()
    {
        Debug.Log("UI" + nameof(WillMapEdit));
        ifSaveMapPanel.SetActive(false);
        OnMapEdit();
    }
    void WillExitLevelFromIfSaveMap()
    {
        Debug.Log("UI" + nameof(WillExitLevelFromIfSaveMap));
        ifSaveMapPanel.SetActive(false);
        WillExitLevel();
    }
    #endregion
    #region Func - MapEdit
    void OnMapEdit()
    {
        Debug.Log("UI" + nameof(OnMapEdit));
        mapEditPanel.SetActive(true);
    }
    void WillConfirmMapEdit()
    {
        Debug.Log("UI" + nameof(WillConfirmMapEdit));
        mapEditPanel.SetActive(false);
        //TODO call SaveMap
        OnConfirmMapEdit();
    }
    void OnConfirmMapEdit()
    {
        Debug.Log("UI" + nameof(OnConfirmMapEdit));
        WillExitLevel();
    }
    
    #endregion

    #region GameObject
    [Header("Main")]
    public GameObject mainPanel;
    public Animator duelAnimator;
    public Animator exitAnimator;
    public UIButton mainBtDuel;
    public UIButton mainBtExit;


    [Header("EditName")]
    public GameObject editNamePanel;
    public Button editNameBtConfirm;
    public List<UIEditMateInfo> uiEditMates;

    [Header("InLevel")]
    public GameObject inLevelPanel;
    public List<UIInLevelMate> uIMateProperties = new List<UIInLevelMate>();

    public Button inLevelBtExit;
    [Header("Mix Color")]

    public GameObject mixPanel;
    public GameObject blockMixPanel;
    public Button mixBt;

    [Header("Winning && Continue")]
    public GameObject winPanel;
    public Text winText;
    public GameObject ContinueGamePanel;
    public Button winBtContinue;
    public Button winBtExit;
    
    [Header("IfSaveMap")]
    public GameObject ifSaveMapPanel;
    public Button ifSaveMapBtConfirm;
    public Button ifSaveMapBtExit;

    [Header("MapEdit")]
    public GameObject mapEditPanel;
    public Text mapName;
    public Button mapEditBtConfirm;

    
    #endregion
}
