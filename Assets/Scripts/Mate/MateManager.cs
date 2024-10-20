using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateManager : Singleton<MateManager>,IOnGameAwakeInit
{
    string dataPre = "MateData";
    Func<int,string> DataName = (int id) => { return "Mate" + id.ToString(); } ;
    public List<Mate> mates;
    public void InitializeOnGameAwake()
    {
        mates = new();
        for (int i = 0; i < transform.childCount; i++)
            mates.Add(transform.GetChild(i).GetComponent<Mate>());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
            WriteAllMateData();
        if (Input.GetKeyDown(KeyCode.L))
            TryReadAllMateData();
    }
    public bool TryReadAllMateData()
    {
        for(int i = 0; i < mates.Count; i++)
        {
            Mate mate = mates[i];
            if(mate.LoadJson(dataPre, DataName(i)) == default)
                return false;
        }
        return true;
    }
    public void WriteAllMateData()
    {
        for (int i = 0; i < mates.Count; i++)
        {
            Mate mate = mates[i];
            mate.SaveJson(dataPre, DataName(i));
        }
    }
}
