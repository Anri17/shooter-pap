using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] float startDelay = 2f;
    [SerializeField] EnemyWave[] waves;
    [SerializeField] BossWave boss;
    [SerializeField] GameObject bossScreen;
    [SerializeField] GameObject bossHealthBar;
    [SerializeField] GameObject bossStageCount;
    [SerializeField] Vector3 bossSpawnPoint;

    [HideInInspector] public GameObject[] spawnedWaves;
    [HideInInspector] public GameObject spawnedBoss;
    
    void Start()
    {
        spawnedWaves = new GameObject[waves.Length];
        StartCoroutine(PlayLevel(startDelay, waves, boss));
    }

    private void Update()
    {
        UpdateBossHUD();
    }

    private void UpdateBossHUD()
    {
        if (spawnedBoss != null)
        {
            // Update HP Bar
            bossHealthBar.GetComponent<Slider>().value = spawnedBoss.GetComponent<Boss>().currentHealth / spawnedBoss.GetComponent<Boss>().currentMaxHealth;

            // Update Current Stage Number
            bossStageCount.GetComponent<Text>().text = spawnedBoss.GetComponent<Boss>().StageCount.ToString();
        }
    }

    IEnumerator PlayLevel(float waitBeforeStart, EnemyWave[] waves, BossWave boss)
    {
        yield return new WaitForSeconds(waitBeforeStart);
        for (int waveIndex = 0; waveIndex < waves.Length; waveIndex++)
        {
            Debug.Log($"Launching Wave {waveIndex + 1}");
            spawnedWaves[waveIndex] = Instantiate(waves[waveIndex].Wave, transform);
            yield return new WaitForSeconds(waves[waveIndex].DelayStartTime);
            if (boss.WaveNumber == (waveIndex + 1))
            {
                Debug.Log("Preparing to launch Boss...");
                LevelManager.ClearBullets();
                LevelManager.ClearEnemies();
                yield return new WaitForSeconds(boss.StartDelay);
                Debug.Log("Launching Boss...");
                spawnedBoss = Instantiate(boss.Boss, bossSpawnPoint, Quaternion.identity, transform);
                bossScreen.SetActive(true);
                yield return new WaitUntil(() => spawnedBoss == null);
                bossScreen.SetActive(false);
                yield return new WaitForSeconds(boss.EndDelay);
            }
        }
        Debug.Log("Level Ended");
    }
}
