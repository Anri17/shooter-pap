using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float normalSpeed = 16.0f;
    public float focusSpeed = 8.0f;
    float speed = 1.0f;

	float horizontal;
	float vertical;

    void Awake()
    {
        speed = normalSpeed;
    }

    void Update()
    {
        // get movement speed
        if (Input.GetButtonDown("Focus"))
        {
            speed = focusSpeed;
            // Debug.Log("Focus Key Down");
        }
        if (Input.GetButtonUp("Focus"))
        {
            speed = normalSpeed;
            // Debug.Log("Focus Key Up");
        }

        // get input values
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // get direction of movement
        Vector3 direction = new Vector3(horizontal, vertical, 0.0f);

        // move the player position
        transform.position += direction * speed * Time.deltaTime;
        
        // debug logs
        // Debug.Log($"Player is at position: x{horizontal}, y{vertical}\n" +
        //           $"Looking at: {direction}");
    }
}
