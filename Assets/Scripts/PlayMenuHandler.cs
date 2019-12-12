using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public GameObject powerItem;
    public GameObject bigPowerItem;
    public GameObject scoreItem;

    GameObject spawnedBoss;
    GameObject spawnedPlayer;

    public void SpawnPlayer()
    {
        // detect if a player already exists in the play area
        if (spawnedPlayer != null)
        {
            Destroy(spawnedPlayer);
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
            spawnedBoss = Instantiate(boss, new Vector3(-2.56f, 5.51f, 0), boss.transform.rotation);
        }
        else
        {
            Destroy(spawnedBoss);
            spawnedBoss = Instantiate(boss, new Vector3(-2.56f, 5.51f, 0), boss.transform.rotation);
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
