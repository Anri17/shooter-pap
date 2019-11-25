using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 1f;
    public bool spawnLimitedCount = true;
    public int spawnEnemyCount = 5;

    int spawnCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        // spawn the enemy
        if (enemy != null)
        {
            InvokeRepeating("SpawnEnemy", 0.0f, spawnRate);
        }
    }

    void SpawnEnemy()
    {
        if (!spawnLimitedCount)
        {
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
            spawnCounter++;
            if (spawnCounter >= spawnEnemyCount)
            {
                CancelInvoke("SpawnEnemy");
            }
        }
    }
}
