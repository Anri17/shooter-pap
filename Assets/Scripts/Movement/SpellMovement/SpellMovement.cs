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
}
