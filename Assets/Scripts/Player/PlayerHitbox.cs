using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyBullet"))
        {
            LevelManager.SpawnItems(transform.position, player.powerItem, 5, player.bigPowerItem, 1, player.bigPowerItem, 0);
            Destroy(collision.gameObject);
            player.Die();
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            LevelManager.SpawnItems(transform.position, player.powerItem, 5, player.bigPowerItem, 1, player.bigPowerItem, 0);
            player.Die();
        }
        if (collision.gameObject.tag.Equals("Boss"))
        {
            LevelManager.SpawnItems(transform.position, player.powerItem, 5, player.bigPowerItem, 1, player.bigPowerItem, 0);
            player.Die();
        }
    }
}
