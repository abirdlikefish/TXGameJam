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
public class MateManager : Singleton<MateManager>, IOnGameAwakeInit, IJsonIO<MateDataList>
{
    string dataPre = "MateData";
    string dataName = "AllMates";
    //Func<int,string> DataName = (int id) => { return "Mate" + id.ToString(); } ;
    public List<Mate> curMates;
    public MateDataList mateDataList;
    public List<MateData> mateDatas => mateDataList.mateDatas;
    public void InitializeOnGameAwake()
    {
        curMates = new();
        LoadJson();
        for (int i = 0; i < transform.childCount; i++)
        {
            curMates.Add(transform.GetChild(i).GetComponent<Mate>());
            curMates[i].mateData = mateDatas[i];
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
            SaveJson();
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
    public MateData SetMateColor(string baseName, Color newColor)
    {
        foreach (var it in mateDatas)
        {
            if (it.name == baseName)
            {
                it.color = newColor;
                SaveJson();
                return it;
            }
        }
        return CreateMate(baseName, newColor);
    }
}
