using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
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
            levelManager.SpawnItems(transform.position, 5, 1, 0);
            Destroy(collision.gameObject);
            player.Die();
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            levelManager.SpawnItems(transform.position, 5, 1, 0);
            player.Die();
        }
        if (collision.gameObject.tag.Equals("Boss"))
        {
            levelManager.SpawnItems(transform.position, 5, 1, 0);
            player.Die();
        }
    }
}
