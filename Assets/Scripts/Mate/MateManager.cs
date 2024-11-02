using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class MateData
{
    public string name;
    public Color color;
    public int winCount;
}
[Serializable]
public class MateDataList
{
    public List<MateData> mateDatas;
}
public class MateManager : Singleton<MateManager, IMateManager>, IMateManager,IJsonIO<MateDataList>
{
    #region IMateManager
    protected override void Init()
    {
        base.Init();
        //EventManager.Instance.SetMatePosEvent += SetMatePos;
        //EventManager.Instance.ShowInputNameUIEvent += OnShowInputLoad;
        //EventManager.Instance.EnterTinyLevelEvent += EnterTinyLevel;
        //EventManager.Instance.ExitLevelEvent += ExitTinyLevel;
        //EventManager.Instance.StartTrapEvent += OnOneDead;
    }
    public Mate GetMate(int mID)
    {
        return curMates[mID];
    }
    public MateData GetMateData(int mID)
    {
        return curMates[mID].mateData;
    }
    public List<MateData> GetAllMateDatas()
    {
        return mateDatas;
    }
    public void SetMatePos(int id, Vector3 pos)
    {
        curMates[id].transform.position = pos;
    }
    public MateData CreateMate(string newName, Color newColor)
    {
        foreach (var it in mateDatas)
        {
            if (it.name == newName)
            {
                it.color = newColor;
                SaveJson();
                return it;
            }
        }
        MateData mateData = new()
        {
            name = newName,
            color = newColor,
            winCount = 0
        };
        mateDataList.mateDatas.Add(mateData);
        SaveJson();
        return mateData;
    }
    public void OnEnterEditName()
    {
        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
        curMates = new();
        LoadJson();
        Debug.Log("LoadJson");
        for (int i = 0; i < 2; i++)
        {
            curMates.Add(Instantiate(Resources.Load<Mate>(matePath), gameObject.transform));
            curMates[i].gameObject.SetActive(false);
            curMates[i].mateData = mateDatas[i];
        }
    }
    public void OnEnterLevel()
    {
        foreach(var mate in curMates)
        {
            mate.OnEnterLevel();
        }
    }
    public void OnExitLevel()
    {

    }
    public void OnEnterTinyLevel()
    {
        hasOneDead = false;
        foreach (var mate in curMates)
        {
            mate.OnEnterTinyLevel();
        }
        ShowAllMates();
    }
    public void OnExitTinyLevel()
    {
        HideAllMates();
    }
    public void OnOneDead(Mate deadMate)
    {
        if (hasOneDead)
            return;
        hasOneDead = true;
        //for (int i = 0; i < 2; i++)
        //    curMates[i].gameObject.SetActive(false);
        Mate winnerMate = curMates.Find(it => it != deadMate);
        winnerMate.mateData.winCount++;
        SaveJson();
        //TODO show victory
        //GameStateMachine.Instance.VictoryMate(winnerMate);
    }
    #endregion

    #region IJsonIO
    public void SaveJson()
    {
        JsonIO.WriteCurSheet(dataPre, dataName, mateDataList);
    }

    public MateDataList LoadJson()
    {
        mateDataList = JsonIO.ReadCurSheet<MateDataList>(dataPre, dataName);
        if (mateDataList == default)
        {
            mateDataList = new();
            mateDataList.mateDatas = new();
        }
        if (mateDatas.Count < 2)
        {
            CreateMate("abirdlikefish", Color.red);
            CreateMate("Deli_", Color.blue);
        }
        return mateDataList;
    }
    #endregion

    string matePath = "Prefabs/Mate";
    string dataPre = "MateData";
    string dataName = "AllMates";
    List<Mate> curMates;
    MateDataList mateDataList;
    List<MateData> mateDatas => mateDataList.mateDatas;
    bool hasOneDead = false;


    void ShowAllMates()
    {
        foreach (var it in curMates)
            it.gameObject.SetActive(true);
    }
    void HideAllMates()
    {
        foreach (var it in curMates)
            it.gameObject.SetActive(false);
    }
}
