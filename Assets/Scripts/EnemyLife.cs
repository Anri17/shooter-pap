using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float health = 10.0f;
    public GameObject hitParticles;

    void Update()
    {
        // identify the health value
        if (health <= 0)
        {
            // destroy the enemy
            Destroy(gameObject);
            // add score
            Data.score += 200;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{collision} Hit!");
        // identify player bullets
        if (collision.gameObject.tag == "PlayerBullet")
        {
            // reduce health
            health -= 0.5f;
            // add score
            Data.score += 40;
            // destroy the player bullet bullet
            Destroy(collision.gameObject);
            // particles on hit
            Instantiate(hitParticles, transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
