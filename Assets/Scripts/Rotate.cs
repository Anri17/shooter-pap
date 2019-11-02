using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float angle = 0;
    public float rotationSpeed = 8f;

    float rotationAngle = 0;

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad), 0);
        Debug.DrawRay(transform.position, direction * 3, Color.green);
        
        // rotate object
        transform.rotation = Quaternion.Euler(0, 0, -rotationAngle);
        rotationAngle += rotationSpeed;
    }
}
