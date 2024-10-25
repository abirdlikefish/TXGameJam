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
public class MateManager : Singleton<MateManager>,IJsonIO<MateDataList>
{
    string rPath = "Prefabs/Mate";
    string dataPre = "MateData";
    string dataName = "AllMates";
    public List<Mate> curMates;
    MateDataList mateDataList;
    public List<MateData> mateDatas => mateDataList.mateDatas;
    bool hasOneDead = false;
    public override void Init()
    {
        EventManager.Instance.SetMatePosEvent += SetMatePos;
        EventManager.Instance.ShowInputNameUIEvent += OnShowInputLoad;
        EventManager.Instance.EnterTinyLevelEvent += EnterTinyLevel;
        EventManager.Instance.ExitLevelEvent += ExitTinyLevel;

    }
    public void OnOneDead(Mate deadMate)
    {
        if (hasOneDead)
            return;
        hasOneDead = true;
        for (int i = 0; i < 2; i++)
            curMates[i].gameObject.SetActive(false);
        Mate mate = curMates.Find(it => it != deadMate);
        mate.mateData.winCount++;
        SaveJson();
        EventManager.Instance.Winning (mate);
    }
    void ExitTinyLevel(int x)
    {
        for (int i = 0; i < 2; i++)
            curMates[i].gameObject.SetActive(false);
    }
    void SetMatePos(int id,Vector3 pos)
    {
        curMates[id].transform.position = pos;
    }
    void OnShowInputLoad()
    {
        for(int i=0;i<transform.childCount;i++)
            Destroy(transform.GetChild(i).gameObject);
        curMates = new();
        LoadJson();
        Debug.Log("LoadJson");
        for (int i = 0; i < 2; i++)
        {
            curMates.Add(Instantiate(Resources.Load<Mate>(rPath), gameObject.transform));
            curMates[i].gameObject.SetActive(false);
            curMates[i].mateData = mateDatas[i];
        }
    }
    void EnterTinyLevel(int levelId)
    {
        hasOneDead = false;
        for (int i = 0; i < 2; i++)
        {
            curMates[i].gameObject.SetActive(true);
        }
    }
    public void SaveJson()
    {
        JsonIO.WriteCurSheet(dataPre, dataName, mateDataList);
    }

    public MateDataList LoadJson()
    {
        mateDataList = JsonIO.ReadCurSheet<MateDataList>(dataPre, dataName);
        if(mateDataList == default)
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
}
