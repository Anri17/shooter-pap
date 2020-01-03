using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public BossStage[] stages;

    BossStage currentStage;
    GameObject currentBarrage;
    float currentHealth;
    int stageIndex = 0;

    void Start()
    {
        SetStage(stageIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerBullet") || collision.tag.Equals("PlayerLazer"))
        {
            GameManager.Instance.Score += 80;
            // currentHealth -= collision.GetComponent<BulletOld>().damage;
            currentHealth -= collision.GetComponent<PlayerBullet>().Damage;
            Destroy(collision.gameObject);
            if (currentHealth <= 0)
            {
                stageIndex++;
                Destroy(currentBarrage);
                SetStage(stageIndex);
            }
        }
    }

    public void SetStage(int stageIndex)
    {
        if (stageIndex < stages.Length)
        {
            currentStage = stages[stageIndex];
            currentBarrage = Instantiate(currentStage.barrage, transform);
            currentHealth = currentStage.health;
        } else
        {
            Debug.Log("Boss Defeated");
            Destroy(gameObject);
        }
    }
}
