using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] float startDelay = 2f;
    [SerializeField] EnemyWave[] waves;
    [SerializeField] BossWave midBoss;
    [SerializeField] BossWave endBoss;
    [SerializeField] GameObject bossScreen;
    [SerializeField] GameObject bossHealthBar;
    [SerializeField] GameObject bossStageCount;
    [SerializeField] Vector3 bossSpawnPoint;
    [SerializeField] int MidbossWaveNumber;

    [HideInInspector] public GameObject[] spawnedWaves;
    [HideInInspector] public GameObject spawnedMidBoss;
    [HideInInspector] public GameObject spawnedEndBoss;

    void Start()
    {
        spawnedWaves = new GameObject[waves.Length];
        StartCoroutine(PlayLevel(startDelay, waves, midBoss, endBoss));
    }

    private void Update()
    {
        UpdateBossHUD();
    }

    private void UpdateBossHUD()
    {
        if (spawnedMidBoss != null)
        {
            // Update HP Bar
            bossHealthBar.GetComponent<Slider>().value = spawnedMidBoss.GetComponent<Boss>().currentHealth / spawnedMidBoss.GetComponent<Boss>().currentMaxHealth;

            // Update Current Stage Number
            bossStageCount.GetComponent<Text>().text = spawnedMidBoss.GetComponent<Boss>().StageCount.ToString();
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
                spawnedMidBoss = Instantiate(midBoss.Boss, bossSpawnPoint, Quaternion.identity, transform);
                bossScreen.SetActive(true);
                yield return new WaitUntil(() => spawnedMidBoss == null);
                bossScreen.SetActive(false);
                yield return new WaitForSeconds(midBoss.EndDelay);
            }
        }

        Debug.Log("Preparing to launch Mid Boss...");
        LevelManager.ClearBullets();
        LevelManager.ClearEnemies();
        yield return new WaitForSeconds(endBoss.StartDelay);
        Debug.Log("Launching Boss...");
        spawnedMidBoss = Instantiate(endBoss.Boss, bossSpawnPoint, Quaternion.identity, transform);
        bossScreen.SetActive(true);
        yield return new WaitUntil(() => spawnedMidBoss == null);
        bossScreen.SetActive(false);
        yield return new WaitForSeconds(endBoss.EndDelay);


        Debug.Log("Level Ended");
    }
}
