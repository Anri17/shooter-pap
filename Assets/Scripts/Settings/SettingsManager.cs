using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    public SettingsData Settings { get => LoadSettings();
        set
        {
            SaveSettings(value);
        }
    }

    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        if (!File.Exists($"{Application.persistentDataPath}/settings.json"))
        {
            string json = JsonUtility.ToJson(new SettingsData());
            File.WriteAllText($"{Application.persistentDataPath}/settings.json", json);
        }
    }

    private void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveSettings(SettingsData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText($"{Application.persistentDataPath}/settings.json", json);
    }

    public SettingsData LoadSettings()
    {
        string settingsPath = $"{Application.persistentDataPath}/settings.json";

        string json = File.ReadAllText(settingsPath);

        return JsonUtility.FromJson<SettingsData>(json);
    }
}