using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    [SerializeField] float playerRespawnDelay = 1f;

    LevelManager levelManager;
    Player player;

    private void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        player = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Respawn();
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Respawn();
        }
        if (collision.gameObject.tag.Equals("Boss"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        levelManager.SpawnItems(transform.position, 5, 1, 0, 0, 0);
        player.RespawnPlayer(levelManager.playerSpawnPoint.transform.position, playerRespawnDelay);
    }
}
