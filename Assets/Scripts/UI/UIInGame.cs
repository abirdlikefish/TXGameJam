using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : Singleton<UIInGame>
{
    public override void Init()
    {
        EventManager.Instance.EnterTinyLevelEvent += (_) =>
        {
            for (int i = 0; i < uIMateProperties.Count && i < MateManager.Instance.curMates.Count; i++) 
            {
                uIMateProperties[i].mate = MateManager.Instance.curMates[i];

                RefreshUI(MateManager.Instance.curMates[i]);
            }
            ShowAllChildren();
            winningPanel.SetActive(false);
            MapSavingPanel.SetActive(false);
            NamingPanel.SetActive(false);
            ContinueGamePanel.SetActive(false);
            mixPanel.SetActive(false);
        };

        exitButton.onClick.AddListener(() => EventManager.Instance.ExitLevel(1));

        ContinueButtn.onClick.AddListener(ContinueGame);
        CancelButton.onClick.AddListener(ShowMapSavingPanel);

        ConfirmSave.onClick.AddListener(() => { 
            CloseAllChildren();
            NamingPanel.SetActive(true); 
        });
        RejectSave.onClick.AddListener(ReturnMainMenu);
        ConfirmNamingButton.onClick.AddListener(SaveMap);

        //��Ϊ��Init�а�����Ϸ��Mate
        //���Ա������˳��ؿ���ʱ��ʹ��Destroy
        //���½���ؿ�ʱ�����´���UIInGame���Ӷ����°�Mate
        EventManager.Instance.EnterLevelEvent += (x) => gameObject.SetActive(true);
        EventManager.Instance.EnterLevelEvent += (x) => SetToggle();
        EventManager.Instance.ExitLevelEvent += (_) => gameObject.SetActive(false);
        EventManager.Instance.ExitLevelEvent +=(x) => gameObject.SetActive(false);
        EventManager.Instance.ExitTinyLevelEvent += () => ShowMixPanel(); 
        EventManager.Instance.refreshUIEvent += (mate) => RefreshUI(mate);
        EventManager.Instance.winningEvent += (mate) => ShowWinPanel(mate);
    }
    void SetToggle()
    {
        foreach (var it in mixPanel.transform.GetComponentsInChildren<Toggle>())
        {
            it.isOn = false;
            it.enabled = true;
        }
    }
    void ShowMixPanel()
    {
        mixPanel.SetActive(true);
        blockMixPanel.SetActive(false);
    }
    void HideMixPanel()
    {
        mixPanel.SetActive(false);
        blockMixPanel.SetActive(true);
    }

    public List<UIMateProperty> uIMateProperties = new List<UIMateProperty>();

    public Button exitButton;

    public GameObject winningPanel;
    public Text winningText;

    public GameObject MapSavingPanel;
    public Button ConfirmSave;
    public Button RejectSave;

    public GameObject ContinueGamePanel;
    public Button ContinueButtn;
    public Button CancelButton;

    public GameObject NamingPanel;
    public Text mapName;
    public Button ConfirmNamingButton;

    public GameObject mixPanel;
    public GameObject blockMixPanel;
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

    public void ShowWinPanel(Mate mate)
    {
        StartCoroutine(ShowWinPanelCor(mate));
    }

    IEnumerator ShowWinPanelCor(Mate mate)
    {
        CloseAllChildren();
        winningPanel.SetActive(true);
        winningText.text = mate.mateData.name + " Win!!";

        RefreshUI(mate);

        yield return new WaitForSeconds(2f);

        ShowContinueGamePanel();
    }

    void ShowAllChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void CloseAllChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ShowContinueGamePanel()
    {
        CloseAllChildren();
        ContinueGamePanel.SetActive(true);
    }

    public void ShowMapSavingPanel()
    {
        CloseAllChildren();
        MapSavingPanel.SetActive(true);
    }

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.V))
    //    {
    //        EventManager.Instance.Winning(MateManager.Instance.curMates[0]);    
    //    }
    //}

    public void ReturnMainMenu()
    {
        //TODO �������˵�
        // Debug.Log("�������˵���δ����");
        EventManager.Instance.ExitLevel(0);
    }

    public void ContinueGame()
    {
        EventManager.Instance.ExitTinyLevel();
        //TODO ������Ϸ
        // Debug.Log("������Ϸ��δʵ��");
    }


    public void SaveMap()
    {
        EventManager.Instance.SaveCurrentMap_beg();
        Debug.Log("�����ͼ");
        ReturnMainMenu();
    }
}
