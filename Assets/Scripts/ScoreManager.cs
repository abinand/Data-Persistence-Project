using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int HighScore { get; set; }
    public string HighScoreUserName { get; set; }
    public string UserName { get; set; }
    public static ScoreManager Instance;

    private const string saveFileRelativePath = "/high_score.json";
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScore();
        }
    }

    public string GetDisplayName()
    {
        if(UserName != null && UserName.Trim().Length > 0)
        {
            return $"{UserName}'s";
        }
        return "";
    }

    private class SaveData
    {
        public int highScore;
        public string username;
    }

    public void SaveScore()
    {
        SaveData saveData = new SaveData();
        saveData.highScore = HighScore;
        saveData.username = HighScoreUserName;
        string jsonData = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + saveFileRelativePath, jsonData);
    }

    public void LoadScore()
    {
        string savePath = Application.persistentDataPath + saveFileRelativePath;
        if(File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonData);
            HighScore = saveData.highScore;
            HighScoreUserName = saveData.username;
        }
    }
}
