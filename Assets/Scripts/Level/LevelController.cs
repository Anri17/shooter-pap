using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject pauseMenu;

    public bool canOpenMenu;
    [Header("Game Over")]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject finalScoreBoard;
    [SerializeField] Text endScreenScore;
    [SerializeField] Text endScreenLivesCalculation;
    [SerializeField] Text endScreenLives;
    [SerializeField] Text endScreenBonus;
    [SerializeField] Text endScreenFinalScore;

    public bool reachedEnd = false;

    void Awake()
    {
        canOpenMenu = true;
        pauseMenu.SetActive(false);
    }

    private void Start()
    {
        gameOverScreen.SetActive(false);
        finalScoreBoard.SetActive(false);
        reachedEnd = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canOpenMenu)
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            GameManager.LockCursor();
        }
        else
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            GameManager.UnlockCursor();
        }
    }

    public void DisplayFinalInfo()
    {
        long score = GameManager.Instance.Score;
        int clearBonus = 1000000;
        int lives = GameManager.Instance.spawnedPlayer.GetComponent<Player>().Lives;
        long finalScore = (lives * 10000) + score + clearBonus;

        finalScoreBoard.SetActive(true);
        endScreenScore.text = score.ToString("000,000,000,000");
        endScreenLivesCalculation.text = $"{lives.ToString()} * 10000";
        endScreenLives.text = (lives * 10000).ToString("000,000,000,000");
        endScreenBonus.text = clearBonus.ToString("000,000,000,000");
        endScreenFinalScore.text = finalScore.ToString("000,000,000,000");

        GameManager.Instance.Score = finalScore;

        SetBackupPlayerData();
    }

    public void SetBackupPlayerData()
    {
        GameManager.Instance.storedPlayerLives = GameManager.Instance.spawnedPlayer.GetComponent<Player>().Lives;
        GameManager.Instance.storedPlayerPowerLevel = GameManager.Instance.spawnedPlayer.GetComponent<Player>().PowerLevel;
        GameManager.Instance.storedPlayerBombs = GameManager.Instance.spawnedPlayer.GetComponent<Player>().Bombs;
    }

    public void EndLevel()
    {
        DisplayFinalInfo();
        reachedEnd = true;
        GameManager.UnlockCursor();
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCoroutine());
    }

    IEnumerator GameOverCoroutine()
    {
        GameManager.UnlockCursor();
        Time.timeScale = 1;
        gameOverScreen.SetActive(true);
        GameObject.Find("LevelController").GetComponent<LevelController>().canOpenMenu = false;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
