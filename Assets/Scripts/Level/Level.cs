using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
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
        playerScript = spawnedPlayer.GetComponent<Player>();
        StartCoroutine(PlayLevel());
    }
        
    void Update()
    {
        // Move Background
        backgroundImage.transform.position += new Vector3(0, -1f, 0) * backgroundImageScrollSpeed * Time.deltaTime;

        // Go to main Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }

        /*
        if (spawnedPlayer == null)
        {
            if (playerScript.lives >= 0)
            {
                SpawnPlayer(playerSpawnPoint.transform);
            }
            else
            {
                Debug.Log("Game Over!");
            }
        }
        */
    }

    public void SpawnPlayer(Transform position)
    {
        if (spawnedPlayer == null)
        {
            spawnedPlayer = Instantiate(player, position);
        }
        else
        {
            playerScript.Respawn();
        }
    }

    public void SpawnTestBoss()
    {
        if (spawnedBoss == null)
        {
            spawnedBoss = Instantiate(boss, new Vector3(-4.037f, 5.51f, 0), boss.transform.rotation);
        }
        else
        {
            Destroy(spawnedBoss);
            spawnedBoss = Instantiate(boss, new Vector3(-4.037f, 5.51f, 0), boss.transform.rotation);
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

    IEnumerator PlayLevel()
    {
        Debug.Log("Level Start");
        yield return new WaitForSeconds(5f);
        Debug.Log("Wave 1");
        waves[0].SetActive(true);
        yield return new WaitForSeconds(5f);
        Debug.Log("Wave 2");
        waves[1].SetActive(true);
        yield return new WaitForSeconds(5f);
        Debug.Log("Wave 3");
        waves[2].SetActive(true);
        yield return new WaitForSeconds(10f);
        Debug.Log("Wait Time Before Boss");
        ClearEnemies();
        ClearBullets();
        yield return new WaitForSeconds(1f);
        Debug.Log("Mid Boss");
        SpawnTestBoss();
        MusicPlayer.Instance.PlayMusic(bossMusicTheme);
    }
}
