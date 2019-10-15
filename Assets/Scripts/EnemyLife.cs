using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float health = 10.0f;

    void Update()
    {
        // identify the health value
        if (health <= 0)
        {
            // destroy the enemy
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit!");
        // identify player bullets
        if (collision.gameObject.tag == "PlayerBullet")
        {
            // reduce health
            health -= 0.5f;
            // destroy the player bullet bullet
            Destroy(collision.gameObject);
        }
    }
}
