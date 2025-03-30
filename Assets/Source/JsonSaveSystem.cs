using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveSystem
{
    void Save(GameData data);
    GameData Load();
}

// Реализация через PlayerPrefs
public class PlayerPrefsSaveSystem : MonoBehaviour, ISaveSystem
{
    public void Save(GameData data)
    {
        PlayerPrefs.SetFloat("Score", data.score);
        PlayerPrefs.SetFloat("PlayTime", data.playTime);
        PlayerPrefs.Save();
    }

    public GameData Load()
    {
        return new GameData
        {
            score = PlayerPrefs.GetFloat("Score"),
            playTime = PlayerPrefs.GetFloat("PlayTime")
        };
    }
}

// Реализация через JSON
public class JsonSaveSystem : MonoBehaviour, ISaveSystem
{
    private string savePath => $"{Application.persistentDataPath}/save.json";

    public void Save(GameData data)
    {
        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(savePath, json);
    }

    public GameData Load()
    {
        if (System.IO.File.Exists(savePath))
        {
            string json = System.IO.File.ReadAllText(savePath);
            return JsonUtility.FromJson<GameData>(json);
        }
        return new GameData();
    }
}
