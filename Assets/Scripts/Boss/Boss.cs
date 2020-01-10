using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Vector3 defaultPosition = new Vector3(-3.81f, 5.97f, 0);

    public BossStage[] stages;

    BezierMove bezierRouteMoveInstance;

    BossStage currentStage;
    GameObject currentBarrage;
    float currentHealth;
    int stageIndex = 0;
    Transform currentPath;

    Transform pathTransform;

    void Awake()
    {
        bezierRouteMoveInstance = GetComponent<BezierMove>();
    }

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
        Debug.Log(stageIndex);
        Debug.Log(stages.Length);
        if (stageIndex < stages.Length)
        {
            bezierRouteMoveInstance.pause = true;
            currentStage = stages[stageIndex];
            currentHealth = currentStage.health;
            currentPath = currentStage.path;
            pathTransform = Instantiate(currentPath, defaultPosition, Quaternion.identity);
            bezierRouteMoveInstance.path = pathTransform;
            bezierRouteMoveInstance.ResetValuesAndRun();
            Vector3 startPosition = defaultPosition;
            StartCoroutine(MoveToPosition(startPosition, 1f));
            Debug.Log("Stage Started");
        } else
        {
            Debug.Log("Boss Defeated");
            Destroy(gameObject);
        }
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
        currentBarrage = Instantiate(currentStage.barrage, transform);
        bezierRouteMoveInstance.pause = false;
        StopCoroutine("MoveToPosition");
    }
}
