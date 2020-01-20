using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float normalSpeed = 8.0f;
    [SerializeField] float focusSpeed = 4.0f;

    float horizontal;
    float vertical;
    Vector3 direction;
    Player player;
    void Awake()
    {
        player = GetComponent<Player>();
        player.Speed = normalSpeed;
    }

    void Update()
    {
        SetDirection();
        Move();
    }

    public void Move()
    {
        transform.position += direction * player.Speed * Time.deltaTime;
    }

    public void SetDirection()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // get speed value
        if (Input.GetButtonDown("Focus"))
        {
            player.Speed = focusSpeed;
        }
        if (Input.GetButtonUp("Focus"))
        {
            player.Speed = normalSpeed;
        }

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
    }
}
