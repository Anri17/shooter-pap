using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 1.0f;

    void FixedUpdate()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
