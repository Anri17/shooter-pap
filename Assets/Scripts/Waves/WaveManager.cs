using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    [SerializeField] BossManager bossManager;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] LevelController levelController;

    [SerializeField] float startDelay = 2f;
    [SerializeField] Wave[] waves;

    [SerializeField] bool isTutorialLevel = false;

    [HideInInspector] public GameObject[] spawnedWaves;
    [HideInInspector] public GameObject spawnedBoss;

    Coroutine level;

    void Start()
    {
        spawnedWaves = new GameObject[waves.Length];
        level = StartCoroutine(PlayLevel());
    }

    private void Update()
    {
        if (levelController.reachedEnd)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (isTutorialLevel)
                {
                    SceneManager.LoadScene(0);
                }
                else if (Application.CanStreamedLevelBeLoaded(SceneManager.GetActiveScene().buildIndex + 1))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
            }
        }

        if (GameManager.Instance.spawnedPlayer.GetComponent<Player>().Lives < 0)
        {
            GameManager.Instance.spawnedPlayer.GetComponent<Player>().Lives = 0;
            levelController.GameOver();
            StopCoroutine(level);
        }
    }

    IEnumerator PlayLevel()
    {
        yield return new WaitForSeconds(startDelay);

        for (int waveIndex = 0; waveIndex < waves.Length; waveIndex++)
        {
            if (waves[waveIndex] is EnemyWave)
            {
                EnemyWave enemyWave = (EnemyWave)waves[waveIndex];

                spawnedWaves[waveIndex] = Instantiate(enemyWave.Wave, transform);
                yield return new WaitForSeconds(enemyWave.DelayStartTime);
                continue;
            }

            if (waves[waveIndex] is BossWave)
            {
                LevelManager.ClearBullets();
                LevelManager.ClearEnemies();

                BossWave bossWave = (BossWave)waves[waveIndex];

                bossManager.spawnedBoss = Instantiate(bossWave.Boss, transform);

                if (bossWave.Dialogue1 != null)
                {
                    dialogueManager.StartDialogue(bossWave.Dialogue1);
                    yield return new WaitUntil(() => dialogueManager.dialogueEnded == true);
                }

                bossManager.ActivateBossInterface();
                bossManager.spawnedBoss.GetComponent<Boss>().StartBoss();

                yield return new WaitUntil(() => bossManager.spawnedBoss == null);

                bossManager.DeactivateBossInterface();
                LevelManager.ClearBullets();
                LevelManager.ClearEnemies();

                if (bossWave.Dialogue2 != null)
                {
                    dialogueManager.StartDialogue(bossWave.Dialogue2);
                    yield return new WaitUntil(() => dialogueManager.dialogueEnded == true);
                }

                yield return new WaitForSeconds(bossWave.EndDelay);

                continue;
            }
        }
        LevelManager.ClearBullets();
        LevelManager.ClearEnemies();
        levelController.EndLevel();
    }
}
