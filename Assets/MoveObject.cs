using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 1.0f;
    public int horizontalDirection = 1;
    public int verticalDirection = 1;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(horizontalDirection, verticalDirection, 0);
        transform.position += direction * speed * Time.deltaTime;
    }
}
