using System;
using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject playerSpawnPoint;
    public AudioClip stageMusicTheme;
    public AudioClip bossMusicTheme;

    Player player;
    GameManager gameManager;
    AudioPlayer musicPlayer;

    void Awake()
    {
        gameManager = GameManager.Instance;
        musicPlayer = AudioPlayer.Instance;
    }

    void Start()
    {
        Time.timeScale = 1;
        GameManager.LockCursor();
        musicPlayer.PlayMusic(stageMusicTheme);
        SpawnPlayer(playerSpawnPoint.transform);
        player = gameManager.spawnedPlayer.GetComponent<Player>();
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
            StartCoroutine(WaitSeconds(() => musicPlayer.PlayMusic(bossMusicTheme),  waitTime));
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

    IEnumerator WaitSeconds(Action funcToExecute, float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        funcToExecute();
    }
}
