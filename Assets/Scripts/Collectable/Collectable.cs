using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    bool moveTowards = false;
    float moveSpeed = 0f;
    Transform target;

    void Update()
    {
        if (moveTowards)
        {
            Succ(target, moveSpeed);
        }
    }

    public void Move(Transform target, float moveSpeed)
    {
        this.target = target;
        this.moveSpeed = moveSpeed;
        moveTowards = true;
    }

    void Succ(Transform target, float moveSpeed)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
