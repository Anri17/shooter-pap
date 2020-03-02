using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    [SerializeField] float startDelay = 2f;
    [SerializeField] EnemyWave[] waves;
    [SerializeField] BossWave midBoss;
    [SerializeField] BossWave endBoss;
    [SerializeField] GameObject bossScreen;
    [SerializeField] GameObject bossHealthBar;
    [SerializeField] GameObject bossStageCount;
    [SerializeField] GameObject bossDeathTimer;
    [SerializeField] Vector3 bossSpawnPoint;
    [SerializeField] int MidbossWaveNumber;

    [SerializeField] GameObject finalScoreBoard;
    [SerializeField] Text endScreenScore;
    [SerializeField] Text endScreenLivesCalculation;
    [SerializeField] Text endScreenLives;
    [SerializeField] Text endScreenBonus;
    [SerializeField] Text endScreenFinalScore;

    [SerializeField] bool isTutorialLevel = false;

    [HideInInspector] public GameObject[] spawnedWaves;
    [HideInInspector] public GameObject spawnedBoss;

    bool reachedEnd = false;

    void Start()
    {
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
                else
                {
                    Debug.Log("Unloading Level 1");
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    private void UpdateBossHUD()
    {
        if (spawnedBoss != null)
        {
            // Update HP Bar
            bossHealthBar.GetComponent<Slider>().value = spawnedBoss.GetComponent<Boss>().CurrentHealth / spawnedBoss.GetComponent<Boss>().CurrentMaxHealth;

            // Update Current Stage Number
            bossStageCount.GetComponent<Text>().text = spawnedBoss.GetComponent<Boss>().StageCount.ToString();

            // Update Death Timer
            bossDeathTimer.GetComponent<Text>().text = spawnedBoss.GetComponent<Boss>().CurrentDeathTimer.ToString();
        }
    }

    IEnumerator PlayLevel(float waitBeforeStart, EnemyWave[] waves, BossWave midBoss, BossWave endBoss)
    {
        yield return new WaitForSeconds(waitBeforeStart);
        for (int waveIndex = 0; waveIndex < waves.Length; waveIndex++)
        {
            Debug.Log($"Launching Wave {waveIndex + 1}");
            spawnedWaves[waveIndex] = Instantiate(waves[waveIndex].Wave, transform);
            yield return new WaitForSeconds(waves[waveIndex].DelayStartTime);
            if (MidbossWaveNumber == (waveIndex + 1))
            {
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
            }
        }

        Debug.Log("Preparing to launch Mid Boss...");
        LevelManager.ClearBullets();
        LevelManager.ClearEnemies();
        yield return new WaitForSeconds(endBoss.StartDelay);
        Debug.Log("Launching Boss...");
        spawnedBoss = Instantiate(endBoss.Boss, bossSpawnPoint, Quaternion.identity, transform);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().PlayBossMusic();
        bossScreen.SetActive(true);
        yield return new WaitUntil(() => spawnedBoss == null);
        bossScreen.SetActive(false);
        yield return new WaitForSeconds(endBoss.EndDelay);
        displayFinalInfo();
        reachedEnd = true;
        GameManager.UnlockCursor();
        Time.timeScale = 1;
        Debug.Log("Level Ended");


        Debug.Log("Press Enter to EndLevel");
            
    }

    void displayFinalInfo()
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
    }
}
