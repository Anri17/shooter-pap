using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    Player playerScript;

    private void Awake()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyBullet"))
        {
            // destroy the player
            Destroy(collision.gameObject);
            playerScript.Die();
            // TODO: drop power items

            // TODO: display death particles
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            playerScript.Die();
            // TODO: drop power items

            // TODO: display death particles
        }
        if (collision.gameObject.tag.Equals("Boss"))
        {
            playerScript.Die();
            // TODO: drop power items

            // TODO: display death particles
        }
    }
}
