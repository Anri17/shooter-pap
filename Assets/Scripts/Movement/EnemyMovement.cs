using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1.0f;
    // public float sinAmplitude = 1.0f;
    // public float sinFrequency = 1.0f;
    public Vector3 direction = new Vector3(0, -1, 0);

    float time;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

}
