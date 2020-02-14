using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float backgroundImageScrollSpeed = 1.0f;
    public GameObject backgroundImage;
    public GameObject playerSpawnPoint;
    public GameObject boss;
    public AudioClip stageMusicTheme;
    public AudioClip bossMusicTheme;
    public GameObject[] waves;
    public Vector3 bossSpawnPoints = new Vector3(1, 13, 0);
    public GameObject bossScreen;
    public GameObject bossHealthBar;

    bool moveBackground = true;

    Player player;
    GameManager gameManager;
    AudioPlayer musicPlayer;

    void Awake()
    {
        gameManager = GameManager.Instance;
        musicPlayer = AudioPlayer.Instance;
        foreach (GameObject wave in waves)
        {
            wave.SetActive(false);
        }
    }

    void Start()
    {
        bossHealthBar.GetComponent<Slider>().value = 0;
        musicPlayer.PlayMusic(stageMusicTheme);
        SpawnPlayer(playerSpawnPoint.transform);
        player = gameManager.spawnedPlayer.GetComponent<Player>();
        StartCoroutine(PlayLevel());
    }
        
    void Update()
    {
        if (gameManager.spawnedBoss != null)
        {
            bossHealthBar.GetComponent<Slider>().value = gameManager.spawnedBoss.GetComponent<Boss>().currentHealth / gameManager.spawnedBoss.GetComponent<Boss>().currentMaxHealth;
        }
        if (moveBackground)
        {
            MoveBackground(backgroundImageScrollSpeed);
        }
    }

    private void MoveBackground(float speed)
    {
        backgroundImage.transform.position += new Vector3(0, -1f, 0) * speed * Time.deltaTime;
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

    public void SpawnBoss()
    {
        if (gameManager.spawnedBoss == null)
        {
            gameManager.spawnedBoss = Instantiate(boss, bossSpawnPoints, boss.transform.rotation);
        }
        else
        {
            Destroy(gameManager.spawnedBoss);
            gameManager.spawnedBoss = Instantiate(boss, bossSpawnPoints, boss.transform.rotation);
        }
    }

    public void SpawnPowerItem()
    {
        Instantiate(gameManager.powerItem, new Vector3(-2.56f, 5.51f, 0), gameManager.powerItem.transform.rotation);
    }

    public void SpawnBigPowerItem()
    {
        Instantiate(gameManager.bigPowerItem, new Vector3(-2.56f, 5.51f, 0), gameManager.bigPowerItem.transform.rotation);
    }

    public void SpawnScoreItem()
    {
        Instantiate(gameManager.scoreItem, new Vector3(-2.56f, 5.51f, 0), gameManager.scoreItem.transform.rotation);
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

    public void SpawnItems(Vector3 position, int powerItemCount, int bigPowerItemCount, int scoreItemCount)
    {
        for (int i = 0; i < powerItemCount; i++)
        {
            Vector3 pos = position + new Vector3(Random.Range(-2f, 2), Random.Range(-0.6f, 2), 0);
            GameObject collectable = Instantiate(gameManager.powerItem, position, Quaternion.identity);
            Collectable collectableScript = collectable.GetComponent<Collectable>();
            collectableScript.Move(pos, 8, 0.6f);
        }
        for (int i = 0; i < bigPowerItemCount; i++)
        {
            Vector3 pos = position + new Vector3(Random.Range(-2f, 2), Random.Range(-0.6f, 2), 0);
            GameObject collectable = Instantiate(gameManager.bigPowerItem, position, Quaternion.identity);
            Collectable collectableScript = collectable.GetComponent<Collectable>();
            collectableScript.Move(pos, 8, 0.6f);
        }
        for (int i = 0; i < scoreItemCount; i++)
        {
            Vector3 pos = position + new Vector3(Random.Range(-2f, 2), Random.Range(-0.6f, 2), 0);
            GameObject collectable = Instantiate(gameManager.scoreItem, position, Quaternion.identity);
            Collectable collectableScript = collectable.GetComponent<Collectable>();
            collectableScript.Move(pos, 8, 0.6f);
        }
    }

    IEnumerator PlayLevel()
    {
        yield return new WaitForSeconds(48f);
        Debug.Log("Wait Time Before Boss");
        ClearEnemies();
        ClearBullets();
        moveBackground = false;
        yield return new WaitForSeconds(2f);
        Debug.Log("Mid Boss");
        bossScreen.SetActive(true);
        SpawnBoss();
        yield return new WaitUntil(() => gameManager.spawnedBoss == null);
        bossScreen.SetActive(false);
        Debug.Log("Continuing stage");
        moveBackground = true;
        yield return new WaitForSeconds(5f);
        Debug.Log("Wave 6.1");
        waves[0].SetActive(true);
        yield return new WaitForSeconds(3f);
        Debug.Log("Wave 6.2");
        waves[1].SetActive(true);
        yield return new WaitForSeconds(3f);
        Debug.Log("Wave 6.3");
        waves[2].SetActive(true);
        yield return new WaitForSeconds(3f);
        Debug.Log("Stage End");
    }
}
