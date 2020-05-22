using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject enemy;
    public float startDelay = 0f;
    public float spawnDelay = 1f;
    public int spawnEnemyCount = 1;

    int spawnCounter;

    void Start()
    {
        spawnCounter = 0;

        if (enemy != null && spawnEnemyCount > 0)
        {
            StartCoroutine(SpawnCoroutine());
        }
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(startDelay);
        while (spawnCounter < spawnEnemyCount)
        {
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
            spawnCounter++;
            yield return new WaitForSeconds(spawnDelay);
        }
        yield return null;
    }
}
