using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager
{
    static SaveManager instance;
    LevelDataSO levelDataSO;
    public static SaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SaveManager();
                instance.levelDataSO = Resources.Load<LevelDataSO>("LevelDataSO");
            }
            return instance;
        }
    }

    private string levelDataPath = "./LevelData/";
    public void LoadLevelData()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(levelDataPath);
        FileInfo[] fileInfos = directoryInfo.GetFiles();
        foreach (FileInfo fileInfo in fileInfos)
        {
            Debug.Log("Load LevelData from json");
            string levelDataJson = File.ReadAllText(fileInfo.FullName);
            LevelData levelData = JsonUtility.FromJson<LevelData>(levelDataJson);
            levelDataSO.AddLevelDataFromLastProject(levelData);
        }
    }

    public List<Vector3Int> GetCubeList(int index)
    {
        return levelDataSO.GetCubeList(index);
    }
}
