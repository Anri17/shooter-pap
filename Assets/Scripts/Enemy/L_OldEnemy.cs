using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_OldEnemy : MonoBehaviour
{
    [SerializeField] float health = 10.0f;
    [SerializeField] int scoreToAdd = 200;
    [SerializeField] GameObject shot = null;
    [SerializeField] float shootDelay = 0f;

    GameObject spawnedShot;
    bool barrageIsSpawned = false;
    BezierMove bezierMoveInstance;

    private void Awake()
    {
        bezierMoveInstance = GetComponent<BezierMove>();
    }

    private void Start()
    {
        bezierMoveInstance.StartMovement();
    }

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
            health -= collision.GetComponent<PlayerBullet>().Damage;
            GameManager.Instance.Score += 40;
            Destroy(collision.gameObject);
        }

        if (!barrageIsSpawned && collision.tag.Equals("PlayArea") && shot != null)
        {
            StartCoroutine(Shoot());
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
        GameManager.Instance.Score += scoreToAdd;
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(shootDelay);
        spawnedShot = Instantiate(shot, gameObject.transform);
        Debug.Log(barrageIsSpawned);
        barrageIsSpawned = true;
    }
}
