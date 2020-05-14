using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    readonly public static Vector3 GAME_FIELD_TOP_LEFT = new Vector3(-8.123814f, 9.333347f, 0);
    readonly public static Vector3 GAME_FIELD_TOP_RIGHT = new Vector3(8.123814f, 9.333347f, 0);
    readonly public static Vector3 GAME_FIELD_BOTTOM_LEFT = new Vector3(-8.123814f, -9.333339f, 0);
    readonly public static Vector3 GAME_FIELD_BOTTOM_RIGHT = new Vector3(8.123814f, -9.333339f, 0);
    readonly public static Vector3 GAME_FIELD_CENTER = new Vector3(-4.061896f, 0, 0);

    public static GameManager Instance { get; private set; }

    [Header("Loading Screen")]
    [SerializeField] private Slider loadingBarSlider;
    [SerializeField] private Text loadingPercentage;
    [SerializeField] private GameObject loadingScreen;

    public GameObject player;
    public GameObject powerItem;
    public GameObject bigPowerItem;
    public GameObject scoreItem;
    public GameObject lifeItem;
    public GameObject bombItem;

    public GameObject spawnedPlayer;
    public GameObject spawnedBoss;

    [HideInInspector] public int storedPlayerLives;
    [HideInInspector] public float storedPlayerPowerLevel;
    [HideInInspector] public int storedPlayerBombs;

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
