using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    bool canMoveTowardsTarget = false;
    float moveSpeed = 0f;
    Vector3 target;
    bool moveToPlayer = false;

    GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.Instance;
    }


    void Update()
    {
        if (canMoveTowardsTarget)
        {
            if (moveToPlayer)
            {
                Succ(gameManager.spawnedPlayer.transform.position, moveSpeed);
            }
            else
            {
                Succ(target, moveSpeed);
            }
        }
    }

    public void Move(Transform target, float moveSpeed, float timeToWait)
    {
        this.target = target.position;
        this.moveSpeed = moveSpeed;
        canMoveTowardsTarget = true;
        StartCoroutine(WaitTimeBeforeStoppingMovement(timeToWait));
    }

    public void Move(Vector3 target, float moveSpeed, float timeToWait)
    {
        this.target = target;
        this.moveSpeed = moveSpeed;
        canMoveTowardsTarget = true;
        StartCoroutine(WaitTimeBeforeStoppingMovement(timeToWait));
    }

    public void MoveToPlayer(float moveSpeed)
    {
        this.target = gameManager.spawnedPlayer.transform.position;
        this.moveToPlayer = true;
        this.moveSpeed = moveSpeed;
        canMoveTowardsTarget = true;
    }

    void Succ(Vector3 target, float moveSpeed)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    IEnumerator WaitTimeBeforeStoppingMovement(float timeToWait)
    {
        if (timeToWait == 0)
            yield return null;
        else
        {
            yield return new WaitForSeconds(timeToWait);
            canMoveTowardsTarget = false;
        }
    }
}
