using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{
    public static SaveManager instance;
    private const string PlayerSave = "PlayerSave";
    private GameData _currentData = new GameData();

    public GameData CurrentData
    {
        get
        {
            if (_currentData != null) return _currentData;
            else return new GameData();
        }
    }

    public void Save(GameData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("PlayerSave", json);
        PlayerPrefs.Save();
    }

    //public void Load()
    //{
    //    if (!PlayerPrefs.HasKey(PlayerSave))
    //    {
    //        Debug.Log("No saved data found. Creating new GameData.");
    //        _currentData = new GameData();
    //    }

    //    string json = PlayerPrefs.GetString(PlayerSave);
    //    GameData data = JsonUtility.FromJson<GameData>(json);
    //    _currentData = data;
    //}

    public void Load()
    {
        if (!PlayerPrefs.HasKey(PlayerSave))
        {
            Debug.Log("No saved data found. Creating new GameData.");
            _currentData = new GameData();
            return; 
        }

        string json = PlayerPrefs.GetString(PlayerSave);
        GameData data = JsonUtility.FromJson<GameData>(json);

        if (data != null)
        {
            _currentData = data;
        }
        else
        {
            Debug.LogError("Failed to load GameData. Setting to new instance.");
            _currentData = new GameData();
        }
    }

    public void SaveBestResult(float newTime, List<SavePoint> frames)
    {
        if (newTime < CurrentData.BestTime || CurrentData.SavePoints.Count == 0)
        {
            CurrentData.BestTime = newTime;
            CurrentData.SavePoints = new List<SavePoint>(frames);
            Save(CurrentData);
            Debug.Log($"New best time saved: {newTime}!");
        }

        else
        {
            Debug.Log($"Current best time ({_currentData.BestTime}) is better than {newTime}. Not saving.");
        }
    }
}

[Serializable]
public class GameData
{
    public List<SavePoint> SavePoints = new List<SavePoint>();
    public float BestTime = 0;
}

