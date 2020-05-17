using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int stageIndex = 0;

    BossStage currentStage;
    float _currentMaxHealth;
    float _currentHealth;
    float _currentDeathTimer;

    bool hittable = false;

    public int StageCount { get; set; }
    public float CurrentMaxHealth { get => _currentMaxHealth; set => _currentMaxHealth = value; }
    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public float CurrentDeathTimer { get => _currentDeathTimer; set => _currentDeathTimer = value; }

    LevelManager levelManager;

    void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    public void StartBoss()
    {
        UnpackSpellAttacks();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("PlayerBullet") || collision.CompareTag("PlayerLazer")) && hittable)
        {
            GameManager.Instance.Score += 80;
            CurrentHealth -= collision.GetComponent<PlayerBullet>().Damage;
            Destroy(collision.gameObject);
            AudioPlayer.Instance.PlayHitSound();
            if (CurrentHealth <= 0)
            {
                GameManager.Instance.Score += currentStage.scoreWorth;
                KillBoss();
            }
        }
    }

    void KillBoss()
    {
        AudioPlayer.Instance.PlayKillSound();
        LevelManager.ClearBullets();
        StopAllCoroutines();
        DropItems(currentStage.powerItemsToDrop, currentStage.bigPowerItemsToDrop, currentStage.scoreItemsToDrop, currentStage.lifeItemsToDrop, currentStage.bombItemsToDrop);
        hittable = false;
        StageCount--;
        stageIndex++;
        Debug.Log($"Stage index: {stageIndex}");
    }

    public void DropItems(int powerItemQuantity, int bigPowerItemQuantity, int scoreItemQuantity, int lifeItemQuantity, int bombItemQuantity)
    {
        levelManager.SpawnItems(transform.position, powerItemQuantity, bigPowerItemQuantity, scoreItemQuantity, lifeItemQuantity, bombItemQuantity);
    }

    public void MoveToDefaultPosition()
    {
        StartCoroutine(MoveToPositionCoroutine(GameManager.DEFAULT_BOSS_POSITION, 1, 2));
    }

    public IEnumerator MoveToPositionCoroutine(Vector3 destination, float timeToMove, float timeToWait)
    {
        Vector3 currentPos = transform.position;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, destination, t);
            yield return null;
        }
        StartCoroutine(FillHealthBar(timeToWait));
        yield return new WaitForSeconds(timeToWait);
        StopCoroutine("MoveToPosition");
    }

    public IEnumerator CountDownDeathTimer()
    {
        while (CurrentDeathTimer > 0)
        {
            CurrentDeathTimer--;
            yield return new WaitForSeconds(1f);
        }
        KillBoss();
    }

    public Vector3 GetRandomPoint()
    {
        Debug.Log("Boss Is Getting Random point");
        float spriteWidthSize = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2;
        float spriteHeightSize = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2;
        float randX = UnityEngine.Random.Range((GameManager.GAME_FIELD_TOP_LEFT.x + spriteWidthSize) + GameManager.GAME_FIELD_CENTER.x, (GameManager.GAME_FIELD_TOP_RIGHT.x - spriteWidthSize) + GameManager.GAME_FIELD_CENTER.x);
        float randY = UnityEngine.Random.Range(1 + spriteHeightSize, (GameManager.GAME_FIELD_TOP_LEFT.y - spriteHeightSize));
        Debug.Log(GameManager.GAME_FIELD_TOP_LEFT.x + spriteWidthSize);
        Debug.Log(GameManager.GAME_FIELD_TOP_RIGHT.x - spriteWidthSize);
        Debug.Log(randX);
        return new Vector3(randX, randY, 0);
    }

    IEnumerator FillHealthBar(float timeToTakeToFill)
    {
        CurrentMaxHealth = 100f;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToTakeToFill;
            CurrentHealth += 1;
            yield return null;
        }
    }

    private void UnpackSpellAttacks()
    {
        throw new NotImplementedException();
    }
}
