using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
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
    public Vector3 bossSpawnPoints = new Vector3(1, 13, 0);
    public GameObject bossScreen;
    public GameObject bossHealthBar;

    Player playerScript;
    GameObject spawnedBoss;
    GameObject spawnedPlayer;

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
        bossHealthBar.GetComponent<Slider>().value = 0;
        MusicPlayer.Instance.PlayMusic(stageMusicTheme);
        SpawnPlayer(playerSpawnPoint.transform);
        playerScript = spawnedPlayer.GetComponent<Player>();
        StartCoroutine(PlayLevel());
    }
        
    void Update()
    {
        if (spawnedBoss != null)
        {
            bossHealthBar.GetComponent<Slider>().value = spawnedBoss.GetComponent<Boss>().currentHealth / spawnedBoss.GetComponent<Boss>().currentMaxHealth;
        }
        // Move Background
        backgroundImage.transform.position += new Vector3(0, -1f, 0) * backgroundImageScrollSpeed * Time.deltaTime;

        // Go to main Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }
    }

    public void SpawnPlayer(Transform position)
    {
        if (spawnedPlayer == null)
        {
            spawnedPlayer = Instantiate(player, position);
        }
        else
        {
            playerScript.Respawn(playerSpawnPoint.transform.position);
        }
    }

    public void SetBoss()
    {
        bossScreen.SetActive(true);
        StartCoroutine(FillHealthBar());
        SpawnBoss();
    }

    public void SpawnBoss()
    {
        if (spawnedBoss == null)
        {
            spawnedBoss = Instantiate(boss, bossSpawnPoints, boss.transform.rotation);
        }
        else
        {
            Destroy(spawnedBoss);
            spawnedBoss = Instantiate(boss, bossSpawnPoints, boss.transform.rotation);
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
        yield return new WaitForSeconds(8f);
        Debug.Log("Wave 2");
        waves[1].SetActive(true);
        yield return new WaitForSeconds(6f);
        Debug.Log("Wave 3");
        waves[2].SetActive(true);
        yield return new WaitForSeconds(8f);
        Debug.Log("Wave 4");
        waves[3].SetActive(true);
        yield return new WaitForSeconds(4f);
        Debug.Log("Wave 5");
        waves[4].SetActive(true);
        yield return new WaitForSeconds(6f);
        Debug.Log("Wait Time Before Boss");
        ClearEnemies();
        ClearBullets();
        yield return new WaitForSeconds(2f);
        Debug.Log("Mid Boss");
        SetBoss();
        MusicPlayer.Instance.PlayMusic(bossMusicTheme);
        yield return new WaitUntil(() => spawnedBoss == null);
        bossScreen.SetActive(false);
        Debug.Log("Continuing stage");
    }

    IEnumerator FillHealthBar()
    {
        while (bossHealthBar.GetComponent<Slider>().value < 1)
        {
            Debug.Log("Raising Health Bar");
            bossHealthBar.GetComponent<Slider>().value += 0.1f;
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
}
