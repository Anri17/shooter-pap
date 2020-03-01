using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Loading Screen")]
    [SerializeField] private Slider loadingBarSlider;
    [SerializeField] private Text loadingPercentage;
    [SerializeField] private GameObject loadingScreen;

    public GameObject player;
    public GameObject powerItem;
    public GameObject bigPowerItem;
    public GameObject scoreItem;

    public GameObject spawnedPlayer;
    public GameObject spawnedBoss;

    public long Score { get; set; }

    public AudioClip[] musicClips;

    void Awake()
    {
        loadingScreen.SetActive(false);
        MakeSingleton();
    }

    void Start()
    {
        ResetData();
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

    public void ResetData()
    {
        Score = 0;
    }

    public void LoadScene(int index)
    {
        StartCoroutine(LoadSceneCoroutine(index));
    }

    public static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private IEnumerator LoadSceneCoroutine(int index)
    {
        AsyncOperation currentLoadingData = SceneManager.LoadSceneAsync(index);

        loadingScreen.SetActive(true);

        while (!currentLoadingData.isDone)
        {
            float progress = Mathf.Clamp((currentLoadingData.progress / 0.9f), 0, 1);
            loadingBarSlider.value = progress;
            loadingPercentage.text = $"{Math.Round(progress * 100, 2)} %";
            
            yield return null;
        }
        loadingScreen.SetActive(false);
    }
}
