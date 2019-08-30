using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float normalSpeed = 8.0f;
    public float focusSpeed = 4.0f;
    float speed = 1.0f;

    void Start()
    {

    }


    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = focusSpeed;
        } else
        {
            speed = normalSpeed;
        }
    }
}
