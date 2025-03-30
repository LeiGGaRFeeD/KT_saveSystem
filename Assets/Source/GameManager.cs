using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Данные игры
    public GameData gameData = new GameData();
    private DateTime appStartTime;

    // Система сохранения (меняется в инспекторе)
    public ISaveSystem saveSystem;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSaveSystem();
            LoadGame();
            appStartTime = DateTime.Now.AddSeconds(-gameData.playTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        gameData.playTime = (float)(DateTime.Now - appStartTime).TotalSeconds;
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }

    public void AddScore(float holdTime, int basePoints)
    {
        gameData.score += basePoints * holdTime;
    }

    private void InitializeSaveSystem()
    {
        if (saveSystem == null)
            saveSystem = gameObject.AddComponent<PlayerPrefsSaveSystem>();
    }

    public void SaveGame() => saveSystem.Save(gameData);
    public void LoadGame() => gameData = saveSystem.Load();
}

[Serializable]
public class GameData
{
    public float score;
    public float playTime;
}