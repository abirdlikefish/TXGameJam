using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    static SaveManager instance;
    LevelDataSO levelDataSO;
    public static SaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("SaveManager");
                instance = go.AddComponent<SaveManager>();
                // instance = new SaveManager();
                instance.levelDataSO = Resources.Load<LevelDataSO>("LevelDataSO");
            }
            return instance;
        }
    }

    public static void AddListener()
    {
        EventManager.Instance.EnterLevelEvent += Instance.LoadMap;
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

    public void LoadMap(int levelIndex)
    {
        foreach (Vector3Int cube in Instance.GetCubeList(levelIndex))
        {
            EventManager.Instance.AddCube(cube);
        }
    }
}
