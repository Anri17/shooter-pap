using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int stageAttackIndex = 0;

    public SpellAttack[] spellAttacks;
    GameObject currentAttack;
    SpellAttack currentSpellAttack;

    bool hittable = false;

    public int StageCount { get; set; }
    public float CurrentMaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public float CurrentDeathTimer { get; set; }

    LevelManager levelManager;

    void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    void Start()
    {
        StageCount = spellAttacks.Length - 1;
    }

    public void StartBoss()
    {
        Next(2);
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
                GameManager.Instance.Score += currentSpellAttack.scoreWorth;
                KillBoss();
            }
        }
    }

    void KillBoss()
    {
        AudioPlayer.Instance.PlayKillSound();
        LevelManager.ClearBullets();
        StopAllCoroutines();
        DropItems(currentSpellAttack.powerItems, currentSpellAttack.bigPowerItems, currentSpellAttack.scoreItems, currentSpellAttack.lifeItems, currentSpellAttack.bombItems);
        hittable = false;
        StageCount--;
        stageAttackIndex++;
        Debug.Log($"Stage index: {stageAttackIndex}");
        if (stageAttackIndex < spellAttacks.Length)
        {
            MoveToDefaultPosition();
            DestroyCurrentStage();
            Next(2);
        }
        else
        {
            Debug.Log("Boss Defeated");
            Destroy(gameObject);
        }
    }

    public void DropItems(int powerItemQuantity, int bigPowerItemQuantity, int scoreItemQuantity, int lifeItemQuantity, int bombItemQuantity)
    {
        levelManager.SpawnItems(transform.position, powerItemQuantity, bigPowerItemQuantity, scoreItemQuantity, lifeItemQuantity, bombItemQuantity);
    }

    public void MoveToDefaultPosition()
    {
        StartCoroutine(MoveToPositionCoroutine(GameManager.DEFAULT_BOSS_POSITION, 1));
    }

    public IEnumerator MoveToPositionCoroutine(Vector3 destination, float timeToMove)
    {
        Vector3 currentPos = transform.position;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, destination, t);
            yield return null;
        }
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

    IEnumerator FillHealthBar(float timeToFill)
    {
        CurrentMaxHealth = 100f;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToFill;
            CurrentHealth += 1;
            yield return null;
        }
    }

    private void Next(float timeToWait)
    {
        StartCoroutine(NextCoroutine(timeToWait));
    }

    private IEnumerator NextCoroutine(float timeToWait)
    {
        StartCoroutine(FillHealthBar(timeToWait));
        yield return new WaitForSeconds(timeToWait);
        SetStage(stageAttackIndex);
    }

    private void SetStage(int stageIndex)
    {
        Debug.Log("Launching Wave " + stageIndex + 1);
        currentSpellAttack = spellAttacks[stageIndex];
        CurrentMaxHealth = currentSpellAttack.health;
        CurrentHealth = currentSpellAttack.health;
        CurrentDeathTimer = currentSpellAttack.deathTimer;
        currentAttack = Instantiate(currentSpellAttack.spellAttack, transform);
        
        
        // TODO: set movement scripts
       
        
        
        hittable = true;


        StartCoroutine(CountDownDeathTimer());
    }

    private void DestroyCurrentStage()
    {
        Destroy(currentAttack);
    }
}
