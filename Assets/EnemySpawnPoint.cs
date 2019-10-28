using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 100.0f;
    public bool spawnDefinedCount = false;
    public int spawnCount;

    private int spawnCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (enemy != null)
            InvokeRepeating("SpawnEnemy", 0.0f, spawnRate / 100);
    }

    void SpawnEnemy()
    {
        if (!spawnDefinedCount)
        {
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
            if (++spawnCounter >= spawnCount)
            {
                CancelInvoke("SpawnEnemy");
            }
        }
    }
}
