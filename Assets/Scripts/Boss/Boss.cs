using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Vector3 defaultPosition = new Vector3(-3.81f, 5.97f, 0);

    public BossStage[] stages;
    int stageIndex = 0;

    BossStage currentStage;
    GameObject currentBarrage;
    float currentHealth;
    Transform currentPath;
    float currentPathSpeed;
    float currentDeathTimer;

    bool hittable = false;

    BezierMove bezierRouteMoveInstance;
    Transform pathTransform;

    void Awake()
    {
        bezierRouteMoveInstance = GetComponent<BezierMove>();
    }

    void Start()
    {
        StartCoroutine(MoveToPosition(defaultPosition, 1f));
        // SetStage(stageIndex);
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
                    bezierRouteMoveInstance.StopMoving();
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
        currentPathSpeed = 0;
        Destroy(pathTransform.gameObject);
    }

    public void SetStage(int stageIndex)
    {
        Debug.Log($"Stages length: {stages.Length}");
        UnpackStage(stageIndex);
        hittable = true;
    }

    private void UnpackStage(int stageIndex)
    {
        currentStage = stages[stageIndex];
        currentHealth = currentStage.health;
        currentPath = currentStage.path;
        currentPathSpeed = currentStage.pathSpeed;
        currentDeathTimer = currentStage.deathTimer;
        UnpackPath(currentPath);
        currentBarrage = Instantiate(currentStage.barrage, transform);
        bezierRouteMoveInstance.RunPath();
    }

    private void UnpackPath(Transform path)
    {
        pathTransform = Instantiate(path, defaultPosition, Quaternion.identity);
        bezierRouteMoveInstance.SetPath(pathTransform, currentPathSpeed);
        bezierRouteMoveInstance.ResetValues();
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
