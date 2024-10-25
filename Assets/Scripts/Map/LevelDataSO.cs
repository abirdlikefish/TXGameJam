using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "LevelDataSO", menuName = "LevelDataSO", order = 0)]
public class LevelDataSO : ScriptableObject
{
    [System.Serializable]
    public struct midCubeList
    {
        public List<Vector3Int> cubeList;
    }
    [SerializeField]
    private List<midCubeList> levelList = new List<midCubeList>();

    public int levelNum = 0;

    public void AddLevelDataFromLastProject(LevelData levelData)
    {
        while(levelList.Count <= levelData.index)
        {
            levelList.Add(new midCubeList(){cubeList = new List<Vector3Int>()});
        }
        levelList[levelData.index].cubeList.Clear();
        for (int i = 0; i < levelData.cubeList.Count; i++)
        {
            levelList[levelData.index].cubeList.Add(levelData.cubeList[i].position);
            // levelList[levelData.index].Add(levelData.cubeList[i].position);
        }
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
        levelNum = levelList.Count;
        return;
    }


    public List<Vector3Int> GetCubeList(int index)
    {
        return levelList[index].cubeList;
    }

    public void AddCubeList(List<Vector3Int> cubeList)
    {
        levelList.Add(new midCubeList(){cubeList = cubeList});
        levelNum = levelList.Count;
    }
    
} 
