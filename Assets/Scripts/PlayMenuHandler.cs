using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuHandler : MonoBehaviour
{
    public GameObject player;

    public void RespawnPlayer()
    {
        // detect if a player already exists in the play area
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        // spawn player
        Instantiate(player, new Vector3(-6.0f, -7.0f, 0.0f), player.transform.rotation);
        // clear enemy bullets
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("EnemyBullet"))
        {
            Destroy(item);
        }
    }
}
