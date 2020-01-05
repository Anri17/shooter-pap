using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject enemy;
    public Transform path;
    public float spawnRate = 1f;
    public float movementSpeed = 4f;
    public int spawnEnemyCount = 5;
    public bool spawnLimitedCount = true;

    GameObject enemyInstance;
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
            enemyInstance = Instantiate(enemy, gameObject.transform.position, Quaternion.identity) as GameObject;
            // spawnedEnemy.GetComponent<BezierMove>().path = path.transform;
            // spawnedEnemy.GetComponent<BezierMove>().speedModifier = movementSpeed;
            enemyInstance.GetComponent<BezierMove>().path = path;
            enemyInstance.GetComponent<BezierMove>().speedModifier = movementSpeed;
        }
        else
        {
            enemyInstance = Instantiate(enemy, gameObject.transform.position, Quaternion.identity) as GameObject;
            // spawnedEnemy.GetComponent<BezierMove>().path = path.transform;
            // spawnedEnemy.GetComponent<BezierMove>().speedModifier = movementSpeed;
            enemyInstance.GetComponent<BezierMove>().path = path;
            enemyInstance.GetComponent<BezierMove>().speedModifier = movementSpeed;
            spawnCounter++;
            if (spawnCounter >= spawnEnemyCount)
            {
                CancelInvoke("SpawnEnemy");
            }
        }
    }
}
