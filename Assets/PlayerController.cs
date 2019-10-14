using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float normalSpeed = 8.0f;
    public float focusSpeed = 4.0f;
    float speed = 1.0f;
    public Rigidbody2D rb2D;

	float horizontal;
	float vertical;

    void Start()
    {

    }


    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0.0f);
        // Vector2 force = new Vector2(horizontal, vertical) * speed * Time.deltaTime;
        // rb2D.AddForce(force);

        transform.position += direction * speed * Time.deltaTime;

        Debug.Log($"{horizontal}, {vertical}\n{direction}");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = focusSpeed;
        } else
        {
            speed = normalSpeed;
        }
    }
}
