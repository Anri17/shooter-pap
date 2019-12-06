using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float normalSpeed = 16.0f;
    public float focusSpeed = 8.0f;
    public bool enableThis = true;

    float speed = 1.0f;
	float horizontal;
	float vertical;
    Vector3 direction;

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

        // get direction 
        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            if (horizontal > 0)
            {
                direction = new Vector3(Mathf.Cos(horizontal), Mathf.Sin(vertical), 0.0f);
            }
            if (horizontal < 0)
            {
                direction = new Vector3(-Mathf.Cos(horizontal), Mathf.Sin(vertical), 0.0f);
            }
        }
        else
        {
            direction = new Vector3(horizontal, vertical, 0.0f);
        }

        // move the player to the direction defined
        transform.position += direction * speed * Time.deltaTime;
    }
}
