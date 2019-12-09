using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject testBoss;
    public GameObject powerItem;
    public GameObject bigPowerItem;
    public GameObject scoreItem;

    GameObject spawnedBoss;

    public void RespawnPlayer()
    {
        // detect if a player already exists in the play area
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        // spawn player
        Instantiate(player, new Vector3(-2.21f, -6.56f, 0.0f), player.transform.rotation);
        // clear enemy bullets
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("EnemyBullet"))
        {
            Destroy(item);
        }
    }

    public void SpawnTestBoss()
    {
        if (spawnedBoss == null)
        {
            spawnedBoss = Instantiate(testBoss, new Vector3(-2.56f, 5.51f, 0), testBoss.transform.rotation);
        }
        else
        {
            Destroy(spawnedBoss);
            spawnedBoss = Instantiate(testBoss, new Vector3(-2.56f, 5.51f, 0), testBoss.transform.rotation);
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
}
