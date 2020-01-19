using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Vector3 defaultPosition = new Vector3(-3.81f, 5.97f, 0);
    public BossStage[] stages;
    int stageIndex = 0;

    public GameObject bossInfo;
    BossStage currentStage;
    GameObject currentBarrage;
    public float currentMaxHealth;
    public float currentHealth;
    Transform currentPath;
    float currentPathSpeed;
    float currentDeathTimer;

    bool hittable = false;

    BezierMove bezierMoveInstance;
    Transform pathTransform;

    void Awake()
    {
        bezierMoveInstance = GetComponent<BezierMove>();
    }

    void Start()
    {
        StartCoroutine(MoveToPosition(defaultPosition, 1f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag.Equals("PlayerBullet") || collision.tag.Equals("PlayerLazer")) && hittable)
        {
            GameManager.Instance.Score += 80;
            currentHealth -= collision.GetComponent<PlayerBullet>().Damage;
            Destroy(collision.gameObject);
            if (currentHealth <= 0)
            {
                hittable = false;
                stageIndex++;
                Debug.Log($"Stage index: {stageIndex}");
                if (stageIndex < stages.Length)
                {
                    bezierMoveInstance.StopMovement();
                    DestroyCurrentStage();
                    StartCoroutine(MoveToPosition(defaultPosition, 1f));
                }
                else
                {
                    Debug.Log("Boss Defeated");
                    Destroy(gameObject);
                }
            }
        }
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
        bezierMoveInstance.StartMovement();
        hittable = true;
    }

    private void UnpackStage(int stageIndex)
    {
        currentStage = stages[stageIndex];
        currentMaxHealth = currentStage.health;
        currentHealth = currentStage.health;
        currentPath = currentStage.path;
        currentPathSpeed = currentStage.pathSpeed;
        currentDeathTimer = currentStage.deathTimer;
    }

    private void UnpackPath(Transform path)
    {
        pathTransform = Instantiate(path, defaultPosition, Quaternion.identity);
        bezierMoveInstance.ResetValues(currentPathSpeed);
        bezierMoveInstance.UnpackPath(pathTransform);
    }

    public IEnumerator MoveToPosition(Vector3 destination, float timeToMove)
    {
        Vector3 currentPos = transform.position;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, destination, t);
            yield return null;
        }
        SetStage(stageIndex);
        StopCoroutine("MoveToPosition");
    }
}
