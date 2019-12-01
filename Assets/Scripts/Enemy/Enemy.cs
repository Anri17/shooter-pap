using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10.0f;

    void Update()
    {
        if (health <= 0)
        {
            Die(); // When health is equal or bellow 0, this enemy object dies (gets destroyed)
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log($"{collision} Hit!");
        // If this enemy objects gets hit by a player bullet or lazer, reduces health by that amount of damage
        if (collision.tag.Equals("PlayerBullet") || collision.tag.Equals("PlayerLazer"))
        {
            // reduce health
            health -= collision.GetComponent<BulletMovement>().damage;
            // add score
            Data.score += 40;
            // destroy the player bullet bullet
            Destroy(collision.gameObject);
            // particles on hit
            // Instantiate(hitParticles, transform);
        }
    }

    void Die()
    {
        // destroy the enemy
        Destroy(gameObject);
        // add score
        Data.score += 200;
    }
}
