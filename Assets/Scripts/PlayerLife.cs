using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public GameObject playerMain;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"The player got hit!");
        // identify bullets collision
        if (collision.gameObject.tag == "EnemyBullet")
        {
            // destroy the player bullet bullet
            Destroy(collision.gameObject);
            Destroy(playerMain);
            --Data.lives;
            // TODO: drop power items

            // TODO: display death particles
        }
    }
}
