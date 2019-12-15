using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLevel : MonoBehaviour
{
    public float backgroundImageScrollSpeed = 1.0f;
    public GameObject backgroundImage;
    public GameObject pauseMenu;
    public GameObject player;
    public GameObject playerSpawnPoint;
    public GameObject powerItem;
    public GameObject bigPowerItem;
    public GameObject scoreItem;
    public GameObject boss;
    public AudioClip stageMusicTheme;
    public AudioClip bossMusicTheme;
    public GameObject[] waves;

    Player playerScript;
    GameObject spawnedBoss;
    GameObject spawnedPlayer;
    bool isPlayerDead = true;

    void Awake()
    {
        playerScript = player.GetComponent<Player>();
        foreach (GameObject wave in waves)
        {
            wave.SetActive(false);
        }
        pauseMenu.SetActive(false);
    }

    void Start()
    {
        MusicPlayer.Instance.PlayMusic(stageMusicTheme);
        SpawnPlayer(playerSpawnPoint.transform);
        StartCoroutine(Level());
    }
        
    void Update()
    {
        // Move Background
        transform.position += new Vector3(0, -1f, 0) * backgroundImageScrollSpeed * Time.deltaTime;

        // Go to main Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }

        if (spawnedPlayer == null)
        {
            if (player.GetComponent<Player>().lives >= 0)
            {
                SpawnPlayer(playerSpawnPoint.transform);
            }
            else
            {
                Debug.Log("Game Over!");
            }
        }
    }

    public void SpawnPlayer(Transform position)
    {
        ClearBullets();
        // detect if a player already exists in the play area
        if (spawnedPlayer == null)
        {
            spawnedPlayer = Instantiate(player, position);
        }
        else
        {
            Destroy(spawnedPlayer);
            spawnedPlayer = Instantiate(player, position);
        }
    }

    public void SpawnTestBoss()
    {
        if (spawnedBoss == null)
        {
            spawnedBoss = Instantiate(boss, new Vector3(-2.56f, 5.51f, 0), boss.transform.rotation);
        }
        else
        {
            Destroy(spawnedBoss);
            spawnedBoss = Instantiate(boss, new Vector3(-2.56f, 5.51f, 0), boss.transform.rotation);
        }
    }

    public void SpawnPowerItem()
    {
        Instantiate(powerItem, new Vector3(-2.56f, 5.51f, 0), powerItem.transform.rotation);
    }

    public void SpawnBigPowerItem()
    {
        Instantiate(bigPowerItem, new Vector3(-2.56f, 5.51f, 0), bigPowerItem.transform.rotation);
    }

    public void SpawnScoreItem()
    {
        Instantiate(scoreItem, new Vector3(-2.56f, 5.51f, 0), scoreItem.transform.rotation);
    }

    public void ClearBullets()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("EnemyBullet"))
        {
            Destroy(item);
        }
    }

    public void TogglePauseGame()
    {
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    IEnumerator Level()
    {
        Debug.Log("Level Start");
        yield return new WaitForSeconds(5.5f);
        Debug.Log("Wave 1");
        waves[0].SetActive(true);
        yield return new WaitForSeconds(11f);
        Debug.Log("Wave 2");
        waves[1].SetActive(true);
        yield return new WaitForSeconds(11f);
        Debug.Log("Boss");
        SpawnTestBoss();
        MusicPlayer.Instance.PlayMusic(bossMusicTheme);
    }
}
