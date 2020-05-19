using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleRotation : MonoBehaviour
{
    public float angle = 0;
    public float rotationSpeed = 2f;

    float rotationAngle = 0;

    public float angleThreshhold = 60;

    bool negative = false;

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -rotationAngle);


        if (negative)
        {
            rotationAngle += -rotationSpeed;
            if (rotationAngle < -angleThreshhold)
            {
                negative = false;
            }
        }
        else if (!negative)
        {
            rotationAngle += rotationSpeed;
            if (rotationAngle > angleThreshhold)
            {
                negative = true;
            }
        }
    }

}
