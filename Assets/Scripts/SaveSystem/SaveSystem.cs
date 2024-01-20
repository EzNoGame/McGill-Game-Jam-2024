using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
public class SaveSystem : Singleton<SaveSystem>
{
    private URunData _runData;
    public URunData RunData => new(_runData);

    private const string dataPath = "/Data/";

    private void OnEnable() => LoadAllData();
    
    private void LoadAllData()
    {
        CreateDataFolder();
        LoadRunData();
    }

    private string GetProfilePath()
    {
        return Application.persistentDataPath + dataPath;
    }
    public void CreateDataFolder()
    {
        if(!Directory.Exists(GetProfilePath()))
            Directory.CreateDirectory(GetProfilePath());

        if(!File.Exists(GetProfilePath() + "rundata.json"))
        {
             _runData = new URunData();
            SaveRunData();
        }            
    }

    public void NewRun()
    {
        SaveRunData();
    }

    public void LoadRunData()
    {
        string path = GetProfilePath() + "rundata.json";
        _runData = JsonUtility.FromJson<URunData>(File.ReadAllText(path));
    }

    public void SaveRunData()
    {
        string path = GetProfilePath() + "rundata.json";
        File.WriteAllText(path, JsonUtility.ToJson(_runData, true));
    }
}

[Serializable]
public class URunData
{
    public List<int> PuzzlesSolved;

    public URunData(URunData data)
    {
        PuzzlesSolved = new List<int>(PuzzlesSolved);
    }

    public URunData()
    {
        PuzzlesSolved = new List<int>();
    }
}