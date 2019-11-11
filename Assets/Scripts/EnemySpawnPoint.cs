using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject enemyObject;
    public float spawnRate = 100.0f;
    public bool spawnDefinedCount = false;
    public int spawnCount;

    private int spawnCounter = 0;
    private Transform[] routes;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Gather the routes from the child object and give it to the enemyObject Routes in it's script
        /*
        // give prefab the routes
        //        movementRoutes
        routes = transform.GetComponentsInChildren<Transform>();

        enemyObject.GetComponent<MoveObjectBezierFollow>().routes = routes;
        */

        if (enemyObject != null)
            InvokeRepeating("SpawnEnemy", 0.0f, spawnRate / 100);
    }

    void SpawnEnemy()
    {
        if (!spawnDefinedCount)
        {
            Instantiate(enemyObject, gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyObject, gameObject.transform.position, Quaternion.identity);
            if (++spawnCounter >= spawnCount)
            {
                CancelInvoke("SpawnEnemy");
            }
        }
    }
}
