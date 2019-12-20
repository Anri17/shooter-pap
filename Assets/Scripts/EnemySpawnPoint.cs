using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 1f;
    public bool spawnLimitedCount = true;
    public int spawnEnemyCount = 5;
    public GameObject path;
    public float movementSpeed = 4f;

    GameObject spawnedEnemy;
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
            spawnedEnemy = Instantiate(enemy, gameObject.transform.position, Quaternion.identity) as GameObject;
            spawnedEnemy.GetComponent<EnemyMovement>().path = path;
            spawnedEnemy.GetComponent<EnemyMovement>().moveSpeed = movementSpeed;
        }
        else
        {
            spawnedEnemy = Instantiate(enemy, gameObject.transform.position, Quaternion.identity) as GameObject;
            spawnedEnemy.GetComponent<EnemyMovement>().path = path;
            spawnedEnemy.GetComponent<EnemyMovement>().moveSpeed = movementSpeed;
            spawnCounter++;
            if (spawnCounter >= spawnEnemyCount)
            {
                CancelInvoke("SpawnEnemy");
            }
        }
    }
}
