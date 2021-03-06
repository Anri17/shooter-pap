﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject _startFlag;
    public GameObject playerSpawnPoint;
    public AudioClip stageMusicTheme;
    public int stageMusicThemeLoopTime = 0;
    public AudioClip bossMusicTheme;
    public int bossMusicThemeLoopTime = 0;

    Player player;
    GameManager gameManager;
    AudioPlayer musicPlayer;
    GameObject startFlag;

    void Awake()
    {
        gameManager = GameManager.Instance;
        musicPlayer = AudioPlayer.Instance;
    }

    void Start()
    {
        Time.timeScale = 1;
        GameManager.LockCursor();
        musicPlayer.PlayMusic(stageMusicTheme, stageMusicThemeLoopTime);
        SpawnPlayer(playerSpawnPoint.transform);
        player = gameManager.spawnedPlayer.GetComponent<Player>();

        if (SceneManager.GetActiveScene().name != "Level1")
            GetBackupPlayerData();

        if (_startFlag != null)
        {
            startFlag = Instantiate(_startFlag);
        }
    }

    public void SpawnPlayer(Transform position)
    {
        if (gameManager.spawnedPlayer == null)
        {
            gameManager.spawnedPlayer = Instantiate(gameManager.player, position);
        }
        else
        {
            player.SpawnPlayer(playerSpawnPoint.transform.position);
        }
    }

    public void GetBackupPlayerData()
    {
        player.Lives = gameManager.storedPlayerLives;
        player.PowerLevel = gameManager.storedPlayerPowerLevel;
        player.Bombs = gameManager.storedPlayerBombs;
    }

    public static void ClearBullets()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("EnemyBullet"))
        {
            Destroy(item);
        }
    }

    public static void ClearEnemies()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(item);
        }
    }

    public void PlayBossMusic(float waitTime)
    {
        if (bossMusicTheme != null)
        {
            musicPlayer.StopMusic();
            StartCoroutine(WaitSeconds(() => musicPlayer.PlayMusic(bossMusicTheme, bossMusicThemeLoopTime),  waitTime));
        }
    }

    public void SpawnItems(Vector3 position, int powerItemCount, int bigPowerItemCount, int scoreItemCount, int lifeItemCount, int bombItemCount)
    {
        for (int i = 0; i < powerItemCount; i++)
        {
            Vector3 pos = position + new Vector3(UnityEngine.Random.Range(-2f, 2), UnityEngine.Random.Range(-0.6f, 2), 0);
            GameObject collectable = Instantiate(gameManager.powerItem, position, Quaternion.identity);
            Collectable collectableScript = collectable.GetComponent<Collectable>();
            collectableScript.Move(pos, 8, 0.6f);
        }
        for (int i = 0; i < bigPowerItemCount; i++)
        {
            Vector3 pos = position + new Vector3(UnityEngine.Random.Range(-2f, 2), UnityEngine.Random.Range(-0.6f, 2), 0);
            GameObject collectable = Instantiate(gameManager.bigPowerItem, position, Quaternion.identity);
            Collectable collectableScript = collectable.GetComponent<Collectable>();
            collectableScript.Move(pos, 8, 0.6f);
        }
        for (int i = 0; i < scoreItemCount; i++)
        {
            Vector3 pos = position + new Vector3(UnityEngine.Random.Range(-2f, 2), UnityEngine.Random.Range(-0.6f, 2), 0);
            GameObject collectable = Instantiate(gameManager.scoreItem, position, Quaternion.identity);
            Collectable collectableScript = collectable.GetComponent<Collectable>();
            collectableScript.Move(pos, 8, 0.6f);
        }
        for (int i = 0; i < lifeItemCount; i++)
        {
            Vector3 pos = position + new Vector3(UnityEngine.Random.Range(-2f, 2), UnityEngine.Random.Range(-0.6f, 2), 0);
            GameObject collectable = Instantiate(gameManager.lifeItem, position, Quaternion.identity);
            Collectable collectableScript = collectable.GetComponent<Collectable>();
            collectableScript.Move(pos, 8, 0.6f);
        }
        for (int i = 0; i < bombItemCount; i++)
        {
            Vector3 pos = position + new Vector3(UnityEngine.Random.Range(-2f, 2), UnityEngine.Random.Range(-0.6f, 2), 0);
            GameObject collectable = Instantiate(gameManager.bombItem, position, Quaternion.identity);
            Collectable collectableScript = collectable.GetComponent<Collectable>();
            collectableScript.Move(pos, 8, 0.6f);
        }
    }

    IEnumerator WaitSeconds(Action methodToRun, float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        methodToRun();
    }
}
