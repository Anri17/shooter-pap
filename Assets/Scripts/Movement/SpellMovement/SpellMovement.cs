using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellMovement : MonoBehaviour
{
    protected Transform mainTransform;

    void Awake()
    {
        if (transform.parent != null)
        {
            mainTransform = transform.parent;
        }
        else
        {
            mainTransform = gameObject.transform;
        }
    }

    void Start()
    {
        Move();
    }

    void Move()
    {
        StartCoroutine(MoveCoroutine());
    }

    public abstract IEnumerator MoveCoroutine();

    public IEnumerator LerpMoveBoss(Vector3 destination, float timeToMove)
    {
        Vector3 currentPos = mainTransform.position;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            mainTransform.position = Vector3.Lerp(currentPos, destination, t);
            yield return null;
        }
    }
}
