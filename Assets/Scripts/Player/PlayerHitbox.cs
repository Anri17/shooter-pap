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
            // destroy the player
            Destroy(collision.gameObject);
            player.Die();
            // TODO: drop power items

            // TODO: display death particles
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            player.Die();
            // TODO: drop power items

            // TODO: display death particles
        }
        if (collision.gameObject.tag.Equals("Boss"))
        {
            player.Die();
            // TODO: drop power items

            // TODO: display death particles
        }
    }
}
