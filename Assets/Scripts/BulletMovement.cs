using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BulletMovement : MonoBehaviour
{
    public bool isStatic = true;
    public bool isHoming = false;
    public bool isAccelerating = false;
    public bool isDecelerating = false;

    public float speed = 1.0f;
    public float speedDelay = 10.0f;
    public float minSpeed = 1.0f;
    public float maxSpeed = 10.0f;
    public float transitionVelocity = 4.0f;
    public float homingDelay = 0.0f;
    public float homingRadius = 10.0f;



    private float acceleration;
    private GameObject targetObject;

    void Start()
    {
        if (isAccelerating)
        {
            acceleration = minSpeed;
        }

        if (isDecelerating)
        {
            acceleration = maxSpeed;
        }
    }

    void FixedUpdate()
    {
        if (isStatic) // static bullet movement
        {
            // move bullet forward at a static speed
            transform.Translate(Vector3.up * (speed / 10) * Time.deltaTime);
        }
        if (isAccelerating) // accelerating bullet movement
        {
            // move bullet forward at an accelerating speed
            transform.Translate(Vector3.up * (acceleration / 10) * Time.deltaTime);

            // delay the velocity change
            if (!(speedDelay <= 0))
            {
                speedDelay--;
            }

            // change the acceleration value
            if ((acceleration < maxSpeed) && speedDelay <= 0)
            {
                acceleration += transitionVelocity;
                if (acceleration > maxSpeed)
                {
                    acceleration = maxSpeed;
                }
            }
        }
        if (isDecelerating) // decelerating bullet movement
        {
            // move bullet forward at a decelerating speed
            transform.Translate(Vector3.up * (acceleration / 10) * Time.deltaTime);

            // delay the velocity change
            if (!(speedDelay <= 0))
            {
                speedDelay--;
            }

            // change the acceleration value
            if ((acceleration > minSpeed) && speedDelay <= 0)
            {
                acceleration -= transitionVelocity;
                if (acceleration < minSpeed)
                {
                    acceleration = minSpeed;
                }
            }
        }
        if (isHoming) // TODO: homing bullet movement
        {
            // Detect the targetObject to aim at
            //targetObject =

            // move bullet forward at a static speed
            transform.Translate(Vector3.up * (speed / 10) * Time.deltaTime);

            var objectsInRadius = Physics.OverlapSphere(transform.position, homingRadius);

            // rotate towards the target

            // delay before bullet start homing
        }
    }
}
