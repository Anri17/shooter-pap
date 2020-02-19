using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Vector3 defaultPosition = new Vector3(-3.81f, 5.97f, 0);
    public BossStage[] stages;
    int stageIndex = 0;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] AudioSource hitSound;

    BossStage currentStage;
    GameObject currentBarrage;
    float _currentMaxHealth;
    float _currentHealth;
    float _currentDeathTimer;
    Transform currentPath;
    float currentPathSpeed;

    bool hittable = false;

    public int StageCount { get; set; }
    public float CurrentMaxHealth { get => _currentMaxHealth; set => _currentMaxHealth = value; }
    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public float CurrentDeathTimer { get => _currentDeathTimer; set => _currentDeathTimer = value; }

    BezierMove bezierMove;
    Transform pathTransform;
    LevelManager levelManager;

    void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        bezierMove = GetComponent<BezierMove>();
    }

    void Start()
    {
        StageCount = stages.Length - 1;
        StartCoroutine(MoveToPosition(defaultPosition, 1f, 2f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("PlayerBullet") || collision.CompareTag("PlayerLazer")) && hittable)
        {
            GameManager.Instance.Score += 80;
            CurrentHealth -= collision.GetComponent<PlayerBullet>().Damage;
            Destroy(collision.gameObject);
            hitSound.Play();
            if (CurrentHealth <= 0)
            {
                KillBoss();
            }
        }
    }

    void KillBoss()
    {
        PlayDeathParticles(deathParticles);
        DropItems();
        hittable = false;
        StageCount--;
        stageIndex++;
        Debug.Log($"Stage index: {stageIndex}");
        if (stageIndex < stages.Length)
        {
            bezierMove.StopMovement();
            DestroyCurrentStage();
            StartCoroutine(MoveToPosition(defaultPosition, 1f, 2f));
        }
        else
        {
            Debug.Log("Boss Defeated");
            Destroy(gameObject);
        }
    }

    void DropItems()
    {
        levelManager.SpawnItems(transform.position, 5, 1, 10);
    }

    public void DestroyCurrentStage()
    {
        Destroy(currentBarrage);
        DestroyCurrentPath();
    }

    public void DestroyCurrentPath()
    {
        Destroy(pathTransform.gameObject);
    }

    public void SetStage(int stageIndex)
    {
        Debug.Log($"Stages length: {stages.Length}");
        UnpackStage(stageIndex);
        UnpackPath(currentPath);
        currentBarrage = Instantiate(currentStage.barrage, transform);
        bezierMove.StartMovement();
        hittable = true;
        StartCoroutine(CountDownDeathTimer());
    }

    private void UnpackStage(int stageIndex)
    {
        currentStage = stages[stageIndex];
        CurrentDeathTimer = currentStage.deathTimer;
        CurrentMaxHealth = currentStage.health;
        CurrentHealth = currentStage.health;
        currentPath = currentStage.path;
        currentPathSpeed = currentStage.pathSpeed;
    }

    private void UnpackPath(Transform path)
    {
        pathTransform = Instantiate(path, defaultPosition, Quaternion.identity);
        bezierMove.ResetValues(currentPathSpeed);
        bezierMove.UnpackPath(pathTransform);
    }

    private void PlayDeathParticles(ParticleSystem deathParticles)
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
    }

    public IEnumerator MoveToPosition(Vector3 destination, float timeToMove, float timeToWait)
    {
        Vector3 currentPos = transform.position;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, destination, t);
            yield return null;
        }
        yield return new WaitForSeconds(timeToWait);
        SetStage(stageIndex);
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
}
