using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToTarget : MonoBehaviour
{
    public GameObject target;
    // public float speed = 1.0f;
    Vector3 direction;

    void Start()
    {
        direction = target.transform.position - transform.position;
        // Vector3 newDirection = Vector3.RotateTowards(transform.position, target.transform.position, 1.0f, 0.0f);
        transform.rotation = Quaternion.LookRotation(direction);
        // transform.position += direction * speed * Time.deltaTime;


    }
}
