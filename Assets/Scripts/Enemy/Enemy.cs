using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 10.0f;
    [SerializeField] int scoreToAdd = 200;
    [SerializeField] GameObject shot = null;
    GameObject spawnedShot;
    bool barrageIsSpawned = false;

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerBullet") || collision.tag.Equals("PlayerLazer"))
        {
            health -= collision.GetComponent<Bullet>().damage;
            GameManager.Instance.score += 40;
            Destroy(collision.gameObject);
        }

        if (!barrageIsSpawned && collision.tag.Equals("PlayArea") && shot != null)
        {
            spawnedShot = Instantiate(shot, gameObject.transform);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayArea") && spawnedShot != null)
        {
            Destroy(spawnedShot);
        }
    }

    void Die()
    {
        Destroy(gameObject);
        GameManager.Instance.score += scoreToAdd;
    }
}
