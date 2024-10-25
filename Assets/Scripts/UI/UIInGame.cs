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
            ShowAll();
            winningPanel.SetActive(false);
            MapSavingPanel.SetActive(false);
            NamingPanel.SetActive(false);
        };

        exitButton.onClick.AddListener(() => EventManager.Instance.ExitLevel(1));
        ConfirmSave.onClick.AddListener(() => { 
            CloseAll();
            NamingPanel.SetActive(true); 
        });
        // RejectSave.onClick.AddListener(ReturnMainMenu);

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

    public GameObject NamingPanel;

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
        CloseAll();
        winningPanel.SetActive(true);
        winningText.text = mate.mateData.name + " Win!!";

        RefreshUI(mate);

        yield return new WaitForSeconds(2f);

        ShowMapSavingPanel();
    }

    void ShowAll()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void CloseAll()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ShowMapSavingPanel()
    {
        CloseAll();
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

    }
}
