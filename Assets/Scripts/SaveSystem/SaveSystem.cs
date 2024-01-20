using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
public class SaveSystem : Singleton<SaveSystem>
{
    private URunData _runData;
    public URunData RunData => new(_runData);

    private const string dataPath = "/Data/";

    private void OnEnable() => StartUp();
    
    private void StartUp()
    {
        CreateDataFolder();
        LoadRunData();
    }




    public void NewRun()
    {
        _runData = new URunData();
        SaveRunData();
    }

    public void AddPuzzle(int puzzleID)
    {
        LoadRunData();
        _runData.PuzzlesSolved.Add(puzzleID);
        SaveRunData();
    }

    public int GetLastPuzzle()
    {
        LoadRunData();
        return _runData.PuzzlesSolved[_runData.PuzzlesSolved.Count - 1];
    }




    private string GetProfilePath()
    {
        return Application.persistentDataPath + dataPath;
    }
    private void CreateDataFolder()
    {
        if(!Directory.Exists(GetProfilePath()))
            Directory.CreateDirectory(GetProfilePath());

        if(!File.Exists(GetProfilePath() + "rundata.json"))
        {
             _runData = new URunData();
            SaveRunData();
        }            
    }

    private void LoadRunData()
    {
        string path = GetProfilePath() + "rundata.json";
        _runData = JsonUtility.FromJson<URunData>(File.ReadAllText(path));
    }

    private void SaveRunData()
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