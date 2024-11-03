using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "LevelDataSO", menuName = "LevelDataSO", order = 0)]
public class LevelDataSO : ScriptableObject
{
    // [System.Serializable]
    // public struct midCubeList
    // {
    //     public List<Vector3Int> cubeList;
    // }
    // [SerializeField]
    // private List<midCubeList> levelList = new List<midCubeList>();

    public List<LevelData> levelDataList ;

    public int levelNum => levelDataList.Count;

    public void AddLevelDataFromLastProject(LevelData_mid levelData_mid)
    {
        // levelDataList.Add(levelData);
        while(levelDataList.Count <= levelData_mid.index)
        {
            levelDataList.Add(new LevelData());
        }

        if(levelDataList[levelData_mid.index].cubeList == null)
        {
            levelDataList[levelData_mid.index].cubeList = new();
        }
        levelDataList[levelData_mid.index].cubeList.Clear();
        levelDataList[levelData_mid.index].index = levelData_mid.index;
        for(int i = 0 ; i < levelData_mid.cubeList.Count; i++)
        {
            levelDataList[levelData_mid.index].cubeList.Add(new LevelData.s_Cube(){position = levelData_mid.cubeList[i].position, color = 0});
        }

        // while(levelList.Count <= levelData.index)
        // {
        //     levelList.Add(new midCubeList(){cubeList = new List<Vector3Int>()});
        // }
        // levelList[levelData.index].cubeList.Clear();
        // for (int i = 0; i < levelData.cubeList.Count; i++)
        // {
        //     levelList[levelData.index].cubeList.Add(levelData.cubeList[i].position);
        //     // levelList[levelData.index].Add(levelData.cubeList[i].position);
        // }
        // EditorUtility.SetDirty(this);
        // AssetDatabase.SaveAssets();
        // levelNum = levelList.Count;
        return;
    }


    public LevelData GetLevelData(int index)
    {
        return levelDataList[index];
    }

    public void AddLevelData(LevelData levelData)
    {
        // Debug.Log("AddLevelData before " + levelDataList.Count);
        levelDataList.Add(levelData);
        // Debug.Log("AddLevelData after " + levelDataList.Count);
    }
    
} 
