using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelDataSO", menuName = "LevelDataSO", order = 0)]
public class LevelDataSO : ScriptableObject
{
    List<Vector3Int>[] cubeList = new List<Vector3Int>[100];
    public void AddLevelDataFromLastProject(LevelData levelData)
    {
        if (cubeList[levelData.index] == null)
        {
            cubeList[levelData.index] = new List<Vector3Int>();
        }
        else
        {
            cubeList[levelData.index].Clear();
        }
        for (int i = 0; i < levelData.cubeList.Count; i++)
        {
            cubeList[levelData.index].Add(levelData.cubeList[i].position);
        }
    }

    public List<Vector3Int> GetCubeList(int index)
    {
        return cubeList[index];
    }
    
} 
