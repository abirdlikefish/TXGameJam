using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorldSpaceManager
{
    public bool AddCube(BaseCube cube);
    public bool RemoveCube(BaseCube cube);
    public void RemoveCube_all();
    public List<BaseCube> GetCubes();
    public BaseCube FindByPosition(Vector3Int position);
    public void MergeGroup(List<int> groupIDList);
    public void IncreaseDepth(int groupID, int depth);
    public void DecreaseDepth(int groupID, int depth);
    public void CleanGroup(int groupID);
    public void CleanGroup_all();
    public List<BaseCube> GetCubesByGroupID(int groupID);
    public void AddCubeToGroup(BaseCube cube);
    public int GetNewID();

}
