using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float normalSpeed = 16.0f;
    public float focusSpeed = 8.0f;
    float speed = 1.0f;
    public Rigidbody2D rb2D;

	float horizontal;
	float vertical;

    void Start()
    {
        speed = normalSpeed;
    }

    void Update()
    {
        // define focus speed
        if (Input.GetButtonDown("Focus"))
        {
            speed = focusSpeed;
            Debug.Log("Focus Key Down");
        }
        if (Input.GetButtonUp("Focus"))
        {
            speed = normalSpeed;
            Debug.Log("Focus Key Up");
        }
    }

    void FixedUpdate()
    {
        // define inputs
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // define direction of movement
        Vector3 direction = new Vector3(horizontal, vertical, 0.0f);
        // Vector2 force = new Vector2(horizontal, vertical) * speed * Time.deltaTime;
        // rb2D.AddForce(force);

        // move the player
        transform.position += direction * speed * Time.deltaTime;
        
        // debug
        Debug.Log($"Player Moved: x{horizontal}, y {vertical}\nAt direction: {direction}");
    }
}
