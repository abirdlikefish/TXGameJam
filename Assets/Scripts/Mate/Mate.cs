using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class MateData
{
    public string name;
    public Color color;
    public int winCount;
}
public class Mate : MonoBehaviour, IJsonIO<MateData>
{
    public MateData mateData;
    public void SaveJson(string f_pathPre, string f_name)
    {
        JsonIO.WriteCurSheet(f_pathPre, f_name, mateData);
    }

    public MateData LoadJson(string f_pathPre, string f_name)
    {
        return mateData = JsonIO.ReadCurSheet<MateData>(f_pathPre, f_name);
    }
}
