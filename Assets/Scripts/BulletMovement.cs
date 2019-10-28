using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BulletMovement : MonoBehaviour
{
    public bool isStatic = true;
    public bool isHoming = false;
    public bool isAcelerating = false;
    public bool isDesacelerating = false;

    public float speed = 1.0f;
    public float minSpeed = 1.0f;
    public float maxSpeed = 10.0f;

    void FixedUpdate()
    {
        if (isStatic)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (isAcelerating)
        {
            // TODO: acelerate bullet movement
        }
        if (isDesacelerating)
        {
            // TODO: desacelerate bullet movement
        }
        if (isHoming)
        {
            // TODO: homing bullet movement
        }
    }
}
