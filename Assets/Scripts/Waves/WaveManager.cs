using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    [SerializeField] bool debugMode = false;

    [SerializeField] float startDelay = 2f;
    [SerializeField] L_EnemyWave[] waves;
    [SerializeField] Wave[] newWaves;
    [SerializeField] L_BossWave midBoss;
    [SerializeField] L_BossWave endBoss;
    [SerializeField] GameObject bossScreen;
    [SerializeField] public GameObject bossHealthBar;
    [SerializeField] GameObject bossStageCount;
    [SerializeField] GameObject bossDeathTimer;
    [SerializeField] Vector3 bossSpawnPoint;
    [SerializeField] int MidbossWaveNumber;

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject finalScoreBoard;
    [SerializeField] Text endScreenScore;
    [SerializeField] Text endScreenLivesCalculation;
    [SerializeField] Text endScreenLives;
    [SerializeField] Text endScreenBonus;
    [SerializeField] Text endScreenFinalScore;

    [SerializeField] DialogueConversation midBossDialogue1;
    [SerializeField] DialogueConversation midBossDialogue2;

    [SerializeField] DialogueConversation mainBossDialogue1;
    [SerializeField] DialogueConversation mainBossDialogue2;

    [SerializeField] bool isTutorialLevel = false;

    [HideInInspector] public GameObject[] spawnedWaves;
    [HideInInspector] public GameObject spawnedBoss;

    public DialogueManager dialogueManager;

    bool reachedEnd = false;

    void Start()
    {
        gameOverScreen.SetActive(false);
        finalScoreBoard.SetActive(false);
        reachedEnd = false;
        spawnedWaves = new GameObject[waves.Length];
        StartCoroutine(PlayLevel(startDelay, waves, midBoss, endBoss));
    }

    private void Update()
    {
        UpdateBossHUD();
        if (reachedEnd)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (isTutorialLevel)
                {
                    Debug.Log("Unloading Tutorial");
                    SceneManager.LoadScene(0);
                }
                else if (Application.CanStreamedLevelBeLoaded(SceneManager.GetActiveScene().buildIndex + 1))
                {
                    Debug.Log("Unloading " + SceneManager.GetActiveScene().name);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    Debug.Log("Unloading " + SceneManager.GetActiveScene().name);
                    SceneManager.LoadScene(0);
                }
            }
        }

        if (GameManager.Instance.spawnedPlayer.GetComponent<Player>().Lives < 0)
        {
            GameManager.Instance.spawnedPlayer.GetComponent<Player>().Lives = 0;
            StartCoroutine(GameOver());
        }
    }

    private void UpdateBossHUD()
    {
        if (spawnedBoss != null)
        {
            // Update HP Bar
            bossHealthBar.GetComponent<Slider>().value = spawnedBoss.GetComponent<L_Boss>().CurrentHealth / spawnedBoss.GetComponent<L_Boss>().CurrentMaxHealth;

            // Update Current Stage Number
            bossStageCount.GetComponent<Text>().text = spawnedBoss.GetComponent<L_Boss>().StageCount.ToString();

            // Update Death Timer
            bossDeathTimer.GetComponent<Text>().text = spawnedBoss.GetComponent<L_Boss>().CurrentDeathTimer.ToString();
        }
    }

    IEnumerator PlayLevel(float waitBeforeStart, L_EnemyWave[] waves, L_BossWave midBoss, L_BossWave endBoss)
    {
        yield return new WaitForSeconds(waitBeforeStart);
        for (int waveIndex = 0; waveIndex < waves.Length; waveIndex++)
        {
            Debug.Log($"Launching Wave {waveIndex + 1}");
            spawnedWaves[waveIndex] = Instantiate(waves[waveIndex].Wave, transform);
            yield return new WaitForSeconds(waves[waveIndex].DelayStartTime);
            if (MidbossWaveNumber == (waveIndex + 1))
            {
                if (midBossDialogue1 != null)
                {
                    dialogueManager.StartDialogue(midBossDialogue1);
                    yield return new WaitUntil(() => dialogueManager.dialogueEnded == true);
                }
                Debug.Log("Preparing to launch Mid Boss...");
                LevelManager.ClearBullets();
                LevelManager.ClearEnemies();
                yield return new WaitForSeconds(midBoss.StartDelay);
                Debug.Log("Launching Boss...");
                spawnedBoss = Instantiate(midBoss.Boss, bossSpawnPoint, Quaternion.identity, transform);
                bossScreen.SetActive(true);
                yield return new WaitUntil(() => spawnedBoss == null);
                bossScreen.SetActive(false);
                yield return new WaitForSeconds(midBoss.EndDelay);
                if (midBossDialogue2 != null)
                {
                    dialogueManager.StartDialogue(midBossDialogue2);
                    yield return new WaitUntil(() => dialogueManager.dialogueEnded == true);
                }
            }
            if (debugMode)
            {
                StopCoroutine("PlayLevel");
                EndLevel();
            }
        }

        Debug.Log("Preparing for Boss...");
        LevelManager.ClearBullets();
        LevelManager.ClearEnemies();
        yield return new WaitForSeconds(endBoss.StartDelay);
        Debug.Log("Launching Dialogue...");
        if (mainBossDialogue1 != null)
        {
            dialogueManager.StartDialogue(mainBossDialogue1);
            yield return new WaitUntil(() => dialogueManager.dialogueEnded == true);
        }
        Debug.Log("Launching Boss...");
        spawnedBoss = Instantiate(endBoss.Boss, bossSpawnPoint, Quaternion.identity, transform);
        bossScreen.SetActive(true);
        yield return new WaitUntil(() => spawnedBoss == null);
        bossScreen.SetActive(false);
        if (mainBossDialogue2 != null)
        {
            dialogueManager.StartDialogue(mainBossDialogue2);
            yield return new WaitUntil(() => dialogueManager.dialogueEnded == true);
        }




        EndLevel();
        Debug.Log("Press Enter to EndLevel");

        /*
        for (int waveIndex = 0; waveIndex < newWaves.Length; waveIndex++)
        {
            if (newWaves[waveIndex] is EnemyWave)
            {
                Debug.Log($"Launching Wave {waveIndex + 1}");
                spawnedWaves[waveIndex] = Instantiate(waves[waveIndex].Wave, transform);
                yield return new WaitForSeconds(waves[waveIndex].DelayStartTime);
                continue;
            }

            if (newWaves[waveIndex] is L_BossWave)
            {

                continue;
            }
        }
        */


    }



    void EndLevel()
    {
        DisplayFinalInfo();
        reachedEnd = true;
        GameManager.UnlockCursor();
        Time.timeScale = 1;
    }

    void DisplayFinalInfo()
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

    void SetBackupPlayerData()
    {
        GameManager.Instance.storedPlayerLives = GameManager.Instance.spawnedPlayer.GetComponent<Player>().Lives;
        GameManager.Instance.storedPlayerPowerLevel = GameManager.Instance.spawnedPlayer.GetComponent<Player>().PowerLevel;
        GameManager.Instance.storedPlayerBombs = GameManager.Instance.spawnedPlayer.GetComponent<Player>().Bombs;
    }

    IEnumerator GameOver()
    {
        GameManager.UnlockCursor();
        Time.timeScale = 1;
        gameOverScreen.SetActive(true);
        GameObject.Find("LevelController").GetComponent<LevelController>().canOpenMenu = false;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
