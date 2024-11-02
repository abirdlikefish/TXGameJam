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

    // public static void AddListener()
    // {
    //     EventManager.Instance.EnterLevelEvent += Instance.LoadMap;
    //     EventManager.Instance.SaveCurrentMapEvent += Instance.AddCubeList;

    //     EventManager.Instance.ShowHeadLineMapEvent += () => Instance.LoadMap(0);
    // }

    private string levelDataPath = "./LevelData/";
    public void LoadLevelData()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(levelDataPath);
        FileInfo[] fileInfos = directoryInfo.GetFiles();
        foreach (FileInfo fileInfo in fileInfos)
        {
            Debug.Log("Load LevelData from json");
            string levelDataJson = File.ReadAllText(fileInfo.FullName);
            LevelData_mid levelData_mid = JsonUtility.FromJson<LevelData_mid>(levelDataJson);
            // Debug.Log("Load LevelData succeed");            
            levelDataSO.AddLevelDataFromLastProject(levelData_mid);
        }
    }

    public LevelData GetLevelData(int index)
    {
        var cubeList = levelDataSO.GetLevelData(index);
        return cubeList;
        // return levelDataSO.GetCubeList(index);
    }
    public int GetLevelNum()
    {
        return levelDataSO.levelNum;
    }
    // public List<Vector3Int> AddCubeList(List<Vector3Int> cubeList)
    // public void AddCubeList(LevelData levelData)
    // {
    //     levelDataSO.AddLevelData(levelData);
    //     // return cubeList;
    // }

    public void LoadMap(int levelIndex)
    {
#region 开发时使用
// LoadLevelData();
#endregion
        LevelData levelData = Instance.GetLevelData(levelIndex);
        foreach (var cube in levelData.cubeList)
        {
            MapManager.Instance.AddCube(cube.position, cube.color);
        }
        // foreach (Vector3Int cube in Instance.GetLevelData(levelIndex))
        // {
        //     EventManager.Instance.AddCube(cube);
        // }
    }
}
