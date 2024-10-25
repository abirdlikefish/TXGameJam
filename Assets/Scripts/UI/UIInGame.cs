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

        //因为在Init中绑定了游戏的Mate
        //所以必须在退出关卡的时候使用Destroy
        //重新进入关卡时会重新创建UIInGame，从而重新绑定Mate
        EventManager.Instance.ExitLevelEvent += (_) => Destroy(gameObject);
        EventManager.Instance.refreshUIEvent += (mate) => RefreshUI(mate);
        EventManager.Instance.winningEvent += (mate) => ShowWinPanel(mate);
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            EventManager.Instance.Winning(MateManager.Instance.curMates[0]);    
        }
    }

    public void ReturnMainMenu()
    {
        //TODO 返回主菜单
        Debug.Log("返回主菜单，未完善");
        EventManager.Instance.ExitLevel(0);
    }

    public void ContinueGame()
    {
        //TODO 继续游戏
        Debug.Log("继续游戏，未实现");
    }


    public void SaveMap()
    {
        Debug.Log("保存地图");
        ReturnMainMenu();
    }
}
