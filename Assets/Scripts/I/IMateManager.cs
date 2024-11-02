using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMateManager
{
    public Mate GetMate(int mID);
    public MateData GetMateData(int mID);
    public List<MateData> GetAllMateDatas();
    public void SetMatePos(int id, Vector3 pos);
    public MateData CreateMate(string newName, Color newColor);

    public void OnEnterEditName();
    public void OnEnterLevel();
    public void OnExitLevel();
    public void OnEnterTinyLevel();
    public void OnExitTinyLevel();
    public void OnOneDead(Mate deadMate);

}
